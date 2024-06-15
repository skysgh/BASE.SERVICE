using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Base.Shared.Models.Messages
{
    using System.Security.Claims;

    /// <summary>
    /// TODO: Describe
    /// </summary>
    public class AuthenticationSuccessMessage
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="identity"></param>
        public AuthenticationSuccessMessage(string userId, ClaimsIdentity identity) {
            UserId = userId;
            Identity= identity;
        }
        /// <summary>
        /// TODO: Describe
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The Identity created from the claims, but not
        /// yet set on the thread.
        /// </summary>
        public ClaimsIdentity Identity { get; set; }
    }


    /// <summary>
    /// TODO: Describe
    /// </summary>
    public class AuthorizationCodeReceivedMessage
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="signedInUserNameIdentifier"></param>
        public AuthorizationCodeReceivedMessage(string name, string signedInUserNameIdentifier)
        {
            Name = name;
            SignedInUserNameIdentifier = signedInUserNameIdentifier;
        }

        /// <summary>
        /// TODO: Describe
        /// </summary>
        public string? Name { get; set; }


        /// <summary>
        /// The NameIdentifier of the Identity built from the returned IdP Credentials
        /// But not yet turned into an Thread Identity (certainly not yet turned into
        /// a BearerToken or older style cookie.
        /// </summary>
        public string? SignedInUserNameIdentifier { get; set; }
    }

    /// <summary>
    /// TODO: Describe
    /// </summary>
    public class AuthenticationErrorMessage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <param name="errorDescription"></param>
        /// <param name="errorUri"></param>
        public AuthenticationErrorMessage(string error, string errorDescription, string errorUri)
        {
            Error = error;
            ErrorDescription = errorDescription;
            ErrorUri = errorUri;
        }

        /// <summary>
        /// TODO: Describe
        /// </summary>
        public string Error { get; set; }
        /// <summary>
        /// TODO: Describe
        /// </summary>
        public string ErrorDescription { get; set; }
        /// <summary>
        /// TODO: Describe
        /// </summary>
        public string ErrorUri { get; set; }
    }

}
