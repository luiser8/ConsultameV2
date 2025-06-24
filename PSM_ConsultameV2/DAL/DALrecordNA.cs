using PSM_ConsultameV2.Models;
using PSM_ConsultameV2.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace PSM_ConsultameV2.DAL
{
    public class DALrecordNA
    {
        private readonly CustomDataTable _dbCon = new CustomDataTable();
        private DataTable _dt = new DataTable();
        private readonly Hashtable _params = new Hashtable();

        public IEnumerable<RecordNA> GetRecords(int IdAl)
        {
            _params.Clear();
            _params.Add("@IdAl", IdAl);
            _dt = _dbCon.Execute("[dbo].[RecordsNA]", _params);

            if (_dt != null || _dt.Rows.Count != 0)
            {
                foreach (DataRow row in _dt.Rows)
                {
                    RecordNA items = new RecordNA
                    {
                        Lapso = Convert.ToString(row["lapso"]),
                        Codmateria = Convert.ToInt32(row["codmateria"]),
                        Calificacion = Convert.ToByte(row["Calificacion"]),
                        Seccion = Convert.ToString(row["seccion"]),
                        Equivalencia = Convert.ToByte(row["equivalencia"]),
                        Cualitativa = Convert.ToByte(row["cualitativa"]),
                        NombreMateria = Convert.ToString(row["NombreMateria"]),
                        Semestre = Convert.ToByte(row["Semestre"]),
                        HT = Convert.ToByte(row["HT"]),
                        HP = Convert.ToByte(row["HP"]),
                        HL = Convert.ToByte(row["HL"]),
                        TH = Convert.ToByte(row["TH"]),
                        UC = Convert.ToByte(row["UC"]),
                        NombreOpcion = Convert.ToString(row["Nombre_Opcion"])
                    };
                    yield return items;
                }
            }
        }
    }
}