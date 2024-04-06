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
using System.Windows.Shapes;

namespace Semana05
{
    /// <summary>
    /// Interaction logic for ListaCategoria.xaml
    /// </summary>
    public partial class ListaCategoria : Window
    {
        public ListaCategoria()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            BCategoria bCategoria = null;

            try
            {
                //listar todas las categorias
                bCategoria = new BCategoria();
                dgvCategoria.ItemsSource = bCategoria.Listar(0);
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

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            //se coloca 0 pq es nuevo
            ManCategoria manCategoria = new ManCategoria(0);
            manCategoria.ShowDialog();
            Cargar();
        }

        private void dgvCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idCategoria = 0;
            var item = (Categoria)dgvCategoria.SelectedItem;
            if (null == item) return;
            idCategoria = Convert.ToInt32(item.IdCategoria);

            ManCategoria manCategoria = new ManCategoria(idCategoria);
            manCategoria.ShowDialog();
            Cargar();

        }
    }
}

