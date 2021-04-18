using System;

namespace ArithmeticMean2 {
  class Program {

    const int delegateArraySize = 10; // кол-во чисел в рассчете
    static readonly Random rnd = new Random();

    static Func<int>[] delegates = new Func<int>[delegateArraySize];
    delegate double ArithmeticMean(Func<int>[] delegates);

    static void Main(string[] args) {
      for (int i = 0; i < delegates.Length; i++) {
        delegates[i] = Random_0_to_99;
      }

      Console.WriteLine("Исходные числа:");
      ArithmeticMean result = delegate (Func<int>[] dlgs) {
        long sum = 0;
        foreach (Func<int> dlg in dlgs) {
          int nextNumber = dlg();
          sum += nextNumber;
          Console.Write(nextNumber);
          Console.Write(" ");
        }
        Console.WriteLine();
        Console.Write("Среднее арифметическое: ");
        return (double)sum / delegates.Length;
      };

      Console.WriteLine(result(delegates));
      Console.ReadKey();
    }

    static int Random_0_to_99() {
      return rnd.Next(100);
    }
  }
}
