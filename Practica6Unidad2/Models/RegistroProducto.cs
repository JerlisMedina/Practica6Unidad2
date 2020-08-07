using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace Practica6Unidad2.Models
{
    public class RegistroProducto
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader dr;

        private void Conectar() {
            string cn = ConfigurationManager.ConnectionStrings["ConexionDB"].ToString();
            con = new SqlConnection(cn);
        }

        // Grabar registro en la base de datos
        public int GrabarProducto(Producto prod) {
            Conectar();
            cmd = new SqlCommand($"INSERT INTO Productos(Descripcion,Tipo,Precio) " +
                $"VALUES('{prod.Descripcion}','{prod.Tipo}','{prod.Precio}')",con);
            con.Open();

            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i;
        }

        // Mostrar todos los registros
        public List<Producto> MostrarTodos() {
            List<Producto> listProd = new List<Producto>();
            Conectar();

            cmd = new SqlCommand("SELECT Id, Descripcion, Tipo, Precio FROM Productos",con);
            con.Open();

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Producto pro = new Producto
                {
                    Id = int.Parse(dr["Id"].ToString()),
                    Descripcion = dr["Descripcion"].ToString(),
                    Tipo = dr["Tipo"].ToString(),
                    Precio = double.Parse(dr["Precio"].ToString())
                };
                listProd.Add(pro);
            }
            con.Close();

            return listProd;
        }

        // Recuperar un registro en especifico
        public Producto MostrarEspecifico(int codigo) {
            Producto prod = new Producto();
            Conectar();
            cmd = new SqlCommand($"SELECT Id, Descripcion, Tipo, Precio FROM Productos WHERE Id = '{codigo}'",con);
            con.Open();

            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                prod.Id = int.Parse(dr["Id"].ToString());
                prod.Descripcion = dr["Descripcion"].ToString();
                prod.Tipo = dr["Tipo"].ToString();
                prod.Precio = double.Parse(dr["Precio"].ToString());
            }
            con.Close();

            return prod;
        }

        // Modificar un registro especifico
        public int Modificar(Producto prod) {

            Conectar();
            cmd = new SqlCommand($"UPDATE Productos SET Descripcion='{prod.Descripcion}'," +
                                 $"Tipo='{prod.Tipo}',Precio='{prod.Precio}'" +
                                 $"WHERE Id='{prod.Id}'",con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i;
        }

        // Borrar un registro
        public int Borrar(int codigo) {

            Conectar();
            cmd = new SqlCommand($"DELETE FROM Productos WHERE Id='{codigo}'",con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i;
        }
    }
}