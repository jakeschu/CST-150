namespace CST_150_Dog_Class.BusinessLayer
{
    internal class Utility
    {
        /// <summary>
        /// Utility that returns false if the paramter string is null, empty, or just contains what spaces.
        /// </summary>
        /// <param name="textToTest"></param>
        /// <returns></returns>
        public bool NotNull(string textToTest)
        {
            if (String.IsNullOrWhiteSpace(textToTest))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Tests to determine if a valid double was entered.
        /// If true the string is parsed to double and true is returned.
        /// if false, -1 is returned and false for bool.
        /// This return type is called a Tuple.
        /// </summary>
        /// <param name="valueToTest"></param>
        /// <returns></returns>
        public(double doublValue, bool isConverted) ValidDouble(string valueToTest)
        {
            double convertValue = 0.00D;
            if(double.TryParse(valueToTest, out convertValue))
            {
                return (convertValue, true);
            }
            return(-1D, false);
        }

        public bool ConvertToBool(string YesOrNo)
        {
            if(YesOrNo == "Yes")
            {
                return true;
            }
            return false;
        }
    }
}
