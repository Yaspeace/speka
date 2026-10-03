using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Speka.Models.Specifications
{
    public class ApiOverview : INotifyPropertyChanged
    {
        public string? Title
        {
            get;
            set { field = value; OnPropertyChanged(); }
        }

        public string? Description
        {
            get;
            set { field = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new(name));
    }
}
