using Autenticacao.Exemplo.Modelos;

namespace Autenticacao.Exemplo.Services
{
    public class AutenticacaoService
    {
        private readonly TokenService tokenService;
        private readonly IUsuariosService usuariosService;

        public AutenticacaoService(TokenService tokenService, IUsuariosService usuariosService)
        {
            this.tokenService = tokenService;
            this.usuariosService = usuariosService;
        }

        public Usuario? Autenticar(string login, string senha)
        {
            var usuario = usuariosService.Obter(login, senha);
            if (usuario == null)
                return usuario;

            usuario.Token = tokenService.Gerar(usuario);
            return usuario;
        }
    }
}
