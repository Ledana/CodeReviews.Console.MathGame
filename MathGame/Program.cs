
using static System.Formats.Asn1.AsnWriter;

namespace MathGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //creating a list to keep all the questionsWithAnswer
            List<string> questionsWithAnswer = new();
            List<List<string>> previusGames = new();
            //random number generator
            Random rand = new();
            

            Console.WriteLine("Wellcome to Math Game");
            string? input = "";
            int gameNumber = 1;
            while (input.ToLower().Trim() != "no")
            {
                RunGame(rand, questionsWithAnswer, gameNumber);
                gameNumber++;
                previusGames.Add(questionsWithAnswer);
                questionsWithAnswer = new();


                Console.WriteLine("Do you want to play again?");
                Console.WriteLine("Type 'yes' to play or 'no' to quit");
                Console.WriteLine("Or type 'previus' if you want to see previous games result");

                input = Console.ReadLine();

                if (input != null)
                {
                    if (input.ToLower().Trim() == "previus")
                    {
                        int game = 1;
                        foreach (var item in previusGames)
                        {
                            Console.WriteLine("Game " + game);
                            foreach (var item1 in item)
                                Console.WriteLine(item1);
                            Console.WriteLine();
                            game++;
                        }
                    }
                }
                else
                    Console.WriteLine("The input is not valid");

            }
            Console.WriteLine("Thank you for playing");
        }

        static void ShowResults(List<string> questionsWithAnswer)
        {
            Console.WriteLine("This game questions answered: ");
            foreach (var item in questionsWithAnswer)
            {
                Console.WriteLine(item);
            }
        }
        static void RunGame(Random rand, List<string> questionsWithAnswer, int gameNumber)
        {
            char operation = '\0';
            string? input = "";
            string question = "";
            int answer = 0;
            int finalScore = 0;
            int correctAnswer = 0;
            //adding a counter
            int gameCount = 0;
            DateTime timeStart = new();
            DateTime timeFinish = new();
            timeStart = DateTime.UtcNow;

            Console.WriteLine("******************");
            Console.WriteLine();
            Console.WriteLine($"GAME {gameNumber}");
            while (input != "0" && gameCount < 5)
            {
                ShowMenu();
                input = Console.ReadLine();
                
                var flag = int.TryParse(input, out int result);

                if (flag)
                {

                    switch (result)
                    {
                        case 1:
                            {
                                //everytime the user chooses an operation its count as a game
                                gameCount++;
                                operation = '+';
                                int firstNumber = rand.Next(1, 100);
                                int secondNumber = rand.Next(1, 100);
                                

                                while (true)
                                {
                                    question = firstNumber + " " + operation + " " + secondNumber;
                                    Console.WriteLine(question);

                                    var validation = int.TryParse(Console.ReadLine(), out answer);

                                    if (validation)
                                    {
                                        correctAnswer = firstNumber + secondNumber;
                                        if (answer == correctAnswer)
                                        {
                                            finalScore++;

                                            CorrectAnswer(questionsWithAnswer, question);
                                        }
                                        else
                                        {
                                            WrongAnswer(questionsWithAnswer, question);
                                            Console.WriteLine("Correct answer is: " + correctAnswer);
                                        }
                                        break;
                                    }
                                    //if input is not a number keep asking the question
                                    else
                                        Console.WriteLine("The answer was not in the right format");
                                }
                            }
                            break;

                        case 2:
                            {
                                gameCount++;
                                operation = '-';
                                int firstNumber = rand.Next(1, 100);
                                int secondNumber = rand.Next(1, 100);
                                while (true)
                                {
                                    question = firstNumber + " " + operation + " " + secondNumber;
                                    Console.WriteLine(question);

                                    var validation = int.TryParse(Console.ReadLine(), out answer);

                                    if (validation)
                                    {
                                        correctAnswer = firstNumber - secondNumber;
                                        if (answer == correctAnswer)
                                        {
                                            finalScore++;

                                            CorrectAnswer(questionsWithAnswer, question);
                                        }
                                        else
                                        {
                                            WrongAnswer(questionsWithAnswer, question);
                                            Console.WriteLine("Correct answer is: " + correctAnswer);
                                        }
                                        break;
                                    }
                                    //if input is not a number keep asking the question
                                    else
                                        Console.WriteLine("The answer was not in the right format");
                                }
                            }
                            break;

                        case 3:
                            {
                                gameCount++;
                                operation = '*';
                                int firstNumber = rand.Next(1, 100);
                                int secondNumber = rand.Next(1, 100);
                                while (true)
                                {
                                    question = firstNumber + " " + operation + " " + secondNumber;
                                    Console.WriteLine(question);

                                    var validation = int.TryParse(Console.ReadLine(), out answer);

                                    if (validation)
                                    {
                                        correctAnswer = firstNumber * secondNumber;
                                        if (answer == correctAnswer)
                                        {
                                            finalScore++;

                                            CorrectAnswer(questionsWithAnswer, question);
                                        }
                                        else
                                        {
                                            WrongAnswer(questionsWithAnswer, question);
                                            Console.WriteLine("Correct answer is: " + correctAnswer);
                                        }
                                        break;
                                    }
                                    //if input is not a number keep asking the question
                                    else
                                        Console.WriteLine("The answer was not in the right format");
                                }
                            }
                            break;

                        case 4:
                            {
                                gameCount++;
                                operation = '/';
                                int firstNumber = rand.Next(1, 100);
                                int secondNumber = rand.Next(1, 100);

                                while (true)
                                {
                                    if (firstNumber % secondNumber == 0)
                                        break;
                                    firstNumber = rand.Next(1, 100);
                                    secondNumber = rand.Next(1, 100);
                                }

                                while (true)
                                {
                                    question = firstNumber + " " + operation + " " + secondNumber;
                                    Console.WriteLine(question);

                                    var validation = int.TryParse(Console.ReadLine(), out answer);

                                    if (validation)
                                    {
                                        correctAnswer = firstNumber / secondNumber;
                                        if (answer == correctAnswer)
                                        {
                                            finalScore++;

                                            CorrectAnswer(questionsWithAnswer, question);
                                        }
                                        else
                                        {
                                            WrongAnswer(questionsWithAnswer, question);
                                            Console.WriteLine("Correct answer is: " + correctAnswer);
                                        }
                                        break;
                                    }
                                    //if input is not a number keep asking the question
                                    else
                                        Console.WriteLine("The answer was not in the right format");
                                }
                            }
                            break;
                        case 0:
                            break;
                        default:
                            Console.WriteLine("Please choose from the menu");
                            break;
                    }
                }
                else
                    Console.WriteLine("Please enter a valid input");
            }
            timeFinish = DateTime.Now;

            if (gameCount == 0)
                Console.WriteLine("Sorry to see you quit");

            else
            {
                Console.WriteLine($"Game {gameNumber}:");
                ShowResults(questionsWithAnswer);
                Console.WriteLine();
                Console.WriteLine($"This game score is: {finalScore}");
                Console.WriteLine($"You took {(timeFinish - timeStart).Seconds} seconds to finish");
            }
            
        }

        private static void WrongAnswer(List<string> questionsWithAnswer, string question)
        {
            Console.WriteLine("Wrong! you get 0 point");
            questionsWithAnswer.Add($"Question: \"{question}\" - Answered Wrong => 0 point");
        }

        static void CorrectAnswer(List<string> questionsWithAnswer, string question)
        {
            Console.WriteLine("Correct! You get 1 point");
            questionsWithAnswer.Add($"Question: \"{question}\" - Answered Correct => 1 point");
            
        }

        static void ShowMenu()
        {
            Console.WriteLine("Choose the operation");
            Console.WriteLine("'1' for '+'");
            Console.WriteLine("'2' for '-'");
            Console.WriteLine("'3' for '*'");
            Console.WriteLine("'4' for '/'");
            
            Console.WriteLine("Or put '0' to quit the game");
        }

        
    }
}
