﻿namespace TrackerUi
{
    partial class CreatTour
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreatTour));
            btn_addTourament = new Button();
            label6 = new Label();
            label5 = new Label();
            deleteSelectedPrize = new Button();
            PrizesAllListBox = new ListBox();
            deleteSelectedTeam = new Button();
            teamsListbox = new ListBox();
            btn_addPrize = new Button();
            btn_addTeam = new Button();
            linkLabel1 = new LinkLabel();
            label4 = new Label();
            SelectTeamDropDown = new ComboBox();
            entryFee_val = new TextBox();
            touramentName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // btn_addTourament
            // 
            btn_addTourament.BackColor = Color.Gray;
            btn_addTourament.BackgroundImageLayout = ImageLayout.Stretch;
            btn_addTourament.Cursor = Cursors.Hand;
            btn_addTourament.FlatAppearance.BorderSize = 0;
            btn_addTourament.FlatStyle = FlatStyle.Flat;
            btn_addTourament.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_addTourament.Location = new Point(441, 397);
            btn_addTourament.Name = "btn_addTourament";
            btn_addTourament.Size = new Size(455, 61);
            btn_addTourament.TabIndex = 45;
            btn_addTourament.Text = "ADD Tourament";
            btn_addTourament.UseVisualStyleBackColor = false;
            btn_addTourament.Click += btn_addTourament_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Courier New", 14.25F, FontStyle.Italic, GraphicsUnit.Point);
            label6.ForeColor = Color.Gray;
            label6.Location = new Point(565, 52);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(120, 21);
            label6.TabIndex = 44;
            label6.Text = "Prize LIST";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Courier New", 14.25F, FontStyle.Italic, GraphicsUnit.Point);
            label5.ForeColor = Color.SteelBlue;
            label5.Location = new Point(39, 283);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(175, 21);
            label5.TabIndex = 43;
            label5.Text = "Teams / Players";
            // 
            // deleteSelectedPrize
            // 
            deleteSelectedPrize.BackColor = Color.RosyBrown;
            deleteSelectedPrize.BackgroundImageLayout = ImageLayout.Stretch;
            deleteSelectedPrize.Cursor = Cursors.Hand;
            deleteSelectedPrize.FlatAppearance.BorderSize = 0;
            deleteSelectedPrize.FlatStyle = FlatStyle.Flat;
            deleteSelectedPrize.Font = new Font("Microsoft Sans Serif", 9.749999F, FontStyle.Bold, GraphicsUnit.Point);
            deleteSelectedPrize.Location = new Point(822, 152);
            deleteSelectedPrize.Name = "deleteSelectedPrize";
            deleteSelectedPrize.Size = new Size(80, 63);
            deleteSelectedPrize.TabIndex = 42;
            deleteSelectedPrize.Text = "Remove SELECTED";
            deleteSelectedPrize.UseVisualStyleBackColor = false;
            deleteSelectedPrize.Click += deleteSelectedPrize_Click;
            // 
            // PrizesAllListBox
            // 
            PrizesAllListBox.BorderStyle = BorderStyle.None;
            PrizesAllListBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PrizesAllListBox.ForeColor = Color.DarkKhaki;
            PrizesAllListBox.FormattingEnabled = true;
            PrizesAllListBox.ItemHeight = 21;
            PrizesAllListBox.Location = new Point(565, 85);
            PrizesAllListBox.Name = "PrizesAllListBox";
            PrizesAllListBox.ScrollAlwaysVisible = true;
            PrizesAllListBox.Size = new Size(245, 189);
            PrizesAllListBox.TabIndex = 41;
            PrizesAllListBox.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // deleteSelectedTeam
            // 
            deleteSelectedTeam.BackColor = Color.RosyBrown;
            deleteSelectedTeam.BackgroundImageLayout = ImageLayout.Stretch;
            deleteSelectedTeam.Cursor = Cursors.Hand;
            deleteSelectedTeam.FlatAppearance.BorderSize = 0;
            deleteSelectedTeam.FlatStyle = FlatStyle.Flat;
            deleteSelectedTeam.Font = new Font("Microsoft Sans Serif", 9.749999F, FontStyle.Bold, GraphicsUnit.Point);
            deleteSelectedTeam.Location = new Point(310, 374);
            deleteSelectedTeam.Name = "deleteSelectedTeam";
            deleteSelectedTeam.Size = new Size(80, 63);
            deleteSelectedTeam.TabIndex = 40;
            deleteSelectedTeam.Text = "Remove SELECTED";
            deleteSelectedTeam.UseVisualStyleBackColor = false;
            deleteSelectedTeam.Click += deleteSelectedTeam_Click;
            // 
            // teamsListbox
            // 
            teamsListbox.BorderStyle = BorderStyle.None;
            teamsListbox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            teamsListbox.ForeColor = Color.SteelBlue;
            teamsListbox.FormattingEnabled = true;
            teamsListbox.ItemHeight = 21;
            teamsListbox.Location = new Point(41, 318);
            teamsListbox.Name = "teamsListbox";
            teamsListbox.ScrollAlwaysVisible = true;
            teamsListbox.Size = new Size(245, 189);
            teamsListbox.TabIndex = 39;
            // 
            // btn_addPrize
            // 
            btn_addPrize.BackColor = Color.DimGray;
            btn_addPrize.BackgroundImageLayout = ImageLayout.Stretch;
            btn_addPrize.Cursor = Cursors.Hand;
            btn_addPrize.FlatAppearance.BorderSize = 0;
            btn_addPrize.FlatStyle = FlatStyle.Flat;
            btn_addPrize.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            btn_addPrize.ForeColor = Color.White;
            btn_addPrize.Location = new Point(255, 218);
            btn_addPrize.Name = "btn_addPrize";
            btn_addPrize.Size = new Size(183, 46);
            btn_addPrize.TabIndex = 38;
            btn_addPrize.Text = "ADD prize";
            btn_addPrize.UseVisualStyleBackColor = false;
            btn_addPrize.Click += btn_addPrize_Click;
            // 
            // btn_addTeam
            // 
            btn_addTeam.BackColor = Color.Turquoise;
            btn_addTeam.BackgroundImageLayout = ImageLayout.Stretch;
            btn_addTeam.Cursor = Cursors.Hand;
            btn_addTeam.FlatAppearance.BorderSize = 0;
            btn_addTeam.FlatStyle = FlatStyle.Flat;
            btn_addTeam.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            btn_addTeam.Location = new Point(39, 218);
            btn_addTeam.Name = "btn_addTeam";
            btn_addTeam.Size = new Size(183, 46);
            btn_addTeam.TabIndex = 37;
            btn_addTeam.Text = "ADD team";
            btn_addTeam.UseVisualStyleBackColor = false;
            btn_addTeam.Click += btn_addTeam_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(396, 172);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(105, 15);
            linkLabel1.TabIndex = 36;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Create new Team ?";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Courier New", 14.25F, FontStyle.Italic, GraphicsUnit.Point);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(13, 172);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(153, 21);
            label4.TabIndex = 35;
            label4.Text = "SELECT TEAM :";
            // 
            // SelectTeamDropDown
            // 
            SelectTeamDropDown.FlatStyle = FlatStyle.Flat;
            SelectTeamDropDown.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            SelectTeamDropDown.FormattingEnabled = true;
            SelectTeamDropDown.Location = new Point(170, 168);
            SelectTeamDropDown.Name = "SelectTeamDropDown";
            SelectTeamDropDown.Size = new Size(220, 29);
            SelectTeamDropDown.TabIndex = 34;
            SelectTeamDropDown.SelectedIndexChanged += SelectTeamDropDown_SelectedIndexChanged;
            // 
            // entryFee_val
            // 
            entryFee_val.BorderStyle = BorderStyle.FixedSingle;
            entryFee_val.Location = new Point(206, 121);
            entryFee_val.Name = "entryFee_val";
            entryFee_val.Size = new Size(98, 23);
            entryFee_val.TabIndex = 33;
            entryFee_val.Text = "0";
            entryFee_val.KeyPress += entryFee_val_KeyPress;
            // 
            // touramentName
            // 
            touramentName.BorderStyle = BorderStyle.FixedSingle;
            touramentName.Location = new Point(206, 78);
            touramentName.Name = "touramentName";
            touramentName.Size = new Size(329, 23);
            touramentName.TabIndex = 32;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Courier New", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor = Color.MidnightBlue;
            label2.Location = new Point(13, 128);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(131, 22);
            label2.TabIndex = 31;
            label2.Text = "Entry fee :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Courier New", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label3.ForeColor = Color.MidnightBlue;
            label3.Location = new Point(13, 85);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(186, 22);
            label3.TabIndex = 30;
            label3.Text = "Tourament Name :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(13, 21);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(240, 29);
            label1.TabIndex = 29;
            label1.Text = "Creat Tourament :";
            // 
            // CreatTour
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(918, 524);
            Controls.Add(btn_addTourament);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(deleteSelectedPrize);
            Controls.Add(PrizesAllListBox);
            Controls.Add(deleteSelectedTeam);
            Controls.Add(teamsListbox);
            Controls.Add(btn_addPrize);
            Controls.Add(btn_addTeam);
            Controls.Add(linkLabel1);
            Controls.Add(label4);
            Controls.Add(SelectTeamDropDown);
            Controls.Add(entryFee_val);
            Controls.Add(touramentName);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "CreatTour";
            Text = "CreatTour";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_addTourament;
        private Label label6;
        private Label label5;
        private Button deleteSelectedPrize;
        private ListBox PrizesAllListBox;
        private Button deleteSelectedTeam;
        private ListBox matchupListBox;
        private Button btn_addPrize;
        private Button btn_addTeam;
        private LinkLabel linkLabel1;
        private Label label4;
        private ComboBox SelectTeamDropDown;
        private TextBox entryFee_val;
        private TextBox touramentName;
        private Label label2;
        private Label label3;
        private Label label1;
        private ListBox teamsListbox;
    }
}