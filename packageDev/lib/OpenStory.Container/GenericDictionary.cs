//https://stackoverflow.com/questions/654752/can-i-create-a-dictionary-of-generic-types thanks!

using System.Collections.Generic;

namespace OpenStory
{
    public class GenericDictionary
    {
        private Dictionary<string, object> _dict = new Dictionary<string, object>();

        public void Add<T>(string key, T value) where T : class
        {
            _dict.Add(key, value);
        }

        public T GetValue<T>(string key) where T : class
        {
            return _dict[key] as T;
        }
    }
}