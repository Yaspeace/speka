using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Speka.Models.Base
{
    public class BasePropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new(name));
    }
}
