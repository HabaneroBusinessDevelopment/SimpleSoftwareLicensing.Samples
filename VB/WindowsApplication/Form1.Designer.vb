<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnStandard = New System.Windows.Forms.Button()
        Me.btnPro = New System.Windows.Forms.Button()
        Me.btnEnterprise = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(13, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Enter License"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(124, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Label1"
        '
        'btnStandard
        '
        Me.btnStandard.Location = New System.Drawing.Point(13, 72)
        Me.btnStandard.Name = "btnStandard"
        Me.btnStandard.Size = New System.Drawing.Size(105, 23)
        Me.btnStandard.TabIndex = 2
        Me.btnStandard.Text = "Standard Feature"
        Me.btnStandard.UseVisualStyleBackColor = True
        '
        'btnPro
        '
        Me.btnPro.Location = New System.Drawing.Point(138, 71)
        Me.btnPro.Name = "btnPro"
        Me.btnPro.Size = New System.Drawing.Size(75, 23)
        Me.btnPro.TabIndex = 3
        Me.btnPro.Text = "Pro Feature"
        Me.btnPro.UseVisualStyleBackColor = True
        '
        'btnEnterprise
        '
        Me.btnEnterprise.Location = New System.Drawing.Point(230, 71)
        Me.btnEnterprise.Name = "btnEnterprise"
        Me.btnEnterprise.Size = New System.Drawing.Size(109, 23)
        Me.btnEnterprise.TabIndex = 4
        Me.btnEnterprise.Text = "Enterprise Feature"
        Me.btnEnterprise.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(367, 137)
        Me.Controls.Add(Me.btnEnterprise)
        Me.Controls.Add(Me.btnPro)
        Me.Controls.Add(Me.btnStandard)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnStandard As System.Windows.Forms.Button
    Friend WithEvents btnPro As System.Windows.Forms.Button
    Friend WithEvents btnEnterprise As System.Windows.Forms.Button
End Class
