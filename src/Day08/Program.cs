string[] forestScan = System.IO.File.ReadAllLines(@"input.txt");

Dictionary<string, int> sceneryScore = new Dictionary<string, int>();

int forestWidth = forestScan[0].Length-1;
int forestLength = forestScan.Count()-1;

int visibleTrees = 0;

for(int x=0;x<=forestLength;x++) {
    for(int y=0;y<=forestWidth;y++) {

        if(isBorder(x,y)) {
            visibleTrees++;
            Console.Write("{0}",forestScan[x][y]);
        } else {
            if(scan(x,y,x-1,y,-1,0) || scan(x,y,x+1,y,1,0) || scan(x,y,x,y+1,0,1) || scan(x,y,x,y-1,0,-1)) {
                Console.Write("{0}",forestScan[x][y]);
                visibleTrees++;
            } else {
                Console.Write("{0}","-");
            }

            int treeScore = sceneryScan(x,y,x-1,y,-1,0,1)*
                            sceneryScan(x,y,x+1,y,1,0,1)*
                            sceneryScan(x,y,x,y+1,0,1,1)*
                            sceneryScan(x,y,x,y-1,0,-1,1);
            
            sceneryScore[ x + "_" + y] = treeScore;

        }

    }

    Console.WriteLine("");
}

int highestSceneryScore = 0; 

foreach(KeyValuePair<string, int> kvp in sceneryScore.ToArray()) {   
    if(kvp.Value > highestSceneryScore)
        highestSceneryScore = kvp.Value;
}

Console.WriteLine("Answer Part One: {0} ", visibleTrees);
Console.WriteLine("Answer Part Two: {0} ", highestSceneryScore);

int sceneryScan(int currentX, int currentY, int scanX, int scanY, int directionX, int directionY,int score) {

     if(isBorder(scanY-directionY, scanX-directionX)) {
        return score-1;
    }

    if(forestScan[currentX][currentY]>forestScan[scanX][scanY]) {
        return sceneryScan(currentX, currentY, scanX+directionX, scanY+directionY, directionX, directionY, score+1);
    } else {
        return score;
    }

}

bool scan(int currentX, int currentY, int scanX, int scanY, int directionX, int directionY) {
    
    if(isBorder(scanY-directionY, scanX-directionX)) {
        return true;
    }

    if(forestScan[currentX][currentY]>forestScan[scanX][scanY]) {
        return scan(currentX, currentY, scanX+directionX, scanY+directionY, directionX, directionY);
    } else {
        return false;
    }
   
}

bool isBorder(int y, int x) {
    if(y == 0 || x == 0 || y == forestWidth || x == forestLength)
        return true;
    return false;
}
