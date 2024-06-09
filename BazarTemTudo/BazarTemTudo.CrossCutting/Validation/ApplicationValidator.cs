using Microsoft.AspNetCore.Http;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazarTemTudo.CrossCutting.Validation
{
    public class ApplicationValidator
    {
        public static DateTime ConvertDatetimeFromString(string previousdata)
        {
            try
            {
                string formato = "dd/MM/yyyy";

                DateTime data = new DateTime();

                if (DateTime.TryParseExact(previousdata, formato, null, System.Globalization.DateTimeStyles.None, out data))
                {
                    return data;
                }
                else
                {
                    throw new Exception("Erro na conversao");
                }
            }
            catch (Exception ex)
            {
               throw new Exception("Erro> " + ex.Message);
            }
        }
    }
}
