namespace TimeCo_UnitTest
{
    public class Tests
    {
        private TimeCo.Utilities.Converter _converter;

        public Tests()
        {
            _converter = new TimeCo.Utilities.Converter();
        }

        [SetUp]
        public void Setup()
        {
         
        }

        [Test]
        public void DateOnlyTest()
        {
            // Arrange
            DateTime dateTime = DateTime.Now;
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);

            // Act
            string actual = _converter.DateOnly(dateTime);
            string expected = currentDate.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToDateTest()
        {
            // Arrange
            string dateString = "31-12-2022";
            DateTime expected = new DateTime(2022, 12, 31);

            // Act
            DateTime actual = _converter.ToDate(dateString);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ToHourTest()
        {
            // Arrange
            string timeString = "3:30";
            TimeSpan expected = new TimeSpan(3, 30, 0);

            // Act
            TimeSpan actual = _converter.ToHour(timeString);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetDaysVacationTest()
        {
            // Arrange
            DateTime startDate = new DateTime(2023, 5, 1);
            DateTime endDate = new DateTime(2023, 5, 10);

            // Act
            double result = _converter.GetDaysVacation(startDate, endDate);

            // Assert
            Assert.AreEqual(8, result);
        }
    }
}