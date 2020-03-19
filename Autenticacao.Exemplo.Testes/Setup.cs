using System;
using Autenticacao.Exemplo.Modelos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.IO;
using System.Net.Http;
using Autenticacao.Exemplo.Services;

namespace Autenticacao.Exemplo.Testes
{
    [SetUpFixture]
    public class Setup
    {
        private const string urlApi = "http://localhost/api/";
        private IServiceScope ServiceScope;
        public static IServiceProvider serviceProvider;
        private WebApplicationFactory<Startup> factory;
        public static HttpClient Client;

        [OneTimeSetUp]
        public void OneTimeSetupGlobal()
        {
            var configPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.Test.json");
            factory = new WebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
                             builder.UseEnvironment("Test")
                             .ConfigureTestServices(services =>
                             {

                             }).ConfigureAppConfiguration((context, configuration) =>
                             {
                                 configuration.AddJsonFile(configPath);
                             }));

            Client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri(urlApi)
            });

            ServiceScope = factory.Services.CreateScope();
            serviceProvider = ServiceScope.ServiceProvider;

            var usuarioPadrao = new Usuario
            {
                Nome = "Teste",
                Email = "teste@email.com"
            };
            AdicionarAutenticacao(usuarioPadrao);
        }

        public static void AdicionarAutenticacao(Usuario usuario)
        {
            var tokenService = serviceProvider.GetService<TokenService>();
            var token = tokenService.Gerar(usuario);
            RemoverAutenticacao();
            Client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }

        public static void RemoverAutenticacao()
            => Client.DefaultRequestHeaders.Remove("Authorization");

        [OneTimeTearDown]
        public void OneTearDownGlobal()
        {
            Client.Dispose();
            ServiceScope.Dispose();
            factory.Dispose();
        }
    }
}
