namespace TestTask.WebUI.Models
{
    /// <summary>
    /// View model for error
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Request identificator
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Show request identificator status
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
