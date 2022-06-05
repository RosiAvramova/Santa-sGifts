using System;
using System.Collections.Generic;
using System.Linq;

namespace SantasGifts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            List<string> numberOfHouses = input.Split(' ').ToList();


            string[] commands = new string[numberOfCommands];
            for (int i = 0; i < numberOfCommands; i++)
            {
                commands[i] = Console.ReadLine();
            }


            int startPosition = 0;
            int endPosition = 0;
            for (int index = 0; index < commands.Length; index++)
            {
                string currentCommand = commands[index];
                string[] splitCommand = currentCommand.Split(' ');
                if (splitCommand[0] == "Forward")
                {
                    int numberOfSteps = int.Parse(splitCommand[1]);

                    if (startPosition + endPosition > numberOfHouses.Count)
                    {
                        continue;
                    }

                    endPosition = startPosition + numberOfSteps;
                    startPosition = endPosition;
                    numberOfHouses.RemoveAt(endPosition);

                }
                else if (splitCommand[0] == "Back")
                {
                    int numberOfSteps = int.Parse(splitCommand[1]);
                    if (startPosition - numberOfSteps < 0)
                    {
                        continue;
                    }
                    endPosition = startPosition - numberOfSteps;
                    startPosition = endPosition;
                    numberOfHouses.RemoveAt(endPosition);
                }
                else if (splitCommand[0] == "Swap")
                {
                    string firstHouseNumber = splitCommand[1];
                    string secondHouseNumber = splitCommand[2];
                    int firstIndex = numberOfHouses.IndexOf(firstHouseNumber);
                    int secondIndex = numberOfHouses.IndexOf(secondHouseNumber);
                    numberOfHouses[firstIndex] = secondHouseNumber;
                    numberOfHouses[secondIndex] = firstHouseNumber;
                }
                else if (splitCommand[0] == "Gift")
                {
                    int indexOfHouseToInsert = int.Parse(splitCommand[1]);
                    string houseNumberToInsert = splitCommand[2];
                    if (indexOfHouseToInsert <= numberOfHouses.Count)
                    {
                        numberOfHouses.Insert(indexOfHouseToInsert, houseNumberToInsert);
                    }

                    endPosition = indexOfHouseToInsert;
                    startPosition = endPosition;
                }

            }
            Console.WriteLine($"Position: {endPosition}");
            for (int i = 0; i < numberOfHouses.Count; i++)
            {
                if (i == numberOfHouses.Count - 1)
                {
                    Console.Write($"{numberOfHouses[i]}");
                }
                else
                {
                    Console.Write($"{numberOfHouses[i]}, ");
                }
            }
        }
    }
}