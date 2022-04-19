using System.Diagnostics;

bool programCycle = true;

List<Solve> allSolves = new List<Solve>();
Scramble scramble = new Scramble();
SpeedcubingTimer timer = new SpeedcubingTimer();
VisualCube cube = new VisualCube();
bool doAnimation = false;

string savePath = @$"{Environment.CurrentDirectory}\Data";
string solvesSavePath = @$"{savePath}\solves.txt";
string settingsSavePath = @$"{savePath}\settings.txt";

void OnLoad()
{
    if (!Directory.Exists(savePath) || !File.Exists(solvesSavePath))
        return;

    ReadFromSavedSolves();

    if (!File.Exists(settingsSavePath))
        return;

    LoadSettings();
}
void LoadSettings()
{
    bool fail = false;

    using (StreamReader sr = new StreamReader(settingsSavePath))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            line = line.Replace($"{SettingsChange.Animation.ToString()}=", "");
            try
            {
                doAnimation = bool.Parse(line);
            } catch
            {
                do
                    Console.WriteLine("Some setting failed to load.\nConfigure program again, settings file is going to be deleted\nPress Enter to continue");
                while (GetInput(true) != Result.Continue);
                fail = true;
            }
        }
    }
    if (fail)
        File.Delete(settingsSavePath);

}

// Add solves to allSolves Collection
void ReadFromSavedSolves()
{
    allSolves.Clear();
    using (StreamReader sr = new StreamReader(solvesSavePath))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            double time;
            string scramble = "";
            DateTime date;

            string temp = "";
            int stickCount = 0;

            foreach (char ch in line)
            {
                if (ch == '|')
                    break;

                temp += ch;
            }
            time = Convert.ToDouble(temp);
            temp = "";
            stickCount = 0;

            foreach (char ch in line)
            {
                if (stickCount == 2)
                    break;
                if (ch == '|')
                    stickCount++;
                if (stickCount == 1)
                    scramble += ch;
            }
            scramble = scramble.Remove(0, 1);
            stickCount = 0;

            foreach (char ch in line)
            {
                if (stickCount == 3)
                    break;
                if (ch == '|')
                    stickCount++;
                if (stickCount == 2)
                    temp += ch;
            }
            date = Convert.ToDateTime(temp.Remove(0, 1));
            temp = "";
            stickCount = 0;

            allSolves.Add(new Solve(time, scramble, date));
        }
    }
}
void DeleteLastSolve()
{
    string tempFile = Path.GetTempFileName();

    using (var sr = new StreamReader(solvesSavePath))
    using (var sw = new StreamWriter(tempFile))
    {
        string line;
        int index = 0;

        while ((line = sr.ReadLine()) != null)
        {
            if (index == allSolves.Count - 1)
                break;

            index++;
            sw.WriteLine(line);
        }
    }

    File.Delete(solvesSavePath);
    File.Move(tempFile, solvesSavePath);

    ReadFromSavedSolves();
}
void SaveSolveAndStopTimer()
{
    timer.StopAndGetTime();
    new Solve(timer.GetDoubleTime(), scramble.GetScramble, DateTime.Now).Save();
    ReadFromSavedSolves();
}

void ChangeSetting(SettingsChange needToChange)
{
    if (needToChange == SettingsChange.Animation)
        doAnimation = !doAnimation;

    File.Delete(settingsSavePath);
    using (StreamWriter sw = File.AppendText(settingsSavePath))
    {
        sw.WriteLine($"{SettingsChange.Animation.ToString()}={doAnimation}");
    }
}
Result GetInput(bool requireInput = false)
{
    if (!Console.KeyAvailable && !requireInput)
        return Result.Nothing;

    ConsoleKey inputKey = Console.ReadKey().Key;

    if (timer.OnGoing)
        return Result.TimerStopped;
    else if (inputKey == ConsoleKey.Q)
        return Result.Quit;
    else if (inputKey == ConsoleKey.D)
        return Result.SolveDeleted;
    else if (!timer.OnGoing && inputKey == ConsoleKey.Spacebar)
        return Result.TimerStarted;
    else if (inputKey == ConsoleKey.Enter)
        return Result.Continue;
    else if (inputKey == ConsoleKey.A)
        return Result.ShowAllSolves;
    else if (inputKey == ConsoleKey.RightArrow)
        return Result.Next;
    else if (inputKey == ConsoleKey.LeftArrow)
        return Result.Previous;
    else if (inputKey == ConsoleKey.M)
        return Result.ToggleAnimation;

    return Result.Nothing;
}
void HandleInput(Result input)
{
    if (input == Result.Nothing)
        return;

    if (input == Result.Quit)
        Quit();
    else if (input == Result.TimerStarted)
        timer.Start();
    else if (input == Result.TimerStopped)
        SaveSolveAndStopTimer();
    else if (input == Result.SolveDeleted)
        DeleteLastSolve();
    else if (input == Result.ShowAllSolves)
        ShowAllSolves();
    else if (input == Result.ToggleAnimation)
        ChangeSetting(SettingsChange.Animation);

    return;
}

void ShowAllSolves()
{
    int solvesPerPage = 15;
    int pageIndex = 0;
    int maxPage = (int)allSolves.Count / 15;
    int solveStartIndexOnPage;

    do
    {
        Console.Clear();
        Console.WriteLine($"All solves: (Page {pageIndex + 1}/{maxPage + 1})");
        if (allSolves.Count < 1)
        {
            Console.WriteLine("No solves fo far.");
        } else
        {
            solveStartIndexOnPage = solvesPerPage * pageIndex;
            for (int i = solveStartIndexOnPage; i < solvesPerPage * (pageIndex + 1); i++)
            {
                if (i > allSolves.Count - 1)
                    break;
                Console.Write($"{i + 1}: ");
                allSolves[i].Show();
            }
        }
        Console.WriteLine();
        if (pageIndex < maxPage)
            Console.WriteLine("(?) Press -> to go to next page");
        if (pageIndex > 0)
            Console.WriteLine("(?) Press <- to go to previous page");
        Console.WriteLine("(?) Press Enter to get back");

        switch (GetInput(true))
        {
            case Result.Continue:
                return;
            case Result.Next:
                if (pageIndex < maxPage)
                    pageIndex++;
                break;
            case Result.Previous:
                if (pageIndex > 0)
                    pageIndex--;
                break;
        }
    } while (true);
}
void DisplayTimer()
{
    Console.Clear();
    Console.WriteLine(timer.GetTime());

    Stopwatch sw = new Stopwatch();
    sw.Restart();
    while (sw.ElapsedMilliseconds <= 50)
    {
        if (GetInput() == Result.TimerStopped)
        { 
            Result result = Result.Nothing;
            HandleInput(Result.TimerStopped);
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Your time: {timer.GetTime()}");
                ShowControlsAfterSolve();

                result = GetInput(true);
                if (result == Result.Continue ||
                    result == Result.SolveDeleted ||
                    result == Result.Quit)
                    break;
            }

            HandleInput(result);
            Console.Clear();
            return;
        }
    }
    sw.Restart();
}

void ShowControls()
{
    Console.WriteLine();
    Console.WriteLine("(?) Press ANY KEY to re-scramble");
    Console.WriteLine("(?) Press SPACEBAR to start timer");
    Console.WriteLine("(?) Press A to see all solves");
    Console.WriteLine("(?) Press D to delete last solve");
    Console.WriteLine("(?) Press M to toggle animation");
    Console.WriteLine("(?) Press Q to quit");
}
void ShowControlsAfterSolve()
{
    Console.WriteLine();
    Console.WriteLine("(?) Press D to delete last solve");
    Console.WriteLine("(?) Press Q to quit");
    Console.WriteLine("(?) Press ENTER to continue");
}

void Quit()
{
    Console.Clear();
    Console.WriteLine("Goodbye :)");
    Console.ReadKey();
    programCycle = false;
}

OnLoad();
while (programCycle)
{
    Console.Clear();
    Console.WriteLine("Scramble");
    scramble.GenerateScramble();
    cube.Scramble = scramble.GetScramble;
    cube.DrawUpdateAndResetAfter(doAnimation, 20, $"Scramble\n{cube.Scramble}\n");
    ShowControls();

    HandleInput(GetInput(true));

    while (timer.OnGoing)
    {
        DisplayTimer();
    }
}
