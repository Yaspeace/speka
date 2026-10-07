using Speka.Models.Base;

namespace Speka.Models.Specifications
{
    public class ApiPath : BasePropertyChanged
    {
        public required string Name
        {
            get;
            set { field = value; OnPropertyChanged(); }
        }
    }
}
