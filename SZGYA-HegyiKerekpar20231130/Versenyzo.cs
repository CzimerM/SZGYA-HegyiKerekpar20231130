using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SZGYA_HegyiKerekpar20231130
{
    class Versenyzo
    {
        public string Rajtszam { get; set; }
        public string Kategoria { get; set; }
        public string Nev {  get; set; }
        public string Egyesulet { get; set; }
        public TimeSpan Ido { get; set; }
        public string Tav => _tav.Tav;
        private Versenytav _tav;

        public Versenyzo(string sor)
        {
            string[] adatok = sor.Split(';');
            this.Rajtszam = adatok[0];
            this.Kategoria = adatok[1];
            this.Nev = adatok[2];
            this.Egyesulet = adatok[3];
            this.Ido = TimeSpan.Parse(adatok[4]);
            this._tav = new Versenytav(this.Rajtszam);
        }

        public override string ToString()
        {
            return $"\tRajtszám: {this.Rajtszam}\n\tNév: {this.Nev}\n\tEgyesület: {this.Egyesulet}\n\tIdő: {this.Ido}";
        }
    }
}
