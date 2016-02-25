﻿using SharedLib.Dispatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib
{
    public interface IRemoteService
    {
        #region EVENTS
        
        /// <summary>
        /// Occurs when service connection state changed.
        /// </summary>
        event ConnectionStateDelegate ConnectionStateChange; 

        #endregion

        #region PROPERTIES
        
        /// <summary>
        /// Gets if service is currently connected.
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Connects to service.
        /// </summary>
        void Connect();

        /// <summary>
        /// Connects to service asynchronously.
        /// </summary>
        Task ConnectAsync();

        /// <summary>
        /// Disconnects from service.
        /// </summary>
        void Disconnect();

        /// <summary>
        /// Disconnects from service asynchronously.
        /// </summary>
        Task DisconnectAsync();

        /// <summary>
        /// Gets message dispatcher.
        /// </summary>
        IMessageDispatcher Dispatcher { get; } 
        
        #endregion
    }
}