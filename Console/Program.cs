using System;

class Program {
	static void Main ( string [] args ) {

		/*  비트연산자 활용 방법  */
		int i = 2;

		Console.WriteLine ( $"{Convert.ToString ( i, 2 )}" );
		Console.WriteLine ( $"{Convert.ToString ( i << 2, 2 )}" );
		Console.WriteLine ( i << 2 );

		/*  3항 연산자  */
		string res = ( i << 2 == 8 ) ? "TRUE" : "FALSE";
		Console.WriteLine ( "값은" + res + "입니다." );

		/*  switch  */
		switch ( 5 > 3 ) {
			case true:
				Console.WriteLine ( "TRUE" );
				break;

			case false:
				Console.WriteLine ( "FALSE" );
				break;
		}

		switch ( i << 2 ) {
			case 1:
				Console.WriteLine ( "ERROR" );
				break;

			case 2:
				Console.WriteLine ( "ERROR" );
				break;

			case 3:
				Console.WriteLine ( "ERROR" );
				break;

			case 4:
				Console.WriteLine ( "ERROR" );
				break;

			case 8:	//	정답이 8이기 때문에 해당 case가 실행됨.
				Console.WriteLine ("Complite");
				break;

			default:	//	1~n번까지의 case에 해당하는 값이 없을 경우 해당 문을 실행함.
				Console.WriteLine ( "??" );
				break;
		}

		/*  날씨 대답 심심이 프로그램  */
		Console.WriteLine ("오늘 날씨가 어떤가요?");
		string weather = Console.ReadLine ();

		switch ( weather ) {
			case "맑음":
				Console.WriteLine ("오늘 날씨는 맑군요..");
				break;

			case "흐림":
				Console.WriteLine ( "오늘 날씨는 흐리군요.." );
				break;

			default:
				Console.WriteLine ( "오늘 날씨는 이도저도 아니군요.." );
				break;
		}
	}
}