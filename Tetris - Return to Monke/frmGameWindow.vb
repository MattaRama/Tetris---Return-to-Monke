''' <summary>
''' The game window
''' </summary>
Public Class frmGameWindow

    Public board As GameBoard = New GameBoard()

    Private Sub frmGameWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Generates GameBoard
        board.GeneratePicBoard(Me)

        'Starts game
        tmrTick.Enabled = False

    End Sub

    ''' <summary>
    ''' A global game timer, running periodic commands every tick
    ''' </summary>
    Private Sub tmrTick_Tick(sender As Object, e As EventArgs) Handles tmrTick.Tick

        TranslateDown() 'Translates groups down

    End Sub

    ''' <summary>
    ''' Translates all groups on the board down
    ''' </summary>
    Sub TranslateDown()

        'Groups to be removed after
        Dim toBeRemoved As List(Of TetrisGroup) = New List(Of TetrisGroup)

        'Translates groups down
        For Each group In board.groups

            'Translates group down
            group.Translate(0, 1)

            'Disbands group if it is locked
            If group.IsLocked() Then

                toBeRemoved.Add(group)

            End If

        Next group

        'Removes locked groups
        For Each group In toBeRemoved

            board.groups.Remove(group)

        Next group

    End Sub




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'Creates a testing group
        Dim t1 As TetrisCube = New TetrisCube()
        Dim t2 As TetrisCube = New TetrisCube()
        Dim t3 As TetrisCube = New TetrisCube()
        Dim t4 As TetrisCube = New TetrisCube()

        t1.BackColor = Color.Blue
        t2.BackColor = Color.Green
        t3.BackColor = Color.Blue
        t4.BackColor = Color.Green

        board.AssignCubeToCell(New KeyValuePair(Of Integer, Integer)(2, 5), t1)
        board.AssignCubeToCell(New KeyValuePair(Of Integer, Integer)(2, 4), t2)
        board.AssignCubeToCell(New KeyValuePair(Of Integer, Integer)(2, 3), t3)
        board.AssignCubeToCell(New KeyValuePair(Of Integer, Integer)(2, 2), t4)

        Dim tlist As List(Of TetrisCube) = New List(Of TetrisCube)

        tlist.Add(t1)
        tlist.Add(t2)
        tlist.Add(t3)
        tlist.Add(t4)

        board.groups.Add(New TetrisGroup(tlist))

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        tmrTick.Enabled = True

    End Sub
End Class