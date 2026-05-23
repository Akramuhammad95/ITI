using System;

namespace Domain.Entities
{
    public class Area : IEquatable<Area>
    {
        public Area(string name, string description = "")
        {
            Name = name;
            Description = description;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsActive { get; private set; } = true;


        public bool Equals(Area? other)
        {
            if (other is null) return false;
            return Id.Equals(other.Id);
        }

        public override bool Equals(object? obj) => Equals(obj as Area);
        public override int GetHashCode() => Id.GetHashCode();
        public static bool operator ==(Area? left, Area? right) => Equals(left, right);
        public static bool operator !=(Area? left, Area? right) => !Equals(left, right);
    }
}