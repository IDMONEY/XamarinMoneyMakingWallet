﻿using IDMONEY.IO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IDMONEY.IO.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EntryDataView : ContentPage
	{
		public EntryDataView()
		{
			InitializeComponent ();

            BindingContext = new EntryDataViewModel();
        }

        private void Cell_OnTapped(object sender, EventArgs e)
        {
            var viewCell = (ViewCell)sender;
            if (viewCell.View != null)
            {
                viewCell.View.BackgroundColor = Color.White;
            }
        }
    }
}