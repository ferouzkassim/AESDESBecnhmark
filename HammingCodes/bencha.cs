using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using static HamminCodes.AesDes;
namespace HamminCodes;

[MemoryDiagnoser]
[RankColumn]
[RPlotExporter]
public class AesBenchmarks
{
    private byte[] _key;
    private byte[] _iv;
    private string _plainText = "the bachwezi are group of fertilizers ";
    private byte[] _cipher;
    private byte[] Des_cipher;
    private byte[] _DesKEy;
    private byte[] _DesIv;
    private AesDes _aesDes;
    [GlobalSetup]
    public void Setup()
    {
        using var aes = Aes.Create();
        _key = aes.Key;
        _iv = aes.IV;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;
        _cipher = AesEncrypt(_plainText, _key, _iv);
        
        using var des = DES.Create();
        _DesKEy = des.Key;
        _DesIv = des.IV;
        des.Mode = CipherMode.CBC;
        des.Padding = PaddingMode.PKCS7;
        _aesDes = new AesDes(_plainText);
        Des_cipher = _aesDes.DesEncrypt();
    }

    [Benchmark]
    public byte[] AesEncryptIon()
    {
        return AesEncrypt(_plainText, _key, _iv);
    }

    [Benchmark]
    public string AesDecryption()
    {
        return AesDes.AesDecrypt(_cipher, _key, _iv);
    }

    [Benchmark]
    public byte[] DesEncryption()
    {
        return _aesDes.DesEncrypt();
    }

    [Benchmark]
 
    public string DesDecryption()
    {
        return _aesDes.DesDecrypt(Des_cipher,_DesKEy,_DesIv);
    }
}
