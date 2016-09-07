using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxtNavigationPages.Models
{
    public class FileStringsGetter
    {
        public static IEnumerable<string> GetStrings(string path)
        {
            List<string> result = new List<string>();

            using (var stream = File.OpenText(path))
            {
                while (!stream.EndOfStream)
                {
                    result.Add(stream.ReadLine());
                }
            }

            return result;
        }
    }
}
