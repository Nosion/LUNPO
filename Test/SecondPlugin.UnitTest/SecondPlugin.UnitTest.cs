using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoSavePlugin;



namespace SecondPlugin.UnitTest
{
    [TestClass]
    public class SecondPluginTest
    {
        [TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        public void SecondPlugin_Console_Do_Test()
        {
            AutoSavePlugin.AutoSave autoSavePlugin = new AutoSavePlugin.AutoSave();
            //autoSavePlugin.DoAutoSave();
            

        }
    }
}
