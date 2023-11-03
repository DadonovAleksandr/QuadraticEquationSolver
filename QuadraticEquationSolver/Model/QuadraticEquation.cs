using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquationSolver.Model;
/// <summary>
/// Квадратное уравнение y = A*x^2 + B*x + C
/// Корни уравнения y(x) = (x - x1) * (x - x2)
/// </summary>
internal class QuadraticEquation
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public QuadraticEquation()
    {
        
    }

    public double Discriminant => B * B - 4 * A * C;

    public int RootsCount => Discriminant switch
    {
        >0 => 2,
        0 => 1,
        _ => 0
    };

    public double X1 => RootsCount == 0 ? double.NaN : (-B + Math.Sqrt(Discriminant)) / (2 * A);

    public double X2 => RootsCount == 0 ? double.NaN : (-B - Math.Sqrt(Discriminant)) / (2 * A);
    

}