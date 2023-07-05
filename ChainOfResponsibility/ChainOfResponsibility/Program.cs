using ChainOfResponsibility.Models;
using ChainOfResponsibility.Models.Derived;

Human human = new User("", "emin@emin.com", "supermanemin");
CheckerDirector director = new();
var validUser = director.MakeHumanChecker(human);
Console.WriteLine(validUser ? "Valid user" : "Invalid User");