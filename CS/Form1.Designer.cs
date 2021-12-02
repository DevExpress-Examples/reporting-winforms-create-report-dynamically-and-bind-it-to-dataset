namespace WindowsFormsApp1 {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.button1 = new System.Windows.Forms.Button();
            this.xrTableRadioButton = new System.Windows.Forms.RadioButton();
            this.xrLabelsRadioButton = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create and Show the Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // xrTableRadioButton
            // 
            this.xrTableRadioButton.AutoSize = true;
            this.xrTableRadioButton.Checked = true;
            this.xrTableRadioButton.Location = new System.Drawing.Point(12, 63);
            this.xrTableRadioButton.Name = "xrTableRadioButton";
            this.xrTableRadioButton.Size = new System.Drawing.Size(67, 17);
            this.xrTableRadioButton.TabIndex = 1;
            this.xrTableRadioButton.TabStop = true;
            this.xrTableRadioButton.Text = "XRTable";
            this.xrTableRadioButton.UseVisualStyleBackColor = true;
            // 
            // xrLabelsRadioButton
            // 
            this.xrLabelsRadioButton.AutoSize = true;
            this.xrLabelsRadioButton.Location = new System.Drawing.Point(12, 86);
            this.xrLabelsRadioButton.Name = "xrLabelsRadioButton";
            this.xrLabelsRadioButton.Size = new System.Drawing.Size(66, 17);
            this.xrLabelsRadioButton.TabIndex = 2;
            this.xrLabelsRadioButton.Text = "XRLabel";
            this.xrLabelsRadioButton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(175, 45);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Choose a control which should be used to display the report\'s data.";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 146);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.xrLabelsRadioButton);
            this.Controls.Add(this.xrTableRadioButton);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton xrTableRadioButton;
        private System.Windows.Forms.RadioButton xrLabelsRadioButton;
        private System.Windows.Forms.TextBox textBox1;
    }
}

