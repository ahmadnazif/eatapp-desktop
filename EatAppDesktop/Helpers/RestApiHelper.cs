using EatAppDesktop.Common;
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

                var json = await resp.Content.ReadAsStringAsync();
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

        public async Task<User> GetUserAsync(string username)
        {
            try
            {
                var resp = await client.GetAsync($"api/user/get-by-username?username={username}");
                if (resp.IsSuccessStatusCode)
                {
                    var json = await resp.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<User>(json);
                }

                return null;
            }
            catch
            {
                return null;
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

                var json = await resp.Content.ReadAsStringAsync();
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

        public async Task<List<Fnb>> ListAllFnbAsync()
        {
            try
            {
                var resp = await client.GetAsync($"{BaseUrl}/api/fnb/list-all");
                if (resp.IsSuccessStatusCode)
                {
                    var json = await resp.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Fnb>>(json);
                }
                else
                    return new List<Fnb>();
            }
            catch
            {
                return new List<Fnb>();
            }
        }

        public async Task<string> AddFnbAsync(string fnbName, FnbType fnbType)
        {
            try
            {
                Fnb fnb = new Fnb
                {
                    Name = fnbName,
                    FnbType = fnbType
                };

                var resp = await client.PostAsJsonAsync($"{BaseUrl}/api/fnb/add", fnb);
                return await resp.Content.ReadAsStringAsync();
            }
            catch(Exception ex)
            {

                return ex.Message;
            }
        }

        public async Task<List<FnbComment>> ListAllFnbCommentAsync(int fnbId)
        {
            try
            {
                var resp = await client.GetAsync($"{BaseUrl}/api/fnb-comment/list-all?fnbid={fnbId}");
                if (resp.IsSuccessStatusCode)
                {
                    var json = await resp.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<FnbComment>>(json);
                }
                else
                    return new List<FnbComment>();
            }
            catch
            {
                return new List<FnbComment>();
            }
        }

    }
}
