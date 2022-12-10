string[] input = System.IO.File.ReadAllLines(@"input.txt");

Dictionary<string, int> directories = new Dictionary<string, int>();

int directorySize = 0;
int usedSpace = 0;
int directoryToDeleteSize = 0;

string currentPath = "";

foreach(string line in input) {

    if(line.StartsWith("$")) {
        currentPath = runCommand(line.Substring(2), currentPath);
    } else if(line.StartsWith("dir")) {
        //ignore
    } else {
        addFile(currentPath, line);
    }

}

foreach(KeyValuePair<string,int> directory in directories.ToList()) {
    
    if(directory.Value <= 100000) {
        directorySize = directorySize + directory.Value;
    }

    //only count root folders for used space
    if(directory.Key.Split("/").Count() == 2) {
        usedSpace = usedSpace + directory.Value;
    }

}

Console.WriteLine("Used space: {0}", usedSpace);

int updateSize = 30000000;
int totalDiskSpace = 70000000;
int freeSpace = totalDiskSpace - usedSpace;
int neededSpace = updateSize - freeSpace;

Console.WriteLine("Total space: {0}", totalDiskSpace);
Console.WriteLine("Free space: {0}", freeSpace);
Console.WriteLine("Space that needs to be freed up: {0}", neededSpace);

foreach(KeyValuePair<string,int> directory in directories.ToList()) {
    
    if(directory.Value > neededSpace) {
        //Console.WriteLine("{0} - {1} - {2} - {3}", directory.Key, directory.Value, directoryToDeleteSize, neededSpace);
        //Console.ReadKey();
        if(directoryToDeleteSize == 0)
            directoryToDeleteSize = directory.Value;        
        if(directoryToDeleteSize > directory.Value)
            directoryToDeleteSize = directory.Value;
    }
    
}

Console.WriteLine("Answer part one: {0}", directorySize);
Console.WriteLine("Answer part two: {0}",directoryToDeleteSize);


string runCommand(string command, string currentPath) {

    switch (command)
    {
        case "cd /":
            return "/";
        case "ls":
            return currentPath;
        case "cd ..":
            return moveOut(currentPath);
        default:
            return moveIn(command, currentPath);
    }
    
} 

string moveOut(string currentPath) {
    string[] splitPath = currentPath.Split("/");
    return currentPath.Substring(0, currentPath.Length-splitPath[splitPath.Count()-2].Length-1);
}

string moveIn(string command,string currentPath) {
    return currentPath + command.Split(" ").ElementAt(1) + "/";
}

void addFile(string path, string file) {

    int fileSize = Int32.Parse(file.Split(" ")[0]);

    string[] splitPath = path.Split("/");
    
    if(splitPath.Count() > 2) {
        addFile(moveOut(path),file);
    }
    
    int oldValue = directories.GetValueOrDefault(path, 0);
    directories[path] = oldValue+fileSize;
    
}
