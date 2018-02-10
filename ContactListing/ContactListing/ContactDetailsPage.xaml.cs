using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ContactListing.Models;
using ContactListing.Services;

namespace ContactListing
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactDetailsPage : ContentPage
	{
		public ContactDetailsPage(Contact contact)
		{
            BindingContext = contact ?? throw new ArgumentNullException();
			InitializeComponent();
		}
	}
}