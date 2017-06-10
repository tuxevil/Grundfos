using System;
using System.Collections.Generic;
using System.Text;

namespace GrundFos.Despiece.Business
{
    public class Utils
    {
        public static long ConvertIp(string ip)
        {

            string[] parts = ip.Split('.');

            string strhexip = string.Format("{0:X2}{1:X2}{2:X2}{3:X2}",

              int.Parse(parts[0]), int.Parse(parts[1]),

              int.Parse(parts[2]), int.Parse(parts[3]));

            return Convert.ToInt64(strhexip, 16);

        }

    }
}
