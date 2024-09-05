using Login.ado;
using Login.classe;
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

namespace Login.view
{

    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
            // FAIRE APPRAITRE LA FENETRE AU CENTRE DE LA PAGE //
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }


        // ACTION AU CLIQUE DU BUTTON LOGIN
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            // RECUPERER LES VALEURS DANS LES TEXTBOX
            string emailInput = txtEmail.Text;
            string passwordInput = txtPassword.Password;

            // UTILISATION DE LA METHODE POUR RECUPERER LES INFO SUR LES USERS
            Users u = UserAdo.GetUserEmailAndPassword(emailInput, passwordInput);

            if (u != null)
            {
                // LES INFO CORRECT, OUVRE LA PAGE DASHBOARD
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Close();
            }
            else
            {
                // AFFICHE LES ERREURS DE SAISIE
                txtErrorMessage.Text = "Invalid email or password.";

            }
        }


        //   OUVRE LA PAGE SIGN UP
        private void SignUpPage_Click(object sender, RoutedEventArgs e)
        {
            SignUpPage signUpPage = new SignUpPage();
            signUpPage.Show();
            this.Close();
        }
    }
}
