Public Interface IComentarioService
    Sub AgregarComentario(comentario As String)
    ' Method declaration for adding a comment.

    Function ObtenerComentarios() As List(Of String)
    ' Method declaration for retrieving the comments as a list.
End Interface

Public Class ComentarioService
    Implements IComentarioService

    Private comentarios As List(Of String) = New List(Of String)()
    ' Private field to store the comments as a list.

    Public Sub AgregarComentario(comentario As String) Implements IComentarioService.AgregarComentario
        ' Implementation of the AgregarComentario method from the interface.
        comentarios.Add(comentario)
        ' Adds the comment to the list of comments.
    End Sub

    Public Function ObtenerComentarios() As List(Of String) Implements IComentarioService.ObtenerComentarios
        ' Implementation of the ObtenerComentarios method from the interface.
        Return comentarios
        ' Returns the list of comments.
    End Function
End Class
