using App4.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace App4.ViewModel
{
    public class ViewModelPrestamo : INotifyPropertyChanged
    {

        public ViewModelPrestamo()
        {

            AbrirListaPrestamos();



            CrearPrestamo = new Command(

                    () => {

                        Prestamo p = new Prestamo()
                        {

                            fechaprestamo = this.fechaprestamo,
                            fechadevolucion = this.fechadevolucion



                        };


                        ListaPrestamos.Add(p);

                        

                        BinaryFormatter formatter = new BinaryFormatter();
                        string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "prestamos.clk");

                        Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                        formatter.Serialize(archivo, ListaPrestamos);
                        archivo.Close();

                        

                        App.Current.Properties["ListaPrestamos"] = ListaPrestamos;


                    }


                );


        }

        private void AbrirListaPrestamos()
        {
            try
            {

             
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "prestamo.clk");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);

                ListaPrestamos = (ObservableCollection<Prestamo>)formatter.Deserialize(archivo);

                archivo.Close();

                App.Current.Properties["ListaPrestamos"] = ListaPrestamos;

            }
            catch (Exception ex)
            {
                ListaPrestamos = new ObservableCollection<Prestamo>();
                listaLibros = App.Current.Properties["ListaLibros"] as ObservableCollection<Libros>;
                listaPersonas = App.Current.Properties["ListaPersonas"] as ObservableCollection<Persona>;
            }

        


            AsignarLibros = new Command(() => {

                peronaSeleccionada.LibrosPersona.Add(libroSeleccionado);
                int i = 0;
                i = i + 1;

            });



        }


        Persona peronaSeleccionada = new Persona();
        public Persona PersonaSeleccionada
        {
            get => peronaSeleccionada;
            set
            {

                peronaSeleccionada = value;
                var arg = new PropertyChangedEventArgs(nameof(PersonaSeleccionada));
                PropertyChanged?.Invoke(this, arg);

            }

        }


        Libros libroSeleccionado = new Libros();
        public Libros LibroSeleccionado
        {
            get => libroSeleccionado;
            set
            {

                libroSeleccionado = value;
                var arg = new PropertyChangedEventArgs(nameof(LibroSeleccionado));
                PropertyChanged?.Invoke(this, arg);

            }

        }



        DateTime fechaprestamo;

        public DateTime Fechaprestamo
        {

            get => fechaprestamo;
            set
            {
                fechaprestamo = value;
                var arg = new PropertyChangedEventArgs(nameof(Fechaprestamo));
                PropertyChanged?.Invoke(this, arg);
            }

        }

        DateTime fechadevolucion;

        public DateTime Fechadevolucion
        {

            get => fechadevolucion;
            set
            {
                fechadevolucion = value;
                var arg = new PropertyChangedEventArgs(nameof(Fechadevolucion));
                PropertyChanged?.Invoke(this, arg);
            }

        }




        public event PropertyChangedEventHandler PropertyChanged;

        public Command CrearPrestamo { get; }

        public ObservableCollection<Prestamo> listaPrestamos { get; set; } = new ObservableCollection<Prestamo>();

        public ObservableCollection<Prestamo> ListaPrestamos
        {

            get => listaPrestamos;
            set
            {

                listaPrestamos = value;
                var arg = new PropertyChangedEventArgs(nameof(ListaPrestamos));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        public ObservableCollection<Libros> listaLibros { get; set; } = new ObservableCollection<Libros>();
        public ObservableCollection<Persona> listaPersonas { get; set; } = new ObservableCollection<Persona>();


        public Command AsignarLibros { get; set; }
    }
}
