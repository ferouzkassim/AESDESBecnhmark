using System.Text;

namespace HamminCodes;

public class Hamming
{
    /// <summary>
    /// Calculate the number of parity bits needed to encode dataBits
    /// </summary>
    /// <param name="dataBits"></param>
    /// <returns></returns>
    private static int CalculateParityBits(int dataBits)
    {
        var r = 0;
        while ((1 << r) < (dataBits + r + 1))
        {
            r++;
        }
        return r;
    }

    private static List<double> ArrangeParitybits(byte[] data)
    {
        var parityBits = CalculateParityBits(data.Length);
        var limit = parityBits+data.Length; 
        if (parityBits <= 0) return [];
       var parityPositions  = new List<double>();
       var startingPoint = 0;
       while (Position(startingPoint) <= limit)
       {
          parityPositions.Add(Position(startingPoint));
          startingPoint++;
       }
       return parityPositions;
    }

    private static double Position(int currentIteration)
    {
       return Math.Pow(2, currentIteration);
    }
  
    public static string Encode(string data)
    { 
       var byteArray = Encoding.ASCII.GetBytes(data);
       var res =  ArrangeParitybits(byteArray);
       var newConstructedBytes = new byte[byteArray.Length + res.Count];
       // we need to enforce even parity bits
       
       var results = Convert.ToHexString(newConstructedBytes);
       return results;
    }

   
    private bool XorAction(int a, int b)
    {
        return a == b;
    }
}