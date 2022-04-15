using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxVonGrafKftMobile.Popups;
using MaxVonGrafKftMobileModel;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MaxVonGrafKftMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditAddAditionalDiver : ContentPage
    {
        private ReservationView reservationView;

       

        public EditAddAditionalDiver(ReservationView reservationView)
        {
            InitializeComponent();
            this.reservationView = reservationView;
        }

        private async void submitBtn_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FnameEntry.Text))
            {
                await PopupNavigation.Instance.PushAsync(new Error_popup("Please enter First name."));
            }
            else if (string.IsNullOrEmpty(LnameEntry.Text))
            {
                await PopupNavigation.Instance.PushAsync(new Error_popup("Please enter Last name."));
            }
            else if (string.IsNullOrEmpty(phoneEntry.Text) && phoneEntry.Text.Length < 10)
            {
                await PopupNavigation.Instance.PushAsync(new Error_popup("Please enter valid phone number."));
            }
            else if (!new EmailAddressAttribute().IsValid(emailEntry.Text) || string.IsNullOrEmpty(emailEntry.Text))
            {
                await PopupNavigation.Instance.PushAsync(new Error_popup("Please enter a valid email address."));
            }
            await Navigation.PushAsync(new SummaryOfChargesPage(reservationView));
        }
    }
}