
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;

	private global::Gtk.Action Action;

	private global::Gtk.Action Action1;

	private global::Gtk.RadioAction RSAAction;

	private global::Gtk.RadioAction DESAction;

	private global::Gtk.RadioAction SHA1Action;

	private global::Gtk.VBox vbox1;

	private global::Gtk.MenuBar menubar1;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup("Default");
		this.Action = new global::Gtk.Action("Action", global::Mono.Unix.Catalog.GetString("Настройки"), null, null);
		this.Action.ShortLabel = global::Mono.Unix.Catalog.GetString("Настройки");
		w1.Add(this.Action, null);
		this.Action1 = new global::Gtk.Action("Action1", global::Mono.Unix.Catalog.GetString("Алгоритм Шифрования"), null, null);
		this.Action1.ShortLabel = global::Mono.Unix.Catalog.GetString("Алгоритм Шифрования");
		w1.Add(this.Action1, null);
		this.RSAAction = new global::Gtk.RadioAction("RSAAction", global::Mono.Unix.Catalog.GetString("RSA"), null, null, 0);
		this.RSAAction.Group = new global::GLib.SList(global::System.IntPtr.Zero);
		this.RSAAction.ShortLabel = global::Mono.Unix.Catalog.GetString("RSA");
		w1.Add(this.RSAAction, null);
		this.DESAction = new global::Gtk.RadioAction("DESAction", global::Mono.Unix.Catalog.GetString("DES"), null, null, 0);
		this.DESAction.Group = this.RSAAction.Group;
		this.DESAction.ShortLabel = global::Mono.Unix.Catalog.GetString("DES");
		w1.Add(this.DESAction, null);
		this.SHA1Action = new global::Gtk.RadioAction("SHA1Action", global::Mono.Unix.Catalog.GetString("SHA-1"), null, null, 0);
		this.SHA1Action.Group = this.DESAction.Group;
		this.SHA1Action.ShortLabel = global::Mono.Unix.Catalog.GetString("SHA-1");
		w1.Add(this.SHA1Action, null);
		this.UIManager.InsertActionGroup(w1, 0);
		this.AddAccelGroup(this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString(@"<ui><menubar name='menubar1'><menu name='Action' action='Action'><menu name='Action1' action='Action1'><menuitem name='RSAAction' action='RSAAction'/><menuitem name='DESAction' action='DESAction'/><menuitem name='SHA1Action' action='SHA1Action'/></menu></menu></menubar></ui>");
		this.menubar1 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget("/menubar1")));
		this.menubar1.Name = "menubar1";
		this.vbox1.Add(this.menubar1);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1[this.menubar1]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		this.Add(this.vbox1);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 600;
		this.DefaultHeight = 380;
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
	}
}
