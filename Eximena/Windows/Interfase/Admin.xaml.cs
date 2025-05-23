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
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
            using (Context db = new Context())
            {
                list.ItemsSource = db.Orders.ToList();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is Order order)
            {
                using (Context db = new Context())
                {
                    var existingOrder = db.Orders.FirstOrDefault(x => x.OrderId == order.OrderId);
                    if (existingOrder != null)
                    {
                        existingOrder.Status = order.Status;
                        existingOrder.NameOrder = order.NameOrder;
                        existingOrder.Master = order.Master;
                        db.SaveChanges();
                        MessageBox.Show("Данные заказа обновлен!");
                    }
                    list.ItemsSource = db.Orders.ToList();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new AdminOperator().Show(); 
        }
    }
}
