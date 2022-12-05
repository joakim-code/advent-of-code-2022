string[] input = System.IO.File.ReadAllLines(@"input.txt");

var stacksOfBoxes = new List<LinkedList<char>>();

int lineCounter = 0;

foreach(string line in input) {

    //load the stacks
    if(lineCounter < 8) {
        //9 boxes pr line
        int stackCounter=0;
        for(int pos=1;pos <= line.Length;pos=pos+4,stackCounter++) {

            if(stackCounter >= stacksOfBoxes.Count)
                stacksOfBoxes.Add(new LinkedList<char>());
            
            if(!Char.IsWhiteSpace(line[pos]))
                stacksOfBoxes[stackCounter].AddFirst(line[pos]);
        }

    //move things around
    } else if(lineCounter > 9) {
        
        string[] moveInstructions = line.Split(" ");
    
        int howMuchToMove = Int32.Parse(moveInstructions[1]);
        int moveFrom = Int32.Parse(moveInstructions[3]);
        int moveTo = Int32.Parse(moveInstructions[5]);

        for(;howMuchToMove>0;howMuchToMove--) {

            char box = stacksOfBoxes[moveFrom-1].Last();
            stacksOfBoxes[moveTo-1].AddLast(box);
            stacksOfBoxes[moveFrom-1].RemoveLast();

        }
        
    } 

    lineCounter++;
}

//Answer part one
Console.Write("Answer part one: ");

foreach (var stack in stacksOfBoxes) {
    Console.Write("{0}", stack.Last());
}
Console.WriteLine("");

var secondStackOfBoxes = new List<List<char>>();
lineCounter = 0;

foreach(string line in input) {

    //load the stacks
    if(lineCounter < 8) {
        //9 boxes pr line
        int stackCounter=0;
        for(int pos=1;pos <= line.Length;pos=pos+4,stackCounter++) {

            if(stackCounter >= secondStackOfBoxes.Count)
                secondStackOfBoxes.Add(new List<char>());
            
            if(!Char.IsWhiteSpace(line[pos]))
                secondStackOfBoxes[stackCounter].Insert(0,line[pos]);
        }

    //move things around
    } else if(lineCounter > 9) {
        
        string[] moveInstructions = line.Split(" ");
    
        int howMuchToMove = Int32.Parse(moveInstructions[1]);
        int moveFrom = Int32.Parse(moveInstructions[3]);
        int moveTo = Int32.Parse(moveInstructions[5]);

        int lastBox = secondStackOfBoxes[moveFrom-1].Count();
        List<char> boxes = secondStackOfBoxes[moveFrom-1].GetRange(lastBox-howMuchToMove,howMuchToMove);
        secondStackOfBoxes[moveTo-1].AddRange(boxes);
        secondStackOfBoxes[moveFrom-1].RemoveRange(lastBox-howMuchToMove,howMuchToMove);
    } 
    lineCounter++;
}

//Answer part two
Console.Write("Answer part two: ");

foreach (var stack in secondStackOfBoxes) {
    Console.Write("{0}", stack.Last());
}
Console.WriteLine("");
