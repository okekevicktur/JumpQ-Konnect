﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

 //[assembly: OwinStartup(typeof(JumpQ_TestApp.API.Startup))]
  
namespace JumpQ_TestApp.API
{
    
    class StartUp_Class
    {
        // public void Configuration(IAppBuilder app)  
        //{  
        //    var oauthProvider = new OAuthAuthorizationServerProvider  
        //    {  
        //        OnGrantResourceOwnerCredentials = async context =>  
        //        {  
        //            if (context.UserName == "xyz" && context.Password == "xyz@123")  
        //            {  
        //                var claimsIdentity = new ClaimsIdentity(context.Options.AuthenticationType);  
        //                claimsIdentity.AddClaim(new Claim("user", context.UserName));  
        //                context.Validated(claimsIdentity);  
        //                return;  
        //            }  
        //            context.Rejected();  
        //        },  
        //        OnValidateClientAuthentication = async context =>  
        //        {  
        //            string clientId;  
        //            string clientSecret;  
        //            if (context.TryGetBasicCredentials(out clientId, out clientSecret))  
        //            {  
        //                if (clientId == "xyz" && clientSecret == "secretKey")  
        //                {  
        //                    context.Validated();  
        //                }  
        //            }  
        //        }  
        //    };  
    //        var oauthOptions = new OAuthAuthorizationServerOptions  
    //        {  
    //            AllowInsecureHttp = true,  
    //            TokenEndpointPath = new PathString("/accesstoken"),  
    //            Provider = oauthProvider,  
    //            AuthorizationCodeExpireTimeSpan= TimeSpan.FromMinutes(1),  
    //            AccessTokenExpireTimeSpan=TimeSpan.FromMinutes(3),  
    //            SystemClock= new SystemClock()  

    //        };  
    //        app.UseOAuthAuthorizationServer(oauthOptions);  
    //        app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());  

    //        var config = new HttpConfiguration();  
    //        config.MapHttpAttributeRoutes();  
    //        app.UseWebApi(config);  
    //    }  
    //}  
    }
}
