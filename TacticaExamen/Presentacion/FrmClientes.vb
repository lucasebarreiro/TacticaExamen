Public Class FrmClientes
    Private clienteDAO As New ClienteDAO()

    Private Sub btnNuevoCliente_Click(sender As Object, e As EventArgs) Handles btnNuevoCliente.Click
        Try
            Dim nuevoForm As New FrmNuevoCliente()
            nuevoForm.ShowDialog()
            btnCargar.PerformClick() ' Recargar la lista luego de agregar
        Catch ex As Exception
            MessageBox.Show("Error al abrir el formulario: " & ex.Message)
        End Try
    End Sub

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        Try
            Dim listaClientes = clienteDAO.ObtenerClientes()
            dgvClientes.DataSource = Nothing
            dgvClientes.DataSource = listaClientes
        Catch ex As Exception
            MessageBox.Show("Error al cargar los clientes: " & ex.Message)
        End Try
    End Sub

    Private Sub FrmClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnCargar.PerformClick()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            If dgvClientes.SelectedRows.Count = 0 Then
                MessageBox.Show("Seleccione un cliente para eliminar.")
                Return
            End If

            Dim idCliente As Integer = Convert.ToInt32(dgvClientes.SelectedRows(0).Cells("ID").Value)
            Dim resultado = MessageBox.Show("¿Está seguro de eliminar este cliente?", "Confirmar", MessageBoxButtons.YesNo)

            If resultado = DialogResult.Yes Then
                clienteDAO.EliminarCliente(idCliente)
                MessageBox.Show("Cliente eliminado correctamente.")
                btnCargar.PerformClick() ' Recargar lista
            End If

        Catch ex As Exception
            MessageBox.Show("Error al eliminar cliente: " & ex.Message)
        End Try
    End Sub
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try
            If dgvClientes.SelectedRows.Count = 0 Then
                MessageBox.Show("Seleccione un cliente para editar.")
                Return
            End If

            Dim clienteEditar As New Cliente With {
            .ID = Convert.ToInt32(dgvClientes.SelectedRows(0).Cells("ID").Value),
            .Nombre = dgvClientes.SelectedRows(0).Cells("Nombre").Value.ToString(),
            .Telefono = dgvClientes.SelectedRows(0).Cells("Telefono").Value.ToString(),
            .Correo = dgvClientes.SelectedRows(0).Cells("Correo").Value.ToString()
        }

            Dim frmEditar As New FrmEditarCliente()
            frmEditar.ClienteActual = clienteEditar
            If frmEditar.ShowDialog() = DialogResult.OK Then
                btnCargar.PerformClick()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al abrir formulario de edición: " & ex.Message)
        End Try
    End Sub
    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        Dim filtro As String = txtBuscar.Text.Trim()
        Dim listaFiltrada = clienteDAO.BuscarClientes(filtro)
        dgvClientes.DataSource = Nothing
        dgvClientes.DataSource = listaFiltrada
    End Sub

End Class
