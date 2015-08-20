namespace RestSharp
{
    /// <summary>
    /// Container for data sent back from API including deserialized data
    /// </summary>
    /// <typeparam name="T">Type of data to deserialize to</typeparam>
    public interface IRestResponse<T> : IRestResponse
    {
        /// <summary>
        /// Deserialized entity data
        /// </summary>
        T Data { get; set; }
    }
}
