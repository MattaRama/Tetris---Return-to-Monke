''' <summary>
''' A class for displaying and keeping track of the different cubes on the screen
''' </summary>
Public Class TetrisCube
    Inherits PictureBox

    Dim locked As Boolean = False
    Public cubeID As Integer
    Public group As TetrisGroup

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
    Function ShouldLock(pos As KeyValuePair(Of Integer, Integer)) As Boolean

        'Checks for bottom position
        If pos.Value = 17 Then

            Return True

        End If

        'Checks for block below
        If Not SharedResources.gameWindow.board.GetCubeAtCoordinate(New KeyValuePair(Of Integer, Integer)(pos.Key, pos.Value + 1)) Is Nothing Then

            'Checks if the block below is part of the same group
            If Not SharedResources.gameWindow.board.GetCubeAtCoordinate(New KeyValuePair(Of Integer, Integer)(pos.Key, pos.Value + 1)).group.Equals(group) Then

                Return True

            End If

        End If

        'Should not lock
        Return False

    End Function

    ''' <summary>
    ''' Gets the location of this particular cube
    ''' </summary>
    Function GetLocation() As KeyValuePair(Of Integer, Integer)

        Return SharedResources.gameWindow.board.GetCellPosition(Me)

    End Function

    Public Overrides Function Equals(obj As Object) As Boolean

        'Checks if the object being compared is actually a TetrisCube
        If Not obj.GetType = GetType(TetrisCube) Then

            Return False

        End If

        'If the cubeIDs match, the cubes are the same
        Return cubeID = obj.cubeID

    End Function

End Class
