using System.Reflection;

namespace Documentos
{
    public partial class FrmDocumentos : Form
    {
        public FrmDocumentos()
        {
            InitializeComponent();

            // Obtener la ruta del archivo de datos CSV
            String nombreArchivo = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                @"\Datos\Datos.csv";

            // Verificar si el archivo CSV existe antes de cargarlo
            if (File.Exists(nombreArchivo))
            {
                // Cargar los datos del archivo CSV y mostrarlos en el DataGridView
                Documento.DesdeArchivo(nombreArchivo);
                Documento.Mostrar(dgvDocumentos);
            }
            else
            {
                MessageBox.Show("El archivo de datos no existe. Por favor, verifica la ruta o nombre del archivo.");
            }

            // Llenar el ComboBox con criterios de ordenamiento
            cmbCriterio.Items.Add("Nombre Completo");
            cmbCriterio.Items.Add("Tipo de Documento");
            cmbCriterio.SelectedIndex = 0; // Selección por defecto
        }

        // Método para el ordenamiento usando el algoritmo Burbuja
        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            if (cmbCriterio.SelectedIndex >= 0)
            {
                // Iniciar el cronómetro para medir el tiempo del ordenamiento
                Util.IniciarCronometro();

                // Ordenar los documentos utilizando Burbuja
                Documento.OrdenarBurbuja(cmbCriterio.SelectedIndex);

                // Mostrar el tiempo de ejecución
                txtTiempo.Text = Util.GetTextoTiempoCronometro();

                // Actualizar la tabla de documentos
                Documento.Mostrar(dgvDocumentos);

                // Mostrar el número total de registros y el tiempo de ordenamiento
                int totalRegistros = Documento.documentos.Count;
                MessageBox.Show($"Los documentos han sido ordenados correctamente.\nTiempo de ejecución: {txtTiempo.Text} ms\nTotal de registros: {totalRegistros}");
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un criterio de ordenamiento antes de continuar.");
            }
        }

        // Método para el ordenamiento usando el algoritmo Quicksort
        private void btnOrdenarRapido_Click(object sender, EventArgs e)
        {
            if (cmbCriterio.SelectedIndex >= 0)
            {
                // Iniciar el cronómetro para medir el tiempo del ordenamiento
                Util.IniciarCronometro();

                // Ordenar los documentos utilizando Quicksort
                Documento.OrdenarRapido(0, Documento.documentos.Count - 1, cmbCriterio.SelectedIndex);

                // Mostrar el tiempo de ejecución
                txtTiempo.Text = Util.GetTextoTiempoCronometro();

                // Actualizar la tabla de documentos
                Documento.Mostrar(dgvDocumentos);

                // Mostrar el número total de registros y el tiempo de ordenamiento
                int totalRegistros = Documento.documentos.Count;
                MessageBox.Show($"Los documentos han sido ordenados correctamente usando Quicksort.\nTiempo de ejecución: {txtTiempo.Text} ms\nTotal de registros: {totalRegistros}");
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un criterio de ordenamiento antes de continuar.");
            }
        }
    }
}
