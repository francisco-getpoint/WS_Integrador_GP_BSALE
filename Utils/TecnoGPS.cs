using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_Integrador_GP_BSALE.Utils
{
    public class Position
    {
        public int id { get; set; }
        public string vehicle { get; set; }
        public string date { get; set; }
        public string timezone { get; set; }
        public Posinfo posinfo { get; set; }
    }
    public class Posinfo
    {
        public string direction { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public int speed { get; set; }
        public decimal temperature { get; set; }
        public string humidity { get; set; }
    }
    public class NewPosition
    {
        private string Vehiculo;
        private string Fecha;
        private string Latitud;
        private string Longitud;
        private string Direccion;
        private int Velocidad;
        private decimal Temperatura;
        private string Humedad;

        public NewPosition(string Vehiculo, string Fecha, string Latitud, string Longitud, string Direccion, int Velocidad, decimal Temperatura, string Humedad)
        {
            this.Vehiculo = Vehiculo;
            this.Fecha = Fecha;
            this.Latitud = Latitud;
            this.Longitud = Longitud;
            this.Direccion = Direccion;
            this.Velocidad = Velocidad;
            this.Temperatura = Temperatura;
            this.Humedad = Humedad;
        }

    }
    }
