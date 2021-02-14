using System;
using System.Net.Sockets;
using System.Net;

class Program {
	static void Main ( string [] args ) {
		Socket s = new Socket ( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );

		IPHostEntry iP_host_info = Dns.Resolve ( "host.contoso.com" );
		IPAddress ipadress = iP_host_info.AddressList [ 0 ];

		IPEndPoint ipe = new IPEndPoint ( ipadress, 11000 );

		try {
			s.Connect ( ipe );
		} catch ( ArgumentNullException ae ) {
			Console.WriteLine ( "ArgumentNullException : {0}", ae.ToString () );
		} catch ( SocketException se ) {
			Console.WriteLine ( "SocketException : {0}", se.ToString () );
		} catch ( Exception e ) {
			Console.WriteLine ( "Unexpected exception : {0}", e.ToString () );
		}
	}
}