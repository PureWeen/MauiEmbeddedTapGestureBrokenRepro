using CommunityToolkit.Mvvm.Input;

namespace MauiTestApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        [RelayCommand]
        private void OnTest()
        {
            DisplayAlert("Test", "Test", "Cancel");
        }

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            DisplayAlert("Test", "Test", "Cancel");
        }
    }

}
