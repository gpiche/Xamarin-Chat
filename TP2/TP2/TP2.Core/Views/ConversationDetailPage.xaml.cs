using System.Linq;
using TP2.Core.ViewModels;
using Xamarin.Forms;

namespace TP2.Core.Views
{
    public partial class ConversationDetailPage : ContentPage
    {
        public ConversationDetailPage()
        {
            InitializeComponent();

        }

      

        private void MyListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MessagesListView.SelectedItem = null;
        }

        private void MyListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            MessagesListView.SelectedItem = null;

        }
    }
}
