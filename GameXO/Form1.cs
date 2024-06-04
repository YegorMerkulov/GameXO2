using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameXO
{
    public partial class Form1 : Form
    {

        GameLogic gameLogic = new GameLogic();
        NPS nps = new NPS();

        int[,] cell;
        bool crossOfZero = true;
        bool playingBot = false;
        int tempRow, tempCol;

        public Form1()
        {
            InitializeComponent();
            cell = new int[6,6];
            tempRow = 0;
            tempCol = 0;
        }

        private void field11_Click(object sender, EventArgs e)
        {
            int row = 1;
            int col = 1;
            fieldClick(row, col);

        }

        private void field12_Click_1(object sender, EventArgs e)
        {
            int row = 1;
            int col = 2;
            fieldClick(row, col);
        }

        private void field13_Click(object sender, EventArgs e)
        {
            int row = 1;
            int col = 3;
            fieldClick(row, col);
        }

        private void field14_Click(object sender, EventArgs e)
        {
            int row = 1;
            int col = 4;
            fieldClick(row, col);
        }

        private void field15_Click(object sender, EventArgs e)
        {
            int row = 1;
            int col = 5;
            fieldClick(row, col);
        }

        private void field21_Click(object sender, EventArgs e)
        {
            int row = 2;
            int col = 1;
            fieldClick(row, col);
        }

        private void field22_Click(object sender, EventArgs e)
        {
            int row = 2;
            int col = 2;
            fieldClick(row, col);
        }

        private void field23_Click(object sender, EventArgs e)
        {
            int row = 2;
            int col = 3;
            fieldClick(row, col);
        }

        private void field24_Click(object sender, EventArgs e)
        {
            int row = 2;
            int col = 4;
            fieldClick(row, col);
        }

        private void field25_Click(object sender, EventArgs e)
        {
            int row = 2;
            int col = 5;
            fieldClick(row, col);
        }

        private void field31_Click(object sender, EventArgs e)
        {
            int row = 3;
            int col = 1;
            fieldClick(row, col);
        }

        private void field32_Click(object sender, EventArgs e)
        {
            int row = 3;
            int col = 2;
            fieldClick(row, col);
        }

        private void field33_Click(object sender, EventArgs e)
        {
            int row = 3;
            int col = 3;
            fieldClick(row, col);
        }

        private void field34_Click(object sender, EventArgs e)
        {
            int row = 3;
            int col = 4;
            fieldClick(row, col);
        }

        private void field35_Click(object sender, EventArgs e)
        {
            int row = 3;
            int col = 5;
            fieldClick(row, col);
        }

        private void field41_Click(object sender, EventArgs e)
        {
            int row = 4;
            int col = 1;
            fieldClick(row, col);
        }

        private void field42_Click(object sender, EventArgs e)
        {
            int row = 4;
            int col = 2;
            fieldClick(row, col);
        }

        private void field43_Click(object sender, EventArgs e)
        {
            int row = 4;
            int col = 3;
            fieldClick(row, col);
        }

        private void field44_Click(object sender, EventArgs e)
        {
            int row = 4;
            int col = 4;
            fieldClick(row, col);
        }

        private void field45_Click(object sender, EventArgs e)
        {
            int row = 4;
            int col = 5;
            fieldClick(row, col);
        }

        private void field51_Click(object sender, EventArgs e)
        {
            int row = 5;
            int col = 1;
            fieldClick(row, col);
        }

        private void field52_Click(object sender, EventArgs e)
        {
            int row = 5;
            int col = 2;
            fieldClick(row, col);
        }

        private void field53_Click(object sender, EventArgs e)
        {
            int row = 5;
            int col = 3;
            fieldClick(row, col);
        }

        private void field54_Click(object sender, EventArgs e)
        {
            int row = 5;
            int col = 4;
            fieldClick(row, col);
        }

        private void field55_Click(object sender, EventArgs e)
        {
            int row = 5;
            int col = 5;
            fieldClick(row, col);
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            gameLogic.movingUp();
            loadInfo();

        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            gameLogic.movingLeft();
            loadInfo();
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            gameLogic.movingDown();
            loadInfo();
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            gameLogic.movingRight();
            loadInfo();
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addCellInfo(int row, int col, bool crossOfZero)
        {
            if (gameLogic.getDataMatrixOX(row, col) == 0)
            {
                int number = 2;
                if (crossOfZero) number = 1;
                this.crossOfZero = !crossOfZero;
                gameLogic.addDataMatrixOX(row, col, number);
                loadInfo();
                if (gameLogic.checkWin(number, row, col))
                {
                    string winner;
                    if (number == 1)
                    {
                        winner = "крестики";
                    }
                    else
                    {
                        winner = "нолики";
                    }
                    MessageBox.Show("Выйграли " + winner + "!");
                    newGame();

                }        

            }
        }

        private Image getImage()
        {
            string tempImage = gameLogic.getImageSelection(crossOfZero);
            if (tempImage == null) return null;
            return Image.FromFile(tempImage);
        }

        private void loadInfo()
        {
            cell = gameLogic.loadInfo();
            Image[,] tempImage = new Image[6,6];

            for (int i = 1; i < 6; i++)
                for (int j = 1; j < 6; j++)
                    if (cell[i, j] == 1)
                    {
                        tempImage[i, j] = Image.FromFile(gameLogic.getImageSelection(true));
                    }
                    else if (cell[i, j] == 2)
                    {
                        tempImage[i, j] = Image.FromFile(gameLogic.getImageSelection(false));
                    }
                    else
                    {
                        tempImage[i, j] = null;
                    }

            field11.Image = tempImage[1, 1];
            field12.Image = tempImage[1, 2];
            field13.Image = tempImage[1, 3];
            field14.Image = tempImage[1, 4];
            field15.Image = tempImage[1, 5];
            field21.Image = tempImage[2, 1];
            field22.Image = tempImage[2, 2];
            field23.Image = tempImage[2, 3];
            field24.Image = tempImage[2, 4];
            field25.Image = tempImage[2, 5];
            field31.Image = tempImage[3, 1];
            field32.Image = tempImage[3, 2];
            field33.Image = tempImage[3, 3];
            field34.Image = tempImage[3, 4];
            field35.Image = tempImage[3, 5];
            field41.Image = tempImage[4, 1];
            field42.Image = tempImage[4, 2];
            field43.Image = tempImage[4, 3];
            field44.Image = tempImage[4, 4];
            field45.Image = tempImage[4, 5];
            field51.Image = tempImage[5, 1];
            field52.Image = tempImage[5, 2];
            field53.Image = tempImage[5, 3];
            field54.Image = tempImage[5, 4];
            field55.Image = tempImage[5, 5];

        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            newGame();
        }

        private void newGame()
        {
            gameLogic.matrixOXRemoveData();
            loadInfo();
            crossOfZero = true;
            playingBot = false;
        }

        private void buttonOnOffBot_Click(object sender, EventArgs e)
        {
            if (!playingBot) playingBot = true;
            else playingBot = false;
            if (!crossOfZero)
            {
                int[] tempMass = nps.stepSelection(tempRow, tempCol, gameLogic);
                gameLogic = nps.getGameLogic();
                addCellInfo(tempMass[0], tempMass[1], crossOfZero);
                loadInfo();
            }
        }

        private void fieldClick(int row, int col)
        {

            addCellInfo(row, col, crossOfZero);
            tempRow = row;
            tempCol = col;
            if (playingBot)
            {
                int[] tempMass = nps.stepSelection(row, col, gameLogic);
                gameLogic = nps.getGameLogic();
                addCellInfo(tempMass[0], tempMass[1], crossOfZero);
                loadInfo();
            }
        }
    }
}
