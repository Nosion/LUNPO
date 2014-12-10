using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecondPlugin;



namespace SecondPlugin.UnitTest
{
    [TestClass]
    public class UnitTest_SecondPlugin
    {
        [TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        public void SecondPlugin_Console_Do_Test()
        {
            SecondPlugin.AutoSavePlugin autoSavePlugin = new SecondPlugin.AutoSavePlugin();
            //autoSavePlugin.DoAutoSave();
            

        }
    }
}
