using Prism.Navigation;

namespace TaxiQualifer.Prism.ViewModels
{
    public class GroupPageViewModel : ViewModelBase
    {
        public GroupPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Admin my user group";
        }
    }
}
