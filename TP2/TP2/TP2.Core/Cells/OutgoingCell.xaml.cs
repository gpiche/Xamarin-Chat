using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TP2.Core.Cells
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OutgoingCell : ViewCell
	{
		public OutgoingCell ()
		{
			InitializeComponent ();
		}
	}
}