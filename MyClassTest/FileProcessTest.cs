using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestingProject;
using System;
using System.Configuration;
using System.IO;

namespace UnitTestingProjectTest
{
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE_NAME = @"C:\badFile.txt";
        private string _GoodFileName;

        public TestContext TestContext { get; set; }

        #region Test Initialize and Cleanup

        [TestInitialize]
        public void TestInitialize()
        {
            if (TestContext.TestName == "FileNameDoesExists")
            {
                if (string.IsNullOrEmpty(_GoodFileName))
                {
                    SetGoodFileName();
                    TestContext.WriteLine($"Creating file: {_GoodFileName}");
                    File.AppendAllText(_GoodFileName, "Some text");
                }
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.TestName == "FileNameDoesExists")
            {
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine($"Deleting file: {_GoodFileName}");
                    File.Delete(_GoodFileName);
                }
            }
        }
        #endregion

        [TestMethod]
        [Owner("Rogerio Bento")]
        [Timeout(200)]
        public void FileNameDoesExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            TestContext.WriteLine($"Testing file: {_GoodFileName}");
            fromCall = fp.FileExists(_GoodFileName);


            Assert.IsTrue(fromCall);
        }

        public void SetGoodFileName()
        {
            _GoodFileName = ConfigurationManager.AppSettings["GoodFileName"];
            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPath]",
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }

        private const string FILE_NAME = @"FileToDeploy.txt";

        [TestMethod]
        [Owner("Rogerio Bento")]
        [DeploymentItem(FILE_NAME)]
        public void FileNameDoesExistsUsingDeploymentItem()
        {
            FileProcess fp = new FileProcess();
            string fileName;
            bool fromCall;

            fileName = $@"{TestContext.DeploymentDirectory}\{FILE_NAME}";

            TestContext.WriteLine($"Checking file: {fileName}");
            fromCall = fp.FileExists(fileName);


            Assert.IsTrue(fromCall);
        }


        [TestMethod]
        [Owner("Rogerio Bento")]
        public void FileNameDoesNotExists()
        {
            FileProcess fp = new FileProcess();
            bool fromCall;

            fromCall = fp.FileExists(BAD_FILE_NAME);

            Assert.IsFalse(fromCall);
        }

        [TestMethod]
        [Owner("Rogerio Bento")]
        [ExpectedException(typeof(ArgumentNullException))]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            FileProcess fp = new FileProcess();

            fp.FileExists("");


        }

        [TestMethod]
        [Owner("Rogerio Bento")]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException_UsingTryCatch()
        {
            FileProcess fp = new FileProcess();
            try
            {
                fp.FileExists("");
            }
            catch (ArgumentNullException)
            {
                //The test was a Success!
                return;
            }

            Assert.Fail("Fail expected");
        }
    }
}
