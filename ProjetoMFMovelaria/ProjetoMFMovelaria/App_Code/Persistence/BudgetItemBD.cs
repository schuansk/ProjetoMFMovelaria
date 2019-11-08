using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FATEC;

namespace ProjetoMFMovelaria.App_Code.Persistence
{
    public class BudgetItemBD
    {
        public bool Insert(string descricao, string tipo, string quantidade, string preco, int ativo, int id)
        {
            System.Data.IDbConnection objConn;
            System.Data.IDbCommand objCommand;

            string sql = "INSERT INTO orcamento_item(ori_descricao, ori_tipo, ori_quantidade, ori_preco, ori_ativo, orc_id)" +
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
    }
}