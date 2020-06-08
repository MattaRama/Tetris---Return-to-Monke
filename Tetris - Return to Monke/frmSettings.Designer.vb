<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.clbEnabledPieces = New System.Windows.Forms.CheckedListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdUpdatePieces = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'clbEnabledPieces
        '
        Me.clbEnabledPieces.FormattingEnabled = True
        Me.clbEnabledPieces.Location = New System.Drawing.Point(12, 32)
        Me.clbEnabledPieces.Name = "clbEnabledPieces"
        Me.clbEnabledPieces.Size = New System.Drawing.Size(151, 124)
        Me.clbEnabledPieces.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(138, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Enabled Pieces:"
        '
        'cmdUpdatePieces
        '
        Me.cmdUpdatePieces.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdatePieces.Location = New System.Drawing.Point(12, 162)
        Me.cmdUpdatePieces.Name = "cmdUpdatePieces"
        Me.cmdUpdatePieces.Size = New System.Drawing.Size(151, 23)
        Me.cmdUpdatePieces.TabIndex = 2
        Me.cmdUpdatePieces.Text = "Update"
        Me.cmdUpdatePieces.UseVisualStyleBackColor = True
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(326, 202)
        Me.Controls.Add(Me.cmdUpdatePieces)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.clbEnabledPieces)
        Me.Name = "frmSettings"
        Me.Text = "Return to Monke - Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents clbEnabledPieces As CheckedListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdUpdatePieces As Button
End Class
