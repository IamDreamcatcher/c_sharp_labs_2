using System;
using HMS.Collection;

namespace HMS.Entities
{
    //housing maintenance service
    class MyHMS
    {
        MyCustomCollection<Rate> rates = new MyCustomCollection<Rate>();
        MyCustomCollection<Tenant> tenants = new MyCustomCollection<Tenant>();
        public int GetAmountOfConsumedServices()
        {
            int cost = 0;
            for (int i = 0; i < tenants.Count; i++)
            {
                cost += tenants[i].spending;
            }
            return cost;
        }
        public int GetAmountOfConsumedServicesByName(string name)
        {
            int cost = 0;
            for (int i = 0; i < tenants.Count; i++)
            {
                if (tenants[i].name == name)
                {
                    cost = tenants[i].spending;
                    break;
                }
            }
            return cost;
        }
        public void AddRate(string name, int cost)
        {
            rates.Add(new Rate(name, cost));
        }
        private int? GetRateCost(string rateName)
        {
            for (int i = 0; i < rates.Count; i++)
            {
                if (rates[i].name == rateName)
                {
                    return rates[i].cost;
                }
            }
            return null;
        }
        public void AddServiceConsumption(string tenantName, string rateName, int servicesRendered)
        {
            int? rateCost = GetRateCost(rateName);
            if (rateCost == null)
            {
                throw new Exception("No such rate");
            } 
            for (int i = 0; i < tenants.Count; i++)
            {
                if (tenants[i].name == tenantName)
                {
                    tenants[i].spending += servicesRendered * (int)rateCost;
                    return;
                }  
            }
            tenants.Add(new Tenant(tenantName, servicesRendered * (int)rateCost));
        }
    }
}