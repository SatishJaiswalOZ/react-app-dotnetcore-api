using System.Linq;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class ExtractEngineTest
    {
        [Fact]
        public void ExtractHorsesFromJsonFilePositive()
        {
            var extractJSON = new ExtractEngineJSON();
            string path = "TestData/Wolferhampton_Race.json";
            var horses = extractJSON.Extract(path);
            Assert.NotNull(horses);
            Assert.True(horses.Races.Count() > 0);
        }

        [Fact]
        public void ExtractHorsesFromXmlFilePositive()
        {
            var extractJSON = new ExtractEngineXML();
            string path = "TestData/Caulfield_Race.xml";
            var horses = extractJSON.Extract(path);
            Assert.NotNull(horses);
            Assert.True(horses.Races.Count() > 0);
        }

        [Fact]
        public void ExtractHorsesFromJsonFileEmpty()
        {
            var extractJSON = new ExtractEngineJSON();
            string path = "TestData/Wolferhampton_Race_Empty.json";
            var horses = extractJSON.Extract(path);
            Assert.Null(horses);
        }

        [Fact]
        public void ExtractHorsesFromXmlFileEmpty()
        {
            var extractJSON = new ExtractEngineXML();
            string path = "TestData/Caulfield_Race_Empty.xml";
            var horses = extractJSON.Extract(path);
            Assert.Null(horses);
        }
    }
}
