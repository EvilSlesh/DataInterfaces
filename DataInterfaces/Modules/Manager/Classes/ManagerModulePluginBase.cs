﻿using IntegrationLib;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Modules
{
    /// <summary>
    /// Manager module plugin base.
    /// Manager modules created and initialized after creation of all other modules.
    /// </summary>
    [InheritedExport(typeof(IManagerModule))]
    [PartNotDiscoverable()]
    public class ManagerModulePluginBase : IManagerModule,
        IPartImportsSatisfiedNotification
    {
        #region VIRTUAL METHODS
        
        /// <summary>
        /// When ovveriden should take care of initializing plugin.
        /// </summary>
        public virtual void Initialize()
        {
        }

        /// <summary>
        /// When overriden should take care of starting plugin.
        /// </summary>
        public virtual void Start()
        {
        }

        /// <summary>
        /// When overriden should take care of stopping plugin.
        /// </summary>
        public virtual void Stop()
        {
        } 

        #endregion

        #region IPartImportsSatisfiedNotification
        public virtual void OnImportsSatisfied()
        {
        }
        #endregion
    }
}