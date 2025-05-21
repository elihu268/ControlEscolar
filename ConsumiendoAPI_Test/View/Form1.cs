using ConsumiendoAPI_Test.Service;
using System;
using System.Configuration;

namespace ConsumiendoAPI_Test
{
    public partial class Form1 : Form
    {
        private readonly ApiService _apiService;
        public Form1()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Consulta();
        }


        private async void Consulta()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                //var estudiantes = await _apiService.GetEstudiantesAsync(true);
                var estudiantes = await _apiService.GetEstudiantesAsync(true, 2, DateTime.Parse("01/01/2022"), DateTime.Parse("10/05/2023"));

                // Mostrar resultados
                dataGridView1.DataSource = estudiantes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al consultar estudiantes: {ex.Message}");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Consulta();
        }
    }
}
