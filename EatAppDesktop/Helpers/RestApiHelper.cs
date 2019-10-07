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

        public async Task<List<UserProfile>> ListAllUserAsync()
        {
            try
            {
                var resp = await client.GetAsync($"api/user/list-all");
                if (resp.IsSuccessStatusCode)
                {
                    var json = await resp.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<UserProfile>>(json);
                }

                return new List<UserProfile>();
            }
            catch
            {
                return new List<UserProfile>();
            }
        }

        public async Task<UserProfile> GetUserAsync(string username)
        {
            try
            {
                var resp = await client.GetAsync($"api/user/get-by-username?username={username}");
                if (resp.IsSuccessStatusCode)
                {
                    var json = await resp.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<UserProfile>(json);
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

        public async Task<string> AddUserAsync(string username, string password, string email, UserRole role)
        {
            try
            {
                UserInit user = new UserInit
                {
                    Username = username,
                    Password = password,
                    Email = email,
                    Role = role
                };

                var resp = await client.PostAsJsonAsync($"{BaseUrl}/api/user/add", user);
                return await resp.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }


        public async Task<UserAuthResponse> UpdateUserAsync(string username, string email, string fullname)
        {
            try
            {
                var user = new UserProfile
                {
                    Username = username,
                    Fullname = fullname,
                    Email = email
                };

                var resp = await client.PostAsJsonAsync($"{BaseUrl}/api/user/update", user);

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
            catch (Exception ex)
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

        public async Task<int> CountAllFnbCommentAsync(int fnbId)
        {
            try
            {
                var resp = await client.GetAsync($"{BaseUrl}/api/fnb-comment/count?fnbid={fnbId}");
                return resp.IsSuccessStatusCode ? int.Parse(await resp.Content.ReadAsStringAsync()) : 0;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<string> AddFnbCommentAsync(int fnbId, string comment, int rating, int commenterId)
        {
            try
            {
                FnbComment fnbComment = new FnbComment
                {
                    FnbId = fnbId,
                    Comment = comment,
                    Rating = rating,
                    CommenterId = commenterId,
                    BaseRating = BaseRating.Ten
                };

                var resp = await client.PostAsJsonAsync($"{BaseUrl}/api/fnb-comment/add", fnbComment);
                return await resp.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }


    }
}
