using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace Speka.Models
{
    public class FileSystemNode(string path, bool isFile, FileSystemNode? parent, string? displayName = null) : INotifyPropertyChanged
    {
        public string Name
        {
            get => field;
            set { field = value; OnPropertyChanged(); }
        } = displayName ?? Path.GetFileName(path);

        public bool IsSelected
        {
            get => field;
            set { field = value; OnPropertyChanged(); }
        }

        public string FullPath { get; } = path;

        public bool IsFile { get; } = isFile;

        public FileSystemNode? Parent
        {
            get;
            set { field = value; OnPropertyChanged(); }
        } = parent;

        public ObservableCollection<FileSystemNode> Children { get; } = [];

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new(name));
    }
}
