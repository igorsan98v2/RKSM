using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using YamlDotNet.Serialization;

namespace lb5.entity
{
    /*
    number: 1312364
    weight: 1.5
    weight-unit: "KG"
    vegetable:
       name: "apelsin"
       type: "TUBER"
       expiration-length: 14
    price: 500
    deliveryTime: "10-10-10 2019/10/12"
    expirationTime: "11-11-11 2019/10/12" 
         
    */
    enum Weight
    {
        KG,
        G,
        POUND
    }
    class Party
    {
        private int number;
        private float weight;
        private Weight weightUnit;
        private Vegetable vegetable;
        private float price;
        private DateTime deliveryTime;//дата та час прибуття до складу
        private DateTime expirationTime;//кінцевий строк придатності

        public int Number { get => number; set => number = value; }
        public float Weight { get => weight; set => weight = value; }
        public float Price { get => price; set => price = value; }
        public string DeliveryTime { get => deliveryTime.ToString(); 
            set {
                deliveryTime = parseToDataTime(value);
            } 
        }
        private DateTime parseToDataTime(string toParse)
        {
            return DateTime.ParseExact(toParse,
                                "HH-mm-ss yyyy/MM/dd",
                                CultureInfo.CurrentCulture);
        }
        public string ExpirationTime { get => expirationTime.ToString();
            set => expirationTime = parseToDataTime(value); }
      
        [YamlMember(Alias = "weight-unit", ApplyNamingConventions = false)]
        public Weight WeightUnit { get => weightUnit; set => weightUnit = value; }
        [YamlMember(Alias = "vegetable", ApplyNamingConventions = false)]
        public Vegetable Vegetable { get => vegetable; set => vegetable = value; }

        public override bool Equals(object obj)
        {
            return obj is Party party &&
                   number == party.number &&
                   weight == party.weight &&
                   weightUnit == party.weightUnit &&
                   EqualityComparer<Vegetable>.Default.Equals(vegetable, party.vegetable) &&
                   price == party.price &&
                   deliveryTime == party.deliveryTime &&
                   expirationTime == party.expirationTime;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(number, weight, weightUnit, vegetable, price, deliveryTime, expirationTime);
        }
    }
}
