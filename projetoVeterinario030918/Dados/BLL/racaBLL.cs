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
    public class racaBLL
    {

        conexao con = new conexao();

        public void inserirRaca(racaDTO dto)
        {

            SqlCommand cmd = new SqlCommand("pa_inserirRaca", con.conectarBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@cod", SqlDbType.VarChar).Value = dto.codRaca;
            cmd.Parameters.Add("@raca", SqlDbType.VarChar).Value = dto.raca;

            cmd.ExecuteNonQuery();
            con.desconectarBD();
        }

        public DataTable consultaRaca()
        {
            SqlCommand cmd = new SqlCommand("pa_consultaRaca", con.conectarBD());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable cliente = new DataTable(); //grid armazenado virtualmente
            da.Fill(cliente);

            con.desconectarBD();
            return cliente;
        }

        public DataTable buscaRaca(racaDTO dto)
        {
            SqlCommand cmd = new SqlCommand("pa_pesquisaRaca", con.conectarBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@raca", SqlDbType.VarChar).Value = dto.raca;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable raca = new DataTable();
            da.Fill(raca);
            con.desconectarBD();
            return raca;
        }
    }
}