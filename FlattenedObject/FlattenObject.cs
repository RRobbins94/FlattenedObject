using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlattenedObject
{
    public class FlattenObject
    {
        private static List<Tuple<string, object>> _flatternedObject;

        private FlattenObject()
        {
            
        }

        public static List<Tuple<string, object>> Flattern<T>(T complexObject)
        {
            _flatternedObject = new List<Tuple<string, object>>();
            var flatternResults = DoFlatterning(complexObject);
            return _flatternedObject;
        }


        private static List<Tuple<string, object>> DoFlatterning<T> (T complexObject)
        {
            //for non anonymous object
            //var filteredProperties = complexObject.GetType().GetProperties().Where(x => x.CanWrite);
            var filteredProperties = complexObject.GetType().GetProperties();

            foreach (var property in filteredProperties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(complexObject, null);

                if(propertyValue != null)
                {
                    if(propertyValue.GetType().IsValueType || propertyValue is string)
                    {
                        _flatternedObject.Add(new Tuple<string, object>(propertyName, propertyValue));
                    }
                    else if (propertyValue is IEnumerable enumerable)
                    {
                        
                        //loop through each item and flatten 
                        foreach (var item in enumerable)
                        {
                            var results = DoFlatterning(item);
                        }
                    }
                    else //is complex item
                    {
                        var results = DoFlatterning(propertyValue);
                    }
                }

            }
            
            return _flatternedObject;
        }


    }
}
