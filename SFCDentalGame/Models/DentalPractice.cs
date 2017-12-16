using System;
using System.Collections.Generic;
using SFCDentalGame.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SFCDentalGame.DAL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SFCDentalGame.Models
{
    public class DentalPractice
    {
        public readonly SFCContext _Context;
        public DentalPractice(SFCContext Context)
        {
            _Context = Context;
        }

        public String DentalPracticeId{ get; set; }


        public List<DentalPracticeItem> PracticeItems { get; set; }


        public static DentalPractice GetPractice(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<SFCContext>();
            string practicesId = session.GetString("PracticeId") ?? Guid.NewGuid().ToString();
            session.SetString("PracticeId",practicesId);

            return new DentalPractice(context) { DentalPracticeId = practicesId };
        }


        public void AddToPractice(Behaviour behaviour, double score)
        {
            var practiceItem = _Context.PracticeItems.SingleOrDefault(
                s => s.Behaviour.BehaviourId == behaviour.BehaviourId && s.DentalPracticeId == DentalPracticeId);
            if(practiceItem==null){
                practiceItem = new DentalPracticeItem
                {
                    DentalPracticeId=DentalPracticeId, Behaviour=behaviour
                };
                _Context.PracticeItems.Add(practiceItem);
            }
            else{
                // tell them its been added already and return nothing
                return;
            }
            _Context.SaveChanges();
        }


        public void RemoveFromPractice(Behaviour behaviour){
            var practiceItem = _Context.PracticeItems.SingleOrDefault(
                s => s.Behaviour.BehaviourId == behaviour.BehaviourId && s.DentalPracticeId == DentalPracticeId);

            _Context.PracticeItems.Remove(practiceItem);
            _Context.SaveChanges();
        }


        public List<DentalPracticeItem> GetDentalPracticeItems()
        {
            return PracticeItems ??
                (PracticeItems =
                 _Context.PracticeItems.Where(c => c.DentalPracticeId == DentalPracticeId)
                           .Include(s => s.Behaviour)
                           .ToList());
        }


        public void ClearPractices()
        {
            var practiceListItems = _Context
                .PracticeItems
                .Where(prac => prac.DentalPracticeId == DentalPracticeId);

            _Context.PracticeItems.RemoveRange(practiceListItems);

            _Context.SaveChanges();
        }


        public decimal GetTotolScore()
        {
            var total = _Context.PracticeItems.Where(c => c.DentalPracticeId == DentalPracticeId)
                                .Select(c => c.Behaviour.Points ).Sum();
            return (decimal)total;
        }

    }
}
