''' <summary>
''' Tetris 
''' </summary>
Public Class TetrisCell
    Inherits PictureBox

    Dim activeCube As TetrisCube

    Public Sub SetCubeDisplay(cube As TetrisCube)

        'Sets active cube
        activeCube = cube

        'If the cube is null, then extra actions will be taken
        If cube Is Nothing Then

            activeCube = Nothing ' Just in case

            BackColor = Color.Transparent
            Image = Nothing

            Return

        End If

        'Updates display. Support for both solid color tetris and image tetris
        BackColor = cube.BackColor
        Image = cube.Image

    End Sub

    ''' <summary>
    ''' Checks if this cell contains a TetrisCube or not
    ''' </summary>
    Public Function ContainsCube() As Boolean

        Return activeCube Is Nothing

    End Function

    ''' <summary>
    ''' Gets the activeCube of this cell
    ''' </summary>
    Public Function GetCube() As TetrisCube

        Return activeCube

    End Function

    'IF USING .EQUALS OVERRIDE, CALL SUPERCONSTRUCTOR!!!!

End Class
