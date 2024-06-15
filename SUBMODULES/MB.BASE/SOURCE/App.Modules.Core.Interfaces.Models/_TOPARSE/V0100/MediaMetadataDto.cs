using App.Base.Shared.Models;

namespace App.Modules.Core.Interface.Models._TOPARSE.V0100
{
    using System;
    using App.Base.Shared.Models.Entities;
    using App.Base.Shared.Models.Entities.TenancySpecific;

    /// <summary>
    /// API DTO for system 
    /// <see cref="MediaMetadata"/>
    /// </summary>
    public class MediaMetadataDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId, IHasTenantFK //, IHasRecordState
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MediaMetadataDto()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// The Record Id
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// The tenancy to which this media is constrained.
        /// </summary>
        public virtual Guid TenantFK { get; set; }

        /// <summary>
        /// DataClassification of the upload
        /// <para>
        /// Use an Enum as DataClassification is shared across Bounded DbContexts
        /// </para>
        /// </summary>
        public virtual DataClassification? DataClassification { get; set; }

        /// <summary>
        /// Date at which uploaded
        /// </summary>
        public virtual DateTime UploadedDateTimeUtc { get; set; }

        /// <summary>
        /// Size of Media stream
        /// </summary>
        public virtual long ContentSize { get; set; } /*size of stream*/

        /// <summary>
        /// The extension is not always a correct indicator...
        /// </summary>
        public virtual string? MimeType { get; set; } /**/

        /// <summary>
        /// the name the file had on the uploader's machine
        /// </summary>
        public virtual string? SourceFileName { get; set; } /**/

        /// <summary>
        /// unique hash of the stream for faster reference later
        /// </summary>
        public virtual string? ContentHash { get; set; } /**/

        /// <summary>
        /// name in storage container
        /// </summary>
        public virtual string? LocalName { get; set; } /**/
        // Results of scanning, whenever done:
        /// <summary>
        /// When the media was last scanned.
        /// Should be periodic as malware detection does evolve.
        /// </summary>
        public virtual DateTime? LatestScanDateTimeUtc { get; set; } /*can be scanned regularly*/

        /// <summary>
        /// Whether the last periodic scan was successful or not.
        /// </summary>
        public virtual bool? LatestScanMalwareDetetected { get; set; }
        /// <summary>
        /// Results of the last non successful scan
        /// </summary>
        public virtual string? LatestScanResults { get; set; }
    }
}