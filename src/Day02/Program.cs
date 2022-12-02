


string[] lines = System.IO.File.ReadAllLines(@"input.txt");
List<int> roundScores = new List<int>();

int competitionScore = 0;
int roundCounter = 1;

//for each round
foreach (string roundData in lines) {
    int roundScore = getRoundScore(roundData);    
    competitionScore = competitionScore + roundScore;
    //Console.WriteLine("Round:{2} score:{0} and match score so far: {1}",roundScore,competitionScore,roundCounter);
    roundCounter++;
}

Console.WriteLine("Answer part one: {0}", competitionScore);

static int getRoundScore(string match) {

    // Rock beats Scissors
    // Paper beats Rock
    // Scissors beats Paper

    // A = Rock
    // B = Paper
    // C = Scissors

    // X = Rock
    // Y = Paper
    // Z = Scissors

    // X = 1 point for selecting rock
    // Y = 2 point for selecting paper
    // Z = 3 point for selecting scissors

    // 0 points if you lost
    // 3 points if you draw
    // 6 points if you win

    switch (match)
    {
        case "A X":
        // A = X Draw (1+3)
            return 4; 
        case "B Y":
        // B = Y Draw (2+3)
            return 5;
        case "C Z":
        // C = Z Draw (3+3)
            return 6;
        case "A Y":
        // A < Y = Win (2+6)
            return  8;
        case "B Z":
        // B < Z = Win (3+6)
            return 9;
        case "C X":
        // C < X = Win (1+6)
            return 7;
        case "A Z":
        // A > Z = Loss (3)
            return 3;
        case "B X":
        // B > X = Loss (1)
            return 1;
        case "C Y":
        // C > Y = Loss (2)
            return 2;

        default:
            return 0;
    }

}

competitionScore = 0;
roundCounter = 1;

//for each round

foreach (string roundData in lines) {

    int roundScore = getRoundScorePartTwo(roundData);    
    competitionScore = competitionScore + roundScore;
    //Console.WriteLine("Round:{2} score:{0} and match score so far: {1}",roundScore,competitionScore,roundCounter);
    roundCounter++;
}

Console.WriteLine("Answer part two: {0}", competitionScore);


static int getRoundScorePartTwo(string match) {

    // Rock beats Scissors
    // Paper beats Rock
    // Scissors beats Paper

    // A = Rock
    // B = Paper
    // C = Scissors

    // Y = Draw
    // X = Loose
    // Z = Win

    // 1 point for selecting rock
    // 2 point for selecting paper
    // 3 point for selecting scissors

    // 0 points if you lost
    // 3 points if you draw
    // 6 points if you win

    switch (match)
    {
        case "A X":
        // A > X Loose with Scissors
            return 3;
        case "B X":
        // B > X Loose with Rock
            return 1;
        case "C X":
        // C > X Loose with Paper
            return 2;
        case "A Z":
        // A < Z = Win with Paper
            return 8;
        case "B Z":
        // B < Z = Win with Scissors
            return 9;
        case "C Z":
        // C < Z Win with Rock
            return 7;
        case "A Y":
        // A = Y = Draw with Rock
            return 4;
        case "B Y":
        // B = Y Draw with Paper
            return 5;
        case "C Y":
        // C = Y = Draw with Scissors
            return 6;

        default:
            return 0;
    }

}