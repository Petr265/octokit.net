using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace Octokit
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class DeploymentStatus
    {
        /// <summary>
        /// Id of this deployment status.
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// The API URL for this deployment status.
        /// </summary>
        public string Url { get; protected set; }

        /// <summary>
        /// The state of this deployment status.
        /// </summary>
        public DeploymentState State { get; protected set; }

        /// <summary>
        /// The <seealso cref="User"/> that created this deployment status.
        /// </summary>
        public User Creator { get; protected set; }

        /// <summary>
        /// JSON payload with extra information about the deployment.
        /// </summary>
        public IReadOnlyDictionary<string, string> Payload { get; protected set; }

        /// <summary>
        /// The target URL of this deployment status. This URL should contain
        /// output to keep the user updated while the task is running or serve
        /// as historical information for what happened in the deployment
        /// </summary>
        public string TargetUrl { get; protected set; }

        /// <summary>
        /// The date and time that the status was created.
        /// </summary>
        public DateTimeOffset CreatedAt { get; protected set; }

        /// <summary>
        /// The date and time that the status was updated.
        /// </summary>
        public DateTimeOffset UpdatedAt { get; protected set; }

        /// <summary>
        /// A short description of the status.
        /// </summary>
        public string Description { get; set; }

        internal string DebuggerDisplay
        {
            get
            {
                return String.Format(CultureInfo.InvariantCulture, "State: {0} UpdatedAt: {1}", State, UpdatedAt);
            }
        }
    }

    public enum DeploymentState
    {
        Pending,
        Success,
        Error,
        Failure
    }
}