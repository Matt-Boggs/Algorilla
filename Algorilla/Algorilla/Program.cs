using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Algorilla
{
    interface ISpeak
    {
        public void Yell()
        {

        }
    }
    class Boggs : ISpeak
    {
        
        public string height { get; set; }
        public void Yello()
        {
            Console.WriteLine("ANYBODY WANT A PEANUT?");
        }
    }
    class Program 
    {
        public static void Main(string[] args)
        {
            {

                //Console.WriteLine(Factorial(158));
                //Console.WriteLine(ProperFractions(5));
                //string stats = "01|15|59, 1|47|16, 01|17|20, 1|32|34, 2|17|17";
                //Console.WriteLine(Stat(stats));

                //int[,] maze = new int[,] { { 1, 1, 1, 1, 1, 1, 1 },
                //                           { 1, 0, 0, 0, 0, 0, 3 },
                //                           { 1, 0, 1, 0, 1, 0, 1 },
                //                           { 0, 0, 1, 0, 0, 0, 1 },
                //                           { 1, 0, 1, 0, 1, 0, 1 },
                //                           { 1, 0, 0, 0, 0, 0, 1 },
                //                           { 1, 2, 1, 0, 1, 0, 1 } };
                //string[] directions = new string[] { "N", "N", "N", "N", "N", "E", "E", "E", "E", "E" };
                //string[] directions = new string[] { "N", "N", "N", "W", "W" };
                //string[] directions = new string[] { "N", "N", "N", "N", "N", "E", "E", "S", "S", "S", "S", "S", "S" };
                //string[] directions = new string[] { "N", "N", "N", "N", "N", "E", "E", "E", "E", "E", "W", "W" };
                //Console.WriteLine(mazeRunner(maze, directions));

                //MultiplicationTable(3);

                //int[] a = { 1, 2, 2, 3, 8 };
                //int[] b = { 2 };
                //ArrayDiff(a,b);
                //string[] empty = new string[0];
                //string[] oneLike = { "Peter" };
                //string[] twoLike = { "Jacob", "Alex" };
                //string[] threeLike = { "Max", "John", "Mark" };
                //string[] fourLike = { "Alex", "Jacob", "Mark", "Max" };
                //Console.WriteLine(Likes(fourLike));
                //string order = "milkshakepizzachickenfriescokeburgerpizzasandwichmilkshakepizza";
                //GetOrder(order);

                //var arr = new int[] { 12, 10, 8, 12, 7, 6, 4, 10, 12 };
                //HighestRank(arr);

                //string[] a = new string[] { "NORTH", "SOUTH", "SOUTH", "EAST", "wesT", "NORTH", "WEST" };
                //dirReduc(a);

                //TowerBuilder(10);

                //string warOne = "z*dq*maaaaaw*pb*s";
                //string warTwo = "zdqmwpbs";
                //string leftWin = "*wwwwww*z*";
                //AlphabetWar(warOne);
                //Console.WriteLine(AlphabetWar(warOne));

                //string test = "what time are we climbing up to the volcano"; // Volcano
                //HighScore(test);

                //string test = "chruschtschov";
                //Solve(test);

                //string input = "fox,bug,chicken,grass,sheep";
                //WhoEatsWho(input);
            }
            //Boggs matt = new Boggs();
            //Console.WriteLine(matt.height);
            //matt.height = "6'0";
            //Console.WriteLine(matt.height);
            //matt.Yello();
            //Mix("hi my name is matt", "hi my name is boggs");
            //int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            //CreatePhoneNumber(numbers);
            //High("Lets go down to the volcano");
        }
        public static string Factorial(int n)
        {
            long result = 1;
            for (int currentNumber = 2;currentNumber <= n; currentNumber++)
            {
                result *= currentNumber;
            }
            return $"{n}! = {result}";
        }
        public static long ProperFractions(long n)
        {
            int properCount = 0;
            if (n == 1) return properCount;
            for (int divisor = 1; divisor <= n; divisor++)
            {
                if ( (n / divisor) % 1 != 0 )
                {
                    properCount++;
                }
            }
            return properCount;
        }
        public static string Stat(string strg)
        {
           
            TimeSpan totalTime = TimeSpan.Zero;
            TimeSpan lowestTime;
            TimeSpan highestTime;

            TimeSpan range;
            string rangeString;
            TimeSpan average;
            string averageString;
            TimeSpan median;
            string medianString;

            string[] arrayOfTimesAsString = strg.Split(",");
            int amountOfStats = arrayOfTimesAsString.Length;

            List<string> listOfTimesAsString = new List<string>();
            foreach (string time in arrayOfTimesAsString) listOfTimesAsString.Add(time.Trim().Replace("|",":"));

            List<TimeSpan> listOfTimeSpans = new List<TimeSpan>();
            foreach (string time in listOfTimesAsString) listOfTimeSpans.Add(TimeSpan.Parse(time));
            listOfTimeSpans =  listOfTimeSpans.OrderBy(time => time.TotalSeconds).ToList();

            lowestTime = listOfTimeSpans[0];
            highestTime = listOfTimeSpans[listOfTimeSpans.Count - 1];
            foreach (var time in listOfTimeSpans) Console.WriteLine(time);

            foreach (var time in listOfTimeSpans)
            {
                if (time > highestTime) highestTime = time;
                if (time < lowestTime) lowestTime = time;
                totalTime += time;
            }
            range = highestTime - lowestTime;
            rangeString = range.ToString().Replace(":","|");

            average = totalTime / amountOfStats;
            averageString = average.ToString().Replace(":","|");
            if (average.Milliseconds > 0) averageString = averageString.Remove(averageString.IndexOf("."));

            int middleIndex = Convert.ToInt32(Math.Ceiling((double)(listOfTimeSpans.Count / 2)));
            if (amountOfStats % 2 == 0) median = (listOfTimeSpans[middleIndex] + listOfTimeSpans[middleIndex+1] ) / 2;
            else
            {
                median = listOfTimeSpans[middleIndex];
            }
            medianString = median.ToString().Replace(":","|");
            if (median.Milliseconds > 0) medianString = medianString.Remove(medianString.IndexOf("."));

            return $"Range: {rangeString} Average: {averageString} Median: {medianString}";
        }
        public static string mazeRunner(int[,] maze, string[] directions)
        {
            // 0: Safe to walk | 1: Wall | 2: Start Point | 3: Finish Point | Maze is always a square


            // Grab start point
            int startRow = 0;
            int startColumn = 0;
            int mazeSize = (int)Math.Sqrt(maze.Length);
            
            for(int row = 0; row <mazeSize; row++)
            {
                for (int column = 0; column < mazeSize; column++)
                {
                    if (maze[row,column] == 2)
                    {
                        startRow = row;
                        startColumn = column;
                    }
                }
            }
            // Follow directions, returning dead if hitting a wall
            int currentRow = startRow;
            int currentColumn = startColumn;
            for (int index = 0; index < directions.Length; index++)
            {
                switch (directions[index])
                {
                    
                    case "N":
                        if (currentRow == 0) return "Dead";
                        currentRow--;
                        if (maze[currentRow, currentColumn] == 1) return "Dead";
                        if (maze[currentRow, currentColumn] == 3) return "Finish";
                        break;
                    case "S":
                        if (currentRow == mazeSize - 1) return "Dead";
                        currentRow++;
                        if (maze[currentRow, currentColumn] == 1) return "Dead";
                        if (maze[currentRow, currentColumn] == 3) return "Finish";
                        break;
                    case "E":
                        if (currentColumn == mazeSize - 1) return "Dead";
                        currentColumn++;
                        if (maze[currentRow, currentColumn] == 1) return "Dead";
                        if (maze[currentRow, currentColumn] == 3) return "Finish";
                        break;
                    case "W":
                        if (currentColumn == 0) return "Dead";
                        currentColumn--;
                        if (maze[currentRow, currentColumn] == 1) return "Dead";
                        if (maze[currentRow, currentColumn] == 3) return "Finish";
                        break;
                }
            }

            // if At end point, return finish
            if (maze[currentRow, currentColumn] == 0) return "Lost";
            return "Finish";
        }
        public static int[,] MultiplicationTable(int size)
        {
            int[,] multiplicationTable = new int[size,size];
            int multiplier = 1;
            for (int row = 0; row < size; row++)
            {
                int otherMultiplier = 1;
                for (int column = 0; column < size; column++)
                {
                    multiplicationTable[row, column] = otherMultiplier * multiplier;
                    otherMultiplier++;
                    Console.WriteLine(multiplicationTable[row, column]);
                }
                multiplier++;
            }
            return multiplicationTable;
        }
        public static int[] ArrayDiff(int[] a, int[] b)
        {
            List<int> listToConvert = new List<int>();
            for (int index = 0; index < a.Length; index++)
            {
                if (!b.Contains(a[index]))
                {
                    Console.WriteLine(a[index]);
                    listToConvert.Add(a[index]);
                }
            }
            int[] finalArr = listToConvert.ToArray();
            return finalArr;
        }
        public static string Likes(string[] name)
        {
            if (name.Length == 0) return "No one likes this";
            if (name.Length == 1) return $"{name[0]} likes this";
            if (name.Length == 2) return $"{name[0]} and {name[1]} like this";
            if (name.Length == 3) return $"{name[0]}, {name[1]} and {name[2]} like this";
            if (name.Length > 3) return $"{name[0]}, {name[1]} and {name.Length - 2} others like this";
            throw new NotImplementedException();
        }
        public static string AlphabetPosition(string text)
        {
            string alphabet = " abcdefghijklmnopqrstuvwxyz";
            string returnString = "";
            foreach (char letter in text.ToLower())
            {
                returnString += alphabet.IndexOf(letter);
            }
            returnString.Replace("0"," ");
            return returnString;
        }
        public static string GetOrder(string input)
        {
            List<string> listOfOrders = new List<string>();
            string orderAsString = "";

            Regex burger = new Regex("burger");
            var burgerMatches = burger.Matches(input);
            foreach (Match match in burgerMatches) listOfOrders.Add(match.ToString());
            
            Regex fries = new Regex("fries");
            var friesMatches = fries.Matches(input);
            foreach (Match match in friesMatches) listOfOrders.Add(match.ToString());
            
            Regex chicken = new Regex("chicken");
            var chickenMatches = chicken.Matches(input);
            foreach (Match match in chickenMatches) listOfOrders.Add(match.ToString());
            
            Regex pizza = new Regex("pizza");
            var pizzaMatches = pizza.Matches(input);
            foreach (Match match in pizzaMatches) listOfOrders.Add(match.ToString());
            
            Regex sandwich = new Regex("sandwich");
            var sandwichMatches = sandwich.Matches(input);
            foreach (Match match in sandwichMatches) listOfOrders.Add(match.ToString());

            Regex onionRings = new Regex("onionrings");
            var onionRingsMatches = onionRings.Matches(input);
            foreach (Match match in sandwichMatches) listOfOrders.Add(match.ToString());

            Regex milkShake = new Regex("milkshake");
            var milkShakeMatches = milkShake.Matches(input);
            foreach (Match match in milkShakeMatches) listOfOrders.Add(match.ToString());

            Regex coke = new Regex("coke");
            var cokeMatches = coke.Matches(input);
            foreach (Match match in cokeMatches) listOfOrders.Add(match.ToString());

            foreach (var order in listOfOrders)orderAsString += order + " ";
            orderAsString = orderAsString.Trim();
            orderAsString.Replace("burger", "Burger");
            orderAsString.Replace("fries", "Fries");
            orderAsString.Replace("chicken", "Chicken");
            orderAsString.Replace("pizza","Pizza");
            orderAsString.Replace("sandwich", "Sandwich");
            orderAsString.Replace("onionrings","Onionrings");
            orderAsString.Replace("milkshake","Milkshake");
            orderAsString.Replace("coke", "Coke");
            return orderAsString;
        }
        public static int HighestRank(int[] arr)
        {
            Dictionary<int, int> rankCount = new Dictionary<int, int>();
            int highestkey = 0;
            int highestCount = 0;
            foreach(int arrayNumber in arr)
            {
                if (rankCount.ContainsKey(arrayNumber)) rankCount[arrayNumber]++;
                else rankCount.Add(arrayNumber, 1);
            }
            foreach(KeyValuePair<int,int> kvp in rankCount)
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
                if (kvp.Value > highestCount)
                {
                    highestCount = kvp.Value;
                    highestkey = kvp.Key;
                    
                }
                if (kvp.Value == highestCount && kvp.Key > highestkey) highestkey = kvp.Key;
            }
            return highestkey;
        }
        public static string[] dirReduc(String[] arr)
        {
            if (arr.Length == 1) return arr;
            List<string> listOfStrings = new List<string>();
            foreach (string direction in arr) listOfStrings.Add(direction.ToUpper());
            Console.WriteLine("   ");
            foreach (string dir in listOfStrings) Console.WriteLine(dir);
            for (int i = 1; i < listOfStrings.Count; i++)
            {
                if (listOfStrings[i] == "NORTH" && listOfStrings[i - 1] == "SOUTH")
                {
                    listOfStrings.Remove(listOfStrings[i]);
                    listOfStrings.Remove(listOfStrings[i - 1]);
                    if (listOfStrings.Count == 1) return listOfStrings.ToArray();

                    dirReduc(listOfStrings.ToArray());
                }
                else if (listOfStrings[i] == "SOUTH" && listOfStrings[i - 1] == "NORTH")
                {
                    listOfStrings.Remove(listOfStrings[i]);
                    listOfStrings.Remove(listOfStrings[i - 1]);
                    if (listOfStrings.Count == 1) return listOfStrings.ToArray();

                    dirReduc(listOfStrings.ToArray());
                }
                else if (listOfStrings[i] == "WEST" && listOfStrings[i - 1] == "EAST")
                {
                    listOfStrings.Remove(listOfStrings[i]);
                    listOfStrings.Remove(listOfStrings[i - 1]);
                    if (listOfStrings.Count == 1) return listOfStrings.ToArray();

                    dirReduc(listOfStrings.ToArray());
                }
                else if (listOfStrings[i] == "EAST" && listOfStrings[i - 1] == "WEST")
                {
                    listOfStrings.Remove(listOfStrings[i]);
                    listOfStrings.Remove(listOfStrings[i - 1]);
                    if (listOfStrings.Count == 1) return listOfStrings.ToArray();

                    dirReduc(listOfStrings.ToArray());
                }
            }
            return listOfStrings.ToArray();
        }
        public static string[] TowerBuilder(int nFloors)
        {
            List<string> listOfFloors = new List<string>();

            int padLeftNumber = nFloors -1;
            int padRightnumber = (nFloors * 2)-1;
            int starsNeeded = 1;

            for (int currentFloor = 1; currentFloor <= nFloors; currentFloor++)
            {
                string floorToAdd = "";
                for (int addNum = 0; addNum < starsNeeded; addNum++)
                {
                    floorToAdd += "*";
                }
                starsNeeded += 2;
                padLeftNumber++;

                floorToAdd = floorToAdd.PadLeft(padLeftNumber);
                floorToAdd = floorToAdd.PadRight(padRightnumber);

                listOfFloors.Add(floorToAdd);
            }
            return listOfFloors.ToArray();
        }
        public static string AlphabetWar(string fight)
        {
            Regex bombMatch = new Regex(@"\w?\*\w?");
             // w:4|p:3|b:2|s:1| LEFT SIDE
             int leftSideScore = 0;
            // m:4|q:3|d:2|z:1| RIGHT SIDE
            int rightSideScore = 0;
            // * bombs adjacent letters, replacing with underscore
            string postBomb = bombMatch.Replace(fight, "___");
            foreach(char letter in postBomb)
            {
                switch (letter)
                {
                    case 'w':
                        leftSideScore += 4;
                        break;
                    case 'p':
                        leftSideScore += 3;
                        break;
                    case 'b':
                        leftSideScore += 2;
                        break;
                    case 's':
                        leftSideScore += 1;
                        break;

                    case 'm':
                        rightSideScore += 4;
                        break;
                    case 'q':
                        rightSideScore += 3;
                        break;
                    case 'd':
                        rightSideScore += 2;
                        break;
                    case 'z':
                        rightSideScore += 1;
                        break;
                }
            }
            if (rightSideScore > leftSideScore) return "Right side wins!";
            if (leftSideScore > rightSideScore) return "Left side wins!";
            return "Let's fight again!";
        }
        public static long QueueTime(int[] customersInLine, int numberOfTills)
        {
            return 0;
        }
        public static string HighScore(string s)
        {
            string alphabet = " abcdefghijklmnopqrstuvwxyz";
            List<string> listOfWords = s.Split(" ").ToList();
            Dictionary<string, int> wordScores = new Dictionary<string, int>();
            int highscore = 0;
            string winningWord = "";

            foreach (string word in listOfWords)
            {
                if (!wordScores.ContainsKey(word)) wordScores.Add(word, 0);
                foreach(char letter in word)
                {
                    wordScores[word] += alphabet.IndexOf(letter);
                }
            }
            foreach(KeyValuePair<string,int> kvp in wordScores)
            {
                if (kvp.Value > highscore)
                {
                    highscore = kvp.Value;
                    winningWord = kvp.Key;
                }
            }

            return winningWord;
        }
        public static int Solve(string s)
        {
            string alphabet = " abcdefghijklmnopqrstuvwxyz";
            int highScore = 0;
            Regex vowels = new Regex(@"[aeiou]");
            string deVoweled = vowels.Replace(s, " ");
            Console.WriteLine(deVoweled);
            List<string> listOfWords = deVoweled.Split(" ").ToList();
            foreach (string word in listOfWords)
            {
                int currentScore = 0;
                foreach(char letter in word)
                {
                    currentScore += alphabet.IndexOf(letter);

                }
                if (currentScore > highScore) highScore = currentScore;
            }
            return highScore;
        }
        public static int DuplicateCount(string str)
        {
            Dictionary<char, int> duplicates = new Dictionary<char, int>();
            int countOfDuplicates = 0;
            foreach(char letter in str.ToLower())
            {
                if (!duplicates.ContainsKey(letter)) duplicates.Add(letter, 1);
                else duplicates[letter]++;
            }
            foreach(KeyValuePair<char,int> keyValuePair in duplicates)
            {
                if (keyValuePair.Value > 1) countOfDuplicates++;
            }
            return countOfDuplicates;
        }
        // Keep it going with the algorithms, learning the software, getting better at setting things up. Memorization plays a part, but I'm aiming for deeper understanding of the concepts
        public static string[] WhoEatsWho(string zoo)
        {

            List<string> listOfAnimals = zoo.Split(",").ToList();
            List<string> finalList = new List<string>();
            finalList.Add(zoo);
            string previousAnimal = "";
            string nextAnimal = "";
            for (int index = 0; index < listOfAnimals.Count; index++)
            {
                Console.WriteLine(listOfAnimals[index]);
                switch (listOfAnimals[index])
                {
                    case "antelope":
                        if (index == 0)
                        {
                            previousAnimal = "";
                            nextAnimal = listOfAnimals[index + 1];
                        }
                        else if (index == listOfAnimals.Count - 1)
                        {
                            previousAnimal = listOfAnimals[index - 1];
                            nextAnimal = "";
                        }
                        else
                        {
                            previousAnimal = listOfAnimals[index - 1];
                            nextAnimal = listOfAnimals[index + 1];
                        }
                        if (previousAnimal == "grass" || (previousAnimal == "" && nextAnimal == "grass"))
                        {
                            finalList.Add("antelope eats grass");
                            listOfAnimals.Remove("grass");
                            index = 0;
                        }
                        break;
                    case "big-fish":
                        if (index == 0)
                        {
                            previousAnimal = "";
                            nextAnimal = listOfAnimals[index + 1];
                        }
                        else if (index == listOfAnimals.Count - 1)
                        {
                            previousAnimal = listOfAnimals[index - 1];
                            nextAnimal = "";
                        }
                        else
                        {
                            previousAnimal = listOfAnimals[index - 1];
                            nextAnimal = listOfAnimals[index + 1];
                        }
                        if (previousAnimal == "little-fish" || (previousAnimal == "" && nextAnimal == "little-fish"))
                        {
                            finalList.Add("big-fish eats little-fish");
                            listOfAnimals.Remove("little-fish");
                            index = 0;

                        }
                        break;
                    case "bug":
                        if (index == 0)
                        {
                            previousAnimal = "";
                            nextAnimal = listOfAnimals[index + 1];
                        }
                        else if (index == listOfAnimals.Count - 1)
                        {
                            previousAnimal = listOfAnimals[index - 1];
                            nextAnimal = "";
                        }
                        else
                        {
                            previousAnimal = listOfAnimals[index - 1];
                            nextAnimal = listOfAnimals[index + 1];
                        }
                        if (previousAnimal == "leaves" || (previousAnimal == "" && nextAnimal == "leaves"))
                        {
                            finalList.Add("bug eats leaves");
                            listOfAnimals.Remove("leaves");
                            index = 0;

                        }
                        break;
                    case "bear":
                        if (index == 0)
                        {
                            previousAnimal = "";
                            nextAnimal = listOfAnimals[index + 1];
                        }
                        else if (index == listOfAnimals.Count - 1)
                        {
                            previousAnimal = listOfAnimals[index - 1];
                            nextAnimal = "";
                        }
                        else
                        {
                            previousAnimal = listOfAnimals[index - 1];
                            nextAnimal = listOfAnimals[index + 1];
                        }
                        if (previousAnimal == "big-fish" || (previousAnimal == "" && nextAnimal == "big-fish"))
                        {
                            finalList.Add("bear eats big-fish");
                            listOfAnimals.Remove("big-fish");
                            index = 0;
                        }
                        if (previousAnimal == "bug" || (previousAnimal == "" && nextAnimal == "bug"))
                        {
                            finalList.Add("bear eats bug");
                            listOfAnimals.Remove("bug");
                            index = 0;
                        }
                        if (previousAnimal == "chicken" || (previousAnimal == "" && nextAnimal == "chicken"))
                        {
                            finalList.Add("bear eats chicken");
                            listOfAnimals.Remove("chicken");
                            index = 0;
                        }
                        if (previousAnimal == "cow" || (previousAnimal == "" && nextAnimal == "cow"))
                        {
                            finalList.Add("bear eats cow");
                            listOfAnimals.Remove("cow");
                            index = 0;
                        }
                        if (previousAnimal == "leaves" || (previousAnimal == "" && nextAnimal == "leaves"))
                        {
                            finalList.Add("bear eats leaves");
                            listOfAnimals.Remove("leaves");
                            index = 0;
                        }
                        if (previousAnimal == "sheep" || (previousAnimal == "" && nextAnimal == "sheep"))
                        {
                            finalList.Add("bear eats sheep");
                            listOfAnimals.Remove("sheep");
                            index = 0;
                        }
                        break;
                    case "chicken":
                        if (index == 0)
                        {
                            previousAnimal = "";
                            nextAnimal = listOfAnimals[index + 1];
                        }
                        else if (index == listOfAnimals.Count - 1)
                        {
                            previousAnimal = listOfAnimals[index - 1];
                            nextAnimal = "";
                        }
                        else
                        {
                            previousAnimal = listOfAnimals[index - 1];
                            nextAnimal = listOfAnimals[index + 1];
                        }
                        if (previousAnimal == "bug" || (previousAnimal == "" && nextAnimal == "bug"))
                        {
                            finalList.Add("chicken eats bug");
                            listOfAnimals.Remove("bug");
                            index = 0;
                        }
                        break;
                    case "cow":
                        if (index == 0)
                        {
                            previousAnimal = "";
                            nextAnimal = listOfAnimals[index + 1];
                        }
                        else if (index == listOfAnimals.Count - 1)
                        {
                            previousAnimal = listOfAnimals[index - 1];
                            nextAnimal = "";
                        }
                        else
                        {
                            previousAnimal = listOfAnimals[index - 1];
                            nextAnimal = listOfAnimals[index + 1];
                        }
                        if (previousAnimal == "grass" || (previousAnimal == "" && nextAnimal == "grass"))
                        {
                            finalList.Add("cow eats grass");
                            listOfAnimals.Remove("grass");
                            index = 0;
                        }
                        break;
                    case "fox":
                        if (index == 0)
                        {
                            previousAnimal = "";
                            nextAnimal = listOfAnimals[index + 1];
                        }
                        else if (index == listOfAnimals.Count - 1)
                        {
                            previousAnimal = listOfAnimals[index - 1];
                            nextAnimal = "";
                        }
                        else
                        {
                            previousAnimal = listOfAnimals[index - 1];
                            nextAnimal = listOfAnimals[index + 1];
                        }
                        if (previousAnimal == "chicken" || nextAnimal == "chicken")
                        {
                            finalList.Add("fox eats chicken");
                            listOfAnimals.Remove("chicken");
                            index = 0;
                        }
                        if (previousAnimal == "sheep" || (previousAnimal == "" && nextAnimal == "sheep"))
                        {
                            finalList.Add("fox eats sheep");
                            listOfAnimals.Remove("sheep");
                            index = 0;
                        }
                        break;
                    case "giraffe":
                        if (index == 0)
                        {
                            previousAnimal = "";
                            nextAnimal = listOfAnimals[index + 1];
                        }
                        else if (index == listOfAnimals.Count - 1)
                        {
                            previousAnimal = listOfAnimals[index - 1];
                            nextAnimal = "";
                        }
                        else
                        {
                            previousAnimal = listOfAnimals[index - 1];
                            nextAnimal = listOfAnimals[index + 1];
                        }
                        if (previousAnimal == "leaves" || (previousAnimal == "" && nextAnimal == "leaves"))
                        {
                            finalList.Add("giraffe eats leaves");
                            listOfAnimals.Remove("leaves");
                            index = 0;
                        }
                        break;
                    case "lion":
                        if (index == 0)
                        {
                            previousAnimal = "";
                            nextAnimal = listOfAnimals[index + 1];
                        }
                        else if (index == listOfAnimals.Count - 1)
                        {
                            previousAnimal = listOfAnimals[index - 1];
                            nextAnimal = "";
                        }
                        else
                        {
                            previousAnimal = listOfAnimals[index - 1];
                            nextAnimal = listOfAnimals[index + 1];
                        }
                        if (previousAnimal == "antelope" || (previousAnimal == "" && nextAnimal == "antelope"))
                        {
                            finalList.Add("lion eats antelope");
                            listOfAnimals.Remove("antelope");
                            index = 0;
                        }
                        if (previousAnimal == "cow" || (previousAnimal == "" && nextAnimal == "cow"))
                        {
                            finalList.Add("lion eats cow");
                            listOfAnimals.Remove("cow");
                            index = 0;
                        }
                        break;
                    case "panda":
                        if (index == 0)
                        {
                            previousAnimal = "";
                            nextAnimal = listOfAnimals[index + 1];
                        }
                        else if (index == listOfAnimals.Count - 1)
                        {
                            previousAnimal = listOfAnimals[index - 1];
                            nextAnimal = "";
                        }
                        else
                        {
                            previousAnimal = listOfAnimals[index - 1];
                            nextAnimal = listOfAnimals[index + 1];
                        }
                        if (previousAnimal == "leaves" || (previousAnimal == "" && nextAnimal == "leaves"))
                        {
                            finalList.Add("panda eats leaves");
                            listOfAnimals.Remove("leaves");
                            index = 0;
                        }
                        break;
                    case "sheep":
                        if (index == 0)
                        {
                            previousAnimal = "";
                            nextAnimal = listOfAnimals[index + 1];
                        }
                        else if (index == listOfAnimals.Count - 1)
                        {
                            previousAnimal = listOfAnimals[index - 1];
                            nextAnimal = "";
                        }
                        else
                        {
                            previousAnimal = listOfAnimals[index - 1];
                            nextAnimal = listOfAnimals[index + 1];
                        }
                        if (previousAnimal == "grass" || (previousAnimal == "" && nextAnimal == "grass"))
                        {
                            finalList.Add("sheep eats grass");
                            listOfAnimals.Remove("grass");
                            index = 0;
                        }
                        break;


                }
            }
            /*
               antelope eats grass
               big-fish eats little-fish
               bug eats leaves
               bear eats big-fish
               bear eats bug
               bear eats chicken
               bear eats cow
               bear eats leaves
               bear eats sheep
               chicken eats bug
               cow eats grass
               fox eats chicken
               fox eats sheep
               giraffe eats leaves
               lion eats antelope
               lion eats cow
               panda eats leaves
               sheep eats grass
            */
            foreach (var thing in finalList) Console.WriteLine(thing);
            
            return finalList.ToArray();
        }
        public static string sumStrings(string a, string b)
        {
            int numberOne = Convert.ToInt32(a.Trim());
            int numberTwo = Convert.ToInt32(b.Trim());
            
            string result = (numberOne + numberTwo).ToString();
            return result;
        }
        public static List<string> GetPINs(string observed)
        {
            /*
             *  ┌───┬───┬───┐
                │ 1 │ 2 │ 3 │
                ├───┼───┼───┤
                │ 4 │ 5 │ 6 │
                ├───┼───┼───┤
                │ 7 │ 8 │ 9 │
                └───┼───┼───┘
                    │ 0 │
                    └───┘
             * 
             * */


            return null;
        }
        public static int NSquaresFor(int n)
        {
            // Your code here!
            return 0;
        }
        public static int[] humanYearsCatYearsDogYears(int humanYears)
        {
            // Your code here!
            int catYears = 0;
            int dogYears = 0;
            if (humanYears == 1)
            {
                catYears = 15;
                dogYears = 15;
            } else if (humanYears == 2)
            {
                catYears = 24;
                dogYears = 24;
            } else
            {
                catYears = 24 + (4 * (humanYears - 2));
                dogYears = 24 + (5 * (humanYears - 2));
            }

            return new int[] { humanYears, catYears, dogYears };
        }
        public static string Mix(string s1, string s2)
        {
            // your code
            Dictionary<char, int> s1CharCount = new Dictionary<char, int>();
            Dictionary<char, int> s2CharCount = new Dictionary<char, int>();
            s1 = s1.Replace(' ', '\0');
            s2 = s2.Replace(' ', '\0');
            string finalString = "";
            foreach (char letter in s1)
            {
                if (!s1CharCount.ContainsKey(letter))
                {
                    s1CharCount.Add(letter, 1);
                } else
                {
                    s1CharCount[letter]++;
                }
            }
            foreach (char letter in s2)
            {
                if (!s2CharCount.ContainsKey(letter))
                {
                    s2CharCount.Add(letter, 1);
                } else
                {
                    s2CharCount[letter]++;
                }
            }
            
            foreach(KeyValuePair<char,int> kvp in s1CharCount)
            {
                string charString = "";
                for(int i =0; i < kvp.Value; i++)
                {
                    charString += kvp.Key;
                }
                try
                {
                    if (kvp.Value > s2CharCount[kvp.Key])
                    {

                        finalString += $"1:{charString}/";


                    }else if (kvp.Value == s2CharCount[kvp.Key])
                    {
                        finalString += $"=:{charString}/";
                    }
                    else
                    {
                        finalString += $"2:{charString}/";
                    }
                }
                catch (KeyNotFoundException)
                {
                    finalString += $"1:{kvp.Key}/";
                }



            }
                Console.WriteLine(finalString);
            return finalString;
        }
        public static string CreatePhoneNumber(int[] numbers)
        {
            string numberString = "(";
            int place = 0;
            foreach (int number in numbers)
            {
                if (place == 3) numberString += ") ";
                if (place == 6) numberString += "-";
                numberString += number.ToString();
                place++;
            }
            return numberString;
        }
        public static string High(string s)
        {
            string bestWord = "";
            int highScore = 0;
            
            string alph = " abcdefghijklmnopqrstuvwxyz";
            List<string> words = new List<string>();
            var array = s.Split(" ");
            foreach(var item in array)
            {
                words.Add(item);
            }
            foreach(var word in words)
            {
                int tempScore = 0;
                foreach(var letter in word)
                {
                    tempScore += alph.IndexOf(letter);
                }
                if (tempScore > highScore)
                {
                    highScore = tempScore;
                    bestWord = word;
                }
            }

            Console.WriteLine(bestWord);
            return bestWord;
        }
        public static string NumberToString(int num)
        {
            return $"{num}";
        }
    }
}
