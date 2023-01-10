using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace JSONSerializer
{
    public class Essentials
    {
        public static void SetFieldValue(object instance)
        {
            var type = instance.GetType();
            
            foreach(var field in type.GetFields(BindingFlags.Public | BindingFlags.Instance 
                | BindingFlags.Static))
            {
                var fieldType = field.FieldType;

                if(fieldType == typeof(int))
                {
                    Console.Write($"{field.Name}: ");
                    int value = int.Parse(Console.ReadLine());
                    field.SetValue(instance, value);
                }

                else if(fieldType == typeof(double))
                {
                    Console.Write($"{field.Name}: ");
                    double value = double.Parse(Console.ReadLine());
                    field.SetValue(instance, value);
                }

                else if (fieldType == typeof(string))
                {
                    Console.Write($"{field.Name}: ");
                    string value = Console.ReadLine();
                    field.SetValue(instance, value);
                }

                else if (fieldType == typeof(bool))
                {
                    Console.Write($"{field.Name}: ");
                    bool value = bool.Parse(Console.ReadLine());
                    field.SetValue(instance, value);
                }


            }

        }

        public static void SetPropertyValue(object instance)
        {
            var type = instance.GetType();
            foreach(var property in type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | 
                BindingFlags.Instance | BindingFlags.Static))
            {
                var propertyType = property.PropertyType;

                if (propertyType == typeof(int))
                {
                    Console.Write($"{property.Name}: ");
                    int value = int.Parse(Console.ReadLine());
                    property.SetValue(instance, value);
                }

                else if (propertyType == typeof(double))
                {
                    Console.Write($"{property.Name}: ");
                    double value = double.Parse(Console.ReadLine());
                    property.SetValue(instance, value);
                }

                else if (propertyType == typeof(float))
                {
                    Console.Write($"{property.Name}: ");
                    float value = float.Parse(Console.ReadLine());
                    property.SetValue(instance, value);
                }

                else if (propertyType == typeof(decimal))
                {
                    Console.Write($"{property.Name}: ");
                    decimal value = decimal.Parse(Console.ReadLine());
                    property.SetValue(instance, value);
                }

                else if (propertyType == typeof(string))
                {
                    Console.Write($"{property.Name}: ");
                    string value = Console.ReadLine();
                    property.SetValue(instance, value);
                }

                else if (propertyType == typeof(bool))
                {
                    Console.Write($"{property.Name}: ");
                    bool value = bool.Parse(Console.ReadLine());
                    property.SetValue(instance, value);
                }

                else if(propertyType== typeof(DateTime))
                {
                    Console.Write($"Enter data for {property.Name} :  ");
                    //var obj = Activator.CreateInstance(propertyType);
                    //SetFieldValue(obj);
                    //SetPropertyValue(obj);
                    var obj = new DateTime();
                    obj = DateTime.Parse(Console.ReadLine());
                    property.SetValue(instance, obj);
                }
                
                else if(propertyType.IsTypeDefinition)
                {
                    Console.WriteLine($"Enter data for {property.Name} :  ");
                    var obj = Activator.CreateInstance(propertyType);
                    SetFieldValue(obj);
                    SetPropertyValue(obj);
                    property.SetValue(instance, obj);
                }

                else if (propertyType.IsArray)
                {
                    Console.Write($"Enter the size of {property.Name} array: ");
                    int size = int.Parse(Console.ReadLine());
                    //Console.WriteLine(property.PropertyType);
                    if (propertyType == typeof(string[]))
                    {
                        string[] arr = new string[size];
                        for (int i = 0; i < size; i++)
                        {
                            Console.Write($"Enter the value of {property.Name} {i + 1}: ");
                            arr[i] = Console.ReadLine();
                        }

                        property.SetValue(instance, arr);
                    }

                    else if(propertyType == typeof(double[]))
                    {
                        double[] arr = new double[size];
                        for (int i = 0; i < size; i++)
                        {
                            Console.Write($"Enter the value of {property.Name} {i + 1}: ");
                            arr[i] = double.Parse(Console.ReadLine());
                        }

                        property.SetValue(instance, arr);
                    }

                    else if (propertyType == typeof(float[]))
                    {
                        float[] arr = new float[size];
                        for (int i = 0; i < size; i++)
                        {
                            Console.Write($"Enter the value of {property.Name} {i + 1}: ");
                            arr[i] = float.Parse(Console.ReadLine());
                        }

                        property.SetValue(instance, arr);
                    }


                    else if (propertyType == typeof(int[]))
                    {
                        int[] arr = new int[size];
                        for (int i = 0; i < size; i++)
                        {
                            Console.Write($"Enter the value of {property.Name} {i + 1}: ");
                            arr[i] = int.Parse(Console.ReadLine());
                        }

                        property.SetValue(instance, arr);
                    }
                    else if (propertyType == typeof(bool[]))
                    {
                        bool[] arr = new bool[size];
                        for (int i = 0; i < size; i++)
                        {
                            Console.Write($"Enter the value of {property.Name} {i + 1}: ");
                            arr[i] = bool.Parse(Console.ReadLine());
                        }

                        property.SetValue(instance, arr);
                    }
                }

                else if (propertyType == typeof(List<string>))
                {
                    List<string> list = new List<string>();

                    while (true)
                    {
                        Console.Write($"do you want to enter element in {property.Name}? (1: yes, 2: no) : ");
                        int choice = int.Parse(Console.ReadLine());
                        int i = 1;
                        if (choice == 1)
                        {
                            Console.Write($"Enter {property.Name} {i++}: ");
                            string value = Console.ReadLine();
                            list.Add(value);
                        }
                        else if (choice == 2) break;
                        else continue;
                    }

                    property.SetValue(instance, list);

                }

                else if (propertyType == typeof(List<int>))
                {
                    List<int> list = new List<int>();

                    while (true)
                    {
                        Console.Write($"do you want to enter element in {property.Name}? (1: yes, 2: no) : ");
                        int choice = int.Parse(Console.ReadLine());
                        int i = 1;
                        if (choice == 1)
                        {
                            Console.Write($"Enter {property.Name} {i++}: ");
                            int value = int.Parse(Console.ReadLine());
                            list.Add(value);
                        }
                        else if (choice == 2) break;
                        else continue;
                    }

                    property.SetValue(instance, list);

                }

                else if (propertyType == typeof(List<double>))
                {
                    List<double> list = new List<double>();

                    while (true)
                    {
                        Console.Write($"do you want to enter element in {property.Name}? (1: yes, 2: no) : ");
                        int choice = int.Parse(Console.ReadLine());
                        int i = 1;
                        if (choice == 1)
                        {
                            Console.Write($"Enter {property.Name} {i++}: ");
                            double value = double.Parse(Console.ReadLine());
                            list.Add(value);
                        }
                        else if (choice == 2) break;
                        else continue;
                    }

                    property.SetValue(instance, list);

                }

                else if (propertyType == typeof(List<bool>))
                {
                    List<bool> list = new List<bool>();

                    while (true)
                    {
                        Console.Write($"do you want to enter element in {property.Name}? (1: yes, 2: no) : ");
                        int choice = int.Parse(Console.ReadLine());
                        int i = 1;
                        if (choice == 1)
                        {
                            Console.Write($"Enter {property.Name} {i++}: ");
                            bool value = bool.Parse(Console.ReadLine());
                            list.Add(value);
                        }
                        else if (choice == 2) break;
                        else continue;
                    }

                    property.SetValue(instance, list);

                }

                else if (propertyType.IsClass)
                {
                    Type objType = propertyType.GetGenericArguments()[0];
                    Type objType1 = propertyType.GetType();
                    //Console.WriteLine(objType);
                    //Console.WriteLine(objType1);
                    //Console.WriteLine(propertyType);
                    var IListRef = typeof(List<>);
                    Type[] IListParam = { objType };
                    object Result = Activator.CreateInstance(IListRef.MakeGenericType(IListParam));

                    
                    while (true)
                    {
                        Console.Write($"do you want to enter element in {property.Name}? (1: yes, 2: no) : ");
                        int choice = int.Parse(Console.ReadLine());
                        int i = 0;
                        if (choice == 1)
                        {
                            var obj = Activator.CreateInstance(objType);
                            SetFieldValue(obj);
                            SetPropertyValue(obj);
                            Result.GetType().GetMethod("Add").Invoke(Result, new[] { obj });

                        }
                        else if (choice == 2) break;
                        else continue;
                    }
                    property.SetValue(instance, Result);
                }
            }
        }


       

    }
}
