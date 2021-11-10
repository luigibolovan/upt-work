namespace HashFunctionsAndMAC
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
            this.hashAlgorithms = new System.Windows.Forms.ComboBox();
            this.computeMACButton = new System.Windows.Forms.Button();
            this.verifyMACButton = new System.Windows.Forms.Button();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.asciiMACTextBox = new System.Windows.Forms.TextBox();
            this.hexMACTextBox = new System.Windows.Forms.TextBox();
            this.keyLabel = new System.Windows.Forms.Label();
            this.asciiLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hexLabel = new System.Windows.Forms.Label();
            this.plainTextLabel = new System.Windows.Forms.Label();
            this.macLabel = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.verifyLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // hashAlgorithms
            // 
            this.hashAlgorithms.FormattingEnabled = true;
            this.hashAlgorithms.Location = new System.Drawing.Point(33, 66);
            this.hashAlgorithms.Name = "hashAlgorithms";
            this.hashAlgorithms.Size = new System.Drawing.Size(222, 21);
            this.hashAlgorithms.TabIndex = 0;
            // 
            // computeMACButton
            // 
            this.computeMACButton.Location = new System.Drawing.Point(33, 182);
            this.computeMACButton.Name = "computeMACButton";
            this.computeMACButton.Size = new System.Drawing.Size(222, 57);
            this.computeMACButton.TabIndex = 1;
            this.computeMACButton.Text = "Compute MAC";
            this.computeMACButton.UseVisualStyleBackColor = true;
            this.computeMACButton.Click += new System.EventHandler(this.computeMACButton_Click);
            // 
            // verifyMACButton
            // 
            this.verifyMACButton.Location = new System.Drawing.Point(33, 302);
            this.verifyMACButton.Name = "verifyMACButton";
            this.verifyMACButton.Size = new System.Drawing.Size(222, 65);
            this.verifyMACButton.TabIndex = 2;
            this.verifyMACButton.Text = "Verify MAC";
            this.verifyMACButton.UseVisualStyleBackColor = true;
            this.verifyMACButton.Click += new System.EventHandler(this.verifyMACButton_Click);
            // 
            // keyTextBox
            // 
            this.keyTextBox.Location = new System.Drawing.Point(454, 66);
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.Size = new System.Drawing.Size(271, 20);
            this.keyTextBox.TabIndex = 3;
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(454, 201);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(269, 20);
            this.messageTextBox.TabIndex = 4;
            // 
            // asciiMACTextBox
            // 
            this.asciiMACTextBox.Location = new System.Drawing.Point(453, 302);
            this.asciiMACTextBox.Name = "asciiMACTextBox";
            this.asciiMACTextBox.Size = new System.Drawing.Size(270, 20);
            this.asciiMACTextBox.TabIndex = 5;
            // 
            // hexMACTextBox
            // 
            this.hexMACTextBox.Location = new System.Drawing.Point(454, 343);
            this.hexMACTextBox.Name = "hexMACTextBox";
            this.hexMACTextBox.Size = new System.Drawing.Size(271, 20);
            this.hexMACTextBox.TabIndex = 6;
            // 
            // keyLabel
            // 
            this.keyLabel.AutoSize = true;
            this.keyLabel.Location = new System.Drawing.Point(451, 50);
            this.keyLabel.Name = "keyLabel";
            this.keyLabel.Size = new System.Drawing.Size(25, 13);
            this.keyLabel.TabIndex = 7;
            this.keyLabel.Text = "Key";
            // 
            // asciiLabel
            // 
            this.asciiLabel.AutoSize = true;
            this.asciiLabel.Location = new System.Drawing.Point(413, 69);
            this.asciiLabel.Name = "asciiLabel";
            this.asciiLabel.Size = new System.Drawing.Size(34, 13);
            this.asciiLabel.TabIndex = 8;
            this.asciiLabel.Text = "ASCII";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(413, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "ASCII";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(413, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "ASCII";
            // 
            // hexLabel
            // 
            this.hexLabel.AutoSize = true;
            this.hexLabel.Location = new System.Drawing.Point(413, 350);
            this.hexLabel.Name = "hexLabel";
            this.hexLabel.Size = new System.Drawing.Size(29, 13);
            this.hexLabel.TabIndex = 11;
            this.hexLabel.Text = "HEX";
            // 
            // plainTextLabel
            // 
            this.plainTextLabel.AutoSize = true;
            this.plainTextLabel.Location = new System.Drawing.Point(451, 182);
            this.plainTextLabel.Name = "plainTextLabel";
            this.plainTextLabel.Size = new System.Drawing.Size(54, 13);
            this.plainTextLabel.TabIndex = 12;
            this.plainTextLabel.Text = "Plain Text";
            // 
            // macLabel
            // 
            this.macLabel.AutoSize = true;
            this.macLabel.Location = new System.Drawing.Point(451, 286);
            this.macLabel.Name = "macLabel";
            this.macLabel.Size = new System.Drawing.Size(30, 13);
            this.macLabel.TabIndex = 13;
            this.macLabel.Text = "MAC";
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(442, 401);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 13);
            this.errorLabel.TabIndex = 14;
            // 
            // verifyLabel
            // 
            this.verifyLabel.AutoSize = true;
            this.verifyLabel.Location = new System.Drawing.Point(119, 401);
            this.verifyLabel.Name = "verifyLabel";
            this.verifyLabel.Size = new System.Drawing.Size(0, 13);
            this.verifyLabel.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.verifyLabel);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.macLabel);
            this.Controls.Add(this.plainTextLabel);
            this.Controls.Add(this.hexLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.asciiLabel);
            this.Controls.Add(this.keyLabel);
            this.Controls.Add(this.hexMACTextBox);
            this.Controls.Add(this.asciiMACTextBox);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.keyTextBox);
            this.Controls.Add(this.verifyMACButton);
            this.Controls.Add(this.computeMACButton);
            this.Controls.Add(this.hashAlgorithms);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox hashAlgorithms;
        private System.Windows.Forms.Button computeMACButton;
        private System.Windows.Forms.Button verifyMACButton;
        private System.Windows.Forms.TextBox keyTextBox;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.TextBox asciiMACTextBox;
        private System.Windows.Forms.TextBox hexMACTextBox;
        private System.Windows.Forms.Label keyLabel;
        private System.Windows.Forms.Label asciiLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label hexLabel;
        private System.Windows.Forms.Label plainTextLabel;
        private System.Windows.Forms.Label macLabel;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label verifyLabel;
    }
}

