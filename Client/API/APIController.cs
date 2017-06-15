using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Model;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.ServiceModel.Channels;
using Windows.UI.Popups;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Converters;
using System.Text.RegularExpressions;

namespace Client.API
{

    public class APIController
    {
       

        private const string APIURL = "http://rest20170524020051.azurewebsites.net";
        public static UserModel CheckLogin(string username,string password) //AGATA
        {
            
            HttpClientHandler httphandler = new HttpClientHandler();
            httphandler.UseDefaultCredentials = true;
            using (HttpClient client = new HttpClient(httphandler))
            {
                client.BaseAddress = new Uri(APIURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var answer = client.GetAsync("/api/Users/" + username + "/" + password + "").Result;
                    if (answer.IsSuccessStatusCode)
                    {
                        UserModel User = answer.Content.ReadAsAsync<UserModel>().Result;
                        return User;
                    }
                    
                    else
                         new MessageDialog("Wrong credentials.").ShowAsync();
                }
                catch(Exception ex)
                {
                     new MessageDialog(ex.Message).ShowAsync();
                    return null;
                }
                return null;
            }
        }
        public static ResidentModel GetOwner(int R_No)
        {


            HttpClientHandler httphandler = new HttpClientHandler();
            httphandler.UseDefaultCredentials = true;
            
            using (HttpClient client = new HttpClient(httphandler))
            {
                client.BaseAddress = new Uri(APIURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    
                    var answer = client.GetAsync("/api/Residents/" + R_No + "").Result;
                    
                    if (answer.IsSuccessStatusCode)
                    {
                        var Residents = answer.Content.ReadAsAsync<ResidentModel>().Result;
                        
                        return Residents;
                    }

                    else
                        return null;
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                    return null;
                }
                return null;
            }

        }

        public static async Task<bool> LogResident(ResidentModel Resident) //FELIX
        {

            HttpClientHandler httphandler = new HttpClientHandler();
            httphandler.UseDefaultCredentials = true;
            using (HttpClient client = new HttpClient(httphandler))
            {
                client.BaseAddress = new Uri(APIURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string postBody = JsonConvert.SerializeObject(Resident, Formatting.None);
                    var answer = client.PostAsync("api/ResidentsLog/", new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                    if (answer.IsSuccessStatusCode)
                        return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
            return false;
        }
        public static async Task<bool> LogApartment(ApartmentModel Apartment)
        {
            HttpClientHandler httphandler = new HttpClientHandler();
            httphandler.UseDefaultCredentials = true;
            using (HttpClient client = new HttpClient(httphandler))
            {
                client.BaseAddress = new Uri(APIURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string postBody = JsonConvert.SerializeObject(Apartment);
                    var answer = client.PostAsync("api/AptLog/", new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                    if (answer.IsSuccessStatusCode)
                        return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
            return false;
        }
        public static async Task<bool> LogFacilities(FacilitiesModel Facility)
        {
            HttpClientHandler httphandler2 = new HttpClientHandler();
            httphandler2.UseDefaultCredentials = true;
            using (HttpClient client = new HttpClient(httphandler2))
            {
                client.BaseAddress = new Uri(APIURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string postBody = JsonConvert.SerializeObject(Facility);
                    var answer = client.PostAsync("api/FacLog/", new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                    if (answer.IsSuccessStatusCode)
                        return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
            return false;
        }

        public static bool Log(object data)
        {
            Type datatype = data.GetType();
            if(datatype==typeof(ResidentModel)) //FELIX
            {
                ResidentModel Resident = (ResidentModel)data;
                return LogResident(Resident).Result;
            }
            else if (datatype == typeof(ApartmentModel))
            {
                ApartmentModel Apartment = (ApartmentModel)data;
                return LogApartment(Apartment).Result;
            }
            else if (datatype == typeof(FacilitiesModel))
            {
                FacilitiesModel Facility = (FacilitiesModel)data;
                return LogFacilities(Facility).Result;
            }
            return false;

        }

        public static async void SaveUser(ResidentModel User) //FELIX
        {
            if(User.IsActive==true)
                User.IsActive = false; //LATER USE IN BOARD APPROVAL
            HttpClientHandler httphandler = new HttpClientHandler();
            httphandler.UseDefaultCredentials = true;
            using (HttpClient client = new HttpClient(httphandler))
            {
                client.BaseAddress = new Uri(APIURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    //string postBody = JsonConvert.SerializeObject(User);
 //                   var answer = client.PostAsync("api/Residents_unapproved", new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                    if (Log(User))
                    {
                        new MessageDialog("Save succesful, the changes will be made after approval").ShowAsync();
                    }
                    else
                        new MessageDialog("Save failed.").ShowAsync();
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                }
            }
        }

        public static List<ResidentModel> GetPeople(int Parent_Resident)
        {

            HttpClientHandler httphandler = new HttpClientHandler();
            httphandler.UseDefaultCredentials = true;
            using (HttpClient client = new HttpClient(httphandler))
            {
                client.BaseAddress = new Uri(APIURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var answer = client.GetAsync("/api/Residents/Cohabitors/" + Parent_Resident + "").Result;
                    if (answer.IsSuccessStatusCode)
                    {
                        var Residents = answer.Content.ReadAsAsync<IEnumerable<ResidentModel>>().Result;

                        return Residents.ToList();
                    }

                    else
                        return null;
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                    return null;
                }
                return null;
            }

        }
        public static ApartmentModel GetApartment(int Ap_No)
        {
            HttpClientHandler httphandler = new HttpClientHandler();
            httphandler.UseDefaultCredentials = true;
            using (HttpClient client = new HttpClient(httphandler))
            {
                client.BaseAddress = new Uri(APIURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var answer = client.GetAsync("api/Apartments/" + Ap_No + "/").Result;
                    if (answer.IsSuccessStatusCode)
                    {
 //                       if(answer.Content.ReadAsAsync<ApartmentModel>().Result.Ap_Drawing==null) 
                        var Apartment = answer.Content.ReadAsAsync<ApartmentModel>().Result;

                        return Apartment;
                    }

                    else
                        return null;
                }
                catch (Exception ex)
                {
                    new MessageDialog(ex.Message).ShowAsync();
                    return null;
                }
                return null;
            }
        }


        public static async Task<bool> CreateUser(UserModel User)
        {
            HttpClientHandler httphandler2 = new HttpClientHandler();
            httphandler2.UseDefaultCredentials = true;
            using (HttpClient client = new HttpClient(httphandler2))
            {
                client.BaseAddress = new Uri(APIURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string postBody = JsonConvert.SerializeObject(User);
                    var answer = client.PostAsync("api/User", new StringContent(postBody, Encoding.UTF8, "application/json")).Result;
                    if (answer.IsSuccessStatusCode)
                        return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
            return false;
        }


    }
}
