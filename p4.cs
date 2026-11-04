using System;
string friendName = Console.ReadLine();
int yearDays = int.Parse(Console.ReadLine());
string[] names = new string[yearDays];
for (int i = 0; i < yearDays; i++)
{
    string currentName = Console.ReadLine();
    if (currentName.Length == friendName.Length)
    {
        names[i] = currentName;
    }
}
for (int i = 0; i < yearDays; i++)
{
    string name = names[i];
    int nameDistance = 0;
    int daysUntilName = i + 1;
    if (name != null)
    {
        for (int j = 0; j < friendName.Length; j++)
            {
                if (friendName[j] != name[j])
                {
                    nameDistance++;
                }
            }
    }
    else
    {
        continue;
    }
    if (nameDistance <= 1)
    {
        Console.WriteLine(daysUntilName);
        break;
    }
}