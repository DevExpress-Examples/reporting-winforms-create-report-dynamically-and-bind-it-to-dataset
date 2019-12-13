Imports Microsoft.VisualBasic
Imports System
Namespace WindowsApplication1
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
			Me.radioButton1 = New System.Windows.Forms.RadioButton()
			Me.radioButton2 = New System.Windows.Forms.RadioButton()
			Me.textBox1 = New System.Windows.Forms.TextBox()
			Me.SuspendLayout()
			' 
			' button1
			' 
			Me.button1.Location = New System.Drawing.Point(21, 160)
			Me.button1.Name = "button1"
			Me.button1.Size = New System.Drawing.Size(166, 23)
			Me.button1.TabIndex = 0
			Me.button1.Text = "Create and Show the Report"
			Me.button1.UseVisualStyleBackColor = True
'			Me.button1.Click += New System.EventHandler(Me.button1_Click);
			' 
			' radioButton1
			' 
			Me.radioButton1.AutoSize = True
			Me.radioButton1.Checked = True
			Me.radioButton1.Location = New System.Drawing.Point(72, 121)
			Me.radioButton1.Name = "radioButton1"
			Me.radioButton1.Size = New System.Drawing.Size(67, 17)
			Me.radioButton1.TabIndex = 1
			Me.radioButton1.TabStop = True
			Me.radioButton1.Text = "XRTable"
			Me.radioButton1.UseVisualStyleBackColor = True
			' 
			' radioButton2
			' 
			Me.radioButton2.AutoSize = True
			Me.radioButton2.Location = New System.Drawing.Point(72, 98)
			Me.radioButton2.Name = "radioButton2"
			Me.radioButton2.Size = New System.Drawing.Size(71, 17)
			Me.radioButton2.TabIndex = 2
			Me.radioButton2.Text = "XRLabels"
			Me.radioButton2.UseVisualStyleBackColor = True
			' 
			' textBox1
			' 
			Me.textBox1.Location = New System.Drawing.Point(21, 12)
			Me.textBox1.Multiline = True
			Me.textBox1.Name = "textBox1"
			Me.textBox1.Size = New System.Drawing.Size(166, 70)
			Me.textBox1.TabIndex = 3
			Me.textBox1.Text = "Choose the building block for the report's Detail band and click the button"
			Me.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(204, 219)
			Me.Controls.Add(Me.textBox1)
			Me.Controls.Add(Me.radioButton2)
			Me.Controls.Add(Me.radioButton1)
			Me.Controls.Add(Me.button1)
			Me.Name = "Form1"
			Me.Text = "Form1"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents button1 As System.Windows.Forms.Button
		Private radioButton1 As System.Windows.Forms.RadioButton
		Private radioButton2 As System.Windows.Forms.RadioButton
		Private textBox1 As System.Windows.Forms.TextBox
	End Class
End Namespace

