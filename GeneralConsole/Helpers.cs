using System;
using System.Collections.Generic;
using System.Globalization;

namespace GeneralConsole {
public class Helpers {
  public static int ReadInt(string message) {
    while (true) {
      Console.Write(message);

      if (int.TryParse(
            Console.ReadLine(),
            out var result
          )) {
        return result;
      }

      Console.WriteLine(
        "Введено неверное значение!"
      );
    }
  }

  public static int ReadPositiveInt(string message) {
    while (true) {
      int result = ReadInt(message);

      if (result > 0) {
        return result;
      }

      Console.WriteLine(
        "Значение должно быть больше нуля!"
      );
    }
  }

  // Считывает непустую строку.
  public static string ReadString(string message) {
    while (true) {
      Console.Write(message);

      string result = Console.ReadLine();

      if (!string.IsNullOrWhiteSpace(result)) {
        return result.Trim();
      }

      Console.WriteLine(
        "Строка не должна быть пустой!"
      );
    }
  }

  // Считывает многострочный текст.
  // Ввод заканчивается пустой строкой.
  public static string ReadText(string message) {
    Console.WriteLine(message);
    Console.WriteLine("(для окончания ввода введите пустую строку)");

    List<string> lines = new List<string>();

    while (true) {
      string line = Console.ReadLine();

      if (string.IsNullOrEmpty(line)) {
        break;
      }

      lines.Add(line);
    }

    return string.Join(Environment.NewLine, lines);
  }

  // Ввод значения с проверкой через свойство объекта.
  // Если свойство выбрасывает исключение, ввод повторяется.
  public static void Input(string message, Action<string> setter) {
    while (true) {
      Console.Write(message);

      try {
        setter(Console.ReadLine() ?? string.Empty);
        return;
      }
      catch (Exception ex) {
        Console.WriteLine("Ошибка: " + ex.Message);
      }
    }
  }

  // Ввод даты в формате дд.мм.гггг с проверкой через свойство.
  public static void InputDate(string message, Action<DateTime> setter) {
    Input(message + " (дд.мм.гггг): ", text => {
      DateTime date;

      if (!DateTime.TryParseExact(
            text.Trim(),
            "dd.MM.yyyy",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out date
          )) {
        throw new FormatException("Дата должна быть в формате дд.мм.гггг.");
      }

      setter(date);
    });
  }

  // Выбор элемента из списка. Возвращает индекс выбранного элемента.
  public static int ReadChoice(string message, IList<string> items) {
    Console.WriteLine(message);

    for (int i = 0; i < items.Count; i++) {
      Console.WriteLine("{0}. {1}", i + 1, items[i]);
    }

    while (true) {
      int choice = ReadInt("Ваш выбор: ");

      if (choice >= 1 && choice <= items.Count) {
        return choice - 1;
      }

      Console.WriteLine("Введено неверное значение!");
    }
  }

  // Вопрос "да/нет".
  public static bool ReadYesNo(string message) {
    while (true) {
      Console.Write(message + " (д/н): ");
      string answer = (Console.ReadLine() ?? string.Empty).Trim().ToLower();

      if (answer == "д" || answer == "y") {
        return true;
      }

      if (answer == "н" || answer == "n") {
        return false;
      }

      Console.WriteLine("Введите \"д\" или \"н\".");
    }
  }

  public static void Pause() {
    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
    Console.ReadKey(true);
  }
}
}
