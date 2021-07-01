using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace EvenMoreAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> listOfNumbers = GrabNumbers();
            //FindSum(listOfNumbers);
            List<string> listOfLines = GrabLines("planeSeats.txt");
            //VerifyPWNew(listOfPW);
            //TreeCounter(listOfLines);
            FindSeatnumber(listOfLines);
        }
        static List<int> GrabNumbers()
        {
            List<int> listOfNumbers = new List<int>();
            string listOfNumbersPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "numLog.txt");
            string line;
            using (StreamReader numStream = new StreamReader(listOfNumbersPath))
            {
                while ((line = numStream.ReadLine()) != null)
                {
                    listOfNumbers.Add(Int32.Parse(line));
                }
            }
            //foreach (int numLine in listOfNumbers)
            //{
            //    Console.WriteLine(numLine);
            //}
            return listOfNumbers;
        }
        static void FindSum(List<int> listOfNumbers)
        {
            for (int index = 0; index < listOfNumbers.Count; index++)
            {
                for (int secondIndex = 0; secondIndex < listOfNumbers.Count; secondIndex++)
                {
                    for (int thirdIndex = 0; thirdIndex<listOfNumbers.Count; thirdIndex++)
                    {
                        int firstNumber = listOfNumbers[index];
                        int secondNumber = listOfNumbers[secondIndex];
                        int thirdNumber = listOfNumbers[thirdIndex];
                        if (firstNumber + secondNumber + thirdNumber == 2020)
                        {
                            Console.WriteLine($"num1: {firstNumber} | num2: {secondNumber} | num3: {thirdNumber}");
                            Console.WriteLine(firstNumber * secondNumber * thirdNumber);
                        }
                    }
                }
            }
        }
        static List<string> GrabLines(string fileName)
        {
            List<string> listOfLines = new List<string>();
            string listOfLinesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
            string line;
            using (StreamReader lineStream = new StreamReader(listOfLinesPath))
            {
                while ((line = lineStream.ReadLine()) != null)
                {

                    listOfLines.Add(line);
                }
            }



            return listOfLines;
        }
        static List<string> GrabLineChunk()
        {
            List<string> listOfLines = new List<string>();
            string listOfLinesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "passPortLog.txt");
            string line;
            string lineChunk = "";
            int verifiedCount = 0;
            int breakLines = 0;
            using (StreamReader lineStream = new StreamReader(listOfLinesPath))
            {
                while ((line = lineStream.ReadLine()) != null)
                {
                  if (line != "")
                    {
                        lineChunk += $" {line}";
                    }
                  if (line == "")
                    {
                        breakLines++;
                        listOfLines.Add(lineChunk);
                        lineChunk = "";
                    }
                }
            }
            Console.WriteLine(breakLines);
            foreach (string longLine in listOfLines)
            {
                if (longLine.Contains("byr") && longLine.Contains("iyr") && longLine.Contains("eyr") && longLine.Contains("hgt") && longLine.Contains("hcl") && longLine.Contains("ecl") && longLine.Contains("pid"))
                {
                    verifiedCount++;
                }
            }
            Console.WriteLine(listOfLines.Count);
            Console.WriteLine(verifiedCount);
            return listOfLines;
        }
        static int VerifyPW(List<string> listOfLines)
        {
            // verifiedCount is how many passwords pass the test
            int verifiedCount = 0;

            // This grabs the lowerBound and dash (999-)
            Regex lowerBoundRX = new Regex(@"\d+\D", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            // This grabs the dash and upperBound (-999)
            Regex upperBoundRX = new Regex(@"\D\d+", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            // This grabs the character we're checking the password for, sandwiched by a space and a colon ( A:)
            Regex characterToVerifyRX = new Regex(@"\s\w:", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            // This grabs the password we're checking, with a space at the beginning and two or more characters ( jhkkkkaakakhe)
            Regex passWordRX = new Regex(@"\s\w{2,}", RegexOptions.Compiled | RegexOptions.IgnoreCase);


            foreach (string line in listOfLines)
            {
                // Grab the lowerbound as a string, and then take the integer value before the dash
                string lowerBoundRaw = lowerBoundRX.Match(line).ToString();
                int lowerBound = Int32.Parse(lowerBoundRaw.Substring(0, (lowerBoundRaw.Length - 1)));
                // Grab the upperbound as a string, and then take the integer value after the dash
                string upperBoundRaw = upperBoundRX.Match(line).ToString();
                int upperBound = Int32.Parse(upperBoundRaw.Substring(1,upperBoundRaw.Length - 1));

                // Grab the character in the middle of our regex match ( _A_:)
                Char characterToVerify = characterToVerifyRX.Match(line).ToString()[1];

                // Grab the password string and remove the white space in the beginning
                string passWordToVerify = passWordRX.Match(line).ToString().Trim();

                // checkCount needs to be within the bounds for the password to be verified
                int checkCount = 0;
                foreach(Char charCheck in passWordToVerify)
                {
                    // Increment the checkCount for every instance of our character
                    if (charCheck == characterToVerify) checkCount++;
                }

                // Increment the verifiedCount if the amount of times the character appears is within the bounds for that password
                if (checkCount >= lowerBound && checkCount <= upperBound) verifiedCount++;
            }


            Console.WriteLine(verifiedCount);

            return verifiedCount;
        }
        static int VerifyPWNew(List<string> listOfLines)
        {
            // verifiedCount is how many passwords pass the test
            int verifiedCount = 0;

            // This grabs the lowerBound and dash (999-)
            Regex lowerBoundRX = new Regex(@"\d+\D", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            // This grabs the dash and upperBound (-999)
            Regex upperBoundRX = new Regex(@"\D\d+", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            // This grabs the character we're checking the password for, sandwiched by a space and a colon ( A:)
            Regex characterToVerifyRX = new Regex(@"\s\w:", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            // This grabs the password we're checking, with a space at the beginning and two or more characters ( jhkkkkaakakhe)
            Regex passWordRX = new Regex(@"\s\w{2,}", RegexOptions.Compiled | RegexOptions.IgnoreCase);


            foreach (string line in listOfLines)
            {
                // Grab the lowerbound as a string, and then take the integer value before the dash
                string lowerBoundRaw = lowerBoundRX.Match(line).ToString();
                int lowerBound = Int32.Parse(lowerBoundRaw.Substring(0, (lowerBoundRaw.Length - 1)));
                // Grab the upperbound as a string, and then take the integer value after the dash
                string upperBoundRaw = upperBoundRX.Match(line).ToString();
                int upperBound = Int32.Parse(upperBoundRaw.Substring(1, upperBoundRaw.Length - 1));

                // Grab the character in the middle of our regex match ( _A_:)
                Char characterToVerify = characterToVerifyRX.Match(line).ToString()[1];

                // Grab the password string and remove the white space in the beginning
                string passWordToVerify = passWordRX.Match(line).ToString().Trim();

                // We only want our chosen character at ONE of the indexes, NOT BOTH
                if (passWordToVerify[lowerBound - 1] == characterToVerify && passWordToVerify[upperBound - 1] == characterToVerify) continue; 

                if (passWordToVerify[lowerBound - 1] == characterToVerify || passWordToVerify[upperBound - 1] == characterToVerify) verifiedCount++;
            }
            return verifiedCount;
        }
        static int TreeCounter(List<string> listOfLines)
        {
            int treeCount = 0;

            // Placing our yAxis at the end of the graph
            int yAxis = 0;
            // Line number refers to the line of the notepad, but in this case is also our x coordinate
            for (int lineNumber = 0; lineNumber < listOfLines.Count; lineNumber++)
            {
                string currentLine = listOfLines[lineNumber];
                if (yAxis > 30) yAxis = yAxis % 30;
                Console.WriteLine(currentLine[yAxis]);
                if (currentLine[yAxis] == '#')
                {
                    treeCount++;
                    yAxis += 3;
                }
            }
            Console.WriteLine(treeCount);



            return treeCount;
        }
        static void FindSeatnumber(List<string> listOfLines)
        {
            // 0 through 127, 128 in total
            int rows = 127;
            int row = 0;
            // 0 through 7, 8 in total
            int columns = 7;
            int column = 0;

            int seatID = 0;

            int highestID = 0;


            foreach (string line in listOfLines)
            {
                int maxRow = 127;
                int minRow = 0;
                int maxColumn = 7;
                int minColumn = 0;
                Console.WriteLine(line);
                for (int index = 0; index < line.Length; index++)
                {
                    
                    switch (line[index])
                    {
                        case 'F': // Lower Half
                            maxRow /= 2;
                            Console.WriteLine(maxRow);
                            break;
                        case 'B': // Upper Half
                            minRow = maxRow / 2;
                            Console.WriteLine(minRow);
                            break;
                        case 'R': // Upper Half
                            maxColumn /= 2;
                            Console.WriteLine(maxColumn);
                            break;
                        case 'L': // Lower Half
                            minColumn = maxColumn / 2;
                            Console.WriteLine(minColumn);
                            break;
                    }
                }
            }





        }
    }
}
