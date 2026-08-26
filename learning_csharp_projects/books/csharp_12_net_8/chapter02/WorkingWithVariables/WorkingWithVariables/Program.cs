// See https://aka.ms/new-console-template for more information
using System.Xml;

var population = 67_000_000; // 67 million in UK.
var weight = 1.88; // in kilograms.
var price = 4.99M; // in pounds sterling.
var fruit = "Apples"; // string values use double-quotes.
var letter = 'Z'; // char values use single-quotes.
var happy = true; // Booleans can only be true or false.

var xml1 = new XmlDocument();
XmlDocument xml2 = new XmlDocument();

XmlDocument xml3 = new();   // Target-typed new expression (C# 9.0 and later).

Person kim = new();
kim.BirthDate = new (1990, 5, 23);


Console.WriteLine($"default(int) = {default(int)}");
Console.WriteLine($"default(bool) = {default(bool)}");
Console.WriteLine($"default(DateTime) = {default(DateTime)}");
Console.WriteLine($"default(string) = {default(string)}");

int number = 13;
Console.WriteLine($"number set to: {number}");
number = default;
Console.WriteLine($"number reset to its default: {number}");

class Person
{
    public DateTime BirthDate;
}