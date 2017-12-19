
using TP2.Core.Repositories.Entities;
using TP2.Core.Services;
using Xamarin.Forms;
using TP2.Core.Helper;
namespace TP2.Core.Cells
{
    class CellSelector : DataTemplateSelector
    {

        private readonly DataTemplate _incomingDataTemplate;
        private readonly DataTemplate _outgoingDataTemplate;
   


        public CellSelector()
        {
            _incomingDataTemplate = new DataTemplate(typeof(IncomingCell));
            _outgoingDataTemplate = new DataTemplate(typeof(OutgoingCell));
           
        }


        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var messageVm = (Message)item;
            if (messageVm == null)
                return null;
            if (messageVm.Author == App.CurrentUser)
            {
                return _outgoingDataTemplate;
            }
            return _incomingDataTemplate;
            
        }
    }

 
}
