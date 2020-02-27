using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODProject
{

    public enum Genre { Action, Comedy, Drama, Horror }
    class Movie : IComparable
    {
        //Properties
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Actors { get; set; }
        public string Director { get; set; }
        public string Times { get; set; }
        public string Rating { get; set; }
        public Genre TypeOfGenre { get; internal set; }
        public string ImageName { get; set; }

        //Constructors
        public Movie()
        {

        }

        public Movie(string name, decimal cost, string actors, string director, string times, string rating)
        {
            Name = name;
            Cost = cost;
            Actors = actors;
            Director = director;
            Times = times;
            Rating = rating;
        }

        //Methods

        public int CompareTo(object obj)
        {
            Movie that = (Movie)obj;

            //Compare one Activity Date to another 
            return this.Name.CompareTo(that.Name);
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
