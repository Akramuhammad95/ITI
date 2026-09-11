# Medical Representative Management System
## Clean Architecture — Domain + Application Layers (MVP)

---

## 📁 Solution Structure

```
MedRepSystem/
│
├── MedRepSystem.Domain/                  ← Core business logic. No dependencies.
│   ├── Common/
│   │   └── BaseEntity.cs                 ← Id, CreatedAt, UpdatedAt, equality
│   ├── Enums/
│   │   └── Enums.cs                      ← UserRole, VisitStatus, CustomerType, etc.
│   ├── Exceptions/
│   │   └── DomainException.cs            ← Business rule violation exception
│   └── Entities/
│       ├── Area.cs                        ← Territory entity
│       ├── User.cs                        ← Medical rep entity
│       ├── Customer.cs                    ← Customer entity (belongs to Area)
│       ├── CustomerLocation.cs            ← Branch/location of a customer
│       ├── Product.cs                     ← Pharmaceutical product catalog
│       ├── Inventory.cs                   ← Stock levels per product per area
│       ├── Visit.cs                       ← Customer visit (most logic-rich)
│       └── VisitProduct.cs               ← Many-to-many: Visit ↔ Product
│
├── MedRepSystem.Application/             ← Orchestration. Depends only on Domain.
│   ├── Interfaces/
│   │   └── IRepositories.cs              ← Contracts (no implementation)
│   ├── DTOs/
│   │   └── Dtos.cs                       ← Request/response objects + Result<T>
│   ├── UseCases/
│   │   ├── CreateVisitUseCase.cs
│   │   ├── AddProductToVisitUseCase.cs
│   │   ├── CompleteVisitUseCase.cs
│   │   ├── CancelVisitUseCase.cs
│   │   └── InventoryUseCases.cs          ← Reduce + Restock
│   └── Services/
│       ├── VisitQueryService.cs           ← Read-side visit queries
│       └── InventoryQueryService.cs       ← Read-side inventory queries
│
├── MedRepSystem.Infrastructure/          ← NOT BUILT YET
│   └── (EF Core, DbContext, Repository implementations)
│
└── MedRepSystem.Web/                     ← NOT BUILT YET
    └── (ASP.NET Core MVC Controllers + Views)
```

---

## 🧱 Architecture Dependency Rules

```
Web (MVC)          →  Application  →  Domain
Infrastructure     →  Application  →  Domain
                                   ↑
                             No outward deps
```

- **Domain** depends on nothing
- **Application** depends only on Domain
- **Infrastructure** will depend on Application (implements interfaces)
- **Web** depends on Application (calls use cases)

---

## 🧠 Domain Layer — Business Rules Summary

### Visit (most complex entity)
| Rule | Where enforced |
|------|----------------|
| Visit date auto-set to UtcNow | `Visit` constructor |
| Cannot add duplicate products | `Visit.AddProduct()` |
| At least 1 product to complete | `Visit.Complete()` |
| Cannot modify completed/cancelled visits | `Visit.EnsureIsEditable()` |
| Cancellation requires a reason | `Visit.Cancel()` |
| CompletedAt timestamp is auto-recorded | `Visit.Complete()` |

### Inventory
| Rule | Where enforced |
|------|----------------|
| Stock never goes below zero | `Inventory.Deduct()` |
| Cannot deduct more than available | `Inventory.Deduct()` |
| Low-stock signal | `Inventory.IsLowStock()` |
| Restock quantity must be positive | `Inventory.Restock()` |

### User (Medical Rep)
| Rule | Where enforced |
|------|----------------|
| Must have valid email | `User` constructor |
| Can only visit customers in assigned area | `User.EnsureCanVisitInArea()` |
| Inactive user cannot visit | `User.EnsureCanVisitInArea()` |

### Customer
| Rule | Where enforced |
|------|----------------|
| Must belong to an Area | `Customer` constructor |
| Cannot be visited if inactive | `Customer.EnsureCanBeVisited()` |
| No duplicate location addresses | `Customer.AddLocation()` |
| Only one primary location | `Customer.AddLocation()` |

### CustomerLocation
| Rule | Where enforced |
|------|----------------|
| GPS coords must be valid range | `CustomerLocation` constructor |
| Address required | `CustomerLocation` constructor |
| Haversine distance calculation | `CustomerLocation.DistanceInKmTo()` |

---

## ⚙️ Application Layer — Use Cases

### Write Use Cases (change state)
| Use Case | What it orchestrates |
|----------|---------------------|
| `CreateVisitUseCase` | Validates rep+customer, checks territory, creates Visit |
| `AddProductToVisitUseCase` | Loads visit+product, delegates to Visit.AddProduct() |
| `CompleteVisitUseCase` | Completes visit + deducts inventory for all products |
| `CancelVisitUseCase` | Cancels visit with reason |
| `ReduceInventoryUseCase` | Manual stock deduction |
| `RestockInventoryUseCase` | Adds stock to inventory |

### Read Services (query only)
| Service | Purpose |
|---------|---------|
| `VisitQueryService` | Fetch visits by rep, customer, date range |
| `InventoryQueryService` | Stock status, low-stock alerts per area |

---

## 🔌 DI Registration (future — when Infrastructure is added)

```csharp
// In Program.cs or DI extension methods:

// Repositories (Infrastructure implements)
services.AddScoped<IVisitRepository, VisitRepository>();
services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<ICustomerRepository, CustomerRepository>();
services.AddScoped<IProductRepository, ProductRepository>();
services.AddScoped<IInventoryRepository, InventoryRepository>();
services.AddScoped<IAreaRepository, AreaRepository>();

// Use Cases (Application)
services.AddScoped<CreateVisitUseCase>();
services.AddScoped<AddProductToVisitUseCase>();
services.AddScoped<CompleteVisitUseCase>();
services.AddScoped<CancelVisitUseCase>();
services.AddScoped<ReduceInventoryUseCase>();
services.AddScoped<RestockInventoryUseCase>();

// Query Services
services.AddScoped<VisitQueryService>();
services.AddScoped<InventoryQueryService>();
```

---

## 🎯 What Comes Next (Infrastructure + Web)

**Infrastructure Layer:**
- `AppDbContext : DbContext` (EF Core)
- Entity configurations (Fluent API — no attributes in domain)
- Concrete repository implementations
- Migrations

**Web Layer (MVC):**
- Controllers inject use cases and query services
- Views display DTOs (never domain entities directly)
- Form submissions map to Request DTOs
