using System;
using System.Globalization;
namespace Documentos
{
    public class Util
    {
        private static long inicio;

        public static void IniciarCronometro()
        {
            inicio = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }

        public static long GetTiempoCronometro()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - inicio;
        }

        public static string GetTextoTiempoCronometro()
        {
            long tiempo = GetTiempoCronometro();
            long ms = tiempo % 1000;
            tiempo = (tiempo - ms) / 1000;
            long s = tiempo % 60;
            tiempo = (tiempo - s) / 60;
            long m = tiempo % 60;
            tiempo = (tiempo - m) / 60;
            long h = tiempo % 60;

            return string.Format(CultureInfo.InvariantCulture, "{0:00}:{1:00}:{2:00}.{3:000}", h, m, s, ms);
        }
    }

}
