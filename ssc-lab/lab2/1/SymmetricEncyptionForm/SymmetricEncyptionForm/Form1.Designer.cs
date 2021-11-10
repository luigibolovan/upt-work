namespace SymmetricEncyptionForm
{
    partial class Form1
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
            this.algorithmComboBox = new System.Windows.Forms.ComboBox();
            this.generateKeyIVBtn = new System.Windows.Forms.Button();
            this.encryptBtn = new System.Windows.Forms.Button();
            this.decryptBtn = new System.Windows.Forms.Button();
            this.encryptTimeBtn = new System.Windows.Forms.Button();
            this.decryptTimeBtn = new System.Windows.Forms.Button();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.ivTextBox = new System.Windows.Forms.TextBox();
            this.plainTextASCIITextBox = new System.Windows.Forms.TextBox();
            this.plainTextHEXTextBox = new System.Windows.Forms.TextBox();
            this.cipherTextASCIITextBox = new System.Windows.Forms.TextBox();
            this.cipherTextHEXTextBox = new System.Windows.Forms.TextBox();
            this.timeEncryptionLabel = new System.Windows.Forms.Label();
            this.decryptionTimeLabel = new System.Windows.Forms.Label();
            this.keyLabel = new System.Windows.Forms.Label();
            this.ivLabel = new System.Windows.Forms.Label();
            this.plainTextLabel = new System.Windows.Forms.Label();
            this.asciiLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hexLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // algorithmComboBox
            // 
            this.algorithmComboBox.FormattingEnabled = true;
            this.algorithmComboBox.Location = new System.Drawing.Point(24, 42);
            this.algorithmComboBox.Name = "algorithmComboBox";
            this.algorithmComboBox.Size = new System.Drawing.Size(206, 21);
            this.algorithmComboBox.TabIndex = 0;
            // 
            // generateKeyIVBtn
            // 
            this.generateKeyIVBtn.Location = new System.Drawing.Point(24, 106);
            this.generateKeyIVBtn.Name = "generateKeyIVBtn";
            this.generateKeyIVBtn.Size = new System.Drawing.Size(206, 34);
            this.generateKeyIVBtn.TabIndex = 1;
            this.generateKeyIVBtn.Text = "Generate IV and Key";
            this.generateKeyIVBtn.UseVisualStyleBackColor = true;
            this.generateKeyIVBtn.Click += new System.EventHandler(this.generateKeyIVBtn_Click);
            // 
            // encryptBtn
            // 
            this.encryptBtn.Location = new System.Drawing.Point(24, 212);
            this.encryptBtn.Name = "encryptBtn";
            this.encryptBtn.Size = new System.Drawing.Size(206, 31);
            this.encryptBtn.TabIndex = 2;
            this.encryptBtn.Text = "Encrypt";
            this.encryptBtn.UseVisualStyleBackColor = true;
            this.encryptBtn.Click += new System.EventHandler(this.encryptBtn_Click);
            // 
            // decryptBtn
            // 
            this.decryptBtn.Location = new System.Drawing.Point(24, 302);
            this.decryptBtn.Name = "decryptBtn";
            this.decryptBtn.Size = new System.Drawing.Size(205, 34);
            this.decryptBtn.TabIndex = 3;
            this.decryptBtn.Text = "Decrypt";
            this.decryptBtn.UseVisualStyleBackColor = true;
            this.decryptBtn.Click += new System.EventHandler(this.decryptBtn_Click);
            // 
            // encryptTimeBtn
            // 
            this.encryptTimeBtn.Location = new System.Drawing.Point(24, 384);
            this.encryptTimeBtn.Name = "encryptTimeBtn";
            this.encryptTimeBtn.Size = new System.Drawing.Size(204, 28);
            this.encryptTimeBtn.TabIndex = 4;
            this.encryptTimeBtn.Text = "Get Encrypt Time";
            this.encryptTimeBtn.UseVisualStyleBackColor = true;
            this.encryptTimeBtn.Click += new System.EventHandler(this.encryptTimeBtn_Click);
            // 
            // decryptTimeBtn
            // 
            this.decryptTimeBtn.Location = new System.Drawing.Point(24, 453);
            this.decryptTimeBtn.Name = "decryptTimeBtn";
            this.decryptTimeBtn.Size = new System.Drawing.Size(203, 26);
            this.decryptTimeBtn.TabIndex = 5;
            this.decryptTimeBtn.Text = "Get Decrypt Time";
            this.decryptTimeBtn.UseVisualStyleBackColor = true;
            this.decryptTimeBtn.Click += new System.EventHandler(this.decryptTimeBtn_Click);
            // 
            // keyTextBox
            // 
            this.keyTextBox.Location = new System.Drawing.Point(420, 42);
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.Size = new System.Drawing.Size(290, 20);
            this.keyTextBox.TabIndex = 6;
            // 
            // ivTextBox
            // 
            this.ivTextBox.Location = new System.Drawing.Point(420, 97);
            this.ivTextBox.Name = "ivTextBox";
            this.ivTextBox.Size = new System.Drawing.Size(289, 20);
            this.ivTextBox.TabIndex = 7;
            // 
            // plainTextASCIITextBox
            // 
            this.plainTextASCIITextBox.Location = new System.Drawing.Point(420, 192);
            this.plainTextASCIITextBox.Name = "plainTextASCIITextBox";
            this.plainTextASCIITextBox.Size = new System.Drawing.Size(288, 20);
            this.plainTextASCIITextBox.TabIndex = 8;
            this.plainTextASCIITextBox.TextChanged += new System.EventHandler(this.plainTextASCIITextBox_TextChanged);
            // 
            // plainTextHEXTextBox
            // 
            this.plainTextHEXTextBox.Location = new System.Drawing.Point(420, 236);
            this.plainTextHEXTextBox.Name = "plainTextHEXTextBox";
            this.plainTextHEXTextBox.Size = new System.Drawing.Size(289, 20);
            this.plainTextHEXTextBox.TabIndex = 9;
            this.plainTextHEXTextBox.TextChanged += new System.EventHandler(this.plainTextHEXTextBox_TextChanged);
            // 
            // cipherTextASCIITextBox
            // 
            this.cipherTextASCIITextBox.Location = new System.Drawing.Point(420, 302);
            this.cipherTextASCIITextBox.Name = "cipherTextASCIITextBox";
            this.cipherTextASCIITextBox.Size = new System.Drawing.Size(290, 20);
            this.cipherTextASCIITextBox.TabIndex = 10;
            // 
            // cipherTextHEXTextBox
            // 
            this.cipherTextHEXTextBox.Location = new System.Drawing.Point(420, 350);
            this.cipherTextHEXTextBox.Name = "cipherTextHEXTextBox";
            this.cipherTextHEXTextBox.Size = new System.Drawing.Size(290, 20);
            this.cipherTextHEXTextBox.TabIndex = 11;
            this.cipherTextHEXTextBox.TextChanged += new System.EventHandler(this.cipherTextHEXTextBox_TextChanged);
            // 
            // timeEncryptionLabel
            // 
            this.timeEncryptionLabel.AutoSize = true;
            this.timeEncryptionLabel.Location = new System.Drawing.Point(417, 392);
            this.timeEncryptionLabel.Name = "timeEncryptionLabel";
            this.timeEncryptionLabel.Size = new System.Drawing.Size(144, 13);
            this.timeEncryptionLabel.TabIndex = 12;
            this.timeEncryptionLabel.Text = "Time/message at encryption:";
            // 
            // decryptionTimeLabel
            // 
            this.decryptionTimeLabel.AutoSize = true;
            this.decryptionTimeLabel.Location = new System.Drawing.Point(417, 453);
            this.decryptionTimeLabel.Name = "decryptionTimeLabel";
            this.decryptionTimeLabel.Size = new System.Drawing.Size(144, 13);
            this.decryptionTimeLabel.TabIndex = 13;
            this.decryptionTimeLabel.Text = "Time/message at decryption:";
            // 
            // keyLabel
            // 
            this.keyLabel.AutoSize = true;
            this.keyLabel.Location = new System.Drawing.Point(417, 26);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(25, 13);
            this.keyLabel.TabIndex = 14;
            this.keyLabel.Text = "Key";
            // 
            // ivLabel
            // 
            this.ivLabel.AutoSize = true;
            this.ivLabel.Location = new System.Drawing.Point(417, 81);
            this.ivLabel.Name = "ivLabel";
            this.ivLabel.Size = new System.Drawing.Size(17, 13);
            this.ivLabel.TabIndex = 15;
            this.ivLabel.Text = "IV";
            // 
            // plainTextLabel
            // 
            this.plainTextLabel.AutoSize = true;
            this.plainTextLabel.Location = new System.Drawing.Point(417, 176);
            this.plainTextLabel.Name = "plainTextLabel";
            this.plainTextLabel.Size = new System.Drawing.Size(54, 13);
            this.plainTextLabel.TabIndex = 16;
            this.plainTextLabel.Text = "Plain Text";
            // 
            // asciiLabel
            // 
            this.asciiLabel.AutoSize = true;
            this.asciiLabel.Location = new System.Drawing.Point(379, 194);
            this.asciiLabel.Name = "asciiLabel";
            this.asciiLabel.Size = new System.Drawing.Size(34, 13);
            this.asciiLabel.TabIndex = 17;
            this.asciiLabel.Text = "ASCII";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(379, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "ASCII";
            // 
            // hexLabel
            // 
            this.hexLabel.AutoSize = true;
            this.hexLabel.Location = new System.Drawing.Point(384, 239);
            this.hexLabel.Name = "hexLabel";
            this.hexLabel.Size = new System.Drawing.Size(29, 13);
            this.hexLabel.TabIndex = 19;
            this.hexLabel.Text = "HEX";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(384, 357);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "HEX";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(312, 500);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 13);
            this.errorLabel.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 523);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hexLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.asciiLabel);
            this.Controls.Add(this.plainTextLabel);
            this.Controls.Add(this.ivLabel);
            this.Controls.Add(this.keyLabel);
            this.Controls.Add(this.decryptionTimeLabel);
            this.Controls.Add(this.timeEncryptionLabel);
            this.Controls.Add(this.cipherTextHEXTextBox);
            this.Controls.Add(this.cipherTextASCIITextBox);
            this.Controls.Add(this.plainTextHEXTextBox);
            this.Controls.Add(this.plainTextASCIITextBox);
            this.Controls.Add(this.ivTextBox);
            this.Controls.Add(this.keyTextBox);
            this.Controls.Add(this.decryptTimeBtn);
            this.Controls.Add(this.encryptTimeBtn);
            this.Controls.Add(this.decryptBtn);
            this.Controls.Add(this.encryptBtn);
            this.Controls.Add(this.generateKeyIVBtn);
            this.Controls.Add(this.algorithmComboBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox algorithmComboBox;
        private System.Windows.Forms.Button generateKeyIVBtn;
        private System.Windows.Forms.Button encryptBtn;
        private System.Windows.Forms.Button decryptBtn;
        private System.Windows.Forms.Button encryptTimeBtn;
        private System.Windows.Forms.Button decryptTimeBtn;
        private System.Windows.Forms.TextBox keyTextBox;
        private System.Windows.Forms.TextBox ivTextBox;
        private System.Windows.Forms.TextBox plainTextASCIITextBox;
        private System.Windows.Forms.TextBox plainTextHEXTextBox;
        private System.Windows.Forms.TextBox cipherTextASCIITextBox;
        private System.Windows.Forms.TextBox cipherTextHEXTextBox;
        private System.Windows.Forms.Label timeEncryptionLabel;
        private System.Windows.Forms.Label decryptionTimeLabel;
        private System.Windows.Forms.Label keyLabel;
        private System.Windows.Forms.Label ivLabel;
        private System.Windows.Forms.Label plainTextLabel;
        private System.Windows.Forms.Label asciiLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label hexLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label errorLabel;
    }
}

