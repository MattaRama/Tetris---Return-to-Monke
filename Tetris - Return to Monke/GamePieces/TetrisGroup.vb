''' <summary>
''' Creates and keeps track of groups of TetrisCubes
''' </summary>
Public Class TetrisGroup

    Dim cubes As List(Of TetrisCube)
    Dim locked As Boolean = False

    Public Sub New(cubesToImport As List(Of TetrisCube))

        cubes = cubesToImport

    End Sub

    Public Function IsLocked() As Boolean

        Return locked

    End Function

    Public Sub Translate(x As Integer, y As Integer)

        'Translates all cubes
        For Each cube In cubes

            cube.Translate(x, y)

        Next cube

        'Check each one for it's lock status
        'If any one of them is locked, all of them will be locked
        For Each cube In cubes

            'Checks if any cubes are locked
            If cube.IsLocked() Then

                locked = True

                'Locks all cubes
                For Each toLock In cubes

                    toLock.Lock()

                Next toLock

                Exit For ' Breaks for loop, for optimization

            End If

        Next

    End Sub

End Class
