using System;
int entries = int.Parse(Console.ReadLine());
int money = 0;
for (int i = 0; i < entries; i++)
{
    string disregard = Console.ReadLine();
    int entryValue = int.Parse(Console.ReadLine());
    money += entryValue;
}
if (money > 0)
{
    Console.WriteLine("Usch, vinst");
}
else if (money == 0)
{
    Console.WriteLine("Lagom");
}
else
{
    Console.WriteLine("Nekad");
}