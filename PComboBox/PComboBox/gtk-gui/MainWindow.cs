
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.VBox vbox;
	private global::Gtk.Table table;
	private global::Gtk.ComboBox comboBox;
	private global::Gtk.Label label;
	
	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox = new global::Gtk.VBox ();
		this.vbox.Name = "vbox";
		this.vbox.Spacing = 6;
		// Container child vbox.Gtk.Box+BoxChild
		this.table = new global::Gtk.Table (((uint)(3)), ((uint)(4)), false);
		this.table.Name = "table";
		this.table.RowSpacing = ((uint)(6));
		this.table.ColumnSpacing = ((uint)(6));
		// Container child table.Gtk.Table+TableChild
		this.comboBox = new global::Gtk.ComboBox ();
		this.comboBox.Name = "comboBox";
		this.table.Add (this.comboBox);
		global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.table [this.comboBox]));
		w1.LeftAttach = ((uint)(1));
		w1.RightAttach = ((uint)(2));
		w1.XOptions = ((global::Gtk.AttachOptions)(4));
		w1.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table.Gtk.Table+TableChild
		this.label = new global::Gtk.Label ();
		this.label.Name = "label";
		this.label.LabelProp = global::Mono.Unix.Catalog.GetString ("label1");
		this.table.Add (this.label);
		global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table [this.label]));
		w2.XOptions = ((global::Gtk.AttachOptions)(4));
		w2.YOptions = ((global::Gtk.AttachOptions)(4));
		this.vbox.Add (this.table);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox [this.table]));
		w3.Position = 1;
		this.Add (this.vbox);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 400;
		this.DefaultHeight = 300;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
	}
}
