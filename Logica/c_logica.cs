using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class c_logica
    {
      
        public DateTime MtdFechaHoy()
        {
            return DateTime.Now;//.ToString("d");
        }



        #region = "tipo de vehiculo";
        public  int MtdCostoTipoVehiculo(int posicion)
        {
            int precio = 0;
            switch (posicion)
            {
                case 0:
                    precio = 100;
                    break;

                case 1:
                    precio = 150;
                    break;

                case 2:
                    precio = 200;
                    break;

                case 3:
                    precio = 300;
                    break;
                case 4:
                    precio = 500;
                    break;
                default:
                    precio = 0;
                    break;
            }
            return precio;
        }
        #endregion


        #region = "precio por dias";
        public  double MtdPrecioTotalDias(double dias, double precio)
        {
            return dias * precio;

        }
        #endregion

        #region = "Costo tipo plan"

        public  int MtdCostoTipoPlan(int posicion)
        {
            int precio = 0;
            switch (posicion)
            {
                case 0:
                    precio = 100;
                    break;

                case 1:
                    precio = 200;
                    break;

                case 2:
                    precio = 500;
                    break;

                case 3:
                    precio = 1000;
                    break;
                default:
                    precio = 0;
                    break;
            }
            return precio;
        }

        #endregion

        #region = "Total factura";

        public  double MtdTotalFacturar(double costodias, double costotipohabitacion)
        {
            return costodias + costotipohabitacion;
        }

        #endregion





    }
}
