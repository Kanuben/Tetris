using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GrantGahwiler_CraigUllrich_Tetris
{
    public class Shape
    {
        Color shape_color;
        GridNode orgin_panel;
        List<GridNode> other_nodes = new List<GridNode>();
        string[] args;

        public Shape(Color color, GridNode orgin, string s)
        {
            shape_color = color;
            orgin_panel = orgin;
            args = s.Split(' ');
            set_bg_color();
        }

        public void load_outer_panels()
        {
            GridNode cur_node = orgin_panel;
            StringBuilder tempstring = new StringBuilder();
            foreach (string item in args)
            {
                tempstring.Append(item + " ");
                if (item == "up" && cur_node != null)
                {
                    GridNode temp = cur_node.get_up();
                    if (temp != null)
                    {
                        other_nodes.Add(temp);
                        cur_node = cur_node.get_up();
                    }
                }
                if (item == "down" && cur_node != null)
                {
                    GridNode temp = cur_node.get_down();
                    if (temp != null)
                    {
                        other_nodes.Add(temp);
                        cur_node = cur_node.get_down();
                    }
                }
                if (item == "left"&& cur_node != null)
                {
                    GridNode temp = cur_node.get_left();
                    if (temp != null)
                    {
                        other_nodes.Add(temp);
                        cur_node = cur_node.get_left();
                    }
                }
                if (item == "right" && cur_node != null)
                {
                    GridNode temp = cur_node.get_right();
                    if (temp != null)
                    {
                        other_nodes.Add(temp);
                        cur_node = cur_node.get_right();
                    }
                }

                if (item == "dul" && cur_node != null)
                {
                    GridNode temp = cur_node.get_D_up_left();
                    if (temp != null)
                    {
                        other_nodes.Add(temp);
                        cur_node = cur_node.get_D_up_left();
                    }
                }

                if (item == "dur" && cur_node != null)
                {
                    GridNode temp = cur_node.get_D_up_right();
                    if (temp != null)
                    {
                        other_nodes.Add(temp);
                        cur_node = cur_node.get_D_up_right();
                    }
                }

                if (item == "ddl" && cur_node != null)
                {
                    GridNode temp = cur_node.get_D_down_left();
                    if (temp != null)
                    {
                        other_nodes.Add(temp);
                        cur_node = cur_node.get_D_down_left();
                    }
                }

                if (item == "ddr" && cur_node != null)
                {
                    GridNode temp = cur_node.get_D_down_right();
                    if (temp != null)
                    {
                        other_nodes.Add(temp);
                        cur_node = cur_node.get_D_down_right();
                    }
                }


                if (item == "orgin" && cur_node != null)
                {
                    cur_node = orgin_panel;
                }
            }

            //MessageBox.Show(tempstring.ToString());
        }

        public void set_bg_color()
        {
            clear_highlight();
            remove_all_nodes();
            load_outer_panels();
            orgin_panel.p.BackColor = shape_color;
            foreach (GridNode item in other_nodes)
            {
                item.p.BackColor = shape_color;
            }
        }

        public void rotate_right()
        {
            bool rotate = true;

            foreach (GridNode item in other_nodes)
            {
                if (item.get_right() == null)
                    orgin_panel = orgin_panel.get_left();
                if (item.get_left() == null)
                    orgin_panel = orgin_panel.get_right();
                break;
            }

            if (rotate == true)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == "up")
                    {
                        args[i] = "right";
                        continue;
                    }

                    if (args[i] == "right")
                    {
                        args[i] = "down";
                        continue;
                    }

                    if (args[i] == "down")
                    {
                        args[i] = "left";
                        continue;
                    }

                    if (args[i] == "left")
                    {
                        args[i] = "up";
                        continue;
                    }

                    if (args[i] == "dul")
                    {
                        args[i] = "dur";
                        continue;
                    }

                    if (args[i] == "dur")
                    {
                        args[i] = "ddr";
                        continue;
                    }

                    if (args[i] == "ddr")
                    {
                        args[i] = "ddl";
                        continue;
                    }

                    if (args[i] == "ddl")
                    {
                        args[i] = "dul";
                        continue;
                    }
                }
                set_bg_color();
            }
        }

        public void rotate_left()
        {
            bool rotate = true;
            
            foreach(GridNode item in other_nodes)
            {
                    if (item.get_left() == null)
                        orgin_panel = orgin_panel.get_right();
                    if (item.get_right() == null)
                    orgin_panel = orgin_panel.get_left();
                break;
            }
            
            if (rotate == true)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == "up")
                    {
                        args[i] = "left";
                        continue;
                    }

                    if (args[i] == "right")
                    {
                        args[i] = "up";
                        continue;
                    }

                    if (args[i] == "down")
                    {
                        args[i] = "right";
                        continue;
                    }

                    if (args[i] == "left")
                    {
                        args[i] = "down";
                        continue;
                    }

                    if (args[i] == "dul")
                    {
                        args[i] = "ddl";
                        continue;
                    }

                    if (args[i] == "dur")
                    {
                        args[i] = "dul";
                        continue;
                    }

                    if (args[i] == "ddr")
                    {
                        args[i] = "dur";
                        continue;
                    }

                    if (args[i] == "ddl")
                    {
                        args[i] = "ddr";
                        continue;
                    }
                }
                set_bg_color();
            }
        }

        public void move_down()
        {
            bool collision = false;
            foreach(GridNode item in other_nodes)
            {
                if(item.get_down() == null)
                {
                    collision = true;
                }
            }

            if(collision == false)
            {
                orgin_panel = orgin_panel.get_down();
            }
            set_bg_color();
        }

        public void move_left()
        {
            bool collision = false;
            foreach (GridNode item in other_nodes)
            {
                if (item.get_left() == null || item.get_left().placed == true)
                {
                    collision = true;
                }
            }

            if (collision == false)
            {
                orgin_panel = orgin_panel.get_left();
            }
            set_bg_color();
        }

        public void move_right()
        {
            bool collision = false;
            foreach (GridNode item in other_nodes)
            {
                if (item.get_right() == null || item.get_right().placed == true)
                {
                    collision = true;
                }
            }

            if (collision == false)
            {
                orgin_panel = orgin_panel.get_right();
            }
            set_bg_color();
        }

        public void clear_highlight()
        {
            foreach (GridNode item in tetris.grid)
            {
                if(item.placed == false)
                item.p.BackColor = Color.Black;
            }
        }

        public void remove_all_nodes()
        {
            other_nodes.Clear();
        }

        public bool hit_bottom()
        {

            foreach(GridNode item in other_nodes)
            {
                for(int i = 0; i < 10; i ++)
                {
                    if (item == tetris.grid[19, i])
                    {

                        return true;
                    }

                    if(orgin_panel == tetris.grid[19, i])
                    {
                        return true;
                    }

                }
            }

            return false;
        }

        public bool hit_placed()
        {
            foreach (GridNode item in other_nodes)
            {
                GridNode temp = item.get_down();
                if (temp != null)
                {
                    if (temp.placed == true)
                    {
                        return true;
                    }
                }
            }
            if(orgin_panel.get_left() != null)
            {
                if (orgin_panel.get_down().placed == true)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public void place()
        {
            foreach(GridNode item in other_nodes)
            {
                item.placed = true;
            }

            orgin_panel.placed = true;
        }
    }
}
