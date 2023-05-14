Public Class frmMenu

    Private numericUpDown As NumericUpDown ' Variable de clase para guardar la referencia al control
    Private lblTotal As Double = 0 ' Variable para guardar el total acumulado
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnComida_Click(sender As Object, e As EventArgs) Handles btnComida.Click
        pnlComida.Height = btnComida.Height
        pnlComida.Top = btnComida.Height
        pnlindxComidas.Visible = True
        pnlIndxBebidas.Visible = False
        pnlindixPostres.Visible = False
        pnlindixCarrito.Visible = False
        pnlindixNosotros.Visible = False

    End Sub

    Private Sub btnBebidas_Click(sender As Object, e As EventArgs) Handles btnBebidas.Click
        pnlBebidas.Height = btnBebidas.Height
        pnlBebidas.Top = btnBebidas.Height
        pnlindxComidas.Visible = False
        pnlIndxBebidas.Visible = True
        pnlindixPostres.Visible = False
        pnlindixCarrito.Visible = False
        pnlindixNosotros.Visible = False
    End Sub
    Private Sub btnPostres_Click(sender As Object, e As EventArgs) Handles btnPostres.Click
        pnlPostres.Height = btnPostres.Height
        pnlPostres.Top = btnPostres.Height
        pnlindxComidas.Visible = False
        pnlIndxBebidas.Visible = False
        pnlindixPostres.Visible = True
        pnlindixCarrito.Visible = False
        pnlindixNosotros.Visible = False
    End Sub

    Private Sub btnCarrito_Click(sender As Object, e As EventArgs) Handles btnCarrito.Click
        pnlCarrito.Height = btnCarrito.Height
        pnlCarrito.Top = btnCarrito.Height
        pnlindxComidas.Visible = False
        pnlIndxBebidas.Visible = False
        pnlindixPostres.Visible = False
        pnlindixCarrito.Visible = True
        pnlindixNosotros.Visible = False
    End Sub

    Private Sub btnNosotros_Click(sender As Object, e As EventArgs) Handles btnNosotros.Click

        pnlNosotros.Height = btnNosotros.Height
        pnlNosotros.Top = btnNosotros.Height
        pnlindxComidas.Visible = False
        pnlIndxBebidas.Visible = False
        pnlindixPostres.Visible = False
        pnlindixCarrito.Visible = False
        pnlindixNosotros.Visible = True
    End Sub
    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles pnlTopSize.Paint

    End Sub

    Private Sub pnlLeftSize_Paint(sender As Object, e As PaintEventArgs) Handles pnlLeftSize.Paint

    End Sub

    Private Sub pnlCarrito_Paint(sender As Object, e As PaintEventArgs) Handles pnlCarrito.Paint

    End Sub





    Private Sub pnlNosotros_Paint(sender As Object, e As PaintEventArgs) Handles pnlNosotros.Paint

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub pnlindixPostres_Paint(sender As Object, e As PaintEventArgs) Handles pnlindixPostres.Paint

    End Sub

    Private Sub pnlComida_Paint(sender As Object, e As PaintEventArgs) Handles pnlComida.Paint

    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label21_Click(sender As Object, e As EventArgs)

    End Sub

    Public Sub btnPizza_Click(sender As Object, e As EventArgs) Handles btnPizza.Click

        Dim numericUpDown As New NumericUpDown ' Crear un nuevo control NumericUpDown
        numericUpDown.Name = "numCantidadPizza" ' Asignar un nombre al control
        numericUpDown.Minimum = 0 ' Establecer el valor mínimo
        numericUpDown.Maximum = 10 ' Establecer el valor máximo
        numericUpDown.Value = 1 ' Establecer el valor predeterminado
        numericUpDown.Location = New Point(380, 95) ' Establecer la ubicación del control en el panel
        pnlindixCarrito.Controls.Add(numericUpDown) ' Agregar el control NumericUpDown al panel

        cantidadPizza = CInt(numericUpDown.Value)

        Dim btnSumar As New Button ' Crear un nuevo botón
        btnSumar.Name = "btnSumarPizza" ' Asignar un nombre al botón
        btnSumar.Text = "Sumar" ' Establecer el texto del botón
        btnSumar.Location = New Point(200, 83) ' Establecer la ubicación del botón en el panel

        pnlindixCarrito.Controls.Add(btnSumar) ' Agregar el botón al panel
        AddHandler btnSumar.Click, AddressOf btnSumar_Click ' Agregar un controlador de eventos para el botón

        Dim pictureBox As New PictureBox ' Crear un nuevo control PictureBox
        pictureBox.Name = "picPizza" ' Asignar un nombre al control
        pictureBox.Location = New Point(45, 83) ' Establecer la ubicación del control en el panel
        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage ' Establecer el modo de tamaño para que la imagen se ajuste al tamaño del control
        pictureBox.Image = Image.FromFile("C:\Users\Brand\OneDrive\Imágenes\Piza.png") ' Establecer la imagen a mostrar en el control


        pnlindixCarrito.Controls.Add(pictureBox) ' Agregar el control PictureBox al pane


    End Sub

    Dim cantidadPizza As Integer
    Dim TotalPizza As Double

    Private Sub btnSumar_Click(sender As Object, e As EventArgs)

        Dim cantidad As Integer = CInt(pnlindixCarrito.Controls("numCantidadPizza").Text)
        Dim compras As New Compras
        Dim totalPizza As Double = compras.CompraPizza(cantidad)

        Dim lblTotalPizza As Label = DirectCast(pnlindixCarrito.Controls.Find("lblTotalPizza", True).FirstOrDefault(), Label)

        If lblTotalPizza Is Nothing Then
            lblTotalPizza = New Label
            lblTotalPizza.Name = "lblTotalPizza"
            lblTotalPizza.Location = New Point(380, 120)
            pnlindixCarrito.Controls.Add(lblTotalPizza)
        End If

        lblTotalPizza.Text = "Total: $" & totalPizza.ToString() & " (Cantidad: " & cantidad.ToString() & ")"

    End Sub

End Class
