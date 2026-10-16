using DAL;
using System;
using System.IO;

namespace BLL
{
    public class BackupBLL
    {
        private static readonly BackupBLL _instancia = new BackupBLL();
        private BackupDal backupDal = new BackupDal();
        private BackupBLL() { }
        public static BackupBLL GetInstance()
        {
            return _instancia;
        }
        public void RealizarBackup(string rutaDestino)
        {
            if (string.IsNullOrWhiteSpace(rutaDestino))
                throw new Exception("Debe seleccionar una ruta válida para guardar la copia de seguridad.");

            // Validamos que el directorio padre exista en la PC
            string directorio = Path.GetDirectoryName(rutaDestino);
            if (!Directory.Exists(directorio))
                throw new Exception("El directorio de destino seleccionado no existe.");

            backupDal.RealizarBackup(rutaDestino);
        }
        public void RealizarRestore(string rutaOrigen)
        {
            if (string.IsNullOrWhiteSpace(rutaOrigen))
                throw new Exception("Debe seleccionar un archivo de backup para restaurar.");

            // Validamos que el archivo (.bak) realmente exista
            if (!File.Exists(rutaOrigen))
                throw new Exception("El archivo de copia de seguridad seleccionado no existe o fue movido.");

            backupDal.RealizarRestore(rutaOrigen);
        }
    }
}