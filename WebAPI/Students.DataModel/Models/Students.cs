﻿using MongoDB.Bson.Serialization.Attributes;

namespace Students.DataModel.Models
{
    public class Student
    {
        // Tells MongoDB that StudentID is going to be used as unique key
        // i.e. _id in student collection
        [BsonElement("_id")]
        public int StudentID { get; set; }
        public string RollNo { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
    }
}
