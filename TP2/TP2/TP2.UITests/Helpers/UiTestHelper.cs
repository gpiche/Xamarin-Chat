using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace TP2.UITests.Helpers
{
    public class UiTestHelper
    {
        public static bool IsTextDisplayed(IApp app, string id)
        {
            try
            {
                app.WaitForElement(id);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
