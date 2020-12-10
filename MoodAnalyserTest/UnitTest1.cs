using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserApp;
namespace programTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// This Test case ensure AnalyseMood() method will return when SAD when message contains Sad
        /// </summary>
        [TestMethod]
        public void GivenSadMessage_WhenSad_ShouldReturnSAD()
        {
            //Arrange
            string Expected = "SAD";
            Program program = new Program("I am in Sad Mood");
            //Act
            string result = program.AnalyseMood();
            //Assert
            Assert.AreEqual(Expected, result);
        }

        /// <summary>
        /// This Test case ensure AnalyseMood() method will return when HAPPY when message contains Happy
        /// </summary>
        [TestMethod]
        public void GivenHappyMessage_WhenAnyMood_ShouldReturnHAPPY()
        {
            //Arrange
            string Expected = "HAPPY";
            Program program = new Program("I am in Happy Mood");
            //Act
            string result = program.AnalyseMood();
            //Assert
            Assert.AreEqual(Expected, result);
        }

        /// <summary>
        /// This Test case ensure AnalyseMood() method will return when HAPPY when Any mood message is given
        /// </summary>
        [TestMethod]
        public void GivenAnyMessage_WhenAnyMood_ShouldReturnHAPPY()
        {
            //Arrange
            string Expected = "HAPPY";
            Program program = new Program("I am in Any Mood");
            //Act
            string result = program.AnalyseMood();
            //Assert
            Assert.AreEqual(Expected, result);
        }

        /// <summary>
        /// This Test case ensure AnalyseMood() method will return when HAPPY when Null mood message is given
        /// </summary>
        [TestMethod]
        [DataRow("null")]
        public void GivenNULLMessage_WhenANULL_ShouldReturnHAPPY(string message)
        {
            //Arrange
            string Expected = "Happy";
            Program moodAnalyser = new Program(message);
            //Act
            string result = moodAnalyser.AnalyseMood();
            //Assert
            Assert.AreEqual(Expected, result);
        }

        /// <summary>
        /// This Test case ensure when given empty message will throw an exception
        /// </summary>
        [TestMethod]
        [DataRow("")]
        public void GivenEmptyMessage_WhenEmpty_ShouldThrowException(string message)
        {
            try
            {
                //Arrange
                Program program = new Program(message);
                //Act
                string result = program.AnalyseMood();
                //Assert
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual("Mood should not be empty", e.Message);
            }
        }
        /// <summary>
        /// UC4-TC4.1 Proper class details are provided and expected to return the MoodAnalyser Object
        /// </summary>
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyserObject()
        {
            object expected = new Program();
            object obj = MoodAnalyserFactory.CreateeMoodAnalyse("MoodAnalyserProject.MoodAnalyser", "MoodAnalyser");
            expected.Equals(obj);
        }
    }
}
