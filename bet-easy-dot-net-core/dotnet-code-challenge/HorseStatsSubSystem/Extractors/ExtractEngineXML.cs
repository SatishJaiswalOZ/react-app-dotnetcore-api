using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace dotnet_code_challenge
{
    public class ExtractEngineXML : IExtractEngine
    {
        public Meeting Extract(string fileWithFullPath)
        {
            try
            {
                var doc = XDocument.Load(fileWithFullPath);
                return new Meeting
                {
                    MeetingId = doc.Descendants("Meetingid").Single().Value,
                    Races = doc.Descendants("race").Select((race) =>
                    {
                        var prices = race.Elements("prices").Single().Descendants("horse");
                        return new Race
                        {
                            Number = int.Parse(race.Attribute("number").Value),
                            Horses = race.Elements("horses").Single().Elements("horse").Select(horse =>
                                {

                                    return new Horse
                                    {
                                        Name = horse.Attribute("name").Value,
                                        Price = decimal.Parse(prices.First(p => p.Attribute("number").Value == horse.Elements("number").Single().Value).Attribute("Price").Value)
                                    };

                                })
                        };

                    })
                };
            }
            catch (InvalidOperationException)
            {
                //For this excercise engulf issues but it has to be addressed to inform user.
                return null;
            }
        }

        public bool EngineSupported(string fileName)
        {
            return fileName.ToLower().EndsWith(".xml", StringComparison.OrdinalIgnoreCase);
        }

    }
}
