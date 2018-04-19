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
        /*
         * 初始化程序
         * 实例化Map--背景网格
         * People--贪吃蛇对象
         * Crah--果子对象
         * backGround--网格图层
         * boll--贪吃蛇图层
         * item--果子图层
         * timer--总定时器
         * way--蛇头朝向
         * init()--初始化相关设置
         * Timer_Tick(object sender, EventArgs e)--定时器定时事件（移动蛇以及相关逻辑）
         * button1_Click(object sender, EventArgs e)--button1点击事件（手动刷星界面（已废除））
         * button1_KeyDown(object sender, KeyEventArgs e)--键盘监听事件（监听wasd改变蛇头位置）
         * GG()--游戏结束与重新初始化事件
         */
        private static Map map = new Map();
        private static People people = new People();
        private static Crah crah = new Crah();
        private static Graphics backGround, boll, item;
        private static Timer timer = new Timer();
        private static Way.MoveWay way = Way.MoveWay.Down;

        public Form1()
        {
            InitializeComponent();
            backGround = CreateGraphics();
            item = CreateGraphics();
            boll = CreateGraphics();
            timer.Interval = 300;
            timer.Tick += Timer_Tick;
            init();
        }

        private static void init()
        {
            map.x_max = 12;
            map.y_max = 12;
            map.space = 30;
            map.padding = 50;
            people.Location = new Point(1, 0);
            people.size = 3;
            people.historyPoint.Clear();
            crah.cras_max = 2;
            crah.cras.Clear();
            crah.AddCras(people.historyPoint, map);
            way = Way.MoveWay.Down;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            switch (way)
            {
                case Way.MoveWay.Up:
                    boll.Clear(Color.White);
                    people.MoveUp(crah, map);
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
            people.Updata(boll, map);
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    if (way != Way.MoveWay.Down)
                    {
                        way = Way.MoveWay.Up;
                    }
                    break;
                case Keys.A:
                    if (way != Way.MoveWay.Right)
                    {
                        way = Way.MoveWay.Left;
                    }
                    break;
                case Keys.S:
                    if (way != Way.MoveWay.Up)
                    {
                        way = Way.MoveWay.Down;
                    }
                    break;
                case Keys.D:
                    if (way != Way.MoveWay.Left)
                    {
                        way = Way.MoveWay.Right;
                    }
                    break;
                default:
                    break;
            }
        }

        public static void GG()
        {
            timer.Stop();
            MessageBox.Show("GG");
            init();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
