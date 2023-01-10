using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;

namespace JSONSerializer
{
    public class JsonFormatter
    {

        public static string Convert(object instance)
        {
            string s = "{";

            var type = instance.GetType();

            foreach(var property in type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.Static))
            {
                var propertyType = property.PropertyType;
                var key = property.Name;
                s += $"\"{key}\" :";
                if(propertyType == typeof(string))
                {
                    s += $" \"{property.GetValue(instance)}\",";
                }

                else if(propertyType == typeof(DateTime))
                {
                    var value = (DateTime)property.GetValue(instance);
                    string valueString = value.ToString("yyyy-mm-ddTHH:mm:ss");
                    s += $" \"{valueString}\",";

                }

                else if (propertyType.IsArray)
                {
                    if (propertyType == typeof(string[]))
                    {
                        string[] arr = (string[])property.GetValue(instance);
                        s += "[";
                        for (int i = 0; i < arr.Length; i++)
                        {
                            if (i == arr.Length - 1) s += $"\"{arr[i]}\"]";
                            else s += $"\"{arr[i]}\",";
                        }
                        s += ',';
                    }
                    else if (propertyType == typeof(int[]))
                    {
                        int[] arr = (int[])property.GetValue(instance);
                        s += "[";
                        for (int i = 0; i < arr.Length; i++)
                        {
                            if (i == arr.Length - 1) s += $"{arr[i]}]";
                            else s += $"{arr[i]},";
                        }
                        s += ',';
                    }
                    else if (propertyType == typeof(double[]))
                    {
                        double[] arr = (double[])property.GetValue(instance);
                        s += "[";
                        for (int i = 0; i < arr.Length; i++)
                        {
                            if (i == arr.Length - 1) s += $"{arr[i]}]";
                            else s += $"{arr[i]},";
                        }
                        s += ',';
                    }
                    else if (propertyType == typeof(bool[]))
                    {
                        bool[] arr = (bool[])property.GetValue(instance);
                        s += "[";
                        for (int i = 0; i < arr.Length; i++)
                        {
                            if (i == arr.Length - 1) s += $"{arr[i]}]";
                            else s += $"{arr[i]},";
                        }
                        s += ',';
                    }
                }

                else if(propertyType == typeof(List<string>))
                {
                    List<string> list = (List<string>)property.GetValue(instance);
                    s += "[";
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (i == list.Count - 1) s += $"\"{list[i]}\"]";
                        else s += $"\"{list[i]}\",";
                    }
                    s += ',';

                }

                else if (propertyType == typeof(List<int>))
                {
                    List<int> list = (List<int>)property.GetValue(instance);
                    s += "[";
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (i == list.Count - 1) s += $"{list[i]}]";
                        else s += $"{list[i]},";
                    }
                    s += ',';

                }

                else if (propertyType == typeof(List<double>))
                {
                    List<double> list = (List<double>)property.GetValue(instance);
                    s += "[";
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (i == list.Count - 1) s += $"{list[i]}]";
                        else s += $"{list[i]},";
                    }
                    s += ',';

                }

                else if (propertyType == typeof(List<bool>))
                {
                    List<bool> list = (List<bool>)property.GetValue(instance);
                    s += "[";
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (i == list.Count - 1) s += $"{list[i]}]";
                        else s += $"{list[i]},";
                    }
                    s += ',';

                }

                /*else if (propertyType.IsTypeDefinition)
                {
                    var obj = Activator.CreateInstance(propertyType);
                    obj = property.GetValue(instance);
                    s+= Convert(obj);
                }*/

                else if (propertyType.IsClass)
                {
                    //Console.WriteLine(property);
                    //var objType = propertyType.GetGenericArguments().First();


                    var list = property.GetValue(instance);
                    var tt = list.GetType();
                    var objType = tt.GetGenericArguments().FirstOrDefault();
                    if(objType != null)
                    {
                        //Console.WriteLine(list);
                        //Console.WriteLine(objType);
                        //Console.WriteLine(tt);
                        var IListRef = typeof(List<>);
                        Type[] IListParam = { objType };
                        object Result = Activator.CreateInstance(IListRef.MakeGenericType(IListParam));
                        Result = property.GetValue(instance);

                        IList collection = (IList)Result;

                        s += "[";

                        for (int i = 0; i < collection.Count; i++)
                        {
                            s += Convert(collection[i]);
                            if (i != collection.Count - 1) s += ',';
                        }


                        s += "],";
                    }
                    else
                    {
                        var obj = Activator.CreateInstance(propertyType);
                        obj = property.GetValue(instance);
                        s += Convert(obj);
                        s += ',';
                    }
                    
                }

                else
                {
                    s += $" {property.GetValue(instance)},";
                }
            }

            s = s.Remove(s.Length - 1);
            s += '}';
            return s;
        }
    }
}
