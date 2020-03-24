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
        private readonly Chave chave;
        private readonly JwtSecurityTokenHandler geradorToken;

        public TokenService(IOptions<Chave> chave, JwtSecurityTokenHandler geradorToken)
        {
            this.chave = chave.Value;
            this.geradorToken = geradorToken;
        }

        public string Gerar(Usuario usuario)
        {
            var dadosDoToken = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Email, usuario.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chave.ObterBytes()), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = geradorToken.CreateToken(dadosDoToken);
            var tokenSerializado = geradorToken.WriteToken(token);

            return tokenSerializado;
        }
    }
}
