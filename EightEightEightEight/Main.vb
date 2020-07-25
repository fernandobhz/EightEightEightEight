Imports System.Net.Sockets
Imports System.Threading.Tasks

Module Main

    Sub Main()
        Task.Factory.StartNew(AddressOf EightEightEightEight)
        Console.WriteLine("Listening clients on port 8888")
        Console.WriteLine("Press any key to quit")
        Console.ReadKey()
    End Sub

    Sub EightEightEightEight()
        Dim TcpListener As New TcpListener(Net.IPAddress.Any, 8888)
        TcpListener.Start()

        Do
            Dim TcpClient As TcpClient = TcpListener.AcceptTcpClient
            Dim Stream As NetworkStream = TcpClient.GetStream


            'Must read before write, even, i don't do anything with that
            Dim RequestBuff(4095) As Byte
            Stream.Read(RequestBuff, 0, 4096)
            'Dim Request As String = System.Text.Encoding.UTF8.GetString(RequestBuff)


            Dim Response As String = "HTTP/1.0 200 OK" & vbCrLf & vbCrLf & Now
            Dim ResponseBuff As Byte() = System.Text.Encoding.UTF8.GetBytes(Response)
            Stream.Write(ResponseBuff, 0, ResponseBuff.Count)

            Stream.Close()
            TcpClient.Close()
        Loop

    End Sub
End Module
