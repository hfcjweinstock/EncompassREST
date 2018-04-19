using System.ComponentModel;
using System.Runtime.Serialization;

namespace EncompassRest.Loans.Enums
{
    /// <summary>
    /// PartialPrepaymentsElection
    /// </summary>
    public enum PartialPrepaymentsElection
    {
        /// <summary>
        /// amount
        /// </summary>
        [Description("amount")]
        Amount = 0,
        /// <summary>
        /// number
        /// </summary>
        [Description("number")]
        Number = 1
    }
}