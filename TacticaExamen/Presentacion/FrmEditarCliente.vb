Public Class FrmEditarCliente
    Public Property ClienteActual As Cliente

    Private Sub FrmEditarCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ClienteActual IsNot Nothing Then
            txtNombre.Text = ClienteActual.Nombre
            txtTelefono.Text = ClienteActual.Telefono
            txtCorreo.Text = ClienteActual.Correo
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            ClienteActual.Nombre = txtNombre.Text
            ClienteActual.Telefono = txtTelefono.Text
            ClienteActual.Correo = txtCorreo.Text

            Dim dao As New ClienteDAO()
            dao.ActualizarCliente(ClienteActual)
            MessageBox.Show("Cliente actualizado correctamente.")
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error al actualizar cliente: " & ex.Message)
        End Try
    End Sub
End Class
