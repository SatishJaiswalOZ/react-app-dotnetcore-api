namespace dotnet_code_challenge
{
    public interface IExtractEngine
    {
        /// <summary>
        /// Perform file extraction
        /// </summary>
        /// <param name="fileWithFullPath"></param>
        /// <returns>Type Metting</returns>
        Meeting Extract(string fileWithFullPath);

        /// <summary>
        /// Checks whether provided file is supported or not. 
        /// File check can be much advance to verify various ways to confirm if the file content is actually as per extension name i.e. MIME Type
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>Confirms if supported.</returns>
        bool EngineSupported(string fileName);
    }
}
