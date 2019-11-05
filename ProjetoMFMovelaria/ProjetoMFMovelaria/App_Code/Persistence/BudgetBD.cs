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
    public class BudgetBD
    {
        //INSERE UM NOVO ORCAMENTO NO BANCO DE DADOS
        public bool Insert(Budget budget)
        {
            System.Data.IDbConnection objConn;
            System.Data.IDbCommand objCommand;

            string sql = "INSERT INTO orcamento(orc_data_inicio, orc_email, orc_total_orcamento, orc_ativo)" +
                "VALUES (?start_date, ?email, ?total_budget, ?active);";

            objConn = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConn);
            objCommand.Parameters.Add(Mapped.Parameter("?start_date", budget.StartDate));
            objCommand.Parameters.Add(Mapped.Parameter("?email", budget.Email));
            objCommand.Parameters.Add(Mapped.Parameter("?total_budget", budget.TotalBudget));
            objCommand.Parameters.Add(Mapped.Parameter("?active", budget.Active));

            objCommand.ExecuteNonQuery();

            objConn.Close();
            objCommand.Dispose();
            objConn.Dispose();

            return true;
        }

        //RETORNA UM ORCAMENTO CASO ELE EXISTA, PESQUISA BASEADA NO ORC_ID
        public Budget SelectById(string id)
        {
            Budget obj = null;

            System.Data.IDbConnection objConn;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;

            objConn = Mapped.Connection();

            objCommand = Mapped.Command("SELECT * FROM orcamento WHERE orc_id = ?id", objConn);

            objCommand.Parameters.Add(Mapped.Parameter("?id", id));

            objDataReader = objCommand.ExecuteReader();

            while (objDataReader.Read())
            {
                obj = new Budget();
                obj.StartDate = Convert.ToDateTime(objDataReader["orc_data_inicio"]);
                obj.Email = Convert.ToString(objDataReader["orc_email"]);
                obj.TotalBudget = Convert.ToDouble(objDataReader["orc_total_orcamento"]);
                obj.Active = Convert.ToBoolean(objDataReader["orc_ativo"]);
            }

            objDataReader.Close();
            objConn.Close();

            objCommand.Dispose();
            objConn.Dispose();
            objDataReader.Dispose();

            return obj;
        }

        //SELECIONA TODOS OS ORCAMENTOS CADASTRADOS
        public DataSet SelectAll()
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConn;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            objConn = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM orcamento", objConn);

            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);

            objConn.Close();
            objCommand.Dispose();
            objConn.Dispose();

            return ds;
        }
    }
}