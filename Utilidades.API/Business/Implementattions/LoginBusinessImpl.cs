using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Utilidades.API.Data.Converters;
using Utilidades.API.Data.VO;
using Utilidades.API.Model;
using Utilidades.API.Repository.Generic;
using Utilidades.API.Security.Configuration;

namespace Utilidades.API.Business.Implementattions {
    public class LoginBusinessImpl : ILoginBusiness {
        private IUserRepository _repository;
        private SigningConfigurations _signingConfigurations;
        private TokenConfiguration _tokenConfiguration;
        public LoginBusinessImpl (IUserRepository repository, SigningConfigurations signingConfigurations, TokenConfiguration tokenConfiguration) {
            _repository = repository;
            _signingConfigurations = signingConfigurations;
            _tokenConfiguration = tokenConfiguration;
        }

        public object FindByLogin (LoginVO login) {
            bool credentialIsValid = false;
            if (login != null && !string.IsNullOrWhiteSpace (login.Username)) {
                var baseLogin = _repository.FindByLogin (login.Username);
                credentialIsValid = (baseLogin != null && login.Username == baseLogin.Username && login.Password == baseLogin.Password);
            }
            if (credentialIsValid) {
                ClaimsIdentity identity = new ClaimsIdentity (
                    new GenericIdentity (login.Username, "Username"),
                    new [] {
                        new Claim (JwtRegisteredClaimNames.Jti, Guid.NewGuid ().ToString ("N")),
                            new Claim (JwtRegisteredClaimNames.UniqueName, login.Username)
                    }
                );
                DateTime createDate = DateTime.Now;
                DateTime expirationDate = createDate + TimeSpan.FromSeconds (_tokenConfiguration.Seconds);

                var handler = new JwtSecurityTokenHandler ();
                string token = CreateToken (identity, createDate, expirationDate, handler);

                return SuccessObject (createDate, expirationDate, token);
            } else {
                return ExceptionObject ();
            }
        }

        private string CreateToken (ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler) {
            var securityToken = handler.CreateToken (new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor {
                Issuer = _tokenConfiguration.Issuer,
                    Audience = _tokenConfiguration.Audience,
                    SigningCredentials = _signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = createDate,
                    Expires = expirationDate
            });

            var token = handler.WriteToken (securityToken);

            return token;
        }

        private object ExceptionObject () {
            return new {
                autenticated = false,
                    message = "OK"
            };
        }

        private object SuccessObject (DateTime createDate, DateTime expirationDate, string token) {
            return new {
                autenticated = true,
                    created = createDate.ToString ("yyyy-MM-dd HH:mm:ss"),
                    expiration = expirationDate.ToString ("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
            };
        }
    }
}