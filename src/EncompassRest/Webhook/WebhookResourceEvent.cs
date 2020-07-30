﻿using System.Runtime.Serialization;

namespace EncompassRest.Webhook
{
    /// <summary>
    /// WebhookResourceEvent
    /// </summary>
    public enum WebhookResourceEvent
    {
        /// <summary>
        /// create
        /// </summary>
        [EnumMember(Value = "create")]
        Create = 0,
        /// <summary>
        /// update
        /// </summary>
        [EnumMember(Value = "update")]
        Update = 1,
        /// <summary>
        /// submit
        /// </summary>
        [EnumMember(Value = "submit")]
        Submit = 2,
        /// <summary>
        /// change
        /// </summary>
        [EnumMember(Value = "change")]
        Change = 3,
        /// <summary>
        /// move
        /// </summary>
        [EnumMember(Value = "move")]
        Move = 4,
        /// <summary>
        /// delete
        /// </summary>
        [EnumMember(Value = "delete")]
        Delete = 5,
        /// <summary>
        /// document
        /// </summary>
        [EnumMember(Value = "document")]
        Document = 6,
        /// <summary>
        /// attachment
        /// </summary>
        [EnumMember(Value = "attachment")]
        Attachment = 7,
        /// <summary>
        /// condition
        /// </summary>
        [EnumMember(Value = "condition")]
        Condition = 8,
        /// <summary>
        /// reportingdbupdate
        /// </summary>
        [EnumMember(Value = "reportingdbupdate")]
        ReportingDBUpdate = 9,
        /// <summary>
        /// milestone
        /// </summary>
        [EnumMember(Value = "milestone")]
        Milestone = 10,
        /// <summary>
        /// publish
        /// </summary>
        [EnumMember(Value = "publish")]
        Publish = 11,
        /// <summary>
        /// loanassignmentcomplete
        /// </summary>
        [EnumMember(Value = "loanassignmentcomplete")]
        LoanAssignmentComplete = 12
    }
}