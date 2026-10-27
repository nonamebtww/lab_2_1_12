namespace Task2WinForms {
  partial class Task2Page {
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.TableLayoutPanel body;
    private System.Windows.Forms.GroupBox groupActions;
    private System.Windows.Forms.Label labelCurrentTitle;
    private System.Windows.Forms.Label labelCurrent;
    private System.Windows.Forms.Button btnCheck;
    private System.Windows.Forms.Button btnScores;
    private System.Windows.Forms.Button btnApplication;
    private System.Windows.Forms.Button btnSuitable;
    private System.Windows.Forms.Button btnReport;
    private System.Windows.Forms.Label labelFile;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnLoad;
    private System.Windows.Forms.GroupBox groupResult;
    private System.Windows.Forms.TextBox boxResult;
    private System.Windows.Forms.SaveFileDialog saveDialog;
    private System.Windows.Forms.OpenFileDialog openDialog;

    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }

      base.Dispose(disposing);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.body = new System.Windows.Forms.TableLayoutPanel();
      this.groupActions = new System.Windows.Forms.GroupBox();
      this.labelCurrentTitle = new System.Windows.Forms.Label();
      this.labelCurrent = new System.Windows.Forms.Label();
      this.btnCheck = new System.Windows.Forms.Button();
      this.btnScores = new System.Windows.Forms.Button();
      this.btnApplication = new System.Windows.Forms.Button();
      this.btnSuitable = new System.Windows.Forms.Button();
      this.btnReport = new System.Windows.Forms.Button();
      this.labelFile = new System.Windows.Forms.Label();
      this.btnSave = new System.Windows.Forms.Button();
      this.btnLoad = new System.Windows.Forms.Button();
      this.groupResult = new System.Windows.Forms.GroupBox();
      this.boxResult = new System.Windows.Forms.TextBox();
      this.saveDialog = new System.Windows.Forms.SaveFileDialog();
      this.openDialog = new System.Windows.Forms.OpenFileDialog();
      this.body.SuspendLayout();
      this.groupActions.SuspendLayout();
      this.groupResult.SuspendLayout();
      this.SuspendLayout();
      // 
      // body
      // 
      this.body.Controls.Add(this.groupActions, 0, 0);
      this.body.Controls.Add(this.groupResult, 1, 0);
      this.body.ColumnCount = 2;
      this.body.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 290F));
      this.body.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.body.Dock = System.Windows.Forms.DockStyle.Fill;
      this.body.Location = new System.Drawing.Point(0, 0);
      this.body.RowCount = 1;
      this.body.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.body.Size = new System.Drawing.Size(1080, 600);
      this.body.Name = "body";
      this.body.TabIndex = 0;
      // 
      // groupActions
      // 
      this.groupActions.Controls.Add(this.labelCurrentTitle);
      this.groupActions.Controls.Add(this.labelCurrent);
      this.groupActions.Controls.Add(this.btnCheck);
      this.groupActions.Controls.Add(this.btnScores);
      this.groupActions.Controls.Add(this.btnApplication);
      this.groupActions.Controls.Add(this.btnSuitable);
      this.groupActions.Controls.Add(this.btnReport);
      this.groupActions.Controls.Add(this.labelFile);
      this.groupActions.Controls.Add(this.btnSave);
      this.groupActions.Controls.Add(this.btnLoad);
      this.groupActions.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupActions.Location = new System.Drawing.Point(3, 3);
      this.groupActions.Size = new System.Drawing.Size(284, 594);
      this.groupActions.Text = "Обработка документов";
      this.groupActions.TabStop = false;
      this.groupActions.Name = "groupActions";
      this.groupActions.TabIndex = 1;
      // 
      // labelCurrentTitle
      // 
      this.labelCurrentTitle.Location = new System.Drawing.Point(15, 25);
      this.labelCurrentTitle.Text = "Текущий абитуриент:";
      this.labelCurrentTitle.Name = "labelCurrentTitle";
      this.labelCurrentTitle.TabIndex = 2;
      this.labelCurrentTitle.AutoSize = true;
      // 
      // labelCurrent
      // 
      this.labelCurrent.Location = new System.Drawing.Point(15, 45);
      this.labelCurrent.Text = "-";
      this.labelCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
      this.labelCurrent.Name = "labelCurrent";
      this.labelCurrent.TabIndex = 3;
      this.labelCurrent.AutoSize = true;
      // 
      // btnCheck
      // 
      this.btnCheck.Location = new System.Drawing.Point(15, 75);
      this.btnCheck.Size = new System.Drawing.Size(230, 30);
      this.btnCheck.Text = "Проверить документы";
      this.btnCheck.Name = "btnCheck";
      this.btnCheck.TabIndex = 4;
      this.btnCheck.UseVisualStyleBackColor = true;
      this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
      // 
      // btnScores
      // 
      this.btnScores.Location = new System.Drawing.Point(15, 112);
      this.btnScores.Size = new System.Drawing.Size(230, 30);
      this.btnScores.Text = "Подсчитать баллы";
      this.btnScores.Name = "btnScores";
      this.btnScores.TabIndex = 5;
      this.btnScores.UseVisualStyleBackColor = true;
      this.btnScores.Click += new System.EventHandler(this.btnScores_Click);
      // 
      // btnApplication
      // 
      this.btnApplication.Location = new System.Drawing.Point(15, 149);
      this.btnApplication.Size = new System.Drawing.Size(230, 30);
      this.btnApplication.Text = "Проверить заявление";
      this.btnApplication.Name = "btnApplication";
      this.btnApplication.TabIndex = 6;
      this.btnApplication.UseVisualStyleBackColor = true;
      this.btnApplication.Click += new System.EventHandler(this.btnApplication_Click);
      // 
      // btnSuitable
      // 
      this.btnSuitable.Location = new System.Drawing.Point(15, 186);
      this.btnSuitable.Size = new System.Drawing.Size(230, 30);
      this.btnSuitable.Text = "Подобрать направления";
      this.btnSuitable.Name = "btnSuitable";
      this.btnSuitable.TabIndex = 7;
      this.btnSuitable.UseVisualStyleBackColor = true;
      this.btnSuitable.Click += new System.EventHandler(this.btnSuitable_Click);
      // 
      // btnReport
      // 
      this.btnReport.Location = new System.Drawing.Point(15, 223);
      this.btnReport.Size = new System.Drawing.Size(230, 30);
      this.btnReport.Text = "Сводный отчёт";
      this.btnReport.Name = "btnReport";
      this.btnReport.TabIndex = 8;
      this.btnReport.UseVisualStyleBackColor = true;
      this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
      // 
      // labelFile
      // 
      this.labelFile.Location = new System.Drawing.Point(15, 275);
      this.labelFile.Text = "Файл документов:";
      this.labelFile.Name = "labelFile";
      this.labelFile.TabIndex = 9;
      this.labelFile.AutoSize = true;
      // 
      // btnSave
      // 
      this.btnSave.Location = new System.Drawing.Point(15, 295);
      this.btnSave.Size = new System.Drawing.Size(230, 30);
      this.btnSave.Text = "Сохранить в файл...";
      this.btnSave.Name = "btnSave";
      this.btnSave.TabIndex = 10;
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // btnLoad
      // 
      this.btnLoad.Location = new System.Drawing.Point(15, 332);
      this.btnLoad.Size = new System.Drawing.Size(230, 30);
      this.btnLoad.Text = "Загрузить из файла...";
      this.btnLoad.Name = "btnLoad";
      this.btnLoad.TabIndex = 11;
      this.btnLoad.UseVisualStyleBackColor = true;
      this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
      // 
      // groupResult
      // 
      this.groupResult.Controls.Add(this.boxResult);
      this.groupResult.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupResult.Location = new System.Drawing.Point(293, 3);
      this.groupResult.Size = new System.Drawing.Size(784, 594);
      this.groupResult.Text = "Результат";
      this.groupResult.TabStop = false;
      this.groupResult.Name = "groupResult";
      this.groupResult.TabIndex = 12;
      // 
      // boxResult
      // 
      this.boxResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
      this.boxResult.Font = new System.Drawing.Font("Consolas", 9F);
      this.boxResult.Location = new System.Drawing.Point(10, 22);
      this.boxResult.Multiline = true;
      this.boxResult.Size = new System.Drawing.Size(764, 562);
      this.boxResult.ReadOnly = true;
      this.boxResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.boxResult.WordWrap = false;
      this.boxResult.Name = "boxResult";
      this.boxResult.TabIndex = 13;
      // 
      // saveDialog
      // 
      this.saveDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
      // 
      // openDialog
      // 
      this.openDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
      // 
      // Task2Page
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.body);
      this.Name = "Task2Page";
      this.Size = new System.Drawing.Size(1080, 600);
      this.groupResult.ResumeLayout(false);
      this.groupResult.PerformLayout();
      this.groupActions.ResumeLayout(false);
      this.groupActions.PerformLayout();
      this.body.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
