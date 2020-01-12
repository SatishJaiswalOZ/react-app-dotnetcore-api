using System.Collections.Generic;

namespace dotnet_code_challenge
{
    public interface IProvider
    {
        /// <summary>
        /// Provide collection of Horse type extracting from provided input supported files.
        /// Internally it uses the ExtractEngines.
        /// </summary>
        /// <param name="source"></param>
        /// <returns>IEnumerable<Horse></returns>
        IEnumerable<Horse> Provide(string source);
    }
}
