using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using GPS_SECCION_0742;
using System.Threading.Tasks;

namespace GPS_SECCION_0742
{
    public partial class MainPage : ContentPage
    {
        private double _latitud;
        private double _longitud;
        private int locatorDesiredAccuracy;
        private bool locatorIsGeolocationEnabled;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void ObtenerUbicacion_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Solicita permisos
                var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (status != PermissionStatus.Granted)
                {
                    status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                    if (status != PermissionStatus.Granted)
                    {
                        lblUbicacion.Text = "Permiso denegado. No se puede acceder a la ubicación.";
                        return;
                    }
                }

                // Obtiene la ubicación
                var locator = CrossGeolocator.Current;
                locatorDesiredAccuracy = 50;

                if (!locatorIsGeolocationEnabled)
                {
                    lblUbicacion.Text = "El GPS está desactivado. Actívalo e intenta de nuevo.";
                    return;
                }

                
                _latitud = posicion.Latitude;
                _longitud = posicion.Longitude;

                // Muestra la ubicación en pantalla
                lblUbicacion.Text = $"Latitud: {_latitud}\nLongitud: {_longitud}";
                btnGoogleMaps.IsVisible = true;
            }
            catch (Exception ex)
            {
                lblUbicacion.Text = $"Error al obtener la ubicación: {ex.Message}";
            }
        }

        private async Task locatorGetPositionAsync(TimeSpan timeSpan)
        {
            throw new NotImplementedException();
        }

        private async void AbrirGoogleMaps_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ubicacion = new Location(_latitud, _longitud);
                var opciones = new MapLaunchOptions { Name = "Ubicación Actual" };

                await Map.OpenAsync(ubicacion, opciones);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"No se pudo abrir Google Maps: {ex.Message}", "OK");
            }
        }

        private class locatorGet
        {
            internal static async Task PositionAsync(TimeSpan timeSpan)
            {
                throw new NotImplementedException();
            }
        }
    }

    internal class posicion
    {
        internal static double Latitude;
        internal static double Longitude;
    }

    internal class btnGoogleMaps
    {
        internal static bool IsVisible;
    }

    internal class lblUbicacion
    {
        internal static string Text;
    }
}
