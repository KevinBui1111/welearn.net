using System.Diagnostics;

namespace welearn.net.learn.csharp; 

public class FloatingPoint {
    public static void Main() {
        /*
         https://stackoverflow.com/questions/618535/difference-between-decimal-float-and-double-in-net
         float:  32-bit, C# alias for System.Single
         double: 64-bit, C# alias for System.Double
            are floating binary point types
            0.1f = 0.100000001
            1.1f = 1.10000002
            2.1f = 2.0999999
            0.8f = 0.800000012
            1.8f = 1.79999995
            0.9f = 0.899999976
            1.9f = 1.89999998
            
         decimal: 128-bit, C# alias for System.Decimal
            is a floating decimal point type
        
         Use float/double for measured values (distance)
            when exact value of numbers is not important, use double for speed.

         Use decimal for counted values (money, scores)
         */
        double d0102 = 0.1 + 0.2; //0.300..004
        double d03 = 0.3; //0.299..99
        Debug.Assert(d0102 != d03);

        float f10 = 10f;
        float infinity = f10 / 0;
        Debug.Assert(infinity == float.PositiveInfinity);
        
        decimal dec0102 = 0.1m + 0.2m; //0.300..004
        decimal dec03 = 0.3m; //0.299..99
        Debug.Assert(dec0102 == dec03);
    }
}