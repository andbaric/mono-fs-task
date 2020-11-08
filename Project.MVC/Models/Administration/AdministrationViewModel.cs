using Project.Service.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Project.MVC.Models.Administration
{
    public class AdministrationViewModel
    {
        public AdministrationViewModel(IEnumerable<object> data)
        {
            Type objectType = data.GetType().GetGenericArguments().Single();
            DataAttributes = objectType.GetProperties();
            Data = data;
        }

        public PropertyInfo[] DataAttributes { get; }
        public IEnumerable<object> Data { get; }
    }
}
