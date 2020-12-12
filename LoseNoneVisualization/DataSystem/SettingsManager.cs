﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace LosePanel.DataSystem
{
    public static class SettingsManager
    {
        /// <summary>
        /// 已选择的数据源名（ProviderName）。
        /// </summary>
        public static string SelectedDataProvider { get; set; }

        /// <summary>
        /// 数据更新频率，单位为秒。
        /// </summary>
        public static int RefreshFrequency { get; set; }

        /// <summary>
        /// 背景图片路径。
        /// </summary>
        public static string BackgroundImagePath { get; set; }

        public static void LoadOn()
        {
            if (File.Exists("settings.ini"))
            {
                XElement xd = XDocument.Load("settings.ini").Element("LosePanelSettings");

                SelectedDataProvider = xd.Element("SelectedDataProvider").Value;
                RefreshFrequency = int.Parse(xd.Element("RefreshFrequency").Value);
                BackgroundImagePath = xd.Element("BackgroundImagePath").Value;
            }
            else
            {
                //加载默认值
                SelectedDataProvider = "洛书南统计服务器";
                RefreshFrequency = 5;
            }
        }

        public static void Save()
        {
            XDocument xd = new XDocument(
                new XElement("LosePanelSettings",
                    new XElement("SelectedDataProvider", SelectedDataProvider),
                    new XElement("RefreshFrequency", RefreshFrequency.ToString()),
                    new XElement("BackgroundImagePath", BackgroundImagePath)));
            xd.Save("settings.ini");
        }
    }
}
