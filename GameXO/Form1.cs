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
        int[,] cell;
        bool crossOfZero = true;

        public Form1()
        {
            InitializeComponent();
            cell = new int[6,6];
        }

        private void field11_Click(object sender, EventArgs e)
        {
            if (field11.Image == null)
            {
                field11.Image = getImage();
                addCellInfo(1, 1, crossOfZero);

            }
        }

        private void field12_Click_1(object sender, EventArgs e)
        {
            if (field12.Image == null)
            {
                field12.Image = getImage();
                addCellInfo(1, 2, crossOfZero);

            }
        }

        private void field13_Click(object sender, EventArgs e)
        {
            if (field13.Image == null)
            {
                field13.Image = getImage();
                addCellInfo(1, 3, crossOfZero);

            }
        }

        private void field14_Click(object sender, EventArgs e)
        {
            if (field14.Image == null)
            {
                field14.Image = getImage();
                addCellInfo(1, 4, crossOfZero);

            }
        }

        private void field15_Click(object sender, EventArgs e)
        {
            if (field15.Image == null)
            {
                field15.Image = getImage();
                addCellInfo(1, 5, crossOfZero);

            }
        }

        private void field21_Click(object sender, EventArgs e)
        {
            if (field21.Image == null)
            {
                field21.Image = getImage();
                addCellInfo(2, 1, crossOfZero);

            }
        }

        private void field22_Click(object sender, EventArgs e)
        {
            if (field22.Image == null)
            {
                field22.Image = getImage();
                addCellInfo(2, 2, crossOfZero);

            }
        }

        private void field23_Click(object sender, EventArgs e)
        {
            if (field23.Image == null)
            {
                field23.Image = getImage();
                addCellInfo(2, 3, crossOfZero);

            }
        }

        private void field24_Click(object sender, EventArgs e)
        {
            if (field24.Image == null)
            {
                field24.Image = getImage();
                addCellInfo(2, 4, crossOfZero);

            }
        }

        private void field25_Click(object sender, EventArgs e)
        {
            if (field25.Image == null)
            {
                field25.Image = getImage();
                addCellInfo(2, 5, crossOfZero);

            }
        }

        private void field31_Click(object sender, EventArgs e)
        {
            if (field31.Image == null)
            {
                field31.Image = getImage();
                addCellInfo(3, 1, crossOfZero);
            }
        }

        private void field32_Click(object sender, EventArgs e)
        {
            if (field32.Image == null)
            {
                field32.Image = getImage();
                addCellInfo(3, 2, crossOfZero);

            }
        }

        private void field33_Click(object sender, EventArgs e)
        {
            if (field33.Image == null)
            {
                field33.Image = getImage();
                addCellInfo(3, 3, crossOfZero);

            }
        }

        private void field34_Click(object sender, EventArgs e)
        {
            if (field34.Image == null)
            {
                field34.Image = getImage();
                addCellInfo(3, 4, crossOfZero);

            }
        }

        private void field35_Click(object sender, EventArgs e)
        {
            if (field35.Image == null)
            {
                field35.Image = getImage();
                addCellInfo(3, 5, crossOfZero);

            }
        }

        private void field41_Click(object sender, EventArgs e)
        {
            if (field41.Image == null)
            {
                field41.Image = getImage();
                addCellInfo(4, 1, crossOfZero);

            }
        }

        private void field42_Click(object sender, EventArgs e)
        {
            if (field42.Image == null)
            {
                field42.Image = getImage();
                addCellInfo(4, 2, crossOfZero);

            }
        }

        private void field43_Click(object sender, EventArgs e)
        {
            if (field43.Image == null)
            {
                field43.Image = getImage();
                addCellInfo(4, 3, crossOfZero);

            }
        }

        private void field44_Click(object sender, EventArgs e)
        {
            if (field44.Image == null)
            {
                field44.Image = getImage();
                addCellInfo(4, 4, crossOfZero);

            }
        }

        private void field45_Click(object sender, EventArgs e)
        {
            if (field45.Image == null)
            {
                field45.Image = getImage();
                addCellInfo(4, 5, crossOfZero);

            }
        }

        private void field51_Click(object sender, EventArgs e)
        {
            if (field51.Image == null)
            {
                field51.Image = getImage();
                addCellInfo(5, 1, crossOfZero);

            }
        }

        private void field52_Click(object sender, EventArgs e)
        {
            if (field52.Image == null)
            {
                field52.Image = getImage();
                addCellInfo(5, 2, crossOfZero);

            }
        }

        private void field53_Click(object sender, EventArgs e)
        {
            if (field53.Image == null)
            {
                field53.Image = getImage();
                addCellInfo(5, 3, crossOfZero);

            }
        }

        private void field54_Click(object sender, EventArgs e)
        {
            if (field54.Image == null)
            {
                field54.Image = getImage();
                addCellInfo(5, 4, crossOfZero);

            }
        }

        private void field55_Click(object sender, EventArgs e)
        {
            if (field55.Image == null)
            {
                field55.Image = getImage();
                addCellInfo(5, 5, crossOfZero);

            }
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
            int number = 2;
            if (crossOfZero) number = 1; 
            cell[row, col] = number;
            this.crossOfZero = !crossOfZero;
            gameLogic.addDataMatrixOX(row, col, number);
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
        }
    }
}
