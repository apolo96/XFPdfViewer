using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFPdfViewer.Helpers;
using XFPdfViewer.Models;

namespace XFPdfViewer.ViewModels
{
    public class PdfViewerViewModel : ViewModelPropertyChanged
    {
        PdfModel _pdfModel;

        public PdfViewerViewModel()
        {
            IsBusy = false;

            _pdfModel = new PdfModel()
            {
                FileName = "demo03.pdf",
                Url = "http://www.pdfpdf.com/samples/pptdemo2.pdf"
            };

            Device.BeginInvokeOnMainThread(async () =>
                {
                    await DownloadPdf();
                }
            );

            DownloadPdfCommand = new Command(async () => await DownloadPdf());
        }

        private async Task DownloadPdf()
        {

            IsBusy = true;
            IsVisible = false;

            if (await PdfFileHelper.ExistsAsync(_pdfModel.FileName) == false)
            {
                if (CrossConnectivity.Current.IsConnected == true)
                {
                    await PdfFileHelper.DownloadDocumentsAsync(_pdfModel);
                    IsVisible = true;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Ops", "Revisa tu conexion a Internet", "Ok");
                }
            }
            else
            {
                IsVisible = true;
            }
            PdfUri = PdfFileHelper.GetFilePathFromRoot(_pdfModel.FileName);
            IsBusy = false;
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                _isBusy = value;
                RaisePropertyChanged();
            }
        }

        public Command DownloadPdfCommand { get; set; }

        private string _pdfUri;

        public string PdfUri
        {
            get
            {
                return _pdfUri;
            }

            set
            {
                _pdfUri = value;
                RaisePropertyChanged();
            }
        }

        private bool _isVisible;

        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
                RaisePropertyChanged();
            }
        }



    }
}
