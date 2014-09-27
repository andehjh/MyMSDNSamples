// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GoogleService.cs" company="saramgsilva">
//   Copyright (c) 2013 saramgsilva. All rights reserved. 
// </copyright>
// <summary>
//   The google service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AuthenticationSample.UniversalApps.Services.Interfaces;
using AuthenticationSample.UniversalApps.Services.Model;
using Newtonsoft.Json;
using Windows.Security.Authentication.Web;
using Windows.ApplicationModel.Activation;

// ReSharper disable once CheckNamespace
namespace AuthenticationSample.UniversalApps.Services
{
    /// <summary>
    /// The google service.
    /// </summary>
    public class GoogleService : IGoogleService
    {
        private readonly ILogManager _logManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleService"/> class.
        /// </summary>
        /// <param name="logManager">
        /// The log manager.
        /// </param>
        public GoogleService(ILogManager logManager)
        {
            _logManager = logManager;
        }

        /// <summary>
        /// The login async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/> object.
        /// </returns>
        public async Task<Session> LoginAsync()
        {
            var googleUrl = new StringBuilder();
            googleUrl.Append("https://accounts.google.com/o/oauth2/auth?client_id=");
            googleUrl.Append(Uri.EscapeDataString(Constants.GoogleClientId));
            googleUrl.Append("&scope=openid%20email%20profile");
            googleUrl.Append("&redirect_uri=");
            googleUrl.Append(Uri.EscapeDataString(Constants.GoogleCallbackUrl));
            googleUrl.Append("&state=foobar");
            googleUrl.Append("&response_type=code");

            var startUri = new Uri(googleUrl.ToString());


#if !WINDOWS_PHONE_APP
            var endUri = new Uri("https://accounts.google.com/o/oauth2/approval?");
            var webAuthenticationResult = await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.UseTitle, startUri, endUri);
            return await GetSession(webAuthenticationResult);
#else
            WebAuthenticationBroker.AuthenticateAndContinue(startUri, new Uri(Constants.GoogleCallbackUrl), null, WebAuthenticationOptions.None);
            return null;
#endif
        }

        private string GetCode(string webAuthResultResponseData)
        {
            // Success code=4/izytpEU6PjuO5KKPNWSB4LK3FU1c
            var split = webAuthResultResponseData.Split('&');

            return split.FirstOrDefault(value => value.Contains("code"));
        }

        /// <summary>
        /// The logout.
        /// </summary>
        public void Logout()
        {
        }

#if WINDOWS_PHONE_APP
        public async Task<Session> Finalize(WebAuthenticationBrokerContinuationEventArgs args)
        {
            Exception exception = null;
            try
            {
                return await GetSession(args.WebAuthenticationResult);
            }
            catch (Exception e)
            {
                exception = e;
            }

            await _logManager.LogAsync(exception);

            return null;
        }
#endif
        private async Task<Session> GetSession(WebAuthenticationResult result)
        {
            if (result.ResponseStatus == WebAuthenticationStatus.Success)
            {
                var code = GetCode(result.ResponseData);
                var serviceRequest = await GetToken(code);

                return new Session
                {
                    AccessToken = serviceRequest.access_token,
                    ExpireDate = new DateTime(long.Parse(serviceRequest.expires_in)),
                    Id = serviceRequest.id_token,
                    Provider = Constants.GoogleProvider
                };
            }
            if (result.ResponseStatus == WebAuthenticationStatus.ErrorHttp)
            {
                throw new Exception("Error http");
            }
            if (result.ResponseStatus == WebAuthenticationStatus.UserCancel)
            {
                throw new Exception("User Canceled.");
            }
            return null;
        }

        private static async Task<ServiceResponse> GetToken(string code)
        {

            const string TokenUrl = "https://accounts.google.com/o/oauth2/token";

            var body = new StringBuilder();
            body.Append(code);
            body.Append("&client_id=");
            body.Append(Uri.EscapeDataString(Constants.GoogleClientId));
            body.Append("&client_secret=");
            body.Append(Uri.EscapeDataString(Constants.GoogleClientSecret));
            body.Append("&redirect_uri=");
            body.Append(Uri.EscapeDataString(Constants.GoogleCallbackUrl));
            body.Append("&grant_type=authorization_code");

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, new Uri(TokenUrl))
            {
                Content = new StringContent(body.ToString(), Encoding.UTF8, "application/x-www-form-urlencoded")
            };
            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            var serviceTequest = JsonConvert.DeserializeObject<ServiceResponse>(content);
            return serviceTequest;
        }
    }
}
