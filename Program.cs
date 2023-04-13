#region Main Program
{
    string marbleRun = args[0];

    var visitedPositions = new HashSet<int>();
    int segments = 0, teleports = 0, i = 0;
    
    for (; i < marbleRun.Length; segments++)
    {
        if (!IsValidMarbleRun(visitedPositions, i))
        {
            Console.WriteLine("Infinite loop detected. Run aborted.");
            return;
        }
        else { visitedPositions.Add(i); }

        switch (marbleRun[i])
        {
            case '<': i--; break;
            case '>': i++; break;
            default:
                segments--;
                teleports++;
                i = GetTeleport(marbleRun, i);
                break;
        }
    }

    Console.WriteLine($"\n# of segments: {segments}");
    Console.WriteLine($"# of teleports: {teleports}");
}
#endregion

#region Methods
bool IsValidMarbleRun(HashSet<int> visitedPositions, int currentPosition) => !visitedPositions.Contains(currentPosition);

int GetTeleport(string marbleRun, int index)
{
    const int DECIMAL_LENGTH = 4, HEXADECIMAL_LENGTH = 6;

    bool numbersIsAfter = char.IsDigit(marbleRun[index + 2]);
    bool isHexadecimal = marbleRun[index + (numbersIsAfter ? 1 : -4)] == 'x';

    int numberLength = isHexadecimal ? HEXADECIMAL_LENGTH : DECIMAL_LENGTH;
    string number = marbleRun.Substring(index + (numbersIsAfter ? 0 : -(numberLength - 1)), numberLength);

    return Convert.ToInt32(number, isHexadecimal ? 16 : 10);
}
#endregion
