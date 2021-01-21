//Autor1: Iovu Vali Cristian
//Functionalitate: Am creat design-ul form-ului. 


using System;
using System.Collections.Generic;
using System.Linq;
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
            var myComboBoxes = panel1.Controls.OfType<ComboBox>();
            Stack<string> myStack = new Stack<string>();
            Stack<string> orizontalInequalityStack = new Stack<string>();
            Stack<string> verticalInequalityStack = new Stack<string>();
            string board = "";
            string orizontalInequalitySigns = "";
            string verticalInequalitySigns = "";


            foreach (RichTextBox txt in myTextBoxes)
            {
                var text = txt.Text;
                if (!text.Equals(""))
                    myStack.Push(text);
                else
                    myStack.Push("0");
            }
            for (int i = 0; i < 16; i++)
            {
                board += myStack.Pop();
            }

            foreach (ComboBox comboBox in myComboBoxes)
            {
                var sign = comboBox.Text;

                if (comboBox.TabIndex >= 99 && comboBox.TabIndex < 199) // Inegalitati orizontale
                {
                    if (sign.Equals("<"))
                        orizontalInequalityStack.Push("2");
                    else if (sign.Equals(">"))
                        orizontalInequalityStack.Push("1");
                    else
                        orizontalInequalityStack.Push("0");
                }
                if (comboBox.TabIndex >= 200) //inegalitati verticale
                {
                    if (sign.StartsWith("/"))
                        verticalInequalityStack.Push("2");
                    else if (sign.Equals(""))
                        verticalInequalityStack.Push("0");
                    else
                        verticalInequalityStack.Push("1");
                }
            }
            for (int i = 0; i < 12; i++)
            {
                orizontalInequalitySigns += orizontalInequalityStack.Pop();
                verticalInequalitySigns += verticalInequalityStack.Pop();
            }
            //MessageBox.Show("board is:\n" + board + "\n orizontale is \n" + orizontalInequalitySigns + "\n  verticale is \n" + verticalInequalitySigns);
            FutoshikiGrid grid = new FutoshikiGrid(board, orizontalInequalitySigns, verticalInequalitySigns);
            grid.TrySolveBKT(grid, 0, 0, 1);
            if(grid.IsSolved()==false)
            {
                MessageBox.Show("Nu exista solutie pentru aceste conditii");
            }
            else
            {
                MessageBox.Show("Solutie existenta -verifica board-ul");
                a00.Text = Solutie.solutie[0,0].ToString();
                a01.Text = Solutie.solutie[0, 1].ToString();
                a02.Text = Solutie.solutie[0, 2].ToString();
                a03.Text = Solutie.solutie[0, 3].ToString();
                a10.Text = Solutie.solutie[1, 0].ToString();
                a11.Text = Solutie.solutie[1, 1].ToString();
                a12.Text = Solutie.solutie[1, 2].ToString();
                a13.Text = Solutie.solutie[1, 3].ToString();
                a20.Text = Solutie.solutie[2, 0].ToString();
                a21.Text = Solutie.solutie[2, 1].ToString();
                a22.Text = Solutie.solutie[2, 2].ToString();
                a23.Text = Solutie.solutie[2, 3].ToString();
                a30.Text = Solutie.solutie[3, 0].ToString();
                a31.Text = Solutie.solutie[3, 1].ToString();
                a32.Text = Solutie.solutie[3, 2].ToString();
                a33.Text = Solutie.solutie[3, 3].ToString();
                
            }

            grid = null;
        }
    
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void a03_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var allControls = panel1.Controls;
            foreach (Control control in allControls)
            {
                control.Text = "";
            }
        }
    }
}
