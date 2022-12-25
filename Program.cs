using System;
using System.Diagnostics; 

namespace BasicGeometry
{

    class Shape
    {
        public virtual double Area()
        {
            Console.WriteLine("Parent ");
            return 0;
        }
    }


    class Triangle: Shape
    {

        protected double A, B, C;

        public Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        //Check if its a right traingle from its 3 sides
        //Pythagores Theorem
        static bool IsRightTriangle(double A, double B, double C)
        {
            double Eps = 0.0001;
            return Math.Abs(A * A - B * B - C * C) < Eps || Math.Abs(B * B - C * C - A * A) < Eps || Math.Abs(C * C - A * A - B * B) < Eps;
        }



        //Area of a triangle from its 3 sides
        public override double Area()
        {
            try
            {

                if( A < 0 || B < 0 || C < 0)
                {
                    throw new Exception("Triangle sides must be of positive length!");
                }
                Console.WriteLine("Is it a right triangle? " + IsRightTriangle(A, B, C).ToString());
                double s = (A + B + C) / 2;
                return Math.Abs(Math.Sqrt(s * (s - A) * (s - B) * (s - C)));
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception occured: "+ex.Message);
                return 0;
            }

        }

    }


    class Circle: Shape
    {
        protected double R;

        public Circle(double radius) { R = radius; }
        //Area of a circle from its radius
        public override double Area()
        {
            return Math.PI * Math.Pow(R, 2.0);
        }
    }




    class Tester
    {
        public static void Main(string[] args)
        {
            //Triangles
            var Tri_A = new Triangle(3, 3, 3);
            var Tri_B = new Triangle(-3, 3, 3);
            var Tri_C = new Triangle(0, 2, 2);
            var Tri_D = new Triangle(1, 1, Math.Sqrt(2));
            var Tri_E = new Triangle(Math.Sqrt(8), 2, 2);
            //Circle
            var Cir_A = new Circle(3);
            var Cir_B = new Circle(0);
            var Cir_C = new Circle(1);

            Console.WriteLine("Calculating Areas...");
            //Triangle Area testing
            Console.WriteLine("Triangle area testing: ");
            Console.WriteLine("Triangle Test 1: " + Tri_A.Area().ToString());
            Console.WriteLine("Triangle Test 2: " + Tri_B.Area().ToString());
            Console.WriteLine("Triangle Test 3: " + Tri_C.Area().ToString());
            Console.WriteLine("Triangle Test 4: " + Tri_D.Area().ToString());
            Console.WriteLine("Triangle Test 5: " + Tri_E.Area().ToString());
            //Circle Area testing
            Console.WriteLine("Circle area testing: ");
            Console.WriteLine("Circle Test 1: " + Cir_A.Area().ToString());
            Console.WriteLine("Circle Test 2: " + Cir_B.Area().ToString());
            Console.WriteLine("Circle Test 3: " + Cir_C.Area().ToString());

        }
    }



}



//SQL Command
//Assuming there is a junction table Product_Category
//with columns 'product_id' and 'category_id' linking the tables
//Product and Category in a many-to-many relationship.
/*
 * 
CREATE Product_Category_NamePair AS SELECT * FROM Product_Category;

ALTER TABLE Product_Category_NamePair
ADD Product_name VARCHAR(255), Category_name VARCHAR(255);


INSERT INTO Product_Category_NamePair (Product_name)
SELECT Product.name
FROM Product
INNER JOIN Product_Category_NamePair
ON Product.id = Product_Category_NamePair.product_id;

INSERT INTO Product_Category_NamePair (Category_name)
SELECT Category.name
FROM Category
INNER JOIN Product_Category_NamePair
ON Category.id = Product_Category_NamePair.category_id;
*
*/
