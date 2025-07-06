Public Class FrmVentas

    Private listaItems As New List(Of VentaItem)
    Private venta As Venta
    Public Sub New()
        InitializeComponent()
    End Sub
    Public Sub New(venta As Venta)
        InitializeComponent()
        Me.venta = venta
    End Sub

    Private Function ObtenerClientes() As List(Of Cliente)
        Dim dao As New ClienteDAO()
        Return dao.ObtenerClientes()
    End Function

    Private Function ObtenerProductos() As List(Of Producto)
        Dim dao As New ProductoDAO()
        Return dao.ObtenerProductos()
    End Function

    Private Sub GuardarVentaEnBD(venta As Venta)
        Dim dao As New VentasDAO()
        dao.GuardarVenta(venta)
    End Sub


    Private Sub FrmVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Cargar combos
        cmbClientes.DataSource = ObtenerClientes()
        cmbClientes.DisplayMember = "Nombre"
        cmbClientes.ValueMember = "ID"

        cmbProductos.DataSource = ObtenerProductos()
        cmbProductos.DisplayMember = "Nombre"
        cmbProductos.ValueMember = "ID"

        'Configurar columnas del DataGridView
        ConfigurarGrid()

        'Setear fecha actual
        dtpFecha.Value = DateTime.Now

        'Inicializar total
        lblTotalGeneral.Text = "Total: $0.00"
    End Sub

    Private Sub ConfigurarGrid()
        dgvItems.Columns.Clear()
        dgvItems.Columns.Add("Nombre", "Producto")
        dgvItems.Columns.Add("Cantidad", "Cantidad")
        dgvItems.Columns.Add("Precio", "Precio Unitario")
        dgvItems.Columns.Add("Total", "Total Item")
    End Sub

    Private Sub btnAgregarItem_Click(sender As Object, e As EventArgs) Handles btnAgregarItem.Click
        'Validación
        If cmbProductos.SelectedItem Is Nothing OrElse Not IsNumeric(txtCantidad.Text) Then
            MessageBox.Show("Seleccione un producto y cantidad válida.")
            Return
        End If

        Dim producto As Producto = DirectCast(cmbProductos.SelectedItem, Producto)
        Dim cantidad As Integer = Integer.Parse(txtCantidad.Text)

        If cantidad <= 0 Then
            MessageBox.Show("La cantidad debe ser mayor a 0.")
            Return
        End If

        'Crear ítem
        Dim item As New VentaItem With {
            .IDProducto = producto.ID,
            .NombreProducto = producto.Nombre,
            .Cantidad = cantidad,
            .PrecioUnitario = producto.Precio
        }

        listaItems.Add(item)

        'Mostrar en el DataGridView
        dgvItems.Rows.Add(item.NombreProducto, item.Cantidad, item.PrecioUnitario.ToString("N2"), item.PrecioTotal.ToString("N2"))

        'Calcular total general
        CalcularTotalGeneral()
    End Sub

    Private Sub CalcularTotalGeneral()
        Dim total As Decimal = listaItems.Sum(Function(i) i.PrecioTotal)
        lblTotalGeneral.Text = "Total: $" & total.ToString("N2")
    End Sub

    Private Sub btnGuardarVenta_Click(sender As Object, e As EventArgs) Handles btnGuardarVenta.Click
        If cmbClientes.SelectedItem Is Nothing Then
            MessageBox.Show("Debe seleccionar un cliente.")
            Return
        End If

        If listaItems.Count = 0 Then
            MessageBox.Show("Debe agregar al menos un producto.")
            Return
        End If

        'Crear la venta a guardar
        Dim ventaAGuardar As New Venta With {
        .IDCliente = DirectCast(cmbClientes.SelectedItem, Cliente).ID,
        .Fecha = dtpFecha.Value,
        .Items = listaItems,
        .Total = listaItems.Sum(Function(i) i.PrecioTotal)
    }

        Dim dao As New VentasDAO()

        If venta Is Nothing OrElse venta.ID = 0 Then
            'Venta nueva
            dao.GuardarVenta(ventaAGuardar)
            MessageBox.Show("¡Venta guardada correctamente!")
        Else
            'Venta existente, asignar el ID y actualizar
            ventaAGuardar.ID = venta.ID
            dao.ActualizarVenta(ventaAGuardar)
            MessageBox.Show("¡Venta actualizada correctamente!")
        End If

        Me.Close()
    End Sub


    Private Sub btnBuscarVentas_Click(sender As Object, e As EventArgs) Handles btnBuscarVentas.Click
        Dim frmBuscarVentas As New FrmBuscarVentas()
        frmBuscarVentas.ShowDialog()
    End Sub
End Class
