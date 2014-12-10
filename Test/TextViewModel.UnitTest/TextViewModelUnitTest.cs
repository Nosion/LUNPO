using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesktopClient.ViewModel;
using DesktopClient.Framework;
using System.Collections.Generic;
using PluginContracts;
using DesktopClient.ViewModel;

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

          //  textViewModel.SaveAsDlg
        }
    }
}
