using Criptografia.Interfaces;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

// Classe para criptografia simétrica
public class CriptografiaSimetrica : ICriptografia, ICriptografiaArquivo
{
    private readonly byte[] _chaveSimetrica;

    public CriptografiaSimetrica()
    {
        _chaveSimetrica = GerarChave();
    }

    // Gera e retorna uma chave simétrica
    public static byte[] GerarChave()
    {
        using (Aes aes = Aes.Create())
        {
            aes.GenerateKey();
            return aes.Key;
        }
    }

    // Criptografa o texto usando a chave fornecida
    public byte[] CriptografarTexto(string texto)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = _chaveSimetrica;
            aes.GenerateIV();
            ICryptoTransform criptografador = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(aes.IV, 0, aes.IV.Length); // Escreve o IV no início do stream
                using (CryptoStream cs = new CryptoStream(ms, criptografador, CryptoStreamMode.Write))
                using (StreamWriter sw = new StreamWriter(cs))
                {
                    sw.Write(texto);
                }
                return ms.ToArray();
            }
        }
    }

    // Descriptografa o texto criptografado usando a chave fornecida
    public string DescriptografarTexto(byte[] textoCriptografado)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = _chaveSimetrica;
            byte[] iv = new byte[aes.IV.Length];
            Array.Copy(textoCriptografado, iv, iv.Length);
            aes.IV = iv;

            ICryptoTransform descriptografador = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream(textoCriptografado, iv.Length, textoCriptografado.Length - iv.Length))
            using (CryptoStream cs = new CryptoStream(ms, descriptografador, CryptoStreamMode.Read))
            using (StreamReader sr = new StreamReader(cs))
            {
                return sr.ReadToEnd();
            }
        }
    }

    // Criptografa o conteúdo de um arquivo
    public void CriptografarArquivo(string caminhoArquivo)
    {
        try
        {
            string texto = File.ReadAllText(caminhoArquivo);
            byte[] textoCriptografado = CriptografarTexto(texto);
            File.WriteAllBytes(caminhoArquivo + ".enc", textoCriptografado);
        }
        catch {
            Console.WriteLine("nao");
        }
    }

    // Descriptografa o conteúdo de um arquivo
    public void DescriptografarArquivo(string caminhoArquivo)
    {
        try
        {
            byte[] textoCriptografado = File.ReadAllBytes(caminhoArquivo);
            string textoDescriptografado = DescriptografarTexto(textoCriptografado);
            File.WriteAllText(caminhoArquivo.Replace(".enc", ""), textoDescriptografado);
        }
        catch
        {
            Console.WriteLine("bah");
                
        }
    }
}

// Classe para criptografia assimétrica
public class CriptografiaAssimetrica : ICriptografia, ICriptografiaArquivo
{
    private RSA _chavePrivada;
    private RSA _chavePublica;

    public CriptografiaAssimetrica()
    {
        GerarChaves();
    }

    // Gera e retorna um par de chaves (pública e privada)
    public void GerarChaves()
    {
        _chavePrivada = RSA.Create();
        _chavePublica = _chavePrivada;
    }

    // Retorna a chave pública
    public RSA ObterChavePublica()
    {
        return _chavePublica;
    }

    // Criptografa o texto usando a chave pública fornecida
    public byte[] CriptografarTexto(string texto)
    {
        return _chavePublica.Encrypt(Encoding.UTF8.GetBytes(texto), RSAEncryptionPadding.OaepSHA256);
    }

    // Descriptografa o texto criptografado usando a chave privada fornecida
    public string DescriptografarTexto(byte[] textoCriptografado)
    {
        return Encoding.UTF8.GetString(_chavePrivada.Decrypt(textoCriptografado, RSAEncryptionPadding.OaepSHA256));
    }

    // Criptografa o conteúdo de um arquivo
    public void CriptografarArquivo(string caminhoArquivo)
    {
        string texto = File.ReadAllText(caminhoArquivo);
        byte[] textoCriptografado = CriptografarTexto(texto);
        File.WriteAllBytes(caminhoArquivo + ".enc", textoCriptografado);
    }

    // Descriptografa o conteúdo de um arquivo
    public void DescriptografarArquivo(string caminhoArquivo)
    {
        byte[] textoCriptografado = File.ReadAllBytes(caminhoArquivo);
        string textoDescriptografado = DescriptografarTexto(textoCriptografado);
        File.WriteAllText(caminhoArquivo.Replace(".enc", ""), textoDescriptografado);
    }
}

// Classe gerenciadora das operações de criptografia e descriptografia
public class GerenciadorCriptografia
{
    private readonly ICriptografia _criptografia;
    private readonly ICriptografiaArquivo _criptografiaArquivo;

    // Construtor que define o tipo de criptografia (simétrica ou assimétrica)
    public GerenciadorCriptografia(ICriptografia criptografia, ICriptografiaArquivo criptografiaArquivo)
    {
        _criptografia = criptografia;
        _criptografiaArquivo = criptografiaArquivo;
    }

    // Criptografa o conteúdo de um arquivo
    public void CriptografarArquivo(string caminhoArquivo)
    {
        _criptografiaArquivo.CriptografarArquivo(caminhoArquivo);
    }

    // Descriptografa o conteúdo de um arquivo
    public void DescriptografarArquivo(string caminhoArquivo)
    {
        _criptografiaArquivo.DescriptografarArquivo(caminhoArquivo);
    }

    // Criptografa um texto
    public byte[] CriptografarTexto(string texto)
    {
        return _criptografia.CriptografarTexto(texto);
    }

    // Descriptografa um texto criptografado
    public string DescriptografarTexto(byte[] textoCriptografado)
    {
        return _criptografia.DescriptografarTexto(textoCriptografado);
    }
}

// Exemplo de uso
public class Programa
{
    public static void Main()
    {
        string caminhoArquivo = @"C:\Users\Sr.Orlandi\Documents\GitHub\Paradgmas-de-Programa-o\Exercicio OOP (E2)\Criptografia\Criptografia\arquivo.csv";

        ICriptografia criptografia;
        ICriptografiaArquivo criptografiaArquivo;

        Console.WriteLine("Selecione o tipo de criptografia:");
        Console.WriteLine("1. Simétrica");
        Console.WriteLine("2. Assimétrica");
        string escolhaTipo = Console.ReadLine();

        if (escolhaTipo == "1")
        {
            criptografia = new CriptografiaSimetrica();
            criptografiaArquivo = new CriptografiaSimetrica();
        }
        else if (escolhaTipo == "2")
        {
            criptografia = new CriptografiaAssimetrica();
            criptografiaArquivo = new CriptografiaAssimetrica();
        }
        else
        {
            Console.WriteLine("Opção inválida. Saindo...");
            return;
        }

        GerenciadorCriptografia gerenciador = new GerenciadorCriptografia(criptografia, criptografiaArquivo);

        while (true)
        {
            Console.WriteLine("\nSelecione a operação:");
            Console.WriteLine("1. Criptografar Texto");
            Console.WriteLine("2. Descriptografar Texto");
            Console.WriteLine("3. Criptografar Arquivo");
            Console.WriteLine("4. Descriptografar Arquivo");
            Console.WriteLine("5. Sair");
            string escolhaOperacao = Console.ReadLine();

            switch (escolhaOperacao)
            {
                case "1":
                    Console.WriteLine("Digite o texto a ser criptografado:");
                    string texto = Console.ReadLine();
                    byte[] textoCriptografado = gerenciador.CriptografarTexto(texto);
                    Console.WriteLine($"Texto Criptografado: {Convert.ToBase64String(textoCriptografado)}");
                    break;

                case "2":
                    Console.WriteLine("Digite o texto criptografado (em base64):");
                    string textoCriptografadoBase64 = Console.ReadLine();
                    byte[] textoCriptografadoBytes = Convert.FromBase64String(textoCriptografadoBase64);
                    string textoDescriptografado = gerenciador.DescriptografarTexto(textoCriptografadoBytes);
                    Console.WriteLine($"Texto Descriptografado: {textoDescriptografado}");
                    break;

                case "3":
                    gerenciador.CriptografarArquivo(caminhoArquivo);
                    Console.WriteLine("Arquivo criptografado com sucesso.");
                    break;

                case "4":
                    gerenciador.DescriptografarArquivo(caminhoArquivo + ".enc");
                    Console.WriteLine("Arquivo descriptografado com sucesso.");
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}