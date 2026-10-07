# TimeReminder Notes

## Created TimeReminder Solution with the following subprojects

### TimeReminder.UI
This project holds the source for the UI that the user will interface with to
1. Create a new TimeReminder
2. Delete/Modify an existing TimeReminder
3. View all current TimeReminders

### TimeReminder.Domain
TimeReminder.Domain defines the core business entities, rules, and interfaces 
that describe the Reminder system at its most fundamental level.

**Purpose**:  
This project defines the core concepts of your application — the nouns and the 
rules that describe what a Reminder is, independent of how it is stored, displayed, or scheduled.

Think of it as the **pure business model**, with zero dependencies.

#### What belongs in Domain:
- Entities / Models
  - Reminder
  - ReminderSchedule
  - ReminderHistory
  - ReminderStatus

- Enums
  - PriorityLevel
  - ScheduleType

- Interfaces
  - IReminderRepository
  - IReminderService

- Validation rules
  - “A reminder must have a due time”
  - “A schedule cannot repeat in the past”

- DTOs (if shared across layers)

- Exceptions
  - InvalidReminderException

#### Why Domain exists:
- It prevents business logic from leaking into UI or Data.
- It makes your system testable.
- It allows you to replace the database or UI without touching the core logic.
- It keeps your architecture clean and maintainable.

### TimeReminder.Data
TimeReminder.Data implements the persistence layer, providing database access, 
repositories, and EF Core infrastructure for storing and retrieving reminders.

**Purpose**:  
This project handles persistence — the mechanics of saving, loading, querying, 
and updating reminders in a database.

It is the _infrastructure layer_.

#### What belongs in Data:
- EF Core DbContext
  - TimeReminderDbContext

- Repository implementations
  - ReminderRepository : IReminderRepository

- Database migrations

- Entity configurations
  - Fluent API mapping

- Connection logic
  - PostgreSQL connection strings (via configuration)

- Data access helpers
  - Query extensions
  - Transaction helpers

#### Why Data exists:
- It isolates database concerns from business logic.
- It allows you to swap PostgreSQL for SQLite, SQL Server, or even a cloud DB 
without touching the API or Scheduler.
- It keeps your API layer clean — the API only calls interfaces, not SQL.


### TimeReminder.API
This project implements the API used by components requiring access to the 
database. This will establish connection and access to the trdb.

### TimeReminder.Scheduler
This projects holds the source code that implements the notification scheduler.

## The Architecture of the Application

Domain
Defines what a Reminder is
⬇️

Data
Defines how a Reminder is stored
⬇️

API
Defines how Reminders behave
⬇️

Scheduler
Uses the API to trigger reminders
⬇️

UI
Uses the API to display and manage reminders

This is a textbook clean architecture flow.
