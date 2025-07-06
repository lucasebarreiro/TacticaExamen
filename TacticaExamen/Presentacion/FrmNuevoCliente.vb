Public Class FrmNuevoCliente

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ' Validación básica
        If txtNombre.Text = "" Then
            MessageBox.Show("Debe ingresar el nombre.")
            Exit Sub
        End If

        ' Crear objeto cliente
        Dim nuevoCliente As New Cliente With {
            .Nombre = txtNombre.Text,
            .Telefono = txtTelefono.Text,
            .Correo = txtCorreo.Text
        }

        ' Guardar en la base de datos
        Dim dao As New ClienteDAO()
        dao.InsertarCliente(nuevoCliente)

        MessageBox.Show("Cliente guardado con éxito.")
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

End Class
