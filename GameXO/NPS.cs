using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameXO
{
    class NPS
    {
        private int[] step;
        private int[,] tempField;
        private int[,] tempField2;
        private int score;
        private string[] lines;
        private int maxScore;

        GameLogic gameLogic;


        public NPS()
        {
            step = null;
            tempField = null;
            tempField2 = null;
            gameLogic = null;
            score = 0;
            lines = null;
            maxScore = 0;
        }

        public GameLogic getGameLogic()
        {
            return gameLogic;
        }

        private int[,] loadField(int row, int col)
        {
            int[,] tempField = new int[11, 11];
            for (int i = 0; i < 11; i++)
                for (int j = 0; j < 11; j++)
                {
                    tempField[i, j] = gameLogic.getDataMatrixOX(row + i - 5, col + j - 5);
                }
            return tempField;
        }

        public int[] stepSelection(int row, int col, GameLogic gameLogic)
        {
            step = null;
            this.gameLogic = gameLogic;
            tempField = loadField(row, col);
            score = 0;
            for (int i = 0; i < 11; i++)
                for (int j = 0; j < 11; j++)
                {
                    if (tempField[i, j] != 1 && tempField[i, j] != 2)
                    {
                        tempField2 = loadField(row + i - 5, col + j - 5);

                        lines = getLines();

                        for (int k = 0; k < 4; k++)
                        {
                            if (lines[3] == "00000011100")
                                MessageBox.Show(i + " " + j);
                            string line = lines[k];

                            if (openFourX(line))
                                score += 1000000;
                            else if (openTreeX(line))
                                score += 10000;
                            else if (closeFourX(line))
                                score += 10;

                            if (closeFourO(line))
                                score += 100000;
                            else if (openFourO(line))
                                score += 2000;
                            else if (closeFlourOX(line))
                                score += 1000;
                            else if (openTreeO(line))
                                score += 100;
                        }

                        if (maxScore < score)
                        {
                            if (tempField[i, j] == 0)
                            {
                                maxScore = score;
                                step = new int[] { row + i - 5, col + j - 5 };
                                MessageBox.Show(step[0] + " " + step[1] + "11111111111111111111111111111111");
                            }

                        }
                        score = 0;
                    }
                }
            if (maxScore == 0)
                step = randomStep(row, col);
            maxScore = 0;
            return step;
        }

        bool openFourX(string line)
        {
            int count = 0;
            int count2 = 0;
            bool flag = true;
            for (int i = 1; i < 10; i++)
            {
                if (line[i] == '2')
                {
                    count++;
                    count2++;
                    if (count == 4)
                        if (line[i - 4] == '0' && line[i + 1] == '0')
                            return true;
                }
                else if (flag)
                {
                    count2 = 0;
                    flag = false;
                }
                else
                {
                    flag = true;
                    count = count2;
                }
            }
            return false;
        }

        bool closeFourX(string line)
        {
            int count = 0;
            int count2 = 0;
            bool flag = true;
            for (int i = 1; i < 10; i++)
            {
                if (line[i] == '2')
                {
                    count++;
                    count2++;
                    if (count == 4)
                        if (line[i - 4] == '1' || line[i + 1] == '1')
                            return true;
                }
                else if (flag)
                {
                    count2 = 0;
                    flag = false;
                }
                else
                {
                    flag = true;
                    count = count2;
                }
            }
            return false;
        }

        bool openTreeX(string line)
        {
            int count = 0;
            int count2 = 0;
            bool flag = true;
            for (int i = 2; i < 9; i++)
            {
                if (line[i] == '2')
                {
                    count++;
                    count2++;
                    if (count == 3)
                        if (line[i - 3] == '0' && line[i + 1] == '0')
                            return true;
                }
                else if (flag)
                {
                    count2 = 0;
                    flag = false;
                }
                else
                {
                    flag = true;
                    count = count2;
                }
            }
            return false;
        }

        bool closeFourO(string line)
        {
            int count = 0;
            int count2 = 0;
            bool flag = true;
            for (int i = 1; i < 10; i++)
            {
                if (line[i] == '1')
                {
                    count++;
                    count2++;
                    if (count == 4)
                        if (line[i - 4] == '2' || line[i + 1] == '2')
                            return true;
                }
                else if (flag)
                {
                    count2 = 0;
                    flag = false;
                }
                else
                {
                    flag = true;
                    count = count2;
                }
            }
            return false;
        }

        bool openFourO(string line)
        {
            int count = 0;
            int count2 = 0;
            for (int i = 1; i < 10; i++)
            {
                if (i != 5)
                {
                    if (line[i] == '1')
                    {
                        count++;
                        count2++;
                        if (count == 3)
                            if (line[i - 3] == '0' && line[i + 1] == '0')
                                return true;
                    }
                    else
                    {
                        count = 0;
                    }
                }
            }
            return false;
        }

        bool closeFlourOX(string line)
        {
            int count = 0;
            int count2 = 0;
            for (int i = 2; i < 9; i++)
            {
                if (i != 5)
                {
                    if (line[i] == '1')
                    {
                        count++;
                        count2++;
                        if (count == 3)
                            if (line[i - 3] == '2' || line[i + 1] == '2')
                                return true;
                    }
                    else
                    {
                        count = 0;
                    }
                }
            }
            return false;
        }

        bool openTreeO(string line)
        {
            int count = 0;
            int count2 = 0;
            bool flag = true;
            if (line[4] == '1' || line[6] == '1')
            {
                for (int i = 2; i < 8; i++)
                {

                    if (line[i] == '1')
                    {
                        count++;
                        if (count == 2)
                            if (line[i - 2] == '0' && line[i + 1] == '0')
                                return true;
                    }
                    else if (flag)
                    {
                        count2 = 0;
                        flag = false;
                    }
                    else
                    {
                        flag = true;
                        count = count2;
                    }
                }
            }
            return false;
        }


        string[] getLines()
        {
            string[] tempLines = null;
            string line = null;
            for (int i = 0; i < 11; i++)
                line += tempField2[i, 5];
            tempLines = push(tempLines, line);
            line = null;
            for (int i = 0; i < 11; i++)
                line += tempField2[i, i];
            tempLines = push(tempLines, line);
            line = null;
            for (int i = 0; i < 11; i++)
                line += tempField2[5, i];
            tempLines = push(tempLines, line);
            line = null;
            for (int i = 0; i < 11; i++)
                line += tempField2[i, 10 - i];
            tempLines = push(tempLines, line);
            line = null;

            return tempLines;

        }

        string[] push(string[] arr, string value)
        {

            if (arr == null)
            {
                arr = new string[1];
                arr[0] = value;
                return arr;
            }
            int countEl = arr.Length + 1;
            string[] tempArr = new string[countEl];
            for (int i = 0; i < countEl - 1; i++)
            {
                tempArr[i] = arr[i];
            }
            tempArr[countEl - 1] = value;
            return tempArr;
        }


        private int[] randomStep(int row, int col)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (tempField[3 + i, 3 + j] == 0)
                        return step = new int[] { row - 1 + i, col - 1 + j };
                }
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    if (tempField[5 + i, 5 + j] == 0)
                        return step = new int[] { row - 2 + i, col - 2 + j };
                }
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 7; j++)
                {
                    if (tempField[7 + i, 7 + j] == 0)
                        return step = new int[] { row - 3 + i, col - 3 + j };
                }
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (tempField[9 + i, 9 + j] == 0)
                        return step = new int[] { row - 4 + i, col - 4 + j };
                }
            return step;
        }
    }
}
