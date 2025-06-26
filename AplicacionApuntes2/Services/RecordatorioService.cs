using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AplicacionApuntes2.Models;

namespace AplicacionApuntes2.Services
{
    public class RecordatorioService
    {
        private static readonly string filePath = Path.Combine(FileSystem.AppDataDirectory, "recordatorios.json");

        public static async Task<List<Recordatorio>> CargarAsync()
        {
            if (!File.Exists(filePath)) return new List<Recordatorio>();

            using var stream = File.OpenRead(filePath);
            return await JsonSerializer.DeserializeAsync<List<Recordatorio>>(stream) ?? new();
        }

        public static async Task GuardarAsync(List<Recordatorio> recordatorios)
        {
            using var stream = File.Create(filePath);
            await JsonSerializer.SerializeAsync(stream, recordatorios);
        }
    }
}
