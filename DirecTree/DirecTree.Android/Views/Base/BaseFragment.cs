using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;

namespace DirecTree.Android.Views.Base
{
    public class BaseFragment : MvxFragment
    {
        public Context context;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            context = Application.Context;
            return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}