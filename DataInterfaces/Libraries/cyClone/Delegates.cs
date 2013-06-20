﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreLib;
using CoreLib.Threading;
using System.IO;

namespace CyClone.Core
{
    #region Deleagates
    public delegate void MappingsConfigurationChnagedDelegate(object sender, MappingsEventArgs e);
    public delegate void ExceptionProcessedDelegate(object sender, Exception ex);
    /// <summary>
    /// Delegate used for file changing notifications.
    /// </summary>
    /// <param name="file">New file.</param>
    public delegate void FileChangedDelegate(object sender, IcyFileSystemInfo file);
    /// <summary>
    /// Delegate used to report errors durring synchronization.
    /// </summary>
    /// <param name="ex"></param>
    public delegate void ErrorEventDelegate(object sender, Exception ex);
    public delegate void CollectStrucutreInfoDelegate(IcyDirectoryInfo source,
    FileInfoLevel infoLevel,
    int hashBlockSize,
    HashType hashType,
    bool recursive, IAbortHandle abortHandle);
    public delegate IcyDiffList CompareStrucutreDelegate(IcyDirectoryInfo destination,
    FileInfoLevel infoLevel,
    IAbortHandle abortHandle);
    public delegate void BeginSyncDelegate(IcyDirectoryInfo source,
    IcyDirectoryInfo destination,
    FileInfoLevel pattern);
    public delegate void BeginSyncStructureDelegate(IcyStructure source,
    IcyDirectoryInfo destination,
    bool substractSource,
    IAbortHandle abortHandle);
    public delegate void SynchronizationProgressDelegate(object sender, SyncProgressEventArgs e);
    public delegate void MappingEventDelegate(IMappingsConfiguration configuration, IcyMapping mapping); 
    #endregion    
}