var animals = new Animal?[]
{
    new Cat { Name = "Karen", Born = new DateTime(2022, 8, 23), Legs = 4, IsDomestic = true },
    new Cat { Name = "Mufasa", Born = new DateTime(1994, 6, 12) },
    new Spider { Name = "Sid Vicious", Born = DateTime.Today, IsPoisonous = true },
    new Spider { Name = "Captain Furry", Born = DateTime.Today }
};

foreach (Animal? animal in animals)
{
    string message;

    switch (animal)
    {
        case Cat fourLeggedCat when fourLeggedCat.Legs == 4:
            message = $"The cat {fourLeggedCat.Name} has four legs.";
            break;
        case Cat wildCat when wildCat.IsDomestic == false:
            message = $"The cat {wildCat.Name} is not domestic.";
            break;
        case Cat cat:
            message = $"The cat is named {cat.Name}.";
            break;
        default: // default is always evaluated last.
            message = $"{animal?.Name} is a {animal?.GetType().Name}.";
            break;
        case Spider spider when spider.IsPoisonous:
            message = $"The spider {spider.Name} is poisonous. Run!";
            break;
        case null:
            message = "The animal is null.";
            break;
    }
    Console.WriteLine($"switch statement: {message}");

    message = animal switch
    {
        Cat fourLeggedCat when fourLeggedCat.Legs == 4
            => $"The cat named {fourLeggedCat.Name} has four legs.",
        Cat wildCat when wildCat.IsDomestic == false
            => $"The non-domestic cat is named {wildCat.Name}",
        Cat cat
            => $"The cat is named {cat.Name}.",
        Spider spider when spider.IsPoisonous
            => $"The {spider.Name} spider is poisonous. Run!",
        null
            => "The animal is null.",
        _
            => $"{animal.Name} is a {animal.GetType().Name}."
    };
    Console.WriteLine($"switch expression: {message}");
}