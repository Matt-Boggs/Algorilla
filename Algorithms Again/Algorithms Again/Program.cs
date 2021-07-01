using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Algorithms_Again
{
    class Program
    {
        static void Main(string[] args)
        {
            //Maskify("blablaljnsjfnlenlsenfljsnelfnjslefn4401");
            //DigitalRoot(678);
            //UniqueInOrder("AAAAbBBBcaWWWlllllllllllaaaAAA");
            //SongDecoder("WUBWEWUBAREWUBWUBTHEWUBCHAMPIONSWUBMYWUBFRIENDWUB");
            //BreakCamelCase("helloSunnyWorld");


            //dirReduc(new string[] { "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST" });
            //Test("2 4 7 8 10");

            //bouncingBall(30, .66, 1.5);
            //FirstNonRepeatingLetter("Moonmen");
        }
        public static string Maskify(string cc)
        {
            string maskedCard = "";
            for (int index = 0; index < (cc.Length); index++)
            {
                if (index < (cc.Length - 4)) maskedCard += '#';
                else maskedCard += cc[index];
            }
            return maskedCard;
        }
        public static int DigitalRoot(long n)
        {
            string stringifiedN = n.ToString();
            Start:
            int digitalRootResult = 0;
            foreach (char num in stringifiedN) digitalRootResult += Int32.Parse(num.ToString());

            if (digitalRootResult > 9)
            {
                stringifiedN = digitalRootResult.ToString();
                goto Start;
            }
            return digitalRootResult;
        }
        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
        {
            List<T> unique = new List<T>();
            foreach (T position in iterable)
            {
                if (!unique.Contains(position))
                {
                    unique.Add(position);
                }
            }
            foreach (var uniqueItem in unique) Console.WriteLine(uniqueItem);
            return unique;

        }

        public static string SongDecoder(string input)
        {
            return input.Replace("WUB", " ").Replace("   ", " ").Replace("  "," ").Trim();

            //================== BETTER WAY
                                        //One or more wubs
            return Regex.Replace(input, "(WUB)+", " ");
        }
        public static string BreakCamelCase(string str)
        {
            string camelCase = "";
            for (int index = 0; index < str.Length; index++)
            {
                if (Char.IsUpper(str[index])) camelCase += $" {str[index]}";
                else camelCase += str[index];
            }
            return camelCase;
        }
        public static string CreatePhoneNumber(int[] numbers)
        {
            string phoneNumber = "(";
            for (int index = 0; index < 3; index++) phoneNumber += numbers[index];
            phoneNumber += ") ";
            for (int index = 3; index < 6; index++) phoneNumber += numbers[index];
            phoneNumber += "-";
            for (int index = 6; index < numbers.Length; index++) phoneNumber += numbers[index];
            //return phoneNumber;

            // By Far the better way of doing this
            return long.Parse(string.Concat(numbers)).ToString("(000) 000-0000");

            // KISS principle
            //return $"({n[0]}{n[1]}{n[2]}) {n[3]}{n[4]}{n[5]}-{n[6]}{n[7]}{n[8]}{n[9]}";
            //return "(" + n[0] + n[1] + n[2] + ") " + n[3] + n[4] + n[5] + "-" + n[6] + n[7] + n[8] + n[9];
        }
        
        // Womp Womp
        public static string[] dirReduc(String[] arr)
        {
            List<string> newArr = new List<string>();
            foreach (string direction in arr) newArr.Add(direction);

            List<string> finalArr = new List<string>();
            for (int index = 0; index < newArr.Count; index++)
            {
                if (index == newArr.Count - 1)
                {
                    break;
                } else
                {
                    string direction = newArr[index];
                    switch (direction)
                    {
                        case "NORTH":
                            if (newArr[index+1] == "SOUTH")
                            {
                                newArr[index] = "";
                                newArr[index + 1] = "";
                            }
                            break;
                        case "SOUTH":
                            if (newArr[index + 1] == "NORTH")
                            {
                                newArr[index] = "";
                                newArr[index + 1] = "";
                            }
                            break;
                        case "EAST":
                            if (newArr[index + 1] == "WEST")
                            {   
                                newArr[index] = "";
                                newArr[index + 1] = "";
                            }
                            break;
                        case "WEST":
                            if (newArr[index + 1] == "EAST")
                            {
                                newArr[index] = "";
                                newArr[index + 1] = "";
                            }
                            break;

                    }
                }
                

                if (newArr[index] != "") finalArr.Add(newArr[index]);
            }
            
            
            foreach (string direction in finalArr) Console.WriteLine(direction);

            return arr;
        }
        public static int Find(int[] integers)
        {
            //If the first two elements have different parity,
            //check which element is wrong based on third (if the second and the third have the same parity, the first is the wrong one, otherwise - the second is the wrong one)
            
            //If the first two elements have the same parity, that means that parity of the first(and the second) element is the correct parity for list.
            //Thus, the element with different parity is what we are looking for.
            if (integers[0] % 2 != integers[1] % 2)
            {
                if (integers[2] % 2 == integers[1] % 2)
                {
                    return integers[0];

                } else return integers[1];
            }
            foreach (int num in integers)
            {
                if (num % 2 != integers[0] % 2) return num;
            }
                         
            return -1;




            // Using Linq and less math
            var evenNumbers = integers.Where(integer => integer % 2 == 0);
            var oddNumbers = integers.Where(integer => integer % 2 == 1);
            return evenNumbers.Count() == 1 ? evenNumbers.First() : oddNumbers.First();
        }
        public static int Test(string numbers)
        {
            List<int> numList = new List<int>();
            foreach (char number in numbers)
            {
                if (number.ToString() != " ")
                {
                    numList.Add(Int32.Parse(number.ToString()));
                } 
            }
            var evenNumbers = numList.Where(integer => integer % 2 == 0);
            var oddNumbers =  numList.Where(integer => integer % 2 == 1);
            return evenNumbers.Count() == 1 ? numList.IndexOf(evenNumbers.First()) - 1 : numList.IndexOf(oddNumbers.First()) - 1;
        }
        public static int bouncingBall(double h, double bounce, double window)
        {
            int Counter = 0;
            while (h > window)
            {
                if (!(h > 0) || !(bounce > 0 && bounce < 1) || !(window < h)) return -1;
                else
                {
                    Counter++;
                    h *= bounce;
                    if (h > window) Counter++;
                }
            }
            if (Counter == 0) return -1;
            return Counter;
        }
        public static string FirstNonRepeatingLetter(string s)
        {
            Dictionary<string, int> letterCount = new Dictionary<string, int>();
            foreach(char letter in s)
            {
                if (letterCount.ContainsKey(letter.ToString()))
                {
                    letterCount[letter.ToString()]++;
                } else
                {
                    letterCount.Add(letter.ToString(), 1);
                }
            }
            foreach(KeyValuePair<string, int> kvp in letterCount)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
                if (letterCount.ContainsKey(kvp.Key.ToString().ToUpper()) && letterCount.ContainsKey(kvp.Key.ToString().ToLower()))
                {
                    Console.WriteLine("Different cases, same char");
                    continue;
                }
                else if (kvp.Value == 1) return kvp.Key.ToString();
            }
            return "";
        }
    }
}
