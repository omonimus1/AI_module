using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
namespace coursework_40401270
{
    class Cave
    {
        private String id;
        private double x;
        private double y;
        private ArrayList links;
        private double distanceFromStart;
        private Cave closestCave;

        public Cave(double x, double y, String id)
        {
            this.x = x;
            this.y = y;
            this.id = id;
            this.links = new ArrayList();
            distanceFromStart = Double.MaxValue;
            closestCave = null;
        }

        public double getX()
        {
            return x;
        }

        public double getY()
        {
            return y;
        }

        public String getId()
        {
            return id;
        }

        public double getDistanceFromStart()
        {
            return distanceFromStart;
        }

        public Cave getClosestCave()
        {
            return closestCave;
        }

        public void setDistanceFromStart(double distanceFromStart)
        {
            this.distanceFromStart = distanceFromStart;
        }

        public void setClosestCave(Cave closestCave)
        {
            this.closestCave = closestCave;
        }

        public void addLink(Cave other)
        {
            this.links.Add(other);
        }

        public ArrayList getLinks()
        {
            return links;
        }

        override
    public String ToString()
        {
            return "Cave{" +
                    "x=" + x +
                    ", y=" + y +
                    ", links=" + links.Count +
                    '}';
        }

        public int compareTo(Cave other)
        {
            return Double.Compare(this.distanceFromStart, other.distanceFromStart);
        }

        public double getDistance(Cave other)
        {
            return Math.Sqrt((Math.Pow(other.x - x, 2)) + Math.Pow(other.y - y, 2));
        }
    }
}
