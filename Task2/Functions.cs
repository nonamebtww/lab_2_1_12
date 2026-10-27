using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Task1;

namespace Task2 {
// Результат проверки абитуриента по одному направлению.
public class SpecialtyCheck {
  public SpecialtyCheck(Specialty specialty) {
    Specialty = specialty;
    Reasons = new List<string>();
  }

  public Specialty Specialty { get; private set; }
  public int Score { get; set; }
  public List<string> Reasons { get; private set; }

  public bool Passed {
    get { return Reasons.Count == 0; }
  }

  public override string ToString() {
    string text = Specialty + " - " + Score + " б. (проходной " +
                  Specialty.PassingScore + "): " +
                  (Passed ? "проходит" : "не проходит");

    foreach (string reason in Reasons) {
      text += Environment.NewLine + "    - " + reason;
    }

    return text;
  }
}

// Методы обработки документов абитуриента.
// Документы обрабатываются через интерфейсные ссылки
// IDocument, IValidatable, IScorable и IStorable.
public static class Functions {
  // Проверка комплекта документов абитуриента.
  public static List<string> CheckDocuments(Abiturient abiturient) {
    List<string> errors = new List<string>();

    if (abiturient.Passport == null) {
      errors.Add("Нет паспорта");
    }

    if (abiturient.Education == null) {
      errors.Add("Нет документа об образовании");
    }

    if (abiturient.Exams == null) {
      errors.Add("Нет результатов ЕГЭ");
    }

    if (abiturient.Application == null) {
      errors.Add("Нет заявления о приёме");
    }

    // Каждый документ проверяет себя сам через интерфейс IValidatable.
    foreach (IDocument document in abiturient.GetDocuments()) {
      IValidatable validatable = document as IValidatable;

      if (validatable == null) {
        continue;
      }

      foreach (string error in validatable.Validate()) {
        errors.Add(document.Title + ": " + error);
      }
    }

    // Проверки, которые связывают разные документы.
    if (abiturient.Passport != null && abiturient.Education != null &&
        abiturient.Education.GraduationYear < abiturient.Passport.BirthDate.Year + 15) {
      errors.Add("Год окончания учебного заведения не согласуется с датой рождения");
    }

    return errors;
  }

  // Сумма баллов по всем документам, реализующим IScorable.
  public static int GetTotalScore(Abiturient abiturient) {
    int sum = 0;

    foreach (IDocument document in abiturient.GetDocuments()) {
      IScorable scorable = document as IScorable;

      if (scorable != null) {
        sum += scorable.GetScore();
      }
    }

    return sum;
  }

  // Баллы за индивидуальные достижения.
  public static int GetAchievementScore(Abiturient abiturient) {
    return abiturient.Education == null ? 0 : abiturient.Education.GetScore();
  }

  // Конкурсные баллы по направлению: экзамены направления + достижения.
  public static int GetScoreForSpecialty(Abiturient abiturient, Specialty specialty) {
    int sum = GetAchievementScore(abiturient);

    if (abiturient.Exams == null) {
      return sum;
    }

    foreach (string subject in specialty.Subjects) {
      ExamResult result = abiturient.Exams.FindResult(subject);

      if (result != null && result.IsValid) {
        sum += result.Score;
      }
    }

    return sum;
  }

  // Проверка, проходит ли абитуриент на направление.
  public static SpecialtyCheck CheckSpecialty(Abiturient abiturient, Specialty specialty) {
    SpecialtyCheck check = new SpecialtyCheck(specialty);
    check.Score = GetScoreForSpecialty(abiturient, specialty);

    foreach (string subject in specialty.Subjects) {
      ExamResult result = abiturient.Exams == null
        ? null
        : abiturient.Exams.FindResult(subject);
      int minScore = SpecialtyCatalog.GetMinScore(subject);

      if (result == null) {
        check.Reasons.Add("нет экзамена \"" + subject + "\"");
      }
      else if (!result.IsValid) {
        check.Reasons.Add("результат \"" + subject + "\" недействителен");
      }
      else if (result.Score < minScore) {
        check.Reasons.Add(
          "\"" + subject + "\": " + result.Score + " ниже минимума " + minScore
        );
      }
    }

    if (check.Score < specialty.PassingScore) {
      check.Reasons.Add("сумма баллов ниже проходной");
    }

    return check;
  }

  // Проверка направлений из заявления в порядке приоритета.
  public static List<SpecialtyCheck> CheckApplication(Abiturient abiturient) {
    List<SpecialtyCheck> checks = new List<SpecialtyCheck>();

    if (abiturient.Application == null) {
      return checks;
    }

    foreach (string code in abiturient.Application.SpecialtyCodes) {
      checks.Add(CheckSpecialty(abiturient, SpecialtyCatalog.Find(code)));
    }

    return checks;
  }

  // Направления справочника, на которые абитуриент проходит,
  // по убыванию запаса баллов над проходным.
  public static List<SpecialtyCheck> FindSuitableSpecialties(Abiturient abiturient) {
    List<SpecialtyCheck> suitable = new List<SpecialtyCheck>();

    foreach (Specialty specialty in SpecialtyCatalog.All) {
      SpecialtyCheck check = CheckSpecialty(abiturient, specialty);

      if (check.Passed) {
        suitable.Add(check);
      }
    }

    suitable.Sort((a, b) =>
      (b.Score - b.Specialty.PassingScore).CompareTo(a.Score - a.Specialty.PassingScore)
    );

    return suitable;
  }

  // Сводный отчёт по абитуриенту.
  public static string BuildReport(Abiturient abiturient) {
    StringBuilder builder = new StringBuilder();
    string nl = Environment.NewLine;

    builder.Append("Абитуриент: " + abiturient.FullName + nl);
    builder.Append("Документов: " + abiturient.GetDocuments().Count + " из 4" + nl + nl);

    List<string> errors = CheckDocuments(abiturient);
    builder.Append(errors.Count == 0
      ? "Документы в порядке." + nl
      : "Ошибки в документах:" + nl + "  " + string.Join(nl + "  ", errors) + nl);

    builder.Append(nl + "Сумма баллов ЕГЭ: " +
                   (abiturient.Exams == null ? 0 : abiturient.Exams.GetScore()) + nl);
    builder.Append("Баллы за достижения: " + GetAchievementScore(abiturient) + nl);
    builder.Append("Всего баллов: " + GetTotalScore(abiturient) + nl);

    builder.Append(nl + "Направления из заявления:" + nl);
    List<SpecialtyCheck> checks = CheckApplication(abiturient);

    if (checks.Count == 0) {
      builder.Append("  не выбраны" + nl);
    }

    foreach (SpecialtyCheck check in checks) {
      builder.Append("  " + check + nl);
    }

    return builder.ToString();
  }

  // Имя файла абитуриента: серия_номер паспорта.
  public static string GetFileName(Abiturient abiturient) {
    if (abiturient.Passport == null || abiturient.Key == "_") {
      throw new InvalidOperationException("Для сохранения нужен заполненный паспорт.");
    }

    return abiturient.Key + ".txt";
  }

  // Сохранение всех документов в текстовый файл.
  // Каждый документ сам формирует свои строки через IStorable.
  public static void SaveToFile(Abiturient abiturient, string path) {
    StreamWriter writer = new StreamWriter(path, false, Encoding.UTF8);

    try {
      foreach (IDocument document in abiturient.GetDocuments()) {
        IStorable storable = document as IStorable;

        if (storable == null) {
          continue;
        }

        writer.WriteLine("[" + storable.Section + "]");

        foreach (string line in storable.Save()) {
          writer.WriteLine(line);
        }

        writer.WriteLine();
      }
    }
    finally {
      writer.Close();
    }
  }

  // Загрузка абитуриента из текстового файла.
  public static Abiturient LoadFromFile(string path) {
    Abiturient abiturient = new Abiturient();
    IStorable current = null;
    string[] lines = File.ReadAllLines(path, Encoding.UTF8);

    for (int i = 0; i < lines.Length; i++) {
      string line = lines[i].Trim();

      if (line.Length == 0) {
        continue;
      }

      try {
        if (line.StartsWith("[") && line.EndsWith("]")) {
          current = CreateDocument(abiturient, line.Substring(1, line.Length - 2));
          continue;
        }

        int separator = line.IndexOf('=');

        if (current == null || separator <= 0) {
          throw new FormatException("строка вне раздела документа");
        }

        string value = line.Substring(separator + 1);

        // Пустые значения не загружаются, поле остаётся по умолчанию.
        if (value.Length > 0) {
          current.Load(line.Substring(0, separator), value);
        }
      }
      catch (Exception ex) {
        throw new FormatException(
          "Ошибка в строке " + (i + 1) + " файла " + Path.GetFileName(path) +
          ": " + ex.Message
        );
      }
    }

    return abiturient;
  }

  // Создание пустого документа по названию раздела.
  private static IStorable CreateDocument(Abiturient abiturient, string section) {
    switch (section) {
      case PassportDocument.SectionName:
        abiturient.Passport = new PassportDocument();
        return abiturient.Passport;
      case EducationDocument.SectionName:
        abiturient.Education = new EducationDocument();
        return abiturient.Education;
      case ExamResultsDocument.SectionName:
        abiturient.Exams = new ExamResultsDocument();
        return abiturient.Exams;
      case ApplicationDocument.SectionName:
        abiturient.Application = new ApplicationDocument();
        return abiturient.Application;
      default:
        throw new FormatException("неизвестный документ \"" + section + "\"");
    }
  }
}
}
