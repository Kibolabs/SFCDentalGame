using System;
using System.Collections;
using System.Collections.Generic;

namespace SFCDentalGame.DAL.Entities
{
    public class RangeBehaviour:Behaviour
    {
        public enum Ranges { Lessthan40, Between40and60, greterathan60 }
        public Ranges Range { get; set; }
    }
}
