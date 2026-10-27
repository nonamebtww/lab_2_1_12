using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Task1;

namespace Task1WinForms {
public partial class Task1Page : UserControl {
  // Рабочие копии документов, которые редактируются на вкладках
  // ЕГЭ и Заявление до нажатия кнопки "Сохранить".
  private ExamResultsDocument exams = new ExamResultsDocument();
  private readonly List<string> chosenCodes = new List<string>();

  public Task1Page() {
    InitializeComponent();

    boxGender.Items.AddRange(PassportDocument.Genders);
    boxLevel.Items.AddRange(EducationDocument.Levels);
    boxSubject.Items.AddRange(ExamResult.Subjects);

    foreach (Specialty specialty in SpecialtyCatalog.All) {
      listCatalog.Items.Add(specialty);
    }

    boxSubject.SelectedIndex = 0;
    boxExamYear.Text = DateTime.Today.Year.ToString();

    LoadFromCurrent();
    ShowDocuments();
  }

  #region Заполнение полей из текущего абитуриента

  private void LoadFromCurrent() {
    Abiturient abiturient = Abiturient.Current;
    PassportDocument passport = abiturient.Passport ?? new PassportDocument();
    EducationDocument education = abiturient.Education ?? new EducationDocument();
    ApplicationDocument application = abiturient.Application ?? new ApplicationDocument();

    boxSurname.Text = passport.Surname;
    boxName.Text = passport.Name;
    boxPatronymic.Text = passport.Patronymic;
    boxGender.SelectedItem = passport.Gender;
    pickBirth.Value = passport.BirthDate;
    boxSeries.Text = passport.Series;
    boxPassportNumber.Text = passport.Number;
    boxIssuedBy.Text = passport.IssuedBy;
    pickPassportIssue.Value = passport.IssueDate;

    boxLevel.SelectedItem = education.Level;
    boxInstitution.Text = education.Institution;
    boxYear.Text = education.GraduationYear.ToString();
    boxAverage.Text = education.AverageGrade.ToString("0.00");
    checkHonors.Checked = education.WithHonors;
    boxEducationNumber.Text = education.Number;
    pickEducationIssue.Value = education.IssueDate;

    // Копия результатов ЕГЭ, чтобы изменения не попали
    // в текущего абитуриента до сохранения.
    exams = new ExamResultsDocument();

    if (abiturient.Exams != null) {
      foreach (ExamResult result in abiturient.Exams.Results) {
        exams.AddResult(new ExamResult(result.Subject, result.Score, result.Year));
      }
    }

    boxExamsNumber.Text = abiturient.Exams == null ? string.Empty : abiturient.Exams.Number;
    pickExamsIssue.Value = abiturient.Exams == null ? DateTime.Today : abiturient.Exams.IssueDate;
    ShowExams();

    chosenCodes.Clear();
    chosenCodes.AddRange(application.SpecialtyCodes);
    boxApplicationNumber.Text = application.Number;
    pickApplicationIssue.Value = application.IssueDate;
    ShowChosen();
  }

  #endregion

  #region Паспорт и документ об образовании

  private void btnSavePassport_Click(object sender, EventArgs e) {
    try {
      // Значения проверяются в свойствах класса PassportDocument.
      PassportDocument passport = new PassportDocument {
        Surname = boxSurname.Text,
        Name = boxName.Text,
        Patronymic = boxPatronymic.Text,
        Gender = (string)boxGender.SelectedItem,
        BirthDate = pickBirth.Value,
        Series = boxSeries.Text,
        Number = boxPassportNumber.Text,
        IssuedBy = boxIssuedBy.Text,
        IssueDate = pickPassportIssue.Value
      };

      Abiturient.Current.Passport = passport;
      Saved(passport);
    }
    catch (ArgumentException ex) {
      ShowError(ex.Message);
    }
  }

  private void btnSaveEducation_Click(object sender, EventArgs e) {
    try {
      int year;
      double average;

      if (!int.TryParse(boxYear.Text, out year)) {
        throw new ArgumentException("Год окончания должен быть целым числом.");
      }

      if (!double.TryParse(
            boxAverage.Text.Replace(',', '.'),
            NumberStyles.Float,
            CultureInfo.InvariantCulture,
            out average
          )) {
        throw new ArgumentException("Средний балл должен быть числом.");
      }

      EducationDocument education = new EducationDocument {
        Level = (string)boxLevel.SelectedItem,
        Institution = boxInstitution.Text,
        GraduationYear = year,
        AverageGrade = average,
        WithHonors = checkHonors.Checked,
        Number = boxEducationNumber.Text,
        IssueDate = pickEducationIssue.Value
      };

      Abiturient.Current.Education = education;
      Saved(education);
    }
    catch (ArgumentException ex) {
      ShowError(ex.Message);
    }
  }

  #endregion

  #region Результаты ЕГЭ

  private void btnAddExam_Click(object sender, EventArgs e) {
    try {
      int score;
      int year;

      if (!int.TryParse(boxScore.Text, out score)) {
        throw new ArgumentException("Балл должен быть целым числом.");
      }

      if (!int.TryParse(boxExamYear.Text, out year)) {
        throw new ArgumentException("Год сдачи должен быть целым числом.");
      }

      exams.AddResult(new ExamResult((string)boxSubject.SelectedItem, score, year));
      boxScore.Text = string.Empty;
      ShowExams();
    }
    catch (ArgumentException ex) {
      ShowError(ex.Message);
    }
  }

  private void btnRemoveExam_Click(object sender, EventArgs e) {
    ExamResult result = listExams.SelectedItem as ExamResult;

    if (result != null) {
      exams.RemoveResult(result.Subject);
      ShowExams();
    }
  }

  private void btnSaveExams_Click(object sender, EventArgs e) {
    try {
      // В абитуриента сохраняется копия рабочего документа.
      ExamResultsDocument saved = new ExamResultsDocument {
        Number = boxExamsNumber.Text,
        IssueDate = pickExamsIssue.Value
      };

      foreach (ExamResult result in exams.Results) {
        saved.AddResult(new ExamResult(result.Subject, result.Score, result.Year));
      }

      Abiturient.Current.Exams = saved;
      Saved(saved);
    }
    catch (ArgumentException ex) {
      ShowError(ex.Message);
    }
  }

  private void ShowExams() {
    listExams.Items.Clear();

    foreach (ExamResult result in exams.Results) {
      listExams.Items.Add(result);
    }
  }

  #endregion

  #region Заявление о приёме

  private void btnAddSpecialty_Click(object sender, EventArgs e) {
    Specialty specialty = listCatalog.SelectedItem as Specialty;

    if (specialty == null) {
      ShowError("Выберите направление в списке.");
      return;
    }

    if (chosenCodes.Contains(specialty.Code)) {
      ShowError("Это направление уже выбрано.");
      return;
    }

    if (chosenCodes.Count >= ApplicationDocument.MaxSpecialties) {
      ShowError("Можно выбрать не более " + ApplicationDocument.MaxSpecialties + " направлений.");
      return;
    }

    chosenCodes.Add(specialty.Code);
    ShowChosen();
  }

  private void btnRemoveSpecialty_Click(object sender, EventArgs e) {
    if (listChosen.SelectedIndex >= 0) {
      chosenCodes.RemoveAt(listChosen.SelectedIndex);
      ShowChosen();
    }
  }

  private void btnSaveApplication_Click(object sender, EventArgs e) {
    try {
      ApplicationDocument application = new ApplicationDocument {
        Number = boxApplicationNumber.Text,
        IssueDate = pickApplicationIssue.Value
      };

      foreach (string code in chosenCodes) {
        application.AddSpecialty(code);
      }

      Abiturient.Current.Application = application;
      Saved(application);
    }
    catch (ArgumentException ex) {
      ShowError(ex.Message);
    }
  }

  private void ShowChosen() {
    listChosen.Items.Clear();

    for (int i = 0; i < chosenCodes.Count; i++) {
      listChosen.Items.Add((i + 1) + ". " + SpecialtyCatalog.Find(chosenCodes[i]));
    }
  }

  #endregion

  #region Общие кнопки

  private void btnShow_Click(object sender, EventArgs e) {
    ShowDocuments();
  }

  private void btnSample_Click(object sender, EventArgs e) {
    Abiturient.Current = Abiturient.CreateSample();
    LoadFromCurrent();
    ShowDocuments();
  }

  private void btnClear_Click(object sender, EventArgs e) {
    Abiturient.Current = new Abiturient();
    LoadFromCurrent();
    ShowDocuments();
  }

  // Вывод всех документов через ссылки на интерфейс IDocument.
  private void ShowDocuments() {
    StringBuilder builder = new StringBuilder();
    List<IDocument> documents = Abiturient.Current.GetDocuments();

    builder.AppendLine("Абитуриент: " + Abiturient.Current.FullName);

    if (documents.Count == 0) {
      builder.AppendLine("Документы не заполнены.");
    }

    foreach (IDocument document in documents) {
      builder.AppendLine();
      builder.AppendLine(document.GetInfo());

      IScorable scorable = document as IScorable;

      if (scorable != null) {
        builder.AppendLine("  Конкурсные баллы документа: " + scorable.GetScore());
      }
    }

    boxDocuments.Text = builder.ToString();
  }

  // Сообщение о сохранении документа и найденных замечаниях.
  private void Saved(IValidatable document) {
    ShowDocuments();
    List<string> errors = document.Validate();

    if (errors.Count == 0) {
      MessageBox.Show("Документ сохранён.", "Готово",
        MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    else {
      MessageBox.Show(
        "Документ сохранён, но содержит замечания:" + Environment.NewLine +
        string.Join(Environment.NewLine, errors),
        "Замечания",
        MessageBoxButtons.OK,
        MessageBoxIcon.Warning
      );
    }
  }

  private static void ShowError(string message) {
    MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
  }

  #endregion
}
}
