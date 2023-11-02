using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquationSolver.Model;

internal class QuadraticEquation
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public QuadraticEquation(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }

    public double Discriminant()
    {
        return B * B - 4 * A * C;
    }

    public double? X1()
    {
        if (Discriminant() < 0)
            return null;
        return (-B + Math.Sqrt(Discriminant())) / (2 * A);
    }

    public double? X2()
    {
        if (Discriminant() < 0)
            return null;
        return (-B - Math.Sqrt(Discriminant())) / (2 * A);
    }   
}