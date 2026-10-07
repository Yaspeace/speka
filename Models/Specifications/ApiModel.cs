using Speka.Models.Base;

namespace Speka.Models.Specifications
{
    public class ApiModel : BasePropertyChanged
    {
        public required string Name
        {
            get;
            set { field = value; OnPropertyChanged(); }
        }

        public string? Description
        {
            get;
            set { field = value; OnPropertyChanged(); }
        }
    }
}
