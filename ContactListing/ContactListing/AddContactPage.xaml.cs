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
        // private User currentUser;
        public event EventHandler<Contact> ContactAdded;

		public AddContactPage()
		{
            // currentUser = user;
			InitializeComponent();
		}

        private async void AddContactButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(firstNameEntry.Text))
            {
                DisplayAlert("Error", "Please fill in the first name field", "OK");
            }
            else if (string.IsNullOrWhiteSpace(countryCodeEntry.Text))
            {
                DisplayAlert("Error", "Please fill in the country code field", "OK");
            }
            else if (string.IsNullOrWhiteSpace(numberEntry.Text) || numberEntry.Text.Length < 8)
            {
                DisplayAlert("Error", "Phone number must be at least 8 digits long", "OK");
            }
            else if (!ValidationService.IsEmailValid(emailEntryCell.Text))
            {
                DisplayAlert("Error", "Please enter a valid email address", "OK");
            }
            else
            {
                var newContact = new Contact(firstNameEntry.Text, lastNameEntry.Text, countryCodeEntry.Text, numberEntry.Text, emailEntryCell.Text, 
                    importantSwitchCell.On);
                // currentUser.ContactList.Add(newContact);
                ContactAdded(this, newContact);
            }
        }

    }
}