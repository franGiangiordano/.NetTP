using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PlanLogic :BusinessLogic
    {
        PlanAdapter _PlanData = new PlanAdapter();

        public PlanLogic()
        {
        }

        public List<Plan> GetAll()
        {
            return _PlanData.GetAll();
        }

        public Business.Entities.Plan GetOne(int id)
        {
            return _PlanData.GetOne(id);
        }

        public void Delete(int id)
        {
            _PlanData.Delete(id);
            return;
        }

        public void Save(Business.Entities.Plan p)
        {
            _PlanData.Save(p);
            return;
        }
    }
}

