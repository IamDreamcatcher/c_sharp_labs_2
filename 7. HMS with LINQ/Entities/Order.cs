namespace HMS.Entities
{
    struct Order
    {
        public string name;
        public int cost;
        public Order(string name, int cost)
        {
            this.name = name;
            this.cost = cost;
        }
    }
}