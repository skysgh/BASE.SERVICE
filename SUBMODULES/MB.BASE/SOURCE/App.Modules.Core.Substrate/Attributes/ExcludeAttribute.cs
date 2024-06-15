using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Base.Shared.Attributes
{

    /// <summary>
    /// Attribute to exclude something from being processed
    /// (ie, ignored)
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.All, Inherited = true, AllowMultiple = true)]
    public class ExcludeAttribute : Attribute
    {
        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly string _reason;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reason"></param>
        /// <exception cref="NotImplementedException"></exception>
        public ExcludeAttribute(string reason)
        {
            _reason = reason;

        }

        /// <summary>
        /// Reason Item is being excluded from processing.
        /// </summary>
        public string Reason
        {
            get { return _reason; }
        }
    }
}