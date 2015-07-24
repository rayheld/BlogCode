Option Explicit On
Option Strict On
Option Infer Off

Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Public Class ZPLTemplate

    Private Template As String
    Private Const RegExPattern As String = "\[(.*?)\]" 'Looks for values that are between brackets:  [ExampleField]

    Public Property FieldList As New Dictionary(Of String, String)

    Public ReadOnly Property Output As String
        Get
            Dim out As String = Template
            For Each k As String In FieldList.Keys
                out = out.Replace(k, FieldList.Item(k))
            Next
            Return out
        End Get
    End Property

    Private Sub New()
        'Intentionally left blank -- i need an input template to make this work.
    End Sub

    Public Sub New(inputTemplate As String)
        Template = inputTemplate
        FindFields()
    End Sub

    Private Sub FindFields()
        Dim re As New Regex(RegExPattern)
        FieldList = New Dictionary(Of String, String)

        For Each m As Match In re.Matches(Template)
            If Not FieldList.ContainsKey(m.ToString) Then
                FieldList.Add(m.ToString, String.Empty)
            End If
        Next
    End Sub

End Class
