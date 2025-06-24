using PSM_ConsultameV2.Models;
using PSM_ConsultameV2.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace PSM_ConsultameV2.DAL
{
    public class DALrecordHA
    {
        private readonly CustomDataTable _dbCon = new CustomDataTable();
        private DataTable _dt = new DataTable();
        private readonly Hashtable _params = new Hashtable();

        public IEnumerable<RecordHA> GetRecords(int IdAl)
        {
            _params.Clear();
            _params.Add("@IdAl", IdAl);
            _dt = _dbCon.Execute("[dbo].[RecordsHA]", _params);

            if (_dt != null || _dt.Rows.Count != 0)
            {
                foreach (DataRow row in _dt.Rows)
                {
                    RecordHA items = new RecordHA
                    {
                        IdMateria = Convert.ToInt32(row["IdMateria"]),
                        NombreOpcion = Convert.ToString(row["Nombre_Opcion"]),
                        Materia = Convert.ToString(row["Materia"]),
                        Turno = Convert.ToString(row["Turno"]),
                        DiaClase = Convert.ToString(row["DiaClase"]),
                        IdHora = Convert.ToInt32(row["IdHora"]),
                        Hora = Convert.ToString(row["Hora"]),
                        Dia = Convert.ToByte(row["Dia"]),
                        Bloque = Convert.ToString(row["Bloque"]),
                        Aula = Convert.ToString(row["aula"]),
                        Seccion = Convert.ToString(row["Seccion"]),
                        Docente = Convert.ToString(row["Docente"]),
                        Lapso = Convert.ToString(row["Lapso"])
                    };
                    yield return items;
                }
            }
        }
    }
}