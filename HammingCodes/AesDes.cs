using System.Security.Cryptography;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
namespace HamminCodes;

public class AesDes(string inputtext)
{
    private readonly string _inputtext=inputtext;
    public byte[] _key { get; set; }
    public byte[] _IV { get; set; }
    public byte[] desKey { get; set; }
    public byte[] desIV { get; set; }
    public byte[] AesEcnryptAlgorhtm()
    {
        using var aes = Aes.Create();
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;
        var res = Encoding.UTF8.GetBytes(_inputtext);//   stringToByteArray(aes.Key,aes.IV); samul -> nytes 
        _IV = aes.IV;
        _key = aes.Key;
        using var decryo = aes.CreateEncryptor(aes.Key, aes.IV);
        res = decryo.TransformFinalBlock(res, 0, res.Length);
        Console.WriteLine("Original text: \n  {0}", _inputtext);
        Console.WriteLine("LAst Round Trip aes:\n {0}",  Encoding.UTF8.GetString(res));
        Console.WriteLine("LAst Round Tripsize:\n {0}",  Encoding.UTF8.GetString(res).Length);
        return res;
    }
    
    public static byte[] AesEncrypt(string plainText, byte[] key, byte[] iv)
    {
        using var aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        using var encryptor = aes.CreateEncryptor();
        var plainBytes = Encoding.UTF8.GetBytes(plainText);
        return encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
    }
    public static string AesDecrypt(byte[] cipherText, byte[] key, byte[] iv)
    {
        using var aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        using var decryptor = aes.CreateDecryptor();
        var plainBytes = decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length);
        return Encoding.UTF8.GetString(plainBytes);
    }


    public string DencryptAlgorhtm(byte[] cipherText, byte[] key, byte[] iv)
    {
        using var aes = Aes.Create();
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;
        aes.Key = key;
        aes.IV = iv;

        using var decryptor = aes.CreateDecryptor();
        var plainBytes = decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length);
        Console.WriteLine("Original:    \n{0}", Encoding.UTF8.GetString(plainBytes));
        return Encoding.UTF8.GetString(plainBytes);
    }


   public byte[] DesEncrypt()
   {
       using var des = DES.Create();
       desKey=des.Key;
       desIV = des.IV;
       using var icrs = des.CreateEncryptor();
       var result = Encoding.UTF8.GetBytes(_inputtext);
       var f =  icrs.TransformFinalBlock(result, 0, result.Length);
       Console.WriteLine("Last Round Trip for des : \n {0}", Encoding.UTF8.GetString(f));
       Console.WriteLine("Last Round Trip for dessize :  \n {0}", Encoding.UTF8.GetString(f).Length);
       return f;
   }

   public string DesDecrypt(byte[] cipherText, byte[] key, byte[] iv)
   {
       using var des = DES.Create();
       des.Key = key;
       des.IV = iv;
       using var icrs = des.CreateDecryptor();
       var result = Encoding.UTF8.GetString(icrs.TransformFinalBlock(cipherText,0,cipherText.Length));
       Console.WriteLine("Original for des:   {0}",result);
       Console.WriteLine("Original for des:   {0}",result.Length);
       return result;
   }

  
}