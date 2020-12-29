using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrantGahwiler_CraigUllrich_Tetris
{
    public class GridNode
    {
        public Panel p;
        public bool placed;
        public int x;
        public int y;

        public GridNode(Panel newp)
        {
            p = newp;
            placed = false;

        }

        public GridNode get_left()
        {
            for(int i = 0; i < 20; i++)
            {
                for( int j = 0; j < 10; j++)
                {
                    if (this == tetris.grid[i, j] && (j - 1) >= 0)
                    {
                        return tetris.grid[i, j - 1];
                    }

                }
            }
            return null;
        }

        public GridNode get_right()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                { 
                    if (this == tetris.grid[i, j] && (j + 1) < 10)
                    {
                        return tetris.grid[i, j + 1];
                    }
                }
            }
            return null;
        }

        public GridNode get_up()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (this == tetris.grid[i, j] && (i - 1) >= 0)
                    {
                        return tetris.grid[i-1, j];
                    }
                }
            }
            return null;
        }

        public GridNode get_down()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (this == tetris.grid[i, j] && (i + 1) < 20)
                    {
                        return tetris.grid[i+1, j];
                    }
                }
            }
            return null;
        }

        public GridNode get_D_up_right()
        {
            {
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (this == tetris.grid[i, j] && (i - 1) >= 0 && ( j + 1) < 10)
                        {
                                return tetris.grid[i - 1, j+1];
                        }
                    }
                }
                return null;
            }
        }

        public GridNode get_D_up_left()
        {
            {
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (this == tetris.grid[i, j] && (i - 1) >= 0 && (j - 1) >= 0)
                        {
                                return tetris.grid[i - 1, j - 1];
                        }
                    }
                }
                return null;
            }
        }

        public GridNode get_D_down_right()
        {
            {
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (this == tetris.grid[i, j] && (i + 1) < 20 && (j + 1) < 10)
                        {
                                return tetris.grid[i + 1, j + 1];
                        }
                    }
                }
                return null;
            }
        }

        public GridNode get_D_down_left()
        {
            {
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (this == tetris.grid[i, j] && (i + 1) < 20 && (j - 1) >= 0)
                        {
                                return tetris.grid[i + 1, j - 1];
                        }
                    }
                }
                return null;
            }
        }


    }
}
