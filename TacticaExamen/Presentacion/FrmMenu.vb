Public Class FrmMenu
    Private Sub btnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click
        Dim frmClientes As New FrmClientes()
        frmClientes.ShowDialog()
    End Sub

    Private Sub btnProductos_Click(sender As Object, e As EventArgs) Handles btnProductos.Click
        Dim frmProductos As New FrmProductos()
        frmProductos.ShowDialog()
    End Sub

    Private Sub btnVentas_Click(sender As Object, e As EventArgs) Handles btnVentas.Click
        Dim frmVentas As New FrmVentas()
        frmVentas.ShowDialog()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dim rta = MessageBox.Show("¿Querés salir de la aplicación?", "Confirmar salida", MessageBoxButtons.YesNo)
        If rta = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub
End Class
