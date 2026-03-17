using System.Reflection;

class Program
{
    public static void Main()
    {
        Assembly assembly = Assembly.GetExecutingAssembly(); //Give me information about the program that is running right now.
        Assembly.Load("MyLibrary");//by its name Load a library that the program already knows about.
        Assembly.LoadFrom("MyPlugin.dll");//Loads an assembly from a specific file path from specific this location
        MethodInfo method = type.GetMethod("Work");//type represents metadata information of a class 
        method.Invoke(obj, null);//Invoke is used to execute the method dynamically. and null indicates that method does not takes any parameters

        PropertyInfo prop = type.GetProperty("Name");
        prop.SetValue(obj, "Jhon");//SetValue() is used to assign a value to a property dynamically. and object(obj) whose property will be updated 
        //This code uses Reflection to locate a property named Name at runtime and assign it a value dynamically using PropertyInfo.

        FieldInfo field = type.GetField("_salary", BindingFlags.NonPublic | BindingFlags.Instance);//It retrieves metadata about a private instance field named _salary from the given class and stores it in a FieldInfo object.
        //BlindingFlags -> looks for the field that belong to an object (instance), not the class itself.

        ConstructorInfo ctor = type.GetConstructor(Type.EmptyTypes);//emptytypes means having no parameters...
        Object obj = ctor.Invoke(null);//Invoke() calls the constructor dynamically. with null means no arguments are passed inside the constructor.

        //this is for the parameteriesed Constructor
        ConstructorInfo ctor = type.GetConstructor(new Type[] { typeof(string), typeof(int) });
        ParameterInfo[] parameters = method.GetParameters();//GetParameters() fetches all parameters of the method.

        Assembly assembly = Assembly.GetExecutingAssembly();

        //This program scans the current program, finds all classes, and prints the names of all methods inside each class using Reflection.
        foreach (Type type in assembly.GetTypes())//Assembly represents a compiled program unit and getType retrieves all types inside the assembly
        {
            Console.WriteLine("Class: " + type.Name);//it will give the name of the class/type

            foreach (MethodInfo method in type.GetMethods())
            {
                Console.WriteLine("  Method: " + method.Name);
            }
        }





    }

}

/*
 Imports the Reflection namespace gives access to:
    Assembly
    Type
    MethodInfo
    PropertyInfo
    Without this, the program cannot work with assemblies or reflection features.

    
    PropertyInfo represents metadata about a property of a class, including its type and accessors. It read and write property values dynamically at runtime


    ConstructorInfo represents metadata about constructors of a type.
    It allows dynamic object creation without using the new keyword.

    Reflexion is required when types are not known at Compiles Time

 */