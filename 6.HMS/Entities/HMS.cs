using System;
using HMS.Collection;
using HMS.Exceptions;

namespace HMS.Entities
{
    //housing maintenance service
    class MyHMS
    {
        public delegate void ChangedRates(Rate rate);
        public event ChangedRates NotifyRateChange;

        public delegate void ChangedTenants(Tenant tenant);
        public event ChangedTenants NotifyTenantChange;

        public delegate void ChangedConsumption(string tenantName, string rateName, int cost);
        public event ChangedConsumption NotifyConsumption;

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
            Rate newRate = new Rate(name, cost);
            rates.Add(newRate);
            NotifyRateChange?.Invoke(newRate);
        }
        public void AddTenant(string name)
        {
            Tenant newTenant = new Tenant(name, 0);
            tenants.Add(newTenant);
            NotifyTenantChange?.Invoke(newTenant);
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
                throw new NullException("No such rate");
            } 
            for (int i = 0; i < tenants.Count; i++)
            {
                if (tenants[i].name == tenantName)
                {
                    int totalCost = servicesRendered * (int)rateCost;
                    tenants[i].spending += totalCost;
                    NotifyConsumption?.Invoke(tenants[i].name, rateName, totalCost);
                    break;
                }  
            }
        }
    }
}