using ApiTarefasNet80.Database;
using MySql.Data.MySqlClient;

namespace ApiTarefasNet80.Models
{
    public class CategoriaDAO
    {
        private static ConnectionMysql _conn;

        public CategoriaDAO()
        {
            _conn = new ConnectionMysql();
        }

        public int Insert(Categoria item)
        {
            try
            {
                var query = _conn.Query();
              

                query.Parameters.AddWithValue("@nome", item.Nome);
             


                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi inserido. Verifique e tente novamente");
                }

                return (int)query.LastInsertedId;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }

        public List<Categoria> List()
        {
            try
            {
                List<Categoria> list = new List<Categoria>();
                // List<Tarefa> list = [];

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM Categoria";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Categoria()
                    {
                        Id = reader.GetInt32("id_Categoria"),
                        Nome = reader.GetString("Nome_Categoria"),
                       
                    });
                }

                return list;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }

        public Categoria? GetById(int id)
        {
            try
            {
                Categoria _categoria = new Categoria();
                // Tarefa _tarefa = new();

                var query = _conn.Query();
                query.CommandText = "SELECT * FROM tarefas WHERE id_tarefa = @_id";

                query.Parameters.AddWithValue("@_id", id);

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    _categoria.Id = reader.GetInt32("id_Categoria");
                    _categoria.Nome = reader.GetString("nome_Categoria");
                
                }

                return _categoria;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }

        public void Update(Categoria item)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "UPDATE categoria SET nome_categoria = @_nome,  WHERE id_categoria = @_id";

                query.Parameters.AddWithValue("@_nome", item.Nome);
        
                query.Parameters.AddWithValue("@_id", item.Id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi atualizado. Verifique e tente novamente");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }

        public void Delete(int id)
        {
            try
            {
                var query = _conn.Query();
                query.CommandText = "DELETE FROM categoria WHERE id_categoria = @_id";

                query.Parameters.AddWithValue("@_id", id);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O registro não foi excluído. Verifique e tente novamente");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
