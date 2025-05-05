using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Logica;

namespace Presentación
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        c_logica objlogica = new c_logica();
        cd_vehiculos objvehiculos = new cd_vehiculos();

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fechas();
            TipoVehiculo();
            MtdPrecioTotalDias(); MtdTotalFacturar();
            MostrarDataVehiculos();
        }
        #region = "metodofecha";
        public void  fechas()
        {
            lbl_fecha.Text = objlogica.MtdFechaHoy().ToString();
        }
        #endregion

        #region = "tipo de vehiculo precios";
        public void TipoVehiculo()
        {
            int posicion = cbx_tipo_vehiculo.SelectedIndex;
            lbl_precio_dia.Text = objlogica.MtdCostoTipoVehiculo(posicion).ToString();

        }


        #endregion

        private void cbx_tipo_vehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoVehiculo();
            MtdPrecioTotalDias();
            MtdTotalFacturar();
        }

        #region ="Precio total por dias";
        public void MtdPrecioTotalDias()
        {
            int posicion = cbx_tipo_vehiculo.SelectedIndex;
            double precio = objlogica.MtdCostoTipoVehiculo(posicion);
            // Validación correcta del texto ingresado
            if (string.IsNullOrWhiteSpace(txt_dias.Text))
            {
                txt_dias.Text = ""; // Si está vacío o contiene solo espacios
            }
            else
            {
                double diashospedaje = double.Parse(txt_dias.Text);
                lbl_precio_total_dias.Text = objlogica.MtdPrecioTotalDias(diashospedaje, precio).ToString();

            }
        }
        #endregion


        #region = "Tipo de plan";
        public void CostoTipoPlan()
        {
            int posicion = cbx_tipo_plan.SelectedIndex;
            if (cbx_tipo_plan != null)
            {
                lbl_costoTipo_plan.Text = objlogica.MtdCostoTipoPlan(posicion).ToString();
            }
            else
            {
                cbx_tipo_plan.Text = "0";
            }
        }


        #endregion

        private void cbx_tipo_plan_SelectedIndexChanged(object sender, EventArgs e)
        {
            CostoTipoPlan();
            MtdTotalFacturar();
        }

        #region = "total monto factura";

        public void MtdTotalFacturar()
        {
            double precioTotalDias, costoTipoHabitacion;

            // convertir ambos valores de los labels
            bool esPrecioValido = double.TryParse(lbl_precio_total_dias.Text, out precioTotalDias);
            bool esCostoValido = double.TryParse(lbl_costoTipo_plan.Text, out costoTipoHabitacion);

            // valores válidos, procedemos
            if (esPrecioValido && esCostoValido)
            {
                double resultado = objlogica.MtdTotalFacturar(precioTotalDias, costoTipoHabitacion);
                lbl_total_apagar.Text = resultado.ToString();
            }
            else
            {
                // Si alguno es inválido, mostramos 0
                lbl_total_apagar.Text = "0";
            }
        }

        #endregion



        public void MostrarDataVehiculos() //cargar en load para que muestre la información
        {
            dgvDatosvehiculos.DataSource = objvehiculos.MtdConsultarHotel();
        }
        #region = "retonar los datos de dtv los cbox, txt y label desde el evento CELLCLICK"

       
        private void dgvDatosvehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          

                txt_codigoRenta.Text = dgvDatosvehiculos.SelectedCells[0].Value.ToString();
                txt_dias.Text = dgvDatosvehiculos.SelectedCells[1].Value.ToString();
                cbx_tipo_vehiculo.Text = dgvDatosvehiculos.SelectedCells[2].Value.ToString();
                cbx_tipo_plan.Text = dgvDatosvehiculos.SelectedCells[3].Value.ToString();
                lbl_precio_dia.Text = dgvDatosvehiculos.SelectedCells[4].Value.ToString();
                lbl_precio_total_dias.Text = dgvDatosvehiculos.SelectedCells[5].Value.ToString();
                lbl_costoTipo_plan.Text = dgvDatosvehiculos.SelectedCells[6].Value.ToString();
                lbl_total_apagar.Text = dgvDatosvehiculos.SelectedCells[7].Value.ToString();
        }

        #endregion
        #region = "boton guardar";
        private void btnGuardar_Click(object sender, EventArgs e)
        {

            // Validación correcta del texto ingresado
            if (string.IsNullOrWhiteSpace(txt_dias.Text))
            {
                txt_dias.Text = ""; // Si está vacío o contiene solo espacios
                MessageBox.Show("Ingrese el número de días porfavor no se permiten datos null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int dias_hospedaje = int.Parse(txt_dias.Text);
                string tamano_habitacion = cbx_tipo_vehiculo.Text;
                string tipo_habitacion = cbx_tipo_plan.Text;
                double precio_dia = double.Parse(lbl_precio_dia.Text);
                double precio_total_dia = double.Parse(lbl_precio_total_dias.Text);
                double costo_tipo_habitacion = double.Parse(lbl_costoTipo_plan.Text);
                double total_factura = double.Parse(lbl_total_apagar.Text);
                DateTime Fecha_factura = objlogica.MtdFechaHoy();
                Boolean estado_codigo = true;

                try
                {
                    objvehiculos.MtdAgregarData_vehiculos(dias_hospedaje, tamano_habitacion, tipo_habitacion, precio_dia, precio_total_dia, costo_tipo_habitacion, total_factura, Fecha_factura, estado_codigo);
                    MessageBox.Show("Registro guardado correctamente", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarDataVehiculos();
                    //LimpiarCancelar();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
        #endregion

        private void btnEditar_Click(object sender, EventArgs e)
        {


            // Validación correcta del texto ingresado
            if (string.IsNullOrWhiteSpace(txt_dias.Text))
            {
                txt_dias.Text = ""; // Si está vacío o contiene solo espacios
                MessageBox.Show("Ingrese el número de días porfavor no se permiten datos null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int codigo = int.Parse(txt_codigoRenta.Text);
                int dias_hospedaje = int.Parse(txt_dias.Text);
                string tamano_habitacion = cbx_tipo_vehiculo.Text;
                string tipo_habitacion = cbx_tipo_plan.Text;
                double precio_dia = double.Parse(lbl_precio_dia.Text);
                double precio_total_dia = double.Parse(lbl_precio_total_dias.Text);
                double costo_tipo_habitacion = double.Parse(lbl_costoTipo_plan.Text);
                double total_factura = double.Parse(lbl_total_apagar.Text);
                DateTime Fecha_factura = objlogica.MtdFechaHoy();
                Boolean estado_codigo = true;

                try
                {
                    objvehiculos.MtdEditarData_vehiculos(codigo,dias_hospedaje, tamano_habitacion, tipo_habitacion, precio_dia, precio_total_dia, costo_tipo_habitacion, total_factura, Fecha_factura, estado_codigo);
                    MessageBox.Show("Registro ACTUALIZADO correctamente", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarDataVehiculos();
                    //LimpiarCancelar();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int codigo_reservacion = int.Parse(txt_codigoRenta.Text);
            
            try
            {
                objvehiculos.MtdEliminarData_vehiculos(codigo_reservacion);
                MessageBox.Show("Registro Eliminado correctamente", "Status Eliminado (Desactivado 👍)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarDataVehiculos();
                //LimpiarCancelar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}



