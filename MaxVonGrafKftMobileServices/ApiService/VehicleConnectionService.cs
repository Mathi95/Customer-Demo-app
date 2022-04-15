using MaxVonGrafKftMobileModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MaxVonGrafKftMobileServices.ApiService
{
    public class VehicleConnectionService
    {
        public bool StartVehicle(int vehicleID, int clientID, int VehicleCommType, string token)
        {

            bool startVehicleStatus = false;
            VehicleDetailRequest req = new VehicleDetailRequest();
            req.vehicleID = vehicleID;
            req.clientID = clientID;
            req.VehicleCommType = VehicleCommType;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConstantData.ApiURL.ToString() + "ClientAPI/StartVehicle");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var myContent = JsonConvert.SerializeObject(req);
                    var buffer = Encoding.UTF8.GetBytes(myContent);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var response = client.PostAsync(client.BaseAddress, byteContent).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var responseStream = response.Content.ReadAsStringAsync().Result;
                        startVehicleStatus = JsonConvert.DeserializeObject<bool>(responseStream);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return startVehicleStatus;
        }

        public bool StopVehicle(int vehicleID, int clientID, int VehicleCommType, string token)
        {
            bool startVehicleStatus = false;
            VehicleDetailRequest req = new VehicleDetailRequest();
            req.vehicleID = vehicleID;
            req.clientID = clientID;
            req.VehicleCommType = VehicleCommType;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConstantData.ApiURL.ToString() + "ClientAPI/StopVehicle");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var myContent = JsonConvert.SerializeObject(req);
                    var buffer = Encoding.UTF8.GetBytes(myContent);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var response = client.PostAsync(client.BaseAddress, byteContent).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var responseStream = response.Content.ReadAsStringAsync().Result;
                        startVehicleStatus = JsonConvert.DeserializeObject<bool>(responseStream);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return startVehicleStatus;
        }

        public bool LockVehicle(int vehicleID, int clientID, int VehicleCommType, string token)
        {

            bool startVehicleStatus = false;
            VehicleDetailRequest req = new VehicleDetailRequest();
            req.vehicleID = vehicleID;
            req.clientID = clientID;
            req.VehicleCommType = VehicleCommType;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConstantData.ApiURL.ToString() + "ClientAPI/LockVehicle");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var myContent = JsonConvert.SerializeObject(req);
                    var buffer = Encoding.UTF8.GetBytes(myContent);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var response = client.PostAsync(client.BaseAddress, byteContent).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var responseStream = response.Content.ReadAsStringAsync().Result;
                        startVehicleStatus = JsonConvert.DeserializeObject<bool>(responseStream);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return startVehicleStatus;
        }

        public bool UnLockVehicle(int vehicleID, int clientID, int VehicleCommType, string token)
        {
            bool startVehicleStatus = false;
            VehicleDetailRequest req = new VehicleDetailRequest();
            req.vehicleID = vehicleID;
            req.clientID = clientID;
            req.VehicleCommType = VehicleCommType;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConstantData.ApiURL.ToString() + "ClientAPI/UnlockVehicle");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var myContent = JsonConvert.SerializeObject(req);
                    var buffer = Encoding.UTF8.GetBytes(myContent);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var response = client.PostAsync(client.BaseAddress, byteContent).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var responseStream = response.Content.ReadAsStringAsync().Result;
                        startVehicleStatus = JsonConvert.DeserializeObject<bool>(responseStream);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return startVehicleStatus;
        }
    }
}
