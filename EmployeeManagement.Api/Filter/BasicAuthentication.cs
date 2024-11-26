using System.Text; 
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using EmployeeManagement.Domain.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


namespace EmployeeManagement.Api.Filter;

public class BasicAuthentication :  Attribute, IAsyncAuthorizationFilter
{
        public string Realm { get; set; }
        public const string AuthTypeName = "Basic";
        private const string _authHeaderName = "Authorization";
        private BasicAuthenticationOptions authOptions;

        public BasicAuthentication(IOptions<BasicAuthenticationOptions> authOptions,string realm = null)
        {
            this.authOptions = authOptions.Value;
            Realm = realm;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            try
            {
                var request = context?.HttpContext?.Request;
                var authHeader = request.Headers.Keys.Contains(_authHeaderName) ? request.Headers[_authHeaderName].First() : null;
                string encodedAuth = (authHeader != null && authHeader.StartsWith(AuthTypeName)) ? authHeader.Substring(AuthTypeName.Length).Trim() : null;
                if (string.IsNullOrEmpty(encodedAuth))
                {
                    throw new UnauthorizedAccessException();
                }

                var (username, password) = DecodeUserIdAndPassword(encodedAuth);
                
                if (!(String.Equals(username,authOptions.UserName) && (String.Equals(password,authOptions.Password))))
                {
                    throw new UnauthorizedAccessException();
                }
                
                var claims = new[] { new Claim(ClaimTypes.Name, username, ClaimValueTypes.String, AuthTypeName) };
                var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, AuthTypeName));
                context.HttpContext.User = principal;
            }
            catch (Exception ex)
            {
                  context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                  context.HttpContext.Response.Headers.Add("WWW-Authenticate", $"{BasicAuthentication.AuthTypeName} Realm=\"{Realm}\"");
                 
                  context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            }
        }

        private static (string userid, string password) DecodeUserIdAndPassword(string encodedAuth)
        {
            var userpass = Encoding.UTF8.GetString(Convert.FromBase64String(encodedAuth));
            var separator = userpass.IndexOf(':');
            if (separator == -1)
                return (null, null);

            return (userpass.Substring(0, separator), userpass.Substring(separator + 1));
        }
}