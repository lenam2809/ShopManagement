using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace WebUI.States
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private const string LocalStorageKey = "auth";
        public CustomAuthenticationStateProvider(ILocalStorageService localStorageService)
        {
            LocalStorageService = localStorageService;
        }
        private readonly ClaimsPrincipal anonymous = new(new ClaimsIdentity());

        public ILocalStorageService LocalStorageService { get; }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string token = await LocalStorageService.GetItemAsStringAsync(LocalStorageKey)!;
            if (string.IsNullOrEmpty(token)) 
                return await Task.FromResult(new AuthenticationState(anonymous));
            
            var(name, email) = GetClaims(token);
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
                return await Task.FromResult(new AuthenticationState(anonymous));

            var claims = SetClaimPricipal(name, email);
            if (claims is null) 
                return await Task.FromResult(new AuthenticationState(anonymous));
            else
                return await Task.FromResult(new AuthenticationState(claims));
        }

        public static ClaimsPrincipal SetClaimPricipal(string name, string email)
        {
            if (name is null || email is null) return new ClaimsPrincipal();
            return new ClaimsPrincipal(new ClaimsIdentity(
                [
                    new(ClaimTypes.Name, name),
                    new(ClaimTypes.Email, email)
                ], "JwtAuth"));
        }

        private static (string, string) GetClaims(string jwtToken)
        {
            if(string.IsNullOrEmpty(jwtToken)) return (null!, null!);
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwtToken);
            var name = token.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.Name)!.Value;
            var email = token.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.Email)!.Value;
            return (name, email);
        }


        public async Task UpdateAuthenticationState(string jwtToken)
        { 
            var claims = new ClaimsPrincipal();
            if (!string.IsNullOrEmpty(jwtToken))
            {
                var (name, email) = GetClaims(jwtToken);
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
                    return;

                var setClaims = SetClaimPricipal(name, email);
                if (setClaims is null)
                    return;

                await LocalStorageService.SetItemAsStringAsync(LocalStorageKey, jwtToken);
            }
            else
            {
                await LocalStorageService.RemoveItemAsync(LocalStorageKey);
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claims)));
        }
    }
}
