using System;

namespace Domain.Entities
{
    public class Manager : IEquatable<Manager>
    {
        public Manager(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }


        public bool Equals(Manager? other)
        {
            if (other is null) return false;
            return Id.Equals(other.Id);
        }

        public override bool Equals(object? obj) => Equals(obj as Manager);
        public override int GetHashCode() => Id.GetHashCode();
        public static bool operator ==(Manager? left, Manager? right) => Equals(left, right);
        public static bool operator !=(Manager? left, Manager? right) => !Equals(left, right);
    }
}