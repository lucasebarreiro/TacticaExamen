Public Class FrmBuscarVentas

    Private listaVentas As New List(Of Venta)

    Private Sub FrmBuscarVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpDesde.Value = Date.Today.AddMonths(-1)
        dtpHasta.Value = Date.Today
        CargarVentas()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        CargarVentas()
    End Sub

    Private Sub CargarVentas()
        Dim dao As New VentasDAO()
        Dim nombreCliente = txtCliente.Text.Trim()
        Dim desde = dtpDesde.Value.Date
        Dim hasta = dtpHasta.Value.Date.AddDays(1).AddSeconds(-1)

        listaVentas = dao.BuscarVentas(nombreCliente, desde, hasta)

        dgvVentas.DataSource = listaVentas.Select(Function(v) New With {
            .ID = v.ID,
            .Cliente = ObtenerNombreCliente(v.IDCliente),
            .Fecha = v.Fecha,
            .Total = v.Total.ToString("N2")
        }).ToList()

        dgvDetalle.DataSource = Nothing
    End Sub

    Private Sub dgvVentas_SelectionChanged(sender As Object, e As EventArgs) Handles dgvVentas.SelectionChanged
        If dgvVentas.SelectedRows.Count = 0 Then Return

        Dim idSeleccionado = Convert.ToInt32(dgvVentas.SelectedRows(0).Cells("ID").Value)
        Dim venta = listaVentas.FirstOrDefault(Function(v) v.ID = idSeleccionado)

        If venta IsNot Nothing Then
            dgvDetalle.DataSource = venta.Items.Select(Function(i) New With {
                .Producto = i.NombreProducto,
                .Cantidad = i.Cantidad,
                .PrecioUnitario = i.PrecioUnitario.ToString("N2"),
                .TotalItem = i.PrecioTotal.ToString("N2")
            }).ToList()
        End If
    End Sub

    Private Function ObtenerNombreCliente(idCliente As Integer) As String
        ' Podés usar ClienteDAO si querés traer solo el nombre
        Return New ClienteDAO().ObtenerClientes().FirstOrDefault(Function(c) c.ID = idCliente)?.Nombre
    End Function

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim f As New FrmVentas()
        f.ShowDialog()
        CargarVentas()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If dgvVentas.SelectedRows.Count = 0 Then Return

        Dim id = Convert.ToInt32(dgvVentas.SelectedRows(0).Cells("ID").Value)

        If MessageBox.Show("¿Seguro que deseas eliminar esta venta?", "Confirmar", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim dao As New VentasDAO()
            dao.EliminarVenta(id)
            MessageBox.Show("Venta eliminada.")
            CargarVentas()
        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        If dgvVentas.SelectedRows.Count = 0 Then Return

        Dim id = Convert.ToInt32(dgvVentas.SelectedRows(0).Cells("ID").Value)
        Dim venta = listaVentas.FirstOrDefault(Function(v) v.ID = id)

        If venta IsNot Nothing Then
            Dim formEdit As New FrmVentas(venta) ' pasás la venta existente
            formEdit.ShowDialog()
            CargarVentas()
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class
