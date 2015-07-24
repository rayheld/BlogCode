Option Explicit On
Option Strict On
Option Infer Off

Imports System.IO
Imports System.Text

Public Class frmManualPrint

    Private LabelTemplate As ZPLTemplate
    Private isLoading As Boolean = True
    Private controlSequence As New List(Of Control)

    Private Sub ConfigureControls()
        Dim oldControls As New Stack(Of Control)
        For Each c As Control In pbControls.Controls
            oldControls.Push(c)
        Next
        Do Until oldControls.Count = 0
            DirectCast(oldControls.Pop, Control).Dispose()
        Loop

        controlSequence.Clear()

        Dim last_y As Int32 = 10
        Dim tabIndex As Int32 = 9
        For Each s As String In LabelTemplate.FieldList.Keys
            Dim l As New Label
            Dim t As New TextBox
            Dim c As New CheckBox
            Dim n As String = s.Replace("[", String.Empty).Replace("]", String.Empty)

            l.Name = String.Format("lblField_{0}", n)
            l.Text = n
            l.Parent = pbControls
            l.Location = New System.Drawing.Point(0, last_y)
            l.Anchor = CType(AnchorStyles.Top Or AnchorStyles.Left, AnchorStyles)

            t.Name = String.Format("txtField_{0}", n)
            t.Tag = s
            t.Parent = pbControls
            t.Location = New System.Drawing.Point(150, last_y)
            t.Width = pbControls.Width - 155 - 120
            t.Anchor = CType(AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top, AnchorStyles)
            tabIndex += 1
            t.TabIndex = tabIndex
            AddHandler t.GotFocus, AddressOf GotFocus_Handler
            controlSequence.Add(t)

            c.Name = String.Format("chkField_{0}", n)
            c.Tag = s
            c.Text = "Persist Data"
            c.Parent = pbControls
            c.Location = New System.Drawing.Point(t.Location.X + t.Width + 5, last_y - 2)
            c.Anchor = CType(AnchorStyles.Top Or AnchorStyles.Right, AnchorStyles)
            tabIndex += 1
            t.TabIndex = tabIndex

            last_y += t.Height + 5
        Next

        tabIndex += 1
        btnPrint.TabIndex = tabIndex

    End Sub

    Private Sub GotFocus_Handler(sender As Object, e As EventArgs)
        DirectCast(sender, TextBox).SelectAll()
    End Sub

    Private Function GetSettingList(baseDirectory As String) As List(Of String)
        Dim fileList As New List(Of String)

        Try
            For Each s As String In Directory.GetFiles(baseDirectory, "*.set")
                fileList.Add(s)
            Next
        Catch ex As Exception
            MessageBox.Show(String.Format("Error reading the printer setting file list: {0}", ex.Message), "Error Getting Setting List", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return fileList
    End Function

    Private Sub SelectFile(filePath As String)
        Using sr As New StreamReader(filePath)
            LabelTemplate = New ZPLTemplate(sr.ReadToEnd)
        End Using
        ConfigureControls()
    End Sub

    Private Function GetTemplateList(baseDirectory As String) As List(Of String)
        Dim fileList As New List(Of String)

        Try
            For Each s As String In Directory.GetFiles(baseDirectory, "*.prn")
                fileList.Add(s)
            Next
        Catch ex As Exception
            MessageBox.Show(String.Format("Error reading the template file list: {0}", ex.Message), "Error Getting Template List", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return fileList
    End Function

    Private Sub PrinterMenuStipHandler(sender As Object, e As EventArgs)
        Printer.RawHelper.SendStringToPrinter(lblPrinter.Text, DirectCast(sender, ToolStripMenuItem).Tag.ToString)
    End Sub

    Private Sub frmManualPrint_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblInstructions.Parent = pbControls
        lblInstructions.Location = New System.Drawing.Point((pbControls.Width \ 2) - (lblInstructions.Width \ 2), (pbControls.Height \ 2) - 25)

        cboTemplate.Items.AddRange(GetTemplateList(Path.Combine(Application.StartupPath, "Templates")).ToArray)

        Dim settingList As New List(Of String)
        settingList = GetSettingList(Path.Combine(Application.StartupPath, "Settings"))
        For Each s As String In settingList
            Dim fi As New FileInfo(s)
            Dim t As New ToolStripMenuItem(fi.Name.Replace(".set", String.Empty))
            t.Tag = s
            AddHandler t.Click, AddressOf PrinterMenuStipHandler
            tsmPrinterSettings.DropDown.Items.Add(t)
        Next

        Me.Visible = True

        For Each printer As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            If printer.ToUpper.Contains("ZDESIGNER") OrElse printer.ToUpper.Contains("ZEBRA") OrElse printer.ToUpper.Contains("ZPL") Then
                lblPrinter.Text = printer
                Exit For
            End If
        Next

        isLoading = False
    End Sub

    Private Sub cboTemplate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTemplate.SelectedIndexChanged
        If isLoading Then Exit Sub

        SelectFile(cboTemplate.Text)

        If lblPrinter.Text <> String.Empty Then
            FocusFirstControl()
        Else
            btnPrint.Focus()
        End If
    End Sub

    Private Sub btnSelectPrinter_Click(sender As Object, e As EventArgs) Handles btnSelectPrinter.Click
        Dim bCancel As Boolean
        Dim settings As New System.Drawing.Printing.PrinterSettings
        lblPrinter.Text = frmPrinterSelection.GetPrinter(settings.PrinterName, bCancel)
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If txtCSVFile.Text.Trim = String.Empty Then
            ManualPrint()
        Else
            FilePrint()
        End If
        FocusFirstControl()
    End Sub

    Private Sub ManualPrint()
        For Each c As Control In pbControls.Controls
            If TypeOf c Is TextBox Then
                LabelTemplate.FieldList(c.Tag.ToString) = c.Text.Trim
                If Not DirectCast(FindControl(String.Format("chkField_{0}", c.Tag.ToString.Replace("[", String.Empty).Replace("]", String.Empty)), pbControls), CheckBox).Checked Then
                    c.Text = String.Empty
                End If
            End If
        Next
        Printer.RawHelper.SendStringToPrinter(lblPrinter.Text, LabelTemplate.Output)
    End Sub

    Private Sub FilePrint()
        Dim s As String = txtCSVFile.Text.Trim

        If Not File.Exists(s) Then
            MessageBox.Show("The file you have selected does not exist.", "Invalid Import Path", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        ParseCSVFile(s)
    End Sub

    Private Function ParseCSVFile(path As String) As Boolean
        Try
            Using parser As New FileIO.TextFieldParser(path)
                parser.SetDelimiters(New String() {","})
                parser.HasFieldsEnclosedInQuotes = True

                While Not parser.EndOfData
                    Dim fields As String() = parser.ReadFields()
                    For i As Int32 = 0 To controlSequence.Count - 1
                        Try
                            Dim c As Control = controlSequence(i)
                            c.Text = fields(i).ToString
                        Catch ex As Exception

                        End Try
                    Next
                    ManualPrint()
                End While

            End Using
        Catch ex As Exception
            MessageBox.Show(String.Format("Error while reading the import file: {0}", ex.Message), "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

        Return True
    End Function

    Private Sub FocusFirstControl()
        DirectCast(controlSequence.Item(0), TextBox).Focus()
    End Sub

    Private Function FindControl(name As String, container As Control) As Control
        For Each c As Control In container.Controls
            If c.HasChildren Then
                Return FindControl(name, c)
            Else
                If c.Name = name Then
                    Return c
                End If
            End If
        Next
        Return Nothing
    End Function

    Private Sub btnSelectCSV_Click(sender As Object, e As EventArgs) Handles btnSelectCSV.Click
        ofdCSVFile.InitialDirectory = Application.StartupPath
        ofdCSVFile.Filter = "csv files (*.csv)|*.csv"

        If ofdCSVFile.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtCSVFile.Text = ofdCSVFile.FileName
        End If
    End Sub

End Class
