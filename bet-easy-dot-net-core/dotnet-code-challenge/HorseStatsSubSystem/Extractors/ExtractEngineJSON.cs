using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace dotnet_code_challenge
{
    public class ExtractEngineJSON : IExtractEngine
    {
        public Meeting Extract(string fileWithFullPath)
        {
            using (StreamReader reader = File.OpenText(fileWithFullPath))
            {
                dynamic data = JsonConvert.DeserializeObject(reader.ReadToEnd());
                if (!ReferenceEquals(null, data))
                {
                    if (data.RawData is object)
                    {
                        IEnumerable<dynamic> markets = data.RawData.Markets;
                        if (data.RawData.Markets is object)
                        {
                            return new Meeting
                            {
                                MeetingId = data.RawData.Id,
                                Races = markets.Select((market, index) =>
                                {
                                    if (market.Selections is object)
                                    {
                                        IEnumerable<dynamic> selections = market.Selections;
                                        return new Race
                                        {
                                            Number = index + 1,
                                            Horses = selections.Select(selection =>
                                            {
                                                return new Horse
                                                {
                                                    Name = (selection.Tags is object) ? selection.Tags.name: string.Empty,
                                                    Price = decimal.Parse((string)selection.Price)
                                                };
                                            })
                                        };
                                    }
                                    return null;
                                })
                            };
                        }
                    }
                }
                return null;
            }
        }

        public bool EngineSupported(string fileName)
        {
            return fileName.ToLower().EndsWith(".json", StringComparison.OrdinalIgnoreCase);
        }
    }
}
