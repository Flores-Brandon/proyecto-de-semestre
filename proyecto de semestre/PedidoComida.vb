Imports System.Collections.Generic
Imports System.Windows.Forms

Public MustInherit Class PedidoComida
    Public Property Cliente As String                    ' Property for storing the customer name.
    Public Property Telefono As String                   ' Property for storing the customer's phone number.
    Public Property HoraEntrega As String                ' Property for storing the delivery time.
    Public Property Total As Decimal                     ' Property for storing the total cost of the order.

    Public MustOverride Sub AgregarItem(item As String, cantidad As Integer)
    ' Abstract method for adding an item to the order. This method needs to be implemented in derived classes.

    Public MustOverride Sub EliminarItem(item As String)
    ' Abstract method for removing an item from the order. This method needs to be implemented in derived classes.

    Public MustOverride Sub CalcularTotal()
    ' Abstract method for calculating the total cost of the order. This method needs to be implemented in derived classes.

    Public Sub MostrarDetallePedido()
        ' Method for displaying the order details in a message box.
        MessageBox.Show("Cliente: " & Cliente & vbCrLf & "Teléfono: " & Telefono & vbCrLf &
                        "Hora de entrega: " & HoraEntrega & vbCrLf & "Total: $" & Total.ToString())
    End Sub
End Class

Public Class PedidoOnline
    Inherits PedidoComida
    Private itemList As Dictionary(Of String, Integer)
    ' Private field to store the items and their quantities in the order.

    Public Sub New()
        ' Constructor for initializing the PedidoOnline class.
        itemList = New Dictionary(Of String, Integer)()
        ' Initialize the itemList dictionary.
    End Sub

    Public Overrides Sub AgregarItem(item As String, cantidad As Integer)
        ' Implementation of the AgregarItem method inherited from the base class.
        ' Adds an item to the order or updates its quantity if it already exists.
        If itemList.ContainsKey(item) Then
            itemList(item) += cantidad
        Else
            itemList.Add(item, cantidad)
        End If
    End Sub

    Public Overrides Sub EliminarItem(item As String)
        ' Implementation of the EliminarItem method inherited from the base class.
        ' Removes an item from the order if it exists.
        If itemList.ContainsKey(item) Then
            itemList.Remove(item)
        End If
    End Sub

    Public Overrides Sub CalcularTotal()
        Total = 0

        For Each kvp As KeyValuePair(Of String, Integer) In itemList
            ' Lógica para calcular el precio de cada item y sumarlo al total
            Dim precioItem As Decimal = ObtenerPrecioItem(kvp.Key)
            Total += precioItem * kvp.Value

        Next
    End Sub

    Private Function ObtenerPrecioItem(item As String) As Decimal
        ' Lógica para obtener el precio de un item en específico
        ' Aquí se puede consultar una base de datos o utilizar datos predefinidos
        Select Case item
            Case "Hamburguesa"
                Return 10
            Case "Pizza"
                Return 12
            Case Else
                Return 0
        End Select
    End Function
End Class