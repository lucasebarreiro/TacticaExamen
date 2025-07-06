Public Class FrmProductos
    Private productoDAO As New ProductoDAO()

    Private Sub FrmProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarProductos()
    End Sub

    Private Sub CargarProductos()
        Dim lista = productoDAO.ObtenerProductos()
        dgvProductos.DataSource = Nothing
        dgvProductos.DataSource = lista
    End Sub

    Private Sub btnCargarProductos_Click(sender As Object, e As EventArgs) Handles btnCargarProductos.Click
        CargarProductos()
    End Sub

    Private Sub btnNuevoProducto_Click(sender As Object, e As EventArgs) Handles btnNuevoProducto.Click
        Dim frmNuevo As New FrmNuevoProducto()
        frmNuevo.ShowDialog()
        CargarProductos()
    End Sub

    Private Sub btnEliminarProducto_Click(sender As Object, e As EventArgs) Handles btnEliminarProducto.Click
        If dgvProductos.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleccione un producto para eliminar.")
            Return
        End If

        Dim id As Integer = Convert.ToInt32(dgvProductos.SelectedRows(0).Cells("ID").Value)
        Dim rta = MessageBox.Show("¿Está seguro de eliminar este producto?", "Confirmar", MessageBoxButtons.YesNo)
        If rta = DialogResult.Yes Then
            productoDAO.EliminarProducto(id)
            MessageBox.Show("Producto eliminado correctamente.")
            CargarProductos()
        End If
    End Sub

    Private Sub btnEditarProducto_Click(sender As Object, e As EventArgs) Handles btnEditarProducto.Click
        If dgvProductos.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleccione un producto para editar.")
            Return
        End If

        Dim productoEditar As New Producto With {
            .ID = Convert.ToInt32(dgvProductos.SelectedRows(0).Cells("ID").Value),
            .Nombre = dgvProductos.SelectedRows(0).Cells("Nombre").Value.ToString(),
            .Precio = Convert.ToDecimal(dgvProductos.SelectedRows(0).Cells("Precio").Value),
            .Categoria = dgvProductos.SelectedRows(0).Cells("Categoria").Value.ToString()
        }

        Dim frmEditar As New FrmEditarProducto()
        frmEditar.ProductoActual = productoEditar
        If frmEditar.ShowDialog() = DialogResult.OK Then
            CargarProductos()
        End If
    End Sub

    Private Sub txtBuscarProducto_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarProducto.TextChanged
        Dim filtro As String = txtBuscarProducto.Text.Trim()
        Dim listaFiltrada = productoDAO.BuscarProductos(filtro)
        dgvProductos.DataSource = Nothing
        dgvProductos.DataSource = listaFiltrada
    End Sub
End Class
