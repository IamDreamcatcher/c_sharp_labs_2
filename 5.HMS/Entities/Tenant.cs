namespace HMS.Entities
{
    class Tenant
    {
        public string name;
        public int spending;
        public Tenant(string name, int spending)
        {
            this.name = name;
            this.spending = spending;
        }
    }
}