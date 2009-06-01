using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Armazon.Models.DataTypes
{
    public class DTComment
    {
        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        private string _comment;

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }
        private double _rating;

        public double Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }
    }
}
