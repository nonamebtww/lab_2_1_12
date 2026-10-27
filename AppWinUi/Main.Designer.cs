namespace AppWinUi {
partial class Main {
  /// <summary>
  /// Required designer variable.
  /// </summary>
  private System.ComponentModel.IContainer components = null;

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

  #region Windows Form Designer generated code

  /// <summary>
  /// Required method for Designer support - do not modify
  /// the contents of this method with the code editor.
  /// </summary>
  private void InitializeComponent() {
    this.header = new System.Windows.Forms.Panel();
    this.box_page = new System.Windows.Forms.ComboBox();
    this.body = new System.Windows.Forms.TableLayoutPanel();
    this.header.SuspendLayout();
    this.SuspendLayout();
    // 
    // header
    // 
    this.header.AutoSize = true;
    this.header.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
    this.header.Controls.Add(this.box_page);
    this.header.Dock = System.Windows.Forms.DockStyle.Top;
    this.header.Location = new System.Drawing.Point(0, 0);
    this.header.MinimumSize = new System.Drawing.Size(0, 40);
    this.header.Name = "header";
    this.header.Size = new System.Drawing.Size(1100, 40);
    this.header.TabIndex = 0;
    // 
    // box_page
    // 
    this.box_page.FormattingEnabled = true;
    this.box_page.Location = new System.Drawing.Point(12, 12);
    this.box_page.Name = "box_page";
    this.box_page.Size = new System.Drawing.Size(160, 21);
    this.box_page.TabIndex = 0;
    this.box_page.SelectedIndexChanged += new System.EventHandler(this.box_page_SelectedIndexChanged);
    // 
    // body
    // 
    this.body.AutoSize = true;
    this.body.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
    this.body.ColumnCount = 1;
    this.body.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
    this.body.Dock = System.Windows.Forms.DockStyle.Fill;
    this.body.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
    this.body.Location = new System.Drawing.Point(0, 40);
    this.body.Name = "body";
    this.body.RowCount = 1;
    this.body.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
    this.body.Size = new System.Drawing.Size(1100, 620);
    this.body.TabIndex = 1;
    // 
    // Main
    // 
    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.ClientSize = new System.Drawing.Size(1100, 660);
    this.Controls.Add(this.body);
    this.Controls.Add(this.header);
    this.MinimumSize = new System.Drawing.Size(900, 600);
    this.Name = "Main";
    this.Text = "Лабораторная работа № 12";
    this.header.ResumeLayout(false);
    this.ResumeLayout(false);
    this.PerformLayout();
  }
  private System.Windows.Forms.ComboBox box_page;
  private System.Windows.Forms.TableLayoutPanel body;
  private System.Windows.Forms.Panel header;

  #endregion
}
}