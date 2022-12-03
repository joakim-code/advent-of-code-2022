
// Priority points
string points = "-abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

//a-z = 1-26
//A-Z = 27-52

string[] input = System.IO.File.ReadAllLines(@"input.txt");

string[] partOneTestInput = System.IO.File.ReadAllLines(@"testinput.txt");

int partOneTestScore = 0;

//for each round
foreach (string rucksack in partOneTestInput) {

    //split compartment in two
    int compartmentSize = rucksack.Length/2;

    var compartments = rucksack.Chunk(compartmentSize)
        .Select(x => new string(x))
        .ToList();

    foreach(char itemType in compartments[0]) {
        if(compartments[1].Contains(itemType)) {
            //check score
            partOneTestScore = partOneTestScore + points.IndexOf(itemType);
            break;
        }
    }

}
//sum should be 157
Console.WriteLine("Total test score: {0} ", partOneTestScore);

int partOneScore = 0;

//for each round
foreach (string rucksack in input) {

    //split compartment in two
    int compartmentSize = rucksack.Length/2;

    var compartments = rucksack.Chunk(compartmentSize)
        .Select(x => new string(x))
        .ToList();

    foreach(char itemType in compartments[0]) {
        if(compartments[1].Contains(itemType)) {
            //check score
            partOneScore = partOneScore + points.IndexOf(itemType);
            break;
        }
    }
}

Console.WriteLine("Answer part one: {0} ", partOneScore);

string[] partTwoTestInput = System.IO.File.ReadAllLines(@"testinputparttwo.txt");
int partTwoTestScore = 0;

for(int i=0;i<partTwoTestInput.Count();i=i+3) {
    foreach(char itemType in partTwoTestInput[i]) {
        if(partTwoTestInput[i+1].Contains(itemType)) {
            if(partTwoTestInput[i+2].Contains(itemType)) {
                //check score
                partTwoTestScore = partTwoTestScore + points.IndexOf(itemType);
                break;
            }
        }
    }
}


//sum should be 70
Console.WriteLine("Part two testing score: {0}",partTwoTestScore);

int partTwoScore = 0;

for(int i=0;i<input.Count();i=i+3) {
    foreach(char itemType in input[i]) {
        if(input[i+1].Contains(itemType)) {
            if(input[i+2].Contains(itemType)) {
                //check score
                partTwoScore = partTwoScore + points.IndexOf(itemType);
                break;
            }
        }
    }
}

Console.WriteLine("Answer part one: {0}", partTwoScore);