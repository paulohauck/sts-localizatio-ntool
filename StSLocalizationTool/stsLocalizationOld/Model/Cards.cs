using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace stsLocalizationOld.Model
{
    [BsonIgnoreExtraElements]
    public class Card
    {
        public string Title{get;set;}

        public string Description{get;set;}

        [BsonIgnoreIfNull]
        public IEnumerable<string> ExtendedDescription {get;set;}

        [BsonIgnoreIfNull]
        public string UpgradedDescription {get; set;}
    }
}