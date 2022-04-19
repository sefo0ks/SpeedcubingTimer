public class Solve
{
    double time;
    string scramble, savePath;
    DateTime date;

    public Solve(double time, string scramble, DateTime date)
    {
        this.time = time;
        this.scramble = scramble;
        this.date = date;

        savePath = @$"{Environment.CurrentDirectory}\Data\";
    }

    public void Show()
    {
        if (time > 60)
        {
            int minutes = (int)time / 60;
            Console.Write($"{minutes}min {Math.Round(time % 60, 3)}sec | {scramble}| " +
                $"{date.Day}.{date.Month}.{date.Year} ");
            if (date.Hour < 10)
                Console.Write($"0{date.Hour}:");
            else
                Console.Write($"{date.Hour}:");
            if (date.Minute < 10)
                Console.Write($"0{date.Minute}");
            else
                Console.Write($"{date.Minute}");
        } else
        {
            Console.Write($"{time}sec | {scramble} | " +
                $"{date.Day}.{date.Month}.{date.Year} ");

            if (date.Hour < 10)
                Console.Write($"0{date.Hour}:");
            else
                Console.Write($"{date.Hour}:");
            if (date.Minute < 10)
                Console.Write($"0{date.Minute}");
            else
                Console.Write($"{date.Minute}");
        }
        Console.WriteLine();
    }

    public void ShowWithMoreText()
    {
        if (time > 60)
        {
            int minutes = (int)time / 60;
            Console.Write($"Time: {minutes}min {Math.Round(time % 60, 3)}sec | Scrumble: {scramble} | " +
                $"Date: {date.Day}.{date.Month}.{date.Year} ");

            if (date.Hour < 10)
                Console.Write($"0{date.Hour}:");
            else
                Console.Write($"{date.Hour}:");
            if (date.Minute < 10)
                Console.Write($"0{date.Minute}");
            else
                Console.Write($"{date.Minute}");
        } else
        {
            Console.Write($"Time: {time}sec | Scrumble: {scramble} | " +
                $"Date: {date.Day}.{date.Month}.{date.Year} ");

            if (date.Hour < 10)
                Console.Write($"0{date.Hour}:");
            else
                Console.Write($"{date.Hour}:");
            if (date.Minute < 10)
                Console.Write($"0{date.Minute}");
            else
                Console.Write($"{date.Minute}");
        }
        Console.WriteLine();
    }

    public void Save()
    {
        if (!Directory.Exists(savePath))
            Directory.CreateDirectory(savePath);

        using (StreamWriter sw = File.AppendText(savePath + "solves.txt"))
        {
            sw.WriteLine($"{Math.Round(time, 3)}|{scramble}|{date}|");
        }
    }

    public double Time { get => time; }
    public string Scramble { get => scramble; }
    public DateTime Date { get => date; }

}
