using MedRepSystem.Application.DTOs;
using MedRepSystem.Application.Interfaces;
using MedRepSystem.Domain.Entities;
using MedRepSystem.Domain.Exceptions;

namespace MedRepSystem.Application.UseCases;

/// <summary>
/// CreateVisitUseCase — Orchestrates the creation of a new customer visit.
///
/// RESPONSIBILITIES:
///   1. Validate that the user (rep) exists and is active
///   2. Validate that the customer exists and is active
///   3. Enforce territory rule: rep's area must match customer's area
///   4. Persist the new Visit
///
/// DOES NOT:
///   - Contain business rules (those live in User, Customer, Visit)
///   - Access the database directly
///   - Know about HTTP, MVC, or views
/// </summary>
public class CreateVisitUseCase
{
    private readonly IVisitRepository _visitRepository;
    private readonly IUserRepository _userRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IAreaRepository _areaRepository;

    public CreateVisitUseCase(
        IVisitRepository visitRepository,
        IUserRepository userRepository,
        ICustomerRepository customerRepository,
        IAreaRepository areaRepository)
    {
        _visitRepository = visitRepository;
        _userRepository = userRepository;
        _customerRepository = customerRepository;
        _areaRepository = areaRepository;
    }

    public async Task<Result<Guid>> ExecuteAsync(CreateVisitRequest request, CancellationToken ct = default)
    {
        try
        {
            // Step 1: Load and validate the medical rep
            var user = await _userRepository.GetByIdAsync(request.UserId, ct);
            if (user is null)
                return Result<Guid>.Failure($"User with ID '{request.UserId}' was not found.");

            // Step 2: Load and validate the customer
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId, ct);
            if (customer is null)
                return Result<Guid>.Failure($"Customer with ID '{request.CustomerId}' was not found.");

            // Step 3: Load the customer's area for territory validation
            var customerArea = await _areaRepository.GetByIdAsync(customer.AreaId, ct);
            if (customerArea is null)
                return Result<Guid>.Failure($"Area configuration for customer '{customer.Name}' is invalid.");

            // Step 4: Domain rule — rep must be active and in the correct area
            // This THROWS DomainException if violated (domain enforces the rule, not us)
            user.EnsureCanVisitInArea(customerArea);

            // Step 5: Domain rule — customer must be eligible for visits
            customer.EnsureCanBeVisited();

            // Step 6: Create the visit (domain entity tracks date automatically)
            var visit = new Visit(user.Id, customer.Id, request.Notes);

            // Step 7: Persist
            await _visitRepository.AddAsync(visit, ct);
            await _visitRepository.SaveChangesAsync(ct);

            return Result<Guid>.Success(visit.Id);
        }
        catch (DomainException ex)
        {
            // Domain rule violations are expected — return as failure, not crash
            return Result<Guid>.Failure(ex.Message);
        }
    }
}
