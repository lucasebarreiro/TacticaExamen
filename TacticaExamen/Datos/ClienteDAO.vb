Imports System.Configuration
Imports System.Data.SqlClient

Public Class ClienteDAO
    Private connStr As String = ConfigurationManager.ConnectionStrings("ConexionDB").ConnectionString

    Public Function ObtenerClientes() As List(Of Cliente)
        Dim lista As New List(Of Cliente)

        Using conn As New SqlConnection(connStr)
            conn.Open()
            Dim cmd As New SqlCommand("SELECT * FROM clientes", conn)
            Dim reader = cmd.ExecuteReader()

            While reader.Read()
                lista.Add(New Cliente With {
                    .ID = Convert.ToInt32(reader("ID")),
                    .Nombre = reader("Cliente").ToString(),
                    .Telefono = reader("Telefono").ToString(),
                    .Correo = reader("Correo").ToString()
                })
            End While
        End Using

        Return lista

    End Function

    Public Sub InsertarCliente(cliente As Cliente)
        Using conn As New SqlConnection(connStr)
            conn.Open()

            Dim query As String = "INSERT INTO clientes (Cliente, Telefono, Correo) VALUES (@Nombre, @Telefono, @Correo)"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre)
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono)
                cmd.Parameters.AddWithValue("@Correo", cliente.Correo)

                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Public Sub EliminarCliente(id As Integer)
        Using conn As New SqlConnection(connStr)
            conn.Open()
            Dim query As String = "DELETE FROM clientes WHERE ID = @ID"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ID", id)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Public Sub ActualizarCliente(cliente As Cliente)
        Using conn As New SqlConnection(connStr)
            conn.Open()
            Dim query As String = "UPDATE clientes SET Cliente = @Nombre, Telefono = @Telefono, Correo = @Correo WHERE ID = @ID"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre)
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono)
                cmd.Parameters.AddWithValue("@Correo", cliente.Correo)
                cmd.Parameters.AddWithValue("@ID", cliente.ID)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub
    Public Function BuscarClientes(filtro As String) As List(Of Cliente)
        Dim lista As New List(Of Cliente)

        Using conn As New SqlConnection(connStr)
            conn.Open()

            Dim query As String = "SELECT * FROM clientes WHERE Cliente LIKE @filtro OR Telefono LIKE @filtro OR Correo LIKE @filtro"
            Using cmd As New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@filtro", "%" & filtro & "%")
                Dim reader = cmd.ExecuteReader()

                While reader.Read()
                    lista.Add(New Cliente With {
                    .ID = Convert.ToInt32(reader("ID")),
                    .Nombre = reader("Cliente").ToString(),
                    .Telefono = reader("Telefono").ToString(),
                    .Correo = reader("Correo").ToString()
                })
                End While
            End Using
        End Using

        Return lista
    End Function


End Class
