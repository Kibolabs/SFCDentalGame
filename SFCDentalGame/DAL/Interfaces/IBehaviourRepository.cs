using System;
using System.Collections.Generic;
using SFCDentalGame.DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace SFCDentalGame.DAL.Interfaces
{
    public interface IBehaviourRepository
    {
        IEnumerable<Behaviour> Behaviours { get; }

        Behaviour GetBehaviourById(int behaviourId);
    }
}
