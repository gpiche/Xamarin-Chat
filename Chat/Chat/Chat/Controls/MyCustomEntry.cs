using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Chat.Controls
{
    public class MyCustomEntry : Entry
    {
        public MyCustomEntry()
        {
            this.HeightRequest = 50;
        }

        public static readonly BindableProperty ImageProperty =
            BindableProperty.Create(nameof(Image), typeof(string), typeof(MyCustomEntry), string.Empty);

        public static readonly BindableProperty LineColorProperty =
            BindableProperty.Create(nameof(LineColor), typeof(Xamarin.Forms.Color), typeof(MyCustomEntry), Color.White);

        public static readonly BindableProperty ImageHeightProperty =
            BindableProperty.Create(nameof(ImageHeight), typeof(int), typeof(MyCustomEntry), 40);

        public static readonly BindableProperty ImageWidthProperty =
            BindableProperty.Create(nameof(ImageWidth), typeof(int), typeof(MyCustomEntry), 40);

        public static readonly BindableProperty ImageAlignmentProperty =
            BindableProperty.Create(nameof(ImageAlignment), typeof(ImageAlignment), typeof(MyCustomEntry),
                ImageAlignment.Left);

        public Color LineColor
        {
            get => (Color) GetValue(LineColorProperty);
            set => SetValue(LineColorProperty, value);
        }

        public int ImageWidth
        {
            get => (int) GetValue(ImageWidthProperty);
            set => SetValue(ImageWidthProperty, value);
        }

        public int ImageHeight
        {
            get => (int) GetValue(ImageHeightProperty);
            set => SetValue(ImageHeightProperty, value);
        }

        public string Image
        {
            get => (string) GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }

        public ImageAlignment ImageAlignment
        {
            get => (ImageAlignment) GetValue(ImageAlignmentProperty);
            set => SetValue(ImageAlignmentProperty, value);
        }
    }

    public enum ImageAlignment
    {
        Left,
        Right
    }
}




