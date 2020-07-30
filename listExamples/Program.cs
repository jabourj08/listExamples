using System;
using System.Collections.Generic;

namespace listExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>() { "Tommy", "Anna", "Josh"};
            while (true)
            {

                Console.WriteLine("Welcome to the guest list manager.");
                Console.WriteLine("Currently you have " + names.Count + " guests.");
                Console.WriteLine("Please select what you would like to do: ");

                Console.WriteLine("1) Print all guest names");
                Console.WriteLine("2) Add in a new guest");
                Console.WriteLine("3) Remove a guest");
                Console.WriteLine("4) Is a guest allowed?");
                Console.WriteLine("5) Exit");

                string input = Console.ReadLine();

                try
                {
                    int pick = int.Parse(input);
                    if (1 <= pick && pick <= 5)
                    {
                        if (pick == 1)
                        {
                            PrintList(names);
                        }
                        else if (pick == 2)
                        {
                            AddName(names);
                        }
                        else if (pick == 3)
                        {
                            RemoveName(names);
                        }
                        else if (pick == 4)
                        {
                            Console.WriteLine("Please input a person you want to check if they will be allowed to attend the party.");
                            string name = Console.ReadLine();
                            bool allowedIn = IsAllowedToAttend(names, name);
                            Console.WriteLine("Is " + name + " allowed to attend?");
                            Console.WriteLine(allowedIn);
                            Console.ReadKey();
                        }
                        else if (pick == 5)
                        {
                            Console.WriteLine("Thanks for using the program.");
                            Console.WriteLine("Press any key to exit.");
                            Console.ReadKey();
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Input number: " + pick + " was not between 1 and 5.");
                        Console.WriteLine("Please press any key to try again.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The input " + input + " was not a number.");
                    Console.WriteLine("Press any key to try again");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
         }

        public static void PrintList(List<string> names)
        {
            Console.Clear();
            Console.WriteLine("Current guests:");
            foreach (string name in names) 
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
        }

        public static void AddName(List<string> guestList)
        {
            Console.Clear();
            Console.WriteLine("Please input a name you wish to ADD to the guest list.");
            string input = Console.ReadLine();

            guestList.Add(input);
            Console.WriteLine(input + " has been added to the guest list.");

            Console.WriteLine();

            //return guestList;

        }

        public static void RemoveName(List<string> guestList)
        {
            Console.Clear();
            Console.WriteLine("Please input a name you wish to REMOVE to the guest list.");
            string input = Console.ReadLine();

            if (guestList.Contains(input))
            {
                guestList.Remove(input);
                Console.WriteLine(input + " has been removed from the guest list.");
            }
            else
            {
                Console.WriteLine("Nothing has been removed because " + input + " is not on the guest list");
            }

            Console.WriteLine();

            //return guestList;

        }

        public static bool IsAllowedToAttend(List<string> guestList, string name)
        {
            bool decision = false;

            if (guestList.Contains(name))
            {
                char[] letters = name.ToCharArray();
                char firstLetter = letters[0];

                if (Char.IsUpper(firstLetter))
                {
                    string vowels = "aeiou";
                    char[] vowelChars = vowels.ToCharArray();
                    int total = 0;

                    for (int i = 0; i < name.Length; i++)
                    {
                        for (int j = 0; j < vowels.Length; j++)
                        {
                            if (name[i] == vowels[j])
                            {
                                total++;
                            }
                        }
                    }

                    Console.WriteLine("Your total is: " + total);

                    if (total > 1)
                    {
                        decision = true;
                    }
                    else
                    {
                        decision = false;
                    }

                    //foreach (char letter in vowels)
                    //{
                    //    if (name.Contains(letter))
                    //    {
                    //        total++;
                    //        if (total > 1)
                    //        {
                    //            decision = true;
                    //        }
                    //        else
                    //        {
                    //            decision = false;
                    //        }
                    //    }
                    //}

                    //return true;

                    //for (int i = 0; i < vowelChars.Length; i++)
                    //{
                    //    for ()
                    //    {

                    //    }
                    //}
                }
                else
                {
                    Console.WriteLine(name + " is not capitalized and therefore may not attend.");
                    decision = false;
                }
            }
            else
            {
                Console.WriteLine(name + " is not on the guest list. They are not allowed to attend");
                decision = false;
            }

            return decision;
        }
    }
}
