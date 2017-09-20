﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFPdfViewer.ViewModels;

namespace XFPdfViewer.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PdfViewerPage : ContentPage
    {
        public PdfViewerPage()
        {
            InitializeComponent();
            BindingContext = new PdfViewerViewModel();
        }
    }
}