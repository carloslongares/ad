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
			
			Console.Write (string.Join(" ",getColumNames(mySqlDataReader)));
			//int contador=mySqlDataReader.FieldCount;
			//for(int i=0;i<contador;i++){
			//	string name= mySqlDataReader.GetName(i);		
			//	Console.Write(name+ " ");
			//}
			
			
			
			//while(mySqlDataReader.Read()){
			//	int num=0;
			//	Console.WriteLine();
			//	Console.Write(mySqlDataReader.GetValue(num));
			//	num++;
			//}
			
			mySqlDataReader.Close();
			mySqlConnection.Close ();
	
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
