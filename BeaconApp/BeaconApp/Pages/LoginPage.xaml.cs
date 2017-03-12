﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeaconApp.Pages
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            //BindingContext = new LoginPageViewModel();
        }
        async void handleLogin(object sender, EventArgs e)
        {
            //DisplayAlert("Title", "Hello World", "OK");
            if (usernameInput.Text == "username" && passwordInput.Text == "password")
            {
                //output.Text = "login successful";
                // create a new NavigationPage, with a new AcquaintanceListPage set as the Root
                var navPage = new NavigationPage(
                    new MapPage()
                    {
                        Title = "Map",
                    });

                navPage.BarTextColor = Color.White;

                // set the MainPage of the app to the navPage
                Application.Current.MainPage = navPage;
            }
            else
            {
                output.Text = "login failed: incorrect username/password";
            }
        }
    }

    class LoginPageViewModel : INotifyPropertyChanged
    {
        public LoginPageViewModel()
        {
            IncreaseCountCommand = new Command(IncreaseCount);
        }

        int count;

        string countDisplay = "You clicked 0 times.";
        public string CountDisplay
        {
            get { return countDisplay; }
            set { countDisplay = value; OnPropertyChanged(); }
        }

        public ICommand IncreaseCountCommand { get; }

        void IncreaseCount() =>
            CountDisplay = $"You clicked {++count} times";


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
