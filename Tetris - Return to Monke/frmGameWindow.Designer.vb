<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGameWindow
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGameWindow))
        Me.tmrTick = New System.Windows.Forms.Timer(Me.components)
        Me.cmdStartGame = New System.Windows.Forms.Button()
        Me.lblScore = New System.Windows.Forms.Label()
        Me.lblQuit = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'tmrTick
        '
        Me.tmrTick.Interval = 500
        '
        'cmdStartGame
        '
        Me.cmdStartGame.Font = New System.Drawing.Font("Microsoft YaHei", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdStartGame.Location = New System.Drawing.Point(12, 119)
        Me.cmdStartGame.Name = "cmdStartGame"
        Me.cmdStartGame.Size = New System.Drawing.Size(474, 288)
        Me.cmdStartGame.TabIndex = 2
        Me.cmdStartGame.Text = "START GAME"
        Me.cmdStartGame.UseVisualStyleBackColor = True
        '
        'lblScore
        '
        Me.lblScore.AutoSize = True
        Me.lblScore.BackColor = System.Drawing.Color.Olive
        Me.lblScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScore.ForeColor = System.Drawing.SystemColors.MenuText
        Me.lblScore.Location = New System.Drawing.Point(12, 585)
        Me.lblScore.Name = "lblScore"
        Me.lblScore.Size = New System.Drawing.Size(279, 73)
        Me.lblScore.TabIndex = 3
        Me.lblScore.Text = "Score: 0"
        '
        'lblQuit
        '
        Me.lblQuit.AutoSize = True
        Me.lblQuit.Font = New System.Drawing.Font("Microsoft YaHei", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuit.Location = New System.Drawing.Point(428, 585)
        Me.lblQuit.Name = "lblQuit"
        Me.lblQuit.Size = New System.Drawing.Size(58, 28)
        Me.lblQuit.TabIndex = 4
        Me.lblQuit.Text = "Quit"
        '
        'frmGameWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(498, 667)
        Me.Controls.Add(Me.lblQuit)
        Me.Controls.Add(Me.lblScore)
        Me.Controls.Add(Me.cmdStartGame)
        Me.Name = "frmGameWindow"
        Me.Text = "Tetris: Return to Monke"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tmrTick As Timer
    Friend WithEvents cmdStartGame As Button
    Friend WithEvents lblScore As Label
    Friend WithEvents lblQuit As Label
End Class
