﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Base.Shared.Models.Messages
{
    using System.IO;

    /// <summary>
    /// A model to summarize what has been uploaded by an end user.
    /// Not persistable (see MediaMetadata).
    /// </summary>
    public class UploadedMedia
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public UploadedMedia()
        {
            Length = 0;
            Stream = null;
            ContentType = String.Empty;
            FileName = String.Empty;

        }
        /// <summary>
        /// The number of bytes in the media stream
        /// </summary>
        public long Length { get; set; }
        /// <summary>
        /// The byte stream itself
        /// </summary>
        public byte[]? Stream { get; set; }
        /// <summary>
        /// The MIME content type of the stream
        /// </summary>
        public string ContentType { get; set; }
        /// <summary>
        /// The source given filename.
        /// <para>
        /// TODO: a stream may have multiple names...
        /// </para>
        /// </summary>
        public string FileName { get; set; }
    }
}
