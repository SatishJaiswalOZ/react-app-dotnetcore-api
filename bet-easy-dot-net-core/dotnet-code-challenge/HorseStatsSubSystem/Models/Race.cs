using System.Collections.Generic;

namespace dotnet_code_challenge
{
    public class Race
    {
        public int Number { get; set; }

        public IEnumerable<Horse> Horses { get; set; }
    }
}
