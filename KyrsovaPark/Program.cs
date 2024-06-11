// See https://aka.ms/new-console-template for more information
using KyrsovaPark;

using System.Diagnostics;
using System.Net.Http.Headers;

Console.WriteLine("Hello, World!");

var UserInputResiver = new UserInputResiver();

Console.WriteLine("Program modes");
Console.WriteLine("1 Input by yourself");
Console.WriteLine("2 Input from generator");
Console.WriteLine("3 Input from file");

//var workingMode = UserInputResiver.GetIntFromUser("Mode");
var workingMode = 1;
var streamWriter = new StreamWriter("Result.txt");
streamWriter.Close();
streamWriter = new StreamWriter("Result.txt", true);

switch (workingMode)
{
	case 1:
        Console.WriteLine("Self");
        var selfM = UserInputResiver.GetIntFromUser("M");
        var selfN = UserInputResiver.GetIntFromUser("N");
        var selfK = UserInputResiver.GetIntFromUser("K");
        Visualizer selfVisualizer = new Visualizer(selfM, selfN, selfK);


        FileVisualizer selfFileVisualizer = new FileVisualizer(selfM, selfN, selfK, streamWriter);


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

        streamWriter.WriteLine("Input");
        selfFileVisualizer.ShowPark(selfPark);
        streamWriter.WriteLine($"M = {selfM}");
        streamWriter.WriteLine($"N = {selfN}");
        streamWriter.WriteLine($"K = {selfK}");



        Stopwatch selfGreedyStopwatch = Stopwatch.StartNew();
        GreedyAlgoritm selfGreedyAlgoritm = new GreedyAlgoritm(selfM, selfN, selfK, selfPark);
        var (selfGreedyX, selfGreedyS) = selfGreedyAlgoritm.GetResult();
        selfGreedyStopwatch.Stop();
        double selfGreedyTime = selfGreedyStopwatch.Elapsed.TotalMilliseconds;

        Console.WriteLine("Greedy Algorithm:");
        selfVisualizer.ShowLamps(selfPark, selfGreedyX);
        Console.WriteLine($"S = {selfGreedyS}");
        Console.WriteLine($"Time = {selfGreedyTime} ms");
        Console.WriteLine();

        streamWriter.WriteLine("Greedy Algorithm:");
        selfFileVisualizer.ShowLamps(selfPark, selfGreedyX);
        streamWriter.WriteLine($"S = {selfGreedyS}");
        streamWriter.WriteLine($"Time = {selfGreedyTime} ms");
        streamWriter.WriteLine();

        Stopwatch selfBrootForceStopwatch = Stopwatch.StartNew();
        BrootForceAlgoritm selfBrootForceAlgoritm = new BrootForceAlgoritm(selfM, selfN, selfK, selfPark);
        var (selfBbrootForceX, selfBbrootForceS) = selfBrootForceAlgoritm.GetResult();
        selfBrootForceStopwatch.Stop();
        double selfBrootForceTime = selfBrootForceStopwatch.Elapsed.TotalMilliseconds;

        Console.WriteLine("Brute Force Algorithm:");
        selfVisualizer.ShowLamps(selfPark, selfBbrootForceX);
        Console.WriteLine($"S = {selfBbrootForceS}");
        Console.WriteLine($"Time = {selfBrootForceTime} ms");
        Console.WriteLine();

        streamWriter.WriteLine("Brute Force Algorithm:");
        selfFileVisualizer.ShowLamps(selfPark, selfBbrootForceX);
        streamWriter.WriteLine($"S = {selfBbrootForceS}");
        streamWriter.WriteLine($"Time = {selfBrootForceTime} ms");
        streamWriter.WriteLine();


        break;
    case 2:
        Console.WriteLine("Generator");
        //var generatorM = UserInputResiver.GetIntFromUser("M");
        //var generarorN = UserInputResiver.GetIntFromUser("N");
        //var generatorK = UserInputResiver.GetIntFromUser("K");
        //var generatorNumOfFields = UserInputResiver.GetIntFromUser("NumOfFields");
        //var generatorNumRepeat = UserInputResiver.GetIntFromUser("NumRepeat");

        var generatorM = 5;
        var generarorN = 6;
        var generatorK = 2;
        var generatorNumOfFields = 28;
        var generatorNumRepeat = 2;
        Visualizer generatorVisualizer = new Visualizer(generatorM, generarorN, generatorK);

        FileVisualizer generatorFileVisualizer = new FileVisualizer(generatorM, generarorN, generatorK, streamWriter);

        Generator generator = new Generator(generatorM, generarorN, generatorK, generatorNumOfFields);

        double totalGreedyTime = 0;
        double totalBrootForceTime = 0;

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

            Stopwatch greedyStopwatch = Stopwatch.StartNew();
            GreedyAlgoritm greedyAlgoritm = new GreedyAlgoritm(generatorM, generarorN, generatorK, generatorPark);
            var (greedyX, greedyS) = greedyAlgoritm.GetResult();
            greedyStopwatch.Stop();
            double greedyTime = greedyStopwatch.Elapsed.TotalMilliseconds;
            totalGreedyTime += greedyTime;

            Console.WriteLine("Greedy Algorithm:");
            generatorVisualizer.ShowLamps(generatorPark, greedyX);
            Console.WriteLine($"S = {greedyS}");
            Console.WriteLine($"Time = {greedyTime} ms");
            Console.WriteLine();

            streamWriter.WriteLine("Greedy Algorithm:");
            generatorFileVisualizer.ShowLamps(generatorPark, greedyX);
            streamWriter.WriteLine($"S = {greedyS}");
            streamWriter.WriteLine($"Time = {greedyTime} ms");
            streamWriter.WriteLine();

            Stopwatch brootForceStopwatch = Stopwatch.StartNew();
            BrootForceAlgoritm brootForceAlgoritm = new BrootForceAlgoritm(generatorM, generarorN, generatorK, generatorPark);
            var (brootForceX, brootForceS) = brootForceAlgoritm.GetResult();
            brootForceStopwatch.Stop();
            double brootForceTime = brootForceStopwatch.Elapsed.TotalMilliseconds;
            totalBrootForceTime += brootForceTime;

            Console.WriteLine("Brute Force Algorithm:");
            generatorVisualizer.ShowLamps(generatorPark, brootForceX);
            Console.WriteLine($"S = {brootForceS}");
            Console.WriteLine($"Time = {brootForceTime} ms");
            Console.WriteLine();

            streamWriter.WriteLine("Brute Force Algorithm:");
            generatorFileVisualizer.ShowLamps(generatorPark, brootForceX);
            streamWriter.WriteLine($"S = {brootForceS}");
            streamWriter.WriteLine($"Time = {brootForceTime} ms");
            streamWriter.WriteLine();
        }

        double averageGreedyTime = totalGreedyTime / generatorNumRepeat;
        double averageBrootForceTime = totalBrootForceTime / generatorNumRepeat;

        Console.WriteLine($"Average time for Greedy Algorithm: {averageGreedyTime} ms");
        Console.WriteLine($"Average time for Brute Force Algorithm: {averageBrootForceTime} ms");

        streamWriter.WriteLine($"Average time for Greedy Algorithm: {averageGreedyTime} ms");
        streamWriter.WriteLine($"Average time for Brute Force Algorithm: {averageBrootForceTime} ms");

        break;
    case 3:
        Console.WriteLine("File");
        Console.WriteLine("Enter File path");

        //string filePath = Console.ReadLine();
        string filePath = "D:\\Code\\C#\\ynik\\KyrsovaDo\\KyrsovaPark\\KyrsovaPark\\File.txt";

        var streamReader = new StreamReader(filePath);



        var fileM = int.Parse(streamReader.ReadLine());
        var fileN = int.Parse(streamReader.ReadLine());
        var fileK = int.Parse(streamReader.ReadLine());

        var fileGreenZones = streamReader.ReadLine().Split(",",StringSplitOptions.RemoveEmptyEntries);

        var filePark = new int[fileM * fileN];

        for (int i = 0; i < fileGreenZones.Length; i++)
        {
            filePark[int.Parse(fileGreenZones[i])-1] = 1;
        }

        Visualizer fileVisualizer = new Visualizer(fileM, fileN, fileK);


        FileVisualizer fileFileVisualizer = new FileVisualizer(fileM, fileN, fileK, streamWriter);



        fileVisualizer.ShowParkWithNumbers();
       
        Console.WriteLine("Input");
        fileVisualizer.ShowPark(filePark);
        Console.WriteLine($"M = {fileM}");
        Console.WriteLine($"N = {fileN}");
        Console.WriteLine($"K = {fileK}");

        streamWriter.WriteLine("Input");
        fileFileVisualizer.ShowPark(filePark);
        streamWriter.WriteLine($"M = {fileM}");
        streamWriter.WriteLine($"N = {fileN}");
        streamWriter.WriteLine($"K = {fileK}");

        Stopwatch fileGreedyStopwatch = Stopwatch.StartNew();
        GreedyAlgoritm fileGreedyAlgoritm = new GreedyAlgoritm(fileM, fileN, fileK, filePark);
        var (fileGreedyX, fileGreedyS) = fileGreedyAlgoritm.GetResult();
        fileGreedyStopwatch.Stop();
        double fileGreedyTime = fileGreedyStopwatch.Elapsed.TotalMilliseconds;

        Console.WriteLine("Greedy Algorithm:");
        fileVisualizer.ShowLamps(filePark, fileGreedyX);
        Console.WriteLine($"S = {fileGreedyS}");
        Console.WriteLine($"Time = {fileGreedyTime} ms");
        Console.WriteLine();

        streamWriter.WriteLine("Greedy Algorithm:");
        fileFileVisualizer.ShowLamps(filePark, fileGreedyX);
        streamWriter.WriteLine($"S = {fileGreedyS}");
        streamWriter.WriteLine($"Time = {fileGreedyTime} ms");
        streamWriter.WriteLine();

        Stopwatch fileBrootForceStopwatch = Stopwatch.StartNew();
        BrootForceAlgoritm fileBrootForceAlgoritm = new BrootForceAlgoritm(fileM, fileN, fileK, filePark);
        var (fileeBbrootForceX, fileBbrootForceS) = fileBrootForceAlgoritm.GetResult();
        fileBrootForceStopwatch.Stop();
        double fileBrootForceTime = fileBrootForceStopwatch.Elapsed.TotalMilliseconds;

        Console.WriteLine("Brute Force Algorithm:");
        fileVisualizer.ShowLamps(filePark, fileeBbrootForceX);
        Console.WriteLine($"S = {fileBbrootForceS}");
        Console.WriteLine($"Time = {fileBrootForceTime} ms");
        Console.WriteLine();

        streamWriter.WriteLine("Brute Force Algorithm:");
        fileFileVisualizer.ShowLamps(filePark, fileeBbrootForceX);
        streamWriter.WriteLine($"S = {fileBbrootForceS}");
        streamWriter.WriteLine($"Time = {fileBrootForceTime} ms");
        streamWriter.WriteLine();


        break;
}
streamWriter.Close();

