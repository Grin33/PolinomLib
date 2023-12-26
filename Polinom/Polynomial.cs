using System.Text;

namespace Polinom;

//В конструктор принимает коэффиценты полинома
//Пример:
//int[] coefficients = { 3, 2, 5, 6, 8 };
//List<int> coefficients = new List<int> { 3, 2, 5, 6, 8 };
public class Polynomial(int[] coefficients)
{
  private readonly int[] coefficients = coefficients;

  public Polynomial(IEnumerable<int> coefficients)
  : this(coefficients.ToArray())
  {
  }
  
  public Polynomial Add(Polynomial other, int modulus)
  {
    var maxLength = Math.Max(coefficients.Length, other.coefficients.Length);
    var resultCoefficients = new int[maxLength];

    for (var i = 0; i < maxLength; i++)
    {
      var a = (i < coefficients.Length) ? coefficients[i] : 0;
      var b = (i < other.coefficients.Length) ? other.coefficients[i] : 0;
      resultCoefficients[i] = (a + b) % modulus;
    }

    return new Polynomial(resultCoefficients);
  }
  
  public Polynomial Subtract(Polynomial other, int modulus)
  {
    var maxLength = Math.Max(this.coefficients.Length, other.coefficients.Length);
    var resultCoefficients = new int[maxLength];

    for (var i = 0; i < maxLength; i++)
    {
      var a = (i < this.coefficients.Length) ? this.coefficients[i] : 0;
      var b = (i < other.coefficients.Length) ? other.coefficients[i] : 0;
      resultCoefficients[i] = (a - b + modulus) % modulus;
    }

    return new Polynomial(resultCoefficients);
  }
  
  public Polynomial Multiply(Polynomial other, int modulus)
  {
    var resultCoefficients = new int[this.coefficients.Length + other.coefficients.Length - 1];

    for (var i = 0; i < this.coefficients.Length; i++)
    {
      for (var j = 0; j < other.coefficients.Length; j++)
      {
        resultCoefficients[i + j] += (this.coefficients[i] * other.coefficients[j]) % modulus;
        resultCoefficients[i + j] %= modulus;
      }
    }

    return new Polynomial(resultCoefficients);
  }

  public override string ToString()
  {
    var sb = new StringBuilder();
    for (var i = 0; i < coefficients.Length; i++)
    {
      sb.Append(coefficients[i] + "x^" + i + " ");
    }

    return sb.ToString();
  }
}