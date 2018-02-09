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
	public partial class ContactsPage : ContentPage
	{
        private User currentUser;

		public ContactsPage(User user)
		{
            currentUser = user;

			InitializeComponent();
            UpdateContactList();

            currentUser.ContactList.CollectionChanged += UserContactList_CollectionChanged; // updates the page to accomodate the changes
		}

        private void UserContactList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateContactList();
        }

        private void UpdateContactList() // update the contact list and display the label if there are no contacts
        {
            contactListView.ItemsSource = currentUser.ContactList;
            noContactsLabel.IsVisible = (currentUser.ContactList.Count == 0);
        }

        private async void AddContactToolbarItem_Activated(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddContactPage(currentUser));
            UpdateContactList();
        }

        private void DeleteContactMenuItem_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            currentUser.ContactList.Remove(contact);
            UpdateContactList();
        }

        private void ContactListView_ItemSelected(object sender, EventArgs e)
        {
            #warning TODO
        }

        // disable the hardware return button so that the user cannot return to the login screen
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}