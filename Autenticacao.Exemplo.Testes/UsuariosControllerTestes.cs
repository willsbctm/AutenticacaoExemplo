using Autenticacao.Exemplo.Modelos;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Autenticacao.Exemplo.Testes
{
    public class UsuariosControllerTestes : TesteBase
    {
        [Test]
        public async Task DeveObterUsuarioLogado()
        {
            var usuarioPadrao = new Usuario
            {
                Nome = "TesteCustomizado",
                Email = "teste@email.com"
            };
            Setup.AdicionarAutenticacao(usuarioPadrao);

            var resultado = await client.GetAsync("usuarios");
            resultado.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}