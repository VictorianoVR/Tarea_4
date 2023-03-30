using System;
using System.Windows.Forms;
using Tarea_4;

namespace LoginApp
{
    public class Login : Form
    {
        private Label userLabel, passwordLabel;
        private TextBox userTextBox;
        private TextBox passwordTextBox;
        private Button loginButton, registerButton;

        public Login()
        {
            Text = "Login";
            Size = new System.Drawing.Size(400, 200);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;

            userLabel = new Label();
            userLabel.Text = "Username:";
            userLabel.Location = new System.Drawing.Point(10, 20);
            userLabel.AutoSize = true;
            panel.Controls.Add(userLabel);

            userTextBox = new TextBox();
            userTextBox.Location = new System.Drawing.Point(120, 20);
            userTextBox.Size = new System.Drawing.Size(250, 20);
            panel.Controls.Add(userTextBox);

            passwordLabel = new Label();
            passwordLabel.Text = "Password:";
            passwordLabel.Location = new System.Drawing.Point(10, 60);
            passwordLabel.AutoSize = true;
            panel.Controls.Add(passwordLabel);

            passwordTextBox = new TextBox();
            passwordTextBox.Location = new System.Drawing.Point(120, 60);
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new System.Drawing.Size(250, 20);
            panel.Controls.Add(passwordTextBox);

            loginButton = new Button();
            loginButton.Text = "Login";
            loginButton.Location = new System.Drawing.Point(120, 100);
            loginButton.Click += new EventHandler(LoginButton_Click);
            panel.Controls.Add(loginButton);

            registerButton = new Button();
            registerButton.Text = "Register";
            registerButton.Location = new System.Drawing.Point(220, 100);
            registerButton.Click += new EventHandler(RegisterButton_Click);
            panel.Controls.Add(registerButton);

            Controls.Add(panel);
            StartPosition = FormStartPosition.CenterScreen;
            Show();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = userTextBox.Text;
            string password = passwordTextBox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Debe ingresar su usuario y contraseña", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var user = Datos.LoginUser(username, password);
                if (user != null)
                {
                    Listado listado = new Listado();
                    listado.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Debe registrarte para poder iniciar sesión", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Registro registro = new();
            this.Hide();
            registro.Show();
        }
    }
}