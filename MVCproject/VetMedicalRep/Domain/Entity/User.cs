

namespace Domain.Entities;

/// <summary>
/// Represents a system user — primarily a Medical Representative.
/// 
/// Business Rules:
/// - Email must be valid and non-empty
/// - Full name cannot be empty
/// - A rep can be assigned to at most one Area at a time
/// - An inactive user cannot conduct visits
/// - Password is stored as hash (never plain text)
/// </summary>
public class User 
{
    public string FullName { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    //public UserRole Role { get; private set; }
    public bool IsActive { get; private set; }

    // Territory assignment
    //public Guid? AreaId { get; private set; }
    //p//ublic Area? Area { get; private set; }

    //// Navigation: visits conducted by this rep
    ////private readonly List<Visit> _visits = new();
    ////public IReadOnlyCollection<Visit> Visits => _visits.AsReadOnly();

    //private User() { } // EF Core / serialization

    //public User(string fullName, string email, string passwordHash, UserRole role = UserRole.MedicalRepresentative)
    //{
    //    if (string.IsNullOrWhiteSpace(fullName))
    //        throw new DomainException("Full name cannot be empty.");

    //    if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
    //        throw new DomainException("A valid email address is required.");

    //    if (string.IsNullOrWhiteSpace(passwordHash))
    //        throw new DomainException("Password hash cannot be empty.");

    //    FullName = fullName.Trim();
    //    Email = email.Trim().ToLowerInvariant();
    //    PasswordHash = passwordHash;
    //    Role = role;
    //    IsActive = true;
    //}

    //// ── Business Methods ──────────────────────────────────────────

    ///// <summary>
    ///// Assigns this medical rep to a territory area.
    ///// A rep can only belong to one area at a time.
    ///// </summary>
    //public void AssignToArea(Area area)
    //{
    //    if (!IsActive)
    //        throw new DomainException($"Inactive user '{FullName}' cannot be assigned to an area.");

    //    if (!area.IsActive)
    //        throw new DomainException($"Cannot assign user to inactive area '{area.Name}'.");

    //    AreaId = area.Id;
    //    Area = area;
    //    MarkUpdated();
    //}

    //public void UnassignFromArea()
    //{
    //    AreaId = null;
    //    Area = null;
    //    MarkUpdated();
    //}

    ///// <summary>
    ///// Validates that this rep is allowed to visit a customer in the given area.
    ///// A rep can only visit customers within their assigned territory.
    ///// </summary>
    //public void EnsureCanVisitInArea(Area targetArea)
    //{
    //    if (!IsActive)
    //        throw new DomainException($"User '{FullName}' is inactive and cannot conduct visits.");

    //    if (AreaId == null)
    //        throw new DomainException($"User '{FullName}' has no assigned area and cannot conduct visits.");

    //    if (AreaId != targetArea.Id)
    //        throw new DomainException(
    //            $"User '{FullName}' is assigned to a different area and cannot visit customers in area '{targetArea.Name}'.");
    //}

    //public void UpdateProfile(string fullName, string email)
    //{
    //    if (string.IsNullOrWhiteSpace(fullName))
    //        throw new DomainException("Full name cannot be empty.");

    //    if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
    //        throw new DomainException("A valid email address is required.");

    //    FullName = fullName.Trim();
    //    Email = email.Trim().ToLowerInvariant();
    //    MarkUpdated();
    //}

    //public void ChangePasswordHash(string newHash)
    //{
    //    if (string.IsNullOrWhiteSpace(newHash))
    //        throw new DomainException("Password hash cannot be empty.");

    //    PasswordHash = newHash;
    //    MarkUpdated();
    //}

    //public void Deactivate()
    //{
    //    if (!IsActive)
    //        throw new DomainException($"User '{FullName}' is already inactive.");

    //    IsActive = false;
    //    MarkUpdated();
    //}

    //public void Activate()
    //{
    //    IsActive = true;
    //    MarkUpdated();
    //}

    //public bool IsManager() => Role == UserRole.AreaManager || Role == UserRole.Admin;
}
