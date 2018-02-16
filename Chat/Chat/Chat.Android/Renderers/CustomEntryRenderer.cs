using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Support.V4.Content;
using Android.Text;
using Android.Views;
using Chat.Controls;
using Chat.Droid.Renderers;
using Java.Util;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyCustomEntry), typeof(CustomEntryRenderer))]
namespace Chat.Droid.Renderers
{
    class CustomEntryRenderer : EntryRenderer
    {
        MyCustomEntry _element;

        public CustomEntryRenderer(Context context) : base(context)
        {
            
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {

            _element = (MyCustomEntry)this.Element;

            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Background = Resources.GetDrawable(Resource.Drawable.rounded_corners);
                Control.SetPadding(50, 10, 10, 3);
                Control.Gravity = GravityFlags.CenterVertical;
            }

            if (e.OldElement != null || e.NewElement == null)
                return;



            var editText = this.Control;
            if (!string.IsNullOrEmpty(_element.Image))
            {
                switch (_element.ImageAlignment)
                {
                    case ImageAlignment.Left:
                        editText.SetCompoundDrawablesWithIntrinsicBounds(GetDrawable(_element.Image), null, null, null);
                        break;
                    case ImageAlignment.Right:
                        editText.SetCompoundDrawablesWithIntrinsicBounds(null, null, GetDrawable(_element.Image), null);
                        break;
                }
            }
            editText.CompoundDrawablePadding = 20;
           
        }

        private BitmapDrawable GetDrawable(string imageEntryImage)
        {
            int resID = Resources.GetIdentifier(imageEntryImage, "drawable", this.Context.PackageName);
            var drawable = ContextCompat.GetDrawable(this.Context, resID);
            var bitmap = ((BitmapDrawable)drawable).Bitmap;

            return new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, _element.ImageWidth * 2, _element.ImageHeight * 2, true));
        }

    }

}
