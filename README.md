The Speaker class has too many responsibilities, violating the Single Responsibility Principle (SRP).
Register Method is doing too many things at once (speaker validation, fee calculation...).
Too many conditional checks with nested conditional statements.
Validation and checks are duplicated across the code and should be extracted into smaller, reusable methods.
It's difficult to extend the code with new functionalities or additional validations without modifying the existing code (Violation of Open Closed Principle).
The Speaker class is tightly coupled with session approval, fee calculation, and validation logic (Interfaces are needed).
