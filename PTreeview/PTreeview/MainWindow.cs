using System;
using Gtk;
using MySql.Data.MySqlClient;
	public partial class MainWindow: Gtk.Window
	{
		private MySqlConnection mySqlConnection;
		public MainWindow (): base (Gtk.WindowType.Toplevel)
		{
			Build ();
			string connectionString="Server=localhost;" +
									"Database=dbprueba;" +
									"User ID=root;" +
									"Password=sistemas";
			
			mySqlConnection = new MySqlConnection(connectionString);
			mySqlConnection.Open();
			
			MySqlCommand mySqlCommand= mySqlConnection.CreateCommand();
			mySqlCommand.CommandText= "select * from articulo";
			
			MySqlDataReader mySqlDataReader= mySqlCommand.ExecuteReader();
			
		
		
		
			// CREACION DE LOS APENDICES DE LA TABLA
			for (int index=0; index<mySqlDataReader.FieldCount;index ++)
				treeview.AppendColumn(mySqlDataReader.GetName(index),new CellRendererText(),"text",index);
		
		
		
			//CREACION DEL MODELO DE DATOS DE LA TABLA
			int fieldCount = mySqlDataReader.FieldCount;
	
			ListStore listStore= createListStore(fieldCount);
		
		
			//INSERCION DE LOS DATOS DENTRO DEL MODELO
			while(mySqlDataReader.Read()){
					
				string []line= new string[mySqlDataReader.FieldCount];
				for (int index=0; index< mySqlDataReader.FieldCount;index++){
						object value= mySqlDataReader.GetValue(index);
						line[index]=value.ToString();			
						}
					
				listStore.AppendValues(line);
			
				//INSERCION DEL MODELO EN LA TABLA(TREEVIEW)
				treeview.Model=listStore;

			}
		
		editAction.Sensitive=false;
		
		treeview.Selection.Changed += delegate 
			
		{
			editAction.Sensitive= treeview.Selection.CountSelectedRows()>0;
			
			editAction.Activated += delegate {
			String mensaje;
			
			
			TreeIter treeIter;
			if(treeview.Selection.GetSelected(out treeIter)){
				String[] linea = new String[fieldCount];	
				for (int index=0; index< fieldCount;index++)		
					linea[index]=listStore.GetValue(treeIter,index).ToString();
					
			 mensaje= string.Join("  ", linea);
			}
			
			MessageDialog md = new MessageDialog (this,DialogFlags.DestroyWithParent, MessageType.Error, ButtonsType.Close, mensaje);
			md.Run ();
			md.Destroy();
			
			
			
			
			
			
			
			
				};
			
			};
			
			// CREACION DE UN EVENTO PARA TREEVIEW (INDICA EN CONSOLA EN QUE CELDA NOS ENCONTRAMOS)
//			treeview.Selection.Changed += delegate {
//	
//				TreeIter treeIter;
//				if(treeview.Selection.GetSelected(out treeIter)){
//				
//					Console.WriteLine("path= "+listStore.GetPath(treeIter));
//					Console.WriteLine(listStore.GetValue(treeIter,0));
//					Console.WriteLine(listStore.GetValue(treeIter,1));
//				}else
//					Console.WriteLine("fuera de rango");
//				};
	}
	
		
	
	
		private ListStore createListStore(int fieldCount){
			Type[] types = new Type[fieldCount];
			for (int index = 0; index < fieldCount; index++)
				types[index] = typeof(string);
				return new ListStore(types);
		}		

			
		
		protected void OnDeleteEvent (object sender, DeleteEventArgs a){
			Application.Quit ();
			a.RetVal = true;
			
			mySqlConnection.Close();
			
		}
	}

