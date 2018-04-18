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
        public Point Location;
        public void MoveUp(Map map)
        {
            if (Location.Y > 0)
            {
                Location.Y--;
            }
        }
        public void MoveDown(Map map)
        {
            if (Location.Y < map.y_max-1)
            {
                Location.Y++;
            }
        }
        public void MoveLeft(Map map)
        {
            if (Location.X > 0)
            {
                Location.X--;
            }
        }
        public void MoveRight(Map map)
        {
            if (Location.X < map.x_max-1)
            {
                Location.X++;
            }
        }
        public void Updata(Graphics g, Map map)
        {
            g.FillEllipse(new SolidBrush(Color.Black), map.space * Location.X + map.padding, map.space * Location.Y + map.padding, 30, 30);
            map.Create(g);
        }
    }
}
