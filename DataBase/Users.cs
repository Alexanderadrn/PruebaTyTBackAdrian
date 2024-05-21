using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Users
    {
        public  int id { set; get; }
        public  string usuario { set; get; }
        public  string primerNombre { set; get; }
        public  string segundoNombre { set; get; }
        public  string primerApellido { set; get; }
        public  string segundoApellido { set; get; }
        public  int idDepartamento { set; get; }
        public  int idCargo { set; get; }
        public  bool estado { set; get; }
        public  string Correo { set; get; }
    }
}