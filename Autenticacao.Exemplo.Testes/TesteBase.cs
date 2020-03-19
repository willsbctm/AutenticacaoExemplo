using NUnit.Framework;
using System;
using System.Net.Http;

namespace Autenticacao.Exemplo.Testes
{
    public class TesteBase
    {
        protected IServiceProvider serviceProvider = Setup.serviceProvider;
        protected HttpClient client = Setup.Client;
    }
}
