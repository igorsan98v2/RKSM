using System;
using System.Collections.Generic;
using System.Text;
using lb5.entity;

namespace lb5.repos
{
    interface IStoreroomRepo
    {
        ICollection<StoreRoom> updateStoreRoomBase();
        StoreRoom findStoreRoomByName(string name);
        ICollection<Party> findAllPartysByWeightAndVegetable(StoreRoom store,float weight,Vegetable vegetable);
        Party addParty(StoreRoom storeRoom, Party party);
        Party editParty(StoreRoom storeRoom,int partyNumber, Party party);
        Party deleteParty(StoreRoom store, Vegetable vegetable, int partyNumber);

        ICollection<StoreRoom> getStorerooms();
        Party doShipment(StoreRoom store,Vegetable vegetable, int partyName,Party subParty);
        void saveChanges();
    }
    class StoreRoomRepoImpl : IStoreroomRepo
    {
        static Dictionary<string,StoreRoom> storerooms = new Dictionary<string,StoreRoom>(1);
       
        public Party addParty(StoreRoom storeRoom, Party party)
        {
            storerooms[storeRoom.Name].AddParty(party);
            return party;
        }

        public Party deleteParty(StoreRoom storeRoom, Vegetable vegetable, int partyNumber)
        {
            List<Party> parties = storerooms[storeRoom.Name].VegatablePartys[vegetable];
            foreach (var party in parties) { 
                if(party.Number == partyNumber)
                {
                    parties.Remove(party);
                    return party;
                }
            }
            throw new Exception("НЕ ЗНАЙДЕНО ЖОДНОЇ ПАРТІЇ С ТАКИМ НОМЕРОМ ПАРТІЇ ЗА ОВОЧЕМ ");
        }

        public Party doShipment(StoreRoom storeRoom,Vegetable vegetable,int partyNumber, Party subParty)
        {
            List<Party> parties = storerooms[storeRoom.Name].VegatablePartys[vegetable];
            foreach (var party in parties)
            {
                if (party.Number == partyNumber)
                {
                    if (party.Weight > subParty.Weight)
                    {
                        party.Weight = subParty.Weight;
                    }
                    else if (party.Weight == subParty.Weight)
                    {
                        parties.Remove(party);
                    }
                    else {
                        throw new Exception("Відвантаження від партії не може перевищувати вагу партії !");
                    }
                    return party;
                }
            }
            throw new Exception("НЕ ЗНАЙДЕНО ЖОДНОЇ ПАРТІЇ С ТАКИМ НОМЕРОМ ПАРТІЇ ЗА ОВОЧЕМ ");
            
        }

        public Party editParty(StoreRoom storeRoom, int partyNumber, Party partyEditted)
        {
            var vegetable = partyEditted.Vegetable;
            List<Party> parties = storerooms[storeRoom.Name].VegatablePartys[vegetable];
            foreach (var party in parties)
            {
                if (party.Number == partyNumber)
                {
                    party.Price = partyEditted.Price;
                    party.ExpirationTime = partyEditted.ExpirationTime;
                    party.Weight = partyEditted.Weight;
                    party.WeightUnit = partyEditted.WeightUnit;
                    return party;
                }
            }
            throw new Exception("НЕ ЗНАЙДЕНО ЖОДНОЇ ПАРТІЇ С ТАКИМ НОМЕРОМ ПАРТІЇ ЗА ОВОЧЕМ ");

        }

        public ICollection<Party> findAllPartysByWeightAndVegetable(StoreRoom store, float weight, Vegetable vegetable)
        {
            throw new NotImplementedException();
        }

        public StoreRoom findStoreRoomByName(string name)
        {
            StoreRoom store = storerooms[name];
            if(store == null)
            {
                return store;
            }
            throw new NullReferenceException();
        }

        public ICollection<StoreRoom> getStorerooms()
        {
           return  storerooms.Values;
        }

        public void saveChanges()
        {
            throw new NotImplementedException();
        }

        public ICollection<StoreRoom> updateStoreRoomBase()
        {
            throw new NotImplementedException();
        }
    }
}
