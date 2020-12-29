using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Timers;

namespace GrantGahwiler_CraigUllrich_Tetris
{
    public partial class tetris : Form
    {
        public static GridNode[,] grid = new GridNode[20, 10];
        public static Shape current_shape;
        public bool can_rotate = false;


        public tetris()
        {
            InitializeComponent();
            load_grid();

            //SoundPlayer backgroundmusic = new SoundPlayer("..\\..\\tetris.wav");
            //backgroundmusic.Play();

            create_shape();

            //timer
            System.Timers.Timer move_down = new System.Timers.Timer(1500);
            move_down.Elapsed += Button3_Click;
            move_down.AutoReset = true;
            move_down.Enabled = true;
        }

        public void load_grid()
        {
            //A
            grid[0, 0] = new GridNode(A1);
            grid[0, 1] = new GridNode(A2);
            grid[0, 2] = new GridNode(A3);
            grid[0, 3] = new GridNode(A4);
            grid[0, 4] = new GridNode(A5);
            grid[0, 5] = new GridNode(A6);
            grid[0, 6] = new GridNode(A7);
            grid[0, 7] = new GridNode(A8);
            grid[0, 8] = new GridNode(A9);
            grid[0, 9] = new GridNode(A10);

            //B
            grid[1, 0] = new GridNode(B1);
            grid[1, 1] = new GridNode(B2);
            grid[1, 2] = new GridNode(B3);
            grid[1, 3] = new GridNode(B4);
            grid[1, 4] = new GridNode(B5);
            grid[1, 5] = new GridNode(B6);
            grid[1, 6] = new GridNode(B7);
            grid[1, 7] = new GridNode(B8);
            grid[1, 8] = new GridNode(B9);
            grid[1, 9] = new GridNode(B10);

            //C
            grid[2, 0] = new GridNode(C1);
            grid[2, 1] = new GridNode(C2);
            grid[2, 2] = new GridNode(C3);
            grid[2, 3] = new GridNode(C4);
            grid[2, 4] = new GridNode(C5);
            grid[2, 5] = new GridNode(C6);
            grid[2, 6] = new GridNode(C7);
            grid[2, 7] = new GridNode(C8);
            grid[2, 8] = new GridNode(C9);
            grid[2, 9] = new GridNode(C10);

            //D
            grid[3, 0] = new GridNode(D1);
            grid[3, 1] = new GridNode(D2);
            grid[3, 2] = new GridNode(D3);
            grid[3, 3] = new GridNode(D4);
            grid[3, 4] = new GridNode(D5);
            grid[3, 5] = new GridNode(D6);
            grid[3, 6] = new GridNode(D7);
            grid[3, 7] = new GridNode(D8);
            grid[3, 8] = new GridNode(D9);
            grid[3, 9] = new GridNode(D10);

            //E
            grid[4, 0] = new GridNode(E1);
            grid[4, 1] = new GridNode(E2);
            grid[4, 2] = new GridNode(E3);
            grid[4, 3] = new GridNode(E4);
            grid[4, 4] = new GridNode(E5);
            grid[4, 5] = new GridNode(E6);
            grid[4, 6] = new GridNode(E7);
            grid[4, 7] = new GridNode(E8);
            grid[4, 8] = new GridNode(E9);
            grid[4, 9] = new GridNode(E10);

            //F
            grid[5, 0] = new GridNode(F1);
            grid[5, 1] = new GridNode(F2);
            grid[5, 2] = new GridNode(F3);
            grid[5, 3] = new GridNode(F4);
            grid[5, 4] = new GridNode(F5);
            grid[5, 5] = new GridNode(F6);
            grid[5, 6] = new GridNode(F7);
            grid[5, 7] = new GridNode(F8);
            grid[5, 8] = new GridNode(F9);
            grid[5, 9] = new GridNode(F10);

            //G
            grid[6, 0] = new GridNode(G1);
            grid[6, 1] = new GridNode(G2);
            grid[6, 2] = new GridNode(G3);
            grid[6, 3] = new GridNode(G4);
            grid[6, 4] = new GridNode(G5);
            grid[6, 5] = new GridNode(G6);
            grid[6, 6] = new GridNode(G7);
            grid[6, 7] = new GridNode(G8);
            grid[6, 8] = new GridNode(G9);
            grid[6, 9] = new GridNode(G10);

            //H
            grid[7, 0] = new GridNode(H1);
            grid[7, 1] = new GridNode(H2);
            grid[7, 2] = new GridNode(H3);
            grid[7, 3] = new GridNode(H4);
            grid[7, 4] = new GridNode(H5);
            grid[7, 5] = new GridNode(H6);
            grid[7, 6] = new GridNode(H7);
            grid[7, 7] = new GridNode(H8);
            grid[7, 8] = new GridNode(H9);
            grid[7, 9] = new GridNode(H10);

            //I
            grid[8, 0] = new GridNode(I1);
            grid[8, 1] = new GridNode(I2);
            grid[8, 2] = new GridNode(I3);
            grid[8, 3] = new GridNode(I4);
            grid[8, 4] = new GridNode(I5);
            grid[8, 5] = new GridNode(I6);
            grid[8, 6] = new GridNode(I7);
            grid[8, 7] = new GridNode(I8);
            grid[8, 8] = new GridNode(I9);
            grid[8, 9] = new GridNode(I10);

            //J
            grid[9, 0] = new GridNode(J1);
            grid[9, 1] = new GridNode(J2);
            grid[9, 2] = new GridNode(J3);
            grid[9, 3] = new GridNode(J4);
            grid[9, 4] = new GridNode(J5);
            grid[9, 5] = new GridNode(J6);
            grid[9, 6] = new GridNode(J7);
            grid[9, 7] = new GridNode(J8);
            grid[9, 8] = new GridNode(J9);
            grid[9, 9] = new GridNode(J10);

            //K
            grid[10, 0] = new GridNode(K1);
            grid[10, 1] = new GridNode(K2);
            grid[10, 2] = new GridNode(K3);
            grid[10, 3] = new GridNode(K4);
            grid[10, 4] = new GridNode(K5);
            grid[10, 5] = new GridNode(K6);
            grid[10, 6] = new GridNode(K7);
            grid[10, 7] = new GridNode(K8);
            grid[10, 8] = new GridNode(K9);
            grid[10, 9] = new GridNode(K10);

            //L
            grid[11, 0] = new GridNode(L1);
            grid[11, 1] = new GridNode(L2);
            grid[11, 2] = new GridNode(L3);
            grid[11, 3] = new GridNode(L4);
            grid[11, 4] = new GridNode(L5);
            grid[11, 5] = new GridNode(L6);
            grid[11, 6] = new GridNode(L7);
            grid[11, 7] = new GridNode(L8);
            grid[11, 8] = new GridNode(L9);
            grid[11, 9] = new GridNode(L10);

            //M
            grid[12, 0] = new GridNode(M1);
            grid[12, 1] = new GridNode(M2);
            grid[12, 2] = new GridNode(M3);
            grid[12, 3] = new GridNode(M4);
            grid[12, 4] = new GridNode(M5);
            grid[12, 5] = new GridNode(M6);
            grid[12, 6] = new GridNode(M7);
            grid[12, 7] = new GridNode(M8);
            grid[12, 8] = new GridNode(M9);
            grid[12, 9] = new GridNode(M10);

            //N
            grid[13, 0] = new GridNode(N1);
            grid[13, 1] = new GridNode(N2);
            grid[13, 2] = new GridNode(N3);
            grid[13, 3] = new GridNode(N4);
            grid[13, 4] = new GridNode(N5);
            grid[13, 5] = new GridNode(N6);
            grid[13, 6] = new GridNode(N7);
            grid[13, 7] = new GridNode(N8);
            grid[13, 8] = new GridNode(N9);
            grid[13, 9] = new GridNode(N10);

            //O
            grid[14, 0] = new GridNode(O1);
            grid[14, 1] = new GridNode(O2);
            grid[14, 2] = new GridNode(O3);
            grid[14, 3] = new GridNode(O4);
            grid[14, 4] = new GridNode(O5);
            grid[14, 5] = new GridNode(O6);
            grid[14, 6] = new GridNode(O7);
            grid[14, 7] = new GridNode(O8);
            grid[14, 8] = new GridNode(O9);
            grid[14, 9] = new GridNode(O10);

            //P
            grid[15, 0] = new GridNode(P1);
            grid[15, 1] = new GridNode(P2);
            grid[15, 2] = new GridNode(P3);
            grid[15, 3] = new GridNode(P4);
            grid[15, 4] = new GridNode(P5);
            grid[15, 5] = new GridNode(P6);
            grid[15, 6] = new GridNode(P7);
            grid[15, 7] = new GridNode(P8);
            grid[15, 8] = new GridNode(P9);
            grid[15, 9] = new GridNode(P10);

            //Q
            grid[16, 0] = new GridNode(Q1);
            grid[16, 1] = new GridNode(Q2);
            grid[16, 2] = new GridNode(Q3);
            grid[16, 3] = new GridNode(Q4);
            grid[16, 4] = new GridNode(Q5);
            grid[16, 5] = new GridNode(Q6);
            grid[16, 6] = new GridNode(Q7);
            grid[16, 7] = new GridNode(Q8);
            grid[16, 8] = new GridNode(Q9);
            grid[16, 9] = new GridNode(Q10);

            //R
            grid[17, 0] = new GridNode(R1);
            grid[17, 1] = new GridNode(R2);
            grid[17, 2] = new GridNode(R3);
            grid[17, 3] = new GridNode(R4);
            grid[17, 4] = new GridNode(R5);
            grid[17, 5] = new GridNode(R6);
            grid[17, 6] = new GridNode(R7);
            grid[17, 7] = new GridNode(R8);
            grid[17, 8] = new GridNode(R9);
            grid[17, 9] = new GridNode(R10);

            //S
            grid[18, 0] = new GridNode(S1);
            grid[18, 1] = new GridNode(S2);
            grid[18, 2] = new GridNode(S3);
            grid[18, 3] = new GridNode(S4);
            grid[18, 4] = new GridNode(S5);
            grid[18, 5] = new GridNode(S6);
            grid[18, 6] = new GridNode(S7);
            grid[18, 7] = new GridNode(S8);
            grid[18, 8] = new GridNode(S9);
            grid[18, 9] = new GridNode(S10);

            //T
            grid[19, 0] = new GridNode(T1);
            grid[19, 1] = new GridNode(T2);
            grid[19, 2] = new GridNode(T3);
            grid[19, 3] = new GridNode(T4);
            grid[19, 4] = new GridNode(T5);
            grid[19, 5] = new GridNode(T6);
            grid[19, 6] = new GridNode(T7);
            grid[19, 7] = new GridNode(T8);
            grid[19, 8] = new GridNode(T9);
            grid[19, 9] = new GridNode(T10);

        }

        private void tetris_Load(object sender, EventArgs e)
        {
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(can_rotate == true)
            current_shape.rotate_right();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (can_rotate == true)
                current_shape.rotate_left();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
                current_shape.move_down();
                check_collision();

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            current_shape.move_left();
            current_shape.set_bg_color();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            current_shape.move_right();

        }

        public void check_collision()
        {
            if (current_shape.hit_bottom() == true || current_shape.hit_placed() == true)
            {
                //MessageBox.Show("TEST");
                current_shape.place();

                int counter = 0;
                for(int i = 19; i > 0; i--)
                {
                    counter = 0;

                    for(int j = 0; j < 10; j++)
                    {
                        if(grid[i,j].placed == true)
                        {
                            counter ++;
                            if(counter == 10)
                            {
                                counter = 0;
                                grid[i, 0].placed = false;
                                grid[i, 1].placed = false;
                                grid[i, 2].placed = false;
                                grid[i, 3].placed = false;
                                grid[i, 4].placed = false;
                                grid[i, 5].placed = false;
                                grid[i, 6].placed = false;
                                grid[i, 7].placed = false;
                                grid[i, 8].placed = false;
                                grid[i, 9].placed = false;
                                move_grid();
                                i++;
                            }
                        }
                    }
                }
                create_shape();
            }
        }

        public void move_grid()
        {
            for(int i = 19; i > 0; i--)
            {
                for(int j = 0; j < 10; j++)
                {
                    if(i != 1)
                    {
                        grid[i, j].p.BackColor = grid[i, j].get_up().p.BackColor;
                        grid[i, j].placed = grid[i, j].get_up().placed;
                    }
                }
            }
        }

        public void create_shape()
        {
            Random rng = new Random();
            //int shape_select = rng.Next(1, 7);
            int shape_select = 2;

            if(shape_select == 1)
                create_TShape();

            else if (shape_select == 2)
                create_CubeShape();

            else if (shape_select == 3)
                 create_ZShape();

            else if (shape_select == 4)
                create_LShape();

            else if (shape_select == 5)
                create_LineShape();

            else if (shape_select == 6)
                create_ZFlippedShape();


            current_shape.set_bg_color();
            for(int i = 0; i < 10; i++)
            {
                if(grid[3,i].placed == true)
                {
                    MessageBox.Show("END");
                }
            }
        }

        public void create_TShape()
        {
            string shape_d = "left orgin down orgin right";
            Shape T_SHAPE = new Shape(Color.Red, grid[2, 4], shape_d);
            current_shape = T_SHAPE;
            can_rotate = true;
        }

        public void create_CubeShape()
        {
            string shape_d = "right down left";
            Shape Cube_SHAPE = new Shape(Color.LimeGreen, grid[2, 4], shape_d);
            current_shape = Cube_SHAPE;
            can_rotate = false;
        }

        public void create_ZShape()
        {
            string shape_d = "left orgin down orgin ddr";
            Shape Z_SHAPE = new Shape(Color.Yellow, grid[2, 4], shape_d);
            current_shape = Z_SHAPE;
            can_rotate = true;
        }

        public void create_ZFlippedShape()
        {
            string shape_d = "right orgin down orgin ddl";
            Shape Z_SHAPE = new Shape(Color.OrangeRed, grid[2, 4], shape_d);
            current_shape = Z_SHAPE;
            can_rotate = true;
        }

        public void create_LShape()
        {
            string shape_d = "up orgin down orgin ddr";
            Shape L_SHAPE = new Shape(Color.HotPink, grid[2, 4], shape_d);
            current_shape = L_SHAPE;
            can_rotate = true;
        }

        public void create_LineShape()
        {
            string shape_d = "up up orgin down";
            Shape LINE_SHAPE = new Shape(Color.Blue, grid[2, 4], shape_d);
            current_shape = LINE_SHAPE;
            can_rotate = true;
        }
    }
}
