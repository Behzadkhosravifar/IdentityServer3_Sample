﻿using IdentityServer3.Core.Configuration;
using Owin;

namespace IdentityServer
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var options = new IdentityServerOptions
            {
                SiteName = "Test Identity Server",
                Factory = new IdentityServerServiceFactory()
                            .UseInMemoryClients(Clients.Get())
                            .UseInMemoryScopes(Scopes.Get())
                            .UseInMemoryUsers(Users.Get()),

                SigningCertificate = Certificate.Get(), // necessary for Flows.ClientCredentials

                RequireSsl = false
            };

            app.UseIdentityServer(options);
        }
    }
}