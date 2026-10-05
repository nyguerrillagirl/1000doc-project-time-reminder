using System.Linq.Expressions;
using static System.Console;

bool p = true;
bool q = false;
WriteLine($"AND | p | q ");
WriteLine($"p | {p & p,-5} | {p & q,-5} ");
WriteLine($"q | {q & p,-5} | {q & q,-5} ");
WriteLine();
WriteLine($"OR | p | q ");
WriteLine($"p | {p | p,-5} | {p | q,-5} ");
WriteLine($"q | {q | p,-5} | {q | q,-5} ");
WriteLine();
WriteLine($"XOR | p | q ");
WriteLine($"p | {p ^ p,-5} | {p ^ q,-5} ");
WriteLine($"q | {q ^ p,-5} | {q ^ q,-5} ");


static bool DoStuff()
{   WriteLine("Doing stuff");
    return true;
}

WriteLine();
// Note that DoStuff() returns true.
WriteLine($"p & DoStuff() = {p & DoStuff()}");
WriteLine($"q & DoStuff() = {q & DoStuff()}");

WriteLine();
// Note that DoStuff() returns true.
WriteLine($"p && DoStuff() = {p && DoStuff()}");
WriteLine($"q && DoStuff() = {q && DoStuff()}");

WriteLine();
int x = 10;
int y = 6;
WriteLine($"Expression | Decimal | Binary");
WriteLine($"-------------------------------");
WriteLine($"x | {x,7} | {x:B8}");
WriteLine($"y | {y,7} | {y:B8}");
WriteLine($"x & y | {x & y,7} | {x & y:B8}");
WriteLine($"x | y | {x | y,7} | {x | y:B8}");
WriteLine($"x ^ y | {x ^ y,7} | {x ^ y:B8}");
