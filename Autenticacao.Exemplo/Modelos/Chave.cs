using System.Text;

namespace Autenticacao.Exemplo.Modelos
{
    public class Chave
    {
        public string Segredo { get; set; }

        public byte[] ObterBytes() => Encoding.ASCII.GetBytes(Segredo);
    }
}
