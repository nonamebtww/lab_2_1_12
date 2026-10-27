using System;
using System.Collections.Generic;
using System.Globalization;
using GeneralConsole;
using Task1;

namespace Task1Console {
public static class Ui {
  public static void Task1Ui() {
    while (true) {
      Console.Clear();

      Console.Write(
        "Документы абитуриента: " + Abiturient.Current.FullName + "\n" +
        "1. Паспорт\n" +
        "2. Документ об образовании\n" +
        "3. Результаты ЕГЭ\n" +
        "4. Заявление о приёме\n" +
        "5. Показать все документы\n" +
        "6. Заполнить примером\n" +
        "7. Новый абитуриент\n" +
        "0. Назад\n" +
        "Введите действие: "
      );

      switch (Console.ReadLine()) {
        case "1":
          InputPassport();
          break;
        case "2":
          InputEducation();
          break;
        case "3":
          InputExams();
          break;
        case "4":
          InputApplication();
          break;
        case "5":
          ShowDocuments(Abiturient.Current);
          break;
        case "6":
          Abiturient.Current = Abiturient.CreateSample();
          Console.WriteLine("Документы заполнены примером.");
          break;
        case "7":
          Abiturient.Current = new Abiturient();
          Console.WriteLine("Документы очищены.");
          break;
        case "0":
          return;
        default:
          Console.WriteLine("Введено неверное значение!");
          break;
      }

      Helpers.Pause();
    }
  }

  // Вывод всех документов через ссылки на интерфейс IDocument.
  public static void ShowDocuments(Abiturient abiturient) {
    List<IDocument> documents = abiturient.GetDocuments();

    if (documents.Count == 0) {
      Console.WriteLine("Документы не заполнены.");
      return;
    }

    foreach (IDocument document in documents) {
      Console.WriteLine();
      Console.WriteLine(document.GetInfo());

      IScorable scorable = document as IScorable;

      if (scorable != null) {
        Console.WriteLine("  Конкурсные баллы документа: " + scorable.GetScore());
      }
    }
  }

  private static void ShowWarnings(IValidatable document) {
    List<string> errors = document.Validate();

    if (errors.Count == 0) {
      Console.WriteLine("Документ сохранён, ошибок нет.");
      return;
    }

    Console.WriteLine("Документ сохранён, но содержит замечания:");

    foreach (string error in errors) {
      Console.WriteLine("  - " + error);
    }
  }

  private static void InputPassport() {
    PassportDocument passport = new PassportDocument();

    Console.WriteLine("\nВвод паспортных данных");
    Helpers.Input("Фамилия: ", v => passport.Surname = v);
    Helpers.Input("Имя: ", v => passport.Name = v);
    Helpers.Input("Отчество (можно пропустить): ", v => passport.Patronymic = v);
    passport.Gender = PassportDocument.Genders[
      Helpers.ReadChoice("Пол:", PassportDocument.Genders)
    ];
    Helpers.InputDate("Дата рождения", d => passport.BirthDate = d);
    Helpers.Input("Серия (4 цифры): ", v => passport.Series = v);
    Helpers.Input("Номер (6 цифр): ", v => passport.Number = v);
    Helpers.Input("Кем выдан: ", v => passport.IssuedBy = v);
    Helpers.InputDate("Дата выдачи", d => passport.IssueDate = d);

    Abiturient.Current.Passport = passport;
    ShowWarnings(passport);
  }

  private static void InputEducation() {
    EducationDocument education = new EducationDocument();

    Console.WriteLine("\nВвод документа об образовании");
    education.Level = EducationDocument.Levels[
      Helpers.ReadChoice("Уровень образования:", EducationDocument.Levels)
    ];
    Helpers.Input("Учебное заведение: ", v => education.Institution = v);
    Helpers.Input("Год окончания: ", v => education.GraduationYear = int.Parse(v));
    Helpers.Input(
      "Средний балл: ",
      v => education.AverageGrade = double.Parse(
        v.Replace(',', '.'),
        CultureInfo.InvariantCulture
      )
    );
    education.WithHonors = Helpers.ReadYesNo("Документ с отличием?");
    Helpers.Input("Номер документа: ", v => education.Number = v);
    Helpers.InputDate("Дата выдачи", d => education.IssueDate = d);

    Abiturient.Current.Education = education;
    ShowWarnings(education);
  }

  private static void InputExams() {
    ExamResultsDocument exams = Abiturient.Current.Exams;

    if (exams == null) {
      exams = new ExamResultsDocument();
      Console.WriteLine("\nВвод сведений о результатах ЕГЭ");
      Helpers.Input("Номер документа: ", v => exams.Number = v);
      Helpers.InputDate("Дата выдачи", d => exams.IssueDate = d);
      Abiturient.Current.Exams = exams;
    }

    while (true) {
      Console.WriteLine("\n" + exams.GetInfo());
      Console.Write(
        "\n1. Добавить экзамен\n" +
        "2. Удалить экзамен\n" +
        "0. Готово\n" +
        "Введите действие: "
      );

      string choice = Console.ReadLine();

      if (choice == "0") {
        ShowWarnings(exams);
        return;
      }

      try {
        if (choice == "1") {
          string subject = ExamResult.Subjects[
            Helpers.ReadChoice("Предмет:", ExamResult.Subjects)
          ];
          int score = Helpers.ReadInt("Балл (0-100): ");
          int year = Helpers.ReadInt("Год сдачи: ");
          exams.AddResult(new ExamResult(subject, score, year));
        }
        else if (choice == "2") {
          string subject = Helpers.ReadString("Предмет для удаления: ");
          Console.WriteLine(exams.RemoveResult(subject) ? "Удалено." : "Предмет не найден.");
        }
        else {
          Console.WriteLine("Введено неверное значение!");
        }
      }
      catch (ArgumentException ex) {
        Console.WriteLine("Ошибка: " + ex.Message);
      }
    }
  }

  private static void InputApplication() {
    ApplicationDocument application = new ApplicationDocument();

    Console.WriteLine("\nВвод заявления о приёме");
    Helpers.Input("Номер заявления: ", v => application.Number = v);
    Helpers.InputDate("Дата подачи", d => application.IssueDate = d);

    Console.WriteLine("\nНаправления подготовки:");

    for (int i = 0; i < SpecialtyCatalog.All.Count; i++) {
      Specialty specialty = SpecialtyCatalog.All[i];
      Console.WriteLine(
        "{0}. {1} (экзамены: {2}; мест: {3})",
        i + 1,
        specialty,
        string.Join(", ", specialty.Subjects),
        specialty.Places
      );
    }

    // Номера направлений вводятся через пробел в порядке приоритета.
    Helpers.Input(
      "Номера направлений по приоритету через пробел (не более " +
      ApplicationDocument.MaxSpecialties + "): ",
      text => {
        application.ClearSpecialties();
        string[] parts = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length == 0) {
          throw new ArgumentException("Нужно выбрать хотя бы одно направление.");
        }

        foreach (string part in parts) {
          int index;

          if (!int.TryParse(part, out index) ||
              index < 1 || index > SpecialtyCatalog.All.Count) {
            throw new ArgumentException("Неверный номер направления: " + part);
          }

          application.AddSpecialty(SpecialtyCatalog.All[index - 1].Code);
        }
      }
    );

    Abiturient.Current.Application = application;
    ShowWarnings(application);
  }
}
}
