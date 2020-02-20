using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

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
