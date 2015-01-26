﻿Imports System
Imports System.Collections.Generic
Imports Rhino
Imports Rhino.Commands
Imports Rhino.Geometry
Imports Rhino.Input
Imports Rhino.Input.Custom

Namespace SampleVbCommands

  <System.Runtime.InteropServices.Guid("5f2b5253-fde4-4d40-abb1-d4b2478b93ed")> _
  Public Class SampleVbCommandsCommand
    Inherits Command

    Shared _instance As SampleVbCommandsCommand

    Public Sub New()
      ' Rhino only creates one instance of each command class defined in a
      ' plug-in, so it is safe to store a refence in a static field.
      _instance = Me
    End Sub

    '''<summary>The only instance of this command.</summary>
    Public Shared ReadOnly Property Instance() As SampleVbCommandsCommand
      Get
        Return _instance
      End Get
    End Property

    '''<returns>The command name as it appears on the Rhino command line.</returns>
    Public Overrides ReadOnly Property EnglishName() As String
      Get
        Return "SampleVbCommands"
      End Get
    End Property

    Protected Overrides Function RunCommand(ByVal doc As RhinoDoc, ByVal mode As RunMode) As Result
      RhinoApp.WriteLine(String.Format("{0} plug-in loaded.", SampleVbCommandsPlugIn.Instance.Name))
      Return Result.Success
    End Function

  End Class
End Namespace