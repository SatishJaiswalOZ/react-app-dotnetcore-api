using NLog;
using System.Collections.Generic;

namespace dotnet_code_challenge
{
    static class SimpleInjectorIOC
    {
        // Below services can be injected in any system via Simple Injector IOC or similar tools/API and remain Singleton & further serves as Dependency Injections
        // This is a temporary placeholder
        internal static readonly Logger Logger = LogManager.GetLogger("fileLogger");
        internal static readonly IProvider Provider = new ExtractProvider(new List<IExtractEngine> { new ExtractEngineJSON(), new ExtractEngineXML() });
    }
}
