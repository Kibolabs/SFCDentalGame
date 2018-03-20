using System;
using System.ComponentModel.DataAnnotations;

namespace SFCDentalGame.Models
{
    public class Player
    {
        public int PlayerId
        {
            get;
            set;
        }
        public string UserName
        {
            get;
            set;
        }
        public string Password
        {
            get;
            set;
        }
    }
}
