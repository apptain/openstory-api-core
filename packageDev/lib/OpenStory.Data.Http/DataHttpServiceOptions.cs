using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenStory.Data.Http
{
    public class DataHttpServiceOptions
    {
        public DataHttpServiceOptions()
        {
            Domain = "OpenStory";
        }

        public Uri BaseAddress { get; set; }

        public string Authentication { get; set; }

        public string Domain { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
