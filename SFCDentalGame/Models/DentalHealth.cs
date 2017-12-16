using System;
using System.Collections.Generic;
namespace SFCDentalGame.Models
{
    public class DentalHealth
    {
        public DentalHealth()
        {
        }
        public int DentalHealthId
        {
            get;
            set;
        }
        public List<DentalHealthDetail> HealthDetails
        {
            get;
            set;
        }
        public DateTime DateTime
        {
            get;
            set;
        }
        public decimal Score
        {
            get;
            set;
        }
        public decimal TeethAge
        {
            get;
            set;
        }
    }
}
