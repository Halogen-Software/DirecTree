using DirecTree.Core.ViewModels.Base;
using MvvmCross.Core.ViewModels;

namespace DirecTree.Core.ViewModels
{
    public class MainViewModel 
        : BaseViewModel
    {
        private string _hello = "Hello MvvmCross";
        public string Hello
        { 
            get { return _hello; }
            set { SetProperty (ref _hello, value); }
        }
    }
}
