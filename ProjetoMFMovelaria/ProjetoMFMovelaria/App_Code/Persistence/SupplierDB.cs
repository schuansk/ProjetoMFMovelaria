using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FATEC;
using ProjetoMFMovelaria.App_Code.Class;
using System.Data;

namespace ProjetoMFMovelaria.App_Code.Persistence
{
    public class SupplierDB
    {
        //INSERE UM NOVO FORNECEDOR NO BANCO DE DADOS
        public bool Insert(Supplier supplier)
        {
            System.Data.IDbConnection objConn;
            System.Data.IDbCommand objCommand;

            string sql = "INSERT INTO fornecedor(for_nome, for_cnpj, for_email, for_cidade, for_uf)" +
                "VALUES (?name, ?cnpj, ?email, ?city, ?uf);";

            objConn = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConn);
            objCommand.Parameters.Add(Mapped.Parameter("?name", supplier.Name));
            objCommand.Parameters.Add(Mapped.Parameter("?cnpj", supplier.CNPJ));
            objCommand.Parameters.Add(Mapped.Parameter("?email", supplier.Email));
            objCommand.Parameters.Add(Mapped.Parameter("?city", supplier.City));
            objCommand.Parameters.Add(Mapped.Parameter("?uf", supplier.UF));

            objCommand.ExecuteNonQuery();

            objConn.Close();
            objCommand.Dispose();
            objConn.Dispose();

            return true;
        }

        //RETORNA UM FORNECEDOR CASO ELE EXISTA, PESQUISA BASEADA NO CNPJ
        public Supplier SelectByCNPJ(string cnpj)
        {
            Supplier obj = null;

            System.Data.IDbConnection objConn;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;

            objConn = Mapped.Connection();

            objCommand = Mapped.Command("SELECT * FROM fornecedor WHERE for_cnpj = ?cnpj", objConn);

            objCommand.Parameters.Add(Mapped.Parameter("?cnpj", cnpj));

            objDataReader = objCommand.ExecuteReader();

            while (objDataReader.Read())
            {
                obj = new Supplier();
                obj.Id = Convert.ToInt32(objDataReader["for_id"]);
                obj.Name = Convert.ToString(objDataReader["for_nome"]);
                obj.CNPJ = Convert.ToString(objDataReader["for_cnpj"]);
                obj.Active = Convert.ToInt32(objDataReader["for_ativo"]);
                obj.Email = Convert.ToString(objDataReader["for_email"]);
            }

            objDataReader.Close();
            objConn.Close();

            objCommand.Dispose();
            objConn.Dispose();
            objDataReader.Dispose();

            return obj;
        }

        //SELECIONA TODOS OS FORNECEDORES CADASTRADOS
        public DataSet SelectAll()
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConn;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            objConn = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM fornecedor ORDER BY for_nome", objConn);

            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);

            objConn.Close();
            objCommand.Dispose();
            objConn.Dispose();

            return ds;
        }        
    }
}