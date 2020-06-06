Public Class frmSettings

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Adds all pieces
        clbEnabledPieces.Items.Add("2x2 Cube", True)
        clbEnabledPieces.Items.Add("Right-skew L", True)
        clbEnabledPieces.Items.Add("Left-skew L", True)
        clbEnabledPieces.Items.Add("Right-skew Z", True)
        clbEnabledPieces.Items.Add("Left-skew Z", True)
        clbEnabledPieces.Items.Add("Straight Line", True)
        clbEnabledPieces.Items.Add("T", True)

    End Sub

    Private Sub cmdUpdatePieces_Click(sender As Object, e As EventArgs) Handles cmdUpdatePieces.Click

        'Updates all pieces
        For i As Integer = 0 To Pieces.enabledArray.Length - 1

            enabledArray(i) = clbEnabledPieces.GetItemChecked(i)

        Next

        SendDialog()

    End Sub


    Sub SendDialog()

        'Sends a setting chaned dialog
        MessageBox.Show("Setting Changed Successfully.", "Update")

    End Sub
End Class