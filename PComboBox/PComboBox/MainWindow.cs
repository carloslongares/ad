using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		CellRendererText cellRendererText = new CellRendererText();
		comboBox.PackStart(cellRendererText,false);
		comboBox.AddAttribute (cellRendererText,"text",1);

		ListStore listStore = new ListStore(typeof(int),typeof(string));
	
		
		listStore.AppendValues(1,"elemento1");
		listStore.AppendValues(2,"elemento2");
		listStore.AppendValues(3,"elemento3");
		listStore.AppendValues(4,"elemento4");
		
		
		comboBox.Model=listStore;
		
		comboBox.Changed += delegate {
			TreeIter treeIter;
			comboBox.GetActiveIter(out treeIter);
			int id = (int) listStore.GetValue(treeIter,0);
			Console.WriteLine (id);
		
		};
		
//		comboBox.AppendText("Uno");
//		comboBox.AppendText("Dos");
//		comboBox.AppendText("Tres");
//		comboBox.AppendText("Cuatro");
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
