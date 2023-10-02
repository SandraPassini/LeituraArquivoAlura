using System.Net.WebSockets;
using System.Text;

class Program
{
    //dentro do () são chamados de argurmentos
    static void Main(string[] args)
    {
        #region Endereço do arquivo
        //Para minimizar erro de onde localizar, o arquivo txt esta dentro da mesma pasta de executavel da aplicacao.
        #endregion
        var enderecoDoArquivo = "Contas.txt";

        #region FileStream
        //Stream significa fluxo. Então, Fluxo de Dados/Arquivo
        //No primeiro argumento recebe o endereço do arquivo e no segundo o que queremos fazer, no caso abrir
        #endregion
        var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open);

        //iniciando a variavel
        var numeroDeBytesLidos = -1;

        #region Explicando o Metodo FileStream Read
        //FileStream tem um metodo chamado Read. Abaixo segue a estrutura:
        // public override int Read(byte[] array, int offset, int count)
        //O método Read recebe três argumentos. O primeiro é o byte[] array, onde serão armazenados os bytes lidos pelo método — ou seja, retomando a ideia de fluxo, de trabalhar de parte em parte no código.Esse conceito ficará mais claro, à medida que entendermos como fornecemos esse array.

        //O segundo argumento é o int offset, que delimita o índice em que o método começará a preencher o array. Por exemplo: para preencher a partir da primeira posição(índice 0), informaremos o número 0 no offset. Caso indiquemos o número 10, começaremos a preencher o array a partir do índice 10 e as dez primeiras posições(índices 0 a 9) ficarão reservadas.

        //O terceiro argumento é o int count, que informa quantas posições preencher. Por exemplo, se indicarmos o offset como 0 e o count como 10, preencheremos do índice 0 a 9.Vale lembrar que iniciamos a contagem dos índices no 0, por isso, a posição 10 corresponde ao índice 9.

        //Em resumo: é preciso fornecer o array, o índice em que começaremos a preenchê - lo e quantas posições serão usadas.
        #endregion

        var buffer = new byte[1024]; //1KB

        #region Ler enquanto Byte nao for 0
        //Enquanto o número de bytes for diferente de 0, vamos exibi - los na tela.A partir do momento em que o retorno for 0,
        //não escreveremos mais o buffer
        #endregion
        while (numeroDeBytesLidos != 0)
        {
            numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
            Console.WriteLine($"Bytes Lidos: {numeroDeBytesLidos}");
            EscreverBuffer(buffer);
        }

        // Devoluções:
        // 0 número total de bytes lidos do buffer. Isso poderá ser menor que o número de
        // bytes solicitado se esse número de bytes não estiver disponível no momento, ou
        //zero, se o final do fluxo for atingido

        fluxoDoArquivo.Close();

        Console.ReadLine();

    }

    // Código anterior omitido

    static void EscreverBuffer(byte[] buffer)
    {
        //decodificando atraves do protocolo utf (duas formas de usar)
       // var utf8 = new UTF8Encoding();
        var utf8 = Encoding.UTF8;

        var texto = utf8.GetString(buffer);
        Console.Write(texto);

        /*
            foreach (var meuByte in buffer)
        {
            Console.Write(meuByte);
            Console.Write(" ");
        }
        */
    }
}