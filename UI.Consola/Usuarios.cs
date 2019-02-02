using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using Negocio;

namespace UI.Consola
{
    public class Usuarios
    {
        private UsuarioLogic _UsuarioNegocio;
        public UsuarioLogic UsuarioNegocio
        {
            get { return _UsuarioNegocio; }
            set { _UsuarioNegocio = value; }
        }
        public Usuarios()
        {
            UsuarioNegocio = new UsuarioLogic();
        }
        public void Menu()
        {
            Console.WriteLine("Ingrese una opción del menú: ");
            Console.WriteLine("1- Listado general");
            Console.WriteLine("2- Consulta");
            Console.WriteLine("3- Agregar");
            Console.WriteLine("4- Modificar");
            Console.WriteLine("5- Eliminar"); ;
            Console.WriteLine("6- Salir");
            int entry = int.Parse(Console.ReadLine());
            if (entry == 1)
            {
                // Listado general
                this.ListadoGeneral();
                Console.ReadKey();
            }
            if (entry == 2)
            {
                // Consulta
                this.Consultar();
            }
            if (entry == 3)
            {
                // Agregar
                this.Agregar();
            }
            if (entry == 4)
            {
                // Modificar
                this.Modificar();
            }
            if (entry == 5)
            {
                // Eliminar
            }
            if (entry == 6)
            {
                // Salir
            }
        }
        public void MostrarDatos(Usuario usr)
        {
            Console.WriteLine("Usuario: {0}", usr.ID);
            Console.WriteLine("\t\tNombre: {0}", usr.Nombre);
            Console.WriteLine("\t\tApellido: {0}", usr.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: {0}", usr.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", usr.Clave);
            Console.WriteLine("\t\tEmail: {0}", usr.EMail);
            Console.WriteLine("\t\tHabilitado: {0}", usr.Habilitado);
            Console.WriteLine();
        }
        public void ListadoGeneral()
        {
            Console.Clear();
            foreach( Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
        }
        public void Consultar()
        {
            Console.Clear();
            Console.Write("Ingrese el ID del usuario a consultar: ");
            try
            {
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un número entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }
        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese la ID del usuario a modificar: ");
                int ID = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(ID);
                Console.WriteLine("Ingrese el nombre: ");
                usuario.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el apellido: ");
                usuario.Apellido = Console.ReadLine();
                Console.WriteLine("Ingrese el nombre de usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.WriteLine("Ingrese la clave: ");
                usuario.Clave = Console.ReadLine();
                Console.WriteLine("Ingrese el Email: ");
                usuario.EMail = Console.ReadLine();
                Console.WriteLine("Ingrese habilitación de Usuario(1-Si/otro-No): ");
                usuario.Habilitado = (Console.ReadLine() == "1");
                usuario.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usuario);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un número entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar: ");
                Console.ReadKey();
            }
        }
        public void Agregar()
        {
            try
            {
                Console.Clear();
                Usuario usuario = new Usuario();

                Console.WriteLine("Ingrese el nombre: ");
                usuario.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el apellido: ");
                usuario.Apellido = Console.ReadLine();
                Console.WriteLine("Ingrese el nombre de usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.WriteLine("Ingrese la clave: ");
                usuario.Clave = Console.ReadLine();
                Console.WriteLine("Ingrese el Email: ");
                usuario.EMail = Console.ReadLine();
                Console.WriteLine("Ingrese habilitación de Usuario(1-Si/otro-No): ");
                usuario.Habilitado = (Console.ReadLine() == "1");
                usuario.State = BusinessEntity.States.New;
                UsuarioNegocio.Save(usuario);

                Console.WriteLine();
                Console.WriteLine("ID: {0}", usuario.ID);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un número entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar: ");
                Console.ReadKey();
            }
        }
        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese la ID del usuario a eliminar: ");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un número entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar: ");
                Console.ReadKey();
            }
        }
    }
}
