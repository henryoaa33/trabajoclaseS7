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
    public class ViewModelPersona : INotifyPropertyChanged
    {

        public ViewModelPersona()
        {

            AbrirListaPersonas();

       

            CrearPersona = new Command(

                    () => {

                        Persona p = new Persona()
                        {

                            nombre2 = this.nombre2,
                            numerocuenta = this.numerocuenta

                        };


                        Mensaje = p.ToString();
                        ListaPersonas.Add(p);

                        /* Rutina de Serializacion (Proceso de convertir Objetos a Archivos, crear archivos) */

                        BinaryFormatter formatter = new BinaryFormatter();
                        string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "personas.clk");

                        Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                        formatter.Serialize(archivo, ListaPersonas);
                        archivo.Close();

                        /*Fin de Rutina de Serializacion*/

                        App.Current.Properties["ListaPersonas"] = ListaPersonas;


                    }


                );


        }

        private void AbrirListaPersonas()
        {
            try
            {

                /*Proceso de Deserializacion (Ingeniera Inversa de Serializar, leer archivos) */
                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "personas.clk");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);

                ListaPersonas = (ObservableCollection<Persona>)formatter.Deserialize(archivo);

                archivo.Close();

                App.Current.Properties["ListaPersonas"] = ListaPersonas;

            }
            catch (Exception ex)
            {
                ListaPersonas = new ObservableCollection<Persona>();
            }



        }

        string mensaje;

        public string Mensaje {

            get => mensaje;
            set
            {

                mensaje = value;
                var arg = new PropertyChangedEventArgs(nameof(Mensaje));
                PropertyChanged?.Invoke(this, arg);

            }

        }

        string nombre2;

        public string Nombre2
        {

            get => nombre2;
            set
            {

                nombre2 = value;
                var arg = new PropertyChangedEventArgs(nameof(Nombre2));
                PropertyChanged?.Invoke(this, arg);


            }

        }



        double numerocuenta;

        public double Numerocuenta
        {

            get => numerocuenta;
            set
            {
                numerocuenta = value;
                var arg = new PropertyChangedEventArgs(nameof(Numerocuenta));
                PropertyChanged?.Invoke(this, arg);
            }

        }

     

        ObservableCollection<Persona> listaPersonas = new ObservableCollection<Persona>();

        public ObservableCollection<Persona> ListaPersonas
        {

            get => listaPersonas;
            set
            {

                listaPersonas = value;
                var arg = new PropertyChangedEventArgs(nameof(ListaPersonas));
                PropertyChanged?.Invoke(this, arg);
            }
        }

        public Command CrearPersona { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}




