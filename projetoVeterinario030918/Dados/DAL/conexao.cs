using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace projetoVeterinario030918.Dados.DAL
{
    public class conexao
    {


        //SqlConnection con = new SqlConnection(@"Persist Security Info=False;User ID=sa;password=1234567;" +
          //      "Initial Catalog=bdClinicaVet0309; Data Source=LAB3PC06\\SA"); //*NOME DO BANCO E DO SERVIDOR DA MAQUINA VERIFICANDO NO SQLMANAGER*

       SqlConnection con = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;" +
                "Initial Catalog=bdClinicaVet0309;Data Source=PC-FAMILIA");

        public SqlConnection conectarBD()
        {
            try
            {
                con.Open();
            }
            catch (Exception e)
            {
                // MessageBox.Show("Erro na Conexão");
                //*-*mudar para alert
            }
            return con;
        }


        public SqlConnection desconectarBD()
        {
            try
            {
                con.Close();
            }
            catch (Exception e)
            {
                // MessageBox.Show("Erro na Conexão");
            }
            return con;
        }
    }
}