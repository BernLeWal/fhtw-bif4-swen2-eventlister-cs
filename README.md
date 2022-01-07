# EventListerInCSharp
Sample project in C# for SWEN2-course, shows 
* SOLID architecture, 
* MVVM-pattern and 
* Unit-Tests with MVVM.


# SOLID

see: https://dotnetcoretutorials.com/2019/10/17/solid-in-c-single-responsibility-principle/
and https://www.baeldung.com/solid-principles

## SRP - Single Responsibility Principle

* A class should have only one reason to change.
  * change of the html should not require a change of other logic
  * change of the transfer protocol (http -> https) should not require ...
  * ...
* no clear border

see split between communication and content interpretation

## OCP - Open/Closed Principle 

* Software entities (classes, modules, functions, etc.) should be open for extension, but closed for modification.
  * Can I extend this code and add more functionality without modifying the original code in any way.

CommandLineArgumentHandler loads filters based on command line parameters.
see DefaultArgumentHandler

## LSP - Liskov Substitution Principle

* Types can be replaced by their subtypes without altering the desirable properties of the program.
* if class A is a subtype of class B, then we should be able to replace B with A without disrupting the behavior of our program.

see: ArgumentHandler

## Interface Segregation Principle

* No client should be forced to depend on methods it does not use
    * keep interfaces small

## Dependency Inversion Principle

* High-level modules should not depend on low-level modules. Both should depend on abstractions (e.g. interfaces).
* Abstractions should not depend on details. Details (concrete implementations) should depend on abstractions.

Dependency Injection is a way to achieve Dependency Inversion
