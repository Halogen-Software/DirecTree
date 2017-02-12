using Android.OS;
using Android.Views;
using DirecTree.Android.Views.Base;
using DirecTree.Core.ViewModels;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace DirecTree.Android.Views.Fragments
{
    public class SignInFragment : BaseFragment
    {
        public override IMvxViewModel ViewModel => Mvx.Resolve<SignInViewModel>();

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.SignInFragment, null);
        }
    }
}