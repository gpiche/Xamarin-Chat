using Android.App;
using Android.Gms.Common;
using Chat.Services;
using Firebase.Iid;
using Android.Util;

namespace Chat.Droid.Firebase
{
    public class NotificationService : INotificationService
    {
        private readonly IAlertService _alertService;

        public NotificationService(IAlertService alertService)
        {
            _alertService = alertService;
        }


        public void Suscribe()
        {
            Log.Debug("allo", "InstanceID token: " + FirebaseInstanceId.Instance.Token);
        }


        public void IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(Application.Context);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                {
                    GoogleApiAvailability.Instance.GetErrorString(resultCode);
                }
                else
                {
                    _alertService.LongAlert("This device is not supported");
                 
                }
              
            }
            else
            {
                _alertService.LongAlert("Google Play Services is available.");
               
            }
        }
    }
}