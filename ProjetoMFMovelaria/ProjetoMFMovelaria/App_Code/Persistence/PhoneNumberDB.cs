using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FATEC;
using ProjetoMFMovelaria.App_Code.Class;
using System.Data;

namespace ProjetoMFMovelaria.App_Code.Persistence
{
    public class PhoneNumberDB
    {
        //INSERE OS NÚMEROS DE TELEFONE NA TABELA TELEFONE-FORNECEDOR
        public bool Insert(int idsupplier, string phonenumber)
        {
            System.Data.IDbConnection objConn;
            System.Data.IDbCommand objCommand;

            string sql = "INSERT INTO telefone_fornecedor(for_id, tel_numero) VALUES (?idsupplier, ?number);";

            objConn = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConn);
            objCommand.Parameters.Add(Mapped.Parameter("?idsupplier", idsupplier));
            objCommand.Parameters.Add(Mapped.Parameter("?number", phonenumber));

            objCommand.ExecuteNonQuery();

            objConn.Close();
            objCommand.Dispose();
            objConn.Dispose();

            return true;
        }
    }
}