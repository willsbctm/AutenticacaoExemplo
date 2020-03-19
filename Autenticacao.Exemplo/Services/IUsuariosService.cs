using Autenticacao.Exemplo.Modelos;

namespace Autenticacao.Exemplo.Services
{
    public interface IUsuariosService
    {
        Usuario Obter(string login, string senha);
    }
}
