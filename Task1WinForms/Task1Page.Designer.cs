namespace Task1WinForms {
  partial class Task1Page {
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.TableLayoutPanel body;
    private System.Windows.Forms.TabControl tabs;
    private System.Windows.Forms.TabPage pagePassport;
    private System.Windows.Forms.Label labelSurname;
    private System.Windows.Forms.TextBox boxSurname;
    private System.Windows.Forms.Label labelName;
    private System.Windows.Forms.TextBox boxName;
    private System.Windows.Forms.Label labelPatronymic;
    private System.Windows.Forms.TextBox boxPatronymic;
    private System.Windows.Forms.Label labelGender;
    private System.Windows.Forms.ComboBox boxGender;
    private System.Windows.Forms.Label labelBirth;
    private System.Windows.Forms.DateTimePicker pickBirth;
    private System.Windows.Forms.Label labelSeries;
    private System.Windows.Forms.TextBox boxSeries;
    private System.Windows.Forms.Label labelPassportNumber;
    private System.Windows.Forms.TextBox boxPassportNumber;
    private System.Windows.Forms.Label labelIssuedBy;
    private System.Windows.Forms.TextBox boxIssuedBy;
    private System.Windows.Forms.Label labelPassportIssue;
    private System.Windows.Forms.DateTimePicker pickPassportIssue;
    private System.Windows.Forms.Button btnSavePassport;
    private System.Windows.Forms.TabPage pageEducation;
    private System.Windows.Forms.Label labelLevel;
    private System.Windows.Forms.ComboBox boxLevel;
    private System.Windows.Forms.Label labelInstitution;
    private System.Windows.Forms.TextBox boxInstitution;
    private System.Windows.Forms.Label labelYear;
    private System.Windows.Forms.TextBox boxYear;
    private System.Windows.Forms.Label labelAverage;
    private System.Windows.Forms.TextBox boxAverage;
    private System.Windows.Forms.CheckBox checkHonors;
    private System.Windows.Forms.Label labelEducationNumber;
    private System.Windows.Forms.TextBox boxEducationNumber;
    private System.Windows.Forms.Label labelEducationIssue;
    private System.Windows.Forms.DateTimePicker pickEducationIssue;
    private System.Windows.Forms.Button btnSaveEducation;
    private System.Windows.Forms.TabPage pageExams;
    private System.Windows.Forms.Label labelExamsNumber;
    private System.Windows.Forms.TextBox boxExamsNumber;
    private System.Windows.Forms.Label labelExamsIssue;
    private System.Windows.Forms.DateTimePicker pickExamsIssue;
    private System.Windows.Forms.Label labelSubject;
    private System.Windows.Forms.ComboBox boxSubject;
    private System.Windows.Forms.Label labelScore;
    private System.Windows.Forms.TextBox boxScore;
    private System.Windows.Forms.Label labelExamYear;
    private System.Windows.Forms.TextBox boxExamYear;
    private System.Windows.Forms.Button btnAddExam;
    private System.Windows.Forms.ListBox listExams;
    private System.Windows.Forms.Button btnRemoveExam;
    private System.Windows.Forms.Button btnSaveExams;
    private System.Windows.Forms.TabPage pageApplication;
    private System.Windows.Forms.Label labelApplicationNumber;
    private System.Windows.Forms.TextBox boxApplicationNumber;
    private System.Windows.Forms.Label labelApplicationIssue;
    private System.Windows.Forms.DateTimePicker pickApplicationIssue;
    private System.Windows.Forms.Label labelCatalog;
    private System.Windows.Forms.ListBox listCatalog;
    private System.Windows.Forms.Button btnAddSpecialty;
    private System.Windows.Forms.Label labelChosen;
    private System.Windows.Forms.ListBox listChosen;
    private System.Windows.Forms.Button btnRemoveSpecialty;
    private System.Windows.Forms.Button btnSaveApplication;
    private System.Windows.Forms.GroupBox groupDocuments;
    private System.Windows.Forms.Button btnShow;
    private System.Windows.Forms.Button btnSample;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.TextBox boxDocuments;

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
      this.tabs = new System.Windows.Forms.TabControl();
      this.pagePassport = new System.Windows.Forms.TabPage();
      this.labelSurname = new System.Windows.Forms.Label();
      this.boxSurname = new System.Windows.Forms.TextBox();
      this.labelName = new System.Windows.Forms.Label();
      this.boxName = new System.Windows.Forms.TextBox();
      this.labelPatronymic = new System.Windows.Forms.Label();
      this.boxPatronymic = new System.Windows.Forms.TextBox();
      this.labelGender = new System.Windows.Forms.Label();
      this.boxGender = new System.Windows.Forms.ComboBox();
      this.labelBirth = new System.Windows.Forms.Label();
      this.pickBirth = new System.Windows.Forms.DateTimePicker();
      this.labelSeries = new System.Windows.Forms.Label();
      this.boxSeries = new System.Windows.Forms.TextBox();
      this.labelPassportNumber = new System.Windows.Forms.Label();
      this.boxPassportNumber = new System.Windows.Forms.TextBox();
      this.labelIssuedBy = new System.Windows.Forms.Label();
      this.boxIssuedBy = new System.Windows.Forms.TextBox();
      this.labelPassportIssue = new System.Windows.Forms.Label();
      this.pickPassportIssue = new System.Windows.Forms.DateTimePicker();
      this.btnSavePassport = new System.Windows.Forms.Button();
      this.pageEducation = new System.Windows.Forms.TabPage();
      this.labelLevel = new System.Windows.Forms.Label();
      this.boxLevel = new System.Windows.Forms.ComboBox();
      this.labelInstitution = new System.Windows.Forms.Label();
      this.boxInstitution = new System.Windows.Forms.TextBox();
      this.labelYear = new System.Windows.Forms.Label();
      this.boxYear = new System.Windows.Forms.TextBox();
      this.labelAverage = new System.Windows.Forms.Label();
      this.boxAverage = new System.Windows.Forms.TextBox();
      this.checkHonors = new System.Windows.Forms.CheckBox();
      this.labelEducationNumber = new System.Windows.Forms.Label();
      this.boxEducationNumber = new System.Windows.Forms.TextBox();
      this.labelEducationIssue = new System.Windows.Forms.Label();
      this.pickEducationIssue = new System.Windows.Forms.DateTimePicker();
      this.btnSaveEducation = new System.Windows.Forms.Button();
      this.pageExams = new System.Windows.Forms.TabPage();
      this.labelExamsNumber = new System.Windows.Forms.Label();
      this.boxExamsNumber = new System.Windows.Forms.TextBox();
      this.labelExamsIssue = new System.Windows.Forms.Label();
      this.pickExamsIssue = new System.Windows.Forms.DateTimePicker();
      this.labelSubject = new System.Windows.Forms.Label();
      this.boxSubject = new System.Windows.Forms.ComboBox();
      this.labelScore = new System.Windows.Forms.Label();
      this.boxScore = new System.Windows.Forms.TextBox();
      this.labelExamYear = new System.Windows.Forms.Label();
      this.boxExamYear = new System.Windows.Forms.TextBox();
      this.btnAddExam = new System.Windows.Forms.Button();
      this.listExams = new System.Windows.Forms.ListBox();
      this.btnRemoveExam = new System.Windows.Forms.Button();
      this.btnSaveExams = new System.Windows.Forms.Button();
      this.pageApplication = new System.Windows.Forms.TabPage();
      this.labelApplicationNumber = new System.Windows.Forms.Label();
      this.boxApplicationNumber = new System.Windows.Forms.TextBox();
      this.labelApplicationIssue = new System.Windows.Forms.Label();
      this.pickApplicationIssue = new System.Windows.Forms.DateTimePicker();
      this.labelCatalog = new System.Windows.Forms.Label();
      this.listCatalog = new System.Windows.Forms.ListBox();
      this.btnAddSpecialty = new System.Windows.Forms.Button();
      this.labelChosen = new System.Windows.Forms.Label();
      this.listChosen = new System.Windows.Forms.ListBox();
      this.btnRemoveSpecialty = new System.Windows.Forms.Button();
      this.btnSaveApplication = new System.Windows.Forms.Button();
      this.groupDocuments = new System.Windows.Forms.GroupBox();
      this.btnShow = new System.Windows.Forms.Button();
      this.btnSample = new System.Windows.Forms.Button();
      this.btnClear = new System.Windows.Forms.Button();
      this.boxDocuments = new System.Windows.Forms.TextBox();
      this.body.SuspendLayout();
      this.tabs.SuspendLayout();
      this.pagePassport.SuspendLayout();
      this.pageEducation.SuspendLayout();
      this.pageExams.SuspendLayout();
      this.pageApplication.SuspendLayout();
      this.groupDocuments.SuspendLayout();
      this.SuspendLayout();
      // 
      // body
      // 
      this.body.Controls.Add(this.tabs, 0, 0);
      this.body.Controls.Add(this.groupDocuments, 1, 0);
      this.body.ColumnCount = 2;
      this.body.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 460F));
      this.body.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.body.Dock = System.Windows.Forms.DockStyle.Fill;
      this.body.Location = new System.Drawing.Point(0, 0);
      this.body.RowCount = 1;
      this.body.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.body.Size = new System.Drawing.Size(1080, 600);
      this.body.Name = "body";
      this.body.TabIndex = 0;
      // 
      // tabs
      // 
      this.tabs.Controls.Add(this.pagePassport);
      this.tabs.Controls.Add(this.pageEducation);
      this.tabs.Controls.Add(this.pageExams);
      this.tabs.Controls.Add(this.pageApplication);
      this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabs.Location = new System.Drawing.Point(3, 3);
      this.tabs.Size = new System.Drawing.Size(454, 594);
      this.tabs.SelectedIndex = 0;
      this.tabs.Name = "tabs";
      this.tabs.TabIndex = 1;
      // 
      // pagePassport
      // 
      this.pagePassport.Controls.Add(this.labelSurname);
      this.pagePassport.Controls.Add(this.boxSurname);
      this.pagePassport.Controls.Add(this.labelName);
      this.pagePassport.Controls.Add(this.boxName);
      this.pagePassport.Controls.Add(this.labelPatronymic);
      this.pagePassport.Controls.Add(this.boxPatronymic);
      this.pagePassport.Controls.Add(this.labelGender);
      this.pagePassport.Controls.Add(this.boxGender);
      this.pagePassport.Controls.Add(this.labelBirth);
      this.pagePassport.Controls.Add(this.pickBirth);
      this.pagePassport.Controls.Add(this.labelSeries);
      this.pagePassport.Controls.Add(this.boxSeries);
      this.pagePassport.Controls.Add(this.labelPassportNumber);
      this.pagePassport.Controls.Add(this.boxPassportNumber);
      this.pagePassport.Controls.Add(this.labelIssuedBy);
      this.pagePassport.Controls.Add(this.boxIssuedBy);
      this.pagePassport.Controls.Add(this.labelPassportIssue);
      this.pagePassport.Controls.Add(this.pickPassportIssue);
      this.pagePassport.Controls.Add(this.btnSavePassport);
      this.pagePassport.Location = new System.Drawing.Point(4, 22);
      this.pagePassport.Padding = new System.Windows.Forms.Padding(3);
      this.pagePassport.Size = new System.Drawing.Size(442, 560);
      this.pagePassport.Text = "Паспорт";
      this.pagePassport.UseVisualStyleBackColor = true;
      this.pagePassport.AutoScroll = true;
      this.pagePassport.Name = "pagePassport";
      // 
      // labelSurname
      // 
      this.labelSurname.Location = new System.Drawing.Point(12, 18);
      this.labelSurname.Text = "Фамилия:";
      this.labelSurname.Name = "labelSurname";
      this.labelSurname.TabIndex = 3;
      this.labelSurname.AutoSize = true;
      // 
      // boxSurname
      // 
      this.boxSurname.Location = new System.Drawing.Point(140, 15);
      this.boxSurname.Size = new System.Drawing.Size(240, 20);
      this.boxSurname.Name = "boxSurname";
      this.boxSurname.TabIndex = 4;
      // 
      // labelName
      // 
      this.labelName.Location = new System.Drawing.Point(12, 50);
      this.labelName.Text = "Имя:";
      this.labelName.Name = "labelName";
      this.labelName.TabIndex = 5;
      this.labelName.AutoSize = true;
      // 
      // boxName
      // 
      this.boxName.Location = new System.Drawing.Point(140, 47);
      this.boxName.Size = new System.Drawing.Size(240, 20);
      this.boxName.Name = "boxName";
      this.boxName.TabIndex = 6;
      // 
      // labelPatronymic
      // 
      this.labelPatronymic.Location = new System.Drawing.Point(12, 82);
      this.labelPatronymic.Text = "Отчество:";
      this.labelPatronymic.Name = "labelPatronymic";
      this.labelPatronymic.TabIndex = 7;
      this.labelPatronymic.AutoSize = true;
      // 
      // boxPatronymic
      // 
      this.boxPatronymic.Location = new System.Drawing.Point(140, 79);
      this.boxPatronymic.Size = new System.Drawing.Size(240, 20);
      this.boxPatronymic.Name = "boxPatronymic";
      this.boxPatronymic.TabIndex = 8;
      // 
      // labelGender
      // 
      this.labelGender.Location = new System.Drawing.Point(12, 114);
      this.labelGender.Text = "Пол:";
      this.labelGender.Name = "labelGender";
      this.labelGender.TabIndex = 9;
      this.labelGender.AutoSize = true;
      // 
      // boxGender
      // 
      this.boxGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.boxGender.FormattingEnabled = true;
      this.boxGender.Location = new System.Drawing.Point(140, 111);
      this.boxGender.Size = new System.Drawing.Size(240, 21);
      this.boxGender.Name = "boxGender";
      this.boxGender.TabIndex = 10;
      // 
      // labelBirth
      // 
      this.labelBirth.Location = new System.Drawing.Point(12, 146);
      this.labelBirth.Text = "Дата рождения:";
      this.labelBirth.Name = "labelBirth";
      this.labelBirth.TabIndex = 11;
      this.labelBirth.AutoSize = true;
      // 
      // pickBirth
      // 
      this.pickBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.pickBirth.Location = new System.Drawing.Point(140, 143);
      this.pickBirth.Size = new System.Drawing.Size(240, 20);
      this.pickBirth.Name = "pickBirth";
      this.pickBirth.TabIndex = 12;
      // 
      // labelSeries
      // 
      this.labelSeries.Location = new System.Drawing.Point(12, 178);
      this.labelSeries.Text = "Серия:";
      this.labelSeries.Name = "labelSeries";
      this.labelSeries.TabIndex = 13;
      this.labelSeries.AutoSize = true;
      // 
      // boxSeries
      // 
      this.boxSeries.Location = new System.Drawing.Point(140, 175);
      this.boxSeries.Size = new System.Drawing.Size(240, 20);
      this.boxSeries.Name = "boxSeries";
      this.boxSeries.TabIndex = 14;
      // 
      // labelPassportNumber
      // 
      this.labelPassportNumber.Location = new System.Drawing.Point(12, 210);
      this.labelPassportNumber.Text = "Номер:";
      this.labelPassportNumber.Name = "labelPassportNumber";
      this.labelPassportNumber.TabIndex = 15;
      this.labelPassportNumber.AutoSize = true;
      // 
      // boxPassportNumber
      // 
      this.boxPassportNumber.Location = new System.Drawing.Point(140, 207);
      this.boxPassportNumber.Size = new System.Drawing.Size(240, 20);
      this.boxPassportNumber.Name = "boxPassportNumber";
      this.boxPassportNumber.TabIndex = 16;
      // 
      // labelIssuedBy
      // 
      this.labelIssuedBy.Location = new System.Drawing.Point(12, 242);
      this.labelIssuedBy.Text = "Кем выдан:";
      this.labelIssuedBy.Name = "labelIssuedBy";
      this.labelIssuedBy.TabIndex = 17;
      this.labelIssuedBy.AutoSize = true;
      // 
      // boxIssuedBy
      // 
      this.boxIssuedBy.Location = new System.Drawing.Point(140, 239);
      this.boxIssuedBy.Size = new System.Drawing.Size(240, 20);
      this.boxIssuedBy.Name = "boxIssuedBy";
      this.boxIssuedBy.TabIndex = 18;
      // 
      // labelPassportIssue
      // 
      this.labelPassportIssue.Location = new System.Drawing.Point(12, 274);
      this.labelPassportIssue.Text = "Дата выдачи:";
      this.labelPassportIssue.Name = "labelPassportIssue";
      this.labelPassportIssue.TabIndex = 19;
      this.labelPassportIssue.AutoSize = true;
      // 
      // pickPassportIssue
      // 
      this.pickPassportIssue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.pickPassportIssue.Location = new System.Drawing.Point(140, 271);
      this.pickPassportIssue.Size = new System.Drawing.Size(240, 20);
      this.pickPassportIssue.Name = "pickPassportIssue";
      this.pickPassportIssue.TabIndex = 20;
      // 
      // btnSavePassport
      // 
      this.btnSavePassport.Location = new System.Drawing.Point(140, 308);
      this.btnSavePassport.Size = new System.Drawing.Size(240, 28);
      this.btnSavePassport.Text = "Сохранить паспорт";
      this.btnSavePassport.Name = "btnSavePassport";
      this.btnSavePassport.TabIndex = 21;
      this.btnSavePassport.UseVisualStyleBackColor = true;
      this.btnSavePassport.Click += new System.EventHandler(this.btnSavePassport_Click);
      // 
      // pageEducation
      // 
      this.pageEducation.Controls.Add(this.labelLevel);
      this.pageEducation.Controls.Add(this.boxLevel);
      this.pageEducation.Controls.Add(this.labelInstitution);
      this.pageEducation.Controls.Add(this.boxInstitution);
      this.pageEducation.Controls.Add(this.labelYear);
      this.pageEducation.Controls.Add(this.boxYear);
      this.pageEducation.Controls.Add(this.labelAverage);
      this.pageEducation.Controls.Add(this.boxAverage);
      this.pageEducation.Controls.Add(this.checkHonors);
      this.pageEducation.Controls.Add(this.labelEducationNumber);
      this.pageEducation.Controls.Add(this.boxEducationNumber);
      this.pageEducation.Controls.Add(this.labelEducationIssue);
      this.pageEducation.Controls.Add(this.pickEducationIssue);
      this.pageEducation.Controls.Add(this.btnSaveEducation);
      this.pageEducation.Location = new System.Drawing.Point(4, 22);
      this.pageEducation.Padding = new System.Windows.Forms.Padding(3);
      this.pageEducation.Size = new System.Drawing.Size(442, 560);
      this.pageEducation.Text = "Образование";
      this.pageEducation.UseVisualStyleBackColor = true;
      this.pageEducation.AutoScroll = true;
      this.pageEducation.Name = "pageEducation";
      // 
      // labelLevel
      // 
      this.labelLevel.Location = new System.Drawing.Point(12, 18);
      this.labelLevel.Text = "Уровень:";
      this.labelLevel.Name = "labelLevel";
      this.labelLevel.TabIndex = 23;
      this.labelLevel.AutoSize = true;
      // 
      // boxLevel
      // 
      this.boxLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.boxLevel.FormattingEnabled = true;
      this.boxLevel.Location = new System.Drawing.Point(140, 15);
      this.boxLevel.Size = new System.Drawing.Size(240, 21);
      this.boxLevel.Name = "boxLevel";
      this.boxLevel.TabIndex = 24;
      // 
      // labelInstitution
      // 
      this.labelInstitution.Location = new System.Drawing.Point(12, 50);
      this.labelInstitution.Text = "Учебное заведение:";
      this.labelInstitution.Name = "labelInstitution";
      this.labelInstitution.TabIndex = 25;
      this.labelInstitution.AutoSize = true;
      // 
      // boxInstitution
      // 
      this.boxInstitution.Location = new System.Drawing.Point(140, 47);
      this.boxInstitution.Size = new System.Drawing.Size(240, 20);
      this.boxInstitution.Name = "boxInstitution";
      this.boxInstitution.TabIndex = 26;
      // 
      // labelYear
      // 
      this.labelYear.Location = new System.Drawing.Point(12, 82);
      this.labelYear.Text = "Год окончания:";
      this.labelYear.Name = "labelYear";
      this.labelYear.TabIndex = 27;
      this.labelYear.AutoSize = true;
      // 
      // boxYear
      // 
      this.boxYear.Location = new System.Drawing.Point(140, 79);
      this.boxYear.Size = new System.Drawing.Size(240, 20);
      this.boxYear.Name = "boxYear";
      this.boxYear.TabIndex = 28;
      // 
      // labelAverage
      // 
      this.labelAverage.Location = new System.Drawing.Point(12, 114);
      this.labelAverage.Text = "Средний балл:";
      this.labelAverage.Name = "labelAverage";
      this.labelAverage.TabIndex = 29;
      this.labelAverage.AutoSize = true;
      // 
      // boxAverage
      // 
      this.boxAverage.Location = new System.Drawing.Point(140, 111);
      this.boxAverage.Size = new System.Drawing.Size(240, 20);
      this.boxAverage.Name = "boxAverage";
      this.boxAverage.TabIndex = 30;
      // 
      // checkHonors
      // 
      this.checkHonors.AutoSize = true;
      this.checkHonors.Location = new System.Drawing.Point(140, 143);
      this.checkHonors.Text = "Документ с отличием";
      this.checkHonors.Name = "checkHonors";
      this.checkHonors.TabIndex = 31;
      this.checkHonors.UseVisualStyleBackColor = true;
      // 
      // labelEducationNumber
      // 
      this.labelEducationNumber.Location = new System.Drawing.Point(12, 178);
      this.labelEducationNumber.Text = "Номер документа:";
      this.labelEducationNumber.Name = "labelEducationNumber";
      this.labelEducationNumber.TabIndex = 32;
      this.labelEducationNumber.AutoSize = true;
      // 
      // boxEducationNumber
      // 
      this.boxEducationNumber.Location = new System.Drawing.Point(140, 175);
      this.boxEducationNumber.Size = new System.Drawing.Size(240, 20);
      this.boxEducationNumber.Name = "boxEducationNumber";
      this.boxEducationNumber.TabIndex = 33;
      // 
      // labelEducationIssue
      // 
      this.labelEducationIssue.Location = new System.Drawing.Point(12, 210);
      this.labelEducationIssue.Text = "Дата выдачи:";
      this.labelEducationIssue.Name = "labelEducationIssue";
      this.labelEducationIssue.TabIndex = 34;
      this.labelEducationIssue.AutoSize = true;
      // 
      // pickEducationIssue
      // 
      this.pickEducationIssue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.pickEducationIssue.Location = new System.Drawing.Point(140, 207);
      this.pickEducationIssue.Size = new System.Drawing.Size(240, 20);
      this.pickEducationIssue.Name = "pickEducationIssue";
      this.pickEducationIssue.TabIndex = 35;
      // 
      // btnSaveEducation
      // 
      this.btnSaveEducation.Location = new System.Drawing.Point(140, 244);
      this.btnSaveEducation.Size = new System.Drawing.Size(240, 28);
      this.btnSaveEducation.Text = "Сохранить документ";
      this.btnSaveEducation.Name = "btnSaveEducation";
      this.btnSaveEducation.TabIndex = 36;
      this.btnSaveEducation.UseVisualStyleBackColor = true;
      this.btnSaveEducation.Click += new System.EventHandler(this.btnSaveEducation_Click);
      // 
      // pageExams
      // 
      this.pageExams.Controls.Add(this.labelExamsNumber);
      this.pageExams.Controls.Add(this.boxExamsNumber);
      this.pageExams.Controls.Add(this.labelExamsIssue);
      this.pageExams.Controls.Add(this.pickExamsIssue);
      this.pageExams.Controls.Add(this.labelSubject);
      this.pageExams.Controls.Add(this.boxSubject);
      this.pageExams.Controls.Add(this.labelScore);
      this.pageExams.Controls.Add(this.boxScore);
      this.pageExams.Controls.Add(this.labelExamYear);
      this.pageExams.Controls.Add(this.boxExamYear);
      this.pageExams.Controls.Add(this.btnAddExam);
      this.pageExams.Controls.Add(this.listExams);
      this.pageExams.Controls.Add(this.btnRemoveExam);
      this.pageExams.Controls.Add(this.btnSaveExams);
      this.pageExams.Location = new System.Drawing.Point(4, 22);
      this.pageExams.Padding = new System.Windows.Forms.Padding(3);
      this.pageExams.Size = new System.Drawing.Size(442, 560);
      this.pageExams.Text = "ЕГЭ";
      this.pageExams.UseVisualStyleBackColor = true;
      this.pageExams.AutoScroll = true;
      this.pageExams.Name = "pageExams";
      // 
      // labelExamsNumber
      // 
      this.labelExamsNumber.Location = new System.Drawing.Point(12, 18);
      this.labelExamsNumber.Text = "Номер документа:";
      this.labelExamsNumber.Name = "labelExamsNumber";
      this.labelExamsNumber.TabIndex = 38;
      this.labelExamsNumber.AutoSize = true;
      // 
      // boxExamsNumber
      // 
      this.boxExamsNumber.Location = new System.Drawing.Point(140, 15);
      this.boxExamsNumber.Size = new System.Drawing.Size(240, 20);
      this.boxExamsNumber.Name = "boxExamsNumber";
      this.boxExamsNumber.TabIndex = 39;
      // 
      // labelExamsIssue
      // 
      this.labelExamsIssue.Location = new System.Drawing.Point(12, 50);
      this.labelExamsIssue.Text = "Дата выдачи:";
      this.labelExamsIssue.Name = "labelExamsIssue";
      this.labelExamsIssue.TabIndex = 40;
      this.labelExamsIssue.AutoSize = true;
      // 
      // pickExamsIssue
      // 
      this.pickExamsIssue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.pickExamsIssue.Location = new System.Drawing.Point(140, 47);
      this.pickExamsIssue.Size = new System.Drawing.Size(240, 20);
      this.pickExamsIssue.Name = "pickExamsIssue";
      this.pickExamsIssue.TabIndex = 41;
      // 
      // labelSubject
      // 
      this.labelSubject.Location = new System.Drawing.Point(12, 82);
      this.labelSubject.Text = "Предмет:";
      this.labelSubject.Name = "labelSubject";
      this.labelSubject.TabIndex = 42;
      this.labelSubject.AutoSize = true;
      // 
      // boxSubject
      // 
      this.boxSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.boxSubject.FormattingEnabled = true;
      this.boxSubject.Location = new System.Drawing.Point(140, 79);
      this.boxSubject.Size = new System.Drawing.Size(240, 21);
      this.boxSubject.Name = "boxSubject";
      this.boxSubject.TabIndex = 43;
      // 
      // labelScore
      // 
      this.labelScore.Location = new System.Drawing.Point(12, 114);
      this.labelScore.Text = "Балл:";
      this.labelScore.Name = "labelScore";
      this.labelScore.TabIndex = 44;
      this.labelScore.AutoSize = true;
      // 
      // boxScore
      // 
      this.boxScore.Location = new System.Drawing.Point(140, 111);
      this.boxScore.Size = new System.Drawing.Size(80, 20);
      this.boxScore.Name = "boxScore";
      this.boxScore.TabIndex = 45;
      // 
      // labelExamYear
      // 
      this.labelExamYear.Location = new System.Drawing.Point(230, 114);
      this.labelExamYear.Text = "Год сдачи:";
      this.labelExamYear.Name = "labelExamYear";
      this.labelExamYear.TabIndex = 46;
      this.labelExamYear.AutoSize = true;
      // 
      // boxExamYear
      // 
      this.boxExamYear.Location = new System.Drawing.Point(300, 111);
      this.boxExamYear.Size = new System.Drawing.Size(80, 20);
      this.boxExamYear.Name = "boxExamYear";
      this.boxExamYear.TabIndex = 47;
      // 
      // btnAddExam
      // 
      this.btnAddExam.Location = new System.Drawing.Point(140, 143);
      this.btnAddExam.Size = new System.Drawing.Size(240, 25);
      this.btnAddExam.Text = "Добавить экзамен";
      this.btnAddExam.Name = "btnAddExam";
      this.btnAddExam.TabIndex = 48;
      this.btnAddExam.UseVisualStyleBackColor = true;
      this.btnAddExam.Click += new System.EventHandler(this.btnAddExam_Click);
      // 
      // listExams
      // 
      this.listExams.FormattingEnabled = true;
      this.listExams.Location = new System.Drawing.Point(140, 175);
      this.listExams.Size = new System.Drawing.Size(240, 108);
      this.listExams.Name = "listExams";
      this.listExams.TabIndex = 49;
      // 
      // btnRemoveExam
      // 
      this.btnRemoveExam.Location = new System.Drawing.Point(140, 290);
      this.btnRemoveExam.Size = new System.Drawing.Size(240, 25);
      this.btnRemoveExam.Text = "Удалить выбранный";
      this.btnRemoveExam.Name = "btnRemoveExam";
      this.btnRemoveExam.TabIndex = 50;
      this.btnRemoveExam.UseVisualStyleBackColor = true;
      this.btnRemoveExam.Click += new System.EventHandler(this.btnRemoveExam_Click);
      // 
      // btnSaveExams
      // 
      this.btnSaveExams.Location = new System.Drawing.Point(140, 325);
      this.btnSaveExams.Size = new System.Drawing.Size(240, 28);
      this.btnSaveExams.Text = "Сохранить результаты";
      this.btnSaveExams.Name = "btnSaveExams";
      this.btnSaveExams.TabIndex = 51;
      this.btnSaveExams.UseVisualStyleBackColor = true;
      this.btnSaveExams.Click += new System.EventHandler(this.btnSaveExams_Click);
      // 
      // pageApplication
      // 
      this.pageApplication.Controls.Add(this.labelApplicationNumber);
      this.pageApplication.Controls.Add(this.boxApplicationNumber);
      this.pageApplication.Controls.Add(this.labelApplicationIssue);
      this.pageApplication.Controls.Add(this.pickApplicationIssue);
      this.pageApplication.Controls.Add(this.labelCatalog);
      this.pageApplication.Controls.Add(this.listCatalog);
      this.pageApplication.Controls.Add(this.btnAddSpecialty);
      this.pageApplication.Controls.Add(this.labelChosen);
      this.pageApplication.Controls.Add(this.listChosen);
      this.pageApplication.Controls.Add(this.btnRemoveSpecialty);
      this.pageApplication.Controls.Add(this.btnSaveApplication);
      this.pageApplication.Location = new System.Drawing.Point(4, 22);
      this.pageApplication.Padding = new System.Windows.Forms.Padding(3);
      this.pageApplication.Size = new System.Drawing.Size(442, 560);
      this.pageApplication.Text = "Заявление";
      this.pageApplication.UseVisualStyleBackColor = true;
      this.pageApplication.AutoScroll = true;
      this.pageApplication.Name = "pageApplication";
      // 
      // labelApplicationNumber
      // 
      this.labelApplicationNumber.Location = new System.Drawing.Point(12, 18);
      this.labelApplicationNumber.Text = "Номер заявления:";
      this.labelApplicationNumber.Name = "labelApplicationNumber";
      this.labelApplicationNumber.TabIndex = 53;
      this.labelApplicationNumber.AutoSize = true;
      // 
      // boxApplicationNumber
      // 
      this.boxApplicationNumber.Location = new System.Drawing.Point(140, 15);
      this.boxApplicationNumber.Size = new System.Drawing.Size(240, 20);
      this.boxApplicationNumber.Name = "boxApplicationNumber";
      this.boxApplicationNumber.TabIndex = 54;
      // 
      // labelApplicationIssue
      // 
      this.labelApplicationIssue.Location = new System.Drawing.Point(12, 50);
      this.labelApplicationIssue.Text = "Дата подачи:";
      this.labelApplicationIssue.Name = "labelApplicationIssue";
      this.labelApplicationIssue.TabIndex = 55;
      this.labelApplicationIssue.AutoSize = true;
      // 
      // pickApplicationIssue
      // 
      this.pickApplicationIssue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.pickApplicationIssue.Location = new System.Drawing.Point(140, 47);
      this.pickApplicationIssue.Size = new System.Drawing.Size(240, 20);
      this.pickApplicationIssue.Name = "pickApplicationIssue";
      this.pickApplicationIssue.TabIndex = 56;
      // 
      // labelCatalog
      // 
      this.labelCatalog.Location = new System.Drawing.Point(12, 82);
      this.labelCatalog.Text = "Направления подготовки:";
      this.labelCatalog.Name = "labelCatalog";
      this.labelCatalog.TabIndex = 57;
      this.labelCatalog.AutoSize = true;
      // 
      // listCatalog
      // 
      this.listCatalog.FormattingEnabled = true;
      this.listCatalog.Location = new System.Drawing.Point(12, 101);
      this.listCatalog.Size = new System.Drawing.Size(410, 82);
      this.listCatalog.Name = "listCatalog";
      this.listCatalog.TabIndex = 58;
      // 
      // btnAddSpecialty
      // 
      this.btnAddSpecialty.Location = new System.Drawing.Point(12, 189);
      this.btnAddSpecialty.Size = new System.Drawing.Size(410, 25);
      this.btnAddSpecialty.Text = "Добавить в заявление";
      this.btnAddSpecialty.Name = "btnAddSpecialty";
      this.btnAddSpecialty.TabIndex = 59;
      this.btnAddSpecialty.UseVisualStyleBackColor = true;
      this.btnAddSpecialty.Click += new System.EventHandler(this.btnAddSpecialty_Click);
      // 
      // labelChosen
      // 
      this.labelChosen.Location = new System.Drawing.Point(12, 227);
      this.labelChosen.Text = "Выбранные направления (по приоритету):";
      this.labelChosen.Name = "labelChosen";
      this.labelChosen.TabIndex = 60;
      this.labelChosen.AutoSize = true;
      // 
      // listChosen
      // 
      this.listChosen.FormattingEnabled = true;
      this.listChosen.Location = new System.Drawing.Point(12, 246);
      this.listChosen.Size = new System.Drawing.Size(410, 56);
      this.listChosen.Name = "listChosen";
      this.listChosen.TabIndex = 61;
      // 
      // btnRemoveSpecialty
      // 
      this.btnRemoveSpecialty.Location = new System.Drawing.Point(12, 309);
      this.btnRemoveSpecialty.Size = new System.Drawing.Size(410, 25);
      this.btnRemoveSpecialty.Text = "Убрать выбранное";
      this.btnRemoveSpecialty.Name = "btnRemoveSpecialty";
      this.btnRemoveSpecialty.TabIndex = 62;
      this.btnRemoveSpecialty.UseVisualStyleBackColor = true;
      this.btnRemoveSpecialty.Click += new System.EventHandler(this.btnRemoveSpecialty_Click);
      // 
      // btnSaveApplication
      // 
      this.btnSaveApplication.Location = new System.Drawing.Point(12, 344);
      this.btnSaveApplication.Size = new System.Drawing.Size(410, 28);
      this.btnSaveApplication.Text = "Сохранить заявление";
      this.btnSaveApplication.Name = "btnSaveApplication";
      this.btnSaveApplication.TabIndex = 63;
      this.btnSaveApplication.UseVisualStyleBackColor = true;
      this.btnSaveApplication.Click += new System.EventHandler(this.btnSaveApplication_Click);
      // 
      // groupDocuments
      // 
      this.groupDocuments.Controls.Add(this.btnShow);
      this.groupDocuments.Controls.Add(this.btnSample);
      this.groupDocuments.Controls.Add(this.btnClear);
      this.groupDocuments.Controls.Add(this.boxDocuments);
      this.groupDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupDocuments.Location = new System.Drawing.Point(463, 3);
      this.groupDocuments.Size = new System.Drawing.Size(614, 594);
      this.groupDocuments.Text = "Документы абитуриента";
      this.groupDocuments.TabStop = false;
      this.groupDocuments.Name = "groupDocuments";
      this.groupDocuments.TabIndex = 64;
      // 
      // btnShow
      // 
      this.btnShow.Location = new System.Drawing.Point(10, 20);
      this.btnShow.Size = new System.Drawing.Size(150, 25);
      this.btnShow.Text = "Показать документы";
      this.btnShow.Name = "btnShow";
      this.btnShow.TabIndex = 65;
      this.btnShow.UseVisualStyleBackColor = true;
      this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
      // 
      // btnSample
      // 
      this.btnSample.Location = new System.Drawing.Point(170, 20);
      this.btnSample.Size = new System.Drawing.Size(150, 25);
      this.btnSample.Text = "Заполнить примером";
      this.btnSample.Name = "btnSample";
      this.btnSample.TabIndex = 66;
      this.btnSample.UseVisualStyleBackColor = true;
      this.btnSample.Click += new System.EventHandler(this.btnSample_Click);
      // 
      // btnClear
      // 
      this.btnClear.Location = new System.Drawing.Point(330, 20);
      this.btnClear.Size = new System.Drawing.Size(150, 25);
      this.btnClear.Text = "Новый абитуриент";
      this.btnClear.Name = "btnClear";
      this.btnClear.TabIndex = 67;
      this.btnClear.UseVisualStyleBackColor = true;
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // boxDocuments
      // 
      this.boxDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
      this.boxDocuments.Font = new System.Drawing.Font("Consolas", 9F);
      this.boxDocuments.Location = new System.Drawing.Point(10, 55);
      this.boxDocuments.Multiline = true;
      this.boxDocuments.Size = new System.Drawing.Size(594, 528);
      this.boxDocuments.ReadOnly = true;
      this.boxDocuments.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.boxDocuments.WordWrap = false;
      this.boxDocuments.Name = "boxDocuments";
      this.boxDocuments.TabIndex = 68;
      // 
      // Task1Page
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.body);
      this.Name = "Task1Page";
      this.Size = new System.Drawing.Size(1080, 600);
      this.groupDocuments.ResumeLayout(false);
      this.groupDocuments.PerformLayout();
      this.pageApplication.ResumeLayout(false);
      this.pageApplication.PerformLayout();
      this.pageExams.ResumeLayout(false);
      this.pageExams.PerformLayout();
      this.pageEducation.ResumeLayout(false);
      this.pageEducation.PerformLayout();
      this.pagePassport.ResumeLayout(false);
      this.pagePassport.PerformLayout();
      this.tabs.ResumeLayout(false);
      this.body.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
