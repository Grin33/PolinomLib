using Polinom;

int[] coefficients1 = { 3, 2, 5, 6, 8 };
int[] coefficients2 = { 1, 4, 2, 7, 9 };

var p1 = new Polynomial(coefficients1);

var p2 = new Polynomial(coefficients2);

var sum = p1.Add(p2, 10);
Console.WriteLine(sum.ToString());