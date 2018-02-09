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
	public partial class RegistrationPage : ContentPage
	{
		public RegistrationPage()
		{
			InitializeComponent();
		}

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            if (!ValidationService.IsEmailValid(emailEntry.Text))
            {
                DisplayAlert("Error", "Your email address is invalid", "OK");
            }
            else if (passwordEntry.Text != repeatPasswordEntry.Text)
            {
                DisplayAlert("Error", "The passwords don't match", "OK");
            }
            else if (!ValidationService.IsPasswordValid(passwordEntry.Text))
            {
                DisplayAlert("Error", "Your password must be at least 8 characters long", "OK");
            }
            else
            {
                try
                {
                    var newUser = new User(emailEntry.Text, passwordEntry.Text);
                    UserService.AddUser(newUser);
                    await DisplayAlert("Success", "Your account has been registered", "Continue");

                    await Navigation.PopAsync(); // return to sign in page
                }
                catch (ArgumentException ex)
                {
                    DisplayAlert("Error", ex.Message, "OK");
                }
            }
        }
    }
}