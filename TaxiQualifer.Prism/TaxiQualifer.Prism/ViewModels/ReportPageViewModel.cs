using Prism.Navigation;

namespace TaxiQualifer.Prism.ViewModels
{
    public class ReportPageViewModel : ViewModelBase
    {
        public ReportPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Report an incident";
        }
    }
}
