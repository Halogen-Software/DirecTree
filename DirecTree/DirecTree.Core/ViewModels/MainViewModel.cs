using System.Collections.Generic;
using DirecTree.Core.ViewModels.Base;
using MvvmCross.Core.ViewModels;

namespace DirecTree.Core.ViewModels
{
    public class MainViewModel
        : BaseViewModel
    {
        public MainViewModel()
        {
            SetupListItems();
        }

        private string value;
        private List<string> _sideBarListItems;
        public List<string> SideBarListItems
        {
            get { return _sideBarListItems; }
            set { SetProperty(ref _sideBarListItems, value); }
        }

        private void SetupListItems()
        {
            SideBarListItems = new List<string>();

            SideBarListItems.Add("Home");
            SideBarListItems.Add("Sign in");
        }
    }
}
