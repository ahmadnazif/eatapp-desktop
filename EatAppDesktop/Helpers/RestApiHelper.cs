using EatAppDesktop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EatAppDesktop.Helpers
{
    public class RestApiHelper
    {
        public const string JWT_BEARER_SCHEME = "Bearer";
        private HttpClient client = new HttpClient();
        public string BaseUrl { get; }

        public RestApiHelper(string baseUrl)
        {
            BaseUrl = baseUrl;
            this.client.BaseAddress = new Uri(BaseUrl);

            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> IsAccessibleAsync()
        {
            try
            {
                var response = await client.GetAsync($"api/test");
                return response.StatusCode == HttpStatusCode.OK ? true : false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<UserAuthResponse> LoginAsync(string username, string password)
        {
            try
            {
                var login = new UserLogin
                {
                    Username = username,
                    Password = password
                };

                var resp = await client.PostAsJsonAsync($"{BaseUrl}/api/user/login", login);

                var stream = await resp.Content.ReadAsStreamAsync();
                var json = await new StreamReader(stream).ReadToEndAsync();
                return JsonConvert.DeserializeObject<UserAuthResponse>(json);
            }
            catch (Exception ex)
            {
                return new UserAuthResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<UserAuthResponse> ChangePasswordAsync(string username, string oldPassword, string newPassword)
        {
            try
            {
                var cp = new UserChangePassword
                {
                    Username = username,
                    OldPassword = oldPassword,
                    NewPassword = newPassword
                };

                var resp = await client.PostAsJsonAsync($"{BaseUrl}/api/user/change-password", cp);

                var stream = await resp.Content.ReadAsStreamAsync();
                var json = await new StreamReader(stream).ReadToEndAsync();
                return JsonConvert.DeserializeObject<UserAuthResponse>(json);
            }
            catch (Exception ex)
            {
                return new UserAuthResponse
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

    }
}
