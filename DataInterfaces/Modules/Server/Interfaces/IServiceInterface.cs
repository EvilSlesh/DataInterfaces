﻿using System;
using SharedLib.Applications;
using NetLib;
using SharedLib;
using System.Collections.Generic;
using SharedLib.Configuration;
using CoreLib;
using System.Collections.ObjectModel;
using SharedLib.User;
using CyClone.Core;
using SharedLib.Dispatcher;

namespace ServerService
{
    /// <summary>
    /// Gizmo Service interface.
    /// </summary>
    public interface IService
    {
        #region EVENTS

        event StartUpDelegate Startup;

        event ShutDownDelegate Shutdown;

        event MappingsConfigurationChnagedDelegate MappingsChange;

        event HostEventDelegate HostEvent;

        event EventHandler<HostPropertiesChangedEventArgs> HostPropertiesChange;

        event ReservationEventDelegate ReservationChange;

        event UserStateChangeDelegate UserStateChange;

        event UserProfileChangeDelegate UserProfileChange;

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the service application container.
        /// </summary>
        IApplicationContainer ApplicationContainer { get; }
   
        /// <summary>
        /// Gets system status.
        /// </summary>
        ISystemStatus SystemStatus { get; }

        /// <summary>
        /// Gets version info.
        /// </summary>
        string Version { get; }

        /// <summary>
        /// Gets application module.
        /// </summary>
        IApplicationModule Module { get; }

        /// <summary>
        /// Gets server license.
        /// </summary>
        ILicense License { get; }

        /// <summary>
        /// Gets system hardware id.
        /// </summary>
        string HardwareId { get; }
        
        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Gets a new instance of host entry.
        /// </summary>
        /// <returns></returns>
        IHostEntry GetHostClassInstance();

        /// <summary>
        /// Gets host entries.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IHostEntry> IHostEntryGet();

        /// <summary>
        /// Gets host entry by dispatcher.
        /// </summary>
        /// <param name="dispatcher">Dispatcher instance.</param>
        /// <returns>Found host, null in case host not found.</returns>
        IHostEntry HostGet(IMessageDispatcher dispatcher);

        /// <summary>
        /// Restarts the service.
        /// </summary>
        void Restart();

        /// <summary>
        /// Stops the service.
        /// </summary>
        void Stop();

        #endregion
    }
}
