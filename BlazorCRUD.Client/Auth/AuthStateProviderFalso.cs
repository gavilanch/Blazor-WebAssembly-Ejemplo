using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorCRUD.Client.Auth
{
    public class AuthStateProviderFalso : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity(new List<Claim> { 
                new Claim(ClaimTypes.Name, "Felipe")
            }, "prueba");
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
        }
    }
}
