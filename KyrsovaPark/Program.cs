// See https://aka.ms/new-console-template for more information
using KyrsovaPark;

Console.WriteLine("Hello, World!");

var UserInputResiver = new UserInputResiver();

Console.WriteLine("Program modes");
Console.WriteLine("1 Input by yourself");
Console.WriteLine("2 Input from generator");
Console.WriteLine("3 Input from file");

//var workingMode = UserInputResiver.GetIntFromUser("Mode");
var workingMode = 2;
switch (workingMode)
{
	case 1:
        Console.WriteLine("Self");
        var selfM = UserInputResiver.GetIntFromUser("M");
        var selfN = UserInputResiver.GetIntFromUser("N");
        var selfK = UserInputResiver.GetIntFromUser("K");
        Visualizer selfVisualizer = new Visualizer(selfM, selfN, selfK);

        var selfPark = new int[selfM * selfN];

        selfVisualizer.ShowParkWithNumbers();
        var pointNumToAdd = -1;
        Console.WriteLine("Enter Num to set Green Zone on");
        Console.WriteLine("Enter 1234 to stop entring Green Zones");

        while (true)
        {
            pointNumToAdd = UserInputResiver.GetIntFromUser("Num");
            if (pointNumToAdd == 1234)
                break;
            selfPark[pointNumToAdd - 1]=1;
        }

        Console.WriteLine("Input");
        selfVisualizer.ShowPark(selfPark);
        Console.WriteLine($"M = {selfM}");
        Console.WriteLine($"N = {selfN}");
        Console.WriteLine($"K = {selfK}");


        break;
    case 2:
        Console.WriteLine("Generator");
        //var generatorM = UserInputResiver.GetIntFromUser("M");
        //var generarorN = UserInputResiver.GetIntFromUser("N");
        //var generatorK = UserInputResiver.GetIntFromUser("K");
        //var generatorNumOfFields = UserInputResiver.GetIntFromUser("NumOfFields");
        //var generatorNumRepeat = UserInputResiver.GetIntFromUser("NumRepeat");

        var generatorM = 10;
        var generarorN = 5;
        var generatorK = 5;
        var generatorNumOfFields = 1;
        var generatorNumRepeat = 2;
        Visualizer generatorVisualizer = new Visualizer(generatorM, generarorN, generatorK);

        Generator generator = new Generator(generatorM, generarorN, generatorK, generatorNumOfFields);
        for (int i = 0; i < generatorNumRepeat; i++)
        {
            var generatorPark = generator.GeneratePark();

            Console.WriteLine("Input");
            generatorVisualizer.ShowPark(generatorPark);
            Console.WriteLine($"M = {generatorM}");
            Console.WriteLine($"N = {generarorN}");
            Console.WriteLine($"K = {generatorK}");


            GreedyAlgoritm greedyAlgoritm = new GreedyAlgoritm(generatorM, generarorN, generatorK, generatorPark);

            var (X, S) = greedyAlgoritm.GetResult();

            generatorVisualizer.ShowLamps(generatorPark, X);
            Console.WriteLine($"S = {S}");
            Console.WriteLine();
        }
        break;
    case 3:
        Console.WriteLine("File");

        break;
    default:
		break;
}
