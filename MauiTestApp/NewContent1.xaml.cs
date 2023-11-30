namespace MauiTestApp;

public partial class NewContent1 : ContentView
{
	public NewContent1()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("Tapped");
        //DisplayAlert("Test", "Test", "Cancel");
    }
}
