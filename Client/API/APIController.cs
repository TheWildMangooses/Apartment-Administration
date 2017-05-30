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

namespace Client.API
{
    public class APIController
    {
        private const string APIURL = "http://rest20170524020051.azurewebsites.net";
        public static UserModel CheckLogin(string username,string password)
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
                        new MessageDialog(Residents.Ap_No.ToString()).ShowAsync();
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

        

    }
}
