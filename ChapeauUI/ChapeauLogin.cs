using Model;
using Service;

namespace ChapeauUI
{
    public partial class ChapeauLogin : Form
    {
        public ChapeauLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;

            if (IsValidated(username, password))
            {
                AuthService authService = new AuthService();
                bool usernameExists = authService.CheckUsernameExists(username);

                if (usernameExists)
                {
                    password = authService.GetHashPassword(password);
                    bool isAuthenticated = authService.Authenticate(username, password);
                    if (isAuthenticated)
                    {
                        authService.GetEmployeeByUsername(username);
                        GotoNextView();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect password. Please try again.");
                    }
                }
                else
                {
                    MessageBox.Show("Username does not exist. Please try again.");
                }
            }
        }

        private void GotoNextView()
        {
            this.Hide();
            Form home;
            UserType userType = Employee.GetInstance().UserType;
            home = (userType == UserType.Waiter) ? new WaiterView() : new KitchenView();
            home.Closed += (s, args) => this.Close();
            home.Show();
        }

        private bool IsValidated(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ChapeauLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
