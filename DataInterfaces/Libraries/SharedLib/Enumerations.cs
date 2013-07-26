﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Linq;
using Localization;

namespace SharedLib
{
    #region Know Folders Types
    /// <summary>
    /// This enumerato is used to combine multiple special folders to unique value.
    /// </summary>
    [Flags()]
    public enum KnownFolderTypes
    {
        /// <summary>
        /// Unset flag.
        /// </summary>
        None = 0,
        /// <summary>
        /// Desktop flag.
        /// </summary>
        [GUIDAttribue("B4BFCC3A-DB2C-424C-B029-7FE99A87C641")]
        [SpecialFolderAttribute(Environment.SpecialFolder.DesktopDirectory)]
        Desktop = 1,
        /// <summary>
        /// Downloads flag.
        /// </summary>
        [GUIDAttribue("374DE290-123F-4565-9164-39C4925E467B")]
        Downloads = 2,
        /// <summary>
        /// Favorites flag.
        /// </summary>
        [GUIDAttribue("1777F761-68AD-4D8A-87BD-30B759FA33DD")]
        [SpecialFolderAttribute(Environment.SpecialFolder.Favorites)]
        Favorites = 4,
        /// <summary>
        /// My Music flag.
        /// </summary>
        [GUIDAttribue("4BD8D571-6D19-48D3-BE97-422220080E43")]
        [SpecialFolderAttribute(Environment.SpecialFolder.MyMusic)]
        Music = 8,
        /// <summary>
        /// My pictures flag.
        /// </summary>
        [GUIDAttribue("33E28130-4E1E-4676-835A-98395C3BC3BB")]
        [SpecialFolderAttribute(Environment.SpecialFolder.MyPictures)]
        Pictures = 16,
        /// <summary>
        /// My videos flag.
        /// </summary>
        [GUIDAttribue("18989B1D-99B5-455B-841C-AB7C74E4DDFC")]
        [SpecialFolderAttribute(Environment.SpecialFolder.MyVideos)]
        Videos = 32,
        /// <summary>
        /// Saved games flag.
        /// </summary>
        [GUIDAttribue("4C5C32FF-BB9D-43b0-B5B4-2D72E54EAAA4")]
        SavedGames = 64,
        /// <summary>
        /// Personal flag (Equals MyDocuments).
        /// </summary>
        [GUIDAttribue("FDD39AD0-238F-46AF-ADB4-6C85480369C7")]
        [SpecialFolderAttribute(Environment.SpecialFolder.MyDocuments)]
        Personal = 128,
        /// <summary>
        /// Basic flag containing all the basic enumerations.
        /// </summary>
        Basic = KnownFolderTypes.Desktop |
            KnownFolderTypes.Downloads |
            KnownFolderTypes.Favorites |
            KnownFolderTypes.Music |
            KnownFolderTypes.Personal |
            KnownFolderTypes.Pictures |
            KnownFolderTypes.SavedGames |
            KnownFolderTypes.Videos,
    }
    #endregion

    #region Application Modes
    /// <summary>
    /// Game application modes.
    /// </summary>
    /// <remarks></remarks>
    [Flags()]
    public enum ApplicationModes : int
    {
        DefaultMode = 0,
        SinglePlayer = 1,
        Online = 2,
        Multiplayer = 4,
        Settings = 8,
        Utility = 16,
        Game = 32,
        Application = 64,
        FreeToPlay = 128,
        RequiresSubscription = 256,
        FreeTrial = 512,

    }
    #endregion

    #region Runmodes
    /// <summary>
    /// Run mode enumeration.
    /// </summary>
    public enum RunMode : int
    {
        FullScreen = 0,
        Minimized = 1,
        Maximized = 2,
        Hidden = 3,
        Normal = 4
    }
    #endregion

    #region Module Scopes
    /// <summary>
    /// Application module type scope enumeration.
    /// </summary>
    [Flags()]
    public enum ModuleScopes : int
    {
        None = 0,
        Client = 1,
        Server = 2,
        Manager = 4,
        Global = ModuleScopes.Client | ModuleScopes.Server | ModuleScopes.Manager,
    }
    #endregion

    #region Activation Types
    /// <summary>
    /// Common activation deactivation types.
    /// </summary>
    [Flags()]
    public enum ActivationType : int
    {
        [Description("Disabled")]
        Disabled = 0,
        [Description("Startup")]
        Startup = 1,
        [Description("Shutdown")]
        Shutdown = 2,
        [Description("Login")]
        Login = 4,
        [Description("Logout")]
        Logout = 8,
        [Description("Pre Launch")]
        PreLaunch = 16,
        [Description("Pre Deploy")]
        PreDeploy = 32,
        [Description("Post Termination")]
        PostTermination = 64,
        [Description("Pre License Management")]
        PreLicenseManagement = 128,
    }
    #endregion

    #region Action Codes
    /// <summary>
    /// Generic completion codes for actions.
    /// </summary>
    public enum ActionCodes : int
    {
        None = 0,
        Success = 1,
        Failure = 2,
        Cancel = 3,
    }
    #endregion

    #region LicenseReservationType
    [Flags]
    public enum LicenseReservationType
    {
        FirstAvailable = 0,
        OneFromEach = 1,
    }
    #endregion

    #region Script Types
    /// <summary>
    /// Script enumeration type.
    /// </summary>
    public enum ScriptTypes
    {
        [Description("Batch")]
        Batch,
        [Description("Visual Basic Script")]
        VbScript,
        [Description("Autoit Script")]
        AutoItScript,
        [Description("Registry Script")]
        RegistryScript,
    }
    #endregion

    #region Login States
    /// <summary>
    ///Login state enumeration.
    /// </summary>
    [Flags()]
    public enum LoginState
    {
        /// <summary>
        /// Logged out.
        /// </summary>
        LoggedOut = 0,
        /// <summary>
        /// Logged in.
        /// </summary>
        LoggedIn = 1,
        /// <summary>
        /// Logging in.
        /// </summary>
        LoggingIn = 2,
        /// <summary>
        /// Logging out.
        /// </summary>
        LoggingOut = 4,
        /// <summary>
        /// Login failed.
        /// </summary>
        LoginFailed = 8,
        /// <summary>
        /// Login completed.
        /// <remarks>
        /// This state is set when all login completed and all on login actions has been processed.
        /// </remarks>
        /// </summary>
        LoginCompleted = 16 | LoggedIn,
    }
    #endregion

    #region Sex
    /// <summary>
    /// Sex enumeration.
    /// </summary>
    [Flags()]
    public enum Sex : int
    {
        Unspecified = 0,
        Male = 1,
        Female = 2,
    }
    #endregion

    #region Client Event Types
    /// <summary>
    /// Enumerator for the types of client events.
    /// </summary>
    public enum ClientEventTypes : int
    {
        Login,
        Integration,
        LockState,
        Startup,
        Shutdown,
        IdChange,
        SecurityState,
        OutOfOrderState,
        Maintenance,
    }
    #endregion

    #region Context Excecution State
    /// <summary>
    /// Execution context state enumeration.
    /// </summary>
    public enum ContextExecutionState : int
    {
        /// <summary>
        /// Context is in initial state.
        /// </summary>
        Initial = 0,
        /// <summary>
        /// User profile is being acquired from server.
        /// </summary>
        GettingUserProfile,
        /// <summary>
        /// Cd image is being mounted.
        /// </summary>
        Mounting,
        /// <summary>
        /// Cd image is being unmounted.
        /// </summary>
        Unmounting,
        /// <summary>
        /// Executable has exited. This only occures when all children has exited thus executable is considered dead and finalized.
        /// </summary>
        Finalized,
        /// <summary>
        /// Executable process is started.
        /// </summary>
        Starting,
        /// <summary>
        /// Executable process is started and running.
        /// </summary>
        Started,
        /// <summary>
        /// Deployment profile is executed for the executable.
        /// </summary>
        Deploying,
        /// <summary>
        /// Execution aborted.
        /// </summary>
        Aborted,
        /// <summary>
        /// Aborting state.
        /// </summary>
        Aborting,
        /// <summary>
        /// Context failed. Executable not found.
        /// <remarks>The failed function can be determined by previous state.</remarks>
        /// </summary>
        Failed,
        /// <summary>
        /// Executable activated.
        /// </summary>
        Activated,
        /// <summary>
        /// Process window being activated.
        /// </summary>
        Activating,
        /// <summary>
        /// Checking available space.
        /// </summary>
        ChekingAvailableSpace,
        /// <summary>
        /// Making space.
        /// </summary>
        MakingSpace,
        /// <summary>
        /// Allocating free space.
        /// </summary>
        AllocatingSpace,
        /// <summary>
        /// Importing registry.
        /// </summary>
        ImportingRegistry,
        /// <summary>
        /// Comparing.
        /// </summary>
        Validating,
        /// <summary>
        /// Completed state.
        /// </summary>
        Completed,
        /// <summary>
        /// Destroyed.
        /// </summary>
        Destroyed,
        /// <summary>
        /// Context is released.
        /// </summary>
        Released,
        /// <summary>
        /// Execution processing has bein initiated.
        /// </summary>
        Processing,
        /// <summary>
        /// Execuntion processing reinitiated.
        /// </summary>
        Reprocessing,
        /// <summary>
        /// License reservation state.
        /// </summary>
        ReservingLicense,
        /// <summary>
        /// License released state.
        /// </summary>
        ReleasedLicense,
        /// <summary>
        /// License installation state.
        /// </summary>
        InstallingLicense,
        /// <summary>
        /// Occours when process is created in this context.
        /// </summary>
        ProcessCreated,
        /// <summary>
        /// Occours when process of this context has exited.
        /// </summary>
        ProcessExited,
        /// <summary>
        /// Occours when task of this context being executed.
        /// </summary>
        ExecutingTask,
    }
    #endregion

    #region ContextExecutionViewState
    public enum ContextExecutionViewState : int
    {
        Initial = 0,
        Working = 1,
        Ready = 2,
    }
    #endregion

    #region Schemes
    [Serializable()]
    public enum Schemes : int
    {
        Unknown = 0,
        Http = 1,
        Ftp = 2,
        Https = 3,
        LocalFile = 4,
        RemoteFile = 5,
        Cftp = 6,
        Sftp = 7,
        File = 8,
    }
    #endregion

    #region Personal User Files

    public enum PufDeployStatus
    {
        Idle = 0,
        Compressing = 1,
        Stroing = 2,
        Extracting = 3,
    }

    public enum PufActionType
    {
        Load = 1,
        Store = 0,
    }

    /// <summary>
    /// Personal user file types.
    /// </summary>
    public enum PersonalUserFileType : uint
    {
        /// <summary>
        /// File or directory.
        /// </summary>
        File = 0,
        /// <summary>
        /// Registry.
        /// </summary>
        Registry = 1,
    }

    #endregion

    #region LogoutAction
    public enum LogoutAction : int
    {
        NoAction = -1,
        Reboot = 0,
        ClosePrograms = 1,
        TurnOff = 2,
        LogOff = 3,
        StandBy = 4,
        AdminMode = 5,
    }
    #endregion

    #region UserInfoTypes
    /// <summary>
    /// User personal information types.
    /// </summary>
    [Flags()]
    public enum UserInfoTypes : int
    {
        /// <summary>
        /// No information.
        /// </summary>
        None = 0,
        /// <summary>
        /// First Name.
        /// </summary>
        FirstName = 1,
        /// <summary>
        /// Last Name.
        /// </summary>
        LastName = 2,
        /// <summary>
        /// Birth date.
        /// </summary>
        BirthDate = 4,
        /// <summary>
        /// Email Address.
        /// </summary>
        Email = 256,
        /// <summary>
        /// Address.
        /// </summary>
        Address = 8,
        /// <summary>
        /// Landline Phone Number.
        /// </summary>
        Phone = 512,
        /// <summary>
        /// Mobile Phone Number.
        /// </summary>
        Mobile = 1024,
        /// <summary>
        /// Postal Code. Zip for United States.
        /// </summary>
        PostCode = 32,
        /// <summary>
        /// City.
        /// </summary>            
        City = 16,
        /// <summary>
        /// State.
        /// </summary>
        State = 64,
        /// <summary>
        /// Country.
        /// </summary>
        Country = 128,
        /// <summary>
        /// Users password.
        /// </summary>
        Password = 4096,
        /// <summary>
        /// Users sex.
        /// </summary>
        Sex = 2048,
        /// <summary>
        /// User Name.
        /// </summary>
        UserName = 8192,
        /// <summary>
        /// All user information.
        /// </summary>
        UserInformation = UserInfoTypes.Address |
            UserInfoTypes.City |
            UserInfoTypes.Email |
            UserInfoTypes.Email |
            UserInfoTypes.FirstName |
            UserInfoTypes.LastName |
            UserInfoTypes.Mobile |
            UserInfoTypes.Phone |
            UserInfoTypes.PostCode |
            UserInfoTypes.Sex,
    }
    #endregion

    #region View Models Enumerations

    public enum ManagementTypesEnum
    {
        Tasking = 0,
        Registry = 1,
        FileSystem = 2,
        Processes = 3,
        Information = 4,
    }

    public enum ManagerViewTypes
    {
        Management = 0,
        Screens = 1,
        Log = 2,
        Deployment = 3,
        Settings = 4,
        Applications = 5,
        Users = 6,
        NewsCenter = 7,
        Statistics = 8,
    }

    public enum StartPageViewTypes : int
    {
        Home = 0,
        Applications = 1,
        Favorites = 2,
        ControlPanel = 3,
        Media = 4,
        GameServers = 5,
    }

    #endregion

    #region LoginUserActivity
    /// <summary>
    /// Represents client activity during user login or logout.
    /// </summary>
    public enum LoginUserActivity
    {
        None = 0,
        SettingPersonalUserFile = 1,
        DeletingUserStorage = 2,
        TerminatingUserProcesses = 3,
    }
    #endregion

    #region MediaType
    [Flags()]
    public enum MediaType
    {
        /// <summary>
        /// Media type unknown.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Media type video.
        /// </summary>
        Video = 1,
        /// <summary>
        /// Media type audio.
        /// </summary>
        Audio = 2,
        /// <summary>
        /// Media type image.
        /// </summary>
        Image = 4,
    }
    #endregion

    #region NotificationButtons
    public enum NotificationButtons
    {
        None = 0,
        Ok = 1,
        Yes = 2,
        No = 3,
        Cancel = 4,
    }
    #endregion

    #region AgeRatingType
    public enum AgeRatingType : byte
    {
        [Description("None")]
        None = 0,
        [Description("Manual")]
        Manual = 1,
        [Description("ESRB")]
        ESRB = 2,
        [Description("PEGI")]
        PEGI = 3,
    }
    #endregion

    #region PEGI
    public enum PEGI : int
    {
        [Description("Three (3)")]
        [AgeRating(3)]
        Three = -1,
        [AgeRating(4)]
        [Description("Four (4)")]
        Four = -2,
        [AgeRating(6)]
        [Description("Six (6)")]
        Six = -3,
        [AgeRating(7)]
        [Description("Seven (7)")]
        Seven = -4,
        [AgeRating(12)]
        [Description("Twelve (12)")]
        Twelve = -5,
        [Description("Sixteen (16)")]
        [AgeRating(16)]
        Sixteen = -6,
        [Description("Eighteen (18)")]
        [AgeRating(18)]
        Eighteen = -7,
    }
    #endregion

    #region ESRB
    public enum ESRB : int
    {
        [Description("Early Childhood (EC)")]
        [AgeRating(3)]
        EarlyChildHood = -21,
        [Description("Everyone (E)")]
        [AgeRating(6)]
        EveryOne = -22,
        [Description("Everyone 10+ (E10+)")]
        [AgeRating(10)]
        EveryOneTenPlus = -23,
        [Description("Teen (T)")]
        [AgeRating(13)]
        Teen = -24,
        [Description("Mature (M)")]
        [AgeRating(17)]
        Matrue = -25,
        [Description("Adults Only (AO)")]
        [AgeRating(18)]
        AdaultsOnly = -26,
        [Description("Rating Pending (RP)")]
        [AgeRating(0)]
        RatingPending = -27,
        [Description("Kids to Adults (K-A)")]
        [AgeRating(6)]
        KidsToAdaults = -28,
    }
    #endregion

    #region DurationRange
    public enum DurationRange
    {
        Today = 0,
        Weeek = 1,
        Month = 2,
        Year = 3,
        Decade = 4,
        Unlimited = 5,
    }
    #endregion

    #region FilterResultDirection
    public enum FilterResultDirection
    {
        Top,
        Bottom,
    }
    #endregion

    #region HostState
    public enum HostState : sbyte
    {
        InOrder = 0,
        OutOfOrder = 1,
    }
    #endregion

    #region GroupOvverides
    /// <summary>
    /// Computer group configuration overrides.
    /// </summary>
    [Flags()]
    public enum GroupOverrides : int
    {
        None = 0,
        Applications = 1,
        Security = 2,
    }
    #endregion

    #region StartupModuleActivity
    /// <summary>
    /// Shared Module activity enumeration.
    /// </summary>
    public enum StartupModuleActivity
    {
        [Localized("EN_SMA_AUTHORIZNG_LICENSE")]
        AuthorizingLicense,
        [Localized("EN_SMA_INITIALIZING_DATA")]
        InitializingData,
        [Localized("EN_SMA_STARTING_TRAY_SERVICES")]
        StartingTrayServices,
        [Localized("EN_SMA_STARTING_NETWORK_SERVICES")]
        StartingNetworkServices,
        [Localized("EN_SMA_STARTING_UI")]
        StartingUi,
        [Localized("EN_SMA_STARTING_INTEGRATION")]
        StartingIntegration,
        [Localized("EN_SMA_STARTING_SHELL")]
        StartingShell,
        [Localized("EN_SMA_INITIATING_CONNECTION")]
        InitiatingConnection,
        [Localized("EN_SMA_INSTALLING_DRIVER")]
        InstallingSystemDriver,
        [Localized("EN_SMA_UNINSTALLING_DRIVER")]
        UninstallingSystemDriver,
        [Localized("EN_SMA_CHECKING_DRIVER")]
        CheckingSystemDriver,
        [Localized("EN_SMA_SETTING_USER_PROFILE")]
        SettingPersonalUserFiles,
        [Localized("EN_SMA_CREATING_STORAGE")]
        CreatingUserStorage,
        [Localized("EN_SMA_DESTROYING_STORAGE")]
        DestroyingUserStorage,
        [Localized("EN_SMA_PROCESSING_TASKS")]
        ProcessingTasks,
        [Localized("EN_SMA_DESTROYING_CONTEXTS")]
        DestroyingUserContexts,
        [Localized("EN_SMA_EXECUTING_LOGOUT_ACTION")]
        ExecutingLogoutAction,
        [Localized("EN_SMA_TERMINATING_USER_PROCESSES")]
        TerminatingUserProcesses,
        [Localized("EN_SMA_INITIALIZING_PLUGINS")]
        InitializingPlugins,
        [Localized("EN_SMA_LOADING_PLUGINS")]
        LoadingPlugins,
        [Localized("EN_SMA_CONFIGURING_FIREWALL")]
        ConfiguringFirewall,
        [Localized("EN_SMA_PARSING_ARGUMENTS")]
        ParsingArguments,
        [Localized("EN_SMA_EXPANDING_VARIABLES")]
        ExpandingVariables,
        RefreshingFileShares,
        [Localized("EN_SMA_STARTING_API_SERVER")]
        StartingAPIServer,
    }
    #endregion

    #region LicenseStatus
    /// <summary>
    /// License status enumeration.
    /// </summary>
    public enum LicenseStatus : int
    {
        /// <summary>
        /// License key is free for use.
        /// </summary>
        Unused,
        /// <summary>
        /// License key is reserved.
        /// </summary>
        Reserved,
    }
    #endregion

    #region EventTypes
    /// <summary>
    /// Event Log types representation.
    /// </summary>
    [Flags()]
    [Serializable()]
    public enum EventTypes : int
    {
        Information = 1,
        Warning = 2,
        Error = 4,
        Event = 8,
        All = Information | Warning | Error | Event
    }
    #endregion

    #region LogCategories
    [Flags()]
    [Serializable()]
    public enum LogCategories : int
    {
        None=0,
        Generic = 1,
        Network = 2,
        Database = 4,
        FileSystem = 8,
        Task = 16,
        Dispatcher = 32,
        Command = 64,
        Operation = 128,
        UserInterface = 256,
        Configuration = 512,
        Subscription = 1024,
        Trace = 2048,
        User = 4096,
        All = Generic | Network | Database | FileSystem | Task | Dispatcher | Command | Operation | UserInterface | Configuration | Subscription | Trace | User
    }
    #endregion

    #region ModuleEnum
    [Flags()]
    [Serializable()]
    public enum ModuleEnum
    {
        Unknown = 0,
        Manager = 1,
        Client = 2,
        Service = 4,
        Any = Manager | Client | Service,
    }
    #endregion

    #region TaskType
    [Serializable()]
    public enum TaskType
    {
        [Description("Process")]
        Process,
        [Description("Script")]
        Script,
        [Description("File System")]
        FileSystem,
        [Description("Task Chain")]
        Chain,
        [Description("Notification")]
        Notification,
        [Description("Junction")]
        Junction,
        [Description("All Types")]
        AllTypes = 65535,

    }
    #endregion

    #region DialogType
    /// <summary>
    /// Dialogue types.
    /// <remarks>
    /// This is generaly used in view models to mark the current dialogue type.
    /// </remarks>
    /// </summary>
    [Serializable()]
    public enum DialogType : int
    {
        None = 0,
        Add = 1,
        Edit = 2,
    }
    #endregion

    #region ClipBoardAction
    /// <summary>
    /// Clipboard actions enumeration.
    /// </summary>
    public enum ClipBoardAction
    {
        Cut,
        Copy,
        Paste,
    }
    #endregion

    #region ActionState
    /// <summary>
    /// Basic enumeration for actions or operations.
    /// </summary>
    public enum ActionState
    {
        Inactive,
        Comparing,
        Deploying,
        Aborted,
        Failed,
        Compared,
        Aborting,
    }
    #endregion

    #region IPVersion
    public enum IPVersion : short
    {
        IPV4 = 0,
        IPV6 = 1,
    }
    #endregion

    #region DriverType
    /// <summary>
    /// System Driver type enumeration.
    /// </summary>
    [Flags()]
    public enum DriverType : sbyte
    {
        /// <summary>
        /// Default value.
        /// </summary>
        None = 0,
        /// <summary>
        /// CallBack Filter.
        /// </summary>
        CallBackFilter = 1,
        /// <summary>
        /// CallBack File System.
        /// </summary>
        CallBackFileSystem = 2,
        /// <summary>
        /// Raw Disk.
        /// </summary>
        RawDisk = 3,
        /// <summary>
        /// Keyboard Driver.
        /// </summary>
        Keyboard = 4,
        /// <summary>
        /// All driver type value.
        /// </summary>
        All = DriverType.CallBackFileSystem | DriverType.CallBackFilter | DriverType.Keyboard | DriverType.RawDisk,
    }
    #endregion

    #region HostEventType
    public enum HostEventType
    {
        /// <summary>
        /// Host was connected.
        /// </summary>
        Connected,
        /// <summary>
        /// Host was initialized.
        /// </summary>
        Initialized,
        /// <summary>
        /// Host was disconnected.
        /// </summary>
        Disconnected,
        /// <summary>
        /// Host was added.
        /// </summary>
        Added,
        /// <summary>
        /// Host was removed.
        /// </summary>
        Removed,
    }
    #endregion

    #region FreeSpaceAllocations
    public enum FreeSpaceAllocations : byte
    {
        Zero = 0,
        Five = 5,
        Ten = 10,
        FifTeen = 15,
        Twenty = 20,
        TwentyFive = 25,
        Thirty = 30,
    }
    #endregion

    #region UserRoles
    [Flags()]
    public enum UserRoles
    {
        /// <summary>
        /// No role.
        /// </summary>
        [RoleAssignable(false)]
        None = 0,
        /// <summary>
        /// Simple user.
        /// </summary>
        [RoleAssignable(true)]
        User = 1,
        /// <summary>
        /// Guest user role.
        /// </summary>
        [RoleAssignable(false)]
        Guest = 2,
        /// <summary>
        /// Operator.
        /// </summary>
        [RoleAssignable(false)]
        Operator = 4
    }
    #endregion

    #region ImageType
    public enum ImageType
    {
        Application,
        Executable,
        VisualOptions,
    }
    #endregion

    #region UserChangeType
    public enum UserChangeType
    {
        /// <summary>
        /// New user added.
        /// </summary>
        Added,
        /// <summary>
        /// Existing user removed.
        /// </summary>
        Removed,
        /// <summary>
        /// Existing user updated.
        /// </summary>
        Updated,
        /// <summary>
        /// Existing user password changed.
        /// </summary>
        Password,
        /// <summary>
        /// Exisitng user email changed.
        /// </summary>
        Email,
        /// <summary>
        /// Existing user username changed.
        /// </summary>
        UserName,
        /// <summary>
        /// Exisitng user group changed.
        /// </summary>
        UserGroup,
        /// <summary>
        /// Exisitng user role changed.
        /// </summary>
        Role,
        /// <summary>
        /// Existing user enabled changed.
        /// </summary>
        Enabled,
    }
    #endregion

    #region DeployOptionType
    [Flags()]
    public enum DeployOptionType : int
    {
        /// <summary>
        /// Defailt option.
        /// </summary>
        None = 0,
        /// <summary>
        /// Marks deployment as ignored from cleanup procedures.
        /// </summary>
        IgnoreCleanup = 1,
        /// <summary>
        /// Indicates that deployment should be done only on repair procedures.
        /// </summary>
        RepairOnly = 2,
        /// <summary>
        /// Indicates direct access to the deployment source.
        /// </summary>
        DirectAccess = 4,
        /// <summary>
        /// Indicates mirroring of destination directory.
        /// </summary>
        Mirror=8,
        /// <summary>
        /// Indicates inclusion of sub directories.
        /// </summary>
        IncludeSubDirectories=16,
    }
    #endregion

    #region UserSessionState
    [Flags(),Serializable()]
    public enum SessionState : int
    {
        /// <summary>
        /// Session initialized.
        /// </summary>
        None = 0,
        /// <summary>
        /// Session is active.
        /// </summary>
        Active = 1,
        /// <summary>
        /// Session ended.
        /// </summary>
        Ended = 2,
        /// <summary>
        /// Session pending termination.
        /// </summary>
        Pending = 4 | Active,
        /// <summary>
        /// Sesstion paused and pending activation.
        /// </summary>
        Paused = 8 | Active,
    } 
    #endregion

    #region ActionSource
    public enum ActionSource
    {
        /// <summary>
        /// Function called by user.
        /// </summary>
        User = 0,
        /// <summary>
        /// Function called by operator.
        /// </summary>
        Operator = 1,
        /// <summary>
        /// Function called on host connect.
        /// </summary>
        Connect = 2,
        /// <summary>
        /// Function called on host disconnect.
        /// </summary>
        Disconnect = 3,
        /// <summary>
        /// Function called by session mechanism.
        /// </summary>
        Session = 4,
    }
    #endregion
}
