using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Futoshiki;


namespace Futoshiki
{
    public class Table
    {
        int[,] a = new int[4, 4];
        public Table(Stack<int> myStack)
        {

            //var myTextBoxes = panel1.Controls.OfType<TextBox>()
            for (int i = 0; i < 4; ++i)
                for (int j = 0; j < 4; ++j)
                {
                    this.a[i, j] = myStack.Pop();
                }

        }
    }
}
