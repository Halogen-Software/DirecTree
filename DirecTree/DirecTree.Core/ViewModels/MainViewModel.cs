using System.Collections.Generic;
using DirecTree.Core.ViewModels.Base;


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
        
        private void SetupListItems()
        {
            SideBarListItems = new List<string>();

            SideBarListItems.Add("Home");
            SideBarListItems.Add("View profile");
            SideBarListItems.Add("Sign in");
        }
    }
}
