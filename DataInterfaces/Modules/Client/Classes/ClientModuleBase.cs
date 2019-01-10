﻿using SharedLib;
using System.ComponentModel.Composition;

namespace Client
{
    /// <summary>
    /// Base module class.
    /// </summary>
    public abstract class ClientModuleBase : PropertyChangedBase,
        IPartImportsSatisfiedNotification
    {
        #region FIELDS
        private IClient client;
        #endregion

        #region IMPORTS

        /// <summary>
        /// Gets client instance.
        /// </summary>
        [Import()]
        public IClient Client
        {
            get { return client; }
            private set { SetProperty(ref client, value); }
        }

        [Import(AllowDefault = true)]
        public virtual IDialogService DialogService
        {
            get; protected set;
        }

        #endregion

        #region IPartImportsSatisfiedNotification
        public virtual void OnImportsSatisfied()
        {
        }
        #endregion
    }
}
