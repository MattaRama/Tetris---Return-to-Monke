''' <summary>
''' The game window
''' </summary>
Public Class frmGameWindow

    Dim board As GameBoard = New GameBoard()

    Private Sub frmGameWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Generates GameBoard
        board.GeneratePicBoard(Me)

        'Starts game
        tmrUpdateTimer.Enabled = True

    End Sub

    ''' <summary>
    ''' A consistent timer, representing 
    ''' </summary>
    Private Sub tmrUpdateTimer_Tick(sender As Object, e As EventArgs) Handles tmrUpdateTimer.Tick



    End Sub
End Class