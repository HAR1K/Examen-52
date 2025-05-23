using Eximena.Data.Context;
using Eximena.Data.Models;
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

namespace Eximena.Windows.Interfase
{
    /// <summary>
    /// Логика взаимодействия для Operator.xaml
    /// </summary>
    public partial class Operator : Window
    {
        public Operator()
        {
            InitializeComponent();
            using (Context db = new Context())
            {
                cmbxPersonnel.ItemsSource = db.Personnels.ToList();
                cmbxPersonnel.DisplayMemberPath = "FirstName";
                cmbxPersonnel.SelectedValuePath = "PersonnelId";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (Context db = new Context())
            {
                db.Orders.Add(new Order
                    {
                        NameOrder = name.Text,
                        Master = master.Text,
                        Status = status.Text,
                        PersonnelId = cmbxPersonnel.SelectedIndex + 1
                    }
                );
                db.SaveChanges();
                MessageBox.Show("Заказ добавлен!");
            }
        }
    }
}
