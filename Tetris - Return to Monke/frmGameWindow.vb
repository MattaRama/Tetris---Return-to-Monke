''' <summary>
''' The game window
''' </summary>
Public Class frmGameWindow

    Public board As GameBoard = New GameBoard()
    Dim totalPoints As Integer = -10

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
            Console.WriteLine("Translating down")
            group.canTranslate = False
            group.Translate(0, 1)
            group.canTranslate = True

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

        AwardPoints(10)

        'Checks to see for full rows. If they are full, the row is cleared and points are added
        For i As Integer = 17 To 0 Step -1

            Dim row As TetrisRow = board.GetRow(i)

            If row.RowComplete() Then

                board.CompleteRow(row)
                i += 1

            End If

        Next

        'Grabs a configuration
        Dim cubeConfig As Point() = Pieces.GetRandomPiece()
        Dim color = GetRandomColor()

        'Creates cubes
        Dim cubes As List(Of TetrisCube) = New List(Of TetrisCube)

        For i As Integer = 0 To cubeConfig.Length - 1

            'Creates Cube
            cubes.Add(New TetrisCube())

            'Configures cube
            cubes(i).BackColor = color
            board.AssignCubeToCell(New KeyValuePair(Of Integer, Integer)(cubeConfig(i).X, cubeConfig(i).Y), cubes(i))

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

        'Stops keypresses if there are no active game pieces. Prevents an error.
        If board.groups.Count = 0 Then

            Return

        End If

        'Move pieces left
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.A Then

            For Each group In board.groups

                'Translates group down
                If group.canTranslate And group.CanTranslateBy(-1, 0) Then

                    Console.WriteLine("Translating Left")
                    group.Translate(-1, 0)

                End If

            Next group

        End If

        'Moves pieces right
        If e.KeyCode = Keys.Right Or e.KeyCode = Keys.D Then

            For Each group In board.groups

                'Translates group down
                If group.canTranslate And group.CanTranslateBy(1, 0) Then

                    Console.WriteLine("Translating Right")
                    group.Translate(1, 0)

                End If

            Next group

        End If

        'Moves pieces down
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.S Then

            For Each group In board.groups

                'Translates group down
                If group.canTranslate And group.CanTranslateBy(0, 1) Then

                    Console.WriteLine("Translating Down")
                    group.Translate(0, 1)

                End If

            Next group

        End If



        'Checks for cube locking
        Dim toBeRemoved As List(Of TetrisGroup) = New List(Of TetrisGroup)

        'Translates groups down
        For Each group In board.groups

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


    ''' <summary>
    ''' Button for starting the game
    ''' </summary>
    Private Sub cmdStartGame_Click(sender As Object, e As EventArgs) Handles cmdStartGame.Click

        'Makes game piece
        CreateNewPiece()

        'Starts Timer
        tmrTick.Enabled = True

        'Removes button
        sender.Enabled = False
        sender.Visible = False

    End Sub

    ''' <summary>
    ''' Appends the points variable by a certain quantity
    ''' </summary>
    ''' <param name="quantity">Amount to append</param>
    ''' <returns>Current point count</returns>
    Public Function AwardPoints(quantity As Integer) As Integer

        totalPoints += quantity

        lblScore.Text = "Points: " & totalPoints

        Return totalPoints

    End Function

    Private Sub lblQuit_Click(sender As Object, e As EventArgs) Handles lblQuit.Click



    End Sub
End Class

''' <summary>
''' I was going to use an enum for this but I didn't know they dont support classes or non-elementary data types.
''' Codes for all of the pieces and the formation of those pieces
''' </summary>
''' TODO: UPDATE THIS TO USE FILES FOR STORAGE AS OPPOSED TO HARD CODING
''' MAYBE TODO: Fix implicit declarations. Not a problem, but possibly something that could be better.
Module Pieces

    Public ReadOnly piece1 = {New Point(1, 1), New Point(1, 0), New Point(0, 1), New Point(0, 0)} ' 2x2 
    Public ReadOnly piece2 = {New Point(0, 1), New Point(2, 0), New Point(1, 0), New Point(0, 0)} ' Right-skew L
    Public ReadOnly piece3 = {New Point(2, 1), New Point(2, 0), New Point(1, 0), New Point(0, 0)} ' Left-skew L
    Public ReadOnly piece4 = {New Point(1, 1), New Point(0, 1), New Point(2, 0), New Point(1, 0)} ' Right-skew Z
    Public ReadOnly piece5 = {New Point(2, 1), New Point(1, 1), New Point(1, 0), New Point(0, 0)} ' Left-skew Z
    Public ReadOnly piece6 = {New Point(0, 2), New Point(0, 1), New Point(0, 0)} ' Straight line
    Public ReadOnly piece7 = {New Point(2, 1), New Point(1, 1), New Point(0, 1), New Point(1, 0)} ' T Shape

    Public piece1Enabled As Boolean = True
    Public piece2Enabled As Boolean = True
    Public piece3Enabled As Boolean = True
    Public piece4Enabled As Boolean = True
    Public piece5Enabled As Boolean = True
    Public piece6Enabled As Boolean = True
    Public piece7Enabled As Boolean = True

    Public enabledArray As Boolean() = {piece1Enabled, piece2Enabled, piece3Enabled, piece4Enabled, piece5Enabled, piece6Enabled, piece7Enabled}
    Public ReadOnly piecesRaw = {piece1, piece2, piece3, piece4, piece5, piece6, piece7}

    ''' <summary>
    ''' Returns a random piece
    ''' </summary>
    ''' <returns></returns>
    Public Function GetRandomPiece()

        'Creates a list of all pieces
        'Filters out disabled pieces
        Dim allPieces As List(Of Point()) = New List(Of Point())


        For i As Integer = 0 To 6

            If enabledArray(i) Then

                allPieces.Add(piecesRaw(i))

            End If

        Next i

        'Random num gen. Picks a random piece from the list
        Call Randomize()
        Dim num As Integer = Int(Rnd() * allPieces.Count)

        'Returns random piece
        Return allPieces(num)

    End Function

End Module