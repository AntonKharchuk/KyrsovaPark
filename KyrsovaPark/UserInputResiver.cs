
namespace KyrsovaPark
{
    public class UserInputResiver
    {
        public int GetIntFromUser(string variableName)
        {
            int variable = -1;
            while (variable<=0)
            {
                Console.WriteLine($"Enter {variableName}:");
                int.TryParse(Console.ReadLine(), out variable);
            }
            return variable;
        }
    }
}
