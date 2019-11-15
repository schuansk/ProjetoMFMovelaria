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
        public DataSet SelectAllFromBudget(int id)
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConn;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            objConn = Mapped.Connection();
            objCommand = Mapped.Command("SELECT ped.ped_id, ped.ped_data, form.for_nome " +
                "FROM pedido ped INNER JOIN fornecedor form USING(for_id) " +
                "WHERE orc_id = ?id; ", objConn);
            objCommand.Parameters.Add(Mapped.Parameter("?id", id));

            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);

            objConn.Close();
            objCommand.Dispose();
            objConn.Dispose();

            return ds;
        }
    }
}