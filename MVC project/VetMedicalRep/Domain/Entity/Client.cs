using System;

namespace Domain.Entities
{
    public class Client : IEquatable<Client>
    {
        public Client(string name, string address)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Client name is required.", nameof(name));
            if (string.IsNullOrWhiteSpace(address)) throw new ArgumentException("Client address is required.", nameof(address));

            Name = name.Trim();
            Address = address.Trim();
        }

        private Client() { } // for EF Core

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }

       // public Classification classification { get; private set; }

        public bool Equals(Client? other)
        {
            if (other is null) return false;
            return Id.Equals(other.Id);
        }

        public override bool Equals(object? obj) => Equals(obj as Client);
        public override int GetHashCode() => Id.GetHashCode();
        public static bool operator ==(Client? left, Client? right) => Equals(left, right);
        public static bool operator !=(Client? left, Client? right) => !Equals(left, right);
    }
}
