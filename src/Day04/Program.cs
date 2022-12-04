


string[] input = System.IO.File.ReadAllLines(@"input.txt");

int partOneAnswer = 0;
int partTwoAnswer = 0;
int lineCounter = 0;

foreach (string line in input) {
    
    string[] pairs = line.Split(',');
    string[] hiLowLeft = pairs[0].Split('-');
    string[] hiLowRight = pairs[1].Split('-');

    int leftLow = Int32.Parse(hiLowLeft[0]);
    int leftHigh = Int32.Parse(hiLowLeft[1]);
    int rightLow = Int32.Parse(hiLowRight[0]);
    int rightHigh = Int32.Parse(hiLowRight[1]);

    if(
        leftLow <= rightLow && leftHigh >= rightHigh || 
        rightLow <= leftLow && rightHigh >= leftHigh
    ) {
        partOneAnswer++;
    }
    if(leftHigh < rightLow || leftLow > rightHigh) {
        //dont overlap so..
    } else {
        partTwoAnswer++;
    }

    lineCounter++;
}

Console.WriteLine("Answer Part one:  {0}", partOneAnswer);
Console.WriteLine("Answer Part one:  {0}", partTwoAnswer);

