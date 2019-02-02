using System;
using System.Collections.Generic;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Negocio
{
    public class PersonasLogic : BusinessLogic
    {
        public PersonaAdapter PersonaData;
        public PersonasLogic()
        {
            PersonaData = new PersonaAdapter();
        }
        public Personas GetOne(int idUsuario)
        {
            return PersonaData.GetOne(idUsuario);
        }
        public List<Personas> GetAll()
        {
            return PersonaData.GetAll();
        }
        public void Save(Personas user)
        {
            PersonaData.Save(user);
        }
        public void Delete(int idUser)
        {
            PersonaData.Delete(idUser);
        }
        public List<Personas> getAllDocentes()
        {
            return PersonaData.getAllByType(1);
        }
        public List<Personas> getAllAlumnos()
        {
            return PersonaData.getAllByType(2);
        }
        public List<Personas> getAllAdmins()
        {
            return PersonaData.getAllByType(0);
        }
        public List<Personas> getAllByType(int type)
        {
            return PersonaData.getAllByType(type);
        }
    }
}
