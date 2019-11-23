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
        public bool Insert(DateTime data, string email, string total, int id)
        {
            System.Data.IDbConnection objConn;
            System.Data.IDbCommand objCommand;

            string sql = "INSERT INTO orcamento(orc_data_inicio, orc_email, orc_total_orcamento, fun_id)" +
                "VALUES (?data, ?email, ?total, ?id);";

            objConn = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConn);
            objCommand.Parameters.Add(Mapped.Parameter("?data", data));
            objCommand.Parameters.Add(Mapped.Parameter("?email", email));
            objCommand.Parameters.Add(Mapped.Parameter("?total", total));
            objCommand.Parameters.Add(Mapped.Parameter("?id", id));

            objCommand.ExecuteNonQuery();

            objConn.Close();
            objCommand.Dispose();
            objConn.Dispose();

            return true;
        }

        //RETORNA UM ORCAMENTO CASO ELE EXISTA, PESQUISA BASEADA NO ORC_ID
        public Budget SelectById(int id)
        {
            Budget obj = null;

            System.Data.IDbConnection objConn;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;

            objConn = Mapped.Connection();

            objCommand = Mapped.Command("SELECT * FROM orcamento orc JOIN funcionario fun on fun.fun_id = orc.fun_id WHERE orc.orc_id = ?id", objConn);

            objCommand.Parameters.Add(Mapped.Parameter("?id", id));

            objDataReader = objCommand.ExecuteReader();

            while (objDataReader.Read())
            {
                obj = new Budget();
                obj.Id = Convert.ToInt32(objDataReader["orc_id"]);
                obj.StartDate = Convert.ToDateTime(objDataReader["orc_data_inicio"]);
                obj.Email = Convert.ToString(objDataReader["orc_email"]);
                obj.TotalBudget = Convert.ToDouble(objDataReader["orc_total_orcamento"]);
                obj.Active = Convert.ToBoolean(objDataReader["orc_ativo"]);
                obj.NameEmployee = Convert.ToString(objDataReader["fun_nome"]);
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
            objCommand = Mapped.Command("SELECT * FROM orcamento orc join funcionario fun on fun.fun_id = orc.fun_id", objConn);

            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);

            objConn.Close();
            objCommand.Dispose();
            objConn.Dispose();

            return ds;
        }

        //ALTERA O STATUS DO ORCAMENTO ENTRE ATIVO E INATIVO
        public bool UpdateBudget(Budget budget)
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("UPDATE orcamento SET orc_ativo = '0' WHERE orc_id = '" + budget.Id + "'", objConexao);
            objCommand.ExecuteNonQuery();

            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();

            return true;
        }

    }
}