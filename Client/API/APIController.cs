using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Model;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;

namespace Client.API
{
    class APIController
    {
        private const string APIURL = "";
        static async Task<int> FindAccount(UserModel user)
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
                    var response = await client.GetAsync("/api/")
                }
            }
        }

    }
}
