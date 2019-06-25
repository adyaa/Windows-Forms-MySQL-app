using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod()]
        public void Test()
        {
            try
            {
            Form1 target = new Form1();
                if (Form1.ShowDialog() == DialogResult.OK)
                {
                    string a = target.TextBoxText;
                }

                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

    }


}

