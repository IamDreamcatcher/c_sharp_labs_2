using System;
using System.Collections.Generic;
using System.Linq;

namespace HMS.Entities
{
    //housing maintenance service
    class MyHMS
    {
        public delegate void HappenedEvent(string eventName, string eventDescription);

        public event HappenedEvent NotifyRateChange;
        public event HappenedEvent NotifyTenantChange;
        public event HappenedEvent NotifyConsumption;

        Dictionary <string, int> rates = new Dictionary<string, int>();
        List<Tenant> tenants = new List<Tenant>();

        public IEnumerable<string> GetSortedRates()
        {
            var sortedRates = from rate in rates 
                              orderby rate.Value
                              select rate.Key;
            return sortedRates;
        }
        public int GetAmountOfConsumedServices()
        {
            int totalSum = tenants.Sum(tenant => tenant.cost);
            return totalSum;
        }
        public int GetAmountOfConsumedServicesByName(string name)
        {
            var newTenants = from tenant in tenants
                             where tenant.name == name
                             select tenant;
            if (newTenants.Count() == 0)
            {
                throw new NullReferenceException("No such tenant");
            }
            return newTenants.First().cost;
        }
        public void AddRate(string name, int cost)
        {
            rates.Add(name, cost);
            NotifyRateChange?.Invoke("Rate change", name + " cost is " + cost);
        }
        public void AddTenant(string name)
        {
            Tenant newTenant = new Tenant(name, 0);
            tenants.Add(newTenant);
            NotifyTenantChange?.Invoke("New tenant", newTenant.name + " was registered");
        }
        private int? GetRateCost(string rateName)
        {
            return rates.ContainsKey(rateName) ? rates[rateName] : null;
        }
        public void AddServiceConsumption(string tenantName, string rateName, int servicesRendered)
        {
            int? rateCost = GetRateCost(rateName);
            if (rateCost == null)
            {
                throw new NullReferenceException("No such rate");
            } 
            foreach (Tenant tenant in tenants)
            {
                if (tenant.name == tenantName)
                {
                    int totalCost = servicesRendered * (int)rateCost;
                    tenant.cost += totalCost;
                    tenant.AddOrder(new Order(rateName, servicesRendered));
                    NotifyConsumption?.Invoke("Consumption- ", tenantName + " spent " + totalCost + " on " + rateName);
                    break;
                }  
            }
        }

        public string GetMostCostTenant()
        {
            Tenant tenant = tenants.OrderByDescending(t => t.cost).First();
            return tenant.name;
        }
        public int GetNumberOfClientsWithLargerAmount(int sum)
        {
            return tenants.Aggregate(0, (counter, tenant) => counter += tenant.cost > sum ? 1 : 0);
        }
        public void PrintOrdersOfTenant(string name)
        {
            foreach(Tenant tenant in tenants)
            {
                if (tenant.name == name)
                {
                    var list = tenant.GetSortedOrders();
                    Console.WriteLine(tenant.name);
                    foreach(var item in list)
                    {
                        Console.WriteLine("Rate: " + item.Item1 + " cost: " + item.Item2);
                    }
                    break;
                }
            }
        }
    }
}