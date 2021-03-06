﻿Imports Rhino
Imports Rhino.Commands
Imports Rhino.Geometry
Imports Rhino.Input

Namespace SampleVbCommands

  <System.Runtime.InteropServices.Guid("c140e5e6-0a0b-47c7-8c58-bae5a44e1022")> _
  Public Class SampleVbEasyLine
    Inherits Command

    ''' <returns>
    ''' The command name as it appears on the Rhino command line.
    ''' </returns>
    Public Overrides ReadOnly Property EnglishName() As String
      Get
        Return "SampleVbEasyLine"
      End Get
    End Property

    ''' <summary>
    ''' Called by Rhino to run the command.
    ''' </summary>
    Protected Overrides Function RunCommand(ByVal doc As RhinoDoc, ByVal mode As RunMode) As Result

      Dim line As Line
      Dim rc As Result = RhinoGet.GetLine(line)
      If rc = Result.Success Then
        doc.Objects.AddLine(line)
        doc.Views.Redraw()
      End If

      Return Result.Success

    End Function
  End Class

End Namespace