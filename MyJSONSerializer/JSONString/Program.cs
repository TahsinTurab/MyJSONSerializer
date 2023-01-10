

using System;
using System.Reflection;
using JSONSerializer;
using System.Collections.Generic;




var assembly = Assembly.LoadFrom(@"G:\Training\ASP.NET\tahsinturab-aspnet-b7\Assignment1\ClassLibrary\bin\Debug\net6.0\ClassLibrary.dll");
//var assembly = Assembly.GetExecutingAssembly();



Console.Write("Enter Class Full Name: ");
string className = Console.ReadLine();
var type = assembly.GetType(className);

var instance = Activator.CreateInstance(type);
Essentials.SetFieldValue(instance);
Essentials.SetPropertyValue(instance);
Console.WriteLine("");
string json = JsonFormatter.Convert(instance);
Console.WriteLine(json);




//--- By Hard Code --- 

//CustomInput  customInput = new CustomInput();
//customInput.Name = "Tahsin";
//customInput.Age = 22;
//customInput.Salary = 00;
//customInput.TGPA = new[] { 3.57, 3.47 };
//customInput.Friends = new List<Friend>();
//Friend friend = new Friend();
//friend.Name = "Tareq";
//friend.Gender = "M";
//customInput.Friends.Add(friend);


//Console.WriteLine("");
//string json = JsonFormatter.Convert(customInput);
//Console.WriteLine(json);




