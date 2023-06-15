namespace ZendeskUtility
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            repairPartsSelector = new CheckedListBox();
            ZDTicketLabel = new Label();
            ZDTicketTextBox = new TextBox();
            AppTitleLabel = new Label();
            ZDTicketSearchButton = new Button();
            TicketSubjectLabel = new Label();
            TicketSubjectTextBox = new TextBox();
            TabControl = new TabControl();
            DiagTabPage = new TabPage();
            DiagSubmitButton = new Button();
            Diag_NotesTextBox = new RichTextBox();
            Diag_TechNotesLabel = new Label();
            Diag_PartsTextBox = new TextBox();
            Diag_PartsNeededLabel = new Label();
            Diag_TechDiagnosisTextBox = new TextBox();
            Diag_UpdateTextLabel = new Label();
            repairTabPage = new TabPage();
            repairSubmitButton = new Button();
            repairNotes = new RichTextBox();
            repairNotesLabel = new Label();
            repairOtherPartsTextBox = new TextBox();
            repairOtherPartLabel = new Label();
            repairLabel = new Label();
            CloseTabPage = new TabPage();
            Close_LimitToggle = new CheckBox();
            Close_ShipperOutput = new RichTextBox();
            Close_SubmitButton = new Button();
            Close_DeleteItemButton = new Button();
            Close_ClearListButton = new Button();
            Close_AddButton = new Button();
            InputTicketTextBox = new TextBox();
            Close_TicketDisplayListBox = new ListBox();
            tabPage1 = new TabPage();
            Update_RemoveAttachButton = new Button();
            Update_AttachmentList = new ListBox();
            Update_AddAttachButton = new Button();
            Update_SubmitButton = new Button();
            Update_AttachmentsLabel = new Label();
            Update_InternalToggleButton = new CheckBox();
            Update_PublicToggleButton = new CheckBox();
            Update_NoteTextBox = new RichTextBox();
            Update_NoteTextLabel = new Label();
            InitialsTextBox = new TextBox();
            InitialsLabel = new Label();
            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            progressBar = new ToolStripProgressBar();
            TabControl.SuspendLayout();
            DiagTabPage.SuspendLayout();
            repairTabPage.SuspendLayout();
            CloseTabPage.SuspendLayout();
            tabPage1.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // repairPartsSelector
            // 
            repairPartsSelector.CheckOnClick = true;
            repairPartsSelector.FormattingEnabled = true;
            repairPartsSelector.Items.AddRange(new object[] { "Motherboard", "LCD / Screen", "Battery", "Bezel", "Camera", "Palm Rest / KB", "Bottom Cover", "LCD Cover", "Hinges", "LCD Cable", "Sub-Board", "Speakers" });
            repairPartsSelector.Location = new Point(6, 36);
            repairPartsSelector.MultiColumn = true;
            repairPartsSelector.Name = "repairPartsSelector";
            repairPartsSelector.Size = new Size(282, 112);
            repairPartsSelector.TabIndex = 0;
            // 
            // ZDTicketLabel
            // 
            ZDTicketLabel.AutoSize = true;
            ZDTicketLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ZDTicketLabel.Location = new Point(12, 65);
            ZDTicketLabel.Name = "ZDTicketLabel";
            ZDTicketLabel.Size = new Size(66, 21);
            ZDTicketLabel.TabIndex = 0;
            ZDTicketLabel.Text = "Ticket #:";
            // 
            // ZDTicketTextBox
            // 
            ZDTicketTextBox.Location = new Point(84, 63);
            ZDTicketTextBox.Name = "ZDTicketTextBox";
            ZDTicketTextBox.Size = new Size(47, 23);
            ZDTicketTextBox.TabIndex = 1;
            ZDTicketTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // AppTitleLabel
            // 
            AppTitleLabel.AutoSize = true;
            AppTitleLabel.BackColor = SystemColors.Control;
            AppTitleLabel.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            AppTitleLabel.Location = new Point(16, 9);
            AppTitleLabel.Name = "AppTitleLabel";
            AppTitleLabel.Size = new Size(288, 40);
            AppTitleLabel.TabIndex = 2;
            AppTitleLabel.Text = "Zendesk Ticket Utility";
            // 
            // ZDTicketSearchButton
            // 
            ZDTicketSearchButton.Location = new Point(137, 62);
            ZDTicketSearchButton.Name = "ZDTicketSearchButton";
            ZDTicketSearchButton.Size = new Size(55, 26);
            ZDTicketSearchButton.TabIndex = 3;
            ZDTicketSearchButton.Text = "Search";
            ZDTicketSearchButton.UseVisualStyleBackColor = true;
            ZDTicketSearchButton.Click += ZDTicketSearchButton_Click;
            // 
            // TicketSubjectLabel
            // 
            TicketSubjectLabel.AutoSize = true;
            TicketSubjectLabel.Location = new Point(12, 98);
            TicketSubjectLabel.Name = "TicketSubjectLabel";
            TicketSubjectLabel.Size = new Size(83, 15);
            TicketSubjectLabel.TabIndex = 4;
            TicketSubjectLabel.Text = "Ticket Subject:";
            // 
            // TicketSubjectTextBox
            // 
            TicketSubjectTextBox.Location = new Point(98, 95);
            TicketSubjectTextBox.Name = "TicketSubjectTextBox";
            TicketSubjectTextBox.PlaceholderText = "Ticket Subject";
            TicketSubjectTextBox.ReadOnly = true;
            TicketSubjectTextBox.Size = new Size(214, 23);
            TicketSubjectTextBox.TabIndex = 5;
            // 
            // TabControl
            // 
            TabControl.AllowDrop = true;
            TabControl.Controls.Add(DiagTabPage);
            TabControl.Controls.Add(repairTabPage);
            TabControl.Controls.Add(CloseTabPage);
            TabControl.Controls.Add(tabPage1);
            TabControl.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            TabControl.Location = new Point(12, 127);
            TabControl.Multiline = true;
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.Size = new Size(304, 393);
            TabControl.SizeMode = TabSizeMode.FillToRight;
            TabControl.TabIndex = 1;
            // 
            // DiagTabPage
            // 
            DiagTabPage.Controls.Add(DiagSubmitButton);
            DiagTabPage.Controls.Add(Diag_NotesTextBox);
            DiagTabPage.Controls.Add(Diag_TechNotesLabel);
            DiagTabPage.Controls.Add(Diag_PartsTextBox);
            DiagTabPage.Controls.Add(Diag_PartsNeededLabel);
            DiagTabPage.Controls.Add(Diag_TechDiagnosisTextBox);
            DiagTabPage.Controls.Add(Diag_UpdateTextLabel);
            DiagTabPage.Location = new Point(4, 24);
            DiagTabPage.Name = "DiagTabPage";
            DiagTabPage.Padding = new Padding(3);
            DiagTabPage.Size = new Size(296, 365);
            DiagTabPage.TabIndex = 1;
            DiagTabPage.Text = "Diagnostics";
            DiagTabPage.UseVisualStyleBackColor = true;
            // 
            // DiagSubmitButton
            // 
            DiagSubmitButton.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            DiagSubmitButton.Location = new Point(6, 314);
            DiagSubmitButton.Name = "DiagSubmitButton";
            DiagSubmitButton.Size = new Size(282, 45);
            DiagSubmitButton.TabIndex = 7;
            DiagSubmitButton.Text = "Submit";
            DiagSubmitButton.UseVisualStyleBackColor = true;
            DiagSubmitButton.Click += DiagSubmitButton_Click;
            // 
            // Diag_NotesTextBox
            // 
            Diag_NotesTextBox.ImeMode = ImeMode.On;
            Diag_NotesTextBox.Location = new Point(6, 141);
            Diag_NotesTextBox.Name = "Diag_NotesTextBox";
            Diag_NotesTextBox.Size = new Size(282, 167);
            Diag_NotesTextBox.TabIndex = 7;
            Diag_NotesTextBox.Text = "";
            // 
            // Diag_TechNotesLabel
            // 
            Diag_TechNotesLabel.AutoSize = true;
            Diag_TechNotesLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Diag_TechNotesLabel.Location = new Point(6, 123);
            Diag_TechNotesLabel.Name = "Diag_TechNotesLabel";
            Diag_TechNotesLabel.Size = new Size(111, 15);
            Diag_TechNotesLabel.TabIndex = 6;
            Diag_TechNotesLabel.Text = "Technician's Notes:";
            // 
            // Diag_PartsTextBox
            // 
            Diag_PartsTextBox.Location = new Point(6, 88);
            Diag_PartsTextBox.Name = "Diag_PartsTextBox";
            Diag_PartsTextBox.PlaceholderText = "Replacement Parts Needed";
            Diag_PartsTextBox.Size = new Size(282, 23);
            Diag_PartsTextBox.TabIndex = 3;
            // 
            // Diag_PartsNeededLabel
            // 
            Diag_PartsNeededLabel.AutoSize = true;
            Diag_PartsNeededLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Diag_PartsNeededLabel.Location = new Point(6, 70);
            Diag_PartsNeededLabel.Name = "Diag_PartsNeededLabel";
            Diag_PartsNeededLabel.Size = new Size(93, 15);
            Diag_PartsNeededLabel.TabIndex = 2;
            Diag_PartsNeededLabel.Text = "Part(s) Needed:";
            // 
            // Diag_TechDiagnosisTextBox
            // 
            Diag_TechDiagnosisTextBox.Location = new Point(6, 34);
            Diag_TechDiagnosisTextBox.Name = "Diag_TechDiagnosisTextBox";
            Diag_TechDiagnosisTextBox.PlaceholderText = "Failure Description";
            Diag_TechDiagnosisTextBox.Size = new Size(284, 23);
            Diag_TechDiagnosisTextBox.TabIndex = 1;
            // 
            // Diag_UpdateTextLabel
            // 
            Diag_UpdateTextLabel.AutoSize = true;
            Diag_UpdateTextLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Diag_UpdateTextLabel.Location = new Point(6, 16);
            Diag_UpdateTextLabel.Name = "Diag_UpdateTextLabel";
            Diag_UpdateTextLabel.Size = new Size(62, 15);
            Diag_UpdateTextLabel.TabIndex = 0;
            Diag_UpdateTextLabel.Text = "Diagnosis:";
            // 
            // repairTabPage
            // 
            repairTabPage.AllowDrop = true;
            repairTabPage.Controls.Add(repairSubmitButton);
            repairTabPage.Controls.Add(repairNotes);
            repairTabPage.Controls.Add(repairNotesLabel);
            repairTabPage.Controls.Add(repairOtherPartsTextBox);
            repairTabPage.Controls.Add(repairOtherPartLabel);
            repairTabPage.Controls.Add(repairLabel);
            repairTabPage.Controls.Add(repairPartsSelector);
            repairTabPage.Location = new Point(4, 24);
            repairTabPage.Name = "repairTabPage";
            repairTabPage.Padding = new Padding(3);
            repairTabPage.Size = new Size(296, 365);
            repairTabPage.TabIndex = 2;
            repairTabPage.Text = "Repair";
            repairTabPage.UseVisualStyleBackColor = true;
            // 
            // repairSubmitButton
            // 
            repairSubmitButton.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            repairSubmitButton.Location = new Point(6, 314);
            repairSubmitButton.Name = "repairSubmitButton";
            repairSubmitButton.Size = new Size(282, 45);
            repairSubmitButton.TabIndex = 8;
            repairSubmitButton.Text = "Submit";
            repairSubmitButton.UseMnemonic = false;
            repairSubmitButton.UseVisualStyleBackColor = true;
            repairSubmitButton.Click += RepairSubmitButton_Click;
            // 
            // repairNotes
            // 
            repairNotes.Location = new Point(6, 243);
            repairNotes.Name = "repairNotes";
            repairNotes.Size = new Size(282, 69);
            repairNotes.TabIndex = 5;
            repairNotes.Text = "";
            // 
            // repairNotesLabel
            // 
            repairNotesLabel.AutoSize = true;
            repairNotesLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            repairNotesLabel.Location = new Point(6, 210);
            repairNotesLabel.Name = "repairNotesLabel";
            repairNotesLabel.Size = new Size(73, 30);
            repairNotesLabel.TabIndex = 4;
            repairNotesLabel.Text = "Notes:";
            // 
            // repairOtherPartsTextBox
            // 
            repairOtherPartsTextBox.Location = new Point(6, 184);
            repairOtherPartsTextBox.Name = "repairOtherPartsTextBox";
            repairOtherPartsTextBox.Size = new Size(282, 23);
            repairOtherPartsTextBox.TabIndex = 3;
            // 
            // repairOtherPartLabel
            // 
            repairOtherPartLabel.AutoSize = true;
            repairOtherPartLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            repairOtherPartLabel.Location = new Point(6, 151);
            repairOtherPartLabel.Name = "repairOtherPartLabel";
            repairOtherPartLabel.Size = new Size(208, 30);
            repairOtherPartLabel.TabIndex = 2;
            repairOtherPartLabel.Text = "Other parts replaced:";
            // 
            // repairLabel
            // 
            repairLabel.AutoSize = true;
            repairLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            repairLabel.Location = new Point(6, 3);
            repairLabel.Name = "repairLabel";
            repairLabel.Size = new Size(210, 30);
            repairLabel.TabIndex = 1;
            repairLabel.Text = "Select parts replaced:";
            // 
            // CloseTabPage
            // 
            CloseTabPage.Controls.Add(Close_LimitToggle);
            CloseTabPage.Controls.Add(Close_ShipperOutput);
            CloseTabPage.Controls.Add(Close_SubmitButton);
            CloseTabPage.Controls.Add(Close_DeleteItemButton);
            CloseTabPage.Controls.Add(Close_ClearListButton);
            CloseTabPage.Controls.Add(Close_AddButton);
            CloseTabPage.Controls.Add(InputTicketTextBox);
            CloseTabPage.Controls.Add(Close_TicketDisplayListBox);
            CloseTabPage.Location = new Point(4, 24);
            CloseTabPage.Name = "CloseTabPage";
            CloseTabPage.Padding = new Padding(3);
            CloseTabPage.Size = new Size(296, 365);
            CloseTabPage.TabIndex = 3;
            CloseTabPage.Text = "Close Tickets";
            CloseTabPage.UseVisualStyleBackColor = true;
            // 
            // Close_LimitToggle
            // 
            Close_LimitToggle.AutoSize = true;
            Close_LimitToggle.Location = new Point(211, 9);
            Close_LimitToggle.Name = "Close_LimitToggle";
            Close_LimitToggle.Size = new Size(77, 19);
            Close_LimitToggle.TabIndex = 7;
            Close_LimitToggle.Text = "No Limits";
            Close_LimitToggle.UseVisualStyleBackColor = true;
            Close_LimitToggle.CheckedChanged += Close_LimitToggle_CheckedChanged;
            // 
            // Close_ShipperOutput
            // 
            Close_ShipperOutput.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            Close_ShipperOutput.Location = new Point(6, 222);
            Close_ShipperOutput.Name = "Close_ShipperOutput";
            Close_ShipperOutput.ReadOnly = true;
            Close_ShipperOutput.Size = new Size(282, 137);
            Close_ShipperOutput.TabIndex = 6;
            Close_ShipperOutput.Text = "";
            Close_ShipperOutput.WordWrap = false;
            // 
            // Close_SubmitButton
            // 
            Close_SubmitButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Close_SubmitButton.Location = new Point(99, 193);
            Close_SubmitButton.Name = "Close_SubmitButton";
            Close_SubmitButton.Size = new Size(108, 23);
            Close_SubmitButton.TabIndex = 5;
            Close_SubmitButton.Text = "Close Tickets";
            Close_SubmitButton.UseVisualStyleBackColor = true;
            Close_SubmitButton.Click += Close_SubmitButton_Click;
            // 
            // Close_DeleteItemButton
            // 
            Close_DeleteItemButton.Location = new Point(213, 193);
            Close_DeleteItemButton.Name = "Close_DeleteItemButton";
            Close_DeleteItemButton.Size = new Size(75, 23);
            Close_DeleteItemButton.TabIndex = 4;
            Close_DeleteItemButton.Text = "Delete Item";
            Close_DeleteItemButton.UseVisualStyleBackColor = true;
            Close_DeleteItemButton.Click += Close_DeleteItemButton_Click;
            // 
            // Close_ClearListButton
            // 
            Close_ClearListButton.Location = new Point(6, 193);
            Close_ClearListButton.Name = "Close_ClearListButton";
            Close_ClearListButton.Size = new Size(87, 23);
            Close_ClearListButton.TabIndex = 3;
            Close_ClearListButton.Text = "Clear List";
            Close_ClearListButton.UseVisualStyleBackColor = true;
            Close_ClearListButton.Click += Close_ClearListButton_Click;
            // 
            // Close_AddButton
            // 
            Close_AddButton.Location = new Point(114, 6);
            Close_AddButton.Name = "Close_AddButton";
            Close_AddButton.Size = new Size(93, 23);
            Close_AddButton.TabIndex = 2;
            Close_AddButton.Text = "Add Ticket";
            Close_AddButton.UseVisualStyleBackColor = true;
            Close_AddButton.Click += Close_AddButton_Click;
            // 
            // InputTicketTextBox
            // 
            InputTicketTextBox.Location = new Point(6, 6);
            InputTicketTextBox.Name = "InputTicketTextBox";
            InputTicketTextBox.PlaceholderText = "Ticket Number ";
            InputTicketTextBox.Size = new Size(102, 23);
            InputTicketTextBox.TabIndex = 1;
            InputTicketTextBox.KeyDown += InputTicketTextBox_KeyDown;
            // 
            // Close_TicketDisplayListBox
            // 
            Close_TicketDisplayListBox.FormattingEnabled = true;
            Close_TicketDisplayListBox.ItemHeight = 15;
            Close_TicketDisplayListBox.Location = new Point(6, 33);
            Close_TicketDisplayListBox.Name = "Close_TicketDisplayListBox";
            Close_TicketDisplayListBox.Size = new Size(282, 154);
            Close_TicketDisplayListBox.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(Update_RemoveAttachButton);
            tabPage1.Controls.Add(Update_AttachmentList);
            tabPage1.Controls.Add(Update_AddAttachButton);
            tabPage1.Controls.Add(Update_SubmitButton);
            tabPage1.Controls.Add(Update_AttachmentsLabel);
            tabPage1.Controls.Add(Update_InternalToggleButton);
            tabPage1.Controls.Add(Update_PublicToggleButton);
            tabPage1.Controls.Add(Update_NoteTextBox);
            tabPage1.Controls.Add(Update_NoteTextLabel);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(296, 365);
            tabPage1.TabIndex = 4;
            tabPage1.Text = "Update";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // Update_RemoveAttachButton
            // 
            Update_RemoveAttachButton.Location = new Point(154, 238);
            Update_RemoveAttachButton.Name = "Update_RemoveAttachButton";
            Update_RemoveAttachButton.Size = new Size(107, 23);
            Update_RemoveAttachButton.TabIndex = 9;
            Update_RemoveAttachButton.Text = "Remove Selected";
            Update_RemoveAttachButton.UseVisualStyleBackColor = true;
            Update_RemoveAttachButton.Click += Update_RemoveAttachButton_Click;
            // 
            // Update_AttachmentList
            // 
            Update_AttachmentList.FormattingEnabled = true;
            Update_AttachmentList.ItemHeight = 15;
            Update_AttachmentList.Location = new Point(6, 264);
            Update_AttachmentList.Name = "Update_AttachmentList";
            Update_AttachmentList.Size = new Size(282, 64);
            Update_AttachmentList.TabIndex = 8;
            // 
            // Update_AddAttachButton
            // 
            Update_AddAttachButton.Location = new Point(28, 238);
            Update_AddAttachButton.Name = "Update_AddAttachButton";
            Update_AddAttachButton.Size = new Size(108, 23);
            Update_AddAttachButton.TabIndex = 7;
            Update_AddAttachButton.Text = "Add Attachment";
            Update_AddAttachButton.UseVisualStyleBackColor = true;
            Update_AddAttachButton.Click += Update_AddAttachButton_Click;
            // 
            // Update_SubmitButton
            // 
            Update_SubmitButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Update_SubmitButton.Location = new Point(6, 331);
            Update_SubmitButton.Name = "Update_SubmitButton";
            Update_SubmitButton.Size = new Size(282, 28);
            Update_SubmitButton.TabIndex = 6;
            Update_SubmitButton.Text = "Post Update";
            Update_SubmitButton.UseVisualStyleBackColor = true;
            Update_SubmitButton.Click += Update_SubmitButton_Click;
            // 
            // Update_AttachmentsLabel
            // 
            Update_AttachmentsLabel.AutoSize = true;
            Update_AttachmentsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Update_AttachmentsLabel.Location = new Point(3, 220);
            Update_AttachmentsLabel.Name = "Update_AttachmentsLabel";
            Update_AttachmentsLabel.Size = new Size(85, 15);
            Update_AttachmentsLabel.TabIndex = 4;
            Update_AttachmentsLabel.Text = "Attachments: ";
            // 
            // Update_InternalToggleButton
            // 
            Update_InternalToggleButton.AutoSize = true;
            Update_InternalToggleButton.Location = new Point(154, 198);
            Update_InternalToggleButton.Name = "Update_InternalToggleButton";
            Update_InternalToggleButton.Size = new Size(95, 19);
            Update_InternalToggleButton.TabIndex = 3;
            Update_InternalToggleButton.Text = "Internal Note";
            Update_InternalToggleButton.UseVisualStyleBackColor = true;
            Update_InternalToggleButton.CheckedChanged += Update_InternalToggleButton_CheckedChanged;
            // 
            // Update_PublicToggleButton
            // 
            Update_PublicToggleButton.AutoSize = true;
            Update_PublicToggleButton.Location = new Point(32, 198);
            Update_PublicToggleButton.Name = "Update_PublicToggleButton";
            Update_PublicToggleButton.Size = new Size(85, 19);
            Update_PublicToggleButton.TabIndex = 2;
            Update_PublicToggleButton.Text = "Public Post";
            Update_PublicToggleButton.UseVisualStyleBackColor = true;
            Update_PublicToggleButton.CheckedChanged += Update_PublicToggleButton_CheckedChanged;
            // 
            // Update_NoteTextBox
            // 
            Update_NoteTextBox.Location = new Point(4, 21);
            Update_NoteTextBox.Name = "Update_NoteTextBox";
            Update_NoteTextBox.Size = new Size(284, 171);
            Update_NoteTextBox.TabIndex = 1;
            Update_NoteTextBox.Text = "";
            // 
            // Update_NoteTextLabel
            // 
            Update_NoteTextLabel.AutoSize = true;
            Update_NoteTextLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Update_NoteTextLabel.Location = new Point(6, 3);
            Update_NoteTextLabel.Name = "Update_NoteTextLabel";
            Update_NoteTextLabel.Size = new Size(130, 15);
            Update_NoteTextLabel.TabIndex = 0;
            Update_NoteTextLabel.Text = "Update Note Content:";
            // 
            // InitialsTextBox
            // 
            InitialsTextBox.Location = new Point(259, 65);
            InitialsTextBox.Name = "InitialsTextBox";
            InitialsTextBox.Size = new Size(52, 23);
            InitialsTextBox.TabIndex = 6;
            InitialsTextBox.TextChanged += InitialsTextBox_TextChanged;
            // 
            // InitialsLabel
            // 
            InitialsLabel.AutoSize = true;
            InitialsLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            InitialsLabel.Location = new Point(198, 65);
            InitialsLabel.Name = "InitialsLabel";
            InitialsLabel.Size = new Size(55, 21);
            InitialsLabel.TabIndex = 7;
            InitialsLabel.Text = "Initials";
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel, progressBar });
            statusStrip.Location = new Point(0, 518);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(323, 22);
            statusStrip.SizingGrip = false;
            statusStrip.TabIndex = 10;
            statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Overflow = ToolStripItemOverflow.Never;
            statusLabel.Size = new Size(206, 17);
            statusLabel.Spring = true;
            statusLabel.Text = "statusLabel";
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // progressBar
            // 
            progressBar.Name = "progressBar";
            progressBar.Overflow = ToolStripItemOverflow.Never;
            progressBar.RightToLeft = RightToLeft.No;
            progressBar.Size = new Size(100, 16);
            progressBar.Style = ProgressBarStyle.Continuous;
            // 
            // MainForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(323, 540);
            Controls.Add(statusStrip);
            Controls.Add(InitialsLabel);
            Controls.Add(InitialsTextBox);
            Controls.Add(TabControl);
            Controls.Add(TicketSubjectTextBox);
            Controls.Add(TicketSubjectLabel);
            Controls.Add(ZDTicketSearchButton);
            Controls.Add(AppTitleLabel);
            Controls.Add(ZDTicketTextBox);
            Controls.Add(ZDTicketLabel);
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MainForm";
            SizeGripStyle = SizeGripStyle.Show;
            Text = "Zendesk Ticket Utility";
            TabControl.ResumeLayout(false);
            DiagTabPage.ResumeLayout(false);
            DiagTabPage.PerformLayout();
            repairTabPage.ResumeLayout(false);
            repairTabPage.PerformLayout();
            CloseTabPage.ResumeLayout(false);
            CloseTabPage.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Label ZDTicketLabel;
        private TextBox ZDTicketTextBox;
        private Label AppTitleLabel;
        private Button ZDTicketSearchButton;
        private Label TicketSubjectLabel;
        private TextBox TicketSubjectTextBox;
        private TabControl TabControl;
        private TabPage DiagTabPage;
        private Button DiagSubmitButton;
        private Label Diag_UpdateTextLabel;
        private TextBox Diag_PartsTextBox;
        private Label Diag_PartsNeededLabel;
        private TextBox Diag_TechDiagnosisTextBox;
        private RichTextBox Diag_NotesTextBox;
        private Label Diag_TechNotesLabel;
        private TabPage repairTabPage;
        private TextBox repairOtherPartsTextBox;
        private Label repairOtherPartLabel;
        private Label repairLabel;
        private Button repairSubmitButton;
        private RichTextBox repairNotes;
        private Label repairNotesLabel;
        public CheckedListBox repairPartsSelector;
        private TextBox InitialsTextBox;
        private Label InitialsLabel;
        private TabPage CloseTabPage;
        private TextBox InputTicketTextBox;
        private ListBox Close_TicketDisplayListBox;
        private Button Close_DeleteItemButton;
        private Button Close_ClearListButton;
        private Button Close_AddButton;
        private RichTextBox Close_ShipperOutput;
        private Button Close_SubmitButton;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusLabel;
        private ToolStripProgressBar progressBar;
        private CheckBox Close_LimitToggle;
        private TabPage tabPage1;
        private RichTextBox Update_NoteTextBox;
        private Label Update_NoteTextLabel;
        private CheckBox Update_InternalToggleButton;
        private CheckBox Update_PublicToggleButton;
        private Button Update_SubmitButton;
        private Label Update_AttachmentsLabel;
        private Button Update_AddAttachButton;
        private ListBox Update_AttachmentList;
        private Button Update_RemoveAttachButton;
    }
}