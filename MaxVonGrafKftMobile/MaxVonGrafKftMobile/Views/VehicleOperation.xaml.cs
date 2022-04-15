using MaxVonGrafKftMobileServices.ApiService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MaxVonGrafKftMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VehicleOperation : ContentPage
    {
        string _token;
        private int vehicleKey = 83821;
        private int clientID = 443;
        private int VehicleCommType = 5;
        private string vehicleName;
        private string vehiType;
        private string licNo;

        //public VehicleOperation()
        //{
        //    InitializeComponent();

        //    _token = App.Current.Properties["currentToken"].ToString();
        //}

     

        public VehicleOperation(int vehicleId, string vehicleName, string vehiType, string licNo) 
        {
            InitializeComponent();

            _token = App.Current.Properties["currentToken"].ToString();
            this.vehicleKey = vehicleId;
            this.clientID = Constants.ClientId;
            this.vehicleName = vehicleName;
            this.vehiType = vehiType;
            this.licNo = licNo;
            vehiclenameEntry.Text = vehicleName;
            VehicleTypeEntry.Text = vehiType;
            licenceNoEntry.Text = licNo;
        }

        private async void StartVehicleBtn_Clicked(object sender, EventArgs e)
        {

            VehicleConnectionService svc = new VehicleConnectionService();

            bool result = svc.StartVehicle(vehicleKey, clientID, VehicleCommType, _token);

            if (result)
            {
                await DisplayAlert("START VEHICLE", "Success..", "Close");
            }
            else
            {
                await DisplayAlert("START VEHICLE", "Failure..", "Close");
            }

        }

        private async void StopVehicleBtn_Clicked(object sender, EventArgs e)
        {
            VehicleConnectionService svc = new VehicleConnectionService();

            bool result = svc.StopVehicle(vehicleKey, clientID, VehicleCommType, _token);

            if (result)
            {
                await DisplayAlert("STOP VEHICLE", "Success..", "Close");
            }
            else
            {
                await DisplayAlert("STOP VEHICLE", "Failure..", "Close");
            }
        }

        private async void LockVehicleBtn_Clicked(object sender, EventArgs e)
        {
            VehicleConnectionService svc = new VehicleConnectionService();

            bool result = svc.LockVehicle(vehicleKey, clientID, VehicleCommType, _token);

            if (result)
            {
                await DisplayAlert("LOCK VEHICLE", "Success..", "Close");
            }
            else
            {
                await DisplayAlert("LOCK VEHICLE", "Failure..", "Close");
            }
        }

        private async void UnLockVehicleBtn_Clicked(object sender, EventArgs e)
        {
            VehicleConnectionService svc = new VehicleConnectionService();

            bool result = svc.UnLockVehicle(vehicleKey, clientID, VehicleCommType, _token);

            if (result)
            {
                await DisplayAlert("UNLOCK VEHICLE", "Success..", "Close");
            }
            else
            {
                await DisplayAlert("UNLOCK VEHICLE", "Failure..", "Close");
            }
        }
    }
}