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
            teamMemberList = new ListBox();
            addMember = new Button();
            CreatNumber = new Button();
            groupBox1 = new GroupBox();
            phoneNum = new TextBox();
            email = new TextBox();
            lastName = new TextBox();
            firstName = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            comboBox1 = new ComboBox();
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
            deleteSelectedPlayer.Text = "DELETE SELECTED";
            deleteSelectedPlayer.UseVisualStyleBackColor = false;
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
            button1.Text = "Creat Team";
            button1.UseVisualStyleBackColor = false;
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
            // teamMemberList
            // 
            teamMemberList.BorderStyle = BorderStyle.None;
            teamMemberList.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            teamMemberList.ForeColor = Color.SteelBlue;
            teamMemberList.FormattingEnabled = true;
            teamMemberList.ItemHeight = 21;
            teamMemberList.Location = new Point(371, 54);
            teamMemberList.Name = "teamMemberList";
            teamMemberList.ScrollAlwaysVisible = true;
            teamMemberList.Size = new Size(380, 378);
            teamMemberList.TabIndex = 54;
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
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(phoneNum);
            groupBox1.Controls.Add(email);
            groupBox1.Controls.Add(lastName);
            groupBox1.Controls.Add(firstName);
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
            // phoneNum
            // 
            phoneNum.BorderStyle = BorderStyle.FixedSingle;
            phoneNum.Location = new Point(152, 129);
            phoneNum.Name = "phoneNum";
            phoneNum.Size = new Size(161, 26);
            phoneNum.TabIndex = 40;
            // 
            // email
            // 
            email.BorderStyle = BorderStyle.FixedSingle;
            email.Location = new Point(152, 93);
            email.Name = "email";
            email.Size = new Size(161, 26);
            email.TabIndex = 39;
            // 
            // lastName
            // 
            lastName.BorderStyle = BorderStyle.FixedSingle;
            lastName.Location = new Point(152, 61);
            lastName.Name = "lastName";
            lastName.Size = new Size(161, 26);
            lastName.TabIndex = 38;
            // 
            // firstName
            // 
            firstName.BorderStyle = BorderStyle.FixedSingle;
            firstName.Location = new Point(152, 29);
            firstName.Name = "firstName";
            firstName.Size = new Size(161, 26);
            firstName.TabIndex = 34;
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
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(13, 172);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(230, 23);
            comboBox1.TabIndex = 50;
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
            Controls.Add(teamMemberList);
            Controls.Add(addMember);
            Controls.Add(CreatNumber);
            Controls.Add(groupBox1);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(tb_teamName);
            Controls.Add(label3);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
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
        private ListBox teamMemberList;
        private Button addMember;
        private Button CreatNumber;
        private GroupBox groupBox1;
        private TextBox phoneNum;
        private TextBox email;
        private TextBox lastName;
        private TextBox firstName;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private ComboBox comboBox1;
        private Label label2;
        private TextBox tb_teamName;
        private Label label3;
        private Label label1;
    }
}