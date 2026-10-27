using System;
using System.Windows.Forms;
using AppWinUi.Pages;
using Task1WinForms;
using Task2WinForms;
using Task3WinForms;

namespace AppWinUi {
public partial class Main : Form {
  public Main() {
    InitializeComponent();
    
    box_page.Items.AddRange(new object[] {
      "Задание 1",
      "Задание 2",
      "Задание 3"
    });
    
    ShowPage(new HomePage());
  }
  
  private void box_page_SelectedIndexChanged(object sender, EventArgs e) {
    var box = (ComboBox)sender;
    
    switch (box.SelectedIndex) {
      case 0:
        ShowPage(new Task1Page());
        break;
      case 1:
        ShowPage(new Task2Page());
        break;
      case 2:
        ShowPage(new Task3Page());
        break;
    }
  }

  #region Helpers

  private void ShowPage(UserControl page) {
    body.Controls.Clear();
    body.Controls.Add(page);
    page.Dock = DockStyle.Fill;
  }

  #endregion
}
}