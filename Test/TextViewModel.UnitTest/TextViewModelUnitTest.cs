using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesktopClient.ViewModel;
using DesktopClient.Framework;
using System.Collections.Generic;
using PluginContracts;

namespace LUNPO.DesktopClient.UnitTest
{
    [TestClass]
    public class TextViewModelTest
    {

        [TestMethod]
        public void SaveAsTest()
        {
            PluginInit pluginInit = new PluginInit();
            TextViewModel textViewModel = new TextViewModel(new Dictionary<string, IPlugin>());

            Type t = typeof(TextViewModel);
                Assert.IsTrue(t.IsAbstract);
            

           //  textViewModel.SaveAsDlg
        }
    }
}
