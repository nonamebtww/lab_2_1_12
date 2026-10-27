using System;
using System.Collections.Generic;
using System.IO;
using Task1;
using Task2;
using FunctionsTask2 = Task2.Functions;

namespace Task3 {
// Строка конкурсного списка.
public class RatingEntry {
  public int Position { get; set; }
  public Abiturient Abiturient { get; set; }
  public int Score { get; set; }
  public int Priority { get; set; }
  public bool Passed { get; set; }
  public bool Admitted { get; set; }
  public string Status { get; set; }

  public override string ToString() {
    return string.Format(
      "{0,3}. {1,-35} {2,4} б.  приоритет {3}  {4}",
      Position,
      Abiturient.FullName,
      Score,
      Priority,
      Status
    );
  }
}

// Приёмная комиссия. Один класс реализует два интерфейса:
// IAbiturientRegistry (хранение абитуриентов в файлах папки)
// и IRatingService (конкурсные списки и зачисление).
public class AdmissionService : IAbiturientRegistry, IRatingService {
  public const string DefaultFolder = "abiturients";

  public AdmissionService() : this(DefaultFolder) {
  }

  public AdmissionService(string folder) {
    Folder = folder;
    Directory.CreateDirectory(folder);
    LoadErrors = new List<string>();
  }

  public string Folder { get; private set; }

  // Ошибки чтения файлов при последнем вызове GetAll().
  public List<string> LoadErrors { get; private set; }

  // Регистрация (или обновление) абитуриента.
  // Документы предварительно проверяются методами задания 2.
  public void Register(Abiturient abiturient) {
    List<string> errors = FunctionsTask2.CheckDocuments(abiturient);

    if (errors.Count > 0) {
      throw new InvalidOperationException(
        "Абитуриент не зарегистрирован, документы содержат ошибки:" +
        Environment.NewLine + string.Join(Environment.NewLine, errors)
      );
    }

    FunctionsTask2.SaveToFile(
      abiturient,
      Path.Combine(Folder, FunctionsTask2.GetFileName(abiturient))
    );
  }

  public bool Remove(string key) {
    string path = Path.Combine(Folder, key + ".txt");

    if (!File.Exists(path)) {
      return false;
    }

    File.Delete(path);
    return true;
  }

  public Abiturient Find(string key) {
    string path = Path.Combine(Folder, key + ".txt");
    return File.Exists(path) ? FunctionsTask2.LoadFromFile(path) : null;
  }

  public List<Abiturient> GetAll() {
    List<Abiturient> result = new List<Abiturient>();
    LoadErrors.Clear();

    foreach (string path in Directory.GetFiles(Folder, "*.txt")) {
      try {
        result.Add(FunctionsTask2.LoadFromFile(path));
      }
      catch (Exception ex) {
        LoadErrors.Add(ex.Message);
      }
    }

    result.Sort((a, b) => string.Compare(a.FullName, b.FullName, StringComparison.CurrentCulture));
    return result;
  }

  public List<RatingEntry> GetRating(Specialty specialty) {
    List<Abiturient> all = GetAll();
    Dictionary<string, string> admission = Distribute(all);
    List<RatingEntry> rating = new List<RatingEntry>();

    foreach (Abiturient abiturient in all) {
      int priority = abiturient.Application.GetPriority(specialty.Code);

      if (priority == 0) {
        continue;
      }

      SpecialtyCheck check = FunctionsTask2.CheckSpecialty(abiturient, specialty);
      RatingEntry entry = new RatingEntry {
        Abiturient = abiturient,
        Score = check.Score,
        Priority = priority,
        Passed = check.Passed
      };

      string admittedCode;
      admission.TryGetValue(abiturient.Key, out admittedCode);

      if (!check.Passed) {
        entry.Status = "не проходит: " + string.Join("; ", check.Reasons);
      }
      else if (admittedCode == specialty.Code) {
        entry.Admitted = true;
        entry.Status = "рекомендован к зачислению";
      }
      else if (admittedCode != null &&
               abiturient.Application.GetPriority(admittedCode) < priority) {
        entry.Status = "рекомендован на " + admittedCode + " (приоритет выше)";
      }
      else {
        entry.Status = "не хватило мест";
      }

      rating.Add(entry);
    }

    // Сначала прошедшие по условиям, затем по убыванию баллов.
    rating.Sort((a, b) => {
      if (a.Passed != b.Passed) {
        return a.Passed ? -1 : 1;
      }

      return b.Score.CompareTo(a.Score);
    });

    for (int i = 0; i < rating.Count; i++) {
      rating[i].Position = i + 1;
    }

    return rating;
  }

  public List<RatingEntry> GetAdmitted(Specialty specialty) {
    List<RatingEntry> admitted = new List<RatingEntry>();

    foreach (RatingEntry entry in GetRating(specialty)) {
      if (entry.Admitted) {
        entry.Position = admitted.Count + 1;
        admitted.Add(entry);
      }
    }

    return admitted;
  }

  // Распределение абитуриентов по направлениям с учётом приоритетов
  // и количества мест. Абитуриент претендует на направления по порядку
  // приоритета; если мест не хватает, вытесняется абитуриент с меньшими
  // баллами и пробует своё следующее направление.
  // Результат: ключ абитуриента -> код направления.
  private static Dictionary<string, string> Distribute(List<Abiturient> all) {
    Dictionary<string, List<Abiturient>> lists = new Dictionary<string, List<Abiturient>>();
    Dictionary<Abiturient, int> nextChoice = new Dictionary<Abiturient, int>();
    Queue<Abiturient> queue = new Queue<Abiturient>();

    foreach (Specialty specialty in SpecialtyCatalog.All) {
      lists[specialty.Code] = new List<Abiturient>();
    }

    foreach (Abiturient abiturient in all) {
      nextChoice[abiturient] = 0;
      queue.Enqueue(abiturient);
    }

    while (queue.Count > 0) {
      Abiturient abiturient = queue.Dequeue();
      IList<string> codes = abiturient.Application.SpecialtyCodes;

      while (nextChoice[abiturient] < codes.Count) {
        Specialty specialty = SpecialtyCatalog.Find(codes[nextChoice[abiturient]]);
        nextChoice[abiturient]++;

        if (!FunctionsTask2.CheckSpecialty(abiturient, specialty).Passed) {
          continue;
        }

        List<Abiturient> list = lists[specialty.Code];
        list.Add(abiturient);
        list.Sort((a, b) =>
          FunctionsTask2.GetScoreForSpecialty(b, specialty)
            .CompareTo(FunctionsTask2.GetScoreForSpecialty(a, specialty))
        );

        if (list.Count <= specialty.Places) {
          break;
        }

        Abiturient displaced = list[list.Count - 1];
        list.RemoveAt(list.Count - 1);

        if (displaced != abiturient) {
          queue.Enqueue(displaced);
          break;
        }
      }
    }

    Dictionary<string, string> result = new Dictionary<string, string>();

    foreach (KeyValuePair<string, List<Abiturient>> pair in lists) {
      foreach (Abiturient abiturient in pair.Value) {
        result[abiturient.Key] = pair.Key;
      }
    }

    return result;
  }

  // Регистрация нескольких абитуриентов для демонстрации.
  public int AddSamples() {
    string[][] data = {
      new[] { "Иванов", "Иван", "Иванович", "Мужской", "4521", "654321", "4,8", "1", "82 76 88 70 0", "09.03.02 09.03.03 10.03.01" },
      new[] { "Петрова", "Анна", "Сергеевна", "Женский", "4522", "111222", "5,0", "1", "95 90 94 0 0", "01.03.02 09.03.02" },
      new[] { "Сидоров", "Алексей", "Павлович", "Мужской", "4523", "333444", "4,2", "0", "70 72 75 0 0", "09.03.02 09.03.03" },
      new[] { "Кузнецова", "Мария", "Олеговна", "Женский", "4524", "555666", "4,6", "1", "88 80 0 0 85", "38.03.01 09.03.03" },
      new[] { "Смирнов", "Дмитрий", "Андреевич", "Мужской", "4525", "777888", "4,0", "0", "65 68 0 74 0", "10.03.01 09.03.02" },
      new[] { "Волкова", "Елена", "Игоревна", "Женский", "4526", "999000", "4,4", "0", "78 84 81 0 0", "09.03.02 01.03.02 09.03.03" },
      new[] { "Морозов", "Никита", "Ильич", "Мужской", "4527", "123123", "3,9", "0", "60 38 50 0 0", "09.03.03" },
      new[] { "Новикова", "Ольга", "Дмитриевна", "Женский", "4528", "456456", "4,9", "1", "90 86 0 0 92", "38.03.01" }
    };

    int count = 0;

    foreach (string[] row in data) {
      Register(CreateSample(row));
      count++;
    }

    return count;
  }

  private static Abiturient CreateSample(string[] row) {
    int year = DateTime.Today.Year;
    DateTime issued = new DateTime(year, 6, 25) > DateTime.Today
      ? DateTime.Today
      : new DateTime(year, 6, 25);

    Abiturient abiturient = new Abiturient {
      Passport = new PassportDocument {
        Surname = row[0],
        Name = row[1],
        Patronymic = row[2],
        Gender = row[3],
        BirthDate = new DateTime(year - 18, 5, 10),
        Series = row[4],
        Number = row[5],
        IssuedBy = "ГУ МВД России по г. Москве",
        IssueDate = new DateTime(year - 4, 6, 1)
      },
      Education = new EducationDocument {
        Institution = "МБОУ СОШ № " + row[5].Substring(0, 2),
        GraduationYear = year,
        AverageGrade = double.Parse(row[6].Replace(',', '.'),
          System.Globalization.CultureInfo.InvariantCulture),
        WithHonors = row[7] == "1",
        Number = "077240" + row[5],
        IssueDate = issued
      },
      Exams = new ExamResultsDocument {
        Number = "ЕГЭ-" + year + "-" + row[5],
        IssueDate = issued
      },
      Application = new ApplicationDocument {
        Number = "А-" + year + "-" + row[5],
        IssueDate = issued
      }
    };

    // Порядок баллов: русский, математика, информатика, физика, обществознание.
    string[] subjects = {
      "Русский язык", "Математика", "Информатика", "Физика", "Обществознание"
    };
    string[] scores = row[8].Split(' ');

    for (int i = 0; i < subjects.Length; i++) {
      int score = int.Parse(scores[i]);

      if (score > 0) {
        abiturient.Exams.AddResult(new ExamResult(subjects[i], score, year));
      }
    }

    foreach (string code in row[9].Split(' ')) {
      abiturient.Application.AddSpecialty(code);
    }

    return abiturient;
  }
}
}
