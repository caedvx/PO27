using System;
int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());
int c = int.Parse(Console.ReadLine());

if (a == 90 || b == 90 || c== 90)
{
    Console.WriteLine("Ratvinklig Triangel");
}
else if (a < 90 && b < 90 && c < 90)
{
    Console.WriteLine("Spetsig Triangel");
}
else
{
    Console.WriteLine("Trubbig Triangel");
}