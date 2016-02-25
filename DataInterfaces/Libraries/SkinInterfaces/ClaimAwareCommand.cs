﻿using System;
using System.IdentityModel.Services;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Security.Permissions;
using System.Threading;

namespace SkinInterfaces
{
    /// <summary>
    /// Claim aware ICommand.
    /// </summary>
    public class ClaimAwareCommand<T1, T2> : SimpleCommand<T1, T2>
    {
        #region CONSTRUCTOR
        public ClaimAwareCommand(Func<T1, bool> canExecuteMethod, Action<T2> executeMethod)
           : base(canExecuteMethod, executeMethod)
        {
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if method access was previously authorized.
        /// </summary>
        private bool IsAuthorized { get; set; }

        /// <summary>
        /// Gets or sets if access check should reoccur.
        /// </summary>
        private bool IsAuthorizedChecked { get; set; }

        #endregion

        #region FUNCTIONS

        private bool IsMethodAuthorized(MethodInfo methodInfo)
        {
            bool isAuthorized = true;

            var claimAttributes = (ClaimsPrincipalPermissionAttribute[])methodInfo.GetCustomAttributes(typeof(ClaimsPrincipalPermissionAttribute), true);

            if (claimAttributes.Count() == 0)
                return true;

            foreach (var claimRequest in claimAttributes)
            {
                ClaimsPrincipal currentPrincipal = Thread.CurrentPrincipal as ClaimsPrincipal;

                if (currentPrincipal != null)
                {
                    isAuthorized = claimRequest.Action == SecurityAction.Demand ? currentPrincipal.HasClaim(claimRequest.Resource, claimRequest.Operation) : true;
                }

                if (!isAuthorized)
                    break;
            }

            return isAuthorized;
        }

        #endregion

        #region OVERRIDES

        public override bool CanExecute(object parameter)
        {
            this.IsAuthorized = !this.IsAuthorizedChecked ? (this.executeMethod == null || this.executeMethod != null && this.IsMethodAuthorized(this.executeMethod.Method)) : this.IsAuthorized;

            return this.IsAuthorized && CanExecute((T1)parameter);
        }

        public override void RaiseCanExecuteChanged()
        {
            base.RaiseCanExecuteChanged();
            this.IsAuthorizedChecked = false;
        }

        #endregion
    }
}