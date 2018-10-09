using System;
using System.Collections.Generic;
using System.Text;

namespace OpenStory.Data.Http
{
    public abstract class HttpRepoServiceConfig : IDataServiceConfig
    {
        public virtual string Name { get; protected set; }

        public virtual string ConnectionString { get; set; }

        public virtual string DatabaseName { get; set; }
        
    }
}
