#region Licence
//===================================================================================
// Pankwood
//===================================================================================
// Copyright (c) 2016, Pankwood.  All Rights Reserved.
//===================================================================================
#endregion

#region References
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
#endregion

namespace Company.Security.BasicAuth
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private const string BasicAuthResponseHeader = "WWW-Authenticate";
        private const string BasicAuthResponseHeaderValue = "Basic";

        public string UsersConfigKey { get; set; }
        public string RolesConfigKey { get; set; }

        protected CustomPrincipal CurrentUser
        {
            get { return Thread.CurrentPrincipal as CustomPrincipal; }
            set { Thread.CurrentPrincipal = value as CustomPrincipal; }
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            try
            {
                AuthenticationHeaderValue authValue = actionContext.Request.Headers.Authorization;

                request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

                if (authValue != null && !String.IsNullOrWhiteSpace(authValue.Parameter) && authValue.Scheme == BasicAuthResponseHeaderValue)
                {
                    Credentials parsedCredentials = ParseAuthorizationHeader(authValue.Parameter);

                    if (parsedCredentials != null)
                    {
                        CurrentUser = new CustomPrincipal(parsedCredentials.Username);

                        if (!CurrentUser.GetUser(parsedCredentials.Username, parsedCredentials.Password))
                        {
                            actionContext.Response = request.CreateResponse(HttpStatusCode.Unauthorized, "User or password incorrect.");
                            actionContext.Response.Headers.Add(BasicAuthResponseHeader, BasicAuthResponseHeaderValue);
                            return;
                        }

                        if (!CurrentUser.IsInRole(parsedCredentials.Username))
                        {
                            actionContext.Response = request.CreateResponse(HttpStatusCode.MethodNotAllowed, "You don't have authorization.");
                            actionContext.Response.Headers.Add(BasicAuthResponseHeader, BasicAuthResponseHeaderValue);
                            return;
                        }

                        //Ok
                        return;
                    }
                    else
                    {
                        actionContext.Response = request.CreateResponse(HttpStatusCode.Unauthorized, "Connect before call this method.");
                        actionContext.Response.Headers.Add(BasicAuthResponseHeader, BasicAuthResponseHeaderValue);
                        return;
                    }
                }
                else
                {
                    actionContext.Response = request.CreateResponse(HttpStatusCode.Unauthorized, "User not found");
                    actionContext.Response.Headers.Add(BasicAuthResponseHeader, BasicAuthResponseHeaderValue);
                    return;
                }
            }
            catch (Exception e)
            {
                actionContext.Response = request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
                actionContext.Response.Headers.Add(BasicAuthResponseHeader, BasicAuthResponseHeaderValue);
                return;
            }
        }

        private Credentials ParseAuthorizationHeader(string authHeader)
        {
            string[] credentials = Encoding.ASCII.GetString(Convert.FromBase64String(authHeader)).Split(new[] { ':' });

            if (credentials.Length != 2 || string.IsNullOrEmpty(credentials[0]) || string.IsNullOrEmpty(credentials[1]))
                return null;

            return new Credentials() { Username = credentials[0], Password = credentials[1], };
        }
    }
    public class Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}