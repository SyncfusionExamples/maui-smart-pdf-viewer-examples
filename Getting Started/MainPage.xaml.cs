namespace GettingStarted
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
           
        }

        // Dispose the PDF Viewer when the page disappears to
        // release resources and prevent memory leaks.
        protected override void OnDisappearing()
        {
            pdfViewer.Dispose();
            base.OnDisappearing();
        }
    }
}