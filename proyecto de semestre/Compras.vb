
Public Class Compras
    ''Here the food variables are created with their value
    Dim Pizza As Int64 = 140
    Dim Burrito As Int64 = 75
    Dim Hamburguesa As Int64 = 120
    Dim Brochetas As Int64 = 120
    Dim Nuggets As Int64 = 75
    Dim HotDog As Int64 = 80
    ''Here the drinks variables are created with their value
    Dim Refresco As Int64 = 25
    Dim Té As Int64 = 20
    Dim Jugos As Int64 = 20
    Dim Cafe As Int64 = 30
    Dim Cerveza As Int64 = 75
    Dim Agua As Int64 = 15

    Public Function CompraPizza(Cantidad As Integer) As Double
        Dim TotalPizza As Double = Pizza * Cantidad
        Return TotalPizza
    End Function



End Class
