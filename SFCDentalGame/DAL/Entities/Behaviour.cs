using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SFCDentalGame.DAL.Entities
{
    public enum Frequency
    {
        DAILY, TWICEADAY, ANNUALY, SEMIANNUALY, QUARTELY, OCASSIONALY
    }
    public class Behaviour
    {
        
        public Behaviour()
        {
        }
        public int BehaviourId
        {
            get;
            set;
        }
        [Display(Name = "Behaviour Name")]
        public string BehaviourName
        {
            get;
            set;
        }
        [Display(Name = "Behaviour Description")]
        public string BehaviourDescription
        {
            get;
            set;
        }
        [Display(Name = "Behaviour Type")]
        public string BehaviourType
        {
            get;
            set;
        }
        public decimal Points
        {
            get;
            set;
        }
        public bool InPractice
        {
            get;
            set;
        }
        public int value
        {
            get;
            set;
        }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public Frequency? Frequency
        {
            get;
            set;
        }

    }
}
