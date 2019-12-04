using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YamlDotNet.Serialization;

namespace lb5.entity
{
    class StoreRoom
    {
        private string name;
        private Dictionary<Vegetable, List<Party>> vegatablePartys = new Dictionary<Vegetable, List<Party>>(10);
        private Dictionary<string, Vegetable> vegetables = new Dictionary<string, Vegetable>(10);
        public StoreRoom(string name) {
            this.name = name;
        }
        public StoreRoom() {}
        public void AddVegetable(Vegetable vegetable)
        {
            string name = vegetable.Name;
            vegetables.Add(name, vegetable);
        }
        public void AddParty(Party party)
        {
            Vegetable vegetable = party.Vegetable;
            if (!vegatablePartys.ContainsKey(vegetable)) {
                vegatablePartys.Add(vegetable, new List<Party>(10));
            }
            vegatablePartys[vegetable].Add(party);
        }
        [YamlMember(Alias = "name", ApplyNamingConventions = false)]
        public string Name { get => name; set => name = value; }
        public Dictionary<Vegetable, List<Party>> VegatablePartys { get => vegatablePartys; set => vegatablePartys = value; }
        public Dictionary<string, Vegetable> VegetablesDictionary { get => vegetables; set => vegetables = value; }
        [YamlMember(Alias = "vegetables", ApplyNamingConventions = false)]
        public List<Vegetable> Vegatables { get; set; }

        [YamlMember(Alias = "parties", ApplyNamingConventions = false)]
        public List<Party> Parties { get {
                var parties =
                VegatablePartys.Values.SelectMany(party => party).ToList();
                return parties;
            }
            set {
                value.ForEach(AddParty);
            }
        }
        [YamlMember(Alias = "store-rooms", ApplyNamingConventions = false)]
        public List<StoreRoom> storeRooms{get;set;}

    }
}
