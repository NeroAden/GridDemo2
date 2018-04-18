using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GridDemo2
{
    class Map
    {
        /*
         * x_max--表格在x轴上的最大值
         * y_max--表格在y轴上的最大值
         * space--表格空隙间距
         * padding--表格距离窗体距离
         * Create(Graphics g)--使用for循环绘制表格
         */
        public int x_max;
        public int y_max;
        public int space;
        public int padding;
        private Pen pen;
        public void Create(Graphics g)
        {
            pen = new Pen(Color.Black);
            for (int i = 0; i < x_max + 1; i++)
            {
                g.DrawLine(pen, space * i + padding, padding, space * i + padding, y_max * space + padding);
            }
            for (int i = 0; i < y_max + 1; i++)
            {
                g.DrawLine(pen, padding, space * i + padding, x_max * space + padding, space * i + padding);
            }
        }
    }
}
