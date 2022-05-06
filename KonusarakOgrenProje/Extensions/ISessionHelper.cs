using KonusarakOgrenProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgrenProje.Extensions
{
    public interface ISessionHelper
    {
        void SetSeesionModel( string SessionName);
        string GetSessionModel(string SessionKey);
    }
}
