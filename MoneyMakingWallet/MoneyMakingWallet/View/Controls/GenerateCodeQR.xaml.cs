using System;
using System.Drawing;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;

namespace IDMONEY.IO.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GenerateCodeQR : ContentView
    {
        public static readonly BindableProperty CodeQRProperty = BindableProperty.Create("CodeQR",
                                                                typeof(string),
                                                                typeof(GenerateCodeQR),
                                                                string.Empty,
                                                                BindingMode.TwoWay,
                                                                propertyChanged: CodeQRPropertyChanged);

        public string CodeQR
        {
            get { return (string)GetValue(CodeQRProperty); }
            set { SetValue(CodeQRProperty, value); }
        }

        private static void CodeQRPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            GenerateCodeQR component = (GenerateCodeQR)bindable;
            component.CodeQR = (string)newValue;
            component.changeCodeQR();
        }

        private void changeCodeQR()
        {
            var stream = DependencyService.Get<IBarcodeService>().ConvertImageStream(
                            this.CodeQR, Convert.ToInt32(WidthRequest * 2), Convert.ToInt32(HeightRequest * 2));
            imgCode.Source = ImageSource.FromStream(() => { return stream; });
        }

        public GenerateCodeQR()
        {
            InitializeComponent();
        }
    }

    public interface IBarcodeService
    {
        Stream ConvertImageStream(string text, int width = 300, int height = 130);
    }
}