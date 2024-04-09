using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManagement.Services
{
    public class MiddlewareService
    {
        private readonly HttpClient _httpClient=new HttpClient();
        public async Task<bool> IsUserExist(string userName)
        {
            var apiUrl = "http://localhost:5211/api/users/checkExistence";

            try
            {
                var response = await _httpClient.GetAsync($"{apiUrl}?username={userName}");

                if (response.IsSuccessStatusCode)
                {
                    return bool.Parse(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                string err=e.Message;
               return false;
            }
        }
    }
}
