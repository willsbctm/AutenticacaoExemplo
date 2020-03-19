using Autenticacao.Exemplo.Modelos;
using System.Collections.Generic;
using System.Linq;

namespace Autenticacao.Exemplo.Services
{
    public class UsuarioService : IUsuariosService
    {
        private static readonly List<Usuario> usuarios = new List<Usuario>
        {
            new Usuario { Nome = "Bonafont", Senha = "1234", Email = "bonafont@email.com" },
            new Usuario { Nome = "Dvd", Senha = "5678", Email = "dvd@email.com" }
        };

        public Usuario? Obter(string login, string senha)
            => usuarios.SingleOrDefault(x => x.Nome == login && x.Senha == senha);
    }
}
