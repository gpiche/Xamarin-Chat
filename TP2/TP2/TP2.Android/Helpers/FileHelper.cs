using System;
using System.IO;
using TP2.Android.Helpers;
using TP2.Core.Helper;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace TP2.Android.Helpers
{
    class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}