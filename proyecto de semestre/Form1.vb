Imports System.IO
Imports System.Security.Cryptography.X509Certificates

Public Class frmMenu
    Private comentarios As List(Of String) = New List(Of String)()
    Private archivoComentarios As String = "comentarios.txt"
    Private pedidoComida As New Comida()
    Private pedidoBebidas As New Bebidas()
    Private pedidoPostres As New Postres()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Agregar las columnas al DataGridView
        dgvCarrito.Columns.Add("Producto", "Producto")
        dgvCarrito.Columns.Add("Cantidad", "Cantidad")
        dgvCarrito.Columns.Add("Precio Unitario", "Precio Unitario")
        dgvCarrito.Columns.Add("Precio Total", "Precio Total")
        dgvCarrito.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells ' Ajusta automáticamente el tamaño de la primera columna basado en el contenido
        dgvCarrito.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill ' Ajusta automáticamente el tamaño de la segunda columna para llenar el espacio restante

        CargarComentarios()

    End Sub
    Private Sub btnOrdenar_Click(sender As Object, e As EventArgs) Handles btnOrdenar.Click
        ' Adjust the height of the pnlPasar a Recoger panel to match the height of the btnComida button
        pnlOrdenar.Height = btnOrdenar.Height

        ' Position the pnlComida panel at the top of the btnComida button
        pnlOrdenar.Top = btnOrdenar.Height

        ' Show the pnlindxComidas panel and hide the other panels
        pnlindxComidas.Visible = False
        pnlIndxBebidas.Visible = False
        pnlindixPostres.Visible = False
        pnlindixCarrito.Visible = False
        pnlindixInicio.Visible = False
        pnlindixComentario.Visible = False
        pnlindixOrdenar.Visible = True
    End Sub
    Private Sub btnComida_Click(sender As Object, e As EventArgs) Handles btnComida.Click

        ' Adjust the height of the pnlComida panel to match the height of the btnComida button
        pnlComida.Height = btnComida.Height

        ' Position the pnlComida panel at the top of the btnComida button
        pnlComida.Top = btnComida.Height

        ' Show the pnlindxComidas panel and hide the other panels
        pnlindxComidas.Visible = True
        pnlIndxBebidas.Visible = False
        pnlindixPostres.Visible = False
        pnlindixCarrito.Visible = False
        pnlindixInicio.Visible = False
        pnlindixComentario.Visible = False
        pnlindixOrdenar.Visible = False

    End Sub

    Private Sub btnBebidas_Click(sender As Object, e As EventArgs) Handles btnBebidas.Click
        ' Adjust the height of the pnlBebidas panel to match the height of the btnBebidas button
        pnlBebidas.Height = btnBebidas.Height

        ' Position the pnlBebidas panel at the top of the btnBebidas button
        pnlBebidas.Top = btnBebidas.Height

        ' Show the pnlIndxBebidas panel and hide the other panels
        pnlindxComidas.Visible = False
        pnlIndxBebidas.Visible = True
        pnlindixPostres.Visible = False
        pnlindixCarrito.Visible = False
        pnlindixInicio.Visible = False
        pnlindixComentario.Visible = False
        pnlindixOrdenar.Visible = False

    End Sub
    Private Sub btnPostres_Click(sender As Object, e As EventArgs) Handles btnPostres.Click
        ' Adjust the height of the pnlPostres panel to match the height of the btnPostres button
        pnlPostres.Height = btnPostres.Height

        ' Position the pnlPostres panel at the top of the btnPostres button
        pnlPostres.Top = btnPostres.Height

        ' Show the pnlindixPostres panel and hide the other panels
        pnlindxComidas.Visible = False
        pnlIndxBebidas.Visible = False
        pnlindixPostres.Visible = True
        pnlindixCarrito.Visible = False
        pnlindixInicio.Visible = False
        pnlindixComentario.Visible = False
        pnlindixOrdenar.Visible = False
    End Sub

    Private Sub btnCarrito_Click(sender As Object, e As EventArgs) Handles btnCarrito.Click
        ' Adjust the height of the pnlCarrito panel to match the height of the btnCarrito button
        pnlCarrito.Height = btnCarrito.Height

        ' Position the pnlCarrito panel at the top of the btnCarrito button
        pnlCarrito.Top = btnCarrito.Height

        ' Show the pnlindixCarrito panel and hide the other panels
        pnlindxComidas.Visible = False
        pnlIndxBebidas.Visible = False
        pnlindixPostres.Visible = False
        pnlindixCarrito.Visible = True
        pnlindixInicio.Visible = False
        pnlindixComentario.Visible = False
        pnlindixOrdenar.Visible = False
    End Sub

    Private Sub btnNosotros_Click(sender As Object, e As EventArgs) Handles btnInicio.Click
        ' Adjust the height of the pnlNosotros panel to match the height of the btnInicio button
        pnlNosotros.Height = btnInicio.Height

        ' Position the pnlNosotros panel at the top of the btnInicio button
        pnlNosotros.Top = btnInicio.Height

        ' Show the pnlindixInicio panel and hide the other panels
        pnlindxComidas.Visible = False
        pnlIndxBebidas.Visible = False
        pnlindixPostres.Visible = False
        pnlindixCarrito.Visible = False
        pnlindixInicio.Visible = True
        pnlindixComentario.Visible = False
        pnlindixOrdenar.Visible = False
    End Sub
    Private Sub btnComentarios_Click(sender As Object, e As EventArgs) Handles btnComentarios.Click
        ' Adjust the height of the pnlComentarios panel to match the height of the btnInicio button
        pnlComentarios.Height = btnInicio.Height

        ' Position the pnlComentarios panel at the top of the btnInicio button
        pnlComentarios.Top = btnInicio.Height

        ' Show the pnlindixComentario panel and hide the other panels
        pnlindxComidas.Visible = False
        pnlIndxBebidas.Visible = False
        pnlindixPostres.Visible = False
        pnlindixCarrito.Visible = False
        pnlindixInicio.Visible = False
        pnlindixComentario.Visible = True
        pnlindixOrdenar.Visible = False

    End Sub
    'Creeamos el evento para cuando seleccione una cantidad en el nud a la hora de precionar agregar al carrito los regrese al valor 0
    Private Sub LimpiarV()
        nudAgua.Value = 0
        nudBrochetas.Value = 0
        nudBurrito.Value = 0
        nudCafe.Value = 0
        nudCerveza.Value = 0
        nudHamburguesa.Value = 0
        nudHelado.Value = 0
        nudHotDog.Value = 0
        nudJugo.Value = 0
        nudNugget.Value = 0
        nudPastel.Value = 0
        nudPay.Value = 0
        nudPizza.Value = 0
        nudRefresco.Value = 0
        nudTe.Value = 0
    End Sub

    Private Sub btnAggComida_Click(sender As Object, e As EventArgs) Handles btnAggComida.Click
        ' Get the amounts of the NumericUpDown
        Dim pizzaCantidad As Integer = nudPizza.Value
        Dim hamburguesaCantidad As Integer = nudHamburguesa.Value
        Dim burritosCantidad As Integer = nudBurrito.Value
        Dim brochetasCantidad As Integer = nudBrochetas.Value
        Dim hotDogCantidad As Integer = nudHotDog.Value
        Dim nuggetCantidad As Integer = nudNugget.Value

        ' Create an instance of the shopping class
        Dim compra As New Compras()

        ' Calculate the total price of each type of meal
        Dim pizzaPrecioTotal As Int64 = compra.CalcularPrecioTotalComida(pizzaCantidad, compra.Pizza)
        Dim hamburguesaPrecioTotal As Int64 = compra.CalcularPrecioTotalComida(hamburguesaCantidad, compra.Hamburguesa)
        Dim burritosPrecioTotal As Int64 = compra.CalcularPrecioTotalComida(burritosCantidad, compra.Burritos)
        Dim brochetasPrecioTotal As Int64 = compra.CalcularPrecioTotalComida(brochetasCantidad, compra.Brochetas)
        Dim hotDogPrecioTotal As Int64 = compra.CalcularPrecioTotalComida(hotDogCantidad, compra.HotDog)
        Dim nuggetPrecioTotal As Int64 = compra.CalcularPrecioTotalComida(nuggetCantidad, compra.Nuggets)

        ' Add the rows to the DataGridView if the number is greater than 0
        If pizzaCantidad > 0 Then
            dgvCarrito.Rows.Add("Pizza", pizzaCantidad, compra.Pizza, pizzaPrecioTotal)
        End If

        If hamburguesaCantidad > 0 Then
            dgvCarrito.Rows.Add("Hamburguesa", hamburguesaCantidad, compra.Hamburguesa, hamburguesaPrecioTotal)
        End If

        If burritosCantidad > 0 Then
            dgvCarrito.Rows.Add("Burritos", burritosCantidad, compra.Burritos, burritosPrecioTotal)
        End If

        If brochetasCantidad > 0 Then
            dgvCarrito.Rows.Add("Brochetas", brochetasCantidad, compra.Brochetas, brochetasPrecioTotal)
        End If

        If hotDogCantidad > 0 Then
            dgvCarrito.Rows.Add("Hot dog", hotDogCantidad, compra.HotDog, hotDogPrecioTotal)
        End If

        If nuggetCantidad > 0 Then
            dgvCarrito.Rows.Add("Nuggets", nuggetCantidad, compra.Nuggets, nuggetPrecioTotal)
        End If
        'Agregamos el evento llamado LimpiarV
        LimpiarV()
    End Sub

    Private Sub btnAggBebidas_Click(sender As Object, e As EventArgs) Handles btnAggBebidas.Click
        ' Get the amounts of the NumericUpDown
        Dim RefrescosCantidad As Integer = nudRefresco.Value
        Dim JugosCantidad As Integer = nudJugo.Value
        Dim CafeCantidad As Integer = nudCafe.Value
        Dim AguaCantidad As Integer = nudAgua.Value
        Dim CervezaCantidad As Integer = nudCerveza.Value
        Dim TeCantidad As Integer = nudTe.Value

        ' Create an instance of the shopping class
        Dim compra As New Compras()

        ' Calculate the total price of each type of drinks
        Dim RefrescosPrecioTotal As Int64 = compra.CalcularPrecioTotalBebida(RefrescosCantidad, compra.Refresco)
        Dim JugosPrecioTotal As Int64 = compra.CalcularPrecioTotalBebida(JugosCantidad, compra.Jugos)
        Dim CafePrecioTotal As Int64 = compra.CalcularPrecioTotalBebida(CafeCantidad, compra.Cafe)
        Dim AguaPrecioTotal As Int64 = compra.CalcularPrecioTotalBebida(AguaCantidad, compra.Agua)
        Dim CervezaPrecioTotal As Int64 = compra.CalcularPrecioTotalBebida(CervezaCantidad, compra.Cerveza)
        Dim TePrecioTotal As Int64 = compra.CalcularPrecioTotalBebida(TeCantidad, compra.Té)

        ' Add the rows to the DataGridView if the number is greater than 0
        If RefrescosCantidad > 0 Then
            dgvCarrito.Rows.Add("Refrescos", RefrescosCantidad, compra.Refresco, RefrescosPrecioTotal)
        End If
        If JugosCantidad > 0 Then
            dgvCarrito.Rows.Add("Jugos", JugosCantidad, compra.Jugos, JugosPrecioTotal)
        End If
        If CafeCantidad > 0 Then
            dgvCarrito.Rows.Add("Café", CafeCantidad, compra.Cafe, CafeCantidad)
        End If
        If AguaCantidad > 0 Then
            dgvCarrito.Rows.Add("Agua", AguaCantidad, compra.Agua, AguaPrecioTotal)
        End If
        If CervezaCantidad > 0 Then
            dgvCarrito.Rows.Add("Cerveza", CervezaCantidad, compra.Cerveza, CervezaPrecioTotal)
        End If
        If TeCantidad > 0 Then
            dgvCarrito.Rows.Add("Té Helado", TeCantidad, compra.Té, TePrecioTotal)
        End If
        'Agregamos el evento llamado LimpiarV
        LimpiarV()
    End Sub

    Private Sub btnAggPostre_Click(sender As Object, e As EventArgs) Handles btnAggPostre.Click
        ' Get the amounts of the NumericUpDown
        Dim HeladoCantidad As Integer = nudHelado.Value
        Dim PastelCantidad As Integer = nudPastel.Value
        Dim PayCantidad As Integer = nudPay.Value

        ' Create an instance of the shopping class
        Dim compra As New Compras()

        ' Calculate the total price of each type of dessert
        Dim HeladoPrecioTotal As Int64 = compra.CalcularPrecioTotalPostre(HeladoCantidad, compra.Helado)
        Dim PastelPrecioTotal As Int64 = compra.CalcularPrecioTotalPostre(PastelCantidad, compra.Pastel)
        Dim PayPrecioTotal As Int64 = compra.CalcularPrecioTotalPostre(PayCantidad, compra.Pay)

        ' Verificar si la cantidad es mayor a 0 antes de agregar las filas al DataGridView
        If HeladoCantidad > 0 Then
            dgvCarrito.Rows.Add("Helado", HeladoCantidad, compra.Helado, HeladoPrecioTotal)
        End If

        If PastelCantidad > 0 Then
            dgvCarrito.Rows.Add("Pastel", PastelCantidad, compra.Pastel, PastelPrecioTotal)
        End If

        If PayCantidad > 0 Then
            dgvCarrito.Rows.Add("Pay", PayCantidad, compra.Pay, PayPrecioTotal)
        End If
        'Agregamos el evento llamado LimpiarV
        LimpiarV()
    End Sub

    Private Sub btnPago_Click(sender As Object, e As EventArgs) Handles btnPago.Click
        ' Calculate the total sum of the "Total Price" column
        Dim sumaTotal As Integer
        For Each fila As DataGridViewRow In dgvCarrito.Rows
            sumaTotal += Convert.ToInt32(fila.Cells("Precio Total").Value)
        Next



        Dim productos As New List(Of String)() ' Create a List to store the product names

        For Each fila As DataGridViewRow In dgvCarrito.Rows
            Dim celdaProducto As DataGridViewCell = fila.Cells("Producto") ' Get the "Product" cell
            Dim celdaCantidad As DataGridViewCell = fila.Cells("Cantidad") ' Get the "Quantity" cell
            Dim celdaPrecio As DataGridViewCell = fila.Cells("Precio Unitario") ' Get the "Unit Price" cell

            If celdaProducto.Value IsNot Nothing AndAlso celdaCantidad.Value IsNot Nothing AndAlso celdaPrecio.Value IsNot Nothing Then ' Check if all cells have a value
                Dim producto As String = celdaProducto.Value.ToString() ' Get the value of the "Product" cell as a string
                Dim cantidad As String = celdaCantidad.Value.ToString() ' Get the value of the "Quantity" cell as a string
                Dim precio As String = celdaPrecio.Value.ToString() ' Get the value of the "Price" cell as a string
                Dim productoCantidadPrecio As String = producto & "..........." & cantidad & "..........." & "$" & precio ' Concatenate the product name, quantity, price with the "$" sign, and separated by dots

                productos.Add(productoCantidadPrecio) ' Add the product name, quantity, and price to the list
            End If
        Next

        ' Convert the List to an array of strings
        Dim productosArray As String() = productos.ToArray()

        Dim ticketForm As New Ticket(sumaTotal, productosArray) ' Create an instance of your ticket form, passing the array as a parameter
        ticketForm.ShowDialog() ' Show the ticket form
    End Sub

    Private Sub btnSumaTotal_Click(sender As Object, e As EventArgs) Handles btnSumaTotal.Click
        ' Calculate the total sum of the "Final Price" column
        Dim sumaTotal As Integer
        For Each fila As DataGridViewRow In dgvCarrito.Rows
            sumaTotal += Convert.ToInt32(fila.Cells("Precio Total").Value)
        Next

        ' Display the total sum in the label
        lblMostrarPago.Text = "Total a pagar: $" + sumaTotal.ToString()

    End Sub

    Private Sub btnPizza_Click(sender As Object, e As EventArgs) Handles btnPizza.Click
        ' Declare the array of pizza ingredients
        Dim ingredientesPizza() As String = {"Masa de pizza", "Salsa de tomate", "Queso", "Pepperoni", "Champiñones", "Cebolla", "Pimiento"}

        ' Show the pizza ingredients in a MessageBox
        MessageBox.Show("La pizza lleva los siguientes ingredientes:" & Environment.NewLine & String.Join(Environment.NewLine, ingredientesPizza))
    End Sub

    Private Sub btnHamburguesa_Click(sender As Object, e As EventArgs) Handles btnHamburguesa.Click
        ' Declare the array of hamburger ingredients
        Dim ingredientesHamburguesa() As String = {"Pan", "Mayonesa", "Mostaza", "Carne de Res O Pollo", "Queso", "Lechuga", "Tomate", "Cebolla", "Jamon"}

        ' Show the hamburger ingredients in a MessageBox
        MessageBox.Show("La Hamburguesa lleva los siguientes ingredientes:" & Environment.NewLine & String.Join(Environment.NewLine, ingredientesHamburguesa))
    End Sub

    Private Sub btnBurrito_Click(sender As Object, e As EventArgs) Handles btnBurrito.Click
        ' Declare the array of burrito ingredients
        Dim ingredientesBurrito() As String = {"Tortilla", "Pollo O Carne Desebrada", "Frijoles", "Lechuga", "Tomate", "Crema"}

        ' Show the burrito ingredients in a MessageBox
        MessageBox.Show("El Burrito lleva los siguientes ingredientes:" & Environment.NewLine & String.Join(Environment.NewLine, ingredientesBurrito))
    End Sub

    Private Sub btnBrochetas_Click(sender As Object, e As EventArgs) Handles btnBrochetas.Click
        ' Declare the array of kebab ingredients
        Dim ingredientesBrochetas() As String = {"Carne", "Piña", "Chile Morron", "Tocino", "Salsa Especial De La Casa"}

        ' Show the kebab ingredients in a MessageBox
        MessageBox.Show("Las Brochetas llevan los siguientes ingredientes:" & Environment.NewLine & String.Join(Environment.NewLine, ingredientesBrochetas))
    End Sub

    Private Sub btnNuggets_Click(sender As Object, e As EventArgs) Handles btnNuggets.Click
        ' Declare the array of nugget ingredients
        Dim ingredientesNuggets() As String = {"Pollo", "Salsas Al gusto", "Papas Fritas"}

        ' Show the nugget ingredients in a MessageBox
        MessageBox.Show("Los Nuggets llevan los siguientes ingredientes:" & Environment.NewLine & String.Join(Environment.NewLine, ingredientesNuggets))
    End Sub

    Private Sub btnHotDog_Click(sender As Object, e As EventArgs) Handles btnHotDog.Click
        ' Declare the array of hot dog ingredients
        Dim ingredientesHotDog() As String = {"Pan", "Salchicha", "Cebolla", "Tocino", "Tomate", "Mostaza", "Salsa Tomate"}

        ' Show the hot dog ingredients in a MessageBox
        MessageBox.Show("El Hot Dog lleva los siguientes ingredientes:" & Environment.NewLine & String.Join(Environment.NewLine, ingredientesHotDog))
    End Sub

    Private Sub btnHelado_Click(sender As Object, e As EventArgs) Handles btnHelado.Click
        ' Declare the array of ice cream ingredients
        Dim ingredientesHelado() As String = {"Nieve De Vainilla", "Cereza", "Galleta", "Chocolate Derretido", "Chispas"}

        ' Show the ice cream ingredients in a MessageBox
        MessageBox.Show("El Helado lleva los siguientes ingredientes:" & Environment.NewLine & String.Join(Environment.NewLine, ingredientesHelado))
    End Sub

    Private Sub btnPastel_Click(sender As Object, e As EventArgs) Handles btnPastel.Click
        ' Declare the array of cake ingredients
        Dim ingredientesPastel() As String = {"Pan", "Fresas", "Leche", "Betun de Vainilla"}

        ' Show the cake ingredients in a MessageBox

        MessageBox.Show("El Pastel lleva los siguientes ingredientes:" & Environment.NewLine & String.Join(Environment.NewLine, ingredientesPastel))
    End Sub

    Private Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click
        ' Declare the array of pay ingredients
        Dim ingredientesPay() As String = {"Fresas", "Base de Galleta", "Queso Fhiladelfhia", "Leche Condenzada", "Leche Evaporada", "Queso Panela", "Mermelada"}

        ' Show the Pay ingredients in a MessageBox
        MessageBox.Show("El Pay lleva los siguientes ingredientes:" & Environment.NewLine & String.Join(Environment.NewLine, ingredientesPay))
    End Sub

    Private Sub btnRefresco_Click(sender As Object, e As EventArgs) Handles btnRefresco.Click
        ' Declare the array of Refreshment ingredients
        Dim ingredientesRefrescos() As String = {"Coca Cola", "Sprite", "Manzanita", "Fanta", "Pepsi"}

        ' Show the Refreshment ingredients in a MessageBox
        MessageBox.Show("Tenemos los siguientes Sabores:" & Environment.NewLine & String.Join(Environment.NewLine, ingredientesRefrescos))
    End Sub

    Private Sub btnJugos_Click(sender As Object, e As EventArgs) Handles btnJugos.Click
        ' Declare the array of Juice ingredients
        Dim ingredientesJugos() As String = {"Naranja", "Manzana", "Melon", "Platano", "Sandia", "Durazno", "Pimiento"}

        ' Show the Juice ingredients in a MessageBox
        MessageBox.Show("Tenemos los siguientes tipos de jugos:" & Environment.NewLine & String.Join(Environment.NewLine, ingredientesJugos))
    End Sub

    Private Sub btnCafe_Click(sender As Object, e As EventArgs) Handles btnCafe.Click
        ' Declare the array of coffee ingredients
        Dim ingredientesCafe() As String = {"Americano", "Expresso", "Macchiato", "Cafe con Leche", "Capuchino", "Moca"}

        ' Show the coffee ingredients in a MessageBox
        MessageBox.Show("Tenemos estos tipos de caffes:" & Environment.NewLine & String.Join(Environment.NewLine, ingredientesCafe))
    End Sub

    Private Sub btnAgua_Click(sender As Object, e As EventArgs) Handles btnAgua.Click
        ' Declarar el arreglo de ingredientes del Agua
        Dim ingredientesAgua() As String = {"Agua", "Agua Mineral"}

        ' Mostrar los ingredientes del Agua en un MessageBox
        MessageBox.Show("Tenemos estos tipos de agua :" & Environment.NewLine & String.Join(Environment.NewLine, ingredientesAgua))
    End Sub

    Private Sub btnCerveza_Click(sender As Object, e As EventArgs) Handles btnCerveza.Click
        ' Declare the array of beer ingredients
        Dim ingredientesCerveza() As String = {"Tecate", "Corona", "Indio"}

        ' Show the beer ingredients in a MessageBox
        MessageBox.Show("Tenemos las siguientes variedades de Cervezas:" & Environment.NewLine & String.Join(Environment.NewLine, ingredientesCerveza))
    End Sub

    Private Sub btnTe_Click(sender As Object, e As EventArgs) Handles btnTe.Click

        ' Declare the array of iced tea ingredients
        Dim ingredientesTe() As String = {"Limon y Miel", "Menta", "Te Verde", "Te Negro"}

        ' Show the iced tea ingredients in a MessageBox
        MessageBox.Show("Tenemos estos tipos de Tés:" & Environment.NewLine & String.Join(Environment.NewLine, ingredientesTe))
    End Sub
    ' Create the function to save comments
    Private Sub btnComentario_Click(sender As Object, e As EventArgs) Handles btnComentario.Click
        ' Retrieve the comment from the text box
        Dim comentario As String = txtComentario.Text
        ' Check if the comment is empty or consists of only whitespace characters
        If String.IsNullOrWhiteSpace(comentario) Then
            ' Display an error message if the comment is invalid
            lblMensaje.Text = "Comentario inválido. Por favor, escribe algo."
        Else
            ' Add the comment to the list of comments
            comentarios.Add(comentario)
            ' Save the comments to a file
            GuardarComentarios()
            ' Clear the text box after saving the comment
            txtComentario.Clear()
            ' Display a success message indicating that the comment has been saved
            lblMensaje.Text = "Comentario guardado correctamente."
        End If
    End Sub

    Private Sub btnMostrarComentario_Click(sender As Object, e As EventArgs) Handles btnMostrarComentario.Click
        ' Display the comments in the label if there are any, otherwise display a message indicating no comments
        lblComentarios.Text = If(comentarios.Count > 0, String.Join(vbCrLf, comentarios), "No hay comentarios.")
    End Sub

    Private Sub CargarComentarios()
        ' Check if the comments file exists
        If File.Exists(archivoComentarios) Then
            ' Load the comments from the file into the list of comments
            comentarios = File.ReadAllLines(archivoComentarios).ToList()
        End If
    End Sub

    Private Sub GuardarComentarios()
        ' Save the comments to the comments file
        File.WriteAllLines(archivoComentarios, comentarios)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
        ' Closes the application.
    End Sub

    Private Sub btnAggComidas_Click(sender As Object, e As EventArgs) Handles btnAggComidas.Click
        ' Event handler for the "Agregar Comidas" button click.

        pedidoComida.MostrarTiposPlatillos()
        ' Calls the MostrarTiposPlatillos method of the pedidoComida object to display the available food options.

        Dim seleccion As Integer
        ' Variable to store the user's selection.

        If Integer.TryParse(InputBox("Ingrese el número del platillo que desea agregar:", "Agregar Platillo"), seleccion) Then
            ' Prompts the user to enter the number of the food item they want to add and tries to parse it as an integer.

            Dim platillo As String = pedidoComida.SeleccionarPlatillo(seleccion)
            ' Calls the SeleccionarPlatillo method of the pedidoComida object to retrieve the selected food item based on the user's input.

            If Not String.IsNullOrWhiteSpace(platillo) Then
                ' Checks if the selected food item is not empty or null.

                Dim cantidad As Integer
                ' Variable to store the quantity of the selected food item.

                If Integer.TryParse(InputBox($"Ingrese la cantidad de {platillo}:", "Agregar Cantidad"), cantidad) Then
                    ' Prompts the user to enter the quantity of the selected food item and tries to parse it as an integer.

                    pedidoComida.AgregarPlatillo(platillo, cantidad)
                    ' Calls the AgregarPlatillo method of the pedidoComida object to add the selected food item with the specified quantity.

                    MessageBox.Show($"Se ha seleccionado {cantidad} {platillo}(s).")
                    ' Displays a message box indicating the successful selection of the food item.

                Else
                    MessageBox.Show("Cantidad inválida. Intente nuevamente.")
                    ' Displays an error message if the entered quantity is invalid (not a valid integer).

                End If
            Else
                MessageBox.Show("Platillo inválido. Intente nuevamente.")
                ' Displays an error message if the selected food item is invalid (not found in the available options).

            End If
        Else
            MessageBox.Show("Selección inválida. Intente nuevamente.")
            ' Displays an error message if the entered selection is invalid (not a valid integer).

        End If
    End Sub

    Private Sub btnAggBebida_Click(sender As Object, e As EventArgs) Handles btnAggBebida.Click
        ' Event handler for the "Agregar Bebida" button click.

        pedidoBebidas.MostrarTiposPlatillos()
        ' Calls the MostrarTiposPlatillos method of the pedidoBebidas object to display the available drink options.

        Dim seleccion As Integer
        ' Variable to store the user's selection.

        If Integer.TryParse(InputBox("Ingrese el número de la bebida que desea agregar:", "Agregar Bebida"), seleccion) Then
            ' Prompts the user to enter the number of the drink item they want to add and tries to parse it as an integer.

            Dim bebida As String = pedidoBebidas.SeleccionarPlatillo(seleccion)
            ' Calls the SeleccionarPlatillo method of the pedidoBebidas object to retrieve the selected drink item based on the user's input.

            If Not String.IsNullOrWhiteSpace(bebida) Then
                ' Checks if the selected drink item is not empty or null.

                Dim cantidad As Integer
                ' Variable to store the quantity of the selected drink item.

                If Integer.TryParse(InputBox($"Ingrese la cantidad de {bebida}:", "Agregar Cantidad"), cantidad) Then
                    ' Prompts the user to enter the quantity of the selected drink item and tries to parse it as an integer.

                    pedidoBebidas.AgregarPlatillo(bebida, cantidad)
                    ' Calls the AgregarPlatillo method of the pedidoBebidas object to add the selected drink item with the specified quantity.

                    MessageBox.Show($"Se ha seleccionado {cantidad} {bebida}(s).")
                    ' Displays a message box indicating the successful selection of the drink item.

                Else
                    MessageBox.Show("Cantidad inválida. Intente nuevamente.")
                    ' Displays an error message if the entered quantity is invalid (not a valid integer).

                End If
            Else
                MessageBox.Show("Bebida inválida. Intente nuevamente.")
                ' Displays an error message if the selected drink item is invalid (not found in the available options).

            End If
        Else
            MessageBox.Show("Selección inválida. Intente nuevamente.")
            ' Displays an error message if the entered selection is invalid (not a valid integer).

        End If
    End Sub

    Private Sub btnAggPostres_Click(sender As Object, e As EventArgs) Handles btnAggPostres.Click
        ' Event handler for the "Agregar Postre" button click.

        pedidoPostres.MostrarTiposPlatillos()
        ' Calls the MostrarTiposPlatillos method of the pedidoPostres object to display the available dessert options.

        Dim seleccion As Integer
        ' Variable to store the user's selection.

        If Integer.TryParse(InputBox("Ingrese el número del postre que desea agregar:", "Agregar Postre"), seleccion) Then
            ' Prompts the user to enter the number of the dessert item they want to add and tries to parse it as an integer.

            Dim postre As String = pedidoPostres.SeleccionarPlatillo(seleccion)
            ' Calls the SeleccionarPlatillo method of the pedidoPostres object to retrieve the selected dessert item based on the user's input.

            If Not String.IsNullOrWhiteSpace(postre) Then
                ' Checks if the selected dessert item is not empty or null.

                Dim cantidad As Integer
                ' Variable to store the quantity of the selected dessert item.

                If Integer.TryParse(InputBox($"Ingrese la cantidad de {postre}:", "Agregar Cantidad"), cantidad) Then
                    ' Prompts the user to enter the quantity of the selected dessert item and tries to parse it as an integer.

                    pedidoPostres.AgregarPlatillo(postre, cantidad)
                    ' Calls the AgregarPlatillo method of the pedidoPostres object to add the selected dessert item with the specified quantity.

                    MessageBox.Show($"Se ha seleccionado {cantidad} {postre}(s).")
                    ' Displays a message box indicating the successful selection of the dessert item.

                Else
                    MessageBox.Show("Cantidad inválida. Intente nuevamente.")
                    ' Displays an error message if the entered quantity is invalid (not a valid integer).

                End If
            Else
                MessageBox.Show("Postre inválido. Intente nuevamente.")
                ' Displays an error message if the selected dessert item is invalid (not found in the available options).

            End If
        Else
            MessageBox.Show("Selección inválida. Intente nuevamente.")
            ' Displays an error message if the entered selection is invalid (not a valid integer).

        End If
    End Sub


    Private Sub btnOrden_Click(sender As Object, e As EventArgs) Handles btnOrden.Click
        ' Event handler for the "Orden" button click.

        ' Retrieve customer information
        Dim nombre As String = txtName.Text.Trim()
        Dim telefono As String = txtNumeroTelefonico.Text.Trim()
        Dim hora As String = txtHora.Text.Trim()

        ' Retrieve the order details from each category
        Dim ordenComida As List(Of String) = pedidoComida.ObtenerOrden()
        Dim ordenBebidas As List(Of String) = pedidoBebidas.ObtenerOrden()
        Dim ordenPostres As List(Of String) = pedidoPostres.ObtenerOrden()

        ' Calculate the total sum of the order
        Dim total As Decimal = pedidoComida.CalcularTotal() + pedidoBebidas.CalcularTotal() + pedidoPostres.CalcularTotal()

        ' Build the order message
        Dim mensaje As String = $"Nombre: {nombre}" & vbCrLf
        mensaje += $"Teléfono: {telefono}" & vbCrLf
        mensaje += $"Hora: {hora}" & vbCrLf
        mensaje += vbCrLf
        mensaje += "Orden:" & vbCrLf
        mensaje += "Comida:" & vbCrLf
        mensaje += If(ordenComida.Count > 0, String.Join(vbCrLf, ordenComida), "No se ha seleccionado comida") & vbCrLf
        mensaje += "Bebidas:" & vbCrLf
        mensaje += If(ordenBebidas.Count > 0, String.Join(vbCrLf, ordenBebidas), "No se ha seleccionado bebida") & vbCrLf
        mensaje += "Postres:" & vbCrLf
        mensaje += If(ordenPostres.Count > 0, String.Join(vbCrLf, ordenPostres), "No se ha seleccionado postre") & vbCrLf
        mensaje += vbCrLf
        mensaje += $"Total: ${total.ToString("0.00")}"

        ' Display the order message in a message box
        MessageBox.Show(mensaje, "Orden", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim camara As New Camara()
        camara.Show()
    End Sub


End Class


