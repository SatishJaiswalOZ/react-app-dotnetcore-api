using System.Collections.Generic;

namespace dotnet_code_challenge
{
    public class Meeting
    {
        public string MeetingId { get; set; }

        public IEnumerable<Race> Races { get; set; }
    }
}
