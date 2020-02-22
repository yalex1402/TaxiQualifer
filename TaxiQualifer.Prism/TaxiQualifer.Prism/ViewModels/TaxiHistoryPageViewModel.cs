using Prism.Navigation;

namespace TaxiQualifer.Prism.ViewModels
{
    public class TaxiHistoryPageViewModel : ViewModelBase
    {
        public TaxiHistoryPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Taxi History";
        }

    }
}
