using System;
using System.Collections.Generic;
using System.Linq;

namespace dotnet_code_challenge
{
    public class ExtractProvider : IProvider
    {
        private readonly IEnumerable<IExtractEngine> extractEngine;

        public ExtractProvider(IEnumerable<IExtractEngine> extractEngine)
        {
            //Dependency Injection
            this.extractEngine = extractEngine;
        }

        public IEnumerable<Horse> Provide(string fileWithFullPath)
        {
            //Strategy pattern
            IExtractEngine supportedExtractEngine = extractEngine.FirstOrDefault(x => x.EngineSupported(fileWithFullPath));

            if (supportedExtractEngine == null)
            {
                throw new Exception();
            }
            return supportedExtractEngine.Extract(fileWithFullPath).Races.SelectMany(x => x.Horses).OrderBy(x => x.Price);
        }
    }
}
