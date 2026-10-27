using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Task1 {
// Базовый класс всех документов абитуриента.
// Реализует интерфейсы IDocument, IValidatable и IStorable,
// а конкретные документы дополняют и переопределяют его члены.
public abstract class Document : IDocument, IValidatable, IStorable {
  public const string DateFormat = "dd.MM.yyyy";

  private string number = string.Empty;
  private DateTime issueDate = DateTime.Today;

  public abstract string Title { get; }

  // Название раздела в файле совпадает с названием документа.
  public string Section {
    get { return Title; }
  }

  public string Number {
    get { return number; }
    set {
      if (string.IsNullOrWhiteSpace(value)) {
        throw new ArgumentException("Номер документа не может быть пустым.");
      }

      string trimmed = value.Trim();
      CheckNumber(trimmed);
      number = trimmed;
    }
  }

  public DateTime IssueDate {
    get { return issueDate; }
    set {
      if (value.Date > DateTime.Today) {
        throw new ArgumentException("Дата выдачи не может быть в будущем.");
      }

      issueDate = value.Date;
    }
  }

  // Проверка формата номера. Наследники могут задать свои правила.
  protected virtual void CheckNumber(string value) {
    foreach (char c in value) {
      if (!char.IsLetterOrDigit(c) && c != '-' && c != ' ' && c != '/') {
        throw new ArgumentException(
          "Номер может содержать только буквы, цифры, пробел, '-' и '/'."
        );
      }
    }
  }

  public virtual string GetInfo() {
    return Title + Environment.NewLine +
           "  Номер: " + (number.Length > 0 ? number : "не указан") +
           Environment.NewLine +
           "  Дата выдачи: " + FormatDate(issueDate);
  }

  public virtual List<string> Validate() {
    List<string> errors = new List<string>();

    if (number.Length == 0) {
      errors.Add("не указан номер документа");
    }

    return errors;
  }

  public virtual List<string> Save() {
    return new List<string> {
      "Number=" + number,
      "IssueDate=" + FormatDate(issueDate)
    };
  }

  public virtual void Load(string key, string value) {
    switch (key) {
      case "Number":
        Number = value;
        break;
      case "IssueDate":
        IssueDate = ParseDate(value);
        break;
      default:
        throw new FormatException("Неизвестный ключ: " + key);
    }
  }

  public static string FormatDate(DateTime date) {
    return date.ToString(DateFormat, CultureInfo.InvariantCulture);
  }

  public static DateTime ParseDate(string text) {
    DateTime result;

    if (!DateTime.TryParseExact(
          text.Trim(),
          DateFormat,
          CultureInfo.InvariantCulture,
          DateTimeStyles.None,
          out result
        )) {
      throw new FormatException(
        "Дата должна быть в формате дд.мм.гггг: " + text
      );
    }

    return result;
  }

  // Проверка, что строка состоит из букв, пробелов и дефисов.
  protected static string CheckName(string value, string field, bool required) {
    if (string.IsNullOrWhiteSpace(value)) {
      if (required) {
        throw new ArgumentException("Поле \"" + field + "\" не может быть пустым.");
      }

      return string.Empty;
    }

    string trimmed = value.Trim();

    foreach (char c in trimmed) {
      if (!char.IsLetter(c) && c != '-' && c != ' ') {
        throw new ArgumentException(
          "Поле \"" + field + "\" может содержать только буквы, пробел и дефис."
        );
      }
    }

    return trimmed;
  }

  protected static bool IsDigits(string value, int length) {
    if (value.Length != length) {
      return false;
    }

    foreach (char c in value) {
      if (!char.IsDigit(c)) {
        return false;
      }
    }

    return true;
  }

  protected static int Age(DateTime birth, DateTime onDate) {
    int age = onDate.Year - birth.Year;

    if (onDate < birth.AddYears(age)) {
      age--;
    }

    return age;
  }
}

// Паспорт абитуриента.
public class PassportDocument : Document {
  public const string SectionName = "Паспорт";

  public static readonly string[] Genders = { "Мужской", "Женский" };

  private string surname = string.Empty;
  private string name = string.Empty;
  private string patronymic = string.Empty;
  private string series = string.Empty;
  private string gender = Genders[0];
  private string issuedBy = string.Empty;
  private DateTime birthDate = DateTime.Today.AddYears(-18);

  public override string Title {
    get { return SectionName; }
  }

  public string Surname {
    get { return surname; }
    set { surname = CheckName(value, "Фамилия", true); }
  }

  public string Name {
    get { return name; }
    set { name = CheckName(value, "Имя", true); }
  }

  // Отчество необязательно.
  public string Patronymic {
    get { return patronymic; }
    set { patronymic = CheckName(value, "Отчество", false); }
  }

  public string Series {
    get { return series; }
    set {
      string trimmed = (value ?? string.Empty).Trim();

      if (!IsDigits(trimmed, 4)) {
        throw new ArgumentException("Серия паспорта должна состоять из 4 цифр.");
      }

      series = trimmed;
    }
  }

  public DateTime BirthDate {
    get { return birthDate; }
    set {
      if (value.Date >= DateTime.Today) {
        throw new ArgumentException("Дата рождения должна быть в прошлом.");
      }

      birthDate = value.Date;
    }
  }

  public string Gender {
    get { return gender; }
    set {
      if (Array.IndexOf(Genders, value) < 0) {
        throw new ArgumentException("Пол должен быть выбран из списка.");
      }

      gender = value;
    }
  }

  public string IssuedBy {
    get { return issuedBy; }
    set {
      if (string.IsNullOrWhiteSpace(value)) {
        throw new ArgumentException("Поле \"Кем выдан\" не может быть пустым.");
      }

      issuedBy = value.Trim();
    }
  }

  public string FullName {
    get {
      return (surname + " " + name + " " + patronymic).Trim();
    }
  }

  // Номер паспорта - ровно 6 цифр.
  protected override void CheckNumber(string value) {
    if (!IsDigits(value, 6)) {
      throw new ArgumentException("Номер паспорта должен состоять из 6 цифр.");
    }
  }

  public override string GetInfo() {
    return Title + Environment.NewLine +
           "  ФИО: " + FullName + Environment.NewLine +
           "  Пол: " + gender + Environment.NewLine +
           "  Дата рождения: " + FormatDate(birthDate) +
           " (возраст " + Age(birthDate, DateTime.Today) + ")" +
           Environment.NewLine +
           "  Серия и номер: " + series + " " + Number + Environment.NewLine +
           "  Кем выдан: " + issuedBy + Environment.NewLine +
           "  Дата выдачи: " + FormatDate(IssueDate);
  }

  public override List<string> Validate() {
    List<string> errors = base.Validate();

    if (surname.Length == 0) {
      errors.Add("не указана фамилия");
    }

    if (name.Length == 0) {
      errors.Add("не указано имя");
    }

    if (series.Length == 0) {
      errors.Add("не указана серия паспорта");
    }

    if (issuedBy.Length == 0) {
      errors.Add("не указано, кем выдан паспорт");
    }

    int age = Age(birthDate, DateTime.Today);

    if (age < 14 || age > 100) {
      errors.Add("возраст владельца должен быть от 14 до 100 лет");
    }

    if (Age(birthDate, IssueDate) < 14) {
      errors.Add("паспорт выдаётся не ранее 14 лет");
    }

    return errors;
  }

  public override List<string> Save() {
    List<string> lines = base.Save();
    lines.Add("Surname=" + surname);
    lines.Add("Name=" + name);
    lines.Add("Patronymic=" + patronymic);
    lines.Add("Gender=" + gender);
    lines.Add("BirthDate=" + FormatDate(birthDate));
    lines.Add("Series=" + series);
    lines.Add("IssuedBy=" + issuedBy);
    return lines;
  }

  public override void Load(string key, string value) {
    switch (key) {
      case "Surname":
        Surname = value;
        break;
      case "Name":
        Name = value;
        break;
      case "Patronymic":
        Patronymic = value;
        break;
      case "Gender":
        Gender = value;
        break;
      case "BirthDate":
        BirthDate = ParseDate(value);
        break;
      case "Series":
        Series = value;
        break;
      case "IssuedBy":
        IssuedBy = value;
        break;
      default:
        base.Load(key, value);
        break;
    }
  }
}

// Документ об образовании (аттестат или диплом СПО).
// Реализует IScorable: документ с отличием даёт баллы за достижения.
public class EducationDocument : Document, IScorable {
  public const string SectionName = "Документ об образовании";
  public const int HonorsScore = 5;

  public static readonly string[] Levels = {
    "Среднее общее (аттестат)",
    "Среднее профессиональное (диплом)"
  };

  private string level = Levels[0];
  private string institution = string.Empty;
  private int graduationYear = DateTime.Today.Year;
  private double averageGrade = 4.0;

  public override string Title {
    get { return SectionName; }
  }

  public string Level {
    get { return level; }
    set {
      if (Array.IndexOf(Levels, value) < 0) {
        throw new ArgumentException("Уровень образования должен быть выбран из списка.");
      }

      level = value;
    }
  }

  public string Institution {
    get { return institution; }
    set {
      if (string.IsNullOrWhiteSpace(value)) {
        throw new ArgumentException("Название учебного заведения не может быть пустым.");
      }

      institution = value.Trim();
    }
  }

  public int GraduationYear {
    get { return graduationYear; }
    set {
      if (value < 1950 || value > DateTime.Today.Year) {
        throw new ArgumentException(
          "Год окончания должен быть от 1950 до " + DateTime.Today.Year + "."
        );
      }

      graduationYear = value;
    }
  }

  public double AverageGrade {
    get { return averageGrade; }
    set {
      if (value < 3.0 || value > 5.0) {
        throw new ArgumentException("Средний балл должен быть от 3,0 до 5,0.");
      }

      averageGrade = Math.Round(value, 2);
    }
  }

  public bool WithHonors { get; set; }

  public int GetScore() {
    return WithHonors ? HonorsScore : 0;
  }

  public override string GetInfo() {
    return Title + Environment.NewLine +
           "  Уровень: " + level + Environment.NewLine +
           "  Учебное заведение: " + institution + Environment.NewLine +
           "  Год окончания: " + graduationYear + Environment.NewLine +
           "  Средний балл: " + averageGrade.ToString("0.00") + Environment.NewLine +
           "  С отличием: " + (WithHonors ? "да" : "нет") + Environment.NewLine +
           "  Номер: " + Number + ", выдан " + FormatDate(IssueDate);
  }

  public override List<string> Validate() {
    List<string> errors = base.Validate();

    if (institution.Length == 0) {
      errors.Add("не указано учебное заведение");
    }

    if (WithHonors && averageGrade < 4.5) {
      errors.Add("документ с отличием не может иметь средний балл ниже 4,5");
    }

    if (IssueDate.Year != graduationYear) {
      errors.Add("год выдачи документа не совпадает с годом окончания");
    }

    return errors;
  }

  public override List<string> Save() {
    List<string> lines = base.Save();
    lines.Add("Level=" + level);
    lines.Add("Institution=" + institution);
    lines.Add("GraduationYear=" + graduationYear);
    lines.Add("AverageGrade=" + averageGrade.ToString(CultureInfo.InvariantCulture));
    lines.Add("WithHonors=" + WithHonors);
    return lines;
  }

  public override void Load(string key, string value) {
    switch (key) {
      case "Level":
        Level = value;
        break;
      case "Institution":
        Institution = value;
        break;
      case "GraduationYear":
        GraduationYear = int.Parse(value);
        break;
      case "AverageGrade":
        AverageGrade = double.Parse(value, CultureInfo.InvariantCulture);
        break;
      case "WithHonors":
        WithHonors = bool.Parse(value);
        break;
      default:
        base.Load(key, value);
        break;
    }
  }
}

// Результат одного экзамена ЕГЭ.
public class ExamResult {
  // Результаты ЕГЭ действительны 4 года после года сдачи.
  public const int ValidYears = 4;

  public static readonly string[] Subjects = {
    "Русский язык",
    "Математика",
    "Информатика",
    "Физика",
    "Обществознание",
    "Иностранный язык",
    "Химия"
  };

  private string subject = Subjects[0];
  private int score;
  private int year = DateTime.Today.Year;

  public ExamResult(string subject, int score, int year) {
    Subject = subject;
    Score = score;
    Year = year;
  }

  public string Subject {
    get { return subject; }
    set {
      if (Array.IndexOf(Subjects, value) < 0) {
        throw new ArgumentException("Предмет должен быть выбран из списка.");
      }

      subject = value;
    }
  }

  public int Score {
    get { return score; }
    set {
      if (value < 0 || value > 100) {
        throw new ArgumentException("Балл ЕГЭ должен быть от 0 до 100.");
      }

      score = value;
    }
  }

  public int Year {
    get { return year; }
    set {
      if (value < 2009 || value > DateTime.Today.Year) {
        throw new ArgumentException(
          "Год сдачи должен быть от 2009 до " + DateTime.Today.Year + "."
        );
      }

      year = value;
    }
  }

  public bool IsValid {
    get { return year >= DateTime.Today.Year - ValidYears; }
  }

  public override string ToString() {
    return subject + ": " + score + " (" + year + ")";
  }
}

// Сведения о результатах ЕГЭ.
// Реализует IScorable: баллы - сумма результатов всех экзаменов.
public class ExamResultsDocument : Document, IScorable {
  public const string SectionName = "Результаты ЕГЭ";
  public const int MinExamCount = 3;

  private readonly List<ExamResult> results = new List<ExamResult>();

  public override string Title {
    get { return SectionName; }
  }

  public IList<ExamResult> Results {
    get { return results.AsReadOnly(); }
  }

  public void AddResult(ExamResult result) {
    if (FindResult(result.Subject) != null) {
      throw new ArgumentException(
        "Результат по предмету \"" + result.Subject + "\" уже добавлен."
      );
    }

    results.Add(result);
  }

  public bool RemoveResult(string subject) {
    ExamResult result = FindResult(subject);
    return result != null && results.Remove(result);
  }

  public ExamResult FindResult(string subject) {
    foreach (ExamResult result in results) {
      if (result.Subject == subject) {
        return result;
      }
    }

    return null;
  }

  public int GetScore() {
    int sum = 0;

    foreach (ExamResult result in results) {
      sum += result.Score;
    }

    return sum;
  }

  public override string GetInfo() {
    StringBuilder builder = new StringBuilder();
    builder.Append(Title);
    builder.Append(Environment.NewLine + "  Номер: " + Number +
                   ", выдан " + FormatDate(IssueDate));

    if (results.Count == 0) {
      builder.Append(Environment.NewLine + "  Экзамены не добавлены");
    }

    foreach (ExamResult result in results) {
      builder.Append(Environment.NewLine + "  " + result);
    }

    builder.Append(Environment.NewLine + "  Сумма баллов: " + GetScore());
    return builder.ToString();
  }

  public override List<string> Validate() {
    List<string> errors = base.Validate();

    if (results.Count < MinExamCount) {
      errors.Add("должно быть не менее " + MinExamCount + " экзаменов");
    }

    if (FindResult("Русский язык") == null) {
      errors.Add("нет обязательного экзамена по русскому языку");
    }

    foreach (ExamResult result in results) {
      if (!result.IsValid) {
        errors.Add(
          "результат по предмету \"" + result.Subject + "\" за " +
          result.Year + " год уже недействителен"
        );
      }
    }

    return errors;
  }

  public override List<string> Save() {
    List<string> lines = base.Save();

    foreach (ExamResult result in results) {
      lines.Add("Exam=" + result.Subject + ";" + result.Score + ";" + result.Year);
    }

    return lines;
  }

  public override void Load(string key, string value) {
    if (key != "Exam") {
      base.Load(key, value);
      return;
    }

    string[] parts = value.Split(';');

    if (parts.Length != 3) {
      throw new FormatException("Неверная запись экзамена: " + value);
    }

    AddResult(new ExamResult(parts[0], int.Parse(parts[1]), int.Parse(parts[2])));
  }
}

// Заявление о приёме с выбранными направлениями подготовки.
// Порядок направлений в списке задаёт приоритет (первое - самое желаемое).
// Этот документ не реализует IScorable, так как баллов не даёт.
public class ApplicationDocument : Document {
  public const string SectionName = "Заявление о приёме";
  public const int MaxSpecialties = 3;

  private readonly List<string> specialtyCodes = new List<string>();

  public override string Title {
    get { return SectionName; }
  }

  public IList<string> SpecialtyCodes {
    get { return specialtyCodes.AsReadOnly(); }
  }

  public void AddSpecialty(string code) {
    if (SpecialtyCatalog.Find(code) == null) {
      throw new ArgumentException("Направление с кодом " + code + " не найдено.");
    }

    if (specialtyCodes.Contains(code)) {
      throw new ArgumentException("Направление " + code + " уже выбрано.");
    }

    if (specialtyCodes.Count >= MaxSpecialties) {
      throw new ArgumentException(
        "Можно выбрать не более " + MaxSpecialties + " направлений."
      );
    }

    specialtyCodes.Add(code);
  }

  public void ClearSpecialties() {
    specialtyCodes.Clear();
  }

  // Приоритет направления (1, 2, 3) или 0, если оно не выбрано.
  public int GetPriority(string code) {
    return specialtyCodes.IndexOf(code) + 1;
  }

  public override string GetInfo() {
    StringBuilder builder = new StringBuilder();
    builder.Append(Title);
    builder.Append(Environment.NewLine + "  Номер: " + Number +
                   ", подано " + FormatDate(IssueDate));

    if (specialtyCodes.Count == 0) {
      builder.Append(Environment.NewLine + "  Направления не выбраны");
    }

    for (int i = 0; i < specialtyCodes.Count; i++) {
      builder.Append(
        Environment.NewLine + "  Приоритет " + (i + 1) + ": " +
        SpecialtyCatalog.Find(specialtyCodes[i])
      );
    }

    return builder.ToString();
  }

  public override List<string> Validate() {
    List<string> errors = base.Validate();

    if (specialtyCodes.Count == 0) {
      errors.Add("не выбрано ни одного направления");
    }

    return errors;
  }

  public override List<string> Save() {
    List<string> lines = base.Save();

    foreach (string code in specialtyCodes) {
      lines.Add("Specialty=" + code);
    }

    return lines;
  }

  public override void Load(string key, string value) {
    if (key == "Specialty") {
      AddSpecialty(value);
    }
    else {
      base.Load(key, value);
    }
  }
}
}
