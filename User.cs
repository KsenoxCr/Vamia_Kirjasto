using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirjasto_ohjelma
{
    public class User
    {
        // Tänne Tallennetaan tietoja kirjautuneesta käyttäjästä

        public static string Username { get; set; }

        public static string Asnum { get; set; }

        public static bool IsStaff { get; set; }
    }
}
