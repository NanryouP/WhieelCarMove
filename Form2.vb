Public Class Form2

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call hideFiles()
    End Sub
    Private Sub hideFiles()
        'ファイルを非表示にする
        Dim batFileName As String
        'バッチファイル名フルパス
        batFileName = "Z:\PC部改\コンピュータ科学部\2016年度（仮設）\PC科学部\System\bat\hidefiles.bat"
        Dim ShellObject As Object
        ShellObject = CreateObject("WScript.Shell")
        ShellObject.Run(batFileName)


        'アプリの終了
        Application.Exit()

    End Sub

    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Const CS_NOCLOSE As Integer = &H200

            Dim createParam As System.Windows.Forms.CreateParams = MyBase.CreateParams
            createParam.ClassStyle = createParam.ClassStyle Or CS_NOCLOSE

            Return createParam
        End Get
    End Property

End Class