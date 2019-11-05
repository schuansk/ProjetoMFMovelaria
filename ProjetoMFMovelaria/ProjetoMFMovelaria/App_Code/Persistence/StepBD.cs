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
    public class StepBD
    {
        //INSERE UMA NOVA ETAPA NO BANCO DE DADOS
        public bool Insert(Step step)
        {
            System.Data.IDbConnection objConn;
            System.Data.IDbCommand objCommand;

            string sql = "INSERT INTO etapa(eta_nome, eta_data_inicio, eta_data_conclusao, eta_orc_id, eta_desc)" +
                "VALUES (?name, ?start_date, ?finish_date, ?orc_id, ?desc);";

            objConn = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConn);
            objCommand.Parameters.Add(Mapped.Parameter("?name", step.Name));
            objCommand.Parameters.Add(Mapped.Parameter("?start_date", step.StartDate));
            objCommand.Parameters.Add(Mapped.Parameter("?finish_date", step.FinishDate));
            objCommand.Parameters.Add(Mapped.Parameter("?orc_id", step.OrcId));
            objCommand.Parameters.Add(Mapped.Parameter("?desc", step.Desc));

            objCommand.ExecuteNonQuery();

            objConn.Close();
            objCommand.Dispose();
            objConn.Dispose();

            return true;
        }

        //RETORNA UMA ETAPA CASO ELA EXISTA, PESQUISA BASEADA NO ID ETAPA
        public Step SelectById(string id)
        {
            Step obj = null;

            System.Data.IDbConnection objConn;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;

            objConn = Mapped.Connection();

            objCommand = Mapped.Command("SELECT * FROM etapa WHERE eta_id = ?id", objConn);

            objCommand.Parameters.Add(Mapped.Parameter("?id", id));

            objDataReader = objCommand.ExecuteReader();

            while (objDataReader.Read())
            {
                obj = new Step();
                obj.Id = Convert.ToInt32(objDataReader["eta_id"]);
                obj.Name = Convert.ToString(objDataReader["eta_nome"]);
                obj.StartDate = Convert.ToDateTime(objDataReader["eta_data_inicio"]);
                obj.FinishDate = Convert.ToDateTime(objDataReader["eta_data_conclusao"]);
                obj.OrcId = Convert.ToInt32(objDataReader["eta_orc_id"]);
                obj.Desc = Convert.ToString(objDataReader["eta_desc"]);
            }

            objDataReader.Close();
            objConn.Close();

            objCommand.Dispose();
            objConn.Dispose();
            objDataReader.Dispose();

            return obj;
        }

        //SELECIONA TODAS AS ETAPAS CADASTRADAS
        public DataSet SelectAll()
        {
            DataSet ds = new DataSet();

            System.Data.IDbConnection objConn;
            System.Data.IDbCommand objCommand;
            System.Data.IDataAdapter objDataAdapter;

            objConn = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM etapa ORDER BY eta_nome", objConn);

            objDataAdapter = Mapped.Adapter(objCommand);
            objDataAdapter.Fill(ds);

            objConn.Close();
            objCommand.Dispose();
            objConn.Dispose();

            return ds;
        }
    }
}