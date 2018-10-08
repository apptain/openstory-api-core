using OpenStory.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenStory
{
    public interface IContainer : IDataService
    {
        IDictionary<IDataServiceConfig, IDataService> _dataServices { get; }
    }
}
