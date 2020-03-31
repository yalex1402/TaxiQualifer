using Prism.Commands;
using Prism.Navigation;
using TaxiQualifer.Common.Helpers;
using TaxiQualifer.Prism.Views;

namespace TaxiQualifer.Prism.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _startTripCommand;

        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Taxi Qualifier";
            _navigationService = navigationService;
        }

        public DelegateCommand StartTripCommand => _startTripCommand ?? (_startTripCommand = new DelegateCommand(StartTripAsync));

        private async void StartTripAsync()
        {
            if (Settings.IsLogin)
            {
                await _navigationService.NavigateAsync(nameof(StartTripPage));
            }
            else
            {
                await _navigationService.NavigateAsync(nameof(LoginPage));
            }
        }

    }
}
