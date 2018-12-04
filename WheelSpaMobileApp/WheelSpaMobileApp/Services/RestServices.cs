using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace WheelSpaMobileApp
{
    public class RestServices
    {
        private const string BaseUrl = "http://thana.shanehospitalfurniture.com/";

        private HttpClient httpClient = new HttpClient();

        public async Task<ResultData> AuthenticateUserViaManual(User user)
        {
            var content = new StringContent(JsonConvert.SerializeObject(user));
            var response = await httpClient.PostAsync(BaseUrl + "user/login", content);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResultData>(response.Content.ReadAsStringAsync().Result.ToString());
            }

            return null;
        }

        public async Task<ResultData> AddUser(User user)
        {
            var content = new StringContent(JsonConvert.SerializeObject(user));
            var response = await httpClient.PostAsync(BaseUrl + "user/add", content);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResultData>(response.Content.ReadAsStringAsync().Result);                
            }

            return null;
        }

        public async Task<ResultData> AddVehicle(Vehicle vehicle)
        {
            var content = new StringContent(JsonConvert.SerializeObject(vehicle));
            var response = await httpClient.PostAsync(BaseUrl + "vehicle/add", content);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ResultData>(response.Content.ReadAsStringAsync().Result);
            }

            return null;
        }
    }
}
