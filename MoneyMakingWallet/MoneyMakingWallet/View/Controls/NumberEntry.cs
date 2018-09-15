using IDMONEY.IO.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace IDMONEY.IO.View
{
    public enum EnumNumberType
    {
        Amount = 1,
        Percent = 2
    }

    public class NumberEntry : Entry
    {
        public static readonly BindableProperty AmountProperty = BindableProperty.Create("Amount",
                                                                    typeof(decimal?),
                                                                    typeof(NumberEntry),
                                                                    null,
                                                                    BindingMode.TwoWay,
                                                                    propertyChanged: AmountPropertyChanged);

        public static readonly BindableProperty NumberTypeProperty = BindableProperty.Create("NumberType",
                                                            typeof(EnumNumberType),
                                                            typeof(NumberEntry),
                                                            EnumNumberType.Amount,
                                                            BindingMode.OneWay,
                                                            propertyChanged: NumberTypePropertyChanged);

        public static readonly BindableProperty MaximumAmountProperty = BindableProperty.Create("MaximumAmount",
                                                            typeof(decimal?),
                                                            typeof(NumberEntry),
                                                            null,
                                                            BindingMode.TwoWay,
                                                            propertyChanged: MaximumAmountPropertyChanged);

        public static readonly BindableProperty MinimumAmountProperty = BindableProperty.Create("MinimumAmount",
                                                    typeof(decimal?),
                                                    typeof(NumberEntry),
                                                    null,
                                                    BindingMode.TwoWay,
                                                    propertyChanged: MinimumAmountPropertyChanged);

        public decimal? Amount
        {
            get { return (decimal?)GetValue(AmountProperty); }
            set { SetValue(AmountProperty, value); }
        }

        public EnumNumberType NumberType
        {
            get { return (EnumNumberType)GetValue(NumberTypeProperty); }
            set { SetValue(NumberTypeProperty, value); }
        }

        public decimal? MaximumAmount
        {
            get { return (decimal?)GetValue(MaximumAmountProperty); }
            set { SetValue(MaximumAmountProperty, value); }
        }

        public decimal? MinimumAmount
        {
            get { return (decimal?)GetValue(MinimumAmountProperty); }
            set { SetValue(MinimumAmountProperty, value); }
        }

        public NumberEntry()
        {
            Text = FormatterHelper.Format(0);
            Keyboard = Keyboard.Numeric;
            this.Focused += OnHandlerFocused;
            this.Unfocused += OnHandlerUnfocused;
        }

        private void OnHandlerUnfocused(object sender, FocusEventArgs e)
        {
            decimal value = 0;
            if (decimal.TryParse(Text, out value))
            {
                if (MaximumAmount.IsNotNull() && value > MaximumAmount)
                {
                    Amount = MaximumAmount;
                    Text = NumberType == EnumNumberType.Amount ? FormatterHelper.Format(Amount.Value) : FormatterHelper.FormatPercentage(Amount.Value);
                }
                else if (MinimumAmount.IsNotNull() && value < MinimumAmount)
                {
                    Amount = MinimumAmount;
                    Text = NumberType == EnumNumberType.Amount ? FormatterHelper.Format(Amount.Value) : FormatterHelper.FormatPercentage(Amount.Value);
                }
                else
                {
                    Amount = value;
                    Text = NumberType == EnumNumberType.Amount ? FormatterHelper.Format(Amount.Value) : FormatterHelper.FormatPercentage(Amount.Value);
                }
            }
            else
            {
                Text = string.Empty;
                Amount = 0;
            }
        }

        private void OnHandlerFocused(object sender, FocusEventArgs e)
        {
            Amount = 0;
            Text = string.Empty;
        }

        private static void AmountPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue.IsNotNull())
            {
                NumberEntry entry = (NumberEntry)bindable;
                entry.Amount = (decimal)newValue;
                entry.ChangeText();
            }
        }

        private static void NumberTypePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue.IsNotNull())
            {
                NumberEntry entry = (NumberEntry)bindable;
                entry.NumberType = (EnumNumberType)newValue;

                if (entry.NumberType == EnumNumberType.Percent)
                {
                    entry.MinimumAmount = 0;
                    entry.MaximumAmount = 100;
                }

                if (oldValue.IsNull())
                {
                    entry.ChangeText();
                }
            }
        }

        private void ChangeText()
        {
            Text = NumberType == EnumNumberType.Amount ? FormatterHelper.Format(Amount.Value) : FormatterHelper.FormatPercentage(Amount.Value);
        }

        private static void MaximumAmountPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            NumberEntry entry = (NumberEntry)bindable;
            entry.MaximumAmount = (decimal)newValue;
        }

        private static void MinimumAmountPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            NumberEntry entry = (NumberEntry)bindable;
            entry.MinimumAmount = (decimal)newValue;
        }
    }
}
