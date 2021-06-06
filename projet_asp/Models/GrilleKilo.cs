using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projet_asp.Models
{
    public class GrilleKilo : IComparable<GrilleKilo>
    {


        public int day;
        public string ville1;
        public string ville2;
        public string heure;
        public int distance;

        public GrilleKilo(int day, string ville1, string ville2, string heure, int distance)
        {
            this.day = day;
            this.ville1 = ville1;
            this.ville2 = ville2;
            this.heure = heure;
            this.distance = distance;
        }



        public int CompareTo(GrilleKilo other)
        {
            return other.day.CompareTo(this.day);
        }
    }
}