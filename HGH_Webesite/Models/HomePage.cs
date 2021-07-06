using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HGH_Webesite.Models
{
    public class HomePage
    {

        //This for honary picture board
        public int id { set; get; }
        public String img1 { set; get; }
        public String name1 { set; get; }
        public String img2{ set; get; }
        public String name2 { set; get; }
        public String img3 { set; get; }
        public String name3 { set; get; }
        //--------------------------------

        //This for NewsBoard
        public String imgtitle { set; get; }
        public String Tilte { set; get; }
        //------------

        public HomePage() { }


    }

}
