using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FATEC;
using System.Data;
using ProjetoMFMovelaria.App_Code.Class;

namespace ProjetoMFMovelaria.App_Code.Persistence
{
    public class BudgetItemBD
    {
        public bool Insert(string descricao, string tipo, string quantidade, string preco, int ativo, int id)
        {
            System.Data.IDbConnection objConn;
            System.Data.IDbCommand objCommand;

            string sql = "INSERT INTO orcamento_item(ori_descricao, ori_tipo, ori_quantidade, ori_preco_uni, ori_ativo, orc_id)" +
                "VALUES (?descricao, ?tipo, ?quantidade, ?preco, ?ativo, ?id);";

            objConn = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConn);
            objCommand.Parameters.Add(Mapped.Parameter("?descricao", descricao));
            objCommand.Parameters.Add(Mapped.Parameter("?tipo", tipo));
            objCommand.Parameters.Add(Mapped.Parameter("?quantidade", quantidade));
            objCommand.Parameters.Add(Mapped.Parameter("?preco", preco));
            objCommand.Parameters.Add(Mapped.Parameter("?ativo", ativo));
            objCommand.Parameters.Add(Mapped.Parameter("?id", id));


            objCommand.ExecuteNonQuery();

            objConn.Close();
            objCommand.Dispose();
            objConn.Dispose();

            return true;
        }

        // SELECIONA OS ITENS DO ORÇAMENTO
        public DataSet SelectAllById(int id)
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConn;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            objConn = Mapped.Connection();
            objCommand = Mapped.Command("SELECT ori.ori_id, ori.ori_descricao " +
                "FROM orcamento_item ori WHERE orc_id = ?id;", objConn);
            objCommand.Parameters.Add(Mapped.Parameter("?id", id));

            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);

            objConn.Close();
            objCommand.Dispose();
            objConn.Dispose();

            return ds;
        }

        //SELECIONA APENAS UM ITEM
        public BudgetItem Select(int id)
        {
            BudgetItem obj = null;

            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM orcamento_item WHERE ori_id = ?id", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?id", id));

            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                obj = new BudgetItem();
                obj.Id = Convert.ToInt32(objDataReader["ori_id"]);
                obj.Description = Convert.ToString(objDataReader["ori_descricao"]);
                obj.Type = Convert.ToString(objDataReader["ori_tipo"]);
                obj.Amount = Convert.ToInt32(objDataReader["ori_quantidade"]);
                obj.Price = Convert.ToDouble(objDataReader["ori_preco_uni"]);
                obj.Active = Convert.ToInt32(objDataReader["ori_ativo"]);
            }

            objDataReader.Close();
            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();

            return obj;
        }
    }
}