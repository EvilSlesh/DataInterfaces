﻿using System;
using SharedLib.Dispatcher;
using System.Diagnostics;

namespace CoreLib.Diagnostics
{
    #region ICoreProcess
    public interface ICoreProcess : IDisposable
    {
        /// <summary>
        /// Gets if the process has exited.
        /// </summary>
        bool HasExited { get; }

        /// <summary>
        /// Gets the unique process id.
        /// </summary>
        int Id { get; }

        void Kill();

        /// <summary>
        /// Gets the process name.
        /// </summary>
        string ProcessName { get; }

        /// <summary>
        /// Gets proccess executable name.
        /// </summary>
        string ProcessExeName { get; }

        /// <summary>
        /// Gets the parent id of the process.
        /// </summary>
        int ParentId { get; }

        /// <summary>
        /// Discards and refreshes process information.
        /// </summary>
        void Refresh();

        /// <summary>
        /// Gets the base priority of the process.
        /// </summary>
        int BasePriority
        {
            get;
        }

        /// <summary>
        /// Gets the session id of the process.
        /// </summary>
        int SessionId
        {
            get;
        }

        /// <summary>
        /// Gets the exit code of the process.
        /// </summary>
        int ExitCode
        {
            get;
        }

        /// <summary>
        /// Gets the main module of the process.
        /// </summary>
        ICoreProcessModule MainModule
        {
            get;
        }

        /// <summary>
        /// Gets or sets start info of the process.
        /// <remarks>This class can only be obtained when creating new process.</remarks>
        /// </summary>
        ICoreProcessStartInfo StartInfo
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the start time of the process.
        /// <remarks>If information cant be obtained or uanavailable MinDate returned.</remarks>
        /// </summary>
        DateTime StartTime
        {
            get;
        }

        /// <summary>
        /// Gets the exit time of the process.
        /// <remarks>If information cant be obtained or uanavailable MinDate returned.</remarks>
        /// </summary>
        DateTime ExitTime
        {
            get;
        }

        /// <summary>
        /// Gets the cpu usage of process.
        /// </summary>
        int CpuUsage
        {
            get;
        }
        
        /// <summary>
        /// Updates the cpu usage from specified parameters.
        /// </summary>
        /// <param name="userTime">User time.</param>
        /// <param name="kernelTime">Kernel time.</param>
        /// <param name="span">Time span.</param>
        void UpdateCpuUsage(TimeSpan userTime, TimeSpan kernelTime, TimeSpan span);
        
        /// <summary>
        /// Gets total processor time.
        /// </summary>
        TimeSpan TotalProcessorTime
        {
            get;
        }
        
        /// <summary>
        /// Gets user processor time.
        /// </summary>
        TimeSpan UserProcessorTime
        { get; }

        /// <summary>
        /// Gets the current directory of process.
        /// </summary>
        string CurrentDirectory
        {
            get;
        }

        /// <summary>
        /// Gets the process command line.
        /// </summary>
        string CommandLine
        {
            get;
        }

        /// <summary>
        /// Checks if Process handle can be obtained in current thread context.
        /// </summary>
        bool IsAccessable { get; }

        /// <summary>
        /// Gets or sets if process exit event should be hooked.
        /// </summary>
        bool HookExited { get; set; }

        /// <summary>
        /// Gets processor count.
        /// </summary>
        int ProcessorCount { get; }
    }
    #endregion    
}
