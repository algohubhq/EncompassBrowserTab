using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncompassBrowserTab.Objects.Dependencies
{
    public class Dependency
    {

        public string Name { get; set; }

        public string FileExtension { get; set; }

        public string Version { get; set; }
        
        public string Filename
        {
            get 
            {
                return string.Format("{0}.{1}", Name, FileExtension);
            }
        }
        
        
    }
}
