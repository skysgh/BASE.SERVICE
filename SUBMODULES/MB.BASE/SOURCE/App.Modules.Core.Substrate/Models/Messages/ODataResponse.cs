namespace App.Base.Shared.Models.Messages
{
    using System.Collections.Generic;

    /// <summary>
    /// TODO: Describe
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ODataResponse<T>
    {
        /// <summary>
        /// The value of the response
        /// </summary>
        public List<T>? Value { get; set; }
    }
}