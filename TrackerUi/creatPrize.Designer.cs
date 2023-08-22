namespace TrackerUi
{
    partial class creatPrize
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(creatPrize));
            button1 = new Button();
            prizePercentageValue = new TextBox();
            label2 = new Label();
            label8 = new Label();
            label1 = new Label();
            PrizeAmountValue = new TextBox();
            placeNameValue = new TextBox();
            placeNumberValue = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            SuspendLayout();
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
            button1.Location = new Point(52, 351);
            button1.Name = "button1";
            button1.Size = new Size(331, 60);
            button1.TabIndex = 94;
            button1.Text = "Creat Prize";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // prizePercentageValue
            // 
            prizePercentageValue.BorderStyle = BorderStyle.FixedSingle;
            prizePercentageValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            prizePercentageValue.Location = new Point(103, 300);
            prizePercentageValue.Margin = new Padding(4);
            prizePercentageValue.Name = "prizePercentageValue";
            prizePercentageValue.Size = new Size(206, 29);
            prizePercentageValue.TabIndex = 93;
            prizePercentageValue.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Courier New", 14.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor = Color.SteelBlue;
            label2.Location = new Point(101, 274);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(208, 22);
            label2.TabIndex = 92;
            label2.Text = "Prize Percentage :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Ink Free", 14F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.MidnightBlue;
            label8.Location = new Point(170, 238);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(52, 23);
            label8.TabIndex = 91;
            label8.Text = "-OR-";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Georgia", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(121, 27);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(165, 29);
            label1.TabIndex = 90;
            label1.Text = "Creat Prize :";
            // 
            // PrizeAmountValue
            // 
            PrizeAmountValue.BorderStyle = BorderStyle.FixedSingle;
            PrizeAmountValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PrizeAmountValue.Location = new Point(215, 187);
            PrizeAmountValue.Margin = new Padding(4);
            PrizeAmountValue.Name = "PrizeAmountValue";
            PrizeAmountValue.Size = new Size(206, 29);
            PrizeAmountValue.TabIndex = 89;
            PrizeAmountValue.Text = "0";
            // 
            // placeNameValue
            // 
            placeNameValue.BorderStyle = BorderStyle.FixedSingle;
            placeNameValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            placeNameValue.Location = new Point(216, 142);
            placeNameValue.Margin = new Padding(4);
            placeNameValue.Name = "placeNameValue";
            placeNameValue.Size = new Size(206, 29);
            placeNameValue.TabIndex = 88;
            // 
            // placeNumberValue
            // 
            placeNumberValue.BorderStyle = BorderStyle.FixedSingle;
            placeNumberValue.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            placeNumberValue.Location = new Point(216, 98);
            placeNumberValue.Margin = new Padding(4);
            placeNumberValue.Name = "placeNumberValue";
            placeNumberValue.Size = new Size(206, 29);
            placeNumberValue.TabIndex = 84;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Courier New", 12F, FontStyle.Italic, GraphicsUnit.Point);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(12, 187);
            label6.Margin = new Padding(5, 0, 5, 0);
            label6.Name = "label6";
            label6.Size = new Size(159, 19);
            label6.TabIndex = 87;
            label6.Text = "-prize Amount :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Courier New", 12F, FontStyle.Italic, GraphicsUnit.Point);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(12, 103);
            label5.Margin = new Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new Size(159, 19);
            label5.TabIndex = 86;
            label5.Text = "-Place number :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Courier New", 12F, FontStyle.Italic, GraphicsUnit.Point);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(18, 142);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(149, 19);
            label4.TabIndex = 85;
            label4.Text = "-place Name  :";
            // 
            // creatPrize
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 450);
            Controls.Add(button1);
            Controls.Add(prizePercentageValue);
            Controls.Add(label2);
            Controls.Add(label8);
            Controls.Add(label1);
            Controls.Add(PrizeAmountValue);
            Controls.Add(placeNameValue);
            Controls.Add(placeNumberValue);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "creatPrize";
            Text = "creatPrize";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox prizePercentageValue;
        private Label label2;
        private Label label8;
        private Label label1;
        private TextBox PrizeAmountValue;
        private TextBox placeNameValue;
        private TextBox placeNumberValue;
        private Label label6;
        private Label label5;
        private Label label4;
    }
}