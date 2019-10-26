using FATEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoMFMovelaria.App_Code.Class;
using System.Data;

namespace ProjetoMFMovelaria.App_Code.Persistence
{
    public class ConnTestDB
    {
        public bool Insert(ConnTest connTest)
        {
            System.Data.IDbConnection objConn;
            System.Data.IDbCommand objCommand;

            string sql = "INSERT INTO teste_conexao(tes_nome) VALUES (?name)";

            objConn = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConn);

            objCommand.Parameters.Add(Mapped.Parameter("?name", connTest.Name));
            objCommand.ExecuteNonQuery();

            objConn.Close();
            objCommand.Dispose();
            objConn.Dispose();

            return true;
        }

        public DataSet SelectAll()
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConn;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            objConn = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM teste_conexao", objConn);
            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);

            objConn.Close();
            objCommand.Dispose();
            objConn.Dispose();

            return ds;
        }
    }
}