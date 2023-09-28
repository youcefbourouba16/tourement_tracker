namespace TrackerUi
{
    partial class tourament_Bracket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tourament_Bracket));
            tourName = new Label();
            label1 = new Label();
            label2 = new Label();
            firstPName = new Label();
            secondPName = new Label();
            panel1 = new Panel();
            DeleteTour = new Button();
            EditTour = new Button();
            button1 = new Button();
            button2 = new Button();
            label4 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // tourName
            // 
            tourName.AutoSize = true;
            tourName.Font = new Font("Comic Sans MS", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            tourName.ForeColor = Color.Red;
            tourName.Location = new Point(429, 9);
            tourName.Name = "tourName";
            tourName.Size = new Size(93, 38);
            tourName.TabIndex = 0;
            tourName.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(128, 93);
            label1.Name = "label1";
            label1.Size = new Size(127, 21);
            label1.TabIndex = 1;
            label1.Text = "First place :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(558, 93);
            label2.Name = "label2";
            label2.Size = new Size(136, 21);
            label2.TabIndex = 2;
            label2.Text = "Second place :";
            // 
            // firstPName
            // 
            firstPName.AutoSize = true;
            firstPName.Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point);
            firstPName.Location = new Point(261, 93);
            firstPName.Name = "firstPName";
            firstPName.Size = new Size(64, 21);
            firstPName.TabIndex = 4;
            firstPName.Text = "label4";
            // 
            // secondPName
            // 
            secondPName.AutoSize = true;
            secondPName.Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point);
            secondPName.Location = new Point(700, 93);
            secondPName.Name = "secondPName";
            secondPName.Size = new Size(64, 21);
            secondPName.TabIndex = 5;
            secondPName.Text = "label5";
            // 
            // panel1
            // 
            panel1.Location = new Point(12, 160);
            panel1.Name = "panel1";
            panel1.Size = new Size(579, 550);
            panel1.TabIndex = 7;
            // 
            // DeleteTour
            // 
            DeleteTour.BackColor = Color.Firebrick;
            DeleteTour.BackgroundImageLayout = ImageLayout.Stretch;
            DeleteTour.Cursor = Cursors.Hand;
            DeleteTour.FlatAppearance.BorderSize = 0;
            DeleteTour.FlatStyle = FlatStyle.Flat;
            DeleteTour.Font = new Font("Segoe UI Symbol", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            DeleteTour.ForeColor = SystemColors.Control;
            DeleteTour.Location = new Point(629, 277);
            DeleteTour.Name = "DeleteTour";
            DeleteTour.Size = new Size(260, 63);
            DeleteTour.TabIndex = 41;
            DeleteTour.Text = "Delete Tourament";
            DeleteTour.UseVisualStyleBackColor = false;
            DeleteTour.Click += DeleteTour_Click;
            // 
            // EditTour
            // 
            EditTour.BackColor = Color.PeachPuff;
            EditTour.BackgroundImageLayout = ImageLayout.Stretch;
            EditTour.Cursor = Cursors.Hand;
            EditTour.FlatAppearance.BorderSize = 0;
            EditTour.FlatStyle = FlatStyle.Flat;
            EditTour.Font = new Font("Microsoft Sans Serif", 11.9999981F, FontStyle.Bold, GraphicsUnit.Point);
            EditTour.Location = new Point(629, 194);
            EditTour.Name = "EditTour";
            EditTour.Size = new Size(260, 57);
            EditTour.TabIndex = 42;
            EditTour.Text = "Tourament History";
            EditTour.UseVisualStyleBackColor = false;
            EditTour.Click += EditTour_Click_1;
            // 
            // button1
            // 
            button1.BackColor = Color.Gray;
            button1.Enabled = false;
            button1.Location = new Point(-3, 126);
            button1.Name = "button1";
            button1.Size = new Size(964, 10);
            button1.TabIndex = 43;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Gray;
            button2.Enabled = false;
            button2.Location = new Point(-3, 71);
            button2.Name = "button2";
            button2.Size = new Size(964, 10);
            button2.TabIndex = 44;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Firebrick;
            label4.Location = new Point(248, 139);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 45;
            label4.Text = "Tips :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(277, 139);
            label3.Margin = new Padding(0, 0, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(314, 15);
            label3.TabIndex = 46;
            label3.Text = "hover over teams gives you Matchup Parent  information .";
            // 
            // tourament_Bracket
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(956, 481);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(EditTour);
            Controls.Add(DeleteTour);
            Controls.Add(panel1);
            Controls.Add(secondPName);
            Controls.Add(firstPName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tourName);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "tourament_Bracket";
            Text = "tourament_Bracket";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label tourName;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label firstPName;
        private Label secondPName;
        private Label thirdPName;
        private Panel panel1;
        private Button DeleteTour;
        private Button EditTour;
        private Button button1;
        private Button button2;
        private Label label4;
    }
}