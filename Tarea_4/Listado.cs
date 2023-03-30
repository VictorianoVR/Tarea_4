
using System.Xml.Linq;

namespace Tarea_4
{
    public class Listado : Form
    {
        private Panel panelUsuarios;
        private DataGridView dataGridViewUsuarios;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private List<UsuarioModel> usuarios;

        List<UsuarioModel> listaUsuarios = new List<UsuarioModel>();

        public Listado()
        {
            InitializeComponent();

            GetList();
        }

        private void GetList()
        {
            listaUsuarios = Datos.GetList();

            dataGridViewUsuarios.AutoGenerateColumns = true;
            dataGridViewUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Asociar la lista de usuarios al DataGridView
            dataGridViewUsuarios.DataSource = listaUsuarios;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registro registro = new();
            registro.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int filaSeleccionada = dataGridViewUsuarios.SelectedCells[0].RowIndex;
            UsuarioModel elementoSeleccionado = listaUsuarios[filaSeleccionada];

            Registro registro = new();
            //registro.userModel = elementoSeleccionado;
            registro.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int filaSeleccionada = dataGridViewUsuarios.SelectedCells[0].RowIndex;
            UsuarioModel elementoSeleccionado = listaUsuarios[filaSeleccionada];

            Datos.Eliminar(elementoSeleccionado.Nombre_Usuario);
            MessageBox.Show("Registro eliminado correctamente", "Listado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GetList();
        }


        private void InitializeComponent()
        {
            this.dataGridViewUsuarios = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewUsuarios
            // 
            this.dataGridViewUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsuarios.Location = new System.Drawing.Point(213, 79);
            this.dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            this.dataGridViewUsuarios.RowTemplate.Height = 25;
            this.dataGridViewUsuarios.Size = new System.Drawing.Size(669, 214);
            this.dataGridViewUsuarios.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(213, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "LISTADO DE USUARIOS";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(213, 309);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Registrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(305, 309);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 30);
            this.button2.TabIndex = 3;
            this.button2.Text = "Editar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(397, 309);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 30);
            this.button3.TabIndex = 4;
            this.button3.Text = "Eliminar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button4.Location = new System.Drawing.Point(742, 309);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(140, 30);
            this.button4.TabIndex = 5;
            this.button4.Text = "Cerrar Sesión";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Listado
            // 
            this.ClientSize = new System.Drawing.Size(1127, 429);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewUsuarios);
            this.Name = "Listado";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
