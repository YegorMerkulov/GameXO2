using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameXO
{
    class MatrixOX
    {

        private int[] data, row, col;
        private int locationRow, locationCol;

        public MatrixOX()
        {
            data = null;
            row = null;
            col = null;
            locationRow = 0;
            locationCol = 0;
        }

        public void setPushMatrix(int value, int countEl, int countRow)
        {
            this.data = push(data, value);
            this.col = push(col, countEl + locationCol);
            this.row = push(row, countRow + locationRow);

            //MessageBox.Show(data[data.Length - 1].ToString() + col[col.Length - 1].ToString() + row[row.Length - 1].ToString());
        }

        int[] push(int[] arr, int value)
        {
            
            if (arr == null)
            {
                arr = new int[1];
                arr[0] = value;
                return arr;
            }
            int countEl = arr.Length + 1;
            int[] tempArr = new int[countEl];
            for (int i = 0; i < countEl - 1; i++)
            {
                tempArr[i] = arr[i];
            }
            tempArr[countEl - 1] = value;
            return tempArr;
        }

        public void setRemoveData()
        {
            data = null;
            row = null;
            col = null;
        }

        public void setAddColLeft()
        {
            if (checkEnemy(col))
                for (int i = 0; col.Length > i; i++)
            {
                this.col[i]++;
                if (locationCol != 0) locationCol--;
            }
        }

        public void setAddColRight()
        {
            if (checkEnemy(col))
            for (int i = 0; col.Length > i; i++)
            {
                this.col[i]--;
                if (locationCol != 0) locationCol++;
            }
        }

        public void setAddRowUp()
        {
            if (checkEnemy(row))
                for (int i = 0; row.Length > i; i++)
            {
                this.row[i]++;
                if (locationRow != 0) locationCol--;
            }
        }

        public void setAddRowDown()
        {
            if (checkEnemy(row))
                for (int i = 0; row.Length > i; i++)
            {
                this.row[i]--;
                locationRow++;
            }
        }

        public int getData(int row, int col)
        {
            if (checkEnemy(data))
                for (int i = 0; data.Length > i; i++)
                if (row == this.row[i])
                    if(col == this.col[i])
                        return data[i];
            return 0;
        }

        private bool checkEnemy(int[] data)
        {
            if (data != null)
                return true;
            return false;
        }
    }
}
