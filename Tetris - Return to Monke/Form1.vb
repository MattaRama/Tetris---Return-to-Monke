'Matthew R
'Final Project
'Tetris: Return to Monke

''' <summary>
''' The main form, housing the start screen and links to the other forms
''' </summary>
Public Class frmReturnToMonke

    'Sends data to the game form and starts the form
    Private Sub cmdStartGame_Click(sender As Object, e As EventArgs) Handles cmdStartGame.Click

        SharedResources.gameWindow.Show()
        Hide()

    End Sub

    'Opens settings form
    Private Sub cmdSettings_Click(sender As Object, e As EventArgs) Handles cmdSettings.Click

    End Sub

    'Form Load
    Private Sub frmReturnToMonke_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Loads the high score board
        FileOpen(1, "highScores.txt", OpenMode.Input)

        Dim highScores(2) As String

        Dim i As Integer = 0
        While Not EOF(1)

            Input(1, highScores(i))
            i += 1

        End While

        FileClose()

        lblHighestScore.Text = "1st Place High Score: " & highScores(0) & Environment.NewLine & "2nd Place High Score: " & highScores(1) & Environment.NewLine & "3rd Place High Score: " & highScores(2)

    End Sub

End Class

Public Module SharedResources

    Public gameWindow As frmGameWindow = New frmGameWindow()

End Module