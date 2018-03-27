using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BoptimusPrime.Models;

namespace BoptimusPrime.Services
{
    public class BoptimusService 
    {

        private HttpClient httpClient;
        private string URL;
        private Token token;

        public async Task ConfigureAuthentication()
        {

            URL = ConfigurationManager.AppSettings.Get("BmtUrl");

            using (httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage respToken = await httpClient.PostAsync(
                    URL + "/api/Login", new StringContent(
                        JsonConvert.SerializeObject(new
                        {
                            UserID = ConfigurationManager.AppSettings.Get("BmtUser"),
                            AccessKey = ConfigurationManager.AppSettings.Get("BmtSubscriptionKey")
                        }), Encoding.UTF8, "application/json")).ConfigureAwait(false);

                string conteudo = await respToken.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (respToken.StatusCode == HttpStatusCode.OK)
                {
                    token = JsonConvert.DeserializeObject<Token>(conteudo);

                }
            }
        }

        public async Task<List<MediaSearch>> GetMedias(int GenreId)
        {
            httpClient = new HttpClient();
            if (token.Authenticated)
            {
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token.AccessToken);
            }
            var endpoint = $"/api/Media?genreId={GenreId}";
            HttpResponseMessage result;
            try
            {
                result = await httpClient.GetAsync($"{URL}{endpoint}");
                if (result.StatusCode != HttpStatusCode.OK)
                    throw new HttpRequestException();

                var resultString = await result.Content.ReadAsStringAsync();
                var medias = JsonConvert.DeserializeObject<List<MediaSearch>>(resultString);
                return medias;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}