using Android.App;
using Android.Content.PM;
using Android.OS;
using Prism;
using Prism.Ioc;
using Android.Gms.Common;
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;
using Chat.Droid.Firebase;
using Chat.Droid.Services;
using Chat.Services;
using Plugin.Toasts;
using Xamarin.Forms;


namespace Chat.Droid
{
    [Activity(Label = "Chat", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            DependencyService.Register<ToastNotification>();
            ToastNotification.Init(this);

            base.OnCreate(bundle);


            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));
             
        }

        
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            container.RegisterSingleton< INotificationService, NotificationService>();
            container.RegisterSingleton<IAlertService, AlertService>();
        }
    }


}

