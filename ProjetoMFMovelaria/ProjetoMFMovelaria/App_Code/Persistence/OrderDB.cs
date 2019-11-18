using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FATEC;
using ProjetoMFMovelaria.App_Code.Class;
using System.Data;

namespace ProjetoMFMovelaria.App_Code.Persistence
{
    public class OrderDB
    {
        // SELECIONA TODOS OS PEDIDOS DO ORÇAMENTO
        public DataSet SelectAllFromBudget(int id)
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConn;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            objConn = Mapped.Connection();
            objCommand = Mapped.Command("SELECT ped.ped_id, ped.ped_data, form.for_nome " +
                "FROM pedido ped INNER JOIN fornecedor form USING(for_id) " +
                "WHERE orc_id = ?id ORDER BY ped.ped_id DESC; ", objConn);
            objCommand.Parameters.Add(Mapped.Parameter("?id", id));

            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);

            objConn.Close();
            objCommand.Dispose();
            objConn.Dispose();

            return ds;
        }

        //INSERE UM NOVO PEDIDO NO BANCO DE DADOS
        public bool Insert(Order order)
        {
            System.Data.IDbConnection objConn;
            System.Data.IDbCommand objCommand;

            string sql = "INSERT INTO pedido(ped_data, for_id, orc_id)" +
                "VALUES (?date, ?forId, ?orcId);";

            objConn = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConn);
            objCommand.Parameters.Add(Mapped.Parameter("?date", order.RegisterDate));
            objCommand.Parameters.Add(Mapped.Parameter("?forId", order.IdSupplier));
            objCommand.Parameters.Add(Mapped.Parameter("?orcId", order.IdBudget));

            objCommand.ExecuteNonQuery();

            objConn.Close();
            objCommand.Dispose();
            objConn.Dispose();

            return true;
        }

        //RETORNA O ULTIMO PEDIDO CADASTRADO
        public int SelectLastOrder()
        {
            int last = 0;

            System.Data.IDbConnection objConn;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;

            objConn = Mapped.Connection();

            objCommand = Mapped.Command("SELECT ped.ped_id FROM pedido ped ORDER BY ped.ped_id DESC LIMIT 1;", objConn);

            objDataReader = objCommand.ExecuteReader();

            while (objDataReader.Read())
            {
                last = Convert.ToInt32(objDataReader["ped_id"]);
            }

            objDataReader.Close();
            objConn.Close();

            objCommand.Dispose();
            objConn.Dispose();
            objDataReader.Dispose();

            return last;
        }
    }
}