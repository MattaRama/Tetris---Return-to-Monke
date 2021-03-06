﻿Imports System.Security.Cryptography.X509Certificates
Imports System.Threading
''' <summary>
''' A collection of TetrisCells
''' </summary>
Public Class TetrisRow

    Dim cellCollection As List(Of TetrisCell) = New List(Of TetrisCell)
    Public rowNumber As Integer

    Public Sub New(rowSize As Integer, rowNumber As Integer)

        'Generates all cells
        GenerateCells(rowSize, rowNumber)
        Me.rowNumber = rowNumber

    End Sub

    ''' <summary>
    ''' A method for generating a row of tetris cells
    ''' </summary>
    ''' <param name="rowSize">The count of tetris cells. Basically always 15</param>
    ''' <param name="rowNumber">The position of the row, particularly as a 1d count</param>
    Sub GenerateCells(rowSize As Integer, rowNumber As Integer)

        'Generates cells
        For i As Integer = 0 To rowSize - 1

            'DEBUG
            Console.WriteLine("TetrisRow: Generating cell " & i + 1 & " of 15 on row " & rowNumber)

            'Creates cell
            cellCollection.Add(New TetrisCell())

            'Configures
            cellCollection(i).Left = 25 + (i * 30) ' X Position
            cellCollection(i).Top = 18 + (rowNumber * 30) ' Y Position

            cellCollection(i).Height = 30 ' Height
            cellCollection(i).Width = 30 ' Width

            cellCollection(i).Visible = True ' Visibility
            cellCollection(i).BackColor = Color.Transparent ' Debug
            cellCollection(i).BorderStyle = BorderStyle.FixedSingle ' Border Style

            'Adds to form controls
            SharedResources.gameWindow.Controls.Add(cellCollection(i))

            'Thread.Sleep(10) ' Just because I like looking at the console fill up over time

        Next i

    End Sub

    ''' <summary>
    ''' Gets a cell at a certain position
    ''' </summary>
    ''' <param name="position">The position in the array</param>
    ''' <returns>The cell at a position in the collection</returns>
    Public Function GetCellAtPosition(position As Integer) As TetrisCell

        Return cellCollection(position)

    End Function

    ''' <summary>
    ''' Clears the row of TetrisCube
    ''' </summary>
    Public Sub Clear()

        'Sets all cells to house nothing
        For Each cell In cellCollection

            cell.SetCubeDisplay(Nothing)

        Next

    End Sub


    ''' <summary>
    ''' Inherits
    ''' </summary>
    Public Sub Inherit(row As TetrisRow)

        'Inherits cubes
        For i As Integer = 0 To 8

            cellCollection(i).SetCubeDisplay(row.cellCollection(i).GetCube())

        Next

    End Sub


    Public Function RowComplete() As Boolean

        'Checks all cells
        For Each c In cellCollection

            'If any cell is empty, the row is not full
            If c.ContainsCube() Then

                Return False

            End If

        Next c

        'No cells are full, so the row is full
        Return True

    End Function

End Class
