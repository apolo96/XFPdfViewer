
using Xamarin.Forms;

namespace XFPdfViewer.CustomRenderers
{
    public class PdfViewCustom : WebView
    {
        public static readonly BindableProperty UriProperty = 
            BindableProperty.Create(nameof(Uri), 
                typeof(string), 
                typeof(PdfViewCustom));

        public string Uri
        {
            get { return (string)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }
    }
}
