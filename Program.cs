using System;
using System.Collections.Generic;
using System.Linq;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {

            bool playAgain = true;




            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge

            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                4, 20
            );
            Challenge threeMinusOne = new Challenge("3 - 1?", 2, 10);
            Challenge rainbowColors = new Challenge("How many colors in a rainbow?", 7, 15);

            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            // Make a new "Adventurer" object using the "Adventurer" class

            Console.WriteLine("Who dis?");
            string adventurerName = Console.ReadLine();

            Console.WriteLine("What color is your robe?");
            string robeColor = Console.ReadLine();

            Console.WriteLine("How long is your robe? (enter a number)");
            int robeLength = Int32.Parse(Console.ReadLine());

            Console.WriteLine("How shiny is your hat? (1 - 10)");
            int hatShininess = Int32.Parse(Console.ReadLine());

            Robe myRobe = new Robe();
            myRobe.Colors = new List<string>();
            myRobe.Colors.Add(robeColor);
            myRobe.Length = robeLength;

            Hat adventurerHat = new Hat();
            adventurerHat.ShininessLevel = hatShininess;

            Prize wonPrize = new Prize("Yay!");

            Adventurer theAdventurer = new Adventurer(adventurerName, myRobe, adventurerHat);

            while (playAgain)
            {
                Console.WriteLine(theAdventurer.GetDescription());
                // A list of challenges for the Adventurer to complete
                // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
                List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                threeMinusOne,
                rainbowColors
            };
                List<Challenge> randomChallenges = new List<Challenge>();
                List<int> indexList = new List<int>();
                Random random = new Random();
                int randomInteger;

                do
                {
                    randomInteger = random.Next(challenges.Count);
                    if (!indexList.Contains(randomInteger) && indexList.Count < 5)
                    {
                        indexList.Add(randomInteger);
                        randomChallenges.Add(challenges[randomInteger]);
                    };
                } while (indexList.Contains(randomInteger));

                //while loop
                //generate random numbers 
                //check if the number is already in list. 
                //add to indexList if not already in list
                //repeat until indexlist.Count is 5




                int correctAnswers = 0;
                // Loop through all the challenges and subject the Adventurer to them
                foreach (Challenge challenge in randomChallenges)
                {
                    challenge.RunChallenge(theAdventurer, correctAnswers);
                }

                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
                }

                wonPrize.ShowPrize(theAdventurer);


                Console.Write("Would you like to play again? (Y/N): ");
                string answer = Console.ReadLine().ToLower();
                if (answer == "n")
                {
                    playAgain = false;
                }
                theAdventurer.Awesomeness += correctAnswers * 10;
            }

        }
    }
}
