using AuthServer.SharedLibrary.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using SharedLibrary.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Extensions
{
    public static class CustomTokenAuth
    {
        //Extensions metodlar mutlaka static keyworduyle işaretlenmelidir 
        //Kimin için yazdıgımızı this keyworduyle belirtik this IServiceCollection services için yazdık.
        public static void AddCustomTokenAuth(this IServiceCollection services, CustomTokenOptions tokenOptions)
        {
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
                {
                    //var tokenOptions = Configuration.GetSection("TokenOption").Get<CustomTokenOptions>();
                    opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience[0],
                        IssuerSigningKey = SignService.GetSymmetricSecurityKey(tokenOptions.SecurityKey),

                        ValidateIssuerSigningKey = true,
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });
        }
    }
}
