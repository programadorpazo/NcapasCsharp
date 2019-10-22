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
using Entidades;


namespace Presentacion
{
    public partial class FrmProductosDatos : Form
    {
        public FrmProductosDatos()
        {
            InitializeComponent();
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            EProducto miproducto = new EProducto();
            string nombre = "";
            decimal precio = 0;
            int stock = 0;

            nombre = txtNombreProd.Text.Trim();
            precio = nudPrecio.Value;
            stock = int.Parse(nudStock.Value.ToString());

            //validacion de datos 



            //asignacion de datos a la entidad ya validados
            miproducto.Nombre = nombre;
            miproducto.Precio = precio;
            miproducto.Stock = stock;

            LProducto lProducto = new LProducto();
            bool respuesta = lProducto.Insertar(miproducto);

            if (respuesta)
            {
                MessageBox.Show("Los Datos han sido registrados correctamente","Mensaje");
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
