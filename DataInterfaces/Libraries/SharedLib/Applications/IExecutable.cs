﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntegrationLib;
using System.Diagnostics;

namespace SharedLib.Applications
{
    public interface IExecutable
    {
        int ID { get; }
        string Arguments { get; set; }
        bool AutoLaunch { get; set; }
        string ExecutableName { get; set; }
        string ExecutablePath { get; set; }
        System.Windows.Data.ListCollectionView HierarchicalView { get; }
        bool KillChildren { get; set; }
        ApplicationModes Modes { get; set; }
        bool MonitorChildren { get; set; }
        bool MultiRun { get; set; }
        RunMode RunMode { get; set; }
        string WorkingDirectory { get; set; }
        IDeploymentProfile DefaultDeploymentProfile { get; }
        Process GetProcessForExecutable(IApplicationProfile application);
    }

}