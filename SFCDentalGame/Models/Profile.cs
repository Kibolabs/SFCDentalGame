using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace SFCDentalGame.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Profile
    { 
        public int ProfileId { get; set; }
        public int DentalHealthId { get; set; }
        //public int HealthDetailId { get; set; }
        public DateTime CreateTime { get; set; }

        public DentalHealth DentalHealth { get; set; }
        //public DentalHealthDetail healthDetail { get; set; }
    }

}
