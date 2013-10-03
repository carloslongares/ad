using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic; // EJEMPLO List<string> columnNames = new  List<string>();
namespace Serpis.ad
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string connectionString="Server=localhost;" +
									"Database=dbprueba;" +
									"User ID=root;" +
									"Password=sistemas";
			
			MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
			mySqlConnection.Open();
			
			MySqlCommand mySqlCommand= mySqlConnection.CreateCommand();
			mySqlCommand.CommandText= "select * from categoria";

			MySqlDataReader mySqlDataReader= mySqlCommand.ExecuteReader();
			
			Console.WriteLine (string.Join(" ",dinamicGetColumNamess(mySqlDataReader)));
			//int contador=mySqlDataReader.FieldCount;
			//for(int i=0;i<contador;i++){
			//	string name= mySqlDataReader.GetName(i);		
			//	Console.Write(name+ " ");
			//}
			
		while(mySqlDataReader.Read())
				Console.WriteLine(getLine(mySqlDataReader));
//				string line= " ";
//				for (int index=0; index< mySqlDataReader.FieldCount;index++){
//					object value= line+mySqlDataReader.GetValue(index);
//					if (value is DBNull)
//						value= "null";
//					line=line +value+" ";
//				}
//				Console.WriteLine(line);
//			}
//			
			
			mySqlDataReader.Close();
			mySqlConnection.Close ();
	
		}
		
		private static string getLine(MySqlDataReader mySqlDataReader){
			string line= " ";
			
				
				for (int index=0; index< mySqlDataReader.FieldCount;index++){
					object value= mySqlDataReader.GetValue(index);
					if (value is DBNull)
						value= "null";
					line=line +value+" ";
					
				}
			
			return line;
		}
		
		
		private static string[] getColumnNames (MySqlDataReader mySqlDataReader){
		string[] nombres = new string[mySqlDataReader.FieldCount];
		for (int index=0;index<mySqlDataReader.FieldCount;index++)
				nombres[index]=mySqlDataReader.GetName(index);
		
		return nombres;
		}
		
		
		private static List<string> dinamicGetColumNamess (MySqlDataReader mySqlDataReader){
		List<string> nombres = new List<string>();
			for (int index =0; index<mySqlDataReader.FieldCount;index++){
				nombres.Add(mySqlDataReader.GetName(index));
			}
			return nombres;
		}
			
	}
}
