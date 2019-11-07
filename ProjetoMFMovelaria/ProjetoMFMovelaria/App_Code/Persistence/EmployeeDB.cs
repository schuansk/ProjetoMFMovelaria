using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FATEC;
using System.Data;
using ProjetoMFMovelaria.App_Code.Class;

namespace ProjetoMFMovelaria.App_Code.Persistence
{
    public class EmployeeDB
    {
        public Employee Autentica(string email, string password)
        {
            Employee obj = null;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM funcionario WHERE fun_email = ?email and fun_senha = ?senha", objConexao);


            objCommand.Parameters.Add(Mapped.Parameter("?email", email));
            objCommand.Parameters.Add(Mapped.Parameter("?senha", password));

            objDataReader = objCommand.ExecuteReader();

            while (objDataReader.Read())
            {
                obj = new Employee();
                obj.Id = Convert.ToInt32(objDataReader["fun_id"]);
                obj.Name = Convert.ToString(objDataReader["fun_nome"]);
                obj.CPF = Convert.ToString(objDataReader["fun_cpf"]);
                obj.Email = Convert.ToString(objDataReader["fun_email"]);
                obj.Active = Convert.ToBoolean(objDataReader["fun_ativo"]);
                obj.Type = Convert.ToInt32(objDataReader["fun_tipo"]);
            }

            objDataReader.Close();
            objConexao.Close();
            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();

            return obj;
        }

        public Employee Select(int id)
        {
            Employee obj = null;
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            System.Data.IDataReader objDataReader;

            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM funcionario WHERE fun_id = ?codigo", objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?codigo", id));
            objDataReader = objCommand.ExecuteReader();

            while (objDataReader.Read())
            {
                obj = new Employee();
                obj.Id = Convert.ToInt32(objDataReader["fun_id"]);
                obj.Name = Convert.ToString(objDataReader["fun_nome"]);
                obj.Email = Convert.ToString(objDataReader["fun_email"]);
                obj.Type = Convert.ToInt32(objDataReader["fun_tipo"]);
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