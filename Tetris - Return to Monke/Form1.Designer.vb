<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReturnToMonke
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReturnToMonke))
        Me.lblHighestScore = New System.Windows.Forms.Label()
        Me.cmdStartGame = New System.Windows.Forms.PictureBox()
        Me.cmdSettings = New System.Windows.Forms.PictureBox()
        CType(Me.cmdStartGame, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblHighestScore
        '
        Me.lblHighestScore.AutoSize = True
        Me.lblHighestScore.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblHighestScore.Font = New System.Drawing.Font("Microsoft YaHei", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHighestScore.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblHighestScore.Location = New System.Drawing.Point(626, 252)
        Me.lblHighestScore.Name = "lblHighestScore"
        Me.lblHighestScore.Size = New System.Drawing.Size(242, 84)
        Me.lblHighestScore.TabIndex = 0
        Me.lblHighestScore.Text = "1st Place High Score:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2nd Place High Score:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3rd Place High Score:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'cmdStartGame
        '
        Me.cmdStartGame.BackColor = System.Drawing.Color.Transparent
        Me.cmdStartGame.Location = New System.Drawing.Point(89, 519)
        Me.cmdStartGame.Name = "cmdStartGame"
        Me.cmdStartGame.Size = New System.Drawing.Size(371, 84)
        Me.cmdStartGame.TabIndex = 1
        Me.cmdStartGame.TabStop = False
        '
        'cmdSettings
        '
        Me.cmdSettings.BackColor = System.Drawing.Color.Transparent
        Me.cmdSettings.Location = New System.Drawing.Point(553, 519)
        Me.cmdSettings.Name = "cmdSettings"
        Me.cmdSettings.Size = New System.Drawing.Size(371, 84)
        Me.cmdSettings.TabIndex = 2
        Me.cmdSettings.TabStop = False
        '
        'frmReturnToMonke
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(987, 661)
        Me.Controls.Add(Me.cmdSettings)
        Me.Controls.Add(Me.cmdStartGame)
        Me.Controls.Add(Me.lblHighestScore)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReturnToMonke"
        Me.Text = "Matthew J. Robinson - Tetris: Return to Monke"
        CType(Me.cmdStartGame, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdSettings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblHighestScore As Label
    Friend WithEvents cmdStartGame As PictureBox
    Friend WithEvents cmdSettings As PictureBox
End Class
