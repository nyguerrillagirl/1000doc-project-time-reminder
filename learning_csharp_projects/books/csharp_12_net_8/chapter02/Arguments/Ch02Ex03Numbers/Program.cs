using System.Runtime.InteropServices;

string line = new string('-', 140);
Console.WriteLine(line);
Console.WriteLine("{0,-10} {1,-20} {2,45} {3,45}", "Type", "Byte(s) of memory", "Min", "Max");
Console.WriteLine(line);
Console.WriteLine("{0,-10} {1,-20} {2,45} {3,45}",
    "sbyte",
    sizeof(sbyte),
    sbyte.MinValue,
    sbyte.MaxValue);
Console.WriteLine("{0,-10} {1,-20} {2,45} {3,45}",
    "byte",
    sizeof(byte),
    byte.MinValue,
    byte.MaxValue);
// short
Console.WriteLine("{0,-10} {1,-20} {2,45} {3,45}",
    "short",
    sizeof(short),
    short.MinValue,
    short.MaxValue);
//ushort
Console.WriteLine("{0,-10} {1,-20} {2,45} {3,45}",
    "ushort",
    sizeof(ushort),
    ushort.MinValue,
    ushort.MaxValue);
//int intValue;
Console.WriteLine("{0,-10} {1,-20} {2,45} {3,45}",
    "int",
    sizeof(int),
    int.MinValue,
    int
    .MaxValue);
//uint uintValue;
Console.WriteLine("{0,-10} {1,-20} {2,45} {3,45}",
    "uint",
    sizeof(uint),
    uint.MinValue,
    uint.MaxValue);
//long longValue;
Console.WriteLine("{0,-10} {1,-20} {2,45} {3,45}",
    "long",
    sizeof(long),
    long.MinValue,
    long.MaxValue);
//ulong ulongValue;
Console.WriteLine("{0,-10} {1,-20} {2,45} {3,45}",
    "ulong",
    sizeof(ulong),
    ulong.MinValue,
    ulong.MaxValue);
//Int128 int128Value;
Console.WriteLine("{0,-10} {1,-20} {2,45} {3,45}",
    "Int128",
    Marshal.SizeOf<Int128>(),
    Int128.MinValue,
    Int128.MaxValue);
//UInt128 uint128Value;
Console.WriteLine("{0,-10} {1,-20} {2,45} {3,45}",
    "UInt128",
    Marshal.SizeOf<UInt128>(),
    UInt128.MinValue,
    UInt128.MaxValue);
//Half halfValue;
Console.WriteLine("{0,-10} {1,-20} {2,45} {3,45}",
    "Half",
    Marshal.SizeOf<Half>(),
    Half.MinValue,
    Half.MaxValue);
//float floatValue;
Console.WriteLine("{0,-10} {1,-20} {2,45} {3,45}",
    "float",
    sizeof(float),
    float.MinValue,
    float.MaxValue);
//double doubleValue;
Console.WriteLine("{0,-10} {1,-20} {2,45} {3,45}",
    "double",
    sizeof(double),
    double.MinValue,
    double.MaxValue);
//decimal decimalValue;
Console.WriteLine("{0,-10} {1,-20} {2,45} {3,45}",
    "decimal",
    sizeof(decimal),
    decimal.MinValue,
    decimal.MaxValue);