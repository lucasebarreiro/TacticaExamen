<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProductos
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBuscarProducto = New System.Windows.Forms.TextBox()
        Me.btnEditarProducto = New System.Windows.Forms.Button()
        Me.btnEliminarProducto = New System.Windows.Forms.Button()
        Me.btnCargarProductos = New System.Windows.Forms.Button()
        Me.btnNuevoProducto = New System.Windows.Forms.Button()
        Me.dgvProductos = New System.Windows.Forms.DataGridView()
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(170, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Buscar"
        '
        'txtBuscarProducto
        '
        Me.txtBuscarProducto.Location = New System.Drawing.Point(173, 50)
        Me.txtBuscarProducto.Name = "txtBuscarProducto"
        Me.txtBuscarProducto.Size = New System.Drawing.Size(178, 20)
        Me.txtBuscarProducto.TabIndex = 12
        '
        'btnEditarProducto
        '
        Me.btnEditarProducto.Location = New System.Drawing.Point(401, 394)
        Me.btnEditarProducto.Name = "btnEditarProducto"
        Me.btnEditarProducto.Size = New System.Drawing.Size(152, 23)
        Me.btnEditarProducto.TabIndex = 11
        Me.btnEditarProducto.Text = "Modificar Producto"
        Me.btnEditarProducto.UseVisualStyleBackColor = True
        '
        'btnEliminarProducto
        '
        Me.btnEliminarProducto.Location = New System.Drawing.Point(243, 394)
        Me.btnEliminarProducto.Name = "btnEliminarProducto"
        Me.btnEliminarProducto.Size = New System.Drawing.Size(152, 23)
        Me.btnEliminarProducto.TabIndex = 10
        Me.btnEliminarProducto.Text = "Eliminar Producto"
        Me.btnEliminarProducto.UseVisualStyleBackColor = True
        '
        'btnCargarProductos
        '
        Me.btnCargarProductos.Location = New System.Drawing.Point(243, 365)
        Me.btnCargarProductos.Name = "btnCargarProductos"
        Me.btnCargarProductos.Size = New System.Drawing.Size(152, 23)
        Me.btnCargarProductos.TabIndex = 9
        Me.btnCargarProductos.Text = "Cargar Productos"
        Me.btnCargarProductos.UseVisualStyleBackColor = True
        '
        'btnNuevoProducto
        '
        Me.btnNuevoProducto.Location = New System.Drawing.Point(401, 365)
        Me.btnNuevoProducto.Name = "btnNuevoProducto"
        Me.btnNuevoProducto.Size = New System.Drawing.Size(152, 23)
        Me.btnNuevoProducto.TabIndex = 8
        Me.btnNuevoProducto.Text = "Nuevo Producto"
        Me.btnNuevoProducto.UseVisualStyleBackColor = True
        '
        'dgvProductos
        '
        Me.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductos.Location = New System.Drawing.Point(173, 76)
        Me.dgvProductos.Name = "dgvProductos"
        Me.dgvProductos.Size = New System.Drawing.Size(458, 283)
        Me.dgvProductos.TabIndex = 7
        '
        'FrmProductos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtBuscarProducto)
        Me.Controls.Add(Me.btnEditarProducto)
        Me.Controls.Add(Me.btnEliminarProducto)
        Me.Controls.Add(Me.btnCargarProductos)
        Me.Controls.Add(Me.btnNuevoProducto)
        Me.Controls.Add(Me.dgvProductos)
        Me.Name = "FrmProductos"
        Me.Text = "FrmProductos"
        CType(Me.dgvProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtBuscarProducto As TextBox
    Friend WithEvents btnEditarProducto As Button
    Friend WithEvents btnEliminarProducto As Button
    Friend WithEvents btnCargarProductos As Button
    Friend WithEvents btnNuevoProducto As Button
    Friend WithEvents dgvProductos As DataGridView
End Class
