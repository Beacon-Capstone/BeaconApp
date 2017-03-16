using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeaconApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        void register(object sender, EventArgs e)
        {
            if (passwordInput.Text == verifyPasswordInput.Text)
            {
                output.Text = "Registration successful.";
                System.Diagnostics.Debug.WriteLine("Email Address: {0}\nUsername: {1}\nPassword: {2}\n",
                    emailInput.Text, usernameInput.Text, passwordInput.Text);
            }
            else
            {
                output.Text = "Passwords do not match.";
                System.Diagnostics.Debug.WriteLine("Passwords do not match.");
            }
        }
        void goToLogin(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Clicked go to login link.");
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}
