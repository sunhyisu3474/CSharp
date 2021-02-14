using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

	class Program {
		static void Main ( string [] args ) {

		/* (1) ip주소와 포트를 연결하고 TCP 연결  */
		TcpClient tc = new TcpClient ( "Localhost", 7000 );
		// 동일한 문장 => TcpCliet tc = new TcpCliet ( "localhost", 7000 );

		string message = "Hello";
		byte [] buff = Encoding.ASCII.GetBytes ( message );

		/*  (2) network stream을 얻는다.  */
		NetworkStream stream = tc.GetStream ();

		/*  (3) 스트림에 바이트 데이터 전송  */
		stream.Write ( buff, 0, buff.Length );

		byte [] outbuf = new byte [ 1024 ];
		int nbyte = stream.Read ( outbuf, 0, outbuf.Length );
		string output = Encoding.ASCII.GetString ( outbuf, 0, nbyte );

		stream.Close ();
		tc.Close ();

		Console.WriteLine ($"{nbyte} bytes: {output}");
	}
}
