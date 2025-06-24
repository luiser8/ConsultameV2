using PSM_ConsultameV2.Models;
using PSM_ConsultameV2.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace PSM_ConsultameV2.DAL
{
    public class DALrecordDA
    {
        private readonly CustomDataTable _dbCon = new CustomDataTable();
        private DataTable _dt = new DataTable();
        private readonly Hashtable _params = new Hashtable();

        public IEnumerable<RecordDA> GetRecords(string Cedula)
        {
            _params.Clear();
            _params.Add("@Cedula", Cedula);
            _dt = _dbCon.Execute("[dbo].[RecordsDA]", _params);

            if (_dt != null || _dt.Rows.Count != 0)
            {
                foreach (DataRow row in _dt.Rows)
                {
                    RecordDA items = new RecordDA
                    {
                        IdAl = Convert.ToInt32(row["IdAl"]),
                        Cedula = Convert.ToString(row["Cedula"]),
                        FullNombre = Convert.ToString(row["FullNombre"]),
                        Sexo = Convert.ToByte(row["Sexo"]),
                        IdEstdo = Convert.ToByte(row["IdEstdo"]),
                        NrBachiller = Convert.ToString(row["NrBachiller"]),
                        IRABachiller = Convert.ToString(row["IRABachiller"]),
                        IdStAca = Convert.ToByte(row["IdStAca"]),
                        LapIng = Convert.ToString(row["LapIng"]),
                        LapAnt = Convert.ToString(row["LapAnt"]),
                        LapCur = Convert.ToString(row["LapCur"]),
                        Iraa = Math.Floor(Convert.ToDecimal(row["Iraa"]) * 100) / 100,
                        UCC = Convert.ToInt32(row["UCC"]),
                        UCA = Convert.ToInt32(row["UCA"]),
                        IdCar = Convert.ToInt32(row["IdCar"]),
                        EstAca = Convert.ToString(row["EstAca"]),
                        Codcarrera = Convert.ToInt32(row["Codcarrera"]),
                        Area = Convert.ToString(row["Area"]),
                        Descripciontitulo = Convert.ToString(row["Descripciontitulo"]),
                        Foto = (Byte[])row["Foto"]
                    };
                    yield return items;
                }
            }
        }
    }
}