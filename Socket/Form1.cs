using System;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient.Authentication;

using MySqlConnector.Authentication;
using MySqlConnector.Logging;
using MySql.Data.Common;

namespace Tutorials {
	public partial class Tutorials : Form {
		public Tutorials () {
			InitializeComponent ();
		}


		string connection_string =
			"server=Localhost;" +
			"port=3474;" +
			"database=Tutorials;" +
			"uid=root;" +
			"pwd=root;" +
			"charset=utf8;";

		private void Form1_Load ( object sender, EventArgs e ) {}

		private void textBox1_TextChanged ( object sender, EventArgs e ) {
			textBox1.MaxLength = 15;
		}

		private void textBox2_TextChanged ( object sender, EventArgs e ) {
			textBox1.MaxLength = 15;
		}

		private void button1_Click ( object sender, EventArgs e ) {
			label1.BackColor = Color.Transparent;
			label1.Parent = this;
			/*  using을 활용해서 data자동 관리 connection변수에 MySqlConnection을 인스턴스화하면서 동시에 mysql에 연동할 서버 정보를 입력  *//*
			using ( MySqlConnection connection = new MySqlConnection ( connection_string ) ) {
				string read_sql = "SELECT * FROM account " +
					"WHERE id = '" + this.textBox1.Text + "' and password = '" + this.textBox2.Text + "';", connection_string;
				MySqlCommand cmd = new MySqlCommand ( read_sql, connection );
				try {
					connection.Open (); //	Open mysql database onnection
					MySqlDataReader mdr = cmd.ExecuteReader ();	//	연결모드로 데이터를 서버에서 불러온다.

				} catch ( Exception ) {
					MessageBox.Show ( "실패" );
				}
			}
		}*/
			try {
				// MySQL 데이타베이스를 연결하기 위해서는 MySqlConnection 클래스를 사용한다. 
				// 이 클래스를 생성할 때, Connection String을 넣어 주어야 하는데, 여기에는 datasource명, port번호, 사용자명, 암호을 지정해 준다.
				MySqlConnection myConn = new MySqlConnection ( connection_string );
				myConn.Open ();
				// MySqlCommand에 해당 SQL문을 지정하여 실행한다
				MySqlCommand SelectCommand = new MySqlCommand ( "select * from account " +
					"where id = '" + textBox1.Text + "' and password = '" + textBox2.Text + "';", myConn );

				// MySqlDataReader는 연결모드로 데이타를 서버에서 가져온다.
				MySqlDataReader myReader;
				myReader = SelectCommand.ExecuteReader ();
				int count = 0;

				while ( myReader.Read () ) {
					count = count + 1;
				}

				if ( count == 1 ) {
					MessageBox.Show ( "접속하셨습니다." );
					this.Visible = false;
					Form2 showForm2 = new Form2 ();
					showForm2.ShowDialog ();
					this.Close ();
				} else if ( count > 1 ) {
					MessageBox.Show ( "아이디와 패스워드가 중복됩니다." );
				} else {
					MessageBox.Show ( "등록된 계정정보가 아닙니다." );
				}

			} catch ( Exception ex ) {
				MessageBox.Show ( ex.Message );
	}
}

		private void button2_Click ( object sender, EventArgs e ) {
			using ( MySqlConnection connection = new MySqlConnection ( connection_string ) ) {
				MySqlCommand cmd = new MySqlCommand ( "account_join", connection );
				cmd.Parameters.AddWithValue ( "@input_id", textBox3.Text );
				cmd.Parameters.AddWithValue ( "@input_pw", textBox4.Text );
				string join_information = "INSERT INTO account(id, password) VALUES(" + textBox3.Text + "," + textBox4.Text + ")";
				try {
					connection.Open (); //	open mysql database connection
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					if ( cmd.ExecuteNonQuery () == 1 && textBox3.Text != "" && textBox4.Text!="") {
						MessageBox.Show ( "회원가입이 정상적으로 완료되었습니다.", "회원가입" );
					} else if( textBox3.Text == "" || textBox4.Text == "") {
						MessageBox.Show ( "공백은 입력하실 수 없습니다." );
					}
				} catch ( Exception ex ) {  //  쿼리 데이터 테이블에 가입하려는 정보와 동일한 경우 아래 메세지를 출력한다.
					MessageBox.Show ( "이미 가입된 계정입니다." );
				}
			}
		}

		private void textBox3_TextChanged ( object sender, EventArgs e ) {
			textBox1.MaxLength = 15;
		}

		private void textBox4_TextChanged ( object sender, EventArgs e ) {
			textBox1.MaxLength = 15;
		}

		private void label7_Click ( object sender, EventArgs e ) {
		}

		private void label6_Click ( object sender, EventArgs e ) {
		}

		private void label1_Click ( object sender, EventArgs e ) {
		}
	}
}
