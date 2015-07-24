<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManualPrint
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cboTemplate = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pbControls = New System.Windows.Forms.PictureBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.lblPrinter = New System.Windows.Forms.Label()
        Me.btnSelectPrinter = New System.Windows.Forms.Button()
        Me.lblInstructions = New System.Windows.Forms.Label()
        Me.txtCSVFile = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSelectCSV = New System.Windows.Forms.Button()
        Me.ofdCSVFile = New System.Windows.Forms.OpenFileDialog()
        Me.mnuMain = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmPrinterSettings = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.pbControls, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboTemplate
        '
        Me.cboTemplate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboTemplate.FormattingEnabled = True
        Me.cboTemplate.Location = New System.Drawing.Point(12, 57)
        Me.cboTemplate.Name = "cboTemplate"
        Me.cboTemplate.Size = New System.Drawing.Size(459, 21)
        Me.cboTemplate.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select Template:"
        '
        'pbControls
        '
        Me.pbControls.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbControls.Location = New System.Drawing.Point(15, 168)
        Me.pbControls.Name = "pbControls"
        Me.pbControls.Size = New System.Drawing.Size(456, 170)
        Me.pbControls.TabIndex = 2
        Me.pbControls.TabStop = False
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Location = New System.Drawing.Point(396, 344)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 50
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'lblPrinter
        '
        Me.lblPrinter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblPrinter.Location = New System.Drawing.Point(18, 90)
        Me.lblPrinter.Name = "lblPrinter"
        Me.lblPrinter.Size = New System.Drawing.Size(372, 19)
        Me.lblPrinter.TabIndex = 6
        Me.lblPrinter.Text = "Printer:"
        '
        'btnSelectPrinter
        '
        Me.btnSelectPrinter.Location = New System.Drawing.Point(396, 90)
        Me.btnSelectPrinter.Name = "btnSelectPrinter"
        Me.btnSelectPrinter.Size = New System.Drawing.Size(75, 23)
        Me.btnSelectPrinter.TabIndex = 1
        Me.btnSelectPrinter.Text = "Select"
        Me.btnSelectPrinter.UseVisualStyleBackColor = True
        '
        'lblInstructions
        '
        Me.lblInstructions.AutoSize = True
        Me.lblInstructions.Location = New System.Drawing.Point(173, 212)
        Me.lblInstructions.Name = "lblInstructions"
        Me.lblInstructions.Size = New System.Drawing.Size(130, 13)
        Me.lblInstructions.TabIndex = 9
        Me.lblInstructions.Text = "Select a template to begin"
        '
        'txtCSVFile
        '
        Me.txtCSVFile.Location = New System.Drawing.Point(15, 141)
        Me.txtCSVFile.Name = "txtCSVFile"
        Me.txtCSVFile.Size = New System.Drawing.Size(375, 20)
        Me.txtCSVFile.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Print from .csv File"
        '
        'btnSelectCSV
        '
        Me.btnSelectCSV.Location = New System.Drawing.Point(396, 139)
        Me.btnSelectCSV.Name = "btnSelectCSV"
        Me.btnSelectCSV.Size = New System.Drawing.Size(75, 23)
        Me.btnSelectCSV.TabIndex = 3
        Me.btnSelectCSV.Text = "Select"
        Me.btnSelectCSV.UseVisualStyleBackColor = True
        '
        'ofdCSVFile
        '
        Me.ofdCSVFile.FileName = "OpenFileDialog1"
        '
        'mnuMain
        '
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.tsmPrinterSettings})
        Me.mnuMain.Location = New System.Drawing.Point(0, 0)
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.Size = New System.Drawing.Size(483, 24)
        Me.mnuMain.TabIndex = 51
        Me.mnuMain.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'tsmPrinterSettings
        '
        Me.tsmPrinterSettings.Name = "tsmPrinterSettings"
        Me.tsmPrinterSettings.Size = New System.Drawing.Size(99, 20)
        Me.tsmPrinterSettings.Text = "Printer Settings"
        '
        'frmManualPrint
        '
        Me.AcceptButton = Me.btnPrint
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 379)
        Me.Controls.Add(Me.btnSelectCSV)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCSVFile)
        Me.Controls.Add(Me.lblInstructions)
        Me.Controls.Add(Me.btnSelectPrinter)
        Me.Controls.Add(Me.lblPrinter)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.pbControls)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboTemplate)
        Me.Controls.Add(Me.mnuMain)
        Me.MainMenuStrip = Me.mnuMain
        Me.Name = "frmManualPrint"
        Me.Text = "Print Label"
        CType(Me.pbControls, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuMain.ResumeLayout(False)
        Me.mnuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboTemplate As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pbControls As System.Windows.Forms.PictureBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents lblPrinter As System.Windows.Forms.Label
    Friend WithEvents btnSelectPrinter As System.Windows.Forms.Button
    Friend WithEvents lblInstructions As System.Windows.Forms.Label
    Friend WithEvents txtCSVFile As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSelectCSV As System.Windows.Forms.Button
    Friend WithEvents ofdCSVFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents mnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmPrinterSettings As System.Windows.Forms.ToolStripMenuItem

End Class
