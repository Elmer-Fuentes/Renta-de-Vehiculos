using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class cd_vehiculos
    {
        #region= "Paso1 comunicaciòn con vista hoteles"
        //todos los form empiezan con este paso despues de la conexión. Ok, super.
        public DataTable MtdConsultarHotel()
        {
            Conexion cd_conexionDB = new Conexion(); //instancia de la clases Conexion
            string QuerySelect = "SELECT * FROM vehiculos";//almacenar en queryselect = la consulta de sql
            SqlDataAdapter adapter = new SqlDataAdapter(QuerySelect, cd_conexionDB.MtdAbrirConexion());//intermediario entre la base de datos y aplicación
            //llenar los datos resultantes en una estructura en memoria, como un DataTable
            DataTable dt_hotel = new DataTable();//estructura en memoria contiene el query
            adapter.Fill(dt_hotel);//ejecuta la consulta SQL definida en el SqlDataAdapter y llena el DataTable (dt_clientes) con los datos obtenidos de la base de datos. 
            cd_conexionDB.MtdCerrarConexion();//cierra la conexión
            return dt_hotel; //devuelve el dataTable.
        }
        #endregion
    

    #region = "Agregar data a Hotel"
    public void MtdAgregarData_vehiculos(int dias, string tipo_vehiculo, string tipo_plan, double precio_dia, double precio_total_dia, double costo_tipo_plan, double total_factura, DateTime Fecha_factura, Boolean estado_codigo)
    {
        Conexion cd_conexionDB = new Conexion(); //instancia de la clases Conexion
        string query = "insert into vehiculos (dias,tipo_vehiculo,tipo_plan,costo_dia,costo_total_dia,costo_tipo_plan,total_a_pagar,fecha) values(@dias,@tipo_vehiculo,@tipo_plan,@costo_dia,@costo_total_dia,@costo_tipo_plan,@total_a_pagar,@fecha)";
        SqlCommand cmd = new SqlCommand(query, cd_conexionDB.MtdAbrirConexion());
        cmd.Parameters.AddWithValue("@dias", dias);
        cmd.Parameters.AddWithValue("@tipo_vehiculo", tipo_vehiculo);
        cmd.Parameters.AddWithValue("@tipo_plan", tipo_plan);
        cmd.Parameters.AddWithValue("@costo_dia", precio_dia);
        cmd.Parameters.AddWithValue("@costo_total_dia", precio_total_dia);
        cmd.Parameters.AddWithValue("@costo_tipo_plan", costo_tipo_plan);
        cmd.Parameters.AddWithValue("@total_a_pagar", total_factura);
        cmd.Parameters.AddWithValue("@fecha", Fecha_factura);
     //   cmd.Parameters.AddWithValue("@estado_codigo", estado_codigo);
        cmd.ExecuteNonQuery();
        cd_conexionDB.MtdCerrarConexion();
    }
        #endregion

        #region = "editar data a vehiculos"
        public void MtdEditarData_vehiculos(int codigo, int dias, string tipo_vehiculo, string tipo_plan, double precio_dia, double precio_total_dia, double costo_tipo_plan, double total_factura, DateTime Fecha_factura, Boolean estado_codigo)
        {
            Conexion cd_conexionDB = new Conexion(); //instancia de la clases Conexion
            string query = "UPDATE vehiculos SET dias = @dias,tipo_vehiculo = @tipo_vehiculo ,tipo_plan = @tipo_plan,costo_dia = @costo_dia,costo_total_dia = @costo_total_dia,costo_tipo_plan = @costo_tipo_plan,total_a_pagar = @total_a_pagar,fecha = @fecha where codigo = @codigo \r\n";
            SqlCommand cmd = new SqlCommand(query, cd_conexionDB.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@codigo", codigo);
            cmd.Parameters.AddWithValue("@dias", dias);
            cmd.Parameters.AddWithValue("@tipo_vehiculo", tipo_vehiculo);
            cmd.Parameters.AddWithValue("@tipo_plan", tipo_plan);
            cmd.Parameters.AddWithValue("@costo_dia", precio_dia);
            cmd.Parameters.AddWithValue("@costo_total_dia", precio_total_dia);
            cmd.Parameters.AddWithValue("@costo_tipo_plan", costo_tipo_plan);
            cmd.Parameters.AddWithValue("@total_a_pagar", total_factura);
            cmd.Parameters.AddWithValue("@fecha", Fecha_factura);
            //   cmd.Parameters.AddWithValue("@estado_codigo", estado_codigo);
            cmd.ExecuteNonQuery();
            cd_conexionDB.MtdCerrarConexion();
        }
        #endregion


        #region = "editar data a vehiculos"
        public void MtdEliminarData_vehiculos(int codigo)
        {
            Conexion cd_conexionDB = new Conexion(); //instancia de la clases Conexion
            string query = "delete from vehiculos where codigo = @codigo";
            SqlCommand cmd = new SqlCommand(query, cd_conexionDB.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@codigo", codigo);
            ////   cmd.Parameters.AddWithValue("@estado_codigo", estado_codigo);
            cmd.ExecuteNonQuery();
            cd_conexionDB.MtdCerrarConexion();
        }
        #endregion







    }
}