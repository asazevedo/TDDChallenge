using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDChallenge.Services
{
    /// <summary>List filter service</summary>
    public class ListFilterService
    {
        /// <summary>Filter type used</summary>
        public enum FilterType
        {
            Integers,
            Strings
        }

        /// <summary>Object list input</summary>
        protected readonly List<object> ObjectList;

        /// <summary>Service constructor. Accepts an object list and filter by a given type</summary>
        /// <param name="objectList">Object list input</param>
        public ListFilterService(List<object> objectList)
        {
            ObjectList = objectList;
        }

        /// <summary>Method used to filter the object list input. Returns a new object list by the given filter type</summary>
        /// <param name="filterType">The filter type used</param>
        public List<object> FilterList(FilterType filterType)
        {
            ValidateObjectList();

            var outputList = new Dictionary<object, FilterType>();

            foreach (var item in ObjectList)
            {
                if (int.TryParse(item.ToString(), out var number))
                    outputList.TryAdd(number, FilterType.Integers);
                else
                    outputList.TryAdd(item, FilterType.Strings);
            }

            return outputList
                .Where(dict => dict.Value == filterType)
                .Select(obj => obj.Key)
                .ToList();
        }

        /// <summary>Validates the input array</summary>
        protected void ValidateObjectList()
        {
            if (ObjectList == null)
                throw new ArgumentNullException("Array cannot be null");

            if (!ObjectList.Any())
                throw new ArgumentException("Array cannot be empty");
        }
    }
}
