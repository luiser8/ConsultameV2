using PSM_ConsultameV2.Models;
using PSM_ConsultameV2.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace PSM_ConsultameV2.DAL
{
    public class DALrecordCV
    {
        private readonly CustomDataTable _dbCon = new CustomDataTable();
        private DataTable _dt = new DataTable();
        private readonly Hashtable _params = new Hashtable();

        public IEnumerable<RecordCV> GetRecords(int IdAl)
        {
            _params.Clear();
            _params.Add("@IdAl", IdAl);
            _dt = _dbCon.Execute("[dbo].[RecordsCV]", _params);

            if (_dt != null || _dt.Rows.Count != 0)
            {
                foreach (DataRow row in _dt.Rows)
                {
                    RecordCV items = new RecordCV
                    {
                        Codmateria = Convert.ToInt32(row["Codmateria"]),
                        NombreMateria = Convert.ToString(row["NombreMateria"]),
                        TH = Convert.ToByte(row["TH"]),
                        UC = Convert.ToByte(row["UC"]),
                        NombreOpcion = Convert.ToString(row["Nombre_Opcion"]),
                        Corte1 = Math.Floor(Convert.ToDecimal(row["Corte1"]) * 100) / 100,
                        Corte2 = Math.Floor(Convert.ToDecimal(row["Corte2"]) * 100) / 100,
                        Corte3 = Math.Floor(Convert.ToDecimal(row["Corte3"]) * 100) / 100,
                        Definitiva = Math.Floor(Convert.ToDecimal(row["Definitiva"]) * 100) / 100,
                        Semestre = Convert.ToByte(row["Semestre"])
                    };
                    yield return items;
                }
            }
        }
    }
}