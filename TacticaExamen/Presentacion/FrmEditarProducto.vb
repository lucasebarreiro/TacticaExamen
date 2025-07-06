Public Class FrmEditarProducto
    Public Property ProductoActual As Producto

    Private Sub FrmEditarProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ProductoActual IsNot Nothing Then
            txtNombre.Text = ProductoActual.Nombre
            txtPrecio.Text = ProductoActual.Precio.ToString()
            txtCategoria.Text = ProductoActual.Categoria
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            ProductoActual.Nombre = txtNombre.Text
            ProductoActual.Precio = Decimal.Parse(txtPrecio.Text)
            ProductoActual.Categoria = txtCategoria.Text

            Dim dao As New ProductoDAO()
            dao.ActualizarProducto(ProductoActual)
            MessageBox.Show("Producto actualizado correctamente.")
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error al actualizar producto: " & ex.Message)
        End Try
    End Sub
End Class