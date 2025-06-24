using PSM_ConsultameV2.Models;
using PSM_ConsultameV2.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace PSM_ConsultameV2.DAL
{
    public class DALrecordCA
    {
        private readonly CustomDataTable _dbCon = new CustomDataTable();
        private DataTable _dt = new DataTable();
        private readonly Hashtable _params = new Hashtable();

        public IEnumerable<RecordCA> GetRecords(int IdAl)
        {
            _params.Clear();
            _params.Add("@IdAl", IdAl);
            _dt = _dbCon.Execute("[dbo].[RecordsCA]", _params);

            if (_dt != null || _dt.Rows.Count != 0)
            {
                foreach (DataRow row in _dt.Rows)
                {
                    RecordCA items = new RecordCA
                    {
                        CodMateria = Convert.ToInt32(row["CodMateria"]),
                        NombreMateria = Convert.ToString(row["NombreMateria"]),
                        TH = Convert.ToByte(row["TH"]),
                        UC = Convert.ToByte(row["UC"]),
                        Aula = Convert.ToString(row["aula"]),
                        NombreTurno = Convert.ToString(row["NombreTurno"]),
                        Seccion = Convert.ToString(row["Seccion"]),
                        NombreOpcion = Convert.ToString(row["Nombre_Opcion"]),
                        Semestre = Convert.ToByte(row["Semestre"]),
                        CHH = Convert.ToByte(row["CHH"]),
                        Prel = Convert.ToByte(row["Prel"])
                    };
                    yield return items;
                }
            }
        }
    }
}