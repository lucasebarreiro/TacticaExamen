﻿Public Class VentaItem
    Public Property IDProducto As Integer
    Public Property NombreProducto As String
    Public Property Cantidad As Integer
    Public Property PrecioUnitario As Decimal

    Public ReadOnly Property PrecioTotal As Decimal
        Get
            Return Cantidad * PrecioUnitario
        End Get
    End Property
End Class
