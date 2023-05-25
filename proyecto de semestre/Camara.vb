Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports AForge.Video
Imports AForge.Video.DirectShow
Imports System.Drawing.Imaging
Imports System.Threading ' This is the constructor method for the Camara class.
Public Class Camara

    Public Delegate Sub FotoTomadaEventHandler(ByVal sender As Object, ByVal foto As Image)
    Public Event FotoTomada As FotoTomadaEventHandler

    Private videoDevices As FilterInfoCollection
    Private videoSource As VideoCaptureDevice
    Private fotogramaActual As Bitmap

    Public Sub New()
        InitializeComponent()


        Me.PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage
        Me.PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        FormBorderStyle = FormBorderStyle.None
        videoDevices = New FilterInfoCollection(FilterCategory.VideoInputDevice)
        videoSource = New VideoCaptureDevice(videoDevices(0).MonikerString)
        AddHandler videoSource.NewFrame, AddressOf CapturarFrame
    End Sub

    Private Sub Camara_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        videoSource.Start()

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Detener la cámara
        videoSource.SignalToStop()
        videoSource.WaitForStop()

        TomarFoto()

        Me.Close()
    End Sub

    Private Sub videoSource_NewFrame(sender As Object, eventArgs As NewFrameEventArgs)
        ' The new frame is cloned and assigned to the pictureBox1.Image property to display it in the PictureBox control.
        ' Muestra el nuevo fotograma en el control PictureBox
        PictureBox1.Image = DirectCast(eventArgs.Frame.Clone(), Bitmap)
    End Sub



    Private Sub TomarFoto()
        'If fotogramaActual is not null (a frame has been captured), the frame is saved as a Jpeg image at the specified rutaImagen.

        If fotogramaActual IsNot Nothing Then
            Dim rutaImagen As String = "C:\Users\Brand\OneDrive\Imágenes\" & "_" & DateTime.Now.ToString("yyyyMMddHHmmss") & ".jpeg"
            Try
                fotogramaActual.Save(rutaImagen, System.Drawing.Imaging.ImageFormat.Jpeg)
            Catch ex As Exception
                MessageBox.Show("Error al guardar la imagen: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub CapturarFrame(ByVal sender As Object, ByVal eventArgs As NewFrameEventArgs)
        'The new frame is cloned and assigned to the fotogramaActual variable.

        ' Capturar el fotograma actual
        fotogramaActual = DirectCast(eventArgs.Frame.Clone(), Bitmap)
        ' Mostrar el fotograma en el PictureBox
        'The pictureBox1.Image property is set to the new frame to display it in the PictureBox control.
        PictureBox1.Image = fotogramaActual
    End Sub
End Class