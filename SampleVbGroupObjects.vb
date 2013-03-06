﻿Imports System
Imports Rhino
Imports Rhino.Commands

Namespace SampleVbCommands

  <System.Runtime.InteropServices.Guid("94796de9-daeb-431a-bc1f-febbdf9bb9d5")> _
  Public Class SampleVbGroupObjects
    Inherits Command

    Shared _instance As SampleVbGroupObjects

    Public Sub New()
      ' Rhino only creates one instance of each command class defined in a
      ' plug-in, so it is safe to store a refence in a static field.
      _instance = Me
    End Sub

    '''<summary>The only instance of this command.</summary>
    Public Shared ReadOnly Property Instance() As SampleVbGroupObjects
      Get
        Return _instance
      End Get
    End Property

    '''<returns>The command name as it appears on the Rhino command line.</returns>
    Public Overrides ReadOnly Property EnglishName() As String
      Get
        Return "SampleVbGroupObjects"
      End Get
    End Property

    Protected Overrides Function RunCommand(ByVal doc As RhinoDoc, ByVal mode As RunMode) As Result

      Dim go As New Rhino.Input.Custom.GetObject()
      go.SetCommandPrompt("Select objects to group")
      go.GroupSelect = True
      go.GetMultiple(1, 0)
      If (go.CommandResult() <> Rhino.Commands.Result.Success) Then
        Return go.CommandResult()
      End If

      Dim objids As New List(Of Guid)()
      For i As Integer = 0 To go.ObjectCount - 1
        Dim objref As Rhino.DocObjects.ObjRef = go.Object(i)
        objids.Add(objref.ObjectId)
      Next

      Dim group_index As Integer = doc.Groups.Add(objids)

      Return Result.Success

    End Function
  End Class
End Namespace