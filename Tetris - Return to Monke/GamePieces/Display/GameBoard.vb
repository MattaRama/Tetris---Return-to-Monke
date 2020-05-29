Imports System.Threading
''' <summary>
''' GameBoard for the TetrisGroups
''' </summary>
Public Class GameBoard

    Dim picDisplay As List(Of TetrisRow) = New List(Of TetrisRow) ' List for the display rows, X and Y

    ''' <summary>
    ''' Generates an array of picture boxes
    ''' </summary>
    Public Sub GeneratePicBoard(ByRef gameWindow As frmGameWindow)

        'Fills display rows
        For i As Integer = 0 To 17

            Console.WriteLine("GameBoard: Generating gamerow " & i + 1 & " of 18")
            picDisplay.Add(New TetrisRow(15, i))

        Next i

    End Sub

    ''' <summary>
    ''' Gets the (x, y) of a cell
    ''' </summary>
    ''' <param name="cell"></param>
    ''' <returns>Pair of coordinates from GameBoard, returned as a KeyValuePair</returns>
    Public Function GetCellPosition(cell As TetrisCell) As KeyValuePair(Of Integer, Integer)

        'Checks all rows
        For i As Integer = 0 To 17

            'Checks all cells
            For j As Integer = 0 To 14

                'If cell matches, returns position in a KeyValuePair
                If picDisplay(i).GetCellAtPosition(j).Equals(cell) Then

                    Return New KeyValuePair(Of Integer, Integer)(i, j)

                End If

            Next j

        Next i

        'Nothing was found. Probably going to cause problems if this happens
        Return Nothing

    End Function

End Class
