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
        public List<Point> historyPoint = new List<Point>();
        public int size;
        private void CheckCras(Point point,Crah cras,Map map)
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
                return true;
            }
            else
            {
                return false;
            }
        }
        private void AutoList(Point point)
        {
            if (historyPoint.Count<size)
            {
                historyPoint.Insert(0, point);
            }
            else
            {
                historyPoint.RemoveAt(size-1);
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
                CheckCras(Location, crah,map);
                AutoList(Location);
            }
        }
        public void MoveDown(Crah crah,Map map)
        {
            if (Location.Y < map.y_max-1)
            {
                Location.Y++;
                if (isMoveToBody(Location))
                {
                    Location.Y--;
                    return;
                }
                CheckCras(Location, crah,map);
                AutoList(Location);
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
                CheckCras(Location, crah,map);
                AutoList(Location);
            }
        }
        public void MoveRight(Crah crah, Map map)
        {
            if (Location.X < map.x_max-1)
            {
                Location.X++;
                if (isMoveToBody(Location))
                {
                    Location.X--;
                    return;
                }
                CheckCras(Location, crah,map);
                AutoList(Location);
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
