using System;
using Gtk;


public partial class MainWindow : Gtk.Window
{
	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}
	/*private void fixed6(object sender, EventArgs args)
	{
		Random rnd = new Random();
		int rand = rnd(0, 100);
		this.PoS.Text = rand.ToString();
	}*/
}

