string[] input = System.IO.File.ReadAllLines(@"input.txt");

foreach(string line in input) {

    int partOneMarker = findMarker(line, 4);
    Console.WriteLine("Answer Part One - Marker pos: {0}", partOneMarker);

    int partTwoMarker = findMarker(line, 14);
    Console.WriteLine("Answer Part Two - Marker pos: {0}", partTwoMarker);

}

int findMarker(string datastream, int markerLength) {
    
    int markerPos = 0;
    for(int i=0;i<datastream.Length;i++) {
        if(isMarker(datastream.Substring(i,markerLength))) {
            markerPos = i + markerLength;
            break;
        }
    }

    return markerPos;
}

bool isMarker(string data) {

    int count = 0;
    
    foreach(char i in data) {    
        foreach(char j in data) {
            if(i.Equals(j))
                count ++;   
        }
    }

    if(count > data.Length) {
        return false;
    } else {
        return true;
    }

}