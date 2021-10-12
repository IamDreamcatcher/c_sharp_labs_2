using System.Collections.Generic;
using System.Linq;

namespace HMS.Entities
{
    class Tenant
    {
        public string name;
        public int cost;
        private List<Order> orders = new List<Order>();
        public Tenant(string name, int spending)
        {
            this.name = name;
            this.cost = spending;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Tenant tenant = obj as Tenant;
            if (tenant == null)
                return false;
            return tenant.name == name;
        }
        public override int GetHashCode()
        {
            int hashcode = name.GetHashCode();
            hashcode = 31 * hashcode + cost.GetHashCode();
            return hashcode;
        }
        public void AddOrder(Order order)
        {
            orders.Add(order);
        }
        public IEnumerable<(string, int)> GetSortedOrders()
        {
            var sortedOrders = orders.GroupBy(order => order.name)
                .Select(group => (group.Key, group.Sum(or => or.cost) ) )
                .ToList();
            return sortedOrders;
        }
    }
}