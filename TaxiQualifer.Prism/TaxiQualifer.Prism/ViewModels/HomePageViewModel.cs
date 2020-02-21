using Prism.Navigation;

namespace TaxiQualifer.Prism.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {

        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Taxi Qualifier";
        }
    }
}
