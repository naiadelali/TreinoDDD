

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EstudoDDD.Infra.Dados.Contexto
{
    public class ProjetoContextoNormal
    { 
        #region Propriedades

        public SqlConnection MyBdConnection { get; set; }
        public string NomeStringConexao { get; set; }
        public string StringDeConexao { get; set; }

        #endregion Propriedades

        #region Construtores

        public ProjetoContextoNormal()
        {
            //this.StringDeConexao = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aspnet-WebApplication2-20150209085116.mdf;Initial Catalog=aspnet-WebApplication2-20150209085116;Integrated Security=True";
            this.StringDeConexao = @"Data Source=(LocalDb)\v11.0;" +
                                   @"AttachDbFilename=C:\Users\naiade.lima\Documents\Visual Studio 2013\Projects\WebApplication2\WebApplication2\App_Data\aspnet-WebApplication2-20150209085116.mdf;" +
                                   @"Initial Catalog=aspnet-WebApplication2-20150209085116;" +
                                   "Integrated Security=True;";
            
            this.MyBdConnection = new SqlConnection(StringDeConexao);

            //this.NomeStringConexao = "DefaultConnection";
            //this.MyBdConnection = new SqlConnection(this.NomeStringConexao);

        }

        public ProjetoContextoNormal(string nomeStringConexao)
        {

            this.NomeStringConexao = nomeStringConexao;
            this.MyBdConnection = new SqlConnection(this.NomeStringConexao);
        }

      
        #endregion


        #region Métodos Privados

        private string GetCorrectParameterName(string parameterName)
        {
            if (parameterName[0] != '@')
            {
                parameterName = "@" + parameterName;
            }
            return parameterName;
        }

        #endregion

        #region Métodos Públicos

        public static ProjetoContextoNormal Create()
        {
            return new ProjetoContextoNormal();
        }

        public static ProjetoContextoNormal Create(string nomeStringConexao)
        {
            return new ProjetoContextoNormal(nomeStringConexao);
        }

        public void OpenConnection()
        {
            if (this.MyBdConnection.State == System.Data.ConnectionState.Closed)
            {
                this.MyBdConnection.Open();
            }
        }

        public void CloseConection()
        {
            this.MyBdConnection.Close();
        }

        public SqlParameter BuildParameter(string nome, object valor, DbType tipo, int size)
        {
            SqlParameter parametro = new SqlParameter(this.GetCorrectParameterName(nome), valor);
            parametro.DbType = tipo;
            parametro.Size = size;
            return parametro;
        }

        public void BuildParameter(string nome, object valor, DbType tipo, int size, List<SqlParameter> listParametros)
        {
            SqlParameter parametro = this.BuildParameter(nome, valor, tipo, size);
            listParametros.Add(parametro);
        }

        public SqlParameter BuildOutPutParameter(string nome, DbType tipo, int size)
        {
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = this.GetCorrectParameterName(nome);
            parametro.DbType = tipo;
            parametro.Size = size;
            parametro.Direction = ParameterDirection.Output;
            return parametro;
        }

        public void BuildOutPutParameter(string nome, DbType tipo, int size, List<SqlParameter> listParametros)
        {
            SqlParameter parametro = this.BuildOutPutParameter(nome, tipo, size);
            listParametros.Add(parametro);
        }

        public void ExecuteNonQuery(SqlCommand command)
        {
            command.ExecuteNonQuery();
        }

        public void ExecuteNonQuery(SqlCommand command, bool openConnection)
        {
            if (openConnection)
            {
                this.OpenConnection();
            }
            this.ExecuteNonQuery(command);
            if (openConnection)
            {
                this.CloseConection();
            }
        }

        public void ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            Exception erro = null;
            try
            {
                this.OpenConnection();
                SqlCommand command = this.MyBdConnection.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddRange(parameters);
                this.ExecuteNonQuery(command);
                this.CloseConection();
            }
            catch (Exception ex)
            {
                erro = ex;
            }
            finally
            {
                this.CloseConection();
            }

            if (erro != null)
            {
                throw erro;
            }
        }

        public SqlDataReader ExecuteDataReader(string query, params SqlParameter[] parameters)
        {
            SqlDataReader reader = null;
            Exception erro = null;
            try
            {
                this.OpenConnection();
                SqlCommand command = this.MyBdConnection.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddRange(parameters);
                
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                erro = ex;
            }
            finally
            {
               // this.CloseConection();
            }

            if (erro != null)
            {
                throw erro;
            }
            return reader;
        }

        public void ExecuteCommands(params SqlCommand[] commands)
        {
            Exception erro = null;
            SqlTransaction trans = null;
            try
            {
                this.MyBdConnection.Open();
                trans = this.MyBdConnection.BeginTransaction();
                for (int i = 0; i < commands.Length; i++)
                {
                    commands[i].Transaction = trans;
                    this.ExecuteNonQuery(commands[i]);
                }
                trans.Commit();
                this.MyBdConnection.Close();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                erro = ex;
            }
            finally
            {
                this.MyBdConnection.Close();
            }

            if (erro != null)
            {
                throw erro;
            }
        }

        #endregion
    }
}



