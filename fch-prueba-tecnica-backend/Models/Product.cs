﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace fch_prueba_tecnica_backend.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        //public ObjectId Id { get; set; }
        public string Id { get; set; }
        public string prodCode { get; set; }

        public string prodName { get; set; }

        public string prodManofacturer { get; set; }

        public string prodModel { get; set; }

        public decimal prodUnitPrice { get; set; }

        public int prodStock { get; set; }
    }
}
