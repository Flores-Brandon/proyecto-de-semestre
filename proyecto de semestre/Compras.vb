
Class Compras
    'Here the foods variables are created with their value
    Public Property Pizza As Int64 = 140
    Public Property Hamburguesa As Int64 = 120
    Public Property Burritos As Int64 = 80
    Public Property Nuggets As Int64 = 70
    Public Property Brochetas As Int64 = 100
    Public Property HotDog As Int64 = 75
    'Here the drinks variables are created with their value

    Public Property Refresco As Int64 = 25
    Public Property Té As Int64 = 20
    Public Property Jugos As Int64 = 20
    Public Property Cafe As Int64 = 30
    Public Property Cerveza As Int64 = 75
    Public Property Agua As Int64 = 15

    'Here the deserts variables are created with their value
    Public Property Helado As Int64 = 40
    Public Property Pastel As Int64 = 65
    Public Property Pay As Int64 = 65

    ' Calcula el precio total de una comida
    Public Function CalcularPrecioTotalComida(cantidad As Integer, precio As Int64) As Int64
        Return cantidad * precio
    End Function

    ' Calcula el precio total de una bebida
    Public Function CalcularPrecioTotalBebida(cantidad As Integer, precio As Int64) As Int64
        Return cantidad * precio
    End Function

    ' Calcula el precio total de una Postres
    Public Function CalcularPrecioTotalPostre(cantidad As Integer, precio As Int64) As Int64
        Return cantidad * precio
    End Function
End Class
