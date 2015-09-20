using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Culture = System.Globalization.CultureInfo;

namespace CultureInfo
{
    public class Program
    {
        private static readonly Culture _english = new Culture("en-GB");
        private static readonly Culture _french = new Culture("fr-FR");

        private string CultureName
        {
            get
            {
                return Culture.CurrentCulture == null ? "null" : Culture.CurrentCulture.EnglishName;
            }
        }

        private string UICultureName
        {
            get
            {
                return Culture.CurrentUICulture == null ? "null" : Culture.CurrentUICulture.EnglishName;
            }
        }

        public void Main(string[] args)
        {
            Console.WriteLine($"Current cultures before '{ CultureName }' / '{ UICultureName }'");

            Culture.DefaultThreadCurrentCulture = _english;
            Culture.DefaultThreadCurrentUICulture = _french;
            Console.WriteLine($"Current cultures after default thread switch '{ CultureName }' / '{ UICultureName }'");

#if DNXCORE50
            Culture.CurrentCulture = _french;
            Culture.CurrentUICulture = _english;
#else
            Thread.CurrentThread.CurrentCulture = _french;
            Thread.CurrentThread.CurrentUICulture = _english;
#endif
            Console.WriteLine($"Current cultures after current switch '{ CultureName }' / '{ UICultureName }'");
        }
    }
}
