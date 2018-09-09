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
    public class responsavelBLL
    {

        conexao con = new conexao();

        public void inserirResp(responsavelDTO dto)
        {

            // SqlCommand cmd = new SqlCommand("insert into tbResponsavel values(@cod,@nome,@end,@bairro, @cid,@uf)", con.conectarBD());

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.conectarBD();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "pa_inserirResponsavel";

            cmd.Parameters.Add("@cod", SqlDbType.VarChar).Value = dto.codResp;
            cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = dto.nome;
            cmd.Parameters.Add("@end", SqlDbType.VarChar).Value = dto.end;
            cmd.Parameters.Add("@bairro", SqlDbType.VarChar).Value = dto.bairro;
            cmd.Parameters.Add("@cid", SqlDbType.VarChar).Value = dto.cidade;
            cmd.Parameters.Add("@uf", SqlDbType.VarChar).Value = dto.uf;

            cmd.ExecuteNonQuery();
            con.desconectarBD();
        }

        public DataTable consultaResp()
        {
            SqlCommand cmd = new SqlCommand("pa_consultaResponsavel", con.conectarBD());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable cliente = new DataTable(); //grid armazenado virtualmente
            da.Fill(cliente);

            con.desconectarBD();
            return cliente;
        }

        public DataTable buscaResp(responsavelDTO dto)
        {
            SqlCommand cmd = new SqlCommand("pa_pesquisaResponsavel", con.conectarBD());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = dto.nome;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable resp = new DataTable();
            da.Fill(resp);
            con.desconectarBD();
            return resp;
        }

    }
}