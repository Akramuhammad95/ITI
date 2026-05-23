using System;

namespace Domain.Entities
{
    public class Visit
    {
        public Guid Id { get; private set; }
        public Guid ClientId { get; private set; }
        public Client? Client { get; private set; }

        public Guid UserId { get; private set; }
        public User? User { get; private set; }

        public DateTime VisitDate { get; private set; }
        public string? Notes { get; private set; }
        public bool Completed { get; private set; }

        private Visit() { }

        public Visit(Guid clientId, Guid userId, DateTime visitDate, string? notes = null)
        {
            ClientId = clientId;
            UserId = userId;
            VisitDate = visitDate;
            Notes = notes?.Trim();
            Completed = false;
        }

        public void MarkCompleted()
        {
            Completed = true;
        }

        public void UpdateNotes(string? notes)
        {
            Notes = notes?.Trim();
        }
    }
}
