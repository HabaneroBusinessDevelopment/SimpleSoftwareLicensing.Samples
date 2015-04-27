<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LicensePopup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LicensePopup))
        Me.btnClear = New System.Windows.Forms.Button()
        Me.textBox3 = New System.Windows.Forms.TextBox()
        Me.textBox2 = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.btnActivateTrial = New System.Windows.Forms.Button()
        Me.txtLicense = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(12, 156)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(96, 23)
        Me.btnClear.TabIndex = 17
        Me.btnClear.Text = "Reset License"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'textBox3
        '
        Me.textBox3.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textBox3.Location = New System.Drawing.Point(12, 419)
        Me.textBox3.Multiline = True
        Me.textBox3.Name = "textBox3"
        Me.textBox3.ReadOnly = True
        Me.textBox3.Size = New System.Drawing.Size(423, 98)
        Me.textBox3.TabIndex = 16
        Me.textBox3.Text = resources.GetString("textBox3.Text")
        '
        'textBox2
        '
        Me.textBox2.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textBox2.Location = New System.Drawing.Point(12, 315)
        Me.textBox2.Multiline = True
        Me.textBox2.Name = "textBox2"
        Me.textBox2.ReadOnly = True
        Me.textBox2.Size = New System.Drawing.Size(423, 98)
        Me.textBox2.TabIndex = 15
        Me.textBox2.Text = resources.GetString("textBox2.Text")
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(12, 195)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(147, 13)
        Me.label2.TabIndex = 14
        Me.label2.Text = "Sample licenses (copy-paste):"
        '
        'textBox1
        '
        Me.textBox1.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textBox1.Location = New System.Drawing.Point(12, 211)
        Me.textBox1.Multiline = True
        Me.textBox1.Name = "textBox1"
        Me.textBox1.ReadOnly = True
        Me.textBox1.Size = New System.Drawing.Size(423, 98)
        Me.textBox1.TabIndex = 13
        Me.textBox1.Text = resources.GetString("textBox1.Text")
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(68, 13)
        Me.label1.TabIndex = 12
        Me.label1.Text = "Your license:"
        '
        'btnActivateTrial
        '
        Me.btnActivateTrial.Location = New System.Drawing.Point(207, 156)
        Me.btnActivateTrial.Name = "btnActivateTrial"
        Me.btnActivateTrial.Size = New System.Drawing.Size(126, 23)
        Me.btnActivateTrial.TabIndex = 11
        Me.btnActivateTrial.Text = "Activate 10 day trial"
        Me.btnActivateTrial.UseVisualStyleBackColor = True
        '
        'txtLicense
        '
        Me.txtLicense.Location = New System.Drawing.Point(12, 28)
        Me.txtLicense.Multiline = True
        Me.txtLicense.Name = "txtLicense"
        Me.txtLicense.Size = New System.Drawing.Size(423, 116)
        Me.txtLicense.TabIndex = 10
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(339, 156)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(96, 23)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Save License"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'LicensePopup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 531)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.textBox3)
        Me.Controls.Add(Me.textBox2)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.textBox1)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.btnActivateTrial)
        Me.Controls.Add(Me.txtLicense)
        Me.Controls.Add(Me.btnSave)
        Me.Name = "LicensePopup"
        Me.Text = "LicensePopup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnClear As System.Windows.Forms.Button
    Private WithEvents textBox3 As System.Windows.Forms.TextBox
    Private WithEvents textBox2 As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents textBox1 As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents btnActivateTrial As System.Windows.Forms.Button
    Private WithEvents txtLicense As System.Windows.Forms.TextBox
    Private WithEvents btnSave As System.Windows.Forms.Button
End Class
