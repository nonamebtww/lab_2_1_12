using System.ComponentModel;

namespace AppWinUi.Pages {
partial class HomePage {
  /// <summary> 
  /// Required designer variable.
  /// </summary>
  private IContainer components = null;

  /// <summary> 
  /// Clean up any resources being used.
  /// </summary>
  /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
  protected override void Dispose(bool disposing) {
    if (disposing && (components != null)) {
      components.Dispose();
    }
    base.Dispose(disposing);
  }

  #region Component Designer generated code

  /// <summary>
  /// Required method for Designer support - do not modify
  /// the contents of this method with the code editor.
  /// </summary>
  private void InitializeComponent() {
    this.body = new System.Windows.Forms.TableLayoutPanel();
    this.lbl_welcome = new System.Windows.Forms.Label();
    this.body.SuspendLayout();
    this.SuspendLayout();
    // 
    // body
    // 
    this.body.AutoSize = true;
    this.body.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
    this.body.ColumnCount = 1;
    this.body.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
    this.body.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
    this.body.Controls.Add(this.lbl_welcome, 0, 0);
    this.body.Dock = System.Windows.Forms.DockStyle.Fill;
    this.body.Location = new System.Drawing.Point(0, 0);
    this.body.MinimumSize = new System.Drawing.Size(400, 225);
    this.body.Name = "body";
    this.body.RowCount = 1;
    this.body.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
    this.body.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
    this.body.Size = new System.Drawing.Size(573, 420);
    this.body.TabIndex = 0;
    // 
    // lbl_welcome
    // 
    this.lbl_welcome.Dock = System.Windows.Forms.DockStyle.Fill;
    this.lbl_welcome.Location = new System.Drawing.Point(3, 0);
    this.lbl_welcome.Name = "lbl_welcome";
    this.lbl_welcome.Size = new System.Drawing.Size(567, 420);
    this.lbl_welcome.TabIndex = 0;
    this.lbl_welcome.Text = "Выберите одно из задание, в левом верхнем углу!";
    this.lbl_welcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
    // 
    // HomePage
    // 
    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.Controls.Add(this.body);
    this.Name = "HomePage";
    this.Size = new System.Drawing.Size(573, 420);
    this.body.ResumeLayout(false);
    this.ResumeLayout(false);
    this.PerformLayout();
  }
  private System.Windows.Forms.Label lbl_welcome;
  private System.Windows.Forms.TableLayoutPanel body;

  #endregion
}
}