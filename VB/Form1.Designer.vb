Namespace WindowsFormsApp1
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.button1 = New System.Windows.Forms.Button()
			Me.xrTableRadioButton = New System.Windows.Forms.RadioButton()
			Me.xrLabelsRadioButton = New System.Windows.Forms.RadioButton()
			Me.textBox1 = New System.Windows.Forms.TextBox()
			Me.SuspendLayout()
			' 
			' button1
			' 
			Me.button1.Location = New System.Drawing.Point(12, 109)
			Me.button1.Name = "button1"
			Me.button1.Size = New System.Drawing.Size(175, 23)
			Me.button1.TabIndex = 0
			Me.button1.Text = "Create and Show the Report"
			Me.button1.UseVisualStyleBackColor = True
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.button1.Click += new System.EventHandler(this.button1_Click);
			' 
			' xrTableRadioButton
			' 
			Me.xrTableRadioButton.AutoSize = True
			Me.xrTableRadioButton.Checked = True
			Me.xrTableRadioButton.Location = New System.Drawing.Point(12, 63)
			Me.xrTableRadioButton.Name = "xrTableRadioButton"
			Me.xrTableRadioButton.Size = New System.Drawing.Size(67, 17)
			Me.xrTableRadioButton.TabIndex = 1
			Me.xrTableRadioButton.TabStop = True
			Me.xrTableRadioButton.Text = "XRTable"
			Me.xrTableRadioButton.UseVisualStyleBackColor = True
			' 
			' xrLabelsRadioButton
			' 
			Me.xrLabelsRadioButton.AutoSize = True
			Me.xrLabelsRadioButton.Location = New System.Drawing.Point(12, 86)
			Me.xrLabelsRadioButton.Name = "xrLabelsRadioButton"
			Me.xrLabelsRadioButton.Size = New System.Drawing.Size(66, 17)
			Me.xrLabelsRadioButton.TabIndex = 2
			Me.xrLabelsRadioButton.Text = "XRLabel"
			Me.xrLabelsRadioButton.UseVisualStyleBackColor = True
			' 
			' textBox1
			' 
			Me.textBox1.Location = New System.Drawing.Point(12, 12)
			Me.textBox1.Multiline = True
			Me.textBox1.Name = "textBox1"
			Me.textBox1.Size = New System.Drawing.Size(175, 45)
			Me.textBox1.TabIndex = 3
			Me.textBox1.Text = "Choose a control which should be used to display the report's data."
			Me.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(203, 146)
			Me.Controls.Add(Me.textBox1)
			Me.Controls.Add(Me.xrLabelsRadioButton)
			Me.Controls.Add(Me.xrTableRadioButton)
			Me.Controls.Add(Me.button1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.Load += new System.EventHandler(this.Form1_Load);
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents button1 As System.Windows.Forms.Button
		Private xrTableRadioButton As System.Windows.Forms.RadioButton
		Private xrLabelsRadioButton As System.Windows.Forms.RadioButton
		Private WithEvents textBox1 As System.Windows.Forms.TextBox
	End Class
End Namespace

