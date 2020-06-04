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

        Button1.Enabled = True

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

        'Creates a new piece one one has been created
        If toBeRemoved.Count <> 0 Then

            CreateNewPiece()

        End If

    End Sub


    Sub CreateNewPiece()

        'Grabs a configuration
        Dim cubeConfig As Integer(,) = Pieces.GetRandomPiece()
        Dim color = GetRandomColor()

        'Creates cubes
        Dim cubes As List(Of TetrisCube) = New List(Of TetrisCube)

        For i As Integer = 0 To cubeConfig.length - 1

            'Creates Cube
            cubes.Add(New TetrisCube())

            'Configures cube
            cubes(i).BackColor = color
            Console.WriteLine(i & " : " & cubeConfig(i, 0))
            board.AssignCubeToCell(New KeyValuePair(Of Integer, Integer)(cubeConfig(i, 0), cubeConfig(i, 1)), cubes(i))

        Next i

        'Creates TetrisGroup
        Dim group = TetrisGroup.CreateTetrisGroup(cubes)

        'Passes out group 
        For Each cube In cubes

            cube.group = group

        Next cube

        'Finalizes group and assigns to board
        board.groups.Add(group)

    End Sub

    Function GetRandomColor() As Color

        'Picks a random number
        Call Randomize()
        Dim num As Integer = Int(Rnd() * 6)

        'Picks a random color
        Select Case num

            Case 0
                Return Color.Red
            Case 1
                Return Color.Orange
            Case 2
                Return Color.Yellow
            Case 3
                Return Color.Green
            Case 4
                Return Color.Blue
            Case 5
                Return Color.Purple

        End Select

    End Function

    ''' <summary>
    ''' Keydown detection
    ''' </summary>
    Private Sub frmGameWindow_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        Console.WriteLine("Keypress")

        'Move pieces left
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.A Then

            For Each group In board.groups

                'Translates group down
                group.Translate(-1, 0)

            Next group

        End If

        'Moves pieces right
        If e.KeyCode = Keys.Right Or e.KeyCode = Keys.D Then

            For Each group In board.groups

                'Translates group down
                group.Translate(1, 0)

            Next group

        End If

    End Sub




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        CreateNewPiece()

        '<DEPRICATED>
        'Creates a testing group
        'Dim t1 As TetrisCube = New TetrisCube()
        'Dim t2 As TetrisCube = New TetrisCube()
        'Dim t3 As TetrisCube = New TetrisCube()
        'Dim t4 As TetrisCube = New TetrisCube()

        't1.BackColor = GetRandomColor()
        't2.BackColor = GetRandomColor()
        't3.BackColor = GetRandomColor()
        't4.BackColor = GetRandomColor()

        'board.AssignCubeToCell(New KeyValuePair(Of Integer, Integer)(2, 5), t1)
        'board.AssignCubeToCell(New KeyValuePair(Of Integer, Integer)(2, 4), t2)
        'board.AssignCubeToCell(New KeyValuePair(Of Integer, Integer)(2, 3), t3)
        'board.AssignCubeToCell(New KeyValuePair(Of Integer, Integer)(2, 2), t4)

        'board.groups.Add(TetrisGroup.CreateTetrisGroup(t1, t2, t3, t4))

        'sender.Enabled = False
        '</DEPRICATED>

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        tmrTick.Enabled = True
        sender.Enabled = False

    End Sub

End Class

''' <summary>
''' I was going to use an enum for this but I didn't know they dont support classes or non-elementary data types.
''' Codes for all of the pieces and the formation of those pieces
''' </summary>
''' TODO: UPDATE THIS TO USE FILES FOR STORAGE AS OPPOSED TO HARD CODING
''' MAYBE TODO: Fix implicit declarations. Not a problem, but possibly something that I could fix.
Class Pieces

    Public Shared ReadOnly piece1 = {{1, 1}, {1, 0}, {0, 1}, {0, 0}} ' 2x2
    Public Shared ReadOnly piece2 = {{0, 1}, {2, 0}, {1, 0}, {0, 0}} ' Right-skew L
    Public Shared ReadOnly piece3 = {{2, 1}, {2, 0}, {1, 0}, {0, 0}} ' Left-skew L
    Public Shared ReadOnly piece4 = {{1, 1}, {0, 1}, {2, 0}, {1, 0}} ' Right-skew Z
    Public Shared ReadOnly piece5 = {{2, 1}, {1, 1}, {1, 0}, {0, 0}} ' Left-skew Z
    Public Shared ReadOnly piece6 = {{0, 2}, {0, 1}, {0, 0}} ' Straight line
    Public Shared ReadOnly piece7 = {{2, 1}, {1, 1}, {0, 1}, {1, 0}} ' T Shape

    ''' <summary>
    ''' Returns a random piece
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetRandomPiece()

        'Random num gen
        Call Randomize()
        Dim num As Integer = Int(Rnd() * 7)

        'Pics random piece and returns
        Dim allPieces = {piece1, piece2, piece3, piece4, piece5, piece6, piece7}

        Return allPieces(num)

    End Function

End Class