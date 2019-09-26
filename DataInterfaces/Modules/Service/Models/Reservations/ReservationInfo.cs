﻿using ProtoBuf;
using SharedLib;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Reservation info.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class ReservationInfo
    {
        #region FIELDS
        IEnumerable<ReservationUserInfo> users;
        IEnumerable<ReservationHostInfo> hosts;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets reservation id.
        /// </summary>
        [ProtoMember(1)]
        [DataMember()]
        public int Id
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets reserving user id.
        /// </summary>
        [ProtoMember(2)]
        [DataMember(EmitDefaultValue = false)]
        public int? UserId
        {
            get; set;
        }

        [DataMember(EmitDefaultValue = false)]
        [ProtoMember(3)]
        public string Note
        {
            get; set;
        }

        [DataMember(EmitDefaultValue = false)]
        [ProtoMember(4)]
        public int Duration
        {
            get; set;
        }

        [DataMember(EmitDefaultValue = false)]
        [ProtoMember(5)]
        public string ContactPhone
        {
            get; set;
        }

        [DataMember(EmitDefaultValue = false)]
        [ProtoMember(6)]
        public string ContactEmail
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(7)]
        public DateTime Date
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(8)]
        public string Pin
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(9)]
        public ReservationStatus Status
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(10)]
        public DateTime EndDate
        {
            get { return Date.AddMinutes(Duration); }
        }

        /// <summary>
        /// Gets reservation user info.
        /// </summary>
        [ProtoMember(500)]
        [DataMember(EmitDefaultValue = false)]
        public IEnumerable<ReservationUserInfo> Users
        {
            get
            {
                if (users == null)
                    users = new List<ReservationUserInfo>();
                return users;
            }
            set
            {
                users = value;
            }
        }

        /// <summary>
        /// Gets or sets reserved host info.
        /// </summary>
        [ProtoMember(500)]
        [DataMember(EmitDefaultValue = false)]
        public IEnumerable<ReservationHostInfo> Hosts
        {
            get
            {
                if (hosts == null)
                    hosts = new List<ReservationHostInfo>();
                return hosts;
            }
            set
            {
                hosts = value;
            }
        }
        #endregion
    }
}