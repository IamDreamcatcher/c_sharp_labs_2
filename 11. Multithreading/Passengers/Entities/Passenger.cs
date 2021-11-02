
namespace Entities
{
    public class Passenger
    {
        public string Name { get; set; }
        public bool HaveBaggage { get; set; }
        public int ID { get;}
        private static int currentId;
        public Passenger()
        {
            ID = currentId++;
            Name = default(string);
            HaveBaggage = default(bool);
        }
        public Passenger(string name, bool haveBaggage)
        {
            ID = currentId++;
            Name = name;
            HaveBaggage = haveBaggage;
        }
    }
}
