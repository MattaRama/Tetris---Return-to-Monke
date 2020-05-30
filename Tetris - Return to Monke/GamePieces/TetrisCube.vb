''' <summary>
''' A class for displaying and keeping track of the different cubes on the screen
''' </summary>
Public Class TetrisCube
    Inherits PictureBox

    Dim locked As Boolean = False
    Public cubeID As Integer

    ''' <summary>
    ''' Constructor
    ''' </summary>
    Public Sub New()

        cubeID = GameBoard.GenerateCubeId()

    End Sub

    ''' <summary>
    ''' Translates the Cube to a different cell if possible
    ''' </summary>
    ''' <param name="x">Amount to translate "left" value by</param>
    ''' <param name="y">Amount to translate "top" value by</param>
    Public Sub Translate(x As Integer, y As Integer)

        'Checks if cube is locked
        If locked = True Then

            Return

        End If

        'Gets position of the cube
        Dim pos As KeyValuePair(Of Integer, Integer) = SharedResources.gameWindow.board.GetCellPosition(Me)

        'Removes from current cell
        SharedResources.gameWindow.board.AssignCubeToCell(pos, Nothing)

        'Sets new position of the cube 
        pos = New KeyValuePair(Of Integer, Integer)(pos.Key + x, pos.Value + y)
        SharedResources.gameWindow.board.AssignCubeToCell(pos, Me)

        'Checks if cube should be locked
        ShouldLock(pos)

    End Sub

    ''' <summary>
    ''' Locks the cube 
    ''' </summary>
    Public Sub Lock()

        locked = True

    End Sub

    ''' <summary>
    ''' Returns the locked status of this cube
    ''' </summary>
    Public Function IsLocked() As Boolean

        Return locked

    End Function

    ''' <summary>
    ''' Checks if the TetrisCube should lock or not
    ''' </summary>
    Sub ShouldLock(pos As KeyValuePair(Of Integer, Integer))

        'Checks for bottom position
        If pos.Value = 17 Then

            Lock()
            Return

        End If

        'Checks for block below
        If Not SharedResources.gameWindow.board.GetCubeAtCoordinate(New KeyValuePair(Of Integer, Integer)(pos.Key, pos.Value + 1)) Is Nothing Then

            Lock()
            Return

        End If

    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean

        'Checks if the object being compared is actually a TetrisCube
        If Not obj.GetType = GetType(TetrisCube) Then

            Return False

        End If

        'If the cubeIDs match, the cubes are the same
        Return cubeID = obj.cubeID

    End Function

End Class
