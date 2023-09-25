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
            label3 = new Label();
            firstPName = new Label();
            secondPName = new Label();
            thirdPName = new Label();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // tourName
            // 
            tourName.AutoSize = true;
            tourName.Font = new Font("Segoe UI Historic", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            tourName.Location = new Point(419, 9);
            tourName.Name = "tourName";
            tourName.Size = new Size(96, 37);
            tourName.TabIndex = 0;
            tourName.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(165, 74);
            label1.Name = "label1";
            label1.Size = new Size(92, 21);
            label1.TabIndex = 1;
            label1.Text = "First place :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(399, 74);
            label2.Name = "label2";
            label2.Size = new Size(116, 21);
            label2.TabIndex = 2;
            label2.Text = "Second place :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(672, 79);
            label3.Name = "label3";
            label3.Size = new Size(96, 21);
            label3.TabIndex = 3;
            label3.Text = "third place :";
            // 
            // firstPName
            // 
            firstPName.AutoSize = true;
            firstPName.Location = new Point(263, 79);
            firstPName.Name = "firstPName";
            firstPName.Size = new Size(38, 15);
            firstPName.TabIndex = 4;
            firstPName.Text = "label4";
            // 
            // secondPName
            // 
            secondPName.AutoSize = true;
            secondPName.Location = new Point(521, 78);
            secondPName.Name = "secondPName";
            secondPName.Size = new Size(38, 15);
            secondPName.TabIndex = 5;
            secondPName.Text = "label5";
            // 
            // thirdPName
            // 
            thirdPName.AutoSize = true;
            thirdPName.Location = new Point(765, 84);
            thirdPName.Name = "thirdPName";
            thirdPName.Size = new Size(38, 15);
            thirdPName.TabIndex = 6;
            thirdPName.Text = "label6";
            // 
            // panel1
            // 
            panel1.Location = new Point(12, 125);
            panel1.Name = "panel1";
            panel1.Size = new Size(914, 386);
            panel1.TabIndex = 7;
            // 
            // tourament_Bracket
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(938, 523);
            Controls.Add(panel1);
            Controls.Add(thirdPName);
            Controls.Add(secondPName);
            Controls.Add(firstPName);
            Controls.Add(label3);
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
    }
}