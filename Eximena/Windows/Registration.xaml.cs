using Eximena.Data.Context;
using Eximena.Data.Models;
using System.Windows;

namespace Eximena.Windows
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
            using (Context db = new Context())
            {
                if (!db.Roles.Any())
                {
                    db.Roles.AddRange(
                    new Role { NameRole = "Админ" },
                    new Role { NameRole = "Техник" },
                    new Role { NameRole = "Оператор" } 
                    );
                    db.SaveChanges();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (Context db = new Context())
            {
                db.Users.Add(new User { FirstName = firstname.Text, Password = password.Text});
                db.SaveChanges();
                MessageBox.Show("Пресонаж добавлен!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new RegistrationPersonnel().Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new LoginUser().Show();
        }
    }
}
