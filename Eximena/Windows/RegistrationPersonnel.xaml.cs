using Eximena.Data.Context;
using Eximena.Data.Models;
using System.Windows;

namespace Eximena.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPersonnel.xaml
    /// </summary>
    public partial class RegistrationPersonnel : Window
    {
        public RegistrationPersonnel()
        {
            InitializeComponent();
            using (Context db = new Context())
            {
                cmbxRole.ItemsSource = db.Roles.ToList();
                cmbxRole.DisplayMemberPath = "NameRole";
                cmbxRole.SelectedValuePath = "RoleId";
                cmbxUser.ItemsSource = db.Users.ToList();
                cmbxUser.DisplayMemberPath = "FirstName";
                cmbxUser.SelectedValuePath = "UserId";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (Context db = new Context())
            {
                db.Personnels.Add(
                    new Personnel 
                    { 
                        FirstName = cmbxUser.Text,
                        RoleName = cmbxRole.Text,
                        RoleId = cmbxRole.SelectedIndex + 1,
                        UserId = cmbxUser.SelectedIndex + 1
                    }
                );
                db.SaveChanges();
                MessageBox.Show("Пресонаж добавлен!");
            }
        }
    }
}
