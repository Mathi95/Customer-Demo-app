using MaxVonGrafKftMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Push;


namespace MaxVonGrafKftMobile
{
    public partial class App : Xamarin.Forms.Application
    {
        public App(string pagename, string data)
        {
            Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);

            InitializeComponent();

            if (pagename != null)
            {
                if(pagename== "ViewReservation")
                {
                    MainPage = new NavigationPage(new ViewReservation(Convert.ToInt32(data)));
                }
            }
            else
            {
                MainPage = new NavigationPage(new WelcomPage());
            }

        }

        protected override void OnStart()
        {
            // Handle when your app starts
            AppCenter.Start("6c941890-4bb2-4f03-8adb-36ba3eb26b5d", typeof(Push));

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
