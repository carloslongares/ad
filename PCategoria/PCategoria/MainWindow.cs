using System;
using Gtk;
using MySql.Data.MySqlClient;
public partial class MainWindow: Gtk.Window
{	
	private MySqlConnection mySqlConnection;
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		//DECLARACION DE LA CONEXION
		
		string conexion="Server=localhost;" +
								"Database=dboctubre;" +
								"User ID=root;" +
								"Password=sistemas";
		
		mySqlConnection=new MySqlConnection(conexion);
		mySqlConnection.Open();	
		
		MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
		mySqlCommand.CommandText="select * from categoria";
			
		MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
	
		//CREAR APENDICES
		
			for (int index=0; index<mySqlDataReader.FieldCount;index ++)
				treeView.AppendColumn(mySqlDataReader.GetName(index),new CellRendererText(),"text",index);
		
		//CREACION DEL MODELO DE DATOS
			int fieldCount = mySqlDataReader.FieldCount;
	
			ListStore listStore= creaListStore(fieldCount);
		
		
			//INSERCION DE LOS DATOS DENTRO DEL MODELO
			while(mySqlDataReader.Read()){
					
				string []line= new string[mySqlDataReader.FieldCount];
				for (int index=0; index< mySqlDataReader.FieldCount;index++){
						object value= mySqlDataReader.GetValue(index);
						line[index]=value.ToString();			
						}
					
				listStore.AppendValues(line);
			
				//INSERCION DEL MODELO EN LA TABLA(TREEVIEW)
				treeView.Model=listStore;

			}
		mySqlDataReader.Close();
		
		treeView.Selection.Changed += delegate {
				deleteAction.Activated += delegate {
				
				if(treeView.Selection.CountSelectedRows()==0)
					return;
				TreeIter treeIter;
				treeView.Selection.GetSelected(out treeIter);
				object id = listStore.GetValue(treeIter,0).ToString();
				Console.WriteLine(id);
				
				MySqlCommand mySqlCommandDelete= mySqlConnection.CreateCommand();
				mySqlCommandDelete.CommandText= "delete from categoria where id='"+id+"'";
				
				MessageDialog md = new MessageDialog (this, 
                                      	DialogFlags.DestroyWithParent,
	                              		MessageType.Question, 
                                      	ButtonsType.YesNo, "¿Estas seguro de eliminarlo?");
				ResponseType result = (ResponseType)md.Run ();
				
				if (result == ResponseType.Yes){
					mySqlCommandDelete.ExecuteNonQuery();
					md.Destroy();
				
				}
				else
					md.Destroy();
				
				
				
				};
		};
		
		
	}
			
	private ListStore creaListStore(int fieldCount){
			Type[] types = new Type[fieldCount];
			for (int index = 0; index < fieldCount; index++)
				types[index] = typeof(string);
				return new ListStore(types);
		}		
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
