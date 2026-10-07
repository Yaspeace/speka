using Microsoft.Win32;
using Speka.Models;
using Speka.Models.Specifications;
using Speka.Models.Specifications.OpenapiSpec;
using Speka.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Speka.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly FileSystemService fileSystemService = new();
        private readonly OpenapiService openapiService = new();

        public ICommand OpenFolderCommand { get; }

        public ICommand NavigateUpCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public FileSystemNode? ProjectRoot
        {
            get;
            set { field = value; OnPropertyChanged(); }
        }

        public FileSystemNode? CurrentRoot
        {
            get;
            set { field = value; OnPropertyChanged(); }
        }

        public FileSystemNode? SelectedItem
        {
            get;
            set { field = value; OnPropertyChanged(); }
        }

        public string? CurrentPath
        {
            get;
            private set { field = value; OnPropertyChanged(); }
        }

        public Specification? CurrentSpec
        {
            get;
            private set { field = value; OnPropertyChanged(); }
        }

        public MainViewModel()
        {
            OpenFolderCommand = new RelayCommand(_ => OpenFolder());
            // OpenItemCommand = new RelayCommand(arg => OpenItem(arg as FileSystemNode));
            NavigateUpCommand = new RelayCommand(_ => NavigateUp());
        }

        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private void OpenFolder()
        {
            var dialog = new OpenFolderDialog
            {
                Title = "Выберите папку спецификаций"
            };

            if (dialog.ShowDialog() == true)
            {
                var root = fileSystemService.ScanDirectory(dialog.FolderName);
                ProjectRoot = root;
                CurrentRoot = root;
                SelectedItem = null;
            }
        }

        public void OpenItem(FileSystemNode? node)
        {
            if (node is null) return;

            if (node.IsFile)
            {
                SelectedItem = node;
                var schema = openapiService.ReadSchemaFromFile(node.FullPath);
                CurrentSpec = GetSpecFromRaw(schema);
            }
            else
            {
                CurrentRoot = node;
                SelectedItem = null;
            }
        }

        private void NavigateUp()
        {
            if (CurrentRoot?.Parent is null) return;

            CurrentRoot = CurrentRoot.Parent;
            SelectedItem = null;
        }

        private Specification GetSpecFromRaw(OpenapiSchema schema)
        {
            return new Specification
            {
                ApiOverview = new()
                {
                    Title = schema.Info.Title,
                    Description = schema.Info.Description
                },
                Models = new ObservableCollection<ApiModel>(GetModelsFromRaw(schema.Components)),
                Paths = new ObservableCollection<ApiPath>(schema.Paths?.Select(kv => new ApiPath() { Name = kv.Key}) ?? [])
            };
        }

        private IEnumerable<ApiModel> GetModelsFromRaw(OpenapiComponents components)
        {
            return components.Schemas.Select(kv => new ApiModel()
            {
                Name = kv.Key,
                Description = kv.Value.Description
            });
        }
    }
}
