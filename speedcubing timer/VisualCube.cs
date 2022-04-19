using System.Diagnostics;

public class VisualCube
{
    string scramble = "";

    int[,] whiteSide =
        {
            { 0, 0, 0 },
            { 0, 0, 0 },
            { 0, 0, 0 },
        };
    int[,] orangeSide =
        {
            { 1, 1, 1 },
            { 1, 1, 1 },
            { 1, 1, 1 },
        };
    int[,] greenSide =
        {
            { 2, 2, 2 },
            { 2, 2, 2 },
            { 2, 2, 2 },
        };
    int[,] redSide =
        {
            { 3, 3, 3 },
            { 3, 3, 3 },
            { 3, 3, 3 },
        };
    int[,] yellowSide =
        {
            { 4, 4, 4 },
            { 4, 4, 4 },
            { 4, 4, 4 },
        };
    int[,] blueSide =
        {
            { 5, 5, 5 },
            { 5, 5, 5 },
            { 5, 5, 5 },
        };
    int[][,] cube = new int[6][,];

    public VisualCube()
    {
        cube[0] = whiteSide;
        cube[1] = orangeSide;
        cube[2] = greenSide;
        cube[3] = redSide;
        cube[4] = yellowSide;
        cube[5] = blueSide;
    }

    public void Update(char scrambleChar, char modifier)
    {
        scrambleChar = scrambleChar.ToString().ToUpper()[0];

        if (scrambleChar == 'U')
        {
            if (modifier == ' ')
            {
                #region top
                int[] ca0 = { cube[0][0, 0], cube[0][0, 2], cube[0][2, 2], cube[0][2, 0] };
                int[] ce0 = { cube[0][0, 1], cube[0][1, 2], cube[0][2, 1], cube[0][1, 0] };
                // angles
                cube[0][0, 2] = ca0[0];
                cube[0][2, 2] = ca0[1];
                cube[0][2, 0] = ca0[2];
                cube[0][0, 0] = ca0[3];
                // edges
                cube[0][1, 2] = ce0[0];
                cube[0][2, 1] = ce0[1];
                cube[0][1, 0] = ce0[2];
                cube[0][0, 1] = ce0[3];
                #endregion
                #region sides
                for (int i = 0; i < 3; i++)
                {
                    int temp = cube[1][0, 0];
                    // orange
                    int[] c1 = { cube[1][0, 1], cube[1][0, 2], cube[2][0, 0] };
                    cube[1][0, 0] = c1[0];
                    cube[1][0, 1] = c1[1];
                    cube[1][0, 2] = c1[2];
                    // green
                    int[] c2 = { cube[2][0, 1], cube[2][0, 2], cube[3][0, 0] };
                    cube[2][0, 0] = c2[0];
                    cube[2][0, 1] = c2[1];
                    cube[2][0, 2] = c2[2];
                    // red
                    int[] c3 = { cube[3][0, 1], cube[3][0, 2], cube[5][2, 2] };
                    cube[3][0, 0] = c3[0];
                    cube[3][0, 1] = c3[1];
                    cube[3][0, 2] = c3[2];
                    // blue
                    int[] c5 = { cube[5][2, 1], cube[5][2, 0], temp };
                    cube[5][2, 2] = c5[0];
                    cube[5][2, 1] = c5[1];
                    cube[5][2, 0] = c5[2];
                }
                #endregion
            }
            else if (modifier == '2')
            {
                Update('U', ' ');
                Update('U', ' ');
            }
            else if (modifier == '\'')
            {
                Update('U', ' ');
                Update('U', ' ');
                Update('U', ' ');
            }
        }
        else if (scrambleChar == 'R')
        {
            if (modifier == ' ')
            {
                #region right
                int[] ca3 = { cube[3][0, 0], cube[3][0, 2], cube[3][2, 2], cube[3][2, 0] };
                int[] ce3 = { cube[3][0, 1], cube[3][1, 2], cube[3][2, 1], cube[3][1, 0] };
                // angles
                cube[3][0, 2] = ca3[0];
                cube[3][2, 2] = ca3[1];
                cube[3][2, 0] = ca3[2];
                cube[3][0, 0] = ca3[3];
                // edges
                cube[3][1, 2] = ce3[0];
                cube[3][2, 1] = ce3[1];
                cube[3][1, 0] = ce3[2];
                cube[3][0, 1] = ce3[3];
                #endregion
                #region sides
                for (int i = 0; i < 3; i++)
                {
                    int temp = cube[0][0, 2];
                    // white
                    int[] c0 = { cube[0][1, 2], cube[0][2, 2], cube[2][0, 2] };
                    cube[0][0, 2] = c0[0];
                    cube[0][1, 2] = c0[1];
                    cube[0][2, 2] = c0[2];
                    // green
                    int[] c2 = { cube[2][1, 2], cube[2][2, 2], cube[4][0, 2] };
                    cube[2][0, 2] = c2[0];
                    cube[2][1, 2] = c2[1];
                    cube[2][2, 2] = c2[2];
                    // yellow
                    int[] c4 = { cube[4][1, 2], cube[4][2, 2], cube[5][0, 2] };
                    cube[4][0, 2] = c4[0];
                    cube[4][1, 2] = c4[1];
                    cube[4][2, 2] = c4[2];
                    // blue
                    int[] c5 = { cube[5][1, 2], cube[5][2, 2], temp };
                    cube[5][0, 2] = c5[0];
                    cube[5][1, 2] = c5[1];
                    cube[5][2, 2] = c5[2];
                }
                #endregion
            }
            else if (modifier == '2')
            {
                Update('R', ' ');
                Update('R', ' ');
            }
            else if (modifier == '\'')
            {
                Update('R', ' ');
                Update('R', ' ');
                Update('R', ' ');
            }
        }
        else if (scrambleChar == 'F')
        {
            if (modifier == ' ')
            {
                #region front
                int[] ca2 = { cube[2][0, 0], cube[2][0, 2], cube[2][2, 2], cube[2][2, 0] };
                int[] ce2 = { cube[2][0, 1], cube[2][1, 2], cube[2][2, 1], cube[2][1, 0] };
                // angles
                cube[2][0, 2] = ca2[0];
                cube[2][2, 2] = ca2[1];
                cube[2][2, 0] = ca2[2];
                cube[2][0, 0] = ca2[3];
                // edges
                cube[2][1, 2] = ce2[0];
                cube[2][2, 1] = ce2[1];
                cube[2][1, 0] = ce2[2];
                cube[2][0, 1] = ce2[3];
                #endregion
                #region sides
                for (int i = 0; i < 3; i++)
                {
                    int temp = cube[0][2, 2];
                    // white
                    int[] c0 = { cube[0][2, 1], cube[0][2, 0], cube[1][0, 2] };
                    cube[0][2, 2] = c0[0];
                    cube[0][2, 1] = c0[1];
                    cube[0][2, 0] = c0[2];
                    // orange
                    int[] c1 = { cube[1][1, 2], cube[1][2, 2], cube[4][0, 0] };
                    cube[1][0, 2] = c1[0];
                    cube[1][1, 2] = c1[1];
                    cube[1][2, 2] = c1[2];
                    // yellow
                    int[] c4 = { cube[4][0, 1], cube[4][0, 2], cube[3][2, 0] };
                    cube[4][0, 0] = c4[0];
                    cube[4][0, 1] = c4[1];
                    cube[4][0, 2] = c4[2];
                    // red
                    int[] c3 = { cube[3][1, 0], cube[3][0, 0], temp };
                    cube[3][2, 0] = c3[0];
                    cube[3][1, 0] = c3[1];
                    cube[3][0, 0] = c3[2];
                }
                #endregion
            }
            else if (modifier == '2')
            {
                Update('F', ' ');
                Update('F', ' ');
            }
            else if (modifier == '\'')
            {
                Update('F', ' ');
                Update('F', ' ');
                Update('F', ' ');
            }
        }
        else if (scrambleChar == 'D')
        {
            if (modifier == ' ')
            {
                #region bottom
                int[] ca4 = { cube[4][0, 0], cube[4][0, 2], cube[4][2, 2], cube[4][2, 0] };
                int[] ce4 = { cube[4][0, 1], cube[4][1, 2], cube[4][2, 1], cube[4][1, 0] };
                // angles
                cube[4][0, 2] = ca4[0];
                cube[4][2, 2] = ca4[1];
                cube[4][2, 0] = ca4[2];
                cube[4][0, 0] = ca4[3];
                // edges
                cube[4][1, 2] = ce4[0];
                cube[4][2, 1] = ce4[1];
                cube[4][1, 0] = ce4[2];
                cube[4][0, 1] = ce4[3];
                #endregion
                #region sides
                for (int i = 0; i < 3; i++)
                {
                    int temp = cube[1][2, 2];
                    // orange
                    int[] c1 = { cube[1][2, 1], cube[1][2, 0], cube[5][0, 0] };
                    cube[1][2, 2] = c1[0];
                    cube[1][2, 1] = c1[1];
                    cube[1][2, 0] = c1[2];
                    // blue
                    int[] c5 = { cube[5][0, 1], cube[5][0, 2], cube[3][2, 2] };
                    cube[5][0, 0] = c5[0];
                    cube[5][0, 1] = c5[1];
                    cube[5][0, 2] = c5[2];
                    // red
                    int[] c3 = { cube[3][2, 1], cube[3][2, 0], cube[2][2, 2] };
                    cube[3][2, 2] = c3[0];
                    cube[3][2, 1] = c3[1];
                    cube[3][2, 0] = c3[2];
                    // green
                    int[] c2 = { cube[2][2, 1], cube[2][2, 0], temp };
                    cube[2][2, 2] = c2[0];
                    cube[2][2, 1] = c2[1];
                    cube[2][2, 0] = c2[2];
                }
                #endregion
            }
            else if (modifier == '2')
            {
                Update('D', ' ');
                Update('D', ' ');
            }
            else if (modifier == '\'')
            {
                Update('D', ' ');
                Update('D', ' ');
                Update('D', ' ');
            }
        }
        else if (scrambleChar == 'L')
        {
            if (modifier == ' ')
            {
                #region left
                int[] ca1 = { cube[1][0, 0], cube[1][0, 2], cube[1][2, 2], cube[1][2, 0] };
                int[] ce1 = { cube[1][0, 1], cube[1][1, 2], cube[1][2, 1], cube[1][1, 0] };
                // angles
                cube[1][0, 2] = ca1[0];
                cube[1][2, 2] = ca1[1];
                cube[1][2, 0] = ca1[2];
                cube[1][0, 0] = ca1[3];
                // edges
                cube[1][1, 2] = ce1[0];
                cube[1][2, 1] = ce1[1];
                cube[1][1, 0] = ce1[2];
                cube[1][0, 1] = ce1[3];
                #endregion
                #region sides
                for (int i = 0; i < 3; i++)
                {
                    int temp = cube[0][2, 0];
                    // white
                    int[] c0 = { cube[0][1, 0], cube[0][0, 0], cube[5][2, 0] };
                    cube[0][2, 0] = c0[0];
                    cube[0][1, 0] = c0[1];
                    cube[0][0, 0] = c0[2];
                    // blue
                    int[] c5 = { cube[5][1, 0], cube[5][0, 0], cube[4][2, 0] };
                    cube[5][2, 0] = c5[0];
                    cube[5][1, 0] = c5[1];
                    cube[5][0, 0] = c5[2];
                    // yellow
                    int[] c4 = { cube[4][1, 0], cube[4][0, 0], cube[2][2, 0] };
                    cube[4][2, 0] = c4[0];
                    cube[4][1, 0] = c4[1];
                    cube[4][0, 0] = c4[2];
                    // green
                    int[] c2 = { cube[2][1, 0], cube[2][0, 0], temp };
                    cube[2][2, 0] = c2[0];
                    cube[2][1, 0] = c2[1];
                    cube[2][0, 0] = c2[2];
                }
                #endregion
            }
            else if (modifier == '2')
            {
                Update('L', ' ');
                Update('L', ' ');
            }
            else if (modifier == '\'')
            {
                Update('L', ' ');
                Update('L', ' ');
                Update('L', ' ');
            }
        }
        else if (scrambleChar == 'B')
        {
            if (modifier == ' ')
            {
                #region back
                int[] ca5 = { cube[5][0, 0], cube[5][0, 2], cube[5][2, 2], cube[5][2, 0] };
                int[] ce5 = { cube[5][0, 1], cube[5][1, 2], cube[5][2, 1], cube[5][1, 0] };
                // angles
                cube[5][0, 2] = ca5[0];
                cube[5][2, 2] = ca5[1];
                cube[5][2, 0] = ca5[2];
                cube[5][0, 0] = ca5[3];
                // edges
                cube[5][1, 2] = ce5[0];
                cube[5][2, 1] = ce5[1];
                cube[5][1, 0] = ce5[2];
                cube[5][0, 1] = ce5[3];
                #endregion
                #region sides
                for (int i = 0; i < 3; i++)
                {
                    int temp = cube[0][0, 0];
                    // white
                    int[] c0 = { cube[0][0, 1], cube[0][0, 2], cube[3][0, 2] };
                    cube[0][0, 0] = c0[0];
                    cube[0][0, 1] = c0[1];
                    cube[0][0, 2] = c0[2];
                    // red
                    int[] c3 = { cube[3][1, 2], cube[3][2, 2], cube[4][2, 2] };
                    cube[3][0, 2] = c3[0];
                    cube[3][1, 2] = c3[1];
                    cube[3][2, 2] = c3[2];
                    // yellow
                    int[] c4 = { cube[4][2, 1], cube[4][2, 0], cube[1][2, 0] };
                    cube[4][2, 2] = c4[0];
                    cube[4][2, 1] = c4[1];
                    cube[4][2, 0] = c4[2];
                    // orange
                    int[] c1 = { cube[1][1, 0], cube[1][0, 0], temp };
                    cube[1][2, 0] = c1[0];
                    cube[1][1, 0] = c1[1];
                    cube[1][0, 0] = c1[2];
                }
                #endregion
            }
            else if (modifier == '2')
            {
                Update('B', ' ');
                Update('B', ' ');
            }
            else if (modifier == '\'')
            {
                Update('B', ' ');
                Update('B', ' ');
                Update('B', ' ');
            }
        }
    }

    public void Draw()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (i != 1)
                    Console.Write("      ");
                for (int k = 0; k < 3; k++)
                {
                    DrawPixel(cube[i][j, k]);
                }
                if (i == 1)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        DrawPixel(cube[i + 1][j, k]);
                    }
                    for (int k = 0; k < 3; k++)
                    {
                        DrawPixel(cube[i + 2][j, k]);
                    }
                }
                Console.WriteLine();
            }
            if (i == 1)
                i += 2;
        }
    }

    public void DrawUpdateAndResetAfter(bool animate, int intervalInMilliseconds = 40, string savedTextBeforeImage = "")
    {
        if (String.IsNullOrWhiteSpace(scramble))
            return;

        String.Concat(scramble.Where(c => !Char.IsWhiteSpace(c)));
        Stopwatch sw = new Stopwatch();
        sw.Start();

        int i = 0;
        while (true)
        {
            if (!animate || sw.ElapsedMilliseconds > intervalInMilliseconds)
            {
                if (i < scramble.Length)
                    if (i < scramble.Length - 1)
                    {
                        if (scramble[i + 1] == '2' || scramble[i + 1] == '\'')
                        {
                            Update(scramble[i], scramble[i + 1]);
                            i++;
                        }
                        else
                        {
                            Update(scramble[i], ' ');
                        }
                    }
                    else
                        Update(scramble[i], ' ');

                if (animate)
                {
                    Console.Clear();
                    Console.WriteLine(savedTextBeforeImage);
                    Draw();
                }
                sw.Restart();

                if (i == scramble.Length)
                    break;
                i++;
            }
        }
        if (!animate)
        {
            Console.Clear();
            Console.WriteLine(savedTextBeforeImage);
            Draw();
        }
        Reset();
    }

    private void DrawPixel(int cubePoint)
    {
        switch (cubePoint)
        {
            case 0:
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 1:
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case 3:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case 4:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case 5:
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
        }
        Console.Write("██");
        Console.ResetColor();
    }

    private void Reset()
    {
        for (int i = 0; i < 6; i++)
            for (int j = 0; j < 3; j++)
                for (int k = 0; k < 3; k++)
                    cube[i][j, k] = i;
    }

    public string Scramble { get => scramble; set => scramble = value; }

}