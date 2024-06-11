// See https://aka.ms/new-console-template for more information
using KyrsovaPark;

using System.Net.Http.Headers;

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

        var streamWriter = new StreamWriter("Result.txt", true);

        FileVisualizer generatorFileVisualizer = new FileVisualizer(generatorM, generarorN, generatorK, streamWriter);

        Generator generator = new Generator(generatorM, generarorN, generatorK, generatorNumOfFields);
        for (int i = 0; i < generatorNumRepeat; i++)
        {
            var generatorPark = generator.GeneratePark();

            Console.WriteLine("Input");
            generatorVisualizer.ShowPark(generatorPark);
            Console.WriteLine($"M = {generatorM}");
            Console.WriteLine($"N = {generarorN}");
            Console.WriteLine($"K = {generatorK}");

            streamWriter.WriteLine("Input");
            generatorFileVisualizer.ShowPark(generatorPark);
            streamWriter.WriteLine($"M = {generatorM}");
            streamWriter.WriteLine($"N = {generarorN}");
            streamWriter.WriteLine($"K = {generatorK}");


            GreedyAlgoritm greedyAlgoritm = new GreedyAlgoritm(generatorM, generarorN, generatorK, generatorPark);

            var (greedyX, greedyS) = greedyAlgoritm.GetResult();

            Console.WriteLine("Greedy Algoritm:");
            generatorVisualizer.ShowLamps(generatorPark, greedyX);
            Console.WriteLine($"S = {greedyS}");
            Console.WriteLine();

            streamWriter.WriteLine("Greedy Algoritm:");
            generatorFileVisualizer.ShowLamps(generatorPark, greedyX);
            streamWriter.WriteLine($"S = {greedyS}");
            streamWriter.WriteLine();

            BrootForceAlgoritm brootForceAlgoritm = new BrootForceAlgoritm(generatorM, generarorN, generatorK, generatorPark);

            var (brootForceX, brootForceS) = brootForceAlgoritm.GetResult();

            Console.WriteLine("Broot Force Algoritm:");
            generatorVisualizer.ShowLamps(generatorPark, brootForceX);
            Console.WriteLine($"S = {brootForceS}");
            Console.WriteLine();

            streamWriter.WriteLine("Broot Force Algoritm:");
            generatorFileVisualizer.ShowLamps(generatorPark, brootForceX);
            streamWriter.WriteLine($"S = {brootForceS}");
            streamWriter.WriteLine();
        }
        streamWriter.Close();
        break;
    case 3:
        Console.WriteLine("File");

        break;
    default:
		break;
}
