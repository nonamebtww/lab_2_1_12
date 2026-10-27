using System;
using System.Collections.Generic;

namespace Task1 {
// Направление подготовки.
public class Specialty {
  public Specialty(
    string code,
    string name,
    string[] subjects,
    int passingScore,
    int places
  ) {
    Code = code;
    Name = name;
    Subjects = subjects;
    PassingScore = passingScore;
    Places = places;
  }

  public string Code { get; private set; }
  public string Name { get; private set; }

  // Вступительные испытания (предметы ЕГЭ).
  public string[] Subjects { get; private set; }

  // Минимальная сумма конкурсных баллов.
  public int PassingScore { get; private set; }

  // Количество бюджетных мест.
  public int Places { get; private set; }

  public override string ToString() {
    return Code + " " + Name;
  }
}

// Справочник направлений подготовки и минимальных баллов ЕГЭ.
public static class SpecialtyCatalog {
  private static readonly string[] ItSubjects = {
    "Русский язык", "Математика", "Информатика"
  };

  public static readonly List<Specialty> All = new List<Specialty> {
    new Specialty("09.03.02", "Информационные системы и технологии", ItSubjects, 200, 3),
    new Specialty("09.03.03", "Прикладная информатика", ItSubjects, 190, 2),
    new Specialty("01.03.02", "Прикладная математика и информатика", ItSubjects, 220, 2),
    new Specialty(
      "10.03.01",
      "Информационная безопасность",
      new[] { "Русский язык", "Математика", "Физика" },
      205,
      2
    ),
    new Specialty(
      "38.03.01",
      "Экономика",
      new[] { "Русский язык", "Математика", "Обществознание" },
      210,
      2
    )
  };

  public static Specialty Find(string code) {
    foreach (Specialty specialty in All) {
      if (specialty.Code == code) {
        return specialty;
      }
    }

    return null;
  }

  // Минимальный балл ЕГЭ по предмету для участия в конкурсе.
  public static int GetMinScore(string subject) {
    switch (subject) {
      case "Русский язык":
        return 40;
      case "Математика":
        return 40;
      case "Информатика":
        return 46;
      case "Физика":
        return 41;
      case "Обществознание":
        return 45;
      default:
        return 40;
    }
  }
}

// Абитуриент и комплект его документов.
public class Abiturient {
  public PassportDocument Passport { get; set; }
  public EducationDocument Education { get; set; }
  public ExamResultsDocument Exams { get; set; }
  public ApplicationDocument Application { get; set; }

  // Текущий абитуриент, с которым работают задания 1 и 2.
  public static Abiturient Current { get; set; } = new Abiturient();

  public string FullName {
    get {
      return Passport == null || Passport.FullName.Length == 0
        ? "(паспорт не заполнен)"
        : Passport.FullName;
    }
  }

  // Ключ абитуриента - серия и номер паспорта.
  public string Key {
    get {
      return Passport == null ? string.Empty : Passport.Series + "_" + Passport.Number;
    }
  }

  // Все имеющиеся документы в виде ссылок на интерфейс IDocument.
  public List<IDocument> GetDocuments() {
    List<IDocument> documents = new List<IDocument>();
    IDocument[] all = { Passport, Education, Exams, Application };

    foreach (IDocument document in all) {
      if (document != null) {
        documents.Add(document);
      }
    }

    return documents;
  }

  // Создание абитуриента с заполненными документами для примера.
  public static Abiturient CreateSample() {
    int year = DateTime.Today.Year;

    PassportDocument passport = new PassportDocument {
      Surname = "Иванов",
      Name = "Иван",
      Patronymic = "Иванович",
      Gender = "Мужской",
      BirthDate = new DateTime(year - 18, 3, 15),
      Series = "4521",
      Number = "654321",
      IssuedBy = "ГУ МВД России по г. Москве",
      IssueDate = new DateTime(year - 4, 3, 20)
    };

    EducationDocument education = new EducationDocument {
      Level = EducationDocument.Levels[0],
      Institution = "МБОУ СОШ № 15",
      GraduationYear = year,
      AverageGrade = 4.8,
      WithHonors = true,
      Number = "07724000123456",
      IssueDate = new DateTime(year, 6, 25) > DateTime.Today
        ? DateTime.Today
        : new DateTime(year, 6, 25)
    };

    ExamResultsDocument exams = new ExamResultsDocument {
      Number = "ЕГЭ-" + year + "-0012345",
      IssueDate = education.IssueDate
    };
    exams.AddResult(new ExamResult("Русский язык", 82, year));
    exams.AddResult(new ExamResult("Математика", 76, year));
    exams.AddResult(new ExamResult("Информатика", 88, year));
    exams.AddResult(new ExamResult("Физика", 70, year));

    ApplicationDocument application = new ApplicationDocument {
      Number = "А-" + year + "-0101",
      IssueDate = education.IssueDate
    };
    application.AddSpecialty("09.03.02");
    application.AddSpecialty("09.03.03");
    application.AddSpecialty("10.03.01");

    return new Abiturient {
      Passport = passport,
      Education = education,
      Exams = exams,
      Application = application
    };
  }
}
}
