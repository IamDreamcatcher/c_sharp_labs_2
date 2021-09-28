using System;
using HMS.Collection;
using HMS.Exceptions;

namespace HMS.Entities
{
    //housing maintenance service
    class MyHMS
    {
        public delegate void ChangedRates(string eventName, string eventDescription);
        public event ChangedRates NotifyRateChange;

        public delegate void ChangedTenants(string eventName, string eventDescription);
        public event ChangedTenants NotifyTenantChange;

        public delegate void ChangedConsumption(string eventName, string eventDescription);
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
            NotifyRateChange?.Invoke("Rate change", newRate.name + " cost is " + newRate.cost);
        }
        public void AddTenant(string name)
        {
            Tenant newTenant = new Tenant(name, 0);
            tenants.Add(newTenant);
            NotifyTenantChange?.Invoke("New tenant", newTenant.name + " was registered");
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
                    NotifyConsumption?.Invoke("Consumption- ", tenantName + " spent " + totalCost + " on " + rateName);
                    break;
                }  
            }
        }
    }
}