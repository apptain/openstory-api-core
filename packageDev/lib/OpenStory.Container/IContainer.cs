using OpenStory.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenStory
{
    public interface IContainer<T> : IDataService<T>
    {
       GenericDictionary _dataServices { get; }
    }
}
