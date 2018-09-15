using IDMONEY.IO.Helpers;
using IDMONEY.IO.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace IDMONEY.IO.View
{
    public class PasswordChangeBehavior : Behavior<Entry>
    {
        public PasswordChangeBehavior()
        {
            ColorValidation = AppManagement.General_DefaultColor;
        }

        #region Bindable Properties

        static readonly BindablePropertyKey ColorValidationPropertyKey = BindableProperty.CreateReadOnly("ColorValidation", typeof(Color), typeof(Color), AppManagement.General_DefaultColor);
        public static readonly BindableProperty ColorValidationProperty = ColorValidationPropertyKey.BindableProperty;

        public Color ColorValidation
        {
            get { return (Color)GetValue(ColorValidationProperty); }
            private set { SetValue(ColorValidationPropertyKey, value); }
        }

        //Bindable property for Valid Regex Password
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

        //Bindable property for Strengh Password
        static readonly BindablePropertyKey IsLowStrengthPropertyKey = BindableProperty.CreateReadOnly("IsLowStrength", typeof(bool), typeof(bool), false);
        public static readonly BindableProperty IsLowStrengthProperty = IsLowStrengthPropertyKey.BindableProperty;

        static readonly BindablePropertyKey IsMedStrengthPropertyKey = BindableProperty.CreateReadOnly("IsMedStrength", typeof(bool), typeof(bool), false);
        public static readonly BindableProperty IsMedStrengthProperty = IsMedStrengthPropertyKey.BindableProperty;

        static readonly BindablePropertyKey IsHighStrengthPropertyKey = BindableProperty.CreateReadOnly("IsHighStrength", typeof(bool), typeof(bool), false);
        public static readonly BindableProperty IsHighStrengthProperty = IsHighStrengthPropertyKey.BindableProperty;

        public bool IsLowStrength
        {
            get { return (bool)GetValue(IsLowStrengthProperty); }
            private set { SetValue(IsLowStrengthPropertyKey, value); }
        }
        public bool IsMedStrength
        {
            get { return (bool)GetValue(IsMedStrengthProperty); }
            private set { SetValue(IsMedStrengthPropertyKey, value); }
        }
        public bool IsHighStrength
        {
            get { return (bool)GetValue(IsHighStrengthProperty); }
            private set { SetValue(IsHighStrengthPropertyKey, value); }
        }

        public static readonly BindableProperty PasswordProperty = BindableProperty.Create("Password",
                                           typeof(string),
                                           typeof(PasswordChangeBehavior),
                                           string.Empty,
                                           BindingMode.TwoWay,
                                           propertyChanged: PasswordPropertyChanged);

        private static void PasswordPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            PasswordChangeBehavior component = (PasswordChangeBehavior)bindable;
            if (newValue.IsNotNull())
            {
                component.password = (string)newValue;
            }
            else
            {
                component.password = string.Empty;
            }
        }

        public int Password
        {
            get { return (int)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        private string password { get; set; }
        #endregion

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
            string propertyName = ((Entry)sender).ClassId;
            Validator(e.NewTextValue);
        }

        private void Validator(string input)
        {

            IsEmptyOrNull = string.IsNullOrEmpty(input);

            //Regex Validation
            IsInvalid = !ValidationHelper.IsValidPassword(input);

            if (IsInvalid)
            {
                ColorValidation = AppManagement.General_ColorError;
            }
            else
            {
                ColorValidation = AppManagement.General_DefaultColor;              
            }

            //Strength Validation
            int length = input.Length;
            if (length == 0)
            {
                IsLowStrength = false;
                IsMedStrength = false;
                IsHighStrength = false;
            }
            else if (length < 10)
            {
                IsLowStrength = true;
                IsMedStrength = false;
                IsHighStrength = false;
            }
            else if (length >= 10 && length < 13)
            {
                IsLowStrength = false;
                IsMedStrength = true;
                IsHighStrength = false;
            }
            else
            {
                IsLowStrength = false;
                IsMedStrength = false;
                IsHighStrength = true;
            }
        }
    }

    public class ConfirmPasswordChangeBehavior : Behavior<Entry>
    {
        public ConfirmPasswordChangeBehavior()
        {
            ColorValidation = AppManagement.General_DefaultColor;
        }

        #region Bindable Properties

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

        static readonly BindablePropertyKey ColorValidationPropertyKey = BindableProperty.CreateReadOnly("ColorValidation", typeof(Color), typeof(Color), AppManagement.General_DefaultColor);
        public static readonly BindableProperty ColorValidationProperty = ColorValidationPropertyKey.BindableProperty;

        public Color ColorValidation
        {
            get { return (Color)GetValue(ColorValidationProperty); }
            private set { SetValue(ColorValidationPropertyKey, value); }
        }

       

        public static readonly BindableProperty PasswordProperty = BindableProperty.Create("Password",
                                           typeof(string),
                                           typeof(ConfirmPasswordChangeBehavior),
                                           string.Empty,
                                           BindingMode.TwoWay,
                                           propertyChanged: PasswordPropertyChanged);

        private static void PasswordPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ConfirmPasswordChangeBehavior component = (ConfirmPasswordChangeBehavior)bindable;
            if (newValue.IsNotNull())
            {
                component.password = (string)newValue;
                component.Validator(component.password, component.confirmPassword);
            }
            
        }

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        private string password { get; set; }

        private string confirmPassword { get; set; }
        #endregion

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            bindable.BindingContextChanged += BindableOnBindingContextChanged;

            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            bindable.BindingContextChanged -= BindableOnBindingContextChanged;

            base.OnDetachingFrom(bindable);
        }

        private void BindableOnBindingContextChanged(object sender, EventArgs e)
        {
            var entry = (Entry)sender as Entry;
            BindingContext = entry.BindingContext;
        }

        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            confirmPassword = e.NewTextValue;
            Validator(password, confirmPassword);
        }

        private void Validator(string password, string confirmPassword)
        {
            IsEmptyOrNull = string.IsNullOrEmpty(confirmPassword);
            if (IsEmptyOrNull)
            {
                IsInvalid = false;
            }
            else
            {
                IsInvalid = password != confirmPassword;
            }
           
        }
    }
}
