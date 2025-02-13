namespace MayinTarlasi
{
    partial class Form1
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
            userNameTextBox = new TextBox();
            label1 = new Label();
            gridInputTextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            mineTextBox = new TextBox();
            StartGameButton = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // userNameTextBox
            // 
            userNameTextBox.Location = new Point(324, 124);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.Size = new Size(157, 23);
            userNameTextBox.TabIndex = 0;
            userNameTextBox.TextChanged += userNameTextBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.ForeColor = SystemColors.Info;
            label1.Location = new Point(224, 127);
            label1.Name = "label1";
            label1.Size = new Size(91, 20);
            label1.TabIndex = 1;
            label1.Text = "Kullanıcı Adı:";
            label1.Click += label1_Click;
            // 
            // gridInputTextBox
            // 
            gridInputTextBox.Location = new Point(324, 163);
            gridInputTextBox.Name = "gridInputTextBox";
            gridInputTextBox.Size = new Size(157, 23);
            gridInputTextBox.TabIndex = 2;
            gridInputTextBox.TextChanged += gridInputTextBox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.ForeColor = SystemColors.Info;
            label2.Location = new Point(178, 166);
            label2.Name = "label2";
            label2.Size = new Size(145, 20);
            label2.TabIndex = 3;
            label2.Text = "Tarla Büyüklüğü (AxA)";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label3.ForeColor = SystemColors.Info;
            label3.Location = new Point(224, 204);
            label3.Name = "label3";
            label3.Size = new Size(89, 20);
            label3.TabIndex = 4;
            label3.Text = "Mayın Sayısı";
            label3.Click += label3_Click;
            // 
            // mineTextBox
            // 
            mineTextBox.Location = new Point(324, 201);
            mineTextBox.Name = "mineTextBox";
            mineTextBox.Size = new Size(157, 23);
            mineTextBox.TabIndex = 5;
            mineTextBox.TextChanged += mineTextBox_TextChanged;
            // 
            // StartGameButton
            // 
            StartGameButton.Font = new Font("Gill Sans Ultra Bold Condensed", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StartGameButton.Location = new Point(242, 291);
            StartGameButton.Name = "StartGameButton";
            StartGameButton.Size = new Size(253, 69);
            StartGameButton.TabIndex = 6;
            StartGameButton.Text = "OYUNA BAŞLA";
            StartGameButton.UseVisualStyleBackColor = true;
            StartGameButton.Click += StartGameButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Showcard Gothic", 44.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.Info;
            label4.Location = new Point(178, 27);
            label4.Name = "label4";
            label4.Size = new Size(447, 74);
            label4.TabIndex = 7;
            label4.Text = "MINESWEEPER";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label5.ForeColor = SystemColors.Info;
            label5.Location = new Point(12, 382);
            label5.Name = "label5";
            label5.Size = new Size(88, 20);
            label5.TabIndex = 8;
            label5.Text = "Turan Akgün";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label6.ForeColor = SystemColors.Info;
            label6.Location = new Point(634, 382);
            label6.Name = "label6";
            label6.Size = new Size(85, 20);
            label6.TabIndex = 9;
            label6.Text = "230229048";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(754, 427);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(StartGameButton);
            Controls.Add(mineTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(gridInputTextBox);
            Controls.Add(label1);
            Controls.Add(userNameTextBox);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mayin Tarlasi Giris Ekrani";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox userNameTextBox;
        private Label label1;
        private TextBox gridInputTextBox;
        private Label label2;
        private Label label3;
        private TextBox mineTextBox;
        private Button StartGameButton;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}
