﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.Windows.Documents;
using System.Globalization;
using System.Windows.Controls.Primitives;
using System.Collections.ObjectModel;
using CoreLib;
using System.Collections;
using SharedLib.ViewModels;
using SharedLib;
using CyClone.Core;

namespace SkinInterfaces.Converters
{
    #region PopupHorizontalOffsetConverter
    public class PopupHorizontalOffsetConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (values != null)
                {
                    if (values[0] != DependencyProperty.UnsetValue &
                        values[1] != DependencyProperty.UnsetValue &
                        values[0] != null &
                        values[1] != null)
                    {
                        bool isOpen = (bool)values[0];
                        if (values[1] is Popup)
                        {
                            Popup popup = values[1] as Popup;
                            if (popup.Child != null)
                            {
                                double contentCenter = popup.Child.RenderSize.Width / 2;
                                double popupCenter = popup.PlacementTarget.RenderSize.Width / 2;
                                return (Double)(popupCenter - contentCenter);
                            }
                        }
                        else if (values[1] is ToolTip)
                        {
                            ToolTip popup = values[1] as ToolTip;
                            if (popup.PlacementTarget != null)
                            {
                                double contentCenter = popup.RenderSize.Width / 2;
                                double popupCenter = popup.PlacementTarget.RenderSize.Width / 2;
                                return (Double)(popupCenter - contentCenter);
                            }
                        }

                    }
                }
            }
            catch
            { }
            return (Double)0;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region DimensionsConverter
    public class DimensionsConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (double.IsNaN((double)value))
            {
                return -1;
            }
            else if (double.IsInfinity((double)value))
            {
                return -2;
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double doubleval = double.NaN;
            if (double.TryParse(value.ToString(), out doubleval))
            {
                if (doubleval == -1)
                {
                    return double.NaN;
                }
                if (doubleval == -2)
                {
                    return double.PositiveInfinity;
                }
                else
                {
                    return value;
                }
            }
            else
            {
                return double.NaN;
            }

        }

        #endregion
    }
    #endregion

    #region MarginConverter
    public class MarginConverter : DependencyObject, IMultiValueConverter
    {
        private UserControl Control
        {
            get;
            set;
        }
        #region IMultiValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                MarginConverterParams param = (MarginConverterParams)int.Parse(parameter.ToString());
                this.Control = values[4] as UserControl;
                if (param == MarginConverterParams.Top)
                {
                    if (values[0] != DependencyProperty.UnsetValue)
                    {
                        Double value = double.Parse(values[0].ToString());
                        return value.ToString();
                    }
                }
                if (param == MarginConverterParams.Bottom)
                {
                    if (values[1] != DependencyProperty.UnsetValue)
                    {
                        Double value = double.Parse(values[1].ToString());
                        return value.ToString();
                    }
                }
                if (param == MarginConverterParams.Left)
                {
                    if (values[2] != DependencyProperty.UnsetValue)
                    {
                        Double value = double.Parse(values[2].ToString());
                        return value.ToString();
                    }
                }
                if (param == MarginConverterParams.Right)
                {
                    if (values[3] != DependencyProperty.UnsetValue)
                    {
                        Double value = double.Parse(values[3].ToString());
                        return value.ToString();
                    }
                }
                return (0).ToString();
            }
            catch
            {
                return (0).ToString();
            }

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                Object[] data = new object[4];
                MarginConverterParams param = (MarginConverterParams)int.Parse(parameter.ToString());

                if (this.Control != null)
                {
                    Thickness margins = this.Control.Margin;
                    if (param == MarginConverterParams.Top)
                    {
                        margins.Top = double.Parse(value.ToString());
                    }
                    if (param == MarginConverterParams.Bottom)
                    {
                        margins.Bottom = double.Parse(value.ToString());
                    }
                    if (param == MarginConverterParams.Left)
                    {
                        margins.Left = double.Parse(value.ToString());
                    }
                    if (param == MarginConverterParams.Right)
                    {
                        margins.Right = double.Parse(value.ToString());
                    }
                    this.Control.Margin = margins;
                }

                return data;
            }
            catch
            {
                return null;
            }

        }

        #endregion
    }
    #endregion

    #region NullVisibilityConverter
    /// <summary>
    /// Converts Null to visibility.
    /// This can be used in some components which doesnt need to be displayed if the value they bound to is null.
    /// </summary>
    public class NullVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    #endregion

    #region NullToBoolConverter
    public class NullToBoolConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || string.IsNullOrEmpty(value as string))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    #endregion

    #region BoolToVisibilityConverter
    /// <summary>
    /// Converts bool value to visibility.
    /// <remarks>If revert operation required specify tru as converter parameter.</remarks>
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value is bool)
                {
                    #region Check for revert parameter
                    bool revert = false;
                    if (parameter != null)
                    {
                        bool temp;
                        if (bool.TryParse(parameter.ToString(), out temp))
                        {
                            revert = temp;
                        }
                    }
                    #endregion

                    if ((bool)value == true)
                    {
                        return revert ? Visibility.Collapsed : Visibility.Visible;
                    }
                    else
                    {
                        return revert ? Visibility.Visible : Visibility.Collapsed;
                    }
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
            catch
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    #endregion

    #region CountToVisibilityConverter
    public class CountToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value == null)
                {
                    return Visibility.Collapsed;
                }
                else if ((int)value > 0)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
            catch
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    #endregion

    #region CountToBoolConverter
    public class CountToBoolConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value == null)
                {
                    return false;
                }
                else
                {
                    return (int)value > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    #endregion

    #region ControlBoxStatesConverter
    public class ControlBoxStatesConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                int type = (int)parameter;
                SkinInterfaces.ElementVisualState supported = (SkinInterfaces.ElementVisualState)value;
                if (type == 1)
                {
                    if ((supported & ElementVisualState.Minimized) == ElementVisualState.Minimized)
                    {
                        return Visibility.Visible;
                    }
                    return Visibility.Collapsed;
                }
                if (type == 2)
                {
                    if ((supported & ElementVisualState.Maximized) == ElementVisualState.Maximized)
                    {
                        return Visibility.Visible;
                    }
                    return Visibility.Collapsed;
                }
                if (type == 3)
                {
                    if ((supported & ElementVisualState.Closed) == ElementVisualState.Closed)
                    {
                        return Visibility.Visible;
                    }
                }
                return Visibility.Collapsed;
            }
            catch
            {
                return Visibility.Collapsed;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    #endregion

    #region GameServerNameConverter
    /// <summary>
    /// This class converts the game server name to the standart color strings.
    /// </summary>
    public class GameServerNameConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value != null)
                {
                    //Get the initial string value.
                    string initialstring = value.ToString();
                    //Create a textblock to hold the value of string.
                    TextBlock textholder = new TextBlock();
                    textholder.TextWrapping = TextWrapping.NoWrap;
                    textholder.TextTrimming = TextTrimming.CharacterEllipsis;
                    //Get the first index of color key.
                    int index = initialstring.IndexOf("^");
                    //Ignore or proceed depending on color keys found.
                    if (index == -1)
                    {
                        //No color keys found.
                        //Return full string to the caller.
                        textholder.Inlines.Add(new Run(initialstring));
                    }
                    else
                    {
                        while (true)
                        {
                            if (index != -1)
                            {
                                string color = findcolor(initialstring.ToCharArray()[index + 1].ToString());
                                int nextindex = initialstring.IndexOf("^", index + 1);

                                if ((nextindex != -1) & (nextindex != index + 1))
                                {
                                    string substring = initialstring.Substring(index + 2, (nextindex) - (index + 2));
                                    Run subrun = new Run(substring);
                                    subrun.Foreground = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFromString(color.ToString());
                                    textholder.Inlines.Add(subrun);
                                    index = nextindex;
                                }
                                else
                                {
                                    string substring = initialstring.Substring(index + 2, initialstring.Length - (index + 2));
                                    Run subrun = new Run(substring);

                                    subrun.Foreground = (System.Windows.Media.Brush)new System.Windows.Media.BrushConverter().ConvertFromString(color);
                                    textholder.Inlines.Add(subrun);
                                    return textholder;
                                }

                            }
                            else
                            {
                                break;
                            }
                        }

                    }

                }
                return value;
            }
            catch
            {
                return "Unable To Parse";
            };

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
        string findcolor(string character)
        {
            switch (character)
            {
                case "0": return "Black";
                case "1": return "Red";
                case "2": return "Green";
                case "3": return "Yellow";
                case "4": return "Blue";
                case "5": return "Cyan";
                case "6": return "Pink";
                case "7": return "White";
                case "8": return "Orange";
                case "9": return "Gray";
                case "a": return "Orange";
                case "b": return "Turquoise";
                case "c": return "Purple";
                case "d": return "LightBlue";
                case "e": return "Purple";
                case "f": return "LightBlue";
                case "g": return "LightGreen";
                case "h": return "DarkGreen";
                case "i": return "DarkRed";
                case "j": return "Claret";
                case "k": return "Brown";
                case "l": return "LightBrown";
                case "m": return "Olive";
                case "n": return "Beige";
                case "o": return "Beige";
                case "p": return "Black";
                case "r": return "Green";
                case "s": return "Yellow";
                case "t": return "Blue";
                case "u": return "Cyan";
                case "v": return "Pink";
                case "w": return "White";
                case "x": return "Orange";
                case "y": return "Gray";
                case "z": return "Orange";
                case "/": return "Beige";
                case "*": return "Gray";
                case "-": return "Olive";
                case "+": return "FoxyRed";
                case "?": return "DarkBrown";
                case "@": return "Brown";
            }
            return null;
        }
    }
    #endregion

    #region FallBackConverter
    public class FallBackConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                return value;
            }
            else
            {
                return parameter;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region HiddenToOpacityConverter
    public class HiddenToOpacityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool revert = false;
            if (parameter != null)
            {
                bool.TryParse(parameter.ToString(), out revert);
            }

            if ((bool)value == true)
            {
                return revert ? 1 : 0.5;
            }
            else
            {
                return revert ? 0.5 : 1;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region MinDateToVisibilityConverter
    /// <summary>
    /// Converts DateTime to Visibility.
    /// <remarks>If DateTime equals to MinDate Collapsed returned else Visible returned.</remarks>
    /// </summary>
    public class MinDateToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime)
            {
                return ((DateTime)value) == DateTime.MinValue | ((DateTime)value) == DateTime.MaxValue ? Visibility.Collapsed : Visibility.Visible;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region BytesConverter
    public class BytesConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                long bytes = long.Parse(value.ToString());
                return FormatBytes(bytes);
            }
            catch
            {
                return value;
            }
        }
        public string FormatBytes(long bytes)
        {
            const int scale = 1024;
            string[] orders = new string[] { "GB", "MB", "KB", "Bytes" };
            long max = (long)Math.Pow(scale, orders.Length - 1);

            foreach (string order in orders)
            {
                if (bytes > max)
                    return string.Format("{0:##.##} {1}", decimal.Divide(bytes, max), order);

                max /= scale;
            }
            return "0 Bytes";
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    #endregion

    #region DateTimeToDateConverter
    /// <summary>
    /// Converts DateTime values to a short date string.
    /// </summary>
    public class DateTimeToDateConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((DateTime)value).ToShortDateString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    #endregion

    #region TimeSpanConverter
    public class TimeSpanConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {

                if (value is TimeSpan)
                {
                    TimeSpan span = (TimeSpan)value;
                    string spanString = span.ToString();
                    if (spanString.LastIndexOf(".") != -1)
                    {
                        return spanString.Substring(0, spanString.LastIndexOf("."));
                    }
                    else
                    {
                        return spanString;
                    }
                }
                return value;
            }
            catch
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    #endregion

    #region EmptyPathConverter
    public class EmptyPathConverter : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (string.IsNullOrEmpty((value as string)))
            {
                return null;
            }
            else
            {
                string s = (value as string).Trim();
                if (string.IsNullOrEmpty(s))
                {
                    return null;
                }
                else
                {
                    return value;
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (string.IsNullOrEmpty((value as string)))
            {
                return null;
            }
            else
            {
                string s = (value as string).Trim();
                if (string.IsNullOrEmpty(s))
                {
                    return null;
                }
                else
                {
                    return value;
                }
            }
        }

        #endregion
    }
    #endregion

    #region ImageByteToBitmapSourceConverter
    /// <summary>
    /// Converts image byte array value to an bitmap image value. 
    /// </summary>
    public class ImageByteToBitmapSourceConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            byte[] data = value as byte[];
            try
            {
                if (data != null)
                {
                    BitmapImage image = new BitmapImage();
                    image.BeginInit();
                    image.StreamSource = new MemoryStream(data);
                    image.EndInit();
                    return image;
                }
                else
                {
                    return DependencyProperty.UnsetValue;
                }
            }
            catch
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    #endregion

    #region RegistryHiveConverter
    /// <summary>
    /// Converts a RegistryHive values to a numeric integer values.
    /// </summary>
    public class RegistryHiveConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                RegistryHive hive = (RegistryHive)value;
                switch (hive)
                {
                    case RegistryHive.ClassesRoot:
                        return 0;
                    case RegistryHive.CurrentUser:
                        return 1;
                    case RegistryHive.LocalMachine:
                        return 2;
                    case RegistryHive.Users:
                        return 3;
                    case RegistryHive.CurrentConfig:
                        return 4;
                    case RegistryHive.PerformanceData:
                        return 5;
                    case RegistryHive.DynData:
                        return 6;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                int index = (int)value;
                switch (index)
                {
                    case 0:
                        return RegistryHive.ClassesRoot;
                    case 1:
                        return RegistryHive.CurrentUser;
                    case 2:
                        return RegistryHive.LocalMachine;
                    case 3:
                        return RegistryHive.Users;
                    case 4:
                        return RegistryHive.CurrentConfig;
                    case 5:
                        return RegistryHive.PerformanceData;
                    case 6:
                        return RegistryHive.DynData;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
    }
    #endregion

    #region ToLowerConverter
    /// <summary>
    /// Converts string values to lower string values.
    /// </summary>
    public class ToLowerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                return value.ToString().ToLower();
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region ToUpperConverter
    /// <summary>
    /// Converts string values to upper string values.
    /// </summary>
    public class ToUpperConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value != null)
                {
                    return value.ToString().ToUpper();
                }
                else
                {
                    return value;
                }

            }
            catch
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region CurrencyToStringConverter
    /// <summary>
    /// Converts a currency string to a formated currency string.
    /// </summary>
    public class CurrencyToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Double & value != null)
            {
                CultureInfo info = System.Threading.Thread.CurrentThread.CurrentCulture;
                return String.Format("{0:C}", value);
            }
            else
            {
                return value;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region UserTimeToStringConverter
    public class UserTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null & value is int)
            {
                TimeSpan dateDifference = TimeSpan.FromMinutes((int)value);
                //return string.Format("{0:00}:{1:00}:{2:00}", dateDifference.TotalHours, dateDifference.Minutes, dateDifference.Seconds);
                if (dateDifference.TotalDays != 0)
                {
                    return string.Format("{0} days, {1:D2} hrs, {2:D2} mins", dateDifference.Days, dateDifference.Hours, dateDifference.Minutes);
                }
                else
                {
                    return string.Format("{0:D2} hrs, {1:D2} mins", dateDifference.Hours, dateDifference.Minutes);
                }
            }
            else
            {
                return value;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region NumberToRoundedConverter
    /// <summary>
    /// Converts an double value to a rounded double value.
    /// </summary>
    public class NumberToRoundedConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double n;
            if (double.TryParse(value.ToString(), out n))
            {
                return Math.Round(n, 1);
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region FlagsEnumValueConverter
    public class FlagsEnumValueConverter : IValueConverter
    {
        private int targetValue;

        public FlagsEnumValueConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int mask = (int)parameter;
            this.targetValue = (int)value;
            return ((mask & this.targetValue) != 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            this.targetValue ^= (int)parameter;
            return Enum.Parse(targetType, parameter.ToString());
        }
    }
    #endregion

    #region FlagsEnumValueVisibilityConverter
    public class FlagsEnumValueVisibilityConverter : IValueConverter
    {
        private int targetValue;

        public FlagsEnumValueVisibilityConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int mask = (int)parameter;
            this.targetValue = (int)value;
            if (((mask & this.targetValue) != 0))
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region BytesToMegabyesConverter
    /// <summary>
    /// Converts bytes value ammount to megabytes.
    /// </summary>
    public class BytesToMegabyesConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var bytes = 0;
                if (int.TryParse(value.ToString(), out bytes))
                {
                    return bytes / 1024 / 1024;
                }
                else
                {
                    return value;
                }
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var megaBytes = 0;
                if (int.TryParse(value.ToString(), out megaBytes))
                {
                    if (megaBytes > 0)
                    {
                        return megaBytes * 1024 * 1024;
                    }
                    else
                    {
                        return megaBytes;
                    }
                }
                else
                {
                    return value;
                }
            }
            else
            {
                return value;
            }
        }
    }
    #endregion

    #region IOPathConverter
    /// <summary>
    /// Converts a full path to file to a file name.
    /// </summary>
    public class IOPathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value != null & (value is String))
                {
                    if (!String.IsNullOrWhiteSpace(value.ToString()))
                    {
                        return Path.GetFileName(value.ToString());
                    }
                }
            }
            catch
            {
                return value;
            }
            return parameter;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion    

    #region SplitStringConverter
    public class SplitStringConverter : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                foreach (string s in (value as ObservableCollection<string>))
                {
                    builder.Append(s);
                    builder.Append(";");
                }
                return builder.ToString();
            }
            catch
            {
                return string.Empty;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                ObservableCollection<string> strings = new ObservableCollection<string>();

                foreach (string s in (value as string).Split(new char[] { ';' }))
                {

                    if (s.Trim() != string.Empty)
                    {
                        strings.Add(s);
                    }

                }
                return strings;
            }
            catch
            {
                return new ObservableCollection<string>();
            }
        }

        #endregion
    }
    #endregion

    #region TypeToStringConverter
    public class TypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return value.GetType().ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region RevertBoolConverter
    public class RevertBoolConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                return !(bool)value;
            }
            catch
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                return !(bool)value;
            }
            catch
            {
                return value;
            }
        }

        #endregion
    }
    #endregion

    #region ExtensionConverter
    public class ExtensionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (value is IcyFileSystemInfo)
                {
                    IcyFileSystemInfo info = (IcyFileSystemInfo)value;
                    if (info.IsDirectory)
                    {
                        return "Directory";
                    }
                    else
                    {
                        return Path.GetExtension(info.FullName);
                    }
                }
                else if (value is IcyDriveInfo)
                {
                    return "Drive";
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region ReverseValueConverter
    public class ReverseValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] != DependencyProperty.UnsetValue & values[1] != DependencyProperty.UnsetValue)
            {
                int initialTotal = (int)values[0];
                int totalLeft = (int)values[1];
                int val = Math.Abs(totalLeft - initialTotal);
                return (double)val;
            }
            return Binding.DoNothing;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region OperatingSystemConverter
    public class OperatingSystemConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            OperatingSystems os = (OperatingSystems)value;
            switch (os)
            {
                case OperatingSystems.WindowsXp:
                    return "Microsoft Windows XP";
                case OperatingSystems.Windows2000:
                    return "Microsoft Windows 2000";
                case OperatingSystems.Windows7:
                    return "Microsoft Windows 7";
                case OperatingSystems.Windows8:
                    return "Microsoft Windows 8";
                case OperatingSystems.WindowsServer2003:
                    return "Microsoft Windows Server 2003";
                case OperatingSystems.WindowsServer2003R2:
                    return "Microsoft Windows Server 2003 R2";
                case OperatingSystems.WindowsServer2008:
                    return "Microsoft Windows Server 2008";
                case OperatingSystems.WindowsServer2008R2:
                    return "Microsoft Windows Server 2008 R2";
                case OperatingSystems.WindowsServer2012:
                    return "Microsoft Windows Server 2012";
                case OperatingSystems.WindowsVista:
                    return "Microsoft Windows Vista";
                default:
                    return "Unknown Operating System";
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region BoolToStringConverter
    public class BoolToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = (bool)value;
            if (val)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string val = (string)value;
            if (!String.IsNullOrWhiteSpace(val))
            {
                if (val.ToLower() == "yes")
                {
                    return true;
                }
                else if (val.ToLower() == "no")
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return "Unknown";
            }
        }
    }
    #endregion

    #region NullToEnabledConverter
    public class NullToEnabledConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    #endregion

    #region EmptyStringToVisibilityConvert
    public class EmptyStringToVisibilityConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (String.IsNullOrWhiteSpace(value as string))
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region DefaultButtonConverter
    public class DefaultButtonConverter : BindableParametersConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (this.BindableConverterParameter != null && this.BindableConverterParameter is IMessageBoxModel && value is NotificationButtons)
            {
                NotificationButtons valueEnum = (NotificationButtons)value;
                IMessageBoxModel parameterEnum = (IMessageBoxModel)this.BindableConverterParameter;
                return valueEnum == parameterEnum.DefaultButton;
            }
            return false;
        }
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region EnumToBoolConverter
    public class EnumToBoolConverter : IValueConverter
    {
        public Type EnumType { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Object.Equals(value, Enum.Parse(EnumType, parameter.ToString()));
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Enum.Parse(EnumType, parameter.ToString()) : Enum.ToObject(EnumType, 0);
        }
    }
    #endregion

    #region StringEnvrionmentConverter
    /// <summary>
    /// Convertes string to environment expanded string.
    /// </summary>
    public class StringToEnvrionmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is string)
                return Environment.ExpandEnvironmentVariables(value.ToString());
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
}

