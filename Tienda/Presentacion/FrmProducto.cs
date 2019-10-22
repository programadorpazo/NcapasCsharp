using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;

namespace Presentacion
{
    public partial class FrmProducto : Form
    {
        public FrmProducto()
        {
            InitializeComponent();
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            LProducto lProducto = new LProducto();
            gvListadoProductos.DataSource = lProducto.ObtenerListado();
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            FrmProductosDatos frmProductosDatos = new FrmProductosDatos();
            if (frmProductosDatos.ShowDialog() == DialogResult.OK)
            {
                //ingresa al if cuendo recibimos una respuesta positiva
                LProducto lProducto = new LProducto();
                gvListadoProductos.DataSource = lProducto.ObtenerListado();
            } 
        }
    }
}
