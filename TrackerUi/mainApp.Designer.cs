namespace TrackerUi
{
    partial class mainApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainApp));
            button1 = new Button();
            monthCalendar1 = new MonthCalendar();
            label10 = new Label();
            score_teamTWO = new TextBox();
            label8 = new Label();
            label9 = new Label();
            label4 = new Label();
            label2 = new Label();
            score_teamONE = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            matchupListBox = new ListBox();
            playedOnly_checkBox = new CheckBox();
            round_list = new ComboBox();
            label3 = new Label();
            TourName = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.PaleGoldenrod;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new Font("Unispace", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(313, 324);
            button1.Name = "button1";
            button1.Size = new Size(455, 61);
            button1.TabIndex = 37;
            button1.Text = "ADD SCORE";
            button1.UseVisualStyleBackColor = false;
            // 
            // monthCalendar1
            // 
            monthCalendar1.BackColor = SystemColors.MenuHighlight;
            monthCalendar1.Font = new Font("Simple Indust Outline", 9F, FontStyle.Bold, GraphicsUnit.Point);
            monthCalendar1.ForeColor = SystemColors.MenuHighlight;
            monthCalendar1.Location = new Point(452, 18);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 36;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Ink Free", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(544, 283);
            label10.Name = "label10";
            label10.Size = new Size(68, 23);
            label10.TabIndex = 35;
            label10.Text = "Score :";
            // 
            // score_teamTWO
            // 
            score_teamTWO.Location = new Point(618, 283);
            score_teamTWO.Name = "score_teamTWO";
            score_teamTWO.Size = new Size(61, 23);
            score_teamTWO.TabIndex = 34;
            score_teamTWO.KeyPress += score_teamTWO_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Ink Free", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(287, 285);
            label8.Name = "label8";
            label8.Size = new Size(68, 23);
            label8.TabIndex = 33;
            label8.Text = "Score :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Georgia", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(485, 219);
            label9.Name = "label9";
            label9.Size = new Size(65, 29);
            label9.TabIndex = 32;
            label9.Text = "-VS-";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Courier New", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.MidnightBlue;
            label4.Location = new Point(544, 222);
            label4.Name = "label4";
            label4.Size = new Size(87, 21);
            label4.TabIndex = 31;
            label4.Text = "teamTwo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Courier New", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.MidnightBlue;
            label2.Location = new Point(287, 222);
            label2.Name = "label2";
            label2.Size = new Size(87, 21);
            label2.TabIndex = 30;
            label2.Text = "teamOne";
            // 
            // score_teamONE
            // 
            score_teamONE.Location = new Point(361, 285);
            score_teamONE.Name = "score_teamONE";
            score_teamONE.Size = new Size(61, 23);
            score_teamONE.TabIndex = 29;
            score_teamONE.KeyPress += score_teamTWO_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(531, 324);
            label7.Name = "label7";
            label7.Size = new Size(0, 15);
            label7.TabIndex = 28;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(271, 300);
            label6.Name = "label6";
            label6.Size = new Size(0, 15);
            label6.TabIndex = 27;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(596, 248);
            label5.Name = "label5";
            label5.Size = new Size(0, 15);
            label5.TabIndex = 26;
            // 
            // matchupListBox
            // 
            matchupListBox.BorderStyle = BorderStyle.None;
            matchupListBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            matchupListBox.FormattingEnabled = true;
            matchupListBox.ItemHeight = 21;
            matchupListBox.Location = new Point(34, 189);
            matchupListBox.Name = "matchupListBox";
            matchupListBox.ScrollAlwaysVisible = true;
            matchupListBox.Size = new Size(237, 189);
            matchupListBox.TabIndex = 25;
            // 
            // playedOnly_checkBox
            // 
            playedOnly_checkBox.AutoSize = true;
            playedOnly_checkBox.Checked = true;
            playedOnly_checkBox.CheckState = CheckState.Checked;
            playedOnly_checkBox.FlatStyle = FlatStyle.Flat;
            playedOnly_checkBox.Font = new Font("Cascadia Mono SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            playedOnly_checkBox.ForeColor = Color.Black;
            playedOnly_checkBox.Location = new Point(99, 158);
            playedOnly_checkBox.Name = "playedOnly_checkBox";
            playedOnly_checkBox.Size = new Size(125, 25);
            playedOnly_checkBox.TabIndex = 24;
            playedOnly_checkBox.Text = "Played ONLY";
            playedOnly_checkBox.UseVisualStyleBackColor = true;
            // 
            // round_list
            // 
            round_list.FlatStyle = FlatStyle.Flat;
            round_list.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            round_list.FormattingEnabled = true;
            round_list.Location = new Point(99, 94);
            round_list.Name = "round_list";
            round_list.Size = new Size(220, 29);
            round_list.TabIndex = 23;
            round_list.SelectedIndexChanged += round_list_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Courier New", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label3.ForeColor = Color.MidnightBlue;
            label3.Location = new Point(34, 98);
            label3.Name = "label3";
            label3.Size = new Size(59, 19);
            label3.TabIndex = 22;
            label3.Text = "Round";
            // 
            // TourName
            // 
            TourName.AutoSize = true;
            TourName.Font = new Font("Courier New", 13F, FontStyle.Bold, GraphicsUnit.Point);
            TourName.ForeColor = Color.MidnightBlue;
            TourName.Location = new Point(199, 39);
            TourName.Name = "TourName";
            TourName.Size = new Size(120, 21);
            TourName.TabIndex = 21;
            TourName.Text = "<teamName>";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(26, 31);
            label1.Name = "label1";
            label1.Size = new Size(167, 29);
            label1.TabIndex = 20;
            label1.Text = "Tourament :";
            // 
            // mainApp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(800, 399);
            Controls.Add(button1);
            Controls.Add(monthCalendar1);
            Controls.Add(label10);
            Controls.Add(score_teamTWO);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(score_teamONE);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(matchupListBox);
            Controls.Add(playedOnly_checkBox);
            Controls.Add(round_list);
            Controls.Add(label3);
            Controls.Add(TourName);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "mainApp";
            Text = "mainApp";
            KeyPress += score_teamTWO_KeyPress;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private MonthCalendar monthCalendar1;
        private Label label10;
        private TextBox score_teamTWO;
        private Label label8;
        private Label label9;
        private Label label4;
        private Label label2;
        private TextBox score_teamONE;
        private Label label7;
        private Label label6;
        private Label label5;
        private ListBox matchupListBox;
        private CheckBox playedOnly_checkBox;
        private ComboBox round_list;
        private Label label3;
        private Label TourName;
        private Label label1;
    }
}