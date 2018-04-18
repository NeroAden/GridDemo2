using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GridDemo2
{
    class People
    {
        /*
         * Location--蛇头当前所在位置（默认起始位置）
         * historyPoint--蛇所有身体的坐标列表
         * size-列表大小，即蛇总长度
         * 
         * CheckCras(Point point,Crah cras,Map map)--确认蛇有没有吃到果子以及相关逻辑
         * isMoveToBody(Point point)--确认蛇有没有碰到自己身体
         * AutoList(Point point)--更新蛇的身体的坐标列表
         * MoveUp(Crah crah, Map map)--蛇向上移动一格的实现
         * MoveLeft(Crah crah, Map map)--蛇向左移动一格的实现
         * MoveDown(Crah crah, Map map)--蛇向下移动一格的实现
         * MoveRight(Crah crah, Map map)--蛇向右移动一格的实现
         * Updata(Graphics g, Map map)--刷新相关界面
         */
        public Point Location;
        public List<Point> historyPoint = new List<Point>();
        public int size;
        private void CheckCras(Point point, Crah cras, Map map)
        {
            if (cras.cras.Contains(point))
            {
                size++;
                cras.cras.Remove(point);
                cras.AddCras(historyPoint, map);
            }
        }
        private Boolean isMoveToBody(Point point)
        {
            if (historyPoint.Contains(point))
            {
                Form1.GG();
                return true;
            }
            else
            {
                return false;
            }
        }
        private void AutoList(Point point)
        {
            if (historyPoint.Count < size)
            {
                historyPoint.Insert(0, point);
            }
            else
            {
                historyPoint.RemoveAt(size - 1);
                historyPoint.Insert(0, point);
            }
        }
        public void MoveUp(Crah crah, Map map)
        {
            if (Location.Y > 0)
            {
                Location.Y--;
                if (isMoveToBody(Location))
                {
                    Location.Y++;
                    return;
                }
                CheckCras(Location, crah, map);
                AutoList(Location);
            }
            else
            {
                Form1.GG();
            }
        }
        public void MoveDown(Crah crah, Map map)
        {
            if (Location.Y < map.y_max - 1)
            {
                Location.Y++;
                if (isMoveToBody(Location))
                {
                    Location.Y--;
                    return;
                }
                CheckCras(Location, crah, map);
                AutoList(Location);
            }
            else
            {
                Form1.GG();
            }
        }
        public void MoveLeft(Crah crah, Map map)
        {
            if (Location.X > 0)
            {
                Location.X--;
                if (isMoveToBody(Location))
                {
                    Location.X++;
                    return;
                }
                CheckCras(Location, crah, map);
                AutoList(Location);
            }
            else
            {
                Form1.GG();
            }
        }
        public void MoveRight(Crah crah, Map map)
        {
            if (Location.X < map.x_max - 1)
            {
                Location.X++;
                if (isMoveToBody(Location))
                {
                    Location.X--;
                    return;
                }
                CheckCras(Location, crah, map);
                AutoList(Location);
            }
            else
            {
                Form1.GG();
            }
        }
        public void Updata(Graphics g, Map map)
        {
            foreach (Point item in historyPoint)
            {
                g.FillEllipse(new SolidBrush(Color.Black), map.space * item.X + map.padding, map.space * item.Y + map.padding, 30, 30);
            }
            map.Create(g);
        }
    }
}
