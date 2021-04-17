using System;
using System.Globalization;

namespace LambdaCalculator {
  class Program {

    delegate double Operation(double x, double y);

    static Operation Add = (x, y) => x + y;
    static Operation Subtract = (x, y) => x - y;
    static Operation Multiply = (x, y) => x * y;
    static Operation Divide = (x, y) => x / y;

    static void Main(string[] args) {

      char operation = default;
      string number1 = default, number2 = default;
      double arg1, arg2;

      // ввод знака операции
      while (operation != '+' && operation != '-' && operation != '*' && operation != '/') {
        Console.Write("Введите знак операции (+-*/): ");
        char.TryParse(Console.ReadLine(), out operation);
      }
      // ввод первого числа
      while (!DoubleParse(number1, out arg1)) {
        Console.Write("Введите 1-е число: ");
        number1 = Console.ReadLine();
      }
      // ввод второго числа
      while (true) {
        if (DoubleParse(number2, out arg2)) {
          if (operation != '/') break;
          if (arg2 != 0) break;
        }
        string remark = operation == '/' ? " (не равное 0)" : "";
        Console.Write($"Введите 2-е число{remark}: ");
        number2 = Console.ReadLine();
      }

      Console.Write("Результат: ");
      ShowResult(arg1, arg2, operation);

      Console.ReadKey();
    }

    static void ShowResult(double arg1, double arg2, char operation) {
      double result = 0.0;
      try {
        switch (operation) {
          case '+': result = Add(arg1, arg2); break;
          case '-': result = Subtract(arg1, arg2); break;
          case '*': result = Multiply(arg1, arg2); break;
          case '/': result = Divide(arg1, arg2); break;
        }
        Console.WriteLine(result);
      } catch (Exception e) {
        Console.WriteLine(e.Message);
      }
    }

    /// <summary>
    /// Культуро-независимый TryParse для Double (нормально работает и с '.' и с ',').
    /// </summary>
    /// <param name="source">Исходная строка с числом.</param>
    /// <param name="result">Результат преобразования в double.</param>
    /// <returns>Успешность операции (true/false)</returns>
    static bool DoubleParse(string source, out double result) {
      result = default(double);
      if (source == null) return false;
      if (!double.TryParse(source, out double t_prm_1)) {
        char sepdec = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
        char sepdecInverse = (char)('.' + ',' - sepdec);
        IFormatProvider fp = new NumberFormatInfo { NumberDecimalSeparator = sepdecInverse.ToString() };
        if (double.TryParse(source, NumberStyles.Float, fp, out double t_prm_2)) {
          result = t_prm_2;
          return true;
        } else return false;
      } else {
        result = t_prm_1;
        return true;
      }
    }
  }
}
