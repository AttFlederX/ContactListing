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
	public partial class AddContactPage : ContentPage
	{
        private User currentUser;

		public AddContactPage(User user)
		{
            currentUser = user;
			InitializeComponent();
		}

        private async void AddContactButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameEntry.Text))
            {
                DisplayAlert("Error", "Please fill in the name field", "OK");
            }
            else if (string.IsNullOrWhiteSpace(countryCodeEntry.Text))
            {
                DisplayAlert("Error", "Please fill in the country code field", "OK");
            }
            else if (string.IsNullOrWhiteSpace(numberEntry.Text) || numberEntry.Text.Length < 8)
            {
                DisplayAlert("Error", "Phone number must be at least 8 digits long", "OK");
            }
            else
            {
                var newContact = new Contact(nameEntry.Text, countryCodeEntry.Text, numberEntry.Text);
                currentUser.ContactList.Add(newContact);

                await Navigation.PopAsync();
            }
        }

    }
}