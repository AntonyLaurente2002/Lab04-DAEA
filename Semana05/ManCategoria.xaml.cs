using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Semana05
{
    /// <summary>
    /// Interaction logic for ManCategoria.xaml
    /// </summary>
    public partial class ManCategoria : Window
    {
        public int ID { get; set; }

        public ManCategoria(int Id)
        {
            InitializeComponent();
            ID = Id;

            if (ID > 0)
            {
                BCategoria bCategoria = new BCategoria();
                List<Categoria> categorias = new List<Categoria>();
                categorias = bCategoria.Listar(ID);

                if (categorias.Count > 0)
                {
                    lblID.Content = categorias[0].IdCategoria.ToString();
                    txtNombre.Text = categorias[0].NombreCategoria;
                    txtDescripcion.Text = categorias[0].Descripcion;
                }
            }
        }

        private void btnGrabar_Click(object sender, RoutedEventArgs e)
        {
            BCategoria bCategoria = null;
            bool result = true;

            try
            {
                //listar todas las categorias
                bCategoria = new BCategoria();

                if (ID > 0)
                {
                    result = bCategoria.Actualizar(new Categoria
                    {
                        IdCategoria = ID,
                        NombreCategoria = txtNombre.Text,
                        Descripcion = txtDescripcion.Text
                    });
                }
                else
                {
                    result = bCategoria.Insertar(new Categoria
                    {
                        NombreCategoria = txtNombre.Text,
                        Descripcion = txtDescripcion.Text
                    });
                }

                if (!result)
                {
                    MessageBox.Show("Comunicarse con el Administrador");
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Comunicarse con el Administrador -> {ex}");
            }
            finally
            {
                bCategoria = null;
            }
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

