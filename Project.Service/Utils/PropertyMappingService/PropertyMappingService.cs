using Project.Service.Models.Entities;
using Project.Service.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Service.Utils.PropertyMappingService
{
    public class PropertyMappingService : IPropertyMappingService
    {
        public PropertyMappingService()
        {
            propertyMappings.Add(new PropertyMapping<VehicleMakeDto, VehicleMake>(_makePropertyMapping));
        }

        private Dictionary<string, PropertyMappingValue> _makePropertyMapping =
            new Dictionary<string, PropertyMappingValue>(StringComparer.OrdinalIgnoreCase)
            {
                { "Id", new PropertyMappingValue ( new List<string>() { "Id" } ) },
                { "Name", new PropertyMappingValue ( new List<string>() { "Name", "Abrv" } ) }
            };

        private IList<IPropertyMapping> propertyMappings = new List<IPropertyMapping>();

        public Dictionary<string, PropertyMappingValue> GetPropertyMapping<TSource, TDestination>()
        {
            var matchingMapping = propertyMappings.OfType<PropertyMapping<TSource, TDestination>>();

            if (matchingMapping.Count() == 1)
            {
                return matchingMapping.First()._mappingDictionary;
            }

            throw new Exception($"Cannot find exact property mapping istance for <{typeof(TSource)}, {typeof(TDestination)}");
        }

        public bool ValidMappingExistsFor<TSource, TDestination>(string fields)
        {
            var propertyMapping = GetPropertyMapping<TSource, TDestination>();

            if (string.IsNullOrWhiteSpace(fields))
            {
                return true;
            }
            var fieldsAfterSplit = fields.Split(',');

            foreach (var field in fieldsAfterSplit)
            {
                var trimmedField = field.Trim();
                var indexOfFirstSpace = trimmedField.IndexOf(" ");
                var propertyName = indexOfFirstSpace == -1 ?
                    trimmedField : trimmedField.Remove(indexOfFirstSpace);

                // find the matching property
                if (!propertyMapping.ContainsKey(propertyName))
                {
                    return false;
                }
            }
            return true;

        }
    }
}
