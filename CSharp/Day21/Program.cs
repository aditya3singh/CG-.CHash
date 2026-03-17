using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

//class Program
//{
//    public static void Main()
//    {
//        List<int> evenList = new List<int>();
//        List<int> divBy3List = new List<int>();
//        List<int> noneList = new List<int>();

//        for (int i = 1; i <= 100; i++)
//        {
//            bool added = false;

//            if (i % 2 == 0)
//            {
//                evenList.Add(i);
//                added = true;
//            }

//            if (i % 3 == 0)
//            {
//                divBy3List.Add(i);
//                added = true;
//            }

//            if (!added)
//            {
//                noneList.Add(i);
//            }
//        }

//        foreach (int i in evenList)
//            Console.WriteLine("Divisible by 2: " + i);



//        foreach (int i in divBy3List)
//            Console.WriteLine("Divisible by 3: " + i);

//        foreach (int i in noneList)
//            Console.WriteLine("Divisible by nothing: " + i);
//    }
//}


// Car company that implements the interface
// 1 interface with 6 methods

//interface IGear
//{
//    public void Gear1() { }
//    public void Gear2() { }
//    public void Gear3() { }
//    public void Gear4() { }
//    public void Gear5() { }
//    public void Reverse() { }
//}


//class Maari : IGear
//{
//    void IGear.Gear1()
//    {
//        Console.WriteLine("Gear1");
//    }
//    void IGear.Gear2()
//    {
//        Console.WriteLine("Gear2");
//    }
//    void IGear.Gear3()
//    {
//        Console.WriteLine("Gear3");
//    }
//    void IGear.Gear4()
//    {
//        Console.WriteLine("Gear4");
//    }
//    void IGear.Gear5()
//    {
//        Console.WriteLine("Gear5");
//    }
//    void IGear.Reverse()
//    {
//        Console.WriteLine("Reverse");
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Maari m = new Maari();
//        IGear g = m;
//        g.Gear1();
//        g.Gear2();
//        g.Gear3();
//        g.Gear4();
//        g.Gear5();
//        g.Reverse();

//        Console.WriteLine("All done");
//    }
//}

//using System;

//abstract class Features
//{
//    public abstract void Gear1();
//    public abstract void Gear2();
//    public abstract void Gear3();

//    public virtual void Camera()
//    {
//        Console.WriteLine("Camera");
//    }
//    public virtual void AirBag()
//    {
//        Console.WriteLine("airbag is optional");
//    }
//}

//class Maari : Features
//{
//    public override void Gear1()
//    {
//        Console.WriteLine("Gear1");
//    }
//    public override void Gear2()
//    {
//        Console.WriteLine("Gear2");
//    }
//    public override void Gear3()
//    {
//        Console.WriteLine("Gear3");
//    }
//}
//class Program
//{
//    public static void Main()
//    {
//        Maari m = new Maari();
//        m.Gear1();
//        //m.Gear2();
//        m.Gear3();
//        //m.Camera();
//        m.AirBag();
//    }
//}

class Program
{
    public delegate void DeAdd(int a, int b);
    
    public static void Main()
    {
        void Add(int a, int b)
        {
            Console.WriteLine(a + b);
        }
        void Sub(int a, int b)
        {
            Console.WriteLine(a - b);
        }

        DeAdd dA = new DeAdd(Add);
        dA += Sub;
        dA(1000, 200);
    }
}