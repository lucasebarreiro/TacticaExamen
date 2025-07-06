<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVentas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmbClientes = New System.Windows.Forms.ComboBox()
        Me.cmbProductos = New System.Windows.Forms.ComboBox()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.dgvItems = New System.Windows.Forms.DataGridView()
        Me.btnAgregarItem = New System.Windows.Forms.Button()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTotalGeneral = New System.Windows.Forms.Label()
        Me.btnGuardarVenta = New System.Windows.Forms.Button()
        Me.btnBuscarVentas = New System.Windows.Forms.Button()
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbClientes
        '
        Me.cmbClientes.FormattingEnabled = True
        Me.cmbClientes.Location = New System.Drawing.Point(178, 77)
        Me.cmbClientes.Name = "cmbClientes"
        Me.cmbClientes.Size = New System.Drawing.Size(121, 21)
        Me.cmbClientes.TabIndex = 0
        '
        'cmbProductos
        '
        Me.cmbProductos.FormattingEnabled = True
        Me.cmbProductos.Location = New System.Drawing.Point(178, 120)
        Me.cmbProductos.Name = "cmbProductos"
        Me.cmbProductos.Size = New System.Drawing.Size(121, 21)
        Me.cmbProductos.TabIndex = 1
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(178, 160)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(121, 20)
        Me.txtCantidad.TabIndex = 2
        '
        'dgvItems
        '
        Me.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItems.Location = New System.Drawing.Point(352, 52)
        Me.dgvItems.Name = "dgvItems"
        Me.dgvItems.Size = New System.Drawing.Size(362, 305)
        Me.dgvItems.TabIndex = 3
        '
        'btnAgregarItem
        '
        Me.btnAgregarItem.Location = New System.Drawing.Point(84, 204)
        Me.btnAgregarItem.Name = "btnAgregarItem"
        Me.btnAgregarItem.Size = New System.Drawing.Size(139, 23)
        Me.btnAgregarItem.TabIndex = 4
        Me.btnAgregarItem.Text = "Agregar"
        Me.btnAgregarItem.UseVisualStyleBackColor = True
        '
        'dtpFecha
        '
        Me.dtpFecha.Location = New System.Drawing.Point(12, 23)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(287, 20)
        Me.dtpFecha.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Clientes"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 123)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Productos"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Cantidad"
        '
        'lblTotalGeneral
        '
        Me.lblTotalGeneral.AutoSize = True
        Me.lblTotalGeneral.Location = New System.Drawing.Point(349, 377)
        Me.lblTotalGeneral.Name = "lblTotalGeneral"
        Me.lblTotalGeneral.Size = New System.Drawing.Size(71, 13)
        Me.lblTotalGeneral.TabIndex = 9
        Me.lblTotalGeneral.Text = "Total General"
        '
        'btnGuardarVenta
        '
        Me.btnGuardarVenta.Location = New System.Drawing.Point(611, 377)
        Me.btnGuardarVenta.Name = "btnGuardarVenta"
        Me.btnGuardarVenta.Size = New System.Drawing.Size(103, 23)
        Me.btnGuardarVenta.TabIndex = 10
        Me.btnGuardarVenta.Text = "Guardar Venta"
        Me.btnGuardarVenta.UseVisualStyleBackColor = True
        '
        'btnBuscarVentas
        '
        Me.btnBuscarVentas.Location = New System.Drawing.Point(84, 233)
        Me.btnBuscarVentas.Name = "btnBuscarVentas"
        Me.btnBuscarVentas.Size = New System.Drawing.Size(139, 23)
        Me.btnBuscarVentas.TabIndex = 11
        Me.btnBuscarVentas.Text = "Buscar Ventas"
        Me.btnBuscarVentas.UseVisualStyleBackColor = True
        '
        'FrmVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnBuscarVentas)
        Me.Controls.Add(Me.btnGuardarVenta)
        Me.Controls.Add(Me.lblTotalGeneral)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.btnAgregarItem)
        Me.Controls.Add(Me.dgvItems)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.cmbProductos)
        Me.Controls.Add(Me.cmbClientes)
        Me.Name = "FrmVentas"
        Me.Text = "FrmVentas"
        CType(Me.dgvItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbClientes As ComboBox
    Friend WithEvents cmbProductos As ComboBox
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents dgvItems As DataGridView
    Friend WithEvents btnAgregarItem As Button
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTotalGeneral As Label
    Friend WithEvents btnGuardarVenta As Button
    Friend WithEvents btnBuscarVentas As Button
End Class
