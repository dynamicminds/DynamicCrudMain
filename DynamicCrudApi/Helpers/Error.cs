namespace DynamicCrud.Api.Helpers
{
    /// <summary>
    /// Error Class
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Gets or Sets ErrorField
        /// </summary>
        public string? ErrorField { get; set; }

        /// <summary>
        /// Gets or Sets ErrorDescription
        /// </summary>
        public string? ErrorDescription { get; set; }

        /// <summary>
        /// Gets or Sets StatusCode
        /// </summary>
        public decimal StatusCode { get; set; }
    }
}
