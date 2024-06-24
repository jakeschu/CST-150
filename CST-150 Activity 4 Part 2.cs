using System.Drawing.Text;

namespace CST_150_Methods
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Button clic event handler to execute the methods.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExecuteMethods_Click(object sender, EventArgs e)
        {
            int num1 = 2, num2 = 3, num3 = 4;
            int randomSum = 0;
            double double1 = 1.1D, double2 = 2.2D, double3 = 3.3D;
            double double4 = 4.4D, double5 = 5.5D;
            string firstString = "This is test number 82.";
            string secondString = "The sky is blue today.";
            double[] doubles = { 4.4D, 23.56D, 24.45D, 16.1D, 125.25D, 45.3D };

            SumInts(num1, num2);

            DisplayResults("Method 2: Average of 5 doubles is: " + AvgValue(double1, double2, double3, double4, double5), false);

            randomSum = RandomInt();
            DisplayResults(string.Format("Method 3: Sum of randoms ints: {0}", randomSum.ToString()), false);

            bool isDivisibleByTwo = DivByTwo(num1, num2, num3);
            DisplayResults("Method 4: Is sum of 3 ints div by two: " + isDivisibleByTwo, false);

            FewestChars(firstString, secondString);

            double maxDouble = LargestDouble(doubles);
            DisplayResults(string.Format("Method 6: Largest Double: {0}", maxDouble.ToString()), false);

            int[] intArray = GenerateIntArray();
            DisplayResults("Method 7: Generated integer array: " + string.Join(", ", intArray), false);

            bool boolComparisonResult = CompareBools(true, false);
            DisplayResults("Method 8: Comparison of two bools: " + boolComparisonResult, false);

            double product = MultiplyIntAndDouble(num1, double1);
            DisplayResults("Method 9: Product of int and double: " + product, false);
        }

        /// <summary>
        /// Write a method that takes two integers and displays their sum with descriptive text.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        private void SumInts(int num1, int num2)
        {
            int sum = num1 + num2;

            DisplayResults("Method 1: The sum of " + num1 + "+" + num2 + "=" + sum, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="descText"></param>
        /// <param name="clearLabel"></param>
        private void DisplayResults(string descText, bool clearLabel)
        {
            if(clearLabel)
            {
                lblResults.Text = "";
            }
            lblResults.Text += string.Format("{0}\n", descText);
        }

        /// <summary>
        /// Find the average of the five doubles and then return average.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="num3"></param>
        /// <param name="num4"></param>
        /// <param name="num5"></param>
        /// <returns></returns>
        private double AvgValue(double num1, double num2, double num3, double num4, double num5)
        {
            const double AvgDenominator = 5.0D;
            // Find the average of the 5 doubles.
            return((num1 + num2 + num3 + num4 + num5) / AvgDenominator);

        }

        private int RandomInt()
        {
            int num1 = 0, num2 = 0, sum = 0;

            Random rand = new Random();

            num1 = rand.Next(1, 101);
            num2 = rand.Next(1, 101);

            sum = num1 + num2;
            return sum;
        }

        private bool DivByTwo(int num1, int num2, int num3)
        {
            int sum = num1 + num2 + num3;

            if(sum%2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Write a method that takes two string and displays the string that has the fewer letters with descriptive text. 
        /// </summary>
        /// <param name="strng1"></param>
        /// <param name="string2"></param>
        private void FewestChars(string string1, string string2)
        {
            int countChar1 = 0, countChar2 = 0, pointer = 0;

            do
            {
                // string1 -> Try and test if the char being pointed to is a letter.
                try
                {
                    //Test if char is a letter
                    if (char.IsLetter(string1[pointer]))
                    {
                        countChar1++;
                    }
                }
                catch(Exception e)
                {
                    //String1 is at the end of length.
                }
                //string2 -> Try and test if the char being pointed to is a letter.
                try
                {
                    if (char.IsLetter(string2[pointer]))
                    {
                        countChar2++;
                    }
                }
                catch(Exception e)
                {
                    //String2 is at the end of length.
                }
                pointer++;
            }
            while ((pointer < string1.Length) || (pointer < string2.Length));

            if (countChar1 < countChar2)
            {
                DisplayResults("Method 5: string 1 has fewer letters", false);
            }
            else if (countChar2 < countChar1)
            {
                DisplayResults("Method 5: string 2 has fewer letters", false);
            }
            else
            {
                DisplayResults("Method 5: Both strings have the same number of letters", false);
            }
        }

        /// <summary>
        /// Write a method that takes an array of doubles and returns the largest value in the array.
        /// </summary>
        /// <param name="arrDoubles"></param>
        /// <returns></returns>
        private double LargestDouble(double[] arrDoubles)
        {
            int arrPointer = 0;
            double valueAtIndex = 0D;
            double biggestDouble = 0D;

            while(arrPointer < arrDoubles.Length )
            {
                valueAtIndex = arrDoubles[arrPointer]; 
                
                if(valueAtIndex > biggestDouble)
                {
                    biggestDouble = valueAtIndex;
                }  
                arrPointer++;
            }
            return biggestDouble;
        }

        /// <summary>
        /// Generates an array of ten integer values and returns it.
        /// </summary>
        /// <returns></returns>
        private int[] GenerateIntArray()
        {
            int[] intArray = new int[10];
            Random rand = new Random();

            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = rand.Next(1, 101); // Generate random integers between 1 and 100
            }

            return intArray;
        }

        /// <summary>
        /// Takes two bool variables and returns true if they have the same value, false otherwise.
        /// </summary>
        /// <param name="bool1"></param>
        /// <param name="bool2"></param>
        /// <returns></returns>
        private bool CompareBools(bool bool1, bool bool2)
        {
            return bool1 == bool2;
        }

        /// <summary>
        /// Takes an int and a double and returns their product.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        private double MultiplyIntAndDouble(int num1, double num2)
        {
            return num1 * num2;
        }
    }
}
