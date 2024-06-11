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
        var selfM = UserInputResiver.GetIntFromUser("M");
        var selfN = UserInputResiver.GetIntFromUser("N");
        var selfK = UserInputResiver.GetIntFromUser("K");

        break;
    case 2:
        Console.WriteLine("Generator");
        var generatorM = UserInputResiver.GetIntFromUser("M");
        var generarorN = UserInputResiver.GetIntFromUser("N");
        var generatorK = UserInputResiver.GetIntFromUser("K");
        var generatorNumOfFields = UserInputResiver.GetIntFromUser("NumOfFields");
        Visualizer visualizer = new Visualizer(generatorM, generarorN, generatorK);

        Generator generator = new Generator(generatorM, generarorN, generatorK, generatorNumOfFields);

        var park = generator.GeneratePark();

        visualizer.ShowPark(park);

        break;
    case 3:
        Console.WriteLine("File");

        break;
    default:
		break;
}
