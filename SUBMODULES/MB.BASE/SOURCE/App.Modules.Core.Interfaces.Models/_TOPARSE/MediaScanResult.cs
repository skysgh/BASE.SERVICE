namespace App.Base.Shared.Models.Messages
{
    /// <summary>
    /// Model of the response from a malware check.
    /// </summary>
    public class MediaMalwareScanResult
    {
        /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="malewareDetectedFlag"></param>
    /// <param name="malwareScanResults"></param>
        public MediaMalwareScanResult(bool malewareDetectedFlag, string malwareScanResults)
        {
            LatestScanMalwareDetected = malewareDetectedFlag;
            LatestScanResults = malwareScanResults;
        }
        /// <summary>
        /// 
        /// </summary>
    public bool LatestScanMalwareDetected { get; set; }
        /// <summary>
        /// 
        /// </summary>
    public string LatestScanResults { get; set; }
    }
}