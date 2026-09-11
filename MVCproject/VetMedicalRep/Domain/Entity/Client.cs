namespace Domain.Entities
{
    public class Client : IEquatable<Client>
    {
        public Client(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public Guid Id { get; private set; }
        public string  Name { get;private set; }
        public string Address { get; private set; }

       // public Classification classification { get; private set; }


        public bool Equals(Client? other)
        {
            throw new NotImplementedException();
        }
    }
}
