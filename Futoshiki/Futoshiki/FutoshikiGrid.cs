using System;
using System.Collections.Generic;
using System.Text;

namespace Futoshiki
{
    class FutoshikiGrid
    {
        private int[,] numere = new int[4, 4];
        private int[,] inegalitatiOrizontale = new int[4, 3];
        private int[,] inegalitatiVerticale = new int[3, 4];
        private bool solved = false;

        public FutoshikiGrid(string _numere, string _inegalitatiOrizontale, string _inegalitatiVerticale)
        {
            try
            {
                int x = 0;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        numere[i, j] = Convert.ToInt32(_numere[x]) - 48;
                        x++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            //<(stanga mai mic ca dreapta) = 2 && >(dreapta mai mic ca stanga) = 1 && -(nimic) = 0
            try
            {
                int x = 0;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        inegalitatiOrizontale[i, j] = Convert.ToInt32(_inegalitatiOrizontale[x]) - 48;
                        x++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            // ^(sus mai mic ca jos) = 2 && v(jos mai mic ca sus) = 1 && -(nimic) = 0
            try
            {
                int x = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        inegalitatiVerticale[i, j] = Convert.ToInt32(_inegalitatiVerticale[x]) - 48;
                        x++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private bool SolutieValida(FutoshikiGrid grid)
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    if (grid.numere[i, j] == 0)
                        return false;
                }
            }
            TrimiteSolutia();
            //solved = true;
            return true;
        }

        private bool Valid(int _i, int _j, int _digit, FutoshikiGrid grid)
        {
            //verifica daca exista cifra _digit pe linia _i si coloana _j
            for (int x = 0; x < 4; x++)
            {
                if (grid.numere[x, _j] == _digit)
                    return false;
                if (grid.numere[_i, x] == _digit)
                    return false;
            }

            //verifica daca se potrivesc inegalitatile daca _digit este plasat pe pozitia [_i,_j]
            //in prima faza, testam inegalitatile orizontale
            //mai intai, cazurile in care _j se afla in interiorul liniei

            if (_j > 0 && _j < 3)
            {
                // la stanga casutei
                if (inegalitatiOrizontale[_i, _j - 1] == 2)
                {
                    if (grid.numere[_i, _j - 1] != 0)
                        if (!(grid.numere[_i, _j - 1] < _digit))
                            return false;
                }
                if (inegalitatiOrizontale[_i, _j - 1] == 1)
                {
                    if (!(grid.numere[_i, _j - 1] > _digit))
                        return false;
                }

                //la dreapta casutei
                if (inegalitatiOrizontale[_i, _j] == 2)
                {
                    if (grid.numere[_i, _j + 1] != 0)
                        if (!(grid.numere[_i, _j + 1] > _digit))
                            return false;
                }
                if (inegalitatiOrizontale[_i, _j] == 1)
                {
                    if (!(grid.numere[_i, _j + 1] < _digit))
                        return false;
                }
            }

            //cazurile in care _digit se va pozitiona pe prima sau ultima coloana
            if (_j == 0)
            {
                //prima coloana
                if (inegalitatiOrizontale[_i, _j] == 2)
                {
                    if (grid.numere[_i, _j + 1] != 0)
                        if (!(grid.numere[_i, _j + 1] > _digit))
                            return false;
                }
                if (inegalitatiOrizontale[_i, _j] == 1)
                {
                    if (!(grid.numere[_i, _j + 1] < _digit))
                        return false;
                }
            }
            if (_j == 3)
            {
                //ultima coloana
                if (inegalitatiOrizontale[_i, _j - 1] == 2)
                {
                    if (grid.numere[_i, _j - 1] != 0)
                        if (!(grid.numere[_i, _j - 1] < _digit))
                            return false;
                }
                if (inegalitatiOrizontale[_i, _j - 1] == 1)
                {
                    if (!(grid.numere[_i, _j - 1] > _digit))
                        return false;
                }
            }

            //validam inegalitatile verticale
            if (_i > 0 && _i < 3)
            {
                if (inegalitatiVerticale[_i - 1, _j] == 2)
                {
                    if (grid.numere[_i - 1, _j] != 0)
                        if (!(grid.numere[_i - 1, _j] < _digit))
                            return false;
                }
                if (inegalitatiVerticale[_i - 1, _j] == 1)
                {
                    if (!(grid.numere[_i - 1, _j] > _digit))
                        return false;
                }
                if (inegalitatiVerticale[_i, _j] == 2)
                {
                    if (grid.numere[_i + 1, _j] != 0)
                        if (!(grid.numere[_i + 1, _j] > _digit))
                            return false;
                }
                if (inegalitatiVerticale[_i, _j] == 1)
                {
                    if (!(grid.numere[_i, _j] < _digit))
                        return false;
                }
            }

            if (_i == 0)
            {
                //prima linie
                if (inegalitatiVerticale[_i, _j] == 2)
                {
                    if (grid.numere[_i + 1, _j] != 0)
                        if (!(grid.numere[_i + 1, _j] > _digit))
                            return false;
                }
                if (inegalitatiVerticale[_i, _j] == 1)
                {
                    if (!(grid.numere[_i + 1, _j] < _digit))
                        return false;
                }
            }
            if (_i == 3)
            {
                //ultima linie
                if (inegalitatiVerticale[_i - 1, _j] == 2)
                {
                    if (grid.numere[_i - 1, _j] != 0)
                        if (!(grid.numere[_i - 1, _j] < _digit))
                            return false;
                }
                if (inegalitatiVerticale[_i - 1, _j] == 1)
                {
                    if (!(grid.numere[_i - 1, _j] > _digit))
                        return false;
                }
            }

            return true;
        }

        public void TrySolveBKT(FutoshikiGrid grid, int i, int j, int digit)
        {
            if (SolutieValida(grid))
            {
                solved = true;
            }
            else if (solved == false)
            {
                if (i < 4)
                {
                    //if-ul asta face sa nu se modifice valorile din grid date initial
                    if (grid.numere[i, j] == 0)
                    {

                        for (int aux = digit; aux <= 4; aux++)
                        {
                            if (Valid(i, j, aux, grid))
                            {
                                grid.numere[i, j] = aux;
                                j++;
                                if (j == 4)
                                {
                                    i++; j = 0;
                                }
                                TrySolveBKT(grid, i, j, 1);
                                if (j == 0)
                                {
                                    j = 3; i--;
                                }
                                else
                                {
                                    j--;
                                }
                                grid.numere[i, j] = 0;
                            }
                        }
                    }
                    else
                    {
                        j++;
                        if (j == 4)
                        {
                            i++; j = 0;
                        }
                        TrySolveBKT(grid, i, j, 1);
                    }
                }
            }
        }

        public void AfisareGrid()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(numere[i, j] + " ");
                    if (j < 3)
                    {
                        Console.Write(inegalitatiOrizontale[i, j] + " ");
                    }
                }
                Console.Write("\n");
                if (i < 3)
                    for (int k = 0; k < 4; k++)
                    {
                        Console.Write(inegalitatiVerticale[i, k] + "   ");
                    }
                Console.Write("\n");
            }
        }

        public void TrimiteSolutia()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Solutie.solutie[i, j] = numere[i, j];
                }
            }
        }

        public bool IsSolved()
        {
            if (solved == false)
                return false;
            return true;
        }
    }

}
