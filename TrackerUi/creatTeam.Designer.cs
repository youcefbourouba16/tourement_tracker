namespace TrackerUi
{
    partial class creatTeam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(creatTeam));
            deleteSelectedPlayer = new Button();
            button1 = new Button();
            label8 = new Label();
            teamMemberListBox = new ListBox();
            addMember = new Button();
            CreatNumber = new Button();
            groupBox1 = new GroupBox();
            phoneNumValue = new TextBox();
            emailValue = new TextBox();
            lastNameValue = new TextBox();
            firstNameValue = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            selectTeamMemberDropdown = new ComboBox();
            label2 = new Label();
            tb_teamName = new TextBox();
            label3 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // deleteSelectedPlayer
            // 
            deleteSelectedPlayer.BackColor = Color.RosyBrown;
            deleteSelectedPlayer.BackgroundImageLayout = ImageLayout.Stretch;
            deleteSelectedPlayer.Cursor = Cursors.Hand;
            deleteSelectedPlayer.FlatAppearance.BorderSize = 0;
            deleteSelectedPlayer.FlatStyle = FlatStyle.Flat;
            deleteSelectedPlayer.Font = new Font("Unispace", 9.749999F, FontStyle.Bold, GraphicsUnit.Point);
            deleteSelectedPlayer.ForeColor = Color.White;
            deleteSelectedPlayer.Location = new Point(281, 109);
            deleteSelectedPlayer.Name = "deleteSelectedPlayer";
            deleteSelectedPlayer.Size = new Size(80, 63);
            deleteSelectedPlayer.TabIndex = 57;
            deleteSelectedPlayer.Text = "REMOVE SELECTED";
            deleteSelectedPlayer.UseVisualStyleBackColor = false;
            deleteSelectedPlayer.Click += deleteSelectedPlayer_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.PaleGoldenrod;
            button1.BackgroundImageLayout = ImageLayout.Stretch;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Unispace", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.Desktop;
            button1.Location = new Point(386, 453);
            button1.Name = "button1";
            button1.Size = new Size(331, 60);
            button1.TabIndex = 56;
            button1.Text = "Create Team";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Courier New", 14.25F, FontStyle.Italic, GraphicsUnit.Point);
            label8.ForeColor = Color.SteelBlue;
            label8.Location = new Point(369, 19);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(241, 21);
            label8.TabIndex = 55;
            label8.Text = "Team player Memeber :";
            // 
            // teamMemberListBox
            // 
            teamMemberListBox.BorderStyle = BorderStyle.None;
            teamMemberListBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            teamMemberListBox.ForeColor = Color.SteelBlue;
            teamMemberListBox.FormattingEnabled = true;
            teamMemberListBox.ItemHeight = 21;
            teamMemberListBox.Location = new Point(371, 54);
            teamMemberListBox.Name = "teamMemberListBox";
            teamMemberListBox.ScrollAlwaysVisible = true;
            teamMemberListBox.Size = new Size(380, 378);
            teamMemberListBox.TabIndex = 54;
            teamMemberListBox.SelectedIndexChanged += teamMemberListBox_SelectedIndexChanged;
            // 
            // addMember
            // 
            addMember.BackColor = Color.DarkKhaki;
            addMember.BackgroundImageLayout = ImageLayout.Stretch;
            addMember.Cursor = Cursors.Hand;
            addMember.FlatAppearance.BorderSize = 0;
            addMember.FlatStyle = FlatStyle.Flat;
            addMember.Font = new Font("Unispace", 9.749999F, FontStyle.Bold, GraphicsUnit.Point);
            addMember.ForeColor = Color.Black;
            addMember.Location = new Point(63, 210);
            addMember.Name = "addMember";
            addMember.Size = new Size(133, 33);
            addMember.TabIndex = 53;
            addMember.Text = " ADD Member";
            addMember.UseVisualStyleBackColor = false;
            addMember.Click += addMember_Click;
            // 
            // CreatNumber
            // 
            CreatNumber.BackColor = Color.Turquoise;
            CreatNumber.BackgroundImageLayout = ImageLayout.Stretch;
            CreatNumber.Cursor = Cursors.Hand;
            CreatNumber.FlatAppearance.BorderSize = 0;
            CreatNumber.FlatStyle = FlatStyle.Flat;
            CreatNumber.Font = new Font("Unispace", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            CreatNumber.ForeColor = Color.White;
            CreatNumber.Location = new Point(73, 462);
            CreatNumber.Name = "CreatNumber";
            CreatNumber.Size = new Size(183, 46);
            CreatNumber.TabIndex = 52;
            CreatNumber.Text = "ADD TEAM";
            CreatNumber.UseVisualStyleBackColor = false;
            CreatNumber.Click += CreatNumber_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(phoneNumValue);
            groupBox1.Controls.Add(emailValue);
            groupBox1.Controls.Add(lastNameValue);
            groupBox1.Controls.Add(firstNameValue);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.Font = new Font("Candara", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.ForeColor = Color.MidnightBlue;
            groupBox1.Location = new Point(11, 270);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(319, 175);
            groupBox1.TabIndex = 51;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add New member :";
            // 
            // phoneNumValue
            // 
            phoneNumValue.BorderStyle = BorderStyle.FixedSingle;
            phoneNumValue.Location = new Point(152, 129);
            phoneNumValue.Name = "phoneNumValue";
            phoneNumValue.Size = new Size(161, 26);
            phoneNumValue.TabIndex = 40;
            phoneNumValue.KeyPress += phoneNumValue_KeyPress;
            // 
            // emailValue
            // 
            emailValue.BorderStyle = BorderStyle.FixedSingle;
            emailValue.Location = new Point(152, 93);
            emailValue.Name = "emailValue";
            emailValue.Size = new Size(161, 26);
            emailValue.TabIndex = 39;
            emailValue.KeyPress += emailValue_KeyPress;
            // 
            // lastNameValue
            // 
            lastNameValue.BorderStyle = BorderStyle.FixedSingle;
            lastNameValue.Location = new Point(152, 61);
            lastNameValue.Name = "lastNameValue";
            lastNameValue.Size = new Size(161, 26);
            lastNameValue.TabIndex = 38;
            lastNameValue.KeyPress += firstNameValue_KeyPress;
            // 
            // firstNameValue
            // 
            firstNameValue.BorderStyle = BorderStyle.FixedSingle;
            firstNameValue.Location = new Point(152, 29);
            firstNameValue.Name = "firstNameValue";
            firstNameValue.Size = new Size(161, 26);
            firstNameValue.TabIndex = 34;
            firstNameValue.KeyPress += firstNameValue_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Courier New", 12F, FontStyle.Italic, GraphicsUnit.Point);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(10, 131);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(129, 19);
            label7.TabIndex = 37;
            label7.Text = "-Phone Num :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Courier New", 12F, FontStyle.Italic, GraphicsUnit.Point);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(5, 98);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(109, 19);
            label6.TabIndex = 36;
            label6.Text = "-Email   :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Courier New", 12F, FontStyle.Italic, GraphicsUnit.Point);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(5, 63);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(129, 19);
            label5.TabIndex = 35;
            label5.Text = "-Last Name :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Courier New", 12F, FontStyle.Italic, GraphicsUnit.Point);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(6, 32);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(139, 19);
            label4.TabIndex = 34;
            label4.Text = "-First Name :";
            // 
            // selectTeamMemberDropdown
            // 
            selectTeamMemberDropdown.FormattingEnabled = true;
            selectTeamMemberDropdown.Location = new Point(13, 172);
            selectTeamMemberDropdown.Name = "selectTeamMemberDropdown";
            selectTeamMemberDropdown.Size = new Size(230, 23);
            selectTeamMemberDropdown.TabIndex = 50;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Courier New", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(12, 138);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(230, 22);
            label2.TabIndex = 49;
            label2.Text = "Select team MEMBER :";
            // 
            // tb_teamName
            // 
            tb_teamName.BorderStyle = BorderStyle.FixedSingle;
            tb_teamName.Location = new Point(12, 92);
            tb_teamName.Name = "tb_teamName";
            tb_teamName.Size = new Size(240, 23);
            tb_teamName.TabIndex = 48;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Courier New", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label3.ForeColor = Color.MidnightBlue;
            label3.Location = new Point(8, 67);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(131, 22);
            label3.TabIndex = 47;
            label3.Text = "Team Name :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(8, 16);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(169, 29);
            label1.TabIndex = 46;
            label1.Text = "Creat Team :";
            // 
            // creatTeam
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(773, 540);
            Controls.Add(deleteSelectedPlayer);
            Controls.Add(button1);
            Controls.Add(label8);
            Controls.Add(teamMemberListBox);
            Controls.Add(addMember);
            Controls.Add(CreatNumber);
            Controls.Add(groupBox1);
            Controls.Add(selectTeamMemberDropdown);
            Controls.Add(label2);
            Controls.Add(tb_teamName);
            Controls.Add(label3);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "creatTeam";
            Text = "creatTeam";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button deleteSelectedPlayer;
        private Button button1;
        private Label label8;
        private ListBox teamMemberListBox;
        private Button addMember;
        private Button CreatNumber;
        private GroupBox groupBox1;
        private TextBox phoneNumValue;
        private TextBox emailValue;
        private TextBox lastNameValue;
        private TextBox firstNameValue;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private ComboBox selectTeamMemberDropdown;
        private Label label2;
        private TextBox tb_teamName;
        private Label label3;
        private Label label1;
    }
}