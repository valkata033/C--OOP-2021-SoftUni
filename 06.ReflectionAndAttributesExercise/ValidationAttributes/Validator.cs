﻿using System;
using System.Reflection;
using System.Linq;

namespace ValidationAttributes
{
    public class Validator
    {
        public static bool IsValid(Object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (var propertyInfo in properties)
            {
                var attributes = propertyInfo
                    .GetCustomAttributes()
                    .Where(t => t.GetType().IsSubclassOf(typeof(MyValidationAttribute)))
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                foreach (var item in attributes)
                {
                    bool isValid = item.IsValid(propertyInfo.GetValue(obj));

                    if (!isValid)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}