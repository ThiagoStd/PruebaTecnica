﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica
{
    public class Variables
    {

        public static PruebaTecnicaEntities _bd = new PruebaTecnicaEntities();
        public string _user = "";
        public static string _apiUrl = "http://pbiz.zonavirtual.com/api/Prueba/Consulta";

    }
}
