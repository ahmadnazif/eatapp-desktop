using EatAppDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EatAppDesktop.Extensions;
using EatAppDesktop.Common;

namespace EatAppDesktop.Helpers
{
    public class AccAuthHelper
    {
       private static Properties.Settings prop = Properties.Settings.Default;

        public static async Task<UserAuthResponse> LoginAsync(RestApiHelper api, string username, string password)
        {
            if (await api.IsAccessibleAsync())
            {
                var resp = await api.LoginAsync(username, password);
                if (resp.IsSuccess)
                {
                    var user = await api.GetUserAsync(username);
                    prop.currentUsername = username;
                    prop.currentUsernameLoginTimeStr = DateTime.Now.ToDbDateTimeString();
                    prop.currentUserRoleId = (int)user.Role;
                    prop.Save();
                }

                return resp;
            }

            return new UserAuthResponse
            {
                IsSuccess = false,
                Message = "Authentication process failed"
            };
        }

        public static bool IsAuthenticated => string.IsNullOrWhiteSpace(prop.currentUsername) ? false : true;

        public static string CurrentUsername => prop.currentUsername;

        public static UserRole CurrentUserRole => (UserRole)prop.currentUserRoleId;

        public static string LoggedInTime => prop.currentUsernameLoginTimeStr;


        public static void Logout()
        {
            prop.currentUsername = null;
            prop.currentUsernameLoginTimeStr = null;
            prop.currentUserRoleId = 99;
            prop.Save();
        }
    }
}
