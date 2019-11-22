using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using FATEC;
using ProjetoMFMovelaria.App_Code.Class;
using ProjetoMFMovelaria.App_Code.Persistence;

namespace ProjetoMFMovelaria.App_Code.Persistence
{
    public class StepBD
    {
        //INSERE UMA NOVA ETAPA NO BANCO DE DADOS
        public bool Insert(Step step)
        {
            System.Data.IDbConnection objConn;
            System.Data.IDbCommand objCommand;

            string sql = "INSERT INTO etapa(etd_id, eta_data_inicio, eta_data_conclusao, orc_id, eta_desc)" +
                "VALUES (?etd_id, ?start_date, ?finish_date, ?orc_id, ?desc);";

            objConn = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConn);
            objCommand.Parameters.Add(Mapped.Parameter("?etd_id", step.EtdId));
            objCommand.Parameters.Add(Mapped.Parameter("?start_date", step.StartDate));
            objCommand.Parameters.Add(Mapped.Parameter("?finish_date", step.FinishDate));
            objCommand.Parameters.Add(Mapped.Parameter("?orc_id", step.OrcId));
            objCommand.Parameters.Add(Mapped.Parameter("?desc", step.Desc));

            objCommand.ExecuteNonQuery();

            objConn.Close();
            objCommand.Dispose();
            objConn.Dispose();

            return true;
        }

        //RETORNA UMA ETAPA CASO ELA EXISTA, PESQUISA BASEADA NO ID ETAPA
        public DataSet SelectStepById(int id)
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConn;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            objConn = Mapped.Connection();

            objCommand = Mapped.Command("SELECT * FROM etapa eta JOIN orcamento orc on orc.orc_id = eta.orc_id JOIN etapa_descricao des on des.etd_id = eta.etd_id WHERE orc.orc_id = ?id", objConn);
            

            objCommand.Parameters.Add(Mapped.Parameter("?id", id));

            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);

            objConn.Close();
            objCommand.Dispose();
            objConn.Dispose();

            return ds;
        }

        public bool UpdatePreviousStep(int etaId)
        {
            //Step obj = null;

            System.Data.IDbConnection objConn;
            System.Data.IDbCommand objCommand;

            string sql = "UPDATE etapa SET eta_data_conclusao = now() WHERE eta_id= ?eta_id";

            objConn = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConn);
            objCommand.Parameters.Add(Mapped.Parameter("?eta_id", etaId));

            objCommand.ExecuteNonQuery();

            objConn.Close();
            objCommand.Dispose();
            objConn.Dispose();

            return true;
        }

        public Step SelectPreviousStep(int id)
        {
            Step obj = null;

            System.Data.IDbConnection objConn;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;

            objConn = Mapped.Connection();

            objCommand = Mapped.Command("select * from etapa eta join etapa_descricao des on des.etd_id = eta.etd_id where eta.orc_id=?id order by eta.etd_id desc limit 1", objConn);

            objCommand.Parameters.Add(Mapped.Parameter("?id", id));

            objDataReader = objCommand.ExecuteReader();

            while (objDataReader.Read())
            {
                obj = new Step();
                obj.Id = Convert.ToInt32(objDataReader["eta_id"]);
                obj.EtdId = Convert.ToInt32(objDataReader["etd_id"]);
                obj.OrcId = Convert.ToInt32(objDataReader["orc_id"]);
                obj.EtdDescricao = Convert.ToString(objDataReader["etd_descricao"]);
                obj.FinishDate = Convert.ToDateTime(objDataReader["eta_data_conclusao"]);
            }

            objDataReader.Close();
            objConn.Close();

            objCommand.Dispose();
            objConn.Dispose();
            objDataReader.Dispose();

            return obj;
        }

        //SELECIONA TODAS AS ETAPAS CADASTRADAS
        public DataSet SelectAll()
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConn;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            objConn = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM etapa ORDER BY etd_id", objConn);

            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);

            objConn.Close();
            objCommand.Dispose();
            objConn.Dispose();

            return ds;
        }
    }
}