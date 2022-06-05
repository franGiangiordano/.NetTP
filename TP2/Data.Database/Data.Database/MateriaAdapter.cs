using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;

//Se trata de una clase de prueba con una DB hardcodeada por lo tanto no formará parte del TP, sin embargo,
//resulta útil para tener como referencia

namespace Data.Database
{
    public class MateriaAdapter : Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
        private static List<Materia> _Materias;

        private static List<Materia> Materias
        {
            get
            {
                if (_Materias == null)
                {
                    _Materias = new List<Business.Entities.Materia>();
                    Business.Entities.Materia mat;
                    mat = new Business.Entities.Materia();
                    mat.ID = 1;
                    mat.State = Business.Entities.BusinessEntity.States.Unmodified;
                    mat.Descripcion = ".net";
                    mat.HSSemanales = 2;
                    mat.HSTotales = 10;
                    mat.IDPlan = 0;
                    _Materias.Add(mat);

                    mat = new Business.Entities.Materia();
                    mat.ID = 2;
                    mat.State = Business.Entities.BusinessEntity.States.Unmodified;
                    mat.Descripcion = "java";
                    mat.HSSemanales = 3;
                    mat.HSTotales = 12;
                    mat.IDPlan = 1;
                    _Materias.Add(mat);


                }
                return _Materias;
            }
        }
        #endregion

        public List<Materia> GetAll()
        {
            return new List<Materia>(Materias);
        }

        public Business.Entities.Materia GetOne(int ID)
        {
            return Materias.Find(delegate (Materia m) { return m.ID == ID; });
        }

        public void Delete(int ID)
        {
            Materias.Remove(this.GetOne(ID));
        }

        public void Save(Materia materia)
        {
            if (materia.State == BusinessEntity.States.New)
            {
                int NextID = 0;
                foreach (Materia mat in Materias)
                {
                    if (mat.ID > NextID)
                    {
                        NextID = mat.ID;
                    }
                }
                materia.ID = NextID + 1;
                Materias.Add(materia);
            }
            else if (materia.State == BusinessEntity.States.Deleted)
            {
                this.Delete(materia.ID);
            }
            else if (materia.State == BusinessEntity.States.Modified)
            {
                Materias[Materias.FindIndex(delegate (Materia m) { return m.ID == materia.ID; })] = materia;
            }
            materia.State = BusinessEntity.States.Unmodified;
        }
    }
}
