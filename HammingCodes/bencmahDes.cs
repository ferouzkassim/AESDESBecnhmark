using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;

namespace HamminCodes;
[MemoryDiagnoser]
public class bencmahDes
{
    public byte[] _key;
    public byte[] _iv;
    public byte[] _cipher;
    private string _plainText = "the bachwezi are group of fertilizers ";
    [GlobalSetup]
    public void Setup()
    {
        using var aes = DES.Create();
        _key = aes.Key;
        _iv = aes.IV;
        //var des = 
       // _cipher = AesEncrypt(_plainText, _key, _iv);
    }
}