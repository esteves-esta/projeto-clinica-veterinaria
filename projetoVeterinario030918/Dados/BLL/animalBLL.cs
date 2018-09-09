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
    public class animalBLL
    {

        conexao con = new conexao();

        public void inserirAnimal(animalDTO dto)
        {

            SqlCommand cmd = new SqlCommand("pa_inserirAnimal", con.conectarBD());
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@coda", SqlDbType.VarChar).Value = dto.codAnimal;
            cmd.Parameters.Add("@nomepet", SqlDbType.VarChar).Value = dto.nomeAnimal;
            cmd.Parameters.Add("@codtipo", SqlDbType.VarChar).Value = dto.codTipo;
            cmd.Parameters.Add("@codraca", SqlDbType.VarChar).Value = dto.codRaca;
            cmd.Parameters.Add("@codresp", SqlDbType.VarChar).Value = dto.codResp;
            cmd.Parameters.Add("@data", SqlDbType.VarChar).Value = dto.dataCadastro;

            cmd.ExecuteNonQuery();
            con.desconectarBD();
        }

        public DataTable consultaAnimal()
        {
            SqlCommand cmd = new SqlCommand("pa_consultaAnimal", con.conectarBD());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable cliente = new DataTable(); //grid armazenado virtualmente
            da.Fill(cliente);

            con.desconectarBD();
            return cliente;
        }

        public DataTable buscaAnimal(animalDTO dto)
        {
            SqlCommand cmd = new SqlCommand("pa_pesquisaAnimal", con.conectarBD());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@nomea", SqlDbType.VarChar).Value = dto.nomeAnimal;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable animal = new DataTable();
            da.Fill(animal);
            con.desconectarBD();
            return animal;
        }
    }
}