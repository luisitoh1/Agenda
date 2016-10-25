using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

using Xamarin.Forms;

namespace AgendaDemo
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MobileServiceClient client;
            IMobileServiceTable<agenda1> tabla;
            client = new MobileServiceClient(Conexion.conexion);
            tabla = client.GetTable<agenda1>();
            Label titulo = new Label()
            {
                Text = "Agenda LUIS ARMANDO H.E."
            };
            Entry nombre1 = new Entry
            { Placeholder = "Ingresa tu nombre" };
            nombre1.TextColor = Color.Blue;
            Entry apellido1 = new Entry
            { Placeholder = "Ingresa tus apellidos" };
            apellido1.TextColor = Color.Blue;
            Entry telefono1 = new Entry
            { Placeholder = "Ingresa thu numero" };
            telefono1.TextColor = Color.Blue;
            Button enviar = new Button()
            {
                Text = "Ingresar Contacto"
            };
            enviar.BorderColor = Color.Red;
            Button leer = new Button()
            {
                Text = "Contactos"
            };
            leer.BorderColor = Color.Aqua;
            ListView lista = new ListView();
            ListView lista2 = new ListView();
            leer.Clicked += async (sender, args) =>
            {
                IEnumerable<agenda1> items = await tabla
    .ToEnumerableAsync();
                string[] arreglo = new string[items.Count()];
                string[] arreglo2 = new string[items.Count()];
                int i = 0;
                foreach (var x in items)
                {
                    arreglo[i] = x.Name;
                    arreglo2[i] = x.Lastname;
                    i++;
                }
                lista.ItemsSource = arreglo;
                lista2.ItemsSource = arreglo2;
            };
            enviar.Clicked += async (sender, args) =>
            {
                var datos = new agenda1 { Name = nombre1.Text, Lastname = apellido1.Text, Cellphone = telefono1.Text };
                await tabla.InsertAsync(datos);
                IEnumerable<agenda1> items = await tabla
    .ToEnumerableAsync();
                string[] arreglo = new string[items.Count()];
                string[] arreglo2 = new string[items.Count()];
                int i = 0;
                foreach (var x in items)
                {
                    arreglo[i] = x.Name;
                    arreglo2[i] = x.Lastname;
                    i++;
                }
          //      lista.ItemsSource = arreglo;
            //    lista2.ItemsSource = arreglo2;
            };
            Button buscar = new Button()
            {
                // Text = "Eliminar dato"
                Text = "Buscar Contacto"
            };
            buscar.BorderColor = Color.Green;
            ListView lista11 = new ListView();
            ListView lista21 = new ListView();
            buscar.Clicked += async (sender, args) =>
            {
                IEnumerable<agenda1> items1 = await tabla
    .ToEnumerableAsync();
                string[] ids = new string[items1.Count()];
                string[] arreglo11 = new string[items1.Count()];
                string[] arreglo21 = new string[items1.Count()];
                string[] arreglo31 = new string[items1.Count()];
                int i = 0;
                foreach (var x in items1)
                {
                    
                    arreglo11[i] = x.Name;
                    arreglo21[i] = x.Lastname;
                    ids[i] = x.Id;
                    arreglo31[i] = x.Cellphone;
                    if (x.Cellphone == telefono1.Text)
                    {
                        if (x.Cellphone == telefono1.Text)
                        {
                         //   arreglo11[i] = x.Name;
                           // arreglo21[i] = x.Lastname;
                            nombre1.Text = x.Name;
                            apellido1.Text = x.Lastname;

                            
                        }
                    }
                }            
            };

            Button actualizar1 = new Button()
            {
                Text = "Actualizar Contacto"

            };
            actualizar1.BorderColor = Color.Lime;
            actualizar1.Clicked += async (sender, args) =>
            {
                IEnumerable<agenda1> items = await tabla.ToEnumerableAsync();
                string[] arreglo = new string[items.Count()];
                string[] arreglo2 = new string[items.Count()];
                string[] ids = new string[items.Count()];
                string[] arreglo3 = new string[items.Count()];
                int i = 0;
                foreach (var x in items)
                {
               //     var datos = new agenda1 { Name = nombre1.Text, Lastname = apellido1.Text, Cellphone = telefono1.Text };
                 //   await tabla.UpdateAsync(datos);
                    arreglo[i] = x.Name;
                    arreglo2[i] = x.Lastname;
                    ids[i] = x.Id;
                    arreglo3[i] = x.Cellphone;
                    if (x.Cellphone == telefono1.Text)
                    {
                        if (x.Name != nombre1.Text)
                        {
                            x.Name = nombre1.Text;
                            //  nombre1.Text = x.Name;
                        }
                        if (x.Lastname != apellido1.Text)
                        {
                            x.Lastname = apellido1.Text;
                            // apellido1.Text = x.Lastname;
                        }
                        await tabla.UpdateAsync(x);
                    }
                    i++;
                }
                lista.ItemsSource = arreglo;
                lista2.ItemsSource = arreglo2;
            };

            Button actualizar = new Button()
            {
                Text = "Eliminar dato"
               
            };
            actualizar.BorderColor = Color.Maroon;
            actualizar.Clicked += async (sender, args) =>
            {
                IEnumerable<agenda1> items = await tabla.ToEnumerableAsync();
                string[] arreglo = new string[items.Count()];
                string[] arreglo2 = new string[items.Count()];
                string[] ids = new string[items.Count()];
                string[] arreglo3 = new string[items.Count()];
                int i = 0;
                foreach (var x in items)
                {
                    arreglo[i] = x.Name;
                    arreglo2[i] = x.Lastname;
                    ids[i] = x.Id;
                    arreglo3[i] = x.Cellphone;
                    if (x.Cellphone == telefono1.Text)
                    {
                        if(x.Name != nombre1.Text)
                        {
                             x.Name = nombre1.Text;
                          //  nombre1.Text = x.Name;
                        }
                        if(x.Lastname != apellido1.Text)
                        {
                             x.Lastname = apellido1.Text;
                           // apellido1.Text = x.Lastname;
                        }
                        await tabla.DeleteAsync(x);
                    }
                    i++;
                }
                lista.ItemsSource = arreglo;
                lista2.ItemsSource = arreglo2;
            };
            var layout = new StackLayout();
            layout.Children.Add(titulo);
            layout.Children.Add(nombre1);
            layout.Children.Add(apellido1);
            layout.Children.Add(telefono1);
            layout.Children.Add(enviar);
            layout.Children.Add(leer);
            layout.Children.Add(buscar);
            layout.Children.Add(actualizar1);
            layout.Children.Add(actualizar);
            layout.Children.Add(lista);
            layout.Children.Add(lista2);

            MainPage = new ContentPage
            {
                Content = layout
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
