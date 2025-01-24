# Accountancy Module Entity Design Documentation


## Entity Definitions and Relationships

### 1. **Company**
Represents an organization that has multiple branches and contacts.

#### Properties:
- `CompanyId` (int): Primary key.
- `Name` (string): Name of the company.
- `Email` (string): Email address of the company.
- `Type` (string): Type of the company.
- `RegistrationNumber` (string): Unique company registration number.
- `TaxId` (string): Tax identification number.

#### Relationships:
- **One-to-Many** with `Branch`: A company can have multiple branches.
- **One-to-Many** with `ContactAssociation`: A company can have multiple contacts (individual or organizational).

### 2. **Branch**
Represents a subdivision or location of a company.

#### Properties:
- `BranchId` (int): Primary key.
- `Name` (string): Name of the branch.
- `CompanyId` (int): Foreign key to the `Company` entity.
- `IsActive` (bool): Indicates whether the branch is operational.

#### Relationships:
- **Many-to-One** with `Company`: A branch belongs to a single company.
- **One-to-Many** with `Address`: A branch can have multiple addresses.
- **One-to-Many** with `ContactAssociation`: A branch can have multiple associated contacts.

### 3. **Address**
Represents the physical location(s) of a branch.

#### Properties:
- `AddressId` (int): Primary key.
- `Line1` (string): First line of the address.
- `Line2` (string): Second line of the address (optional).
- `City` (string): City of the address.
- `State` (string): State of the address.
- `PostalCode` (string): Postal or ZIP code.
- `Latitude` (decimal?): GPS latitude of the address.
- `Longitude` (decimal?): GPS longitude of the address.
- `BranchId` (int): Foreign key to the `Branch` entity.

#### Relationships:
- **Many-to-One** with `Branch`: Each address is linked to one branch.

### 4. **Contact**
Represents an individual or organizational contact.

#### Properties:
- `ContactId` (int): Primary key.
- `Name` (string): Name of the contact (individual or organization).
- `Email` (string): Email address of the contact.
- `PhoneNumber` (string): Phone number of the contact.
- `ContactType` (string): Indicates whether the contact is an `Individual` or `Organization`.
- `RegistrationNumber` (string): Registration number (if the contact is an organization).
- `Industry` (string): Industry type (if the contact is an organization).
- `TaxId` (string): Tax ID (if the contact is an organization).
- `Role` (string): Role of the individual (if the contact is a person).
- `IsActive` (bool): Indicates whether the contact is active.

#### Relationships:
- **One-to-Many** with `ContactAssociation`: A contact can be associated with multiple companies or branches.

### 5. **ContactAssociation**
Represents the association between a contact and a company or branch.

#### Properties:
- `ContactAssociationId` (int): Primary key.
- `ContactId` (int): Foreign key to the `Contact` entity.
- `CompanyId` (int?): Foreign key to the `Company` entity (nullable).
- `BranchId` (int?): Foreign key to the `Branch` entity (nullable).

#### Relationships:
- **Many-to-One** with `Contact`: Links to the associated contact.
- **Optional Many-to-One** with `Company`: Links to the associated company (if applicable).
- **Optional Many-to-One** with `Branch`: Links to the associated branch (if applicable).

### 6. **Enums**
#### ContactType
Defines the type of contact.
- `Individual`
- `Organization`

## Entity Relationship Diagram (ERD)
The relationships are as follows:
- `Company` has a one-to-many relationship with `Branch`.
- `Branch` has a one-to-many relationship with `Address`.
- `Company` and `Branch` both have one-to-many relationships with `ContactAssociation`.
- `ContactAssociation` has a many-to-one relationship with `Contact`.

## Notes
- The `ContactAssociation` table is pivotal in allowing flexibility for associating contacts with both `Company` and `Branch` entities.
- The design ensures scalability and supports complex real-world scenarios, such as shared contacts across companies or branches.

This design forms a strong foundation for the accountancy module, adhering to production-level standards and supporting extensibility for future requirements.

