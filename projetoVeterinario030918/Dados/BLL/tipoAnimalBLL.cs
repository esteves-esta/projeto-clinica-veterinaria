using projetoVeterinario030918.Dados.DAL;
using projetoVeterinario030918.Dados.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace projetoVeterinario030918.Dados.BLL
{
    public class tipoAnimalBLL
    {

        conexao con = new conexao();

        public void inserirTipo(tipoAnimalDTO dto)
        {

            SqlCommand cmd = new SqlCommand("pa_inserirTipo", con.conectarBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@cod", SqlDbType.VarChar).Value = dto.codTipo;
            cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = dto.tipo;

            cmd.ExecuteNonQuery();
            con.desconectarBD();
        }

        public DataTable consultaTipo()
        {
            SqlCommand cmd = new SqlCommand("pa_consultaTipo", con.conectarBD());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable cliente = new DataTable(); //grid armazenado virtualmente
            da.Fill(cliente);

            con.desconectarBD();
            return cliente;
        }

        public DataTable buscaTipo(tipoAnimalDTO dto)
        {
            SqlCommand cmd = new SqlCommand("pa_pesquisaTipo", con.conectarBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@cod", SqlDbType.VarChar).Value = dto.codTipo;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tipo = new DataTable();
            da.Fill(tipo);
            con.desconectarBD();
            return tipo;
        }


    }
}