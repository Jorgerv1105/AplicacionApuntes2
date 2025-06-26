using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacionApuntes2.Models;
using AplicacionApuntes2.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace AplicacionApuntes2.ViewModels
{
    public partial class RecordatoriosViewModel : ObservableObject
    {
        public ObservableCollection<Recordatorio> Lista { get; } = new();

        [ObservableProperty]
        string nuevoTexto;

        [ObservableProperty]
        TimeSpan nuevoFechaHora;

        [ObservableProperty]
        bool nuevoActivo;

        [RelayCommand]
        async Task AgregarRecordatorio()
        {
            var r = new Recordatorio
            {
                Texto = NuevoTexto,
                FechaHora = NuevoFechaHora,
                Activo = NuevoActivo
            };

            Lista.Add(r);
            await Guardar();
            LimpiarCampos();
        }

        [RelayCommand]
        async Task EliminarRecordatorio(Recordatorio r)
        {
            Lista.Remove(r);
            await Guardar();
        }

        public async Task Cargar()
        {
            Lista.Clear();
            var data = await RecordatorioService.CargarAsync();
            foreach (var r in data)
                Lista.Add(r);
        }

        private async Task Guardar() =>
            await RecordatorioService.GuardarAsync(Lista.ToList());

        private void LimpiarCampos()
        {
            NuevoTexto = string.Empty;
            NuevoFechaHora = TimeSpan.Zero;
            NuevoActivo = false;
        }
    }
}
