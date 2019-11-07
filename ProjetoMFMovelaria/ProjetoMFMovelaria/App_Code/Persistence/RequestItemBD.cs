﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using FATEC;
using ProjetoMFMovelaria.App_Code.Class;
using ProjetoMFMovelaria.App_Code.Persistence;

namespace ProjetoMFMovelaria.App_Code.Persistence
{
    public class RequestItemBD
    {
        //INSERE UM NOVO ORCAMENTO NO BANCO DE DADOS
        public bool Insert(RequestItem requestItem)
        {
            System.Data.IDbConnection objConn;
            System.Data.IDbCommand objCommand;

            string sql = "INSERT INTO pedido_item(pei_descricao, pei_tipo, pei_quantidade, pei_preco, pei_ativo, ped_id)" +
                "VALUES (?desc, ?type_of_item, ?qty, ?price, ?active, ?ped_id);";

            objConn = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConn);
            objCommand.Parameters.Add(Mapped.Parameter("?desc", requestItem.Desc));
            objCommand.Parameters.Add(Mapped.Parameter("?type_of_item", requestItem.TypeOfItem));
            objCommand.Parameters.Add(Mapped.Parameter("?qty", requestItem.Qty));
            objCommand.Parameters.Add(Mapped.Parameter("?price", requestItem.Price));
            objCommand.Parameters.Add(Mapped.Parameter("?active", requestItem.isActive));
            objCommand.Parameters.Add(Mapped.Parameter("?ped_id", requestItem.PedId));

            objCommand.ExecuteNonQuery();

            objConn.Close();
            objCommand.Dispose();
            objConn.Dispose();

            return true;
        }

        //RETORNA UM ORCAMENTO CASO ELE EXISTA, PESQUISA BASEADA NO ORC_ID
        public DataSet SelectItemsById(int id)
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConn;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            objConn = Mapped.Connection();

            objCommand = Mapped.Command("SELECT * FROM pedido_item WHERE ped_id = ?id", objConn);

            objCommand.Parameters.Add(Mapped.Parameter("?id", id));

            //objDataReader = objCommand.ExecuteReader();

            //while (objDataReader.Read())
            //{
            //    obj = new RequestItem();
            //    obj.PeiId = Convert.ToInt32(objDataReader["pei_id"]);
            //    obj.Desc = Convert.ToString(objDataReader["pei_descricao"]);
            //    obj.TypeOfItem = Convert.ToString(objDataReader["pei_tipo"]);
            //    obj.Qty = Convert.ToInt32(objDataReader["pei_quantidade"]);
            //    obj.Price = Convert.ToDouble(objDataReader["pei_preco"]);
            //    obj.isActive = Convert.ToBoolean(objDataReader["pei_ativo"]);
            //    obj.isCorrect = Convert.ToBoolean(objDataReader["pei_correto"]);
            //    obj.PedId = Convert.ToInt32(objDataReader["ped_id"]);
            //}

            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);

            objConn.Close();
            objCommand.Dispose();
            objConn.Dispose();

            return ds;
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