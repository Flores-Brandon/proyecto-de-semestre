<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ticket
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
        Me.lblTicket = New System.Windows.Forms.Label()
        Me.btnGenerarTicket = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblTicket
        '
        Me.lblTicket.Location = New System.Drawing.Point(47, 111)
        Me.lblTicket.Name = "lblTicket"
        Me.lblTicket.Size = New System.Drawing.Size(449, 275)
        Me.lblTicket.TabIndex = 2
        '
        'btnGenerarTicket
        '
        Me.btnGenerarTicket.Location = New System.Drawing.Point(172, 12)
        Me.btnGenerarTicket.Name = "btnGenerarTicket"
        Me.btnGenerarTicket.Size = New System.Drawing.Size(135, 55)
        Me.btnGenerarTicket.TabIndex = 1
        Me.btnGenerarTicket.Text = "CERRAR APP"
        Me.btnGenerarTicket.UseVisualStyleBackColor = True
        '
        'Ticket
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 470)
        Me.Controls.Add(Me.lblTicket)
        Me.Controls.Add(Me.btnGenerarTicket)
        Me.Name = "Ticket"
        Me.Text = "Ticket"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTicket As Label
    Friend WithEvents btnGenerarTicket As Button
End Class
