using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Services
{
    public interface IAlertService
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}
