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
                FileName = "demo1.pdf",
                Url = "http://www.pdfpdf.com/samples/pptdemo2.pdf"
            };

            DownloadPdfCommand = new Command((obj) => DownloadPdf());
        }

        private async void DownloadPdf()
        {            

            IsBusy = true;

            if (await PdfFileHelper.ExistsAsync(_pdfModel.FileName) == false)
            {
                await PdfFileHelper.DownloadDocumentsAsync(_pdfModel);
            }
            PdfUri = PdfFileHelper.GetFilePathFromRoot(_pdfModel.FileName);

            IsBusy = false;
        }

        bool _isBusy = false;

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


    }
}
