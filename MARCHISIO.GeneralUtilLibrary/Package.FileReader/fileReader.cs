using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Marchisio.GeneralUtilsLibrary
{
    public class fileReader<T> where T : new()
    {
        private string _fileName { get; }

        private Type _type { get; }

        private PropertyInfo[] _props { get;  }


        public fileReader(string fileName)
        {
            _fileName = fileName;

            _type = typeof(T);

            _props = _type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(prop => Attribute.IsDefined(prop, typeof(orderInFileAttribute))).ToArray();
        }


        public IReadOnlyList<T> read(string separator = ";")
        {
            var data = new List<T>();

            if (!File.Exists(_fileName)) throw new FileNotFoundException();

            using (var sr = new StreamReader(_fileName))
            
            while(!sr.EndOfStream){
                string row = sr.ReadLine();

                data.Add(generateObject(row.Split(separator)));
            }

            return data;
        }

        private T generateObject(string[] split)
        {
            var obj = new T();

            foreach(var property in _props)
            {
                int index = property.GetCustomAttribute<orderInFileAttribute>().order;

                property.SetValue(obj, Convert.ChangeType(split[index], property.PropertyType));
            }

            return obj;
        }

    }


}

