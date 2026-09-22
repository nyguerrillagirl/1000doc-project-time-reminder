int x = 5;
int postfixIncrement = x++;
Console.WriteLine("after postfix increment x: " + x);
int prefixIncrement = ++x;
Console.WriteLine("after prefix increment x: " + x);

Type theTypeOfInteger = typeof(int);
Console.WriteLine("The type of integer is: " + theTypeOfInteger);

string nameOfVariable = nameof(x);
Console.WriteLine("The name of the variable is: " + nameOfVariable);

int howManyBytesInAnInteger = sizeof(int);
Console.WriteLine("The number of bytes in an integer is: " + howManyBytesInAnInteger);

