﻿Imports System.Drawing
Imports System.Windows.Forms

Public Class DrawingBox

    Public Structure Layer
        Dim Pen As Pen
        Dim Path As Drawing2D.GraphicsPath
        Dim FillColor As Color
    End Structure

    Private xPen As New Pen(Color.Black, 1)
    Private Layers As New ObjectModel.Collection(Of Layer)

    <System.ComponentModel.Category("Pen")>
    Public Property PenColor() As Color
        Get
            Return xPen.Color
        End Get
        Set(ByVal value As Color)
            xPen.Color = value
        End Set
    End Property

    <System.ComponentModel.Category("Pen")>
    Public Property PenWidth() As Single
        Get
            Return xPen.Width
        End Get
        Set(ByVal value As Single)
            xPen.Width = value
        End Set
    End Property

    <System.ComponentModel.Category("Pen")>
    Public Property PenDashCap() As Drawing2D.DashCap
        Get
            Return xPen.DashCap
        End Get
        Set(ByVal value As Drawing2D.DashCap)
            xPen.DashCap = value
        End Set
    End Property

    <System.ComponentModel.Category("Pen")>
    Public Property PenDashStyle() As Drawing2D.DashStyle
        Get
            Return xPen.DashStyle
        End Get
        Set(ByVal value As Drawing2D.DashStyle)
            xPen.DashStyle = value
        End Set
    End Property

    <System.ComponentModel.Category("Pen")>
    Public Property PenAlingment() As Drawing2D.PenAlignment
        Get
            Return xPen.Alignment
        End Get
        Set(ByVal value As Drawing2D.PenAlignment)
            xPen.Alignment = value
        End Set
    End Property

    <System.ComponentModel.Category("Pen")>
    Public Property PenStartCap() As Drawing2D.LineCap
        Get
            Return xPen.StartCap
        End Get
        Set(ByVal value As Drawing2D.LineCap)
            xPen.StartCap = value
        End Set
    End Property

    <System.ComponentModel.Category("Pen")>
    Public Property PenEndCap() As Drawing2D.LineCap
        Get
            Return xPen.EndCap
        End Get
        Set(ByVal value As Drawing2D.LineCap)
            xPen.EndCap = value
        End Set
    End Property

    <System.ComponentModel.Category("Pen")>
    Public Property PenMiterLimit() As Single
        Get
            Return xPen.MiterLimit
        End Get
        Set(ByVal value As Single)
            xPen.MiterLimit = value
        End Set
    End Property

    <System.ComponentModel.Category("Pen")>
    Public Property PenLineJoin() As Drawing2D.LineJoin
        Get
            Return xPen.LineJoin
        End Get
        Set(ByVal value As Drawing2D.LineJoin)
            xPen.MiterLimit = value
        End Set
    End Property

    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Function AddLayer() As Integer
        Dim Layer As Layer
        With Layer
            .Pen = xPen.Clone()
            .Path = New Drawing2D.GraphicsPath()
            .FillColor = Me.ForeColor
        End With
        Me.Layers.Add(Layer)
        Return Me.Layers.IndexOf(Layer)
    End Function

    Public Property Item(ByVal Index As Integer) As Layer
        Get
            Return Me.Layers.Item(Index)
        End Get
        Set(ByVal value As Layer)
            Me.Layers.Item(Index) = value
        End Set
    End Property

    Public ReadOnly Property LayerCount() As Integer
        Get
            Return Me.Layers.Count
        End Get
    End Property

    Public Function DeleteLayer(ByVal Index As Integer) As Boolean
        Return Me.Layers.Remove(Me.Layers.Item(Index))
    End Function

    Private Sub DrawingBox_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles Me.Paint
        'e.Graphics.DrawPath(Me.xPen, Me.kmPath)
        Dim i As Integer
        e.Graphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        For i = 0 To Me.Layers.Count - 1
            e.Graphics.FillPath(New SolidBrush(Me.Layers.Item(i).FillColor), Me.Layers.Item(i).Path)
            e.Graphics.DrawPath(Me.Layers.Item(i).Pen, Me.Layers.Item(i).Path)
        Next
        'e.Graphics.DrawRectangle(Pens.Black, 10, 20, 100, 300)
    End Sub
End Class
