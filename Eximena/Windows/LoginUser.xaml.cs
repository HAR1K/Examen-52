using Eximena.Data.Context;
using Eximena.Windows.Interfase;
using System.Windows;

namespace Eximena.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginUser.xaml
    /// </summary>
    public partial class LoginUser : Window
    {
        public LoginUser()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (Context db = new Context())
            {
                var user = db.Users.FirstOrDefault(x => x.FirstName == firstname.Text && x.Password == password.Text);
                var personnel = db.Personnels.FirstOrDefault(x => x.UserId == user.UserId);
                if (user != null)
                {
                    MessageBox.Show("Вы вошли в аккаунт!");
                    if (personnel != null)
                    {
                        if (personnel.RoleName == "Админ")
                        {
                            new Admin().Show();
                        }
                        if (personnel.RoleName == "Техник")
                        {
                            new Technik().Show();
                        }
                        if (personnel.RoleName == "Оператор")
                        {
                            new Operator().Show(); 
                        }
                    }
                }
            }
        }
    }
}
