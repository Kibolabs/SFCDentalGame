using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SFCDentalGame.DAL.Entities
{
    public class Behaviour

    {
        public enum Rating { GOOD, BETTER, EXCELLENT }

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
        public Rating ratings
        {
            get;
            set;
        }
        public string ProffesionalComment { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }


    }
}
