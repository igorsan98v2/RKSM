using System;
using System.Collections.Generic;
using System.Text;
using YamlDotNet.Serialization;

namespace lb5.entity
{

    /*
     * name: "apelsin"
       type: "TUBER"
       expiration-length: 14
       */
    enum Type
    {
        TUBER,//клубневі
        TOMATO,//томати
        ONION,//лукові
        SALAT,//салати
        CABBAGE,//капустні
        GOURDS//бахчеві
        
    };
    class Vegetable
    {
        private string name;
        private Type type;
        private int expirationLength;//строк придатності у днях
        public Vegetable() { }
        public Vegetable(string name, Type type, int expiration)
        {
            this.name = name;
            this.type = type;
            this.expirationLength = expiration;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        [YamlMember(Alias = "type", ApplyNamingConventions = false)]
        public Type VegatableType
        {

            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        [YamlMember(Alias = "expiration-length", ApplyNamingConventions = false)]
        public int Expiration
        {
            get
            {
                return expirationLength;
            }
            set
            {
                expirationLength = value;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Vegetable vegetable &&
                   name == vegetable.name &&
                   type == vegetable.type &&
                   expirationLength == vegetable.expirationLength &&
                   Name == vegetable.Name &&
                   VegatableType == vegetable.VegatableType &&
                   Expiration == vegetable.Expiration;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, type, expirationLength, Name, VegatableType, Expiration);
        }
    }
}


