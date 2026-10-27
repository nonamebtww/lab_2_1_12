using System;
using System.Collections.Generic;
using GeneralConsole;
using Task1;
using Task2;

namespace Task2Console {
public static class Ui {
  public static void Task2Ui() {
    while (true) {
      Console.Clear();

      Console.Write(
        "Обработка документов абитуриента: " + Abiturient.Current.FullName + "\n" +
        "1. Проверить документы\n" +
        "2. Подсчитать баллы\n" +
        "3. Проверить направления из заявления\n" +
        "4. Подобрать подходящие направления\n" +
        "5. Сводный отчёт\n" +
        "6. Сохранить документы в файл\n" +
        "7. Загрузить документы из файла\n" +
        "0. Назад\n" +
        "Введите действие: "
      );

      string choice = Console.ReadLine();

      if (choice == "0") {
        return;
      }

      Console.WriteLine();

      try {
        switch (choice) {
          case "1":
            ShowErrors(Functions.CheckDocuments(Abiturient.Current));
            break;
          case "2":
            ShowScores(Abiturient.Current);
            break;
          case "3":
            ShowChecks(Functions.CheckApplication(Abiturient.Current), "В заявлении нет направлений.");
            break;
          case "4":
            ShowChecks(
              Functions.FindSuitableSpecialties(Abiturient.Current),
              "Подходящих направлений нет."
            );
            break;
          case "5":
            Console.WriteLine(Functions.BuildReport(Abiturient.Current));
            break;
          case "6":
            string savePath = Helpers.ReadString(
              "Путь к файлу (например, " +
              Functions.GetFileName(Abiturient.Current) + "): "
            );
            Functions.SaveToFile(Abiturient.Current, savePath);
            Console.WriteLine("Документы сохранены в файл " + savePath);
            break;
          case "7":
            string loadPath = Helpers.ReadString("Путь к файлу: ");
            Abiturient.Current = Functions.LoadFromFile(loadPath);
            Console.WriteLine("Загружен абитуриент: " + Abiturient.Current.FullName);
            break;
          default:
            Console.WriteLine("Введено неверное значение!");
            break;
        }
      }
      catch (Exception ex) {
        Console.WriteLine("Ошибка: " + ex.Message);
      }

      Helpers.Pause();
    }
  }

  private static void ShowErrors(List<string> errors) {
    if (errors.Count == 0) {
      Console.WriteLine("Документы в порядке, ошибок не найдено.");
      return;
    }

    Console.WriteLine("Найдено ошибок: " + errors.Count);

    foreach (string error in errors) {
      Console.WriteLine("  - " + error);
    }
  }

  private static void ShowScores(Abiturient abiturient) {
    Console.WriteLine(
      "Сумма баллов ЕГЭ: " + (abiturient.Exams == null ? 0 : abiturient.Exams.GetScore())
    );
    Console.WriteLine("Баллы за достижения: " + Functions.GetAchievementScore(abiturient));
    Console.WriteLine("Всего баллов: " + Functions.GetTotalScore(abiturient));
    Console.WriteLine("\nКонкурсные баллы по направлениям:");

    foreach (Specialty specialty in SpecialtyCatalog.All) {
      Console.WriteLine(
        "  {0} - {1}",
        specialty,
        Functions.GetScoreForSpecialty(abiturient, specialty)
      );
    }
  }

  private static void ShowChecks(List<SpecialtyCheck> checks, string emptyMessage) {
    if (checks.Count == 0) {
      Console.WriteLine(emptyMessage);
      return;
    }

    foreach (SpecialtyCheck check in checks) {
      Console.WriteLine(check);
    }
  }
}
}
