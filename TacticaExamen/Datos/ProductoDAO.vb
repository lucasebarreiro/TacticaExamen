Imports System.Configuration
Imports System.Data.SqlClient

Public Class ProductoDAO
    Private connStr As String = ConfigurationManager.ConnectionStrings("ConexionDB").ConnectionString

    Public Function ObtenerProductos() As List(Of Producto)
        Dim lista As New List(Of Producto)

        Using conn As New SqlConnection(connStr)
            conn.Open()
            Dim cmd As New SqlCommand("SELECT * FROM productos", conn)
            Dim reader = cmd.ExecuteReader()

            While reader.Read()
                lista.Add(New Producto With {
                    .ID = Convert.ToInt32(reader("ID")),
                    .Nombre = reader("Nombre").ToString(),
                    .Precio = Convert.ToDecimal(reader("Precio")),
                    .Categoria = reader("Categoria").ToString()
                })
            End While
        End Using

        Return lista
    End Function

    Public Sub InsertarProducto(producto As Producto)
        Using conn As New SqlConnection(connStr)
            conn.Open()

            Dim query As String = "INSERT INTO productos (Nombre, Precio, Categoria) VALUES (@Nombre, @Precio, @Categoria)"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Nombre", producto.Nombre)
                cmd.Parameters.AddWithValue("@Precio", producto.Precio)
                cmd.Parameters.AddWithValue("@Categoria", producto.Categoria)

                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub EliminarProducto(id As Integer)
        Using conn As New SqlConnection(connStr)
            conn.Open()
            Dim query As String = "DELETE FROM productos WHERE ID = @ID"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ID", id)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub ActualizarProducto(producto As Producto)
        Using conn As New SqlConnection(connStr)
            conn.Open()
            Dim query As String = "UPDATE productos SET Nombre = @Nombre, Precio = @Precio, Categoria = @Categoria WHERE ID = @ID"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Nombre", producto.Nombre)
                cmd.Parameters.AddWithValue("@Precio", producto.Precio)
                cmd.Parameters.AddWithValue("@Categoria", producto.Categoria)
                cmd.Parameters.AddWithValue("@ID", producto.ID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Function BuscarProductos(filtro As String) As List(Of Producto)
        Dim lista As New List(Of Producto)

        Using conn As New SqlConnection(connStr)
            conn.Open()

            Dim query As String = "SELECT * FROM productos WHERE Nombre LIKE @filtro OR Categoria LIKE @filtro"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@filtro", "%" & filtro & "%")
                Dim reader = cmd.ExecuteReader()

                While reader.Read()
                    lista.Add(New Producto With {
                        .ID = Convert.ToInt32(reader("ID")),
                        .Nombre = reader("Nombre").ToString(),
                        .Precio = Convert.ToDecimal(reader("Precio")),
                        .Categoria = reader("Categoria").ToString()
                    })
                End While
            End Using
        End Using

        Return lista
    End Function
End Class
