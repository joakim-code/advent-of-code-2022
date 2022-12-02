
        string[] lines = System.IO.File.ReadAllLines(@"input.txt");
        List<int> allElfCalories = new List<int>();
        int countedCalories = 0;

        foreach (string line in lines) {
            
            try {
                int calorie = Convert.ToInt32(line);
                countedCalories = countedCalories + calorie;
                
            }
            catch (FormatException) {
                Console.WriteLine("Input string is not a sequence of digits.");
            }
            catch (OverflowException) {
                Console.WriteLine("The number cannot fit in an Int32.");
            }
            Console.WriteLine(countedCalories);
            if(line.Equals("")) {
                allElfCalories.Add(countedCalories);
                countedCalories = 0;
            }

        }

        allElfCalories.Sort();

        foreach(int elfCalorie in allElfCalories) {
            Console.WriteLine("Elf Calory count: {0}" , elfCalorie);
        }

        int count = allElfCalories.Count;

        int top3Elfs = allElfCalories[allElfCalories.Count-1]+allElfCalories[allElfCalories.Count-2]+allElfCalories[allElfCalories.Count-3];

        Console.WriteLine("Check last elf: {0} ", allElfCalories[allElfCalories.Count-1]);
        Console.WriteLine(top3Elfs);
        
        System.Console.ReadKey();
