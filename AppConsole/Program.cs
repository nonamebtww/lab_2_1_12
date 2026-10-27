using System;
using GeneralConsole;

namespace AppConsole {
  internal class Program {
    private static void Main(string[] args) {
      while (true) {
        Console.Clear();

        Console.Write(
          "Задания:\n" +
          "1. Задание 1 - документы абитуриента\n" +
          "2. Задание 2 - обработка документов абитуриента\n" +
          "3. Задание 3 - приёмная комиссия\n" +
          "0. Выход\n" +
          "Введите действие: "
        );

        switch (Console.ReadLine()) {
            case "1":
              Task1Console.Ui.Task1Ui();
              break;
            case "2":
              Task2Console.Ui.Task2Ui();
              break;
            case "3":
              Task3Console.Ui.Task3Ui();
              break;
            case "0":
              return;
            default:
              Console.WriteLine("Введено неверное значение!");
              Helpers.Pause();
              break;
        }
      }
    }
  }
}
