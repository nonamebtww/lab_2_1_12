using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Task1;
using Task3;
using FunctionsTask2 = Task2.Functions;

namespace Task3WinForms {
public partial class Task3Page : UserControl {
  // Работа с приёмной комиссией идёт через интерфейсные ссылки.
  private readonly AdmissionService service = new AdmissionService();
  private readonly IAbiturientRegistry registry;
  private readonly IRatingService rating;

  public Task3Page() {
    InitializeComponent();

    registry = service;
    rating = service;

    listAbiturients.Columns.Add("ФИО", 200);
    listAbiturients.Columns.Add("Паспорт", 90);
    listAbiturients.Columns.Add("Баллы", 50);
    listAbiturients.Columns.Add("Направления", 220);

    listRating.Columns.Add("№", 35);
    listRating.Columns.Add("ФИО", 190);
    listRating.Columns.Add("Баллы", 50);
    listRating.Columns.Add("Приоритет", 75);
    listRating.Columns.Add("Статус", 300);

    foreach (Specialty specialty in SpecialtyCatalog.All) {
      boxSpecialty.Items.Add(specialty);
    }

    boxSpecialty.SelectedIndex = 0;
    ShowAbiturients();
  }

  private void ShowAbiturients() {
    labelCurrent.Text = "Текущий: " + Abiturient.Current.FullName;
    listAbiturients.Items.Clear();

    foreach (Abiturient abiturient in registry.GetAll()) {
      ListViewItem item = new ListViewItem(abiturient.FullName);
      item.SubItems.Add(abiturient.Key);
      item.SubItems.Add(FunctionsTask2.GetTotalScore(abiturient).ToString());
      item.SubItems.Add(string.Join(", ", abiturient.Application.SpecialtyCodes));
      item.Tag = abiturient;
      listAbiturients.Items.Add(item);
    }

    if (service.LoadErrors.Count > 0) {
      ShowError("Некоторые файлы не прочитаны:" + Environment.NewLine +
                string.Join(Environment.NewLine, service.LoadErrors));
    }
  }

  private Abiturient SelectedAbiturient() {
    if (listAbiturients.SelectedItems.Count == 0) {
      ShowError("Выберите абитуриента в списке.");
      return null;
    }

    return (Abiturient)listAbiturients.SelectedItems[0].Tag;
  }

  private void btnRegister_Click(object sender, EventArgs e) {
    try {
      registry.Register(Abiturient.Current);
      ShowAbiturients();
      MessageBox.Show(
        "Абитуриент " + Abiturient.Current.FullName + " зарегистрирован.",
        "Готово",
        MessageBoxButtons.OK,
        MessageBoxIcon.Information
      );
    }
    catch (Exception ex) {
      ShowError(ex.Message);
    }
  }

  private void btnMakeCurrent_Click(object sender, EventArgs e) {
    Abiturient abiturient = SelectedAbiturient();

    if (abiturient != null) {
      Abiturient.Current = abiturient;
      labelCurrent.Text = "Текущий: " + abiturient.FullName;
    }
  }

  private void btnRemove_Click(object sender, EventArgs e) {
    Abiturient abiturient = SelectedAbiturient();

    if (abiturient == null) {
      return;
    }

    if (MessageBox.Show(
          "Удалить " + abiturient.FullName + "?",
          "Удаление",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Question
        ) == DialogResult.Yes) {
      registry.Remove(abiturient.Key);
      ShowAbiturients();
    }
  }

  private void btnSamples_Click(object sender, EventArgs e) {
    try {
      int count = service.AddSamples();
      ShowAbiturients();
      MessageBox.Show("Добавлено абитуриентов: " + count, "Готово",
        MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    catch (Exception ex) {
      ShowError(ex.Message);
    }
  }

  private void btnRefresh_Click(object sender, EventArgs e) {
    ShowAbiturients();
  }

  private void btnRating_Click(object sender, EventArgs e) {
    Specialty specialty = (Specialty)boxSpecialty.SelectedItem;
    ShowEntries(specialty, rating.GetRating(specialty), "Конкурсный список");
  }

  private void btnAdmitted_Click(object sender, EventArgs e) {
    Specialty specialty = (Specialty)boxSpecialty.SelectedItem;
    ShowEntries(specialty, rating.GetAdmitted(specialty), "Рекомендованные к зачислению");
  }

  private void ShowEntries(Specialty specialty, List<RatingEntry> entries, string title) {
    labelInfo.Text =
      title + ": " + specialty + Environment.NewLine +
      "Экзамены: " + string.Join(", ", specialty.Subjects) +
      "; проходной балл: " + specialty.PassingScore +
      "; мест: " + specialty.Places +
      "; в списке: " + entries.Count;

    listRating.Items.Clear();

    foreach (RatingEntry entry in entries) {
      ListViewItem item = new ListViewItem(entry.Position.ToString());
      item.SubItems.Add(entry.Abiturient.FullName);
      item.SubItems.Add(entry.Score.ToString());
      item.SubItems.Add(entry.Priority.ToString());
      item.SubItems.Add(entry.Status);
      listRating.Items.Add(item);
    }
  }

  private static void ShowError(string message) {
    MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
  }
}
}
