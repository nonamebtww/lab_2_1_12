namespace Task3WinForms {
  partial class Task3Page {
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.TableLayoutPanel body;
    private System.Windows.Forms.GroupBox groupAbiturients;
    private System.Windows.Forms.Label labelCurrent;
    private System.Windows.Forms.Button btnRegister;
    private System.Windows.Forms.Button btnMakeCurrent;
    private System.Windows.Forms.Button btnRemove;
    private System.Windows.Forms.Button btnSamples;
    private System.Windows.Forms.Button btnRefresh;
    private System.Windows.Forms.ListView listAbiturients;
    private System.Windows.Forms.GroupBox groupRating;
    private System.Windows.Forms.Label labelSpecialty;
    private System.Windows.Forms.ComboBox boxSpecialty;
    private System.Windows.Forms.Button btnRating;
    private System.Windows.Forms.Button btnAdmitted;
    private System.Windows.Forms.Label labelInfo;
    private System.Windows.Forms.ListView listRating;

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
      this.groupAbiturients = new System.Windows.Forms.GroupBox();
      this.labelCurrent = new System.Windows.Forms.Label();
      this.btnRegister = new System.Windows.Forms.Button();
      this.btnMakeCurrent = new System.Windows.Forms.Button();
      this.btnRemove = new System.Windows.Forms.Button();
      this.btnSamples = new System.Windows.Forms.Button();
      this.btnRefresh = new System.Windows.Forms.Button();
      this.listAbiturients = new System.Windows.Forms.ListView();
      this.groupRating = new System.Windows.Forms.GroupBox();
      this.labelSpecialty = new System.Windows.Forms.Label();
      this.boxSpecialty = new System.Windows.Forms.ComboBox();
      this.btnRating = new System.Windows.Forms.Button();
      this.btnAdmitted = new System.Windows.Forms.Button();
      this.labelInfo = new System.Windows.Forms.Label();
      this.listRating = new System.Windows.Forms.ListView();
      this.body.SuspendLayout();
      this.groupAbiturients.SuspendLayout();
      this.groupRating.SuspendLayout();
      this.SuspendLayout();
      // 
      // body
      // 
      this.body.Controls.Add(this.groupAbiturients, 0, 0);
      this.body.Controls.Add(this.groupRating, 1, 0);
      this.body.ColumnCount = 2;
      this.body.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 500F));
      this.body.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.body.Dock = System.Windows.Forms.DockStyle.Fill;
      this.body.Location = new System.Drawing.Point(0, 0);
      this.body.RowCount = 1;
      this.body.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.body.Size = new System.Drawing.Size(1080, 600);
      this.body.Name = "body";
      this.body.TabIndex = 0;
      // 
      // groupAbiturients
      // 
      this.groupAbiturients.Controls.Add(this.labelCurrent);
      this.groupAbiturients.Controls.Add(this.btnRegister);
      this.groupAbiturients.Controls.Add(this.btnMakeCurrent);
      this.groupAbiturients.Controls.Add(this.btnRemove);
      this.groupAbiturients.Controls.Add(this.btnSamples);
      this.groupAbiturients.Controls.Add(this.btnRefresh);
      this.groupAbiturients.Controls.Add(this.listAbiturients);
      this.groupAbiturients.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupAbiturients.Location = new System.Drawing.Point(3, 3);
      this.groupAbiturients.Size = new System.Drawing.Size(494, 594);
      this.groupAbiturients.Text = "Абитуриенты";
      this.groupAbiturients.TabStop = false;
      this.groupAbiturients.Name = "groupAbiturients";
      this.groupAbiturients.TabIndex = 1;
      // 
      // labelCurrent
      // 
      this.labelCurrent.Location = new System.Drawing.Point(12, 22);
      this.labelCurrent.Text = "Текущий: -";
      this.labelCurrent.Name = "labelCurrent";
      this.labelCurrent.TabIndex = 2;
      this.labelCurrent.AutoSize = true;
      // 
      // btnRegister
      // 
      this.btnRegister.Location = new System.Drawing.Point(12, 42);
      this.btnRegister.Size = new System.Drawing.Size(200, 25);
      this.btnRegister.Text = "Зарегистрировать текущего";
      this.btnRegister.Name = "btnRegister";
      this.btnRegister.TabIndex = 3;
      this.btnRegister.UseVisualStyleBackColor = true;
      this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
      // 
      // btnMakeCurrent
      // 
      this.btnMakeCurrent.Location = new System.Drawing.Point(220, 42);
      this.btnMakeCurrent.Size = new System.Drawing.Size(200, 25);
      this.btnMakeCurrent.Text = "Сделать текущим";
      this.btnMakeCurrent.Name = "btnMakeCurrent";
      this.btnMakeCurrent.TabIndex = 4;
      this.btnMakeCurrent.UseVisualStyleBackColor = true;
      this.btnMakeCurrent.Click += new System.EventHandler(this.btnMakeCurrent_Click);
      // 
      // btnRemove
      // 
      this.btnRemove.Location = new System.Drawing.Point(12, 72);
      this.btnRemove.Size = new System.Drawing.Size(200, 25);
      this.btnRemove.Text = "Удалить";
      this.btnRemove.Name = "btnRemove";
      this.btnRemove.TabIndex = 5;
      this.btnRemove.UseVisualStyleBackColor = true;
      this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
      // 
      // btnSamples
      // 
      this.btnSamples.Location = new System.Drawing.Point(220, 72);
      this.btnSamples.Size = new System.Drawing.Size(200, 25);
      this.btnSamples.Text = "Добавить примеры";
      this.btnSamples.Name = "btnSamples";
      this.btnSamples.TabIndex = 6;
      this.btnSamples.UseVisualStyleBackColor = true;
      this.btnSamples.Click += new System.EventHandler(this.btnSamples_Click);
      // 
      // btnRefresh
      // 
      this.btnRefresh.Location = new System.Drawing.Point(12, 102);
      this.btnRefresh.Size = new System.Drawing.Size(200, 25);
      this.btnRefresh.Text = "Обновить список";
      this.btnRefresh.Name = "btnRefresh";
      this.btnRefresh.TabIndex = 7;
      this.btnRefresh.UseVisualStyleBackColor = true;
      this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
      // 
      // listAbiturients
      // 
      this.listAbiturients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
      this.listAbiturients.FullRowSelect = true;
      this.listAbiturients.GridLines = true;
      this.listAbiturients.HideSelection = false;
      this.listAbiturients.Location = new System.Drawing.Point(12, 135);
      this.listAbiturients.MultiSelect = false;
      this.listAbiturients.Size = new System.Drawing.Size(470, 445);
      this.listAbiturients.UseCompatibleStateImageBehavior = false;
      this.listAbiturients.View = System.Windows.Forms.View.Details;
      this.listAbiturients.Name = "listAbiturients";
      this.listAbiturients.TabIndex = 8;
      // 
      // groupRating
      // 
      this.groupRating.Controls.Add(this.labelSpecialty);
      this.groupRating.Controls.Add(this.boxSpecialty);
      this.groupRating.Controls.Add(this.btnRating);
      this.groupRating.Controls.Add(this.btnAdmitted);
      this.groupRating.Controls.Add(this.labelInfo);
      this.groupRating.Controls.Add(this.listRating);
      this.groupRating.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupRating.Location = new System.Drawing.Point(503, 3);
      this.groupRating.Size = new System.Drawing.Size(574, 594);
      this.groupRating.Text = "Конкурсные списки";
      this.groupRating.TabStop = false;
      this.groupRating.Name = "groupRating";
      this.groupRating.TabIndex = 9;
      // 
      // labelSpecialty
      // 
      this.labelSpecialty.Location = new System.Drawing.Point(12, 25);
      this.labelSpecialty.Text = "Направление:";
      this.labelSpecialty.Name = "labelSpecialty";
      this.labelSpecialty.TabIndex = 10;
      this.labelSpecialty.AutoSize = true;
      // 
      // boxSpecialty
      // 
      this.boxSpecialty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.boxSpecialty.FormattingEnabled = true;
      this.boxSpecialty.Location = new System.Drawing.Point(95, 22);
      this.boxSpecialty.Size = new System.Drawing.Size(380, 21);
      this.boxSpecialty.Name = "boxSpecialty";
      this.boxSpecialty.TabIndex = 11;
      // 
      // btnRating
      // 
      this.btnRating.Location = new System.Drawing.Point(95, 52);
      this.btnRating.Size = new System.Drawing.Size(185, 25);
      this.btnRating.Text = "Конкурсный список";
      this.btnRating.Name = "btnRating";
      this.btnRating.TabIndex = 12;
      this.btnRating.UseVisualStyleBackColor = true;
      this.btnRating.Click += new System.EventHandler(this.btnRating_Click);
      // 
      // btnAdmitted
      // 
      this.btnAdmitted.Location = new System.Drawing.Point(290, 52);
      this.btnAdmitted.Size = new System.Drawing.Size(185, 25);
      this.btnAdmitted.Text = "Рекомендованные";
      this.btnAdmitted.Name = "btnAdmitted";
      this.btnAdmitted.TabIndex = 13;
      this.btnAdmitted.UseVisualStyleBackColor = true;
      this.btnAdmitted.Click += new System.EventHandler(this.btnAdmitted_Click);
      // 
      // labelInfo
      // 
      this.labelInfo.Location = new System.Drawing.Point(12, 85);
      this.labelInfo.Text = "-";
      this.labelInfo.Name = "labelInfo";
      this.labelInfo.TabIndex = 14;
      this.labelInfo.AutoSize = true;
      // 
      // listRating
      // 
      this.listRating.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
      this.listRating.FullRowSelect = true;
      this.listRating.GridLines = true;
      this.listRating.HideSelection = false;
      this.listRating.Location = new System.Drawing.Point(12, 135);
      this.listRating.MultiSelect = false;
      this.listRating.Size = new System.Drawing.Size(550, 445);
      this.listRating.UseCompatibleStateImageBehavior = false;
      this.listRating.View = System.Windows.Forms.View.Details;
      this.listRating.Name = "listRating";
      this.listRating.TabIndex = 15;
      // 
      // Task3Page
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.body);
      this.Name = "Task3Page";
      this.Size = new System.Drawing.Size(1080, 600);
      this.groupRating.ResumeLayout(false);
      this.groupRating.PerformLayout();
      this.groupAbiturients.ResumeLayout(false);
      this.groupAbiturients.PerformLayout();
      this.body.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
