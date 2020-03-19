using Autenticacao.Exemplo.Modelos;

namespace Autenticacao.Exemplo.Services
{
    public class UsuarioServiceFake : IUsuariosService
    {
        public Usuario Obter(string login, string senha)
            => new Usuario { Nome = login, Senha = senha, Email = "email@email.com" };
    }
}
