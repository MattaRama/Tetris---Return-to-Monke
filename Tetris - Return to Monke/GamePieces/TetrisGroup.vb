Imports System.Runtime.InteropServices.WindowsRuntime
''' <summary>
''' Creates and keeps track of groups of TetrisCubes
''' </summary>
Public Class TetrisGroup

    Dim cubes As List(Of TetrisCube)
    Dim locked As Boolean = False

    ''' <summary>
    ''' Constructor
    ''' </summary>
    Public Sub New(cubesToImport As List(Of TetrisCube))

        cubes = cubesToImport

    End Sub

    ''' <summary>
    ''' Creates a TetrisGroup, doing all of the hard work
    ''' </summary>
    ''' <param name="cubes">The individual cubes for the TetrisGroup</param>
    ''' <returns>The TetrisGroup</returns>
    Public Shared Function CreateTetrisGroup(ParamArray cubes() As TetrisCube) As TetrisGroup

        'Creates list of TetrisCubes
        Dim tlist As List(Of TetrisCube) = New List(Of TetrisCube)

        For Each cube In cubes

            tlist.Add(cube)

        Next cube

        'Constructs
        Dim groupFinal As TetrisGroup = New TetrisGroup(tlist)

        'Distributes group
        For Each cube In cubes

            cube.group = groupFinal

        Next

        'Returns
        Return groupFinal

    End Function

    ''' <summary>
    ''' Creates a TetrisGroup, doing all of the hard work
    ''' </summary>
    ''' <param name="tlist">The individual cubes for the TetrisGroup</param>
    ''' <returns>The TetrisGroup</returns>
    Public Shared Function CreateTetrisGroup(tlist As List(Of TetrisCube)) As TetrisGroup

        'Constructs
        Dim groupFinal As TetrisGroup = New TetrisGroup(tlist)

        'Distributes group
        For Each cube In tlist

            cube.group = groupFinal

        Next

        'Returns
        Return groupFinal

    End Function


    ''' <returns>locked</returns>
    Public Function IsLocked() As Boolean

        'Checks all cubes for lock
        Dim shouldLock As Boolean = False

        For Each cube In cubes

            If cube.ShouldLock(cube.GetLocation()) Then

                shouldLock = True

            End If

        Next cube

        'Locks all cubes if they should be locked
        If shouldLock Then

            For Each cube In cubes

                cube.Lock()

            Next

        End If

        'Returns locked statement
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
