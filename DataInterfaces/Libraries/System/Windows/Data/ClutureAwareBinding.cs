﻿using System.Globalization;

namespace System.Windows.Data
{
    /// <summary>
    /// Binding that uses current culture.
    /// </summary>
    public class CultureAwareBinding : Binding
    {
        public CultureAwareBinding()
        {
            ConverterCulture = CultureInfo.CurrentCulture;
        }

        public CultureAwareBinding(string path):base(path)
        {
            ConverterCulture = CultureInfo.CurrentCulture;
        }
    }
}
