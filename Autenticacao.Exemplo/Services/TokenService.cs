using Autenticacao.Exemplo.Modelos;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Autenticacao.Exemplo.Services
{
    public class TokenService
    {
        private readonly Chave identidade;
        public TokenService(IOptions<Chave> identidade) => this.identidade = identidade.Value;

        public string Gerar(Usuario usuario)
        {
            var geradorToken = new JwtSecurityTokenHandler();
            var dadosDoToken = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Email, usuario.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(identidade.ObterBytes()), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = geradorToken.CreateToken(dadosDoToken);
            var tokenSerializado = geradorToken.WriteToken(token);

            return tokenSerializado;
        }
    }
}
