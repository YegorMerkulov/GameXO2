using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameXO
{
    class GameLogic
    {
        MatrixOX matrixOX = new MatrixOX();

        private string wayOfCross = @"image\cross.png";
        private string wayOfZero = @"image\zero.png";

        public string getImageSelection(bool crossOfZero)
        {
            string temp = wayOfZero;
            if (crossOfZero) temp = wayOfCross;
            if (File.Exists(temp))
            {
                return temp;
            }
            else
            {
                MessageBox.Show("Файл изображения не найден: " + temp);
            }
            return null;
        }

        public void addDataMatrixOX(int row, int col, int data)
        {
            matrixOX.setPushMatrix(data, col, row);
        }

        public void matrixOXRemoveData()
        {
            matrixOX.setRemoveData();
        }

        public void movingUp()
        {
            matrixOX.setAddRowUp();

        }

        public void movingLeft()
        {
            matrixOX.setAddColLeft();

        }

        public void movingDown()
        {
            matrixOX.setAddRowDown();

        }

        public void movingRight()
        {
            matrixOX.setAddColRight();

        }

        public int[,] loadInfo()
        {

            int[,] temp = new int[6, 6];
            for (int i = 1; i < 6; i++)
                for (int j = 1; j < 6; j++)
                    if (matrixOX.getData(i,j)!= 0)
                        temp[i, j] = matrixOX.getData(i, j);

            return temp;
        }

        public bool checkWin(int data, int row, int col)
        {
            int countWin = 0;
            int[,] tempField = new int[9, 9];
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    int tempData = matrixOX.getData(row + i - 4, col + j - 4);
                    if (tempData == data)
                    {
                        tempField[i, j] = tempData;
                    }
                }

            for (int i = 0; i < 9; i++)
                if (tempField[i, i] == data)
                {
                    countWin++;
                    if (countWin > 4)
                        return true;
                }
                else countWin = 0;

            for (int i = 0; i < 9; i++)
                if (tempField[i, col] == data)
                {
                    countWin++;
                    if (countWin > 4)
                        return true;
                }
                else countWin = 0;

            for (int i = 0; i < 9; i++)
                if (tempField[row, i] == data)
                {
                    countWin++;
                    if (countWin > 4)
                        return true;
                }
                else countWin = 0;

            return false;
        }

    }
}
