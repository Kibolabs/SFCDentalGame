using System;
using SFCDentalGame.DAL.Entities;
namespace SFCDentalGame.Models
{
    public class DentalHealthDetail
    {
        public DentalHealthDetail()
        {
        }
        public int DentalHealthDetailId
        {
            get;
            set;
        }
        public int DentalHealthId
        {
            get;
            set;
        }
        public int BehaviourId
        {
            get;
            set;
        }
        public decimal Points
        {
            get;
            set;

        }

        public string Comment
        {
            get;
            set;
        }
        public virtual Behaviour Behaviour {get; set;}
        public virtual DentalHealth DentalHealth { get; set; }
    }
}
