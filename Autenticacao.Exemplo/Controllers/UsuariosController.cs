using Microsoft.AspNetCore.Mvc;

namespace Autenticacao.Exemplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioLogado usuarioLogado;

        public UsuariosController(UsuarioLogado usuarioLogado) => this.usuarioLogado = usuarioLogado;

        [HttpGet]
        public IActionResult Obter() => Ok(usuarioLogado);
    }
}