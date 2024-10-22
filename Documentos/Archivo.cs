using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documentos
{
    public class Archivo
    {
        // Método estático para abrir archivos de texto
        public static StreamReader AbrirArchivo(string nombreArchivo)
        {
            FileInfo f = new FileInfo(nombreArchivo);
            // ¿Existe el archivo?
            if (f.Exists)
            {
                try
                {
                    // Apertura del archivo de texto
                    return new StreamReader(f.FullName);
                }
                catch (IOException)
                {
                    // Error en la apertura del archivo
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

    }
}
