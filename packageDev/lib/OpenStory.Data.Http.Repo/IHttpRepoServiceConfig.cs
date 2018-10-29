using System;
using System.Collections.Generic;
using System.Text;

namespace OpenStory.Data.Http
{
    public interface IHttpRepoServiceConfig : IDataServiceConfig
    {
       string Name { get; }

       string ConnectionString { get; set; }

       string DatabaseName { get; set; }
        
    }
}
