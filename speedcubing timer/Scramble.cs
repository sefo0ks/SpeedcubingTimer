public class Scramble
{
    int scrambleLength = 22;
    string scramble = "";
    char[] scrambleSymbols = { 'R', 'L', 'U', 'D', 'F', 'B' };
    char[] modifiers = { '\'', '2' };

    public string Generate()
    {
        scramble = "";
        char prevChar = ' ';
        Random random = new Random();
        int index = random.Next(scrambleSymbols.Length);
        bool addModifier = false;
        for (int i = 0; i < scrambleLength; i++)
        {
            if (i != 0)
            {
                index = random.Next(scrambleSymbols.Length);
                addModifier = random.Next(2) == 0 ? true : false;
            }

            while (prevChar == scrambleSymbols[index]
                || (prevChar == 'U' && scrambleSymbols[index] == 'D') || (prevChar == 'D' && scrambleSymbols[index] == 'U')
                || (prevChar == 'R' && scrambleSymbols[index] == 'L') || (prevChar == 'L' && scrambleSymbols[index] == 'R')
                || (prevChar == 'F' && scrambleSymbols[index] == 'B') || (prevChar == 'B' && scrambleSymbols[index] == 'F'))
            {
                index = random.Next(scrambleSymbols.Length);
            }

            scramble += scrambleSymbols[index];
            prevChar = scrambleSymbols[index];
            if (addModifier)
                scramble += modifiers[random.Next(2)];
            scramble += " ";
        }
        scramble = scramble.Remove(scramble.Length - 1);
        
        return scramble;
    }

    public void Show()
    {
        if (scramble == "")
            Generate();
        Console.WriteLine(scramble);
    }

    public string GetScramble { get => scramble; }
   
}