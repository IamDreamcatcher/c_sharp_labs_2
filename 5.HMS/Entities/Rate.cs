namespace HMS.Entities
{
    class Rate
    {
        public string name;
        public int cost;
        public Rate(string name, int cost)
        {
            this.name = name;
            this.cost = cost;
        }
    }
}