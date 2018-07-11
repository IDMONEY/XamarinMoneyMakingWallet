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
    public partial class EntryDataComponent : ContentView
    {
        #region Properties
        public static readonly BindableProperty DescriptionProperty = BindableProperty.Create("Description",
                                                        typeof(string),
                                                        typeof(EntryDataComponent),
                                                        string.Empty,
                                                        BindingMode.TwoWay,
                                                        propertyChanged: DescriptionPropertyChanged);

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        private static void DescriptionPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            EntryDataComponent component = (EntryDataComponent)bindable;
            component.Description = (string)newValue;
            component.lblDescription.Text = component.Description;
        }

        public static readonly BindableProperty ValueProperty = BindableProperty.Create("Value",
                                                        typeof(string),
                                                        typeof(EntryDataComponent),
                                                        string.Empty,
                                                        BindingMode.TwoWay,
                                                        propertyChanged: ValuePropertyChanged);

        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        private static void ValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            EntryDataComponent component = (EntryDataComponent)bindable;
            if (component.Value != (string)newValue || string.IsNullOrEmpty((string)oldValue))
            {
                component.Value = (string)newValue;
                component.changeValue();
            }
        }

        public static readonly BindableProperty TypeProperty = BindableProperty.Create("Type",
                                                        typeof(string),
                                                        typeof(EntryDataComponent),
                                                        string.Empty,
                                                        BindingMode.TwoWay,
                                                        propertyChanged: TypePropertyChanged);

        public string Type
        {
            get { return (string)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        private static void TypePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            EntryDataComponent component = (EntryDataComponent)bindable;
            component.Type = (string)newValue;
            component.changeType();
        }

        #endregion

        #region Controls
        private Switch _switch;

        #endregion
        public EntryDataComponent()
        {
            InitializeComponent();
        }

        #region Private Methods
        private void changeValue()
        {
            if (!string.IsNullOrEmpty(Value) && !string.IsNullOrEmpty(Type))
            {
                switch (Type)
                {
                    case "Boolean":
                        _switch.IsToggled = Convert.ToBoolean(Value);
                        break;
                }
            }
        }

        private void changeType()
        {
            if (!string.IsNullOrEmpty(Type))
            {
                switch (Type)
                {
                    case "Boolean":
                        _switch = new Switch()
                        {

                        };
                        _switch.Toggled += (object sender, ToggledEventArgs e) =>
                        {
                            Value = _switch.IsToggled.ToString();
                        };
                        pnlControls.Children.Add(_switch);
                        break;
                }
            }
        }
        #endregion
    }
}