using System;
using System.Collections.Generic;
using SFCDentalGame.DAL.Entities;

namespace SFCDentalGame.DAL.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
