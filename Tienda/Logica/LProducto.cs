using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Logica
{
    public class LProducto
    {
        public List<EProducto> ObtenerListado()
        {
            DProducto dProducto = new DProducto();
            return dProducto.ObtenerListado();
        }

        public bool Insertar(EProducto producto)
        {
            DProducto dProducto = new DProducto();
            return dProducto.Insertar(producto);
        }
    }
}
