using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Platform;

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

        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            if (Parent is NavigationPage)
                await Navigation.PushAsync(new MainPage());
            else
                await DisplayAlert("Test", "Test", "Cancel");
        }
    }

}
