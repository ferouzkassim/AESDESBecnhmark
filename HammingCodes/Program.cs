// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using HamminCodes;
//var hamming = new Hamming();
var keyword = Console.ReadLine();
var aes = new AesDes(keyword);
//aes encruypion 
var resulbytes =aes.AesEcnryptAlgorhtm();

aes.DencryptAlgorhtm(resulbytes,aes._key,aes._IV);

// cnow we are decryptin

var desbytes =aes.DesEncrypt();

aes.DesDecrypt(desbytes,aes.desKey,aes.desIV);
// dotnet run -c Release
//BenchmarkRunner.Run<AesBenchmarks>();

//if (keyword != null) Console.WriteLine(Hamming.Encode(keyword));

//Console.WriteLine("Hello, World!");
