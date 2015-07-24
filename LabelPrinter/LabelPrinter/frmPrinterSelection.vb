Option Explicit On
Option Strict On
Option Infer Off

Public Class frmPrinterSelection

    Private selectedPrinter As String = String.Empty
    Private cancelled As Boolean = False

    Public Function GetPrinter(currentPrinter As String, ByRef userCancelled As Boolean) As String

        'Fill the combo box
        Fill_PrinterCombo()

        'If the currentPrinter is listed in the combo box, select that, otherwise, select the default printer
        SelectPrinter(currentPrinter)

        'so the form to the user modally
        Me.ShowDialog()

        'return the selected printer and indicate if the user cancelled
        userCancelled = cancelled
        Return selectedPrinter

    End Function

    Private Sub SelectPrinter(printerName As String)
        Dim bFound As Boolean = False
        For Each printer As String In cboPrinterList.Items
            If printer = printerName Then
                cboPrinterList.SelectedItem = printer
                bFound = True
                Exit For
            End If
        Next
        If Not bFound Then
            Dim defaultPrinter As New System.Drawing.Printing.PrinterSettings
            cboPrinterList.SelectedItem = defaultPrinter.PrinterName
        End If
    End Sub

    Private Sub Fill_PrinterCombo()
        cboPrinterList.Items.Clear()
        For Each printer As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            cboPrinterList.Items.Add(printer)
        Next
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        cancelled = True
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        selectedPrinter = cboPrinterList.SelectedItem.ToString
        Me.Close()
    End Sub
End Class