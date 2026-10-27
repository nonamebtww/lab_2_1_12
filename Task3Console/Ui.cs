using System;
using System.Collections.Generic;
using GeneralConsole;
using Task1;
using Task2;
using Task3;
using FunctionsTask2 = Task2.Functions;

namespace Task3Console {
public static class Ui {
  // Работа с приёмной комиссией идёт через интерфейсные ссылки.
  private static readonly AdmissionService Service = new AdmissionService();
  private static readonly IAbiturientRegistry Registry = Service;
  private static readonly IRatingService Rating = Service;

  public static void Task3Ui() {
    while (true) {
      Console.Clear();

      Console.Write(
        "Приёмная комиссия (папка " + Service.Folder + ")\n" +
        "Текущий абитуриент: " + Abiturient.Current.FullName + "\n" +
        "1. Список абитуриентов\n" +
        "2. Зарегистрировать текущего абитуриента\n" +
        "3. Сделать абитуриента текущим\n" +
        "4. Удалить абитуриента\n" +
        "5. Конкурсный список направления\n" +
        "6. Рекомендованные к зачислению\n" +
        "7. Добавить примеры абитуриентов\n" +
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
            ShowAbiturients();
            break;
          case "2":
            Registry.Register(Abiturient.Current);
            Console.WriteLine("Абитуриент " + Abiturient.Current.FullName + " зарегистрирован.");
            break;
          case "3":
            SelectCurrent();
            break;
          case "4":
            RemoveAbiturient();
            break;
          case "5":
            ShowEntries(Rating.GetRating(ReadSpecialty()));
            break;
          case "6":
            ShowEntries(Rating.GetAdmitted(ReadSpecialty()));
            break;
          case "7":
            Console.WriteLine("Добавлено абитуриентов: " + Service.AddSamples());
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

  private static List<Abiturient> ShowAbiturients() {
    List<Abiturient> all = Registry.GetAll();

    if (all.Count == 0) {
      Console.WriteLine("Зарегистрированных абитуриентов нет.");
    }

    for (int i = 0; i < all.Count; i++) {
      Console.WriteLine(
        "{0,3}. {1,-35} паспорт {2}  баллов {3,3}  направления: {4}",
        i + 1,
        all[i].FullName,
        all[i].Key,
        FunctionsTask2.GetTotalScore(all[i]),
        string.Join(", ", all[i].Application.SpecialtyCodes)
      );
    }

    foreach (string error in Service.LoadErrors) {
      Console.WriteLine("Пропущен файл: " + error);
    }

    return all;
  }

  private static Abiturient ReadAbiturient() {
    List<Abiturient> all = ShowAbiturients();

    if (all.Count == 0) {
      return null;
    }

    while (true) {
      int index = Helpers.ReadInt("\nНомер абитуриента: ");

      if (index >= 1 && index <= all.Count) {
        return all[index - 1];
      }

      Console.WriteLine("Введено неверное значение!");
    }
  }

  private static void SelectCurrent() {
    Abiturient abiturient = ReadAbiturient();

    if (abiturient != null) {
      Abiturient.Current = abiturient;
      Console.WriteLine("Текущий абитуриент: " + abiturient.FullName);
    }
  }

  private static void RemoveAbiturient() {
    Abiturient abiturient = ReadAbiturient();

    if (abiturient != null && Helpers.ReadYesNo("Удалить " + abiturient.FullName + "?")) {
      Console.WriteLine(Registry.Remove(abiturient.Key) ? "Удалено." : "Файл не найден.");
    }
  }

  private static Specialty ReadSpecialty() {
    List<string> names = new List<string>();

    foreach (Specialty specialty in SpecialtyCatalog.All) {
      names.Add(specialty + " (мест: " + specialty.Places +
                ", проходной: " + specialty.PassingScore + ")");
    }

    return SpecialtyCatalog.All[Helpers.ReadChoice("Направление:", names)];
  }

  private static void ShowEntries(List<RatingEntry> entries) {
    Console.WriteLine();

    if (entries.Count == 0) {
      Console.WriteLine("Список пуст.");
      return;
    }

    foreach (RatingEntry entry in entries) {
      Console.WriteLine(entry);
    }
  }
}
}
