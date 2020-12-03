using APIPETS.Domains;
using APIPETS.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using APIPETS.Context;

namespace APIPETS.Repositories
{

    public class TipoPetsRepository : ITipoPets
    {

        TipoPetsContext conexao = new TipoPetsContext();

        SqlCommand cmd = new SqlCommand();
        public TipoPets Alterar(int id ,TipoPets t)
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "UPDATE TipoPets SET " +
                "Descrição = @descrição WHERE IdTipoPet = @id";
            cmd.Parameters.AddWithValue("@descrição", t.Descrição);

            cmd.Parameters.AddWithValue("@id", id);

            //Executando uma "não consulta" por se tratar de um cadastro
            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return t;
        }

        public TipoPets BuscarPorID(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM TipoPets WHERE IdTipoPet    = @id ";
            //Fazendo a junção das variáveis para identificação
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            TipoPets tipo = new TipoPets();
            while (dados.Read())
            {
                tipo.IdTipoPet = Convert.ToInt32(dados.GetValue(0));
                tipo.Descrição = dados.GetValue(1).ToString();
            }
            return tipo;
        }

        public TipoPets Cadastrar(TipoPets t)
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "INSERT INTO TipoPets (Descrição) " +
                "VALUES" +
                "(@Descrição)";
            cmd.Parameters.AddWithValue("@Descrição", t.Descrição);

            //Executando uma "não consulta" por se tratar de um cadastro
            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return t;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();
            cmd.CommandText = "DELETE FROM TipoPets WHERE IdTipoPet = @id ";

            cmd.Parameters.AddWithValue("@id", id);

            //Executando uma "não consulta" por se tratar de um cadastro
            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }

        public List<TipoPets> LerTodos()
        {
            //Abrir conexão
            cmd.Connection = conexao.Conectar();

            //Estruturar Consulta
            cmd.CommandText = "SELECT * FROM TipoPets";
            SqlDataReader dados = cmd.ExecuteReader();

            List<TipoPets> tipos = new List<TipoPets>();
            while (dados.Read())
            {
                tipos.Add(
                    new TipoPets()
                    {
                        IdTipoPet = Convert.ToInt32(dados.GetValue(0)),
                        Descrição = dados.GetValue(1).ToString()
                    });
            }

            conexao.Desconectar();
            return tipos;
        }
    }
}

