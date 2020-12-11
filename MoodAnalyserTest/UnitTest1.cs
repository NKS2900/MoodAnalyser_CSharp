using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserApp;
namespace programTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// This Test case ensure AnalyseMood() 
        /// </summary>
        [TestMethod]
        public void GivenSadMessage_WhenSad_ShouldReturnSAD()
        {
            string Expected = "SAD";
            Program program = new Program("I am in Sad Mood");
            string result = program.AnalyseMood();
            Assert.AreEqual(Expected, result);
        }
        /// <summary>
        ///  method will return when HAPPY when message contains Happy
        /// </summary>
        [TestMethod]
        public void GivenHappyMessage_WhenAnyMood_ShouldReturnHAPPY()
        {
            string Expected = "HAPPY";
            Program program = new Program("I am in Happy Mood");
            string result = program.AnalyseMood();
            Assert.AreEqual(Expected, result);
        }
        /// <summary>
        /// method will return when HAPPY when Any mood message is given
        /// </summary>
        [TestMethod]
        public void GivenAnyMessage_WhenAnyMood_ShouldReturnHAPPY()
        {
            string Expected = "HAPPY";
            Program program = new Program("I am in Any Mood");
            string result = program.AnalyseMood();
            Assert.AreEqual(Expected, result);
        }
        /// <summary>
        /// method will return when HAPPY when Null mood message is given
        /// </summary>
        [TestMethod]
        [DataRow("null")]
        public void GivenNULLMessage_WhenANULL_ShouldReturnHAPPY(string message)
        {
            string Expected = "Happy";
            Program moodAnalyser = new Program(message);
            string result = moodAnalyser.AnalyseMood();
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
                Program program = new Program(message);
                string result = program.AnalyseMood();
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
            object obj = MoodAnalyserFactory.CreateMoodAnalyse("MoodAnalyserApp.Program", "Program");
            expected.Equals(obj);
        }
        /// <summary>
        /// UC5-TC5.1 Proper message are provided to parameterized constructor and expected to return the MoodAnalyser Object
        /// </summary>
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyserObject_UsingParameterizdConstructor()
        {
            object expected = new Program("HAPPY");
            object obj = MoodAnalyserFactory.CreateMoodAnalyserUsingParameterizedConstructor("MoodAnalyserApp.Program", "Program", "HAPPY");
            expected.Equals(obj);
        }
        /// <summary>
        /// UC6-TC6-1 Given Happy Should Return Happy.
        /// </summary>
        [TestMethod]
        public void GiveHappyMoodShouldReturnHappy()
        {
            string expected = "HAPPY";
            string mood = MoodAnalyserFactory.InvokeAnalyseMood("Happy", "AnalyseMood");
            Assert.AreEqual(expected, mood);
        }
        /// <summary>
        /// UC7-TC7.1 Given Happy Should Return Happy
        /// </summary>
        [TestMethod]
        public void Given_HAPPYMessag_WithReflector_should_ReturnHAPPY()
        {
            string result = MoodAnalyserFactory.SetField("HAPPY", "message");
            Assert.AreEqual("HAPPY", result);
        }
    }
}
