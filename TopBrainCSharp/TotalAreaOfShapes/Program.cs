using System;

public interface iarea
{
    double getarea();
}

public abstract class shape : iarea
{
    public abstract double getarea();
}

public class circle : shape
{
    private double r;

    public circle(double r)
    {
        this.r = r;
    }

    public override double getarea()
    {
        return Math.PI * r * r;
    }
}

public class rectangle : shape
{
    private double w;
    private double h;

    public rectangle(double w, double h)
    {
        this.w = w;
        this.h = h;
    }

    public override double getarea()
    {
        return w * h;
    }
}

public class triangle : shape
{
    private double b;
    private double h;

    public triangle(double b, double h)
    {
        this.b = b;
        this.h = h;
    }

    public override double getarea()
    {
        return 0.5 * b * h;
    }
}

public class solution
{
    public static double computetotalarea(string[] shapes)
    {
        double total = 0;

        foreach (string s in shapes)
        {
            string[] parts = s.Split(' ');
            char type = parts[0][0];

            shape obj = null;

            if (type == 'C')
            {
                double r = double.Parse(parts[1]);
                obj = new circle(r);
            }
            else if (type == 'R')
            {
                double w = double.Parse(parts[1]);
                double h = double.Parse(parts[2]);
                obj = new rectangle(w, h);
            }
            else if (type == 'T')
            {
                double b = double.Parse(parts[1]);
                double h = double.Parse(parts[2]);
                obj = new triangle(b, h);
            }

            if (obj != null)
            {
                total += obj.getarea();
            }
        }

        return Math.Round(total, 2, MidpointRounding.AwayFromZero);
    }
}
