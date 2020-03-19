using Autenticacao.Exemplo.ApiMiodelos;
using Autenticacao.Exemplo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autenticacao.Exemplo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly AutenticacaoService autenticacaoService;

        public LoginController(AutenticacaoService autenticacaoService)
            => this.autenticacaoService = autenticacaoService;

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Index(LoginApiModelo login)
        {
            var usuario = autenticacaoService.Autenticar(login.Nome, login.Senha);

            if (usuario == null)
                return BadRequest("Dados inválidos");

            return Ok(new
            {
                usuario.Nome,
                usuario.Email,
                usuario.Token
            });
        }
    }
}