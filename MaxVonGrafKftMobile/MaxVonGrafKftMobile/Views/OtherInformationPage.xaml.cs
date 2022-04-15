using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxVonGrafKftMobile.Popups;
using MaxVonGrafKftMobileController;
using MaxVonGrafKftMobileModel;
using MaxVonGrafKftMobileModel.AccessModels;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MaxVonGrafKftMobile.Views
{
    public partial class OtherInformationPage : ContentPage
    {
        private CustomerReview customer;
        private string _token;
        GetAllStateForMobileResponse stateResponse = null;
        int customerID = 0;
        UploadCustomerImageMobileRequest imageMobileRequest;
        UploadCustomerImageMobileResponse imageMobileResponse;
        CustomerImages images;

        public OtherInformationPage(CustomerReview customer, CustomerImages images)
        {
            InitializeComponent();
            this.customer = customer;
            licenceIssueDate.MaximumDate = DateTime.Now;
            _token = App.Current.Properties["currentToken"].ToString();
            GetAllStateForMobileRequest stateRequest = new GetAllStateForMobileRequest();
            List<string> stateList = new List<string>();
            stateRequest.CountryID = (int)customer.CountryId;
            stateResponse = getStates(stateRequest, _token);
            if (stateResponse.stateList.Count > 0) { foreach (State s in stateResponse.stateList) { stateList.Add(s.StateCode); }; }
            licenceStatePicker.ItemsSource = stateList;
            imageMobileRequest = new UploadCustomerImageMobileRequest();
            imageMobileResponse = null;
            this.images = images;
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (PopupNavigation.Instance.PopupStack.Count > 0)
            {
                if (PopupNavigation.Instance.PopupStack[PopupNavigation.Instance.PopupStack.Count - 1].GetType() == typeof(ErrorWithClosePagePopup))
                {
                    await PopupNavigation.Instance.PopAllAsync();
                }
            }

        }

        private GetAllStateForMobileResponse getStates(GetAllStateForMobileRequest stateRequest, string token)
        {
            CommonController stateController = new CommonController();
            GetAllStateForMobileResponse sResponse;
            sResponse = stateController.GetAllStateByCountryID(stateRequest, token);
            return sResponse;
        }

        private async void DoneBtn_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(licenceNumber.Text))
            {
                await PopupNavigation.Instance.PushAsync(new Error_popup("Please enter your license number"));
            }
            else if (licenceExpiryDate.Date == null)
            {
                await PopupNavigation.Instance.PushAsync(new Error_popup("Please enter your license expiry date"));
            }
            else if (licenceExpiryDate.Date <= DateTime.Now)
            {
                await PopupNavigation.Instance.PushAsync(new Error_popup("Your license has expired"));
                licenceNumber.TextColor = (Color)Application.Current.Resources["DanderRed"];
            }
            else
            {
                

                bool busy = false;
                if (!busy)
                {
                    try
                    {
                        busy = true;
                        await PopupNavigation.Instance.PushAsync(new LoadingPopup("Saving your informations"));
                        await Task.Run(() =>
                        {
                            customer.LicenseNumber = licenceNumber.Text;
                            customer.LicenseExpiryDate = licenceExpiryDate.Date;
                            customer.LicenseIssueDate = licenceIssueDate.Date;
                            if (licenceStatePicker.SelectedIndex != -1)
                            {
                                customer.LicenseIssueState = returnStateIdByStateName(licenceStatePicker.SelectedItem.ToString());
                            }
                            if (images != null)
                            {
                                imageMobileRequest.custImag = images;
                            }
                            
                            RegisterController registerController = new RegisterController();
                            customerID = registerController.registerUser(customer, _token);
                            if (images != null && customerID>0)
                            {
                                imageMobileRequest.custImag.CustomerID = customerID;
                                imageMobileRequest.custImag.ImageID = customerID;
                                imageMobileRequest.custImag.Title = "My Image";
                                imageMobileRequest.custImag.FileName = "My Image";
                                imageMobileRequest.custImag.Description = "My ImageMy ImageMy Image";
                                imageMobileResponse = registerController.addCustomerImage(imageMobileRequest,_token);
                            }
                        });
                    }
                    finally
                    {
                        busy = false;
                        await PopupNavigation.Instance.PopAllAsync();
                    }
                }
                if(customerID > 0)
                {
                    await PopupNavigation.Instance.PushAsync(new SavedSuccessfullyPopup());
                }
                else
                {
                    await PopupNavigation.Instance.PushAsync(new Error_popup("Registration Failed.")) ;
                }

                

            }

        }

        private string returnStateIdByStateName(string v)
        {
            int staID = 0;
            foreach (State p in stateResponse.stateList) { if (p.StateCode == v) { staID = p.StateID; } }
            return staID.ToString();
        }

        private void LicenceNumber_Focused(object sender, FocusEventArgs e)
        {
            licenceNumber.TextColor = (Color)Application.Current.Resources["MaxVonGray"];
        }

    }
}