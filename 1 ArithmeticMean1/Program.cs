using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticMean1 {
  class Program {
    delegate int arithmeticMean(int arg1, int arg2, int arg3);

    static void Main(string[] args) {
      arithmeticMean AMCalc = delegate (int a, int b, int c) {
        return (a + b + c) / 3;
      };

      Console.WriteLine(AMCalc(11, 3, 7));
      Console.ReadKey();
    }
  }
}
