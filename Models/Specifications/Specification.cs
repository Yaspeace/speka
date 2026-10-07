using Speka.Models.Base;
using System.Collections.ObjectModel;

namespace Speka.Models.Specifications
{
    public class Specification : BasePropertyChanged
    {
        public ApiOverview? ApiOverview
        {
            get;
            set { field = value; OnPropertyChanged(); }
        }

        public ObservableCollection<ApiModel> Models
        {
            get;
            set { field = value; OnPropertyChanged(); }
        } = [];

        public ObservableCollection<ApiPath> Paths
        {
            get;
            set { field = value; OnPropertyChanged(); }
        } = [];
    }
}
