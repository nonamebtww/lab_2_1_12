using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Task1;
using Task2;
using FunctionsTask2 = Task2.Functions;

namespace Task2WinForms {
public partial class Task2Page : UserControl {
  public Task2Page() {
    InitializeComponent();
    ShowCurrent();
  }

  private void ShowCurrent() {
    labelCurrent.Text = Abiturient.Current.FullName;
  }

  private void ShowResult(string text) {
    ShowCurrent();
    boxResult.Text = text.Replace("\r\n", "\n").Replace("\n", Environment.NewLine);
  }

  private void btnCheck_Click(object sender, EventArgs e) {
    List<string> errors = FunctionsTask2.CheckDocuments(Abiturient.Current);

    if (errors.Count == 0) {
      ShowResult("Документы в порядке, ошибок не найдено.");
      return;
    }

    ShowResult(
      "Найдено ошибок: " + errors.Count + Environment.NewLine +
      "  - " + string.Join(Environment.NewLine + "  - ", errors)
    );
  }

  private void btnScores_Click(object sender, EventArgs e) {
    Abiturient abiturient = Abiturient.Current;
    StringBuilder builder = new StringBuilder();

    builder.AppendLine(
      "Сумма баллов ЕГЭ: " + (abiturient.Exams == null ? 0 : abiturient.Exams.GetScore())
    );
    builder.AppendLine("Баллы за достижения: " + FunctionsTask2.GetAchievementScore(abiturient));
    builder.AppendLine("Всего баллов: " + FunctionsTask2.GetTotalScore(abiturient));
    builder.AppendLine();
    builder.AppendLine("Конкурсные баллы по направлениям:");

    foreach (Specialty specialty in SpecialtyCatalog.All) {
      builder.AppendLine(
        "  " + specialty + " - " + FunctionsTask2.GetScoreForSpecialty(abiturient, specialty)
      );
    }

    ShowResult(builder.ToString());
  }

  private void btnApplication_Click(object sender, EventArgs e) {
    ShowChecks(
      FunctionsTask2.CheckApplication(Abiturient.Current),
      "В заявлении нет направлений."
    );
  }

  private void btnSuitable_Click(object sender, EventArgs e) {
    ShowChecks(
      FunctionsTask2.FindSuitableSpecialties(Abiturient.Current),
      "Подходящих направлений нет."
    );
  }

  private void btnReport_Click(object sender, EventArgs e) {
    ShowResult(FunctionsTask2.BuildReport(Abiturient.Current));
  }

  private void btnSave_Click(object sender, EventArgs e) {
    try {
      saveDialog.FileName = FunctionsTask2.GetFileName(Abiturient.Current);

      if (saveDialog.ShowDialog() == DialogResult.OK) {
        FunctionsTask2.SaveToFile(Abiturient.Current, saveDialog.FileName);
        ShowResult("Документы сохранены в файл " + saveDialog.FileName);
      }
    }
    catch (Exception ex) {
      ShowError(ex.Message);
    }
  }

  private void btnLoad_Click(object sender, EventArgs e) {
    if (openDialog.ShowDialog() != DialogResult.OK) {
      return;
    }

    try {
      Abiturient.Current = FunctionsTask2.LoadFromFile(openDialog.FileName);
      ShowResult("Загружен абитуриент: " + Abiturient.Current.FullName);
    }
    catch (Exception ex) {
      ShowError(ex.Message);
    }
  }

  private void ShowChecks(List<SpecialtyCheck> checks, string emptyMessage) {
    if (checks.Count == 0) {
      ShowResult(emptyMessage);
      return;
    }

    StringBuilder builder = new StringBuilder();

    foreach (SpecialtyCheck check in checks) {
      builder.AppendLine(check.ToString());
    }

    ShowResult(builder.ToString());
  }

  private static void ShowError(string message) {
    MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
  }
}
}
