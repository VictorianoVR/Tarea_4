using Microsoft.Data.SqlClient;
using System.Reflection;

namespace Tarea_4
{
    public static class Datos
    {
        public static UsuarioModel LoginUser(string usuario, string clave)
        {
            string query = $"select * from dbo.Usuario where Nombre_Usuario = '{usuario}' and Clave = '{clave}'";

            UsuarioModel model = null;
            try
            {
                using SqlConnection con = new("data source=MC\\HOME;initial catalog=Tarea_4;persist security info=True;user id=sa;password=123456;MultipleActiveResultSets=True;TrustServerCertificate=True");
                SqlCommand cmd = new(query, con);

                con.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    model = reader.GetModel<UsuarioModel>();
                }
                con.Close();
            }
            catch (Exception e)
            {
            }
            return model;
        }

        public static UsuarioModel ValidateUser(string usuario)
        {
            string query = $"select * from dbo.Usuario where Nombre_Usuario = '{usuario}'";

            UsuarioModel model = null;
            try
            {
                using SqlConnection con = new("data source=MC\\HOME;initial catalog=Tarea_4;persist security info=True;user id=sa;password=123456;MultipleActiveResultSets=True;TrustServerCertificate=True");
                SqlCommand cmd = new(query, con);

                con.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    model = reader.GetModel<UsuarioModel>();
                }
                con.Close();

            }
            catch (Exception e)
            {
            }
            return model;
        }

        public static void Registrar(UsuarioModel model)
        {
            string query = $"insert into dbo.Usuario values(@Nombre_Usuario, @Nombre, @Apellido, @Telefono, @Correo, @Clave)";

            using SqlConnection con = new("data source=MC\\HOME;initial catalog=Tarea_4;persist security info=True;user id=sa;password=123456;MultipleActiveResultSets=True;TrustServerCertificate=True");
            SqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@Nombre_Usuario", model.Nombre_Usuario);
            cmd.Parameters.AddWithValue("@Nombre", model.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", model.Apellido);
            cmd.Parameters.AddWithValue("@Telefono", model.Telefono);
            cmd.Parameters.AddWithValue("@Correo", model.Correo);
            cmd.Parameters.AddWithValue("@Clave", model.Clave);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static List<UsuarioModel> GetList()
        {
            var result = new List<UsuarioModel>();
            string query = $"select * from dbo.Usuario";

            UsuarioModel model = null;
            try
            {
                using SqlConnection con = new("data source=MC\\HOME;initial catalog=Tarea_4;persist security info=True;user id=sa;password=123456;MultipleActiveResultSets=True;TrustServerCertificate=True");
                SqlCommand cmd = new(query, con);

                con.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    model = reader.GetModel<UsuarioModel>();
                    result.Add(model);
                }
                con.Close();
            }
            catch (Exception e)
            {
            }
            return result;
        }

        public static void Eliminar(string usuario)
        {
            string query = $"delete dbo.Usuario where Nombre_Usuario = '{usuario}'";

            using SqlConnection con = new("data source=MC\\HOME;initial catalog=Tarea_4;persist security info=True;user id=sa;password=123456;MultipleActiveResultSets=True;TrustServerCertificate=True");
            SqlCommand cmd = new(query, con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static T GetModel<T>(this SqlDataReader reader) where T : class
        {
            T model = Activator.CreateInstance<T>();

            foreach (var item in typeof(T).GetProperties().Where(p => p.CanWrite && p.GetCustomAttributes(typeof(ColumnSqlAttribute), false).Any()))
            {
                var column = item.GetCustomAttributes(typeof(ColumnSqlAttribute), false).FirstOrDefault() as ColumnSqlAttribute;

                if (item.PropertyType == typeof(string))
                    item.SetValue(model, Convert.ToString(reader[column.NameColumn]));
                else if (item.PropertyType == typeof(DateTime))
                    item.SetValue(model, Convert.ToDateTime(reader[column.NameColumn] is DBNull ? DateTime.Now : reader[column.NameColumn]));
                else if (item.PropertyType == typeof(double))
                    item.SetValue(model, Convert.ToDouble(reader[column.NameColumn] is DBNull ? 0 : reader[column.NameColumn]));

                EvaluateDateTime<T>(item, reader, column, model);
            }

            return model;
        }

        private static void EvaluateDateTime<T>(PropertyInfo item, SqlDataReader reader, ColumnSqlAttribute column, T model)
        {
            if (item.PropertyType == typeof(DateTime?))
            {
                if (reader[column.NameColumn] is DBNull)
                {
                    //
                }
                else
                    item.SetValue(model, Convert.ToDateTime(reader[column.NameColumn]));
            }
        }
    }

    public class ColumnSqlAttribute : Attribute
    {
        public string NameColumn { get; set; }

        public ColumnSqlAttribute(string nameColumn)
        {
            NameColumn = nameColumn;
        }
    }
}