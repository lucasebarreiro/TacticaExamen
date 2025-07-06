Imports System.Configuration
Imports System.Data.SqlClient

Public Class VentasDAO
    Private connStr As String = ConfigurationManager.ConnectionStrings("ConexionDB").ConnectionString

    Public Sub GuardarVenta(venta As Venta)
        Dim idVenta As Integer = 0

        ' Paso 1: Guardar cabecera de la venta
        Using conn As New SqlConnection(connStr)
            conn.Open()

            Dim queryVenta As String = "INSERT INTO ventas (IDCliente, Fecha, Total) 
                                        VALUES (@IDCliente, @Fecha, @Total);
                                        SELECT SCOPE_IDENTITY();"

            Dim cmdVenta As New SqlCommand(queryVenta, conn)
            cmdVenta.Parameters.AddWithValue("@IDCliente", venta.IDCliente)
            cmdVenta.Parameters.AddWithValue("@Fecha", venta.Fecha)
            cmdVenta.Parameters.AddWithValue("@Total", venta.Total)

            ' Recuperar el ID generado
            idVenta = Convert.ToInt32(cmdVenta.ExecuteScalar())
        End Using

        ' Paso 2: Guardar los ítems de la venta
        For Each item As VentaItem In venta.Items
            Using conn As New SqlConnection(connStr)
                conn.Open()

                Dim queryItem As String = "INSERT INTO ventasitems (IDVenta, IDProducto, Cantidad, PrecioUnitario, PrecioTotal)
                                           VALUES (@VentaID, @IDProducto, @Cantidad, @PrecioUnitario, @PrecioTotal)"

                Dim cmdItem As New SqlCommand(queryItem, conn)
                cmdItem.Parameters.AddWithValue("@VentaID", idVenta)
                cmdItem.Parameters.AddWithValue("@IDProducto", item.IDProducto)
                cmdItem.Parameters.AddWithValue("@Cantidad", item.Cantidad)
                cmdItem.Parameters.AddWithValue("@PrecioUnitario", item.PrecioUnitario)
                cmdItem.Parameters.AddWithValue("@Preciototal", item.PrecioTotal)



                cmdItem.ExecuteNonQuery()
            End Using
        Next
    End Sub
    Public Function BuscarVentas(nombreCliente As String, desde As Date, hasta As Date) As List(Of Venta)
        Dim lista As New List(Of Venta)

        Using conn As New SqlConnection(connStr)
            conn.Open()

            Dim query As String = "
            SELECT v.ID, v.IDCliente, v.Fecha, v.Total
            FROM Ventas v
            INNER JOIN Clientes c ON v.IDCliente = c.ID
            WHERE v.Fecha BETWEEN @Desde AND @Hasta
              AND c.Cliente LIKE @Nombre
            ORDER BY v.Fecha DESC"

            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Desde", desde)
                cmd.Parameters.AddWithValue("@Hasta", hasta)
                cmd.Parameters.AddWithValue("@Nombre", "%" & nombreCliente & "%")

                Dim reader = cmd.ExecuteReader()
                While reader.Read()
                    Dim venta As New Venta With {
                        .ID = Convert.ToInt32(reader("ID")),
                        .IDCliente = Convert.ToInt32(reader("IDCliente")),
                        .Fecha = Convert.ToDateTime(reader("Fecha")),
                        .Total = Convert.ToDecimal(reader("Total")),
                        .Items = ObtenerItemsVenta(Convert.ToInt32(reader("ID")))
                    }
                    lista.Add(venta)
                End While
            End Using
        End Using

        Return lista
    End Function
    Public Function ObtenerItemsVenta(idVenta As Integer) As List(Of VentaItem)
        Dim lista As New List(Of VentaItem)

        Using conn As New SqlConnection(connStr)
            conn.Open()

            Dim query As String = "
            SELECT vi.IDProducto, p.Nombre, vi.Cantidad, vi.PrecioUnitario
            FROM ventasitems vi
            INNER JOIN Productos p ON vi.IDProducto = p.ID
            WHERE vi.IDVenta = @VentaID"

            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@VentaID", idVenta)

                Dim reader = cmd.ExecuteReader()
                While reader.Read()
                    lista.Add(New VentaItem With {
                        .IDProducto = Convert.ToInt32(reader("IDProducto")),
                        .NombreProducto = reader("Nombre").ToString(),
                        .Cantidad = Convert.ToInt32(reader("Cantidad")),
                        .PrecioUnitario = Convert.ToDecimal(reader("PrecioUnitario"))
                    })
                End While
            End Using
        End Using

        Return lista
    End Function
    Public Sub EliminarVenta(id As Integer)
        Using conn As New SqlConnection(connStr)
            conn.Open()
            Dim query As String = "DELETE FROM ventas WHERE ID = @ID"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ID", id)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Public Sub ActualizarVenta(venta As Venta)
        Using conn As New SqlConnection(connStr)
            conn.Open()

            ' Actualizar cabecera de la venta
            Dim queryUpdateVenta As String = "UPDATE ventas SET IDCliente = @IDCliente, Fecha = @Fecha, Total = @Total WHERE ID = @ID"
            Using cmd As New SqlCommand(queryUpdateVenta, conn)
                cmd.Parameters.AddWithValue("@IDCliente", venta.IDCliente)
                cmd.Parameters.AddWithValue("@Fecha", venta.Fecha)
                cmd.Parameters.AddWithValue("@Total", venta.Total)
                cmd.Parameters.AddWithValue("@ID", venta.ID)
                cmd.ExecuteNonQuery()
            End Using

            ' Borrar ítems antiguos
            Dim queryDeleteItems As String = "DELETE FROM ventasitems WHERE IDVenta = @IDVenta"
            Using cmd As New SqlCommand(queryDeleteItems, conn)
                cmd.Parameters.AddWithValue("@IDVenta", venta.ID)
                cmd.ExecuteNonQuery()
            End Using

            ' Insertar ítems nuevos
            For Each item As VentaItem In venta.Items
                Dim queryInsertItem As String = "INSERT INTO ventasitems (IDVenta, IDProducto, Cantidad, PrecioUnitario, PrecioTotal) VALUES (@VentaID, @IDProducto, @Cantidad, @PrecioUnitario, @PrecioTotal)"
                Using cmd As New SqlCommand(queryInsertItem, conn)
                    cmd.Parameters.AddWithValue("@VentaID", venta.ID)
                    cmd.Parameters.AddWithValue("@IDProducto", item.IDProducto)
                    cmd.Parameters.AddWithValue("@Cantidad", item.Cantidad)
                    cmd.Parameters.AddWithValue("@PrecioUnitario", item.PrecioUnitario)
                    cmd.Parameters.AddWithValue("@PrecioTotal", item.PrecioTotal)
                    cmd.ExecuteNonQuery()
                End Using
            Next
        End Using
    End Sub


End Class
