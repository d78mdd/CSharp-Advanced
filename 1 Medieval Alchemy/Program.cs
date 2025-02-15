
Stack<int> substances = new Stack<int>(
    Console.ReadLine()
    .Split(", ")
    .Select(int.Parse)
    );

Queue<int> crystals = new Queue<int>(
    Console.ReadLine()
    .Split(", ")
    .Select(int.Parse)
    );




int brewOfImmortality = 110;
int essenceOfResilience = 100;
int draughtOfWisdom = 90;
int potionOfAgility = 80;
int elixirOfStrength = 70;

List<int> potions = new List<int>() { 110, 100, 90, 80, 70 };

bool brewOfImmortalityCrafted = false;
bool essenceOfResilienceCrafted = false;
bool draughtOfWisdomCrafted = false;
bool potionOfAgilityCrafted = false;
bool elixirOfStrengthCrafted = false;

List<string> craftedPotions = new List<string>();

for (; ; )
{



    int crystal = crystals.Peek();
    int substance = substances.Peek();

    int sum = crystal + substance;

    bool sumWasEnough = false;

    if (potions.Contains(sum))
    {
        potions.Remove(sum);

        if (sum == 110 && !brewOfImmortalityCrafted)
        {
            brewOfImmortalityCrafted = true;
            craftedPotions.Add(item: "Brew of Immortality");
        }
        else if (sum == 100 && !essenceOfResilienceCrafted)
        {
            essenceOfResilienceCrafted = true;
            craftedPotions.Add("Essence of Resilience");
        }
        else if (sum == 90 && !draughtOfWisdomCrafted)
        {
            draughtOfWisdomCrafted = true;
            craftedPotions.Add("Draught of Wisdom");
        }
        else if (sum == 80 && !potionOfAgilityCrafted)
        {
            potionOfAgilityCrafted = true;
            craftedPotions.Add("Potion of Agility");
        }
        else if (sum == 70 && !elixirOfStrengthCrafted)
        {
            elixirOfStrengthCrafted = true;
            craftedPotions.Add("Elixir of Strength");
        }

        substances.Pop();
    }
    else // sum does not exactly match
    {
        // already sorted by value descending
        foreach (int potion in potions)
        {
            if (sum > potion)
            {
                substances.Pop();

                if (potion == 110 && !brewOfImmortalityCrafted)
                {
                    brewOfImmortalityCrafted = true;
                    craftedPotions.Add(item: "Brew of Immortality");
                }
                else if (potion == 100 && !essenceOfResilienceCrafted)
                {
                    essenceOfResilienceCrafted = true;
                    craftedPotions.Add("Essence of Resilience");
                }
                else if (potion == 90 && !draughtOfWisdomCrafted)
                {
                    draughtOfWisdomCrafted = true;
                    craftedPotions.Add("Draught of Wisdom");
                }
                else if (potion == 80 && !potionOfAgilityCrafted)
                {
                    potionOfAgilityCrafted = true;
                    craftedPotions.Add("Potion of Agility");
                }
                else if (potion == 70 && !elixirOfStrengthCrafted)
                {
                    elixirOfStrengthCrafted = true;
                    craftedPotions.Add("Elixir of Strength");
                }

                if (substances.Count > 0)
                {
                    int nextSubstance = substances.Pop();
                    nextSubstance += (sum - potion) * 2;
                    substances.Push(nextSubstance);
                }

                sumWasEnough = true;

                break;
            }
        }

        // no potion with an energy less than the combined energy(sum)
        if (!sumWasEnough)
        {
            substances.Pop();
        }
    }

    //The crystal is always returned to the back of the sequence with zero energy
    crystals.Dequeue();
    crystals.Enqueue(0);



    if (brewOfImmortalityCrafted && essenceOfResilienceCrafted &&
    draughtOfWisdomCrafted && potionOfAgilityCrafted &&
    elixirOfStrengthCrafted)
    {
        break;
    }

    if (substances.Count == 0)
    {
        break;
    }



    // all crystals in the sequence are recovered by 5 units
    for (int i = 0; i < crystals.Count; i++)
    {
        var cr = crystals.Dequeue();

        cr += 5;

        crystals.Enqueue(cr);
    }
}


if (brewOfImmortalityCrafted && essenceOfResilienceCrafted &&
    draughtOfWisdomCrafted && potionOfAgilityCrafted &&
    elixirOfStrengthCrafted)
{
    Console.WriteLine("Success! The alchemist has forged all potions!");
}
else // not all
{
    Console.WriteLine("The alchemist failed to complete his quest.");
}

if (brewOfImmortalityCrafted || essenceOfResilienceCrafted ||
    draughtOfWisdomCrafted || potionOfAgilityCrafted ||
    elixirOfStrengthCrafted)
{
    Console.Write("Crafted potions: ");

    string allCraftedPotionsString = string.Join(", ", craftedPotions);

    Console.WriteLine(allCraftedPotionsString);

}

if (substances.Count > 0)
{
    Console.Write("Substances: ");

    string substancesString = string.Join(", ", substances);

    Console.WriteLine(substancesString);
}


if (crystals.Count > 0)
{
    Console.Write("Crystals: ");

    string crystalsString = string.Join(", ", crystals);

    Console.WriteLine(crystalsString);
}
