using System;

namespace App.Base.Shared.Attributes
{
    /// <summary>
    /// Attribute to uniquely Key Types
    /// </summary>
    public class KeyAttribute : Attribute
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="key"></param>
        public KeyAttribute(string key)
        {
            this.Key = key;
        }

        /// <summary>
        /// The unique key.
        /// </summary>
        public string Key { get; set; }

    }
}
