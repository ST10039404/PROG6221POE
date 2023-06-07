namespace POETesting
{
    [TestClass]
    public class POETest
    {
        [TestMethod]
        public void CalculateCalorieTest()
        {
            int a = 30;
            int b = 60;
            int c = 90;

            object[,] dummyArray = new object[3, 6] { {-1, -1, -1, -1, a, -1}, { -1, -1, -1, -1, b, -1 }, { -1, -1, -1, -1, c, -1 } };
            int actual = ConsoleRecipe.calculateCalories(dummyArray);
            int expected = a + b + c;

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void CalorieMessageTest()
        {
            int caloriesToCheck = 301;

            String actual = ConsoleRecipe.checkCalories(caloriesToCheck);
            String expected = "NOTICE: The total calories for this recipe exceeds 300";
            
            Assert.AreEqual(expected, actual);
        }
    }
}