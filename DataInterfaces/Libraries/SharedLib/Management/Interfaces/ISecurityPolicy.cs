﻿using System;
using CoreLib;

namespace SharedLib
{
    /// <summary>
    /// Security policy implementation interface.
    /// </summary>
    public interface ISecurityPolicy
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets or sets security policy id.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets security profile id.
        /// </summary>
        int ProfileId { get; set; }

        /// <summary>
        /// Gets or sets security policy type.
        /// </summary>
        SecurityPolicyType Type { get; set; } 

        #endregion
    }

    #region SecurityPolicy
    /// <summary>
    /// Security policy.
    /// </summary>
    [Serializable()]
    public class SecurityPolicy : ItemObject, ISecurityPolicy
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets security profile id.
        /// </summary>
        public int ProfileId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets policy type.
        /// </summary>
        public SecurityPolicyType Type
        {
            get;
            set;
        }

        #endregion
    }
    #endregion
}
