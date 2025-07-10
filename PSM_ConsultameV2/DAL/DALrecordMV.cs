using PSM_ConsultameV2.Models;
using PSM_ConsultameV2.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace PSM_ConsultameV2.DAL
{
    public class DALrecordMV
    {
        private readonly CustomDataTable _dbCon = new CustomDataTable();
        private DataTable _dt = new DataTable();
        private readonly Hashtable _params = new Hashtable();

        public IEnumerable<RecordMV> GetRecords(int IdAl)
        {
            _params.Clear();
            _params.Add("@IdAl", IdAl);
            _dt = _dbCon.Execute("[dbo].[RecordsMV]", _params);

            if (_dt != null || _dt.Rows.Count != 0)
            {
                foreach (DataRow row in _dt.Rows)
                {
                    RecordMV items = new RecordMV
                    {
                        Codmateria = Convert.ToInt32(row["codmateria"]),
                        Semestre = Convert.ToString(row["Semestre"]),
                        NombreMateria = Convert.ToString(row["NombreMateria"]),
                        HT = Convert.ToInt32(row["HT"]),
                        HP = Convert.ToInt32(row["HP"]),
                        HL = Convert.ToInt32(row["HL"]),
                        TH = Convert.ToInt32(row["TH"]),
                        UC = Convert.ToInt32(row["UC"])
                    };
                    yield return items;
                }
            }
        }
    }
}