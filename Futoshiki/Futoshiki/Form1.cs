using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Futoshiki
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();

            a00.SelectAll();
            a00.SelectionAlignment = HorizontalAlignment.Center;

            a01.SelectAll();
            a01.SelectionAlignment = HorizontalAlignment.Center;

            a02.SelectAll();
            a02.SelectionAlignment = HorizontalAlignment.Center;

            a03.SelectAll();
            a03.SelectionAlignment = HorizontalAlignment.Center;

            a10.SelectAll();
            a10.SelectionAlignment = HorizontalAlignment.Center;

            a11.SelectAll();
            a11.SelectionAlignment = HorizontalAlignment.Center;

            a12.SelectAll();
            a12.SelectionAlignment = HorizontalAlignment.Center;

            a13.SelectAll();
            a13.SelectionAlignment = HorizontalAlignment.Center;

            a20.SelectAll();
            a20.SelectionAlignment = HorizontalAlignment.Center;

            a21.SelectAll();
            a21.SelectionAlignment = HorizontalAlignment.Center;

            a22.SelectAll();
            a22.SelectionAlignment = HorizontalAlignment.Center;

            a23.SelectAll();
            a23.SelectionAlignment = HorizontalAlignment.Center;

            a30.SelectAll();
            a30.SelectionAlignment = HorizontalAlignment.Center;

            a31.SelectAll();
            a31.SelectionAlignment = HorizontalAlignment.Center;

            a32.SelectAll();
            a32.SelectionAlignment = HorizontalAlignment.Center;

            a33.SelectAll();
            a33.SelectionAlignment = HorizontalAlignment.Center;

            

        }

        private void a00_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var myTextBoxes = panel1.Controls
                         .OfType<RichTextBox>();
            Stack<int> myStack = new Stack<int>();

            foreach (RichTextBox txt in myTextBoxes)
            {
                var text = txt.Text;
                if (!text.Equals(""))
                    myStack.Push(Int32.Parse(text));
                else
                    myStack.Push(0);

                // do something amazing
            }

            Table Game = new Table(myStack);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
