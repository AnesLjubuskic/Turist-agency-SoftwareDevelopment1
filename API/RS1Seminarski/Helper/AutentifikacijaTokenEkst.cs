//using System.Linq;
//using System.Text.Json.Serialization;
//using AutoMapper.QueryableExtensions;
//using Microsoft.AspNetCore.Http;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using RS1Seminarski.Data;
//using RS1Seminarski.ModulAutentifikacija.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RS1Seminarski.Data;
using RS1Seminarski.ModulAutentifikacija.Models;
using System.Linq;
using System.Text.Json.Serialization;

namespace RS1Seminarski.Helper
{
/*    public static class AutentifikacijaTokenEkst
    {
        public class LoginInformacije
        {
            public LoginInformacije(AutentifikacijaToken autentifikacijaToken)
            {
                this.autentifikacijaToken = autentifikacijaToken;
            }

            [JsonIgnore]
            public KorisnickiNalog korisnickiNalog => autentifikacijaToken?.KorisnickiNalog;
            public AutentifikacijaToken autentifikacijaToken { get; set; }
            public bool isLogiran => korisnickiNalog != null;

            public bool isPermisijaVodic => isLogiran && (korisnickiNalog.isVodic || korisnickiNalog.isAdmin);
       
            public bool isPermsijaAdmin => isLogiran && korisnickiNalog.isAdmin;
        }


        public static LoginInformacije GetLoginInfo(this HttpContext httpContext)
        {
            var token = httpContext.GetAuthToken();

            return new LoginInformacije(token);
        }

        public static AutentifikacijaToken GetAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.GetMyAuthToken();
            ApplicationDbContext db = httpContext.RequestServices.GetService<ApplicationDbContext>();

            AutentifikacijaToken korisnickiNalog = db.AutentifikacijaToken
                .Include(s => s.korisnickiNalog)
                .SingleOrDefault(x => token != null && x.Vrijednost == token);

            return korisnickiNalog;
        }


        public static string GetMyAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.Request.Headers["autentifikacija-token"];
            return token;
        }

    }
*/
}
