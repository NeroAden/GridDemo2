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
        Crah crah = new Crah();
        Graphics backGround,boll,item;
        Timer timer = new Timer();
        Way.MoveWay way = Way.MoveWay.Down;

        public Form1()
        {
            InitializeComponent();
            backGround = CreateGraphics();
            item = CreateGraphics();
            boll = CreateGraphics();
            timer.Interval = 500;
            timer.Tick += Timer_Tick;
            map.x_max = 12;
            map.y_max = 12;
            map.space = 30;
            map.padding = 50;
            people.Location = new Point(1, 0);
            people.size = 8;
            crah.cras_max = 2;
            crah.AddCras(people.historyPoint, map);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            switch (way)
            {
                case Way.MoveWay.Up:
                    boll.Clear(Color.White);
                    people.MoveUp(crah,map);
                    people.Updata(boll, map);
                    break;
                case Way.MoveWay.Down:
                    boll.Clear(Color.White);
                    people.MoveDown(crah, map);
                    people.Updata(boll, map);
                    break;
                case Way.MoveWay.Left:
                    boll.Clear(Color.White);
                    people.MoveLeft(crah, map);
                    people.Updata(boll, map);
                    break;
                case Way.MoveWay.Right:
                    boll.Clear(Color.White);
                    people.MoveRight(crah, map);
                    people.Updata(boll, map);
                    break;
                default:
                    break;
            }
            crah.Draw(item, map);
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
                    way = Way.MoveWay.Up;
                    break;
                case Keys.A:
                    way = Way.MoveWay.Left;
                    break;
                case Keys.S:
                    way = Way.MoveWay.Down;
                    break;
                case Keys.D:
                    way = Way.MoveWay.Right;
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
