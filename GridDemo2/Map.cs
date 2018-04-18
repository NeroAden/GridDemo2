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
