using Prism.Navigation;
using TaxiQualifer.Prism.Helpers;

namespace TaxiQualifer.Prism.ViewModels
{
    public class MyTripPageViewModel : ViewModelBase
    {
        public MyTripPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = Languages.MyTrip;
        }
    }

}
