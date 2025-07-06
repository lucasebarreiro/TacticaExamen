Public Class FrmNuevoProducto
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim nuevoProducto As New Producto With {
                .Nombre = txtNombre.Text,
                .Precio = Decimal.Parse(txtPrecio.Text),
                .Categoria = txtCategoria.Text
            }

            Dim dao As New ProductoDAO()
            dao.InsertarProducto(nuevoProducto)
            MessageBox.Show("Producto agregado correctamente.")
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error al agregar producto: " & ex.Message)
        End Try
    End Sub
End Class

