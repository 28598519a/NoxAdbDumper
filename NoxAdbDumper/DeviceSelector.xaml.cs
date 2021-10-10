using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace NoxAdbDumper
{
    /// <summary>
    /// DeviceSelector.xaml 的互動邏輯
    /// </summary>
    public partial class DeviceSelector : Window
    {
        public DeviceSelector()
        {
            InitializeComponent();
        }

        public string input;
        public string output = "";
        private void DeviceSelector_Loaded(object sender, RoutedEventArgs e)
        {
            StringReader sr = new StringReader(input);
            List<string> lines = new List<string>();
            string line;
            while ((line = sr.ReadLine()) != null)
                lines.Add(line);
            foreach (string l in lines)
            {
                string[] tokens = Regex.Split(l.Trim(), "\\s+");
                if (tokens[0] == "TCP" && tokens[1].StartsWith("127.0.0.1:62") && tokens[2] == "0.0.0.0:0")
                {
                    int pid = Convert.ToInt32(tokens[4]);
                    Process p = Process.GetProcessById(pid);
                    if (p.ProcessName.ToLower().Contains("nox"))
                        ls_device.Items.Add(l + "\t" + p.ProcessName);
                }
            }
            if (ls_device.Items.Count != 0)
                ls_device.SelectedIndex = 0;
        }

        private void btn_select_Click(object sender, RoutedEventArgs e)
        {
            int n = ls_device.SelectedIndex;
            if (n == -1)
                return;
            string[] tokens = Regex.Split(ls_device.SelectedItem.ToString().Trim(), "\\s+");
            output = tokens[1];
            this.Close();
        }
    }
}
