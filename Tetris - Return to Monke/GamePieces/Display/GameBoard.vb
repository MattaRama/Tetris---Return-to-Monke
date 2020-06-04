Imports System.CodeDom.Compiler
Imports System.Threading
''' <summary>
''' GameBoard for the TetrisGroups
''' </summary>
Public Class GameBoard

    Dim boardCollection As List(Of TetrisRow) = New List(Of TetrisRow) ' List for the display rows, X and Y
    Shared usedCubeIds As List(Of Integer) = New List(Of Integer) ' List of used cubeIDs
    Public groups As List(Of TetrisGroup) = New List(Of TetrisGroup) ' List of TetrisGroups

    ''' <summary>
    ''' Generates an array of picture boxes
    ''' </summary>
    Public Sub GeneratePicBoard(ByRef gameWindow As frmGameWindow)

        'Fills display rows
        For i As Integer = 0 To 17

            Console.WriteLine("GameBoard: Generating gamerow " & i + 1 & " of 18")
            boardCollection.Add(New TetrisRow(15, i))

        Next i

    End Sub

    ''' <summary>
    ''' Gets the (x, y) of a cell
    ''' </summary>
    ''' <param name="cell"></param>
    ''' <returns>Pair of coordinates from GameBoard, returned as a KeyValuePair</returns>
    Public Function GetCellPosition(cell As TetrisCube) As KeyValuePair(Of Integer, Integer)

        'Checks all rows
        For i As Integer = 0 To 17

            'Checks all cells
            For j As Integer = 0 To 14

                Dim cellCube As TetrisCube = boardCollection(i).GetCellAtPosition(j).GetCube()

                'If cell is null, doesnt run
                If Not cellCube Is Nothing Then

                    'If cell matches, returns position in a KeyValuePair
                    If cell.Equals(cellCube) Then

                        Return New KeyValuePair(Of Integer, Integer)(j, i)

                    End If

                End If

            Next j

        Next i

        Throw New Exception("Something went really wrong here. Very very wrong.")
        Return Nothing

    End Function

    ''' <summary>
    ''' Assigns a particular TetrisCube to a new Cell
    ''' </summary>
    ''' <param name="position">The position of the cell, as (x, y)</param>
    ''' <param name="cube">The TetrisCube instance</param>
    Public Sub AssignCubeToCell(position As KeyValuePair(Of Integer, Integer), cube As TetrisCube)

        boardCollection(position.Value).GetCellAtPosition(position.Key).SetCubeDisplay(cube)

    End Sub

    ''' <summary>
    ''' Gets the cube at a particular cell
    ''' </summary>
    ''' <param name="position">The position of the cell</param>
    ''' <returns></returns>
    Public Function GetCubeAtCoordinate(position As KeyValuePair(Of Integer, Integer)) As TetrisCube

        Return boardCollection(position.Value).GetCellAtPosition(position.Key).GetCube()

    End Function

    ''' <summary>
    ''' Generates a random cubeID
    ''' </summary>
    Public Shared Function GenerateCubeId() As Integer

        'Loops until a new ID is created
        While True

            'Generates random number in range 0-999
            Call Randomize()
            Dim cubeID As Integer = Int(1000 * Rnd())

            'Generates new ID if it is already taken
            For Each id In usedCubeIds

                If cubeID = id Then

                    Continue While

                End If

            Next id

            Return cubeID

        End While

        Return False ' Not needed for the code to function, but I didn't like Visual Studio thinking there was an error

    End Function

End Class
