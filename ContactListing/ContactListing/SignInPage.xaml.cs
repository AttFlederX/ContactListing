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
	public partial class SignInPage : ContentPage
	{
		public SignInPage()
		{
			InitializeComponent();

            // logoImage.Source = ImageSource.FromResource("ContactListing.Images.logo.png");
		}

        private void SetLoadingScreenState(bool isDisplayed)
        {
            loadingBoxView.IsVisible = isDisplayed;
            loadingAcitvityIndicator.IsVisible = isDisplayed;
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            SetLoadingScreenState(true);

            // asynchronously queries the database for a user with the specified email
            User user = await UserService.GetUserAsync(emailEntry.Text);
            SetLoadingScreenState(false);

            if (user == null)
            {
                await DisplayAlert("Error", "This user has not been found. Try re-entering your login credentials", "OK");
                passwordEntry.Text = string.Empty;
            }
            else
            {
                if (user.Password == passwordEntry.Text)
                {
                    await Navigation.PushAsync(new ContactsPage(user));
                }
                else
                {
                    await DisplayAlert("Error", "The password is incorrect. Try re-entering your login credentials", "OK");
                    passwordEntry.Text = string.Empty;
                }
            }
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
    }
}