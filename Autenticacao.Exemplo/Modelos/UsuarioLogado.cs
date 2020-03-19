using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace Autenticacao.Exemplo
{
    public class UsuarioLogado
    {
        private readonly IHttpContextAccessor httpContext;

        public virtual string Nome => ObterClaim(ClaimTypes.Name);
        public virtual string Email => ObterClaim(ClaimTypes.Email);

        public UsuarioLogado(IHttpContextAccessor httpContext) => this.httpContext = httpContext;

        private string ObterClaim(string tipo) => httpContext.HttpContext.User.Claims.Single(x => x.Type == tipo).Value;
    }
}
