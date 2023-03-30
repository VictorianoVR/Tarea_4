using Tarea_4;

public class Registro : Form
{
    private Label labelTitulo, labelUsuario, labelNombre, labelApellido, labelTelefono, labelCorreo, labelContrasena, labelConfirmarContrasena;
    public UsuarioModel userModel;

    private void Registro_Load(object sender, EventArgs e)
    {
        if (userModel != null)
        {
            campoUsuario.Text = userModel.Nombre_Usuario;
            campoNombre.Text = userModel.Nombre;
            campoApellido.Text = userModel.Apellido;
            campoCorreo.Text = userModel.Correo;
            campoTelefono.Text = userModel.Telefono;
            campoContrasena.Text = userModel.Clave;
            campoConfirmarContrasena.Text = userModel.Clave;
        }
    }

    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // Registro
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Registro";
            this.Load += new System.EventHandler(this.Registro_Load);
            this.ResumeLayout(false);

    }

    private TextBox campoUsuario, campoNombre, campoApellido, campoTelefono, campoCorreo;
    private TextBox campoContrasena, campoConfirmarContrasena;
    private Button botonRegistrar, botonCancelar;

    public Registro()
    {
        this.SuspendLayout();
        this.Text = "Registro de Usuario";
        this.Size = new Size(400, 450);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.FormClosed += (s, e) => Application.Exit();

        labelTitulo = new Label();
        labelTitulo.Text = "Registro de Usuario";
        labelTitulo.Font = new Font("Arial", 18, FontStyle.Bold);
        labelTitulo.Size = new Size(200, 30);
        labelTitulo.Location = new Point(100, 20);
        this.Controls.Add(labelTitulo);

        labelUsuario = new Label();
        labelUsuario.Text = "Nombre de Usuario:";
        labelUsuario.Size = new Size(150, 20);
        labelUsuario.Location = new Point(50, 70);
        this.Controls.Add(labelUsuario);

        campoUsuario = new TextBox();
        campoUsuario.Size = new Size(150, 20);
        campoUsuario.Location = new Point(200, 70);
        this.Controls.Add(campoUsuario);

        labelNombre = new Label();
        labelNombre.Text = "Nombre:";
        labelNombre.Size = new Size(150, 20);
        labelNombre.Location = new Point(50, 100);
        this.Controls.Add(labelNombre);

        campoNombre = new TextBox();
        campoNombre.Size = new Size(150, 20);
        campoNombre.Location = new Point(200, 100);
        this.Controls.Add(campoNombre);

        labelApellido = new Label();
        labelApellido.Text = "Apellido:";
        labelApellido.Size = new Size(150, 20);
        labelApellido.Location = new Point(50, 130);
        this.Controls.Add(labelApellido);

        campoApellido = new TextBox();
        campoApellido.Size = new Size(150, 20);
        campoApellido.Location = new Point(200, 130);
        this.Controls.Add(campoApellido);

        labelTelefono = new Label();
        labelTelefono.Text = "Teléfono:";
        labelTelefono.Size = new Size(150, 20);
        labelTelefono.Location = new Point(50, 160);
        this.Controls.Add(labelTelefono);

        campoTelefono = new TextBox();
        campoTelefono.Size = new Size(150, 20);
        campoTelefono.Location = new Point(200, 160);
        this.Controls.Add(campoTelefono);

        labelCorreo = new Label();
        labelCorreo.Text = "Correo Electrónico:";
        labelCorreo.Size = new Size(150, 20);
        labelCorreo.Location = new Point(50, 190);
        this.Controls.Add(labelCorreo);

        campoCorreo = new TextBox();
        campoCorreo.Size = new Size(150, 20);
        campoCorreo.Location = new Point(200, 190);
        this.Controls.Add(campoCorreo);

        labelContrasena = new Label();
        labelContrasena.Text = "Contraseña:";
        labelContrasena.Size = new Size(150, 20);
        labelContrasena.Location = new Point(50, 220);
        this.Controls.Add(labelContrasena);

        campoContrasena = new TextBox();
        campoContrasena.PasswordChar = '*';
        campoContrasena.Location = new System.Drawing.Point(200, 220);
        campoContrasena.Size = new System.Drawing.Size(150, 20);
        this.Controls.Add(campoContrasena);

        labelConfirmarContrasena = new Label();
        labelConfirmarContrasena.Text = "Confirmar Contraseña:";
        labelConfirmarContrasena.Location = new System.Drawing.Point(50, 250);
        labelConfirmarContrasena.Size = new System.Drawing.Size(150, 20);
        this.Controls.Add(labelConfirmarContrasena);

        campoConfirmarContrasena = new TextBox();
        campoConfirmarContrasena.PasswordChar = '*';
        campoConfirmarContrasena.Location = new System.Drawing.Point(200, 250);
        campoConfirmarContrasena.Size = new System.Drawing.Size(150, 20);
        this.Controls.Add(campoConfirmarContrasena);

        botonRegistrar = new Button();
        botonRegistrar.Text = "Registrar";
        botonRegistrar.Location = new System.Drawing.Point(80, 310);
        botonRegistrar.Size = new System.Drawing.Size(100, 30);
        botonRegistrar.Click += new EventHandler(botonRegistrar_Click);
        this.Controls.Add(botonRegistrar);

        botonCancelar = new Button();
        botonCancelar.Text = "Cancelar";
        botonCancelar.Location = new System.Drawing.Point(200, 310);
        botonCancelar.Size = new System.Drawing.Size(100, 30);
        botonCancelar.Click += new EventHandler(botonCancelar_Click);
        this.Controls.Add(botonCancelar);

        this.ResumeLayout(false);
        this.PerformLayout();
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.Visible = true;

    }

    private void botonRegistrar_Click(object sender, EventArgs e)
    {
        var model = new UsuarioModel() { 
            Nombre_Usuario = campoUsuario.Text, Nombre = campoNombre.Text, Apellido= campoApellido.Text, Correo= campoCorreo.Text, Telefono= campoTelefono.Text, Clave = campoContrasena.Text
        };

        if (string.IsNullOrWhiteSpace(campoUsuario.Text) || string.IsNullOrWhiteSpace(campoNombre.Text) || string.IsNullOrWhiteSpace(campoApellido.Text) || string.IsNullOrWhiteSpace(campoCorreo.Text) || 
            string.IsNullOrWhiteSpace(campoTelefono.Text) || string.IsNullOrWhiteSpace(campoContrasena.Text))
        {
            MessageBox.Show("No puede dejar campos vacios", "Error de registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else if (campoContrasena.Text != campoConfirmarContrasena.Text)
        {
            MessageBox.Show("Las contraseñas no coinciden", "Error de registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else if (Datos.ValidateUser(campoUsuario.Text) != null)
        {
            MessageBox.Show("Nombre de Usuario ya exíste en base de datos", "Error de registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            Datos.Registrar(model);
            MessageBox.Show("Registro satisfactorio", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Listado listado = new Listado();
            listado.Show();
            this.Hide();
        }
    }

    private void botonCancelar_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}