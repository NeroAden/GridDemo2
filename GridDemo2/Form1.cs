using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridDemo2
{
    public partial class Form1 : Form
    {
        Map map = new Map();
        People people = new People();
        Graphics backGround,boll;
        Color color = new Color();
        public Form1()
        {
            InitializeComponent();
            backGround = CreateGraphics();
            boll = CreateGraphics();
            map.x_max = 10;
            map.y_max = 10;
            map.space = 30;
            map.padding = 50;
            people.Location = new Point(1, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backGround.Clear(Color.White);
            map.Create(backGround);
            people.Updata(boll,map);
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    boll.Clear(Color.White);
                    people.MoveUp(map);
                    people.Updata(boll, map);
                    break;
                case Keys.A:
                    boll.Clear(Color.FromArgb(255, 255, 255, 255));
                    people.MoveLeft(map);
                    people.Updata(boll, map);
                    break;
                case Keys.S:
                    boll.Clear(Color.FromArgb(255, 255, 255, 255));
                    people.MoveDown(map);
                    people.Updata(boll, map);
                    break;
                case Keys.D:
                    boll.Clear(Color.FromArgb(255, 255, 255, 255));
                    people.MoveRight(map);
                    people.Updata(boll, map);
                    break;
                default:
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
