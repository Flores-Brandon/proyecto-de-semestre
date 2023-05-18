Imports System.IO

Public Class Ticket
    Private sumaTotal As Integer
    Private productos As String()

    Public Sub New(ByVal sumaTotal As Integer, ByVal productos As String())
        InitializeComponent()
        ' Initializes the Ticket form.
        Me.sumaTotal = sumaTotal
        ' Assigns the total sum to the private variable sumaTotal.
        Me.productos = productos
        ' Assigns the products array to the private variable productos.
    End Sub

    Private Sub Ticket_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Event handler when the Ticket form is loaded.
        MostrarTicket()
        ' Calls the MostrarTicket method to display the ticket.
    End Sub

    Private Sub MostrarTicket()
        ' Method to display the ticket.

        ' Ticket information
        Dim numeroTicket As Integer = 123
        ' Ticket number.
        Dim fecha As Date = Date.Now
        ' Current date.
        Dim nombreRestaurante As String = "Restaurante La Parrilla Ardiente"
        ' Restaurant name.

        ' Build the ticket content
        Dim contenidoTicket As String = ""
        ' Variable to store the ticket content.
        contenidoTicket &= "-------------------------------------------------------------------------------" & vbCrLf
        contenidoTicket &= "      MUCHAS GRACIAS POR VENIR, ¡VUELVA PRONTO!      " & vbCrLf
        contenidoTicket &= "--------------------------------------------------------------------------------" & vbCrLf
        contenidoTicket &= "Número de ticket: " & numeroTicket.ToString() & vbCrLf
        contenidoTicket &= "Fecha: " & fecha.ToString() & vbCrLf
        contenidoTicket &= "Restaurante: " & nombreRestaurante & vbCrLf
        contenidoTicket &= "--------------------------------------------------------------------------------" & vbCrLf
        contenidoTicket &= "Productos:" & vbCrLf

        For Each producto As String In productos
            contenidoTicket &= "- " & producto & vbCrLf
            ' Adds each product to the ticket content.
        Next

        contenidoTicket &= "--------------------------------------------------------------------------------" & vbCrLf
        contenidoTicket &= "Total: $" & sumaTotal.ToString() & vbCrLf
        ' Adds the total sum to the ticket content.

        ' Display the content in the Label
        lblTicket.Text = contenidoTicket
        ' Sets the text of lblTicket to the ticket content.

        ' File path on the desktop
        Dim desktopPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Dim archivoTicket As String = Path.Combine(desktopPath, "ticket.txt")
        ' Generates the file path for saving the ticket content as a text file on the desktop.

        ' Save the ticket content to the file
        File.WriteAllText(archivoTicket, contenidoTicket)
        ' Writes the ticket content to the text file.
    End Sub

    Private Sub btnGenerarTicket_Click(sender As Object, e As EventArgs) Handles btnGenerarTicket.Click
        ' Event handler for the "Generar Ticket" button click.
        Application.Exit()
        ' Closes the application.
    End Sub

    Private Sub lblTicket_Click(sender As Object, e As EventArgs) Handles lblTicket.Click

    End Sub
End Class