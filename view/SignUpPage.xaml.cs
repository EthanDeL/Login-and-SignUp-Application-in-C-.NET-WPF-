using Login.ado;
using Login.classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Login.view
{
    public partial class SignUpPage : Window
    {
        public SignUpPage()
        {
            InitializeComponent();

            // FAIRE APPRAITRE LA FENETRE AU CENTRE DE LA PAGE //
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }


        // CREER LE COMPTE DE L'UTILISATEUR 
        public void BtnSignup_Click(object sender, RoutedEventArgs e)
        {
            if (EmptyInput() != null)
            {
                // VERIFIE SI EMAIL EST UNIQUE
                string Email = txtEmail.Text;

                // VERIFIE QUE L'ADRESSE EMAIL RESSEMBLE A UNE ADRESSE EMAIL
                if (!IsValidEmail(Email))
                {
                    txtErrorMessage.Text = "Please enter a valid email address";
                    return;
                }

                // CREER L'UTILISATEUR
                if (UserAdo.EmailUnique(Email))
                {
                    Users u = new Users();
                    u.FirstName = txtFirstName.Text;
                    u.LastName = txtLastName.Text;
                    u.Email = txtEmail.Text;
                    u.Password = txtPassword.Password;

                    UserAdo.AjouterUser(u);

                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtEmail.Text = "";
                    txtPassword.Password = "";

                    // APRES AVOIR CREER LE COMPTE, ENVOYER L'UTILISATEUR VERS LE DASHBOARD
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                    this.Close();
                }
                else
                {
                    txtErrorMessage.Text = "This e-mail address already exists, please log in";
                }
            }
            else
            {
                txtErrorMessage.Text = "Please complete all fields";
            }
        }


        // OUVRE LA PAGE LOGIN
        private void LoginPage_Click(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Close();
        }


        // VERIFIIE SI TOUT LES CHAMPS SONT REMPLIENT
        private bool EmptyInput()
        {
            return !string.IsNullOrEmpty(txtFirstName.Text) && !string.IsNullOrEmpty(txtLastName.Text) && !string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtPassword.Password);
        }


        // VERIFIE QUE L'ADRESSE EMAIL RESSEMBLE A UNE ADRESSE EMAIL
        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

    }
}
