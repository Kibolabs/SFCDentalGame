using System;
using System.Collections;
using System.Collections.Generic;
using SFCDentalGame.DAL.Entities;
namespace SFCDentalGame.Models
{
    public class BehaviourListViewModel
    {
        public IEnumerable<Behaviour> Behaviours { get; set; }
        public string CurrentCategory
        {
            get;
            set;
        }

    }
}
