// 01.Mission to Mars




// quantities of the daily solar energy 
Stack<int> energies = new Stack<int>(  // queue correct?
    Console.ReadLine()
        .Split(", ")
        .Select(int.Parse)
);

// daily distances 
Queue<int> distances = new Queue<int>(   // stack correct?
    Console.ReadLine()
        .Split(", ")
        .Select(int.Parse)
);

string[] resourceName = new string[]
{
    "Iron",
    "Titanium",
    "Aluminium",
    "Chlorine",
    "Sulfur"
};


int[] resources = new[]
{
    80,   // Iron
    90,   // Titanium
    100,  // Aluminium
    60,   // Chlorine
    70    // Sulfur
};
int resourceIndex = 0;

bool[] resourcesCollected = new bool[]
{
    false,
    false,
    false,
    false,
    false
};

List<string> resourceCollectedNames = new List<string>();

bool collectedAllResources = false;

//bool missionOver = false;
//bool missionEnd = false;

for (int day = 1; day <= 7; day++)
{
    int energy = energies.Peek();
    int distance = distances.Peek();


    int sum = energy + distance;


    if (sum >= resources[resourceIndex])
    {
        resourcesCollected[resourceIndex] = true;
        resourceCollectedNames.Add(resourceName[resourceIndex]);

        energies.Pop();
        distances.Dequeue();

        resourceIndex++;
    }
    else  // sum < resources[resourceIndex]
    {
        energies.Pop();
        distances.Dequeue();
    }



    collectedAllResources = resourcesCollected.All(b => b.Equals(true));
    if (collectedAllResources)
    {
        break;
    }

    if (energies.Count < 1 && distances.Count < 1)
    {
        break;
    }


}





// print whether it managed
if (collectedAllResources)
{
    Console.WriteLine("Mission complete! All minerals have been collected.");
}
else
{
    Console.WriteLine("Mission not completed! Awaiting further instructions from Earth.");
}



// print resources if any
if (resourceCollectedNames.Count > 0)
{
    Console.WriteLine("Collected resources:");
    foreach (string resourceCollectedName in resourceCollectedNames)
    {
        Console.WriteLine(resourceCollectedName);
    }
}

