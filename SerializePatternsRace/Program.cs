using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SerializePatternsRace
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            ISerialize<List<Race>> serialize = new SerializeToJson<List<Race>>();

            RaceSerialize raceSerialize = new RaceSerialize(@"C:\Users\ladon\Desktop\race.txt", @"C:\Users\ladon\Desktop\race_Json.json", serialize);

            await raceSerialize.Serialize();
        }
    }
}
