using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Data.Database
{
    public class PlanAdapter : Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Plan> _Planes;

        private static List<Plan> Planes
        {
            get
            {
                if (_Planes == null)
                {
                    _Planes = new List<Business.Entities.Plan>();
                    Business.Entities.Plan p;
                    p = new Business.Entities.Plan();
                    p.ID = 0;
                    p.State = Business.Entities.BusinessEntity.States.Unmodified;
                    p.Descripcion = "plan viejo";
                    p.IDEspecialidad = 2;
                    _Planes.Add(p);

                    p = new Business.Entities.Plan();
                    p.ID = 1;
                    p.State = Business.Entities.BusinessEntity.States.Unmodified;
                    p.Descripcion = "plan nuevo";
                    p.IDEspecialidad = 3;
                    _Planes.Add(p);
                }
                return _Planes;
            }
        }
        #endregion

        public List<Plan> GetAll()
        {
            return new List<Plan>(Planes);
        }

        public Business.Entities.Plan GetOne(int ID)
        {
            return Planes.Find(delegate (Plan p) { return p.ID == ID; });
        }

        public void Delete(int ID)
        {
            Planes.Remove(this.GetOne(ID));
        }

        public void Save(Plan plan)
        {
            if (plan.State == BusinessEntity.States.New)
            {
                int NextID = 0;
                foreach (Plan p in Planes)
                {
                    if (p.ID > NextID)
                    {
                        NextID = p.ID;
                    }
                }
                plan.ID = NextID + 1;
                Planes.Add(plan);
            }
            else if (plan.State == BusinessEntity.States.Deleted)
            {
                this.Delete(plan.ID);
            }
            else if (plan.State == BusinessEntity.States.Modified)
            {
                Planes[Planes.FindIndex(delegate (Plan p) { return p.ID == plan.ID; })] = plan;
            }
            plan.State = BusinessEntity.States.Unmodified;
        }
    }
}