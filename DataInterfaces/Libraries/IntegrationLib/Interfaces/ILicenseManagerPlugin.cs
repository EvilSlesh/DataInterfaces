﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using SharedLib.Applications;
using System.Windows;
using SharedLib;
using Client;

namespace IntegrationLib
{
    #region ILicenseManagerPlugin
    /// <summary>
    /// License Manager interface.
    /// </summary>
    public interface ILicenseManagerPlugin : IPlugin
    {
        /// <summary>
        /// Installs the license.
        /// </summary>
        /// <param name="key">IApplicationLicense.</param>
        /// <param name="context">IExecutionContext context.</param>
        /// <param name="forceCreation">Sets if process creation should be forced even if execution process is alive.</param>
        void Install(IApplicationLicense key, IExecutionContext context, ref bool forceCreation);

        /// <summary>
        /// Uninstalls the license.
        /// </summary>
        /// <param name="license">IApplicationLicense.</param>
        void Uninstall(IApplicationLicense license);
        
        /// <summary>
        /// Gets the instance of the application license.
        /// </summary>
        /// <returns>IApplicationLicenseKey instance.</returns>
        IApplicationLicenseKey GetLicense(ILicenseProfile profile, ref bool additionHandled, Window owner);
        
        /// <summary>
        /// Edit existing license key.
        /// </summary>
        /// <param name="key">License Key.</param>
        /// <returns>IApplicationLicenseKey instance.</returns>
        IApplicationLicenseKey EditLicense(IApplicationLicenseKey key, ILicenseProfile profile, ref bool additionHandled, Window owner);
        
        /// <summary>
        /// Gets if licenses can be edited by this plugin.
        /// </summary>
        bool CanEdit
        {
            get;
        }
        
        /// <summary>
        /// Gets if licenses can be added to this plugin.
        /// </summary>
        bool CanAdd { get; }
    } 
    #endregion
}