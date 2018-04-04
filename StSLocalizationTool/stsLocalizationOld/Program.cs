using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MongoDB.Bson;
using stsLocalizationOld.Model;

namespace stsLocalizationOld
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText(@"/home/paulo/Documentos/localization/eng/cards.json");
            BsonDocument doc = BsonDocument.Parse(text);
            foreach(var el in doc.Elements){
                var card = new Card
                {
                    Title = el.Name,
                    Description = el.Value.AsBsonDocument.GetValue("DESCRIPTION").AsString,
                    ExtendedDescription = el.Value.AsBsonDocument.Contains("EXTENDED_DESCRIPTION") ? el.Value.AsBsonDocument.GetValue("EXTENDED_DESCRIPTION").AsBsonArray.Select( x => x.AsString) : new List<string>(),
                    UpgradedDescription = el.Value.AsBsonDocument.Contains("UPGRADE_DESCRIPTION") ? el.Value.AsBsonDocument.GetValue("UPGRADE_DESCRIPTION").AsString : string.Empty
                };
                Console.WriteLine("================================================================");
                Console.WriteLine($"Card Title : '{card.Title}'");
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine($"Card Description : '{card.Description}'");
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine($"Card Upgraded Description : '{card.UpgradedDescription}'");
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine($"Card Extended : ");                
                foreach(var s in card.ExtendedDescription){Console.WriteLine($"\t {s}");}

                Console.WriteLine("================================================================");
            }
            Console.WriteLine(doc.ElementCount);
        }
    }
}


