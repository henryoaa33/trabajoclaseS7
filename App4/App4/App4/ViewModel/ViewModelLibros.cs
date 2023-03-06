using App4.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace App4.ViewModel
{
    public class ViewModelLibros : INotifyPropertyChanged
    {

        public ViewModelLibros() { 

        AbrirListaLibros();

        LibroSeleccionado = new Libros();

        CrearLibro = new Command(() =>
            {

            Libros c = new Libros()
            {

                nombre = this.nombre,
                autor = this.autor,
                fechadeimpresion = this.fechadeimpresion,

            };


            ListaLibros.Add(c);

            BinaryFormatter formatter = new BinaryFormatter();
            string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "librosv2.clk");

            Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(archivo, ListaLibros);
            archivo.Close();

            App.Current.Properties["ListaLibros"] = ListaLibros;

        });


            CambioLibro = new Command(() => {

            Nombre = libroSelecionado.nombre;
            Autor = libroSelecionado.autor;
            Fechadeimpresion = libroSelecionado.fechadeimpresion;
        


        } );


        }

    private void AbrirListaLibros()
    {
        try
        {

            BinaryFormatter formatter = new BinaryFormatter();
            string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "librosv2.clk");
            Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);

            ListaLibros = (ObservableCollection<Libros>)formatter.Deserialize(archivo);

            archivo.Close();

            App.Current.Properties["ListaLibros"] = ListaLibros;

        }
        catch (Exception ex)
        {
                ListaLibros = new ObservableCollection<Libros>();
        }





    }



    ObservableCollection<Libros> listaLibros = new ObservableCollection<Libros>();

        public ObservableCollection<Libros> ListaLibros{
            get => listaLibros;
            set
            {

                listaLibros = value;
                var arg = new PropertyChangedEventArgs(nameof(ListaLibros));
                PropertyChanged?.Invoke(this, arg);

            }
        }



        string nombre;
        public string Nombre{

            get => nombre;
            set
            {
                nombre = value;
                var arg = new PropertyChangedEventArgs(nameof(Nombre));
                PropertyChanged?.Invoke(this, arg);

            }
        }


        string autor;
        public string Autor
        {

            get => autor;
            set
            {
                autor = value;
                var arg = new PropertyChangedEventArgs(nameof(Autor));
                PropertyChanged?.Invoke(this, arg);

            }
        }


        DateTime fechadeimpresion;

        public DateTime Fechadeimpresion
        {

            get => fechadeimpresion;
            set
            {
                fechadeimpresion = value;
                var arg = new PropertyChangedEventArgs(nameof(Fechadeimpresion));
                PropertyChanged?.Invoke(this, arg);
            }

        }


        Libros libroSelecionado = new Libros();
        public Libros LibroSeleccionado {

            get => libroSelecionado;
            set
            {

                libroSelecionado = value;
                var arg = new PropertyChangedEventArgs(nameof(LibroSeleccionado));
                PropertyChanged?.Invoke(this, arg);


            }

        }


        public event PropertyChangedEventHandler PropertyChanged;

        public Command CrearLibro { get; }
        public Command CambioLibro { get; }


    }
}
