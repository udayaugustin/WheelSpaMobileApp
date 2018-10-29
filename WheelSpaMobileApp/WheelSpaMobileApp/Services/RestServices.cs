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

        public async Task AddUser(User user)
        {
            var t1 = JsonConvert.SerializeObject(user);
            var content = new StringContent(JsonConvert.SerializeObject(user));
            var result = await httpClient.PostAsync(BaseUrl + "/user/add", content);
        }

    }
}
