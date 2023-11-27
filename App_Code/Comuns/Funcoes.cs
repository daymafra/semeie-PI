using System.Text;
using System;
using System.Security.Cryptography;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Descrição resumida de Funcoes
/// </summary>
public class Funcoes
{
    /// <summary>
    /// metodo responsavel por criptografar o texto na base SHA512
    /// </summary>
    /// <param name="textoLimpo">Texto a ser criptografado</param>
    /// <returns>Retorna o texto na base 512</returns>
    public static string Hash(string textoLimpo)
    {
        HashAlgorithm hashAlgoritmo = HashAlgorithm.Create("SHA-512");
        if (hashAlgoritmo == null)
        {
            throw new ArgumentException("Hash não válida!");
        }
        else
        {
            //explita caracter por caracter, embaralha e retorna num vetor de byte
            byte[] hash = hashAlgoritmo.ComputeHash(Encoding.UTF8.GetBytes(textoLimpo));

            //converte a array criptografada para string
            return Convert.ToBase64String(hash);
        }
    }

    /// <summary>
    /// Método para gerar a codificação em Base64
    /// </summary>
    /// <param name="textoLimpo">Texto a ser codificado</param>
    /// <returns>Texto em base64 codificado</returns>
    public static string BaseCodifica(string textoLimpo)
    {
#pragma warning disable IDE0059 // Type or member is obsolete
        byte[] vetorBase = new byte[textoLimpo.Length];
        vetorBase = Encoding.UTF8.GetBytes(textoLimpo);
        return Convert.ToBase64String(vetorBase);
#pragma warning restore IDE0059 // Type or member is obsolete
    }

    /// <summary>
    /// Decodifica a bse64 (Volta o texto ao estado original)
    /// </summary>
    /// <param name="textoCodificado">Texto codificado em base64</param>
    /// <returns>Texto limpo => original </returns>
    public static string BaseDecodifica(string textoCodificado)
    {
        // crio a variável de decodificação textual UTF8
        var decode = new UTF8Encoding();
        // crio o decodificador
        var utf8Decode = decode.GetDecoder();

        // crio o vetor que receberá o texto codificado
        // pego cada partição do texto codificado e armazeno
        // no vetor
        byte[] stringValor = Convert.FromBase64String(textoCodificado);
        //crio um contador que recebe o tamanho de cada partição gerada do vetor de bytes
        int contador = utf8Decode.GetCharCount(stringValor, 0, stringValor.Length);
        // crio uma cadeia de char para mostrar o resultado final
        char[] decodeChar = new char[contador];

        // passando os valores do texto decodificado para o
        // vetor de char => texto limpo separado em cada
        // "casa" do vetor
        utf8Decode.GetChars(stringValor, 0, stringValor.Length, decodeChar, 0);

        //converto o vetor em um único texto
#pragma warning disable IDE0090 // Type or member is obsolete
        String resultado = new String(decodeChar);
        return resultado;
#pragma warning restore IDE0090 // Type or member is obsolete
    }

    public static int QuantidadeRegistros(DataSet ds)
    {
        return ds.Tables[0].Rows.Count;
    }

    public static void CarregarGridViewComDataSet(DataSet ds, GridView gv)
    {
        int qtd = Funcoes.QuantidadeRegistros(ds);

        if (qtd > 0)
        {
            gv.DataSource = ds.Tables[0].DefaultView;
            gv.DataBind();
            gv.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}