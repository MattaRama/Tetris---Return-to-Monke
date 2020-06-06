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
    ''' Checks if the cube can be translated to a different position relative to the cube without interacting with another cube
    ''' </summary>
    Public Function CanTranslateBy(x As Integer, y As Integer) As Boolean

        'Gets position
        Dim pos As KeyValuePair(Of Integer, Integer) = SharedResources.gameWindow.board.GetCellPosition(Me)

        'Checks if it is at a border
        If pos.Key <= 0 And x < 0 Then

            Return False

        End If

        If pos.Key >= 14 And x > 0 Then

            Return False

        End If

        If pos.Value >= 17 And y > 0 Then

            Return False

        End If

        'Adds values to position
        pos = New KeyValuePair(Of Integer, Integer)(pos.Key + x, pos.Value + y)

        'Checks if position is occupied
        If SharedResources.gameWindow.board.GetCubeAtCoordinate(pos) Is Nothing Then

            Return True

        End If

        If SharedResources.gameWindow.board.GetCubeAtCoordinate(pos).group.Equals(group) Then

            Return True

        End If

        Return False

    End Function

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
            If Not group.Equals(SharedResources.gameWindow.board.GetCubeAtCoordinate(New KeyValuePair(Of Integer, Integer)(pos.Key, pos.Value + 1)).group) Then

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
