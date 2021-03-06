﻿using System;
using System.Linq.Expressions;

namespace SharedLib
{
    #region RoleAssignableAttribute
    /// <summary>
    /// Role assignable attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class RoleAssignableAttribute : Attribute
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="assignable">Indicates if role is assignable.</param>
        public RoleAssignableAttribute(bool assignable)
        {
            Assignable = assignable;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets if role is assignable.
        /// </summary>
        public bool Assignable
        {
            get;
            protected set;
        }
        #endregion
    }
    #endregion

    #region CanUserAssignAttribute
    /// <summary>
    /// User assignable attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class CanUserAssignAttribute : Attribute
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="assignable">Indicates if user assignable.</param>
        public CanUserAssignAttribute(bool assignable)
        {
            Assignable = assignable;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if item can be assigned by the user.
        /// </summary>
        public bool Assignable
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion

    #region IsGameModeAttibute
    /// <summary>
    /// Game mode attribute.
    /// Used to indicate wether the application mode is game. 
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class IsGameModeAttibute : Attribute
    { }
    #endregion

    #region GUIDAttribue
    /// <summary>
    /// GUID Attribute.
    /// </summary>
    public class GUIDAttribute : Attribute
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="guid">Guid.</param>
        /// <exception cref="ArgumentNullException"> thrown if <paramref name="guid"/> is equal to null or empty string.</exception>
        public GUIDAttribute(string guid)
        {
            if (string.IsNullOrWhiteSpace(guid))
                throw new ArgumentNullException(nameof(guid));

            Guid = new Guid(guid);
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="guid">Guid instance.</param>
        public GUIDAttribute(Guid guid)
        {
            Guid = guid;
        }

        #endregion

        #region Fields
        private Guid guid;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the GUID for this attribute.
        /// </summary>
        public Guid Guid
        {
            get { return guid; }
            protected set { guid = value; }
        }
        #endregion
    }
    #endregion

    #region SpecialFolderAttribute
    /// <summary>
    /// Special folder attribute.
    /// </summary>
    public class SpecialFolderAttribute : Attribute
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        public SpecialFolderAttribute()
        {
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="specialFolderType">Special folder type.</param>
        public SpecialFolderAttribute(Environment.SpecialFolder specialFolderType)
        {
            SpecialFolder = specialFolderType;
        }

        #endregion

        #region FIELDS
        private Environment.SpecialFolder folderType = (Environment.SpecialFolder)65535;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the folder type for this attribute.
        /// </summary>
        public Environment.SpecialFolder SpecialFolder
        {
            get { return folderType; }
            protected set { folderType = value; }
        }

        #endregion
    }
    #endregion

    #region AgeAttribute
    /// <summary>
    /// Age attribute.
    /// </summary>
    public class AgeRatingAttribute : Attribute
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new age attribute.
        /// </summary>
        /// <param name="value">Age value.</param>
        public AgeRatingAttribute(uint value)
        {
            Age = value;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets attributes age value.
        /// </summary>
        public uint Age
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion

    #region PolicyAttribute
    /// <summary>
    /// Policy attribute.
    /// </summary>
    public class PolicyAttribute : Attribute
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance of the attribute.
        /// </summary>
        /// <param name="registryPath">Registry path.</param>
        /// <param name="valueName">Value name.</param>
        /// <param name="description">Description.</param>
        public PolicyAttribute(string registryPath,
            string description,
            string valueName)
        {
            #region Validation

            if (string.IsNullOrWhiteSpace(registryPath))
                throw new ArgumentException("Registry path may not be null or empty.", "RegistryPath");

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description may not be null or empty.", "Description");

            #endregion

            //registry path of restriction
            RegistryPath = registryPath;

            //if value name is emty enum value should be used
            ValueName = valueName;

            //set description
            Description = description;
        }
        #endregion

        #region FIELDS
        private Microsoft.Win32.RegistryHive hive = Microsoft.Win32.RegistryHive.CurrentUser;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets registry path of restriction attribute.
        /// </summary>
        public string RegistryPath
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets value name of security attribute.
        /// </summary>
        public string ValueName
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the restrictions description.
        /// </summary>
        public string Description
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the restrictions category string.
        /// </summary>
        public string Category
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets registry hive.
        /// </summary>
        public Microsoft.Win32.RegistryHive Hive
        {
            get { return hive; }
            protected set { hive = value; }
        }

        #endregion

        #region FUNCTIONS
        /// <summary>
        /// Converts enable flag to registry value object.
        /// </summary>
        /// <param name="enable">Enable flag.</param>
        /// <returns>Returns converted object value.</returns>
        public virtual object GetValueForAttribute(bool enable)
        {
            return enable ? 1 : 0;
        }
        #endregion
    }
    #endregion

    #region MessengerPolicyAttribute
    public class MessengerPolicyAttribute : PolicyAttribute
    {
        #region Constructor
        public MessengerPolicyAttribute(string description, string valueName = "")
            : base("Software\\Policies\\Microsoft\\Messenger\\Client", description, valueName)
        {
            Category = "MSN Messenger";
        }
        #endregion
    }
    #endregion

    #region InternetExplorerPolicyAttribute
    public class InternetExplorerPolicyAttribute : PolicyAttribute
    {
        #region Constructor
        public InternetExplorerPolicyAttribute(string description, string valueName = "")
            : base("Software\\Policies\\Microsoft\\Internet Explorer\\Restrictions", description, valueName)
        {
            Category = "Internet Explorer";
        }
        #endregion
    }
    #endregion

    #region InternetExplorerToolbarsPolicyAttribute
    public class InternetExplorerToolbarsPolicyAttribute : PolicyAttribute
    {
        #region Constructor
        public InternetExplorerToolbarsPolicyAttribute(string description, string valueName = "")
            : base("Software\\Policies\\Microsoft\\Internet Explorer\\Toolbars\\Restrictions", description, valueName)
        {
            Category = "Internet Explorer Toolbars";
        }
        #endregion
    }
    #endregion

    #region ExplorerPolicyAttribute
    public class ExplorerPolicyAttribute : PolicyAttribute
    {
        #region Constructor
        public ExplorerPolicyAttribute(string description, string valueName = "")
            : base("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", description, valueName)
        {
            Category = "Windows Explorer";
        }
        #endregion

        #region Ovverdies
        public override object GetValueForAttribute(bool enable)
        {
            var returnValue = base.GetValueForAttribute(enable);
            if (!string.IsNullOrWhiteSpace(ValueName))
            {
                switch (ValueName)
                {
                    case "NoDriveAutoRun":
                        returnValue = (int)returnValue * (int)(Math.Pow(2, 26));
                        break;
                    case "Btn_Folders":
                        returnValue = (int)returnValue * 2;
                        break;
                    default:
                        break;
                }
            }
            return returnValue;
        }
        #endregion
    }
    #endregion

    #region SystemPolicyAttribute
    /// <summary>
    /// System policy attribute.
    /// </summary>
    public class SystemPolicyAttribute : PolicyAttribute
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="description">Dscription.</param>
        /// <param name="valueName">Value name.</param>
        public SystemPolicyAttribute(string description, string valueName = "")
            : base("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", description, valueName)
        {
            Category = "System";
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="description">Dscription.</param>
        /// <param name="hive">Registry hive.</param>
        /// <param name="valueName">Value name.</param>
        public SystemPolicyAttribute(string description, Microsoft.Win32.RegistryHive hive, string valueName = "")
            : base("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", description, valueName)
        {
            Category = "System";
            Hive = hive;
        }

        #endregion
    }
    #endregion

    #region WindowsSystemPolicyAttribute
    /// <summary>
    /// Windows security policy attribute.
    /// </summary>
    public class WindowsSystemPolicyAttribute : PolicyAttribute
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="description">Dscription.</param>
        /// <param name="valueName">Value name.</param>
        public WindowsSystemPolicyAttribute(string description, string valueName = "")
            : base(@"Software\Policies\Microsoft\Windows\System", description, valueName)
        {
            Category = "System";
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="description">Dscription.</param>
        /// <param name="hive">Registry hive.</param>
        /// <param name="valueName">Value name.</param>
        public WindowsSystemPolicyAttribute(string description, Microsoft.Win32.RegistryHive hive, string valueName = "")
            : base(@"Software\Policies\Microsoft\Windows\System", description, valueName)
        {
            Category = "System";
            Hive = hive;
        }

        #endregion

        #region OVERRIDES
        public override object GetValueForAttribute(bool enable)
        {
            var returnValue = base.GetValueForAttribute(enable);
            if (!string.IsNullOrWhiteSpace(ValueName))
            {
                switch (ValueName)
                {
                    case "DisableCMD":
                        returnValue = (int)returnValue * 2;
                        break;
                    default:
                        break;
                }
            }
            return returnValue;
        }
        #endregion
    }
    #endregion

    #region NetworkPolicyAttribute
    /// <summary>
    /// Network policy attribute.
    /// </summary>
    public class NetworkPolicyAttribute : PolicyAttribute
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="description">Dscription.</param>
        /// <param name="valueName">Value name.</param>
        public NetworkPolicyAttribute(string description, string valueName = "")
            : base("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Network", description, valueName)
        {
            Category = "Network";
        }
        #endregion
    }
    #endregion

    #region CommonDialogPolicyAttribute
    /// <summary>
    /// Common dialog policy attribute.
    /// </summary>
    public class CommonDialogPolicyAttribute : PolicyAttribute
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="description">Dscription.</param>
        /// <param name="valueName">Value name.</param>
        public CommonDialogPolicyAttribute(string description, string valueName = "")
            : base("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Comdlg32", description, valueName)
        {
            Category = "Common Dialog";
        }
        #endregion
    }
    #endregion

    #region NoEnumPolicyAttribute
    /// <summary>
    /// No enumeration policy attribute.
    /// </summary>
    public class NoEnumPolicyAttribute : PolicyAttribute
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="description">Dscription.</param>
        /// <param name="valueName">Value name.</param>
        public NoEnumPolicyAttribute(string description, string valueName = "")
            : base("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\NonEnum", description, valueName)
        {
            Category = "No Enum (Pre Windows 10)";
        }
        #endregion
    }
    #endregion

    #region UsbStorPolicyAttribute
    /// <summary>
    /// USB Stor policy attribute.
    /// </summary>
    public class UsbStorPolicyAttribute : PolicyAttribute
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="description">Dscription.</param>
        /// <param name="valueName">Value name.</param>
        public UsbStorPolicyAttribute(string description, string valueName = "")
            : base("System\\CurrentControlSet\\Services\\UsbStor", description, valueName)
        {
            Hive = Microsoft.Win32.RegistryHive.LocalMachine;
            Category = "Hardware";
        }
        #endregion

        #region OVERRIDES
        /// <summary>
        /// Gets value for the attribute.
        /// </summary>
        /// <param name="enable">Enable parameter.</param>
        /// <returns>Value.</returns>
        public override object GetValueForAttribute(bool enable)
        {
            return enable ? 4 : 3;
        }
        #endregion
    }
    #endregion

    #region UninstallAttribute
    /// <summary>
    /// Uninstall policy attribute.
    /// </summary>
    public class UninstallAttribute : PolicyAttribute
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="description">Dscription.</param>
        /// <param name="valueName">Value name.</param>
        public UninstallAttribute(string description, string valueName = "")
            : base(@"Software\Microsoft\Windows\CurrentVersion\Policies\Uninstall", description, valueName)
        {
            Category = "Uninstall";
        }
        #endregion
    }
    #endregion

    #region PropertyMapAttribute
    /// <summary>
    /// Property map attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public class PropertyMapAttribute : Attribute
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        public PropertyMapAttribute(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException(nameof(propertyName));

            typeId = Guid.NewGuid();

            PropertyName = propertyName;
        }

        #endregion

        #region FILEDS
        private Guid typeId;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Property name.
        /// </summary>
        public string PropertyName
        {
            get; protected set;
        }

        #endregion

        #region OVERRIDES

        /// <summary>
        /// Gets type id.
        /// </summary>
        public override object TypeId
        {
            get
            {
                return typeId;
            }
        }

        #endregion
    }
    #endregion

    #region FilterPropertyAttribute
    /// <summary>
    /// Maps a class property to filter property name.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public class FilterPropertyAttribute : PropertyMapAttribute
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new filter property attribute.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        /// <param name="operation">Filter opertation.</param>
        public FilterPropertyAttribute(string propertyName, Op operation) : this(propertyName, operation, null, false)
        { }

        /// <summary>
        /// Creates new filter property attribute.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        /// <param name="operation">Filter opertation.</param>
        /// <param name="groupName">Filter group name.</param>
        /// <param name="includedOnNull">Indicates if filter should be included on null values.</param>
        public FilterPropertyAttribute(string propertyName, Op operation, string groupName, bool includedOnNull) : this(propertyName, operation, groupName, includedOnNull, false)
        {
        }

        /// <summary>
        /// Creates new filter property attribute.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        /// <param name="operation">Filter opertation.</param>
        /// <param name="groupName">Filter group name.</param>
        /// <param name="includedOnNull">Indicates if filter should be included on null values.</param>
        /// <param name="ignore">Indicates if property should be ignored when calling get filters function.</param>
        public FilterPropertyAttribute(string propertyName, Op operation, string groupName, bool includedOnNull, bool ignore) : base(propertyName)
        {
            Operation = operation;
            GroupName = groupName;
            IncludeOnNullValue = includedOnNull;
            Ignore = ignore;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if filter should be included if filter value equals to null.
        /// </summary>
        public bool IncludeOnNullValue
        {
            get; protected set;
        }

        /// <summary>
        /// Gets filtering operation.
        /// </summary>
        public Op Operation
        {
            get; protected set;
        }

        /// <summary>
        /// Filter group name.
        /// </summary>
        public string GroupName
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets if property should be ignored when calling get filters function.
        /// </summary>
        public bool Ignore
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion
}
