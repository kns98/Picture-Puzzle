using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Picture_Puzzle
{
    public partial class Form1 : Form
    {
        const int size = 270;
        const int one_third = size/3;
        const int two_third = (size / 3) * 2; 
        Point EmptyPoint;
        ArrayList images = new ArrayList();

        public Form1()
        {
            EmptyPoint.X = two_third;
            EmptyPoint.Y = two_third;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void button9_Click(object sender, EventArgs e)
        {
            foreach (Button b in panel1.Controls)
                b.Enabled = true;

            Image orginal = Image.FromFile(@"..\..\img\img.jpg");

            cropImageTomages(orginal, size, size);

            AddImagesToButtons(images);
        }

        private void AddImagesToButtons(ArrayList images)
        {
            int i = 0;
            int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7 };

            Shuffle(arr);

            foreach (Button b in panel1.Controls)
            {
                if (i < arr.Length)
                {
                    b.Image = (Image)images[arr[i]];
                    i++;
                }
            }
        }

        public static void Shuffle(int[] array)
        {
            Random rng = new Random();
            int n = array.Length;

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int temp = array[k];
                array[k] = array[n];
                array[n] = temp;
            }
        }


        private void cropImageTomages(Image orginal, int w, int h)
        {
            Bitmap bmp = new Bitmap(w, h);

            Graphics graphic = Graphics.FromImage(bmp);

            graphic.DrawImage(orginal, 0, 0, w, h);

            graphic.Dispose();

            int movr = 0,
                movd = 0;

            for (int x = 0; x < 8; x++)
            {
                Bitmap piece = new Bitmap(one_third, one_third);

                for (int i = 0; i < one_third; i++)
                    for (int j = 0; j < one_third; j++)
                        piece.SetPixel(i, j, bmp.GetPixel(i + movr, j + movd));

                images.Add(piece);

                movr += one_third;

                if (movr == size)
                {
                    movr = 0;
                    movd += one_third;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MoveButton((Button)sender);
        }

        private void MoveButton(Button btn)
        {
            if (
                (
                    (btn.Location.X == EmptyPoint.X - one_third || btn.Location.X == EmptyPoint.X + one_third)
                    && btn.Location.Y == EmptyPoint.Y
                )
                || (btn.Location.Y == EmptyPoint.Y - one_third || btn.Location.Y == EmptyPoint.Y + one_third)
                    && btn.Location.X == EmptyPoint.X
            )
            {
                Point swap = btn.Location;
                btn.Location = EmptyPoint;
                EmptyPoint = swap;
            }

            if (EmptyPoint.X == two_third && EmptyPoint.Y == two_third)
                CheckValid();
        }

        private void CheckValid()
        {
            int count = 0,
                index;
            foreach (Button btn in panel1.Controls)
            {
                index = (btn.Location.Y / one_third) * 3 + btn.Location.X / one_third;
                if (images[index] == btn.Image)
                    count++;
            }
            if (count == 8)
                MessageBox.Show("well done you win!");
        }
    }
}
