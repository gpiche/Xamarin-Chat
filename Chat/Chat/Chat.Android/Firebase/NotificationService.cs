using Chat.Services;
using Firebase.Iid;
using Android.Util;

namespace Chat.Droid.Firebase
{
    public class NotificationService : INotificationService
    {
        public void Suscribe()
        {

            Log.Debug("allo", "InstanceID token: " + FirebaseInstanceId.Instance.Token);
        }
    }
}