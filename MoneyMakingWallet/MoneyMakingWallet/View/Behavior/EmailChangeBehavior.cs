using IDMONEY.IO.Helper;
using IDMONEY.IO.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace IDMONEY.IO.View
{
    public class EmailChangeBehavior : Behavior<Entry>
    {
        static readonly BindablePropertyKey ColorValidationPropertyKey = BindableProperty.CreateReadOnly("ColorValidation", typeof(Color), typeof(Color), AppManagement.General_DefaultColor);
        public static readonly BindableProperty ColorValidationProperty = ColorValidationPropertyKey.BindableProperty;
        public Color ColorValidation
        {
            get { return (Color)GetValue(ColorValidationProperty); }
            private set { SetValue(ColorValidationPropertyKey, value); }
        }

        static readonly BindablePropertyKey IsInvalidPropertyKey = BindableProperty.CreateReadOnly("IsInvalid", typeof(bool), typeof(bool), false);
        public static readonly BindableProperty IsInvalidProperty = IsInvalidPropertyKey.BindableProperty;

        public bool IsInvalid
        {
            get { return (bool)GetValue(IsInvalidProperty); }
            private set { SetValue(IsInvalidPropertyKey, value); }
        }

        static readonly BindablePropertyKey IsEmptyOrNullPropertyKey = BindableProperty.CreateReadOnly("IsEmptyOrNull", typeof(bool), typeof(bool), false);
        public static readonly BindableProperty IsEmptyOrNullProperty = IsEmptyOrNullPropertyKey.BindableProperty;

        public bool IsEmptyOrNull
        {
            get { return (bool)GetValue(IsEmptyOrNullProperty); }
            private set { SetValue(IsEmptyOrNullPropertyKey, value); }
        }

        public EmailChangeBehavior()
        {
            ColorValidation = AppManagement.General_DefaultColor;
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            Validator(e.NewTextValue);
        }

        private void Validator(string input)
        {
            IsEmptyOrNull = string.IsNullOrEmpty(input);

            IsInvalid = !ValidationHelper.IsValidEmail(input);
            if (IsInvalid)
            {
                ColorValidation = AppManagement.General_ColorError;             
            }
            else
            {
                ColorValidation = AppManagement.General_DefaultColor;
            }
        }
    }
}
