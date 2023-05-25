Public MustInherit Class Pedido
    Public platillos As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)()
    Public precios As Dictionary(Of String, Decimal) = New Dictionary(Of String, Decimal)()
    Public platillosSeleccionados As Dictionary(Of Integer, Integer) = New Dictionary(Of Integer, Integer)()

    Public Sub MostrarTiposPlatillos()
        ' Displays the available dishes for the particular category
        Dim mensaje As String = "Available Dishes:" & vbCrLf
        For Each kvp As KeyValuePair(Of Integer, String) In platillos
            mensaje += $"{kvp.Key}. {kvp.Value} - Price: {precios(kvp.Value)}" & vbCrLf
        Next

        MessageBox.Show(mensaje)
    End Sub


    Public Function SeleccionarPlatillo(seleccion As Integer) As String
        ' Selects a dish based on the provided selection
        If platillos.ContainsKey(seleccion) Then
            Return platillos(seleccion)
        Else
            Return String.Empty
        End If
    End Function

    Public Sub AgregarPlatillo(platillo As String, cantidad As Integer)
        ' Adds a dish and its quantity to the selected dishes dictionary
        Dim seleccion As Integer = platillos.FirstOrDefault(Function(x) x.Value = platillo).Key
        If seleccion <> 0 Then
            If platillosSeleccionados.ContainsKey(seleccion) Then
                platillosSeleccionados(seleccion) += cantidad
            Else
                platillosSeleccionados.Add(seleccion, cantidad)
            End If
        End If
    End Sub

    Public MustOverride Function ObtenerOrden() As List(Of String)

    Public Function CalcularTotal() As Decimal
        ' Calculates the total cost of the selected dishes
        Dim total As Decimal = 0

        For Each kvp As KeyValuePair(Of Integer, Integer) In platillosSeleccionados
            Dim platillo As String = platillos(kvp.Key)
            Dim cantidad As Integer = kvp.Value
            Dim precio As Decimal = precios(platillo)
            Dim subtotal As Decimal = cantidad * precio

            total += subtotal
        Next

        Return total
    End Function
End Class

Public Class Comida
    Inherits Pedido

    Public Sub New()
        ' Constructor of the Comida class that initializes the available dishes and prices
        platillos.Add(1, "Pizza")
        platillos.Add(2, "Hamburguesa")
        platillos.Add(3, "Nuggets")
        platillos.Add(4, "HotDog")
        platillos.Add(5, "Burritos")
        platillos.Add(6, "Brochetas")

        precios.Add("Pizza", 140)
        precios.Add("Hamburguesa", 120)
        precios.Add("Nuggets", 70)
        precios.Add("HotDog", 90)
        precios.Add("Burritos", 110)
        precios.Add("Brochetas", 130)
    End Sub

    Public Overrides Function ObtenerOrden() As List(Of String)
        ' Returns a list of strings representing the selected dishes in the Comida order
        Dim orden As New List(Of String)

        For Each kvp As KeyValuePair(Of Integer, Integer) In platillosSeleccionados
            Dim platillo As String = platillos(kvp.Key)
            Dim cantidad As Integer = kvp.Value
            Dim precio As Decimal = precios(platillo)
            Dim subtotal As Decimal = cantidad * precio

            orden.Add($"{cantidad} x {platillo} - Subtotal: ${subtotal.ToString("0.00")}")
        Next

        Return orden
    End Function

End Class

Public Class Bebidas
    Inherits Pedido

    Public Sub New()
        ' Constructor of the Bebidas class that initializes the available drinks and prices
        platillos.Add(1, "Refresco")
        platillos.Add(2, "Agua")
        platillos.Add(3, "Jugo")
        platillos.Add(4, "Té")
        platillos.Add(5, "Café")

        precios.Add("Refresco", 30)
        precios.Add("Agua", 20)
        precios.Add("Jugo", 35)
        precios.Add("Té", 25)
        precios.Add("Café", 40)
    End Sub

    Public Overrides Function ObtenerOrden() As List(Of String)
        ' Returns a list of strings representing the selected drinks in the Bebidas order
        Dim orden As New List(Of String)

        For Each kvp As KeyValuePair(Of Integer, Integer) In platillosSeleccionados
            Dim platillo As String = platillos(kvp.Key)
            Dim cantidad As Integer = kvp.Value
            Dim precio As Decimal = precios(platillo)
            Dim subtotal As Decimal = cantidad * precio

            orden.Add($"{cantidad} x {platillo} - Subtotal: ${subtotal.ToString("0.00")}")
        Next

        Return orden
    End Function
End Class

Public Class Postres
    Inherits Pedido

    Public Sub New()
        ' Constructor of the Postres class that initializes the available desserts and prices
        platillos.Add(1, "Pastel")
        platillos.Add(2, "Helado")
        platillos.Add(3, "Pay")


        precios.Add("Pastel", 65)
        precios.Add("Helado", 40)
        precios.Add("Pay", 65)

    End Sub

    Public Overrides Function ObtenerOrden() As List(Of String)
        ' Returns a list of strings representing the selected desserts in the Postres order
        Dim orden As New List(Of String)

        For Each kvp As KeyValuePair(Of Integer, Integer) In platillosSeleccionados
            Dim platillo As String = platillos(kvp.Key)
            Dim cantidad As Integer = kvp.Value
            Dim precio As Decimal = precios(platillo)
            Dim subtotal As Decimal = cantidad * precio

            orden.Add($"{cantidad} x {platillo} - Subtotal: ${subtotal.ToString("0.00")}")
        Next

        Return orden
    End Function
End Class
