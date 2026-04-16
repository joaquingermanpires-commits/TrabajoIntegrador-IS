using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABS
{
    public interface ITurno
    {
        long Id_Turno { get; set; }
        DateTime fecha {  get; set; }
        String Estado {  get; set; }
        
    }
}
