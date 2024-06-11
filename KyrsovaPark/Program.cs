// See https://aka.ms/new-console-template for more information
using KyrsovaPark;

Console.WriteLine("Hello, World!");

var UserInputResiver = new UserInputResiver();

Console.WriteLine("Program modes");
Console.WriteLine("1 Input by yourself");
Console.WriteLine("2 Input from generator");
Console.WriteLine("3 Input from file");

var workingMode = UserInputResiver.GetIntFromUser("Mode");

switch (workingMode)
{
	case 1:
        Console.WriteLine("Self");

        break;
    case 2:
        Console.WriteLine("Generator");

        break;
    case 3:
        Console.WriteLine("File");

        break;
    default:
		break;
}
