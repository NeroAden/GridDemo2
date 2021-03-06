﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GridDemo2
{
    class Crah
    {
        /*
         * cras--所有果子的坐标列表
         * cras_max--同时存在的果子的最大数
         * AddCras(List<Point> body,Map map)--添加果子的实现
         * Draw(Graphics g,Map map)--绘制（更新）果子图层
         */
        public List<Point> cras = new List<Point>();
        public int cras_max;
        public void AddCras(List<Point> body, Map map)
        {
            Random random = new Random();
            while (cras.Count < 2)
            {
                Point point = new Point(random.Next(0, map.x_max), random.Next(0, map.y_max));
                if (cras.Contains(point) == false && body.Contains(point) == false)
                {
                    cras.Add(point);
                }
            }
        }
        public void Draw(Graphics g, Map map)
        {
            foreach (var item in cras)
            {
                g.FillEllipse(new SolidBrush(Color.Red), map.space * item.X + map.padding, map.space * item.Y + map.padding, 30, 30);
            }
        }
    }
}
