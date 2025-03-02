using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Infrastructure.Utilities
    {
        public static class CodeGenerators
        {
            public static string ActiveCode()
            {
                return Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6);
            }

            public static string ImgCode()
            {
                return Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);
            }


            public static string FactorCode()
            {
                Random random = new Random();

                string strCode = random.Next(11110000, 99999900).ToString();

                return strCode;
            }

        }
    }

}
