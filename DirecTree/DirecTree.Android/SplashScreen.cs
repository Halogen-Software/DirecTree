using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Util;
using Android.Views;
using DirecTree.Android.Views;
using MvvmCross.Droid.Views;

[Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
public class SplashScreen : MvxActivity
{
    static readonly string TAG = "X:" + typeof(SplashScreen).Name;

    public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
    {
        base.OnCreate(savedInstanceState, persistentState);
        Log.Debug(TAG, "SplashActivity.OnCreate");
    }

    protected override void OnResume()
    {
        base.OnResume();

        Task startupWork = new Task(() => {
            Log.Debug(TAG, "Performing some startup work that takes a bit of time.");
            Task.Delay(5000);  // Simulate a bit of startup work.
            Log.Debug(TAG, "Working in the background - important stuff.");
        });

        startupWork.ContinueWith(t => {
            Log.Debug(TAG, "Work is finished - start Activity1.");
            StartActivity(new Intent(Application.Context, typeof(MainView)));
        }, TaskScheduler.FromCurrentSynchronizationContext());

        startupWork.Start();
    }
}
