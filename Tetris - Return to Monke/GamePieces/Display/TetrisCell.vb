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
        If cube.Equals(Nothing) Then

            activeCube = Nothing ' Just in case

            BackColor = Color.Transparent
            Image = Nothing

            Return

        End If

        'Updates display. Support for both solid color tetris and image tetris
        BackColor = cube.BackColor
        Image = cube.Image

    End Sub

    'IF USING .EQUALS OVERRIDE, CALL SUPERCONSTRUCTOR!!!!

End Class
