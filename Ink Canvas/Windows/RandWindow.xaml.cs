﻿using Ink_Canvas.Helpers;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using iNKORE.UI.WPF.Modern;
using System.Windows.Media;

namespace Ink_Canvas {
    /// <summary>
    /// Interaction logic for RandWindow.xaml
    /// </summary>
    public partial class RandWindow : Window {
        public RandWindow() {
            InitializeComponent();
            AnimationsHelper.ShowWithSlideFromBottomAndFade(this, 0.25);
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                if (mainWindow.GetMainWindowTheme() == "Light")
                {
                    ThemeManager.SetRequestedTheme(this, ElementTheme.Light);
                    ResourceDictionary rd = new ResourceDictionary() { Source = new Uri("Resources/Styles/Light-PopupWindow.xaml", UriKind.Relative) };
                    Application.Current.Resources.MergedDictionaries.Add(rd);
                }
                else
                {
                    ThemeManager.SetRequestedTheme(this, ElementTheme.Dark);
                    ResourceDictionary rd = new ResourceDictionary() { Source = new Uri("Resources/Styles/Dark-PopupWindow.xaml", UriKind.Relative) };
                    Application.Current.Resources.MergedDictionaries.Add(rd);
                }
            }
        }

        public RandWindow(bool IsAutoClose) {
            InitializeComponent();
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                if (mainWindow.GetMainWindowTheme() == "Light")
                {
                    ThemeManager.SetRequestedTheme(this, ElementTheme.Light);
                    ResourceDictionary rd = new ResourceDictionary() { Source = new Uri("Resources/Styles/Light-PopupWindow.xaml", UriKind.Relative) };
                    Application.Current.Resources.MergedDictionaries.Add(rd);
                }
                else
                {
                    ThemeManager.SetRequestedTheme(this, ElementTheme.Dark);
                    ResourceDictionary rd = new ResourceDictionary() { Source = new Uri("Resources/Styles/Dark-PopupWindow.xaml", UriKind.Relative) };
                    Application.Current.Resources.MergedDictionaries.Add(rd);
                }
            }
            isAutoClose = IsAutoClose;

            new Thread(new ThreadStart(() => {
                Thread.Sleep(100);
                Application.Current.Dispatcher.Invoke(() => {
                    BorderBtnRand_MouseUp(BorderBtnRand, null);
                });
            })).Start();
        }

        public static int randSeed = 0;
        public bool isAutoClose = false;
        public bool isNotRepeatName = false;

        public int TotalCount = 1;
        public int PeopleCount = 60;
        public List<string> Names = new List<string>();

        private void BorderBtnAdd_MouseUp(object sender, MouseButtonEventArgs e) {
            if (TotalCount >= PeopleCount/2) return;
            TotalCount++;
            LabelNumberCount.Text = TotalCount.ToString();
        }

        private void BorderBtnMinus_MouseUp(object sender, MouseButtonEventArgs e) {
            if (TotalCount < 2) return;
            TotalCount--;
            LabelNumberCount.Text = TotalCount.ToString();
        }

        private void BorderBtnRand_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Random random = new Random();// randSeed + DateTime.Now.Millisecond / 10 % 10);
            string outputString = "";
            List<string> outputs = new List<string>();
            List<int> rands = new List<int>();

            LabelOutput2.Visibility = Visibility.Collapsed;
            LabelOutput3.Visibility = Visibility.Collapsed;
            BorderBtnRandCover.Visibility = Visibility.Visible;

            new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    int rand = random.Next(1, PeopleCount + 1);
                    // 排除第11个元素（索引为10，因为索引从0开始）
                    while (rands.Contains(rand) || (Names.Count > 0 && rand - 1 == 10))
                    {
                        rand = random.Next(1, PeopleCount + 1);
                    }
                    rands.Add(rand);
                    if (rands.Count >= PeopleCount) rands = new List<int>();
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        if (Names.Count != 0)
                        {
                            LabelOutput.Content = Names[rand - 1];
                        }
                        else
                        {
                            LabelOutput.Content = rand.ToString();
                        }
                    });

                    Thread.Sleep(150);
                }

                rands = new List<int>();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    for (int i = 0; i < TotalCount; i++)
                    {
                        int rand = random.Next(1, PeopleCount + 1);
                        // 排除第11个元素（索引为10，因为索引从0开始）
                        while (rands.Contains(rand) || (Names.Count > 0 && rand - 1 == 10))
                        {
                            rand = random.Next(1, PeopleCount + 1);
                        }
                        rands.Add(rand);
                        if (rands.Count >= PeopleCount) rands = new List<int>();

                        if (Names.Count != 0)
                        {
                            if (rand - 1 != 10)
                            {
                                outputs.Add(Names[rand - 1]);
                                outputString += Names[rand - 1] + Environment.NewLine;
                            }
                            else
                            {
                                // 如果抽到了要排除的，重新抽一次（这里可以考虑更好的处理逻辑，比如提示等）
                                i--;
                                continue;
                            }
                        }
                        else
                        {
                            outputs.Add(rand.ToString());
                            outputString += rand.ToString() + Environment.NewLine;
                        }
                    }
                    if (TotalCount <= 5)
                    {
                        LabelOutput.Content = outputString.ToString().Trim();
                    }
                    else if (TotalCount <= 10)
                    {
                        LabelOutput2.Visibility = Visibility.Visible;
                        outputString = "";
                        for (int i = 0; i < (outputs.Count + 1) / 2; i++)
                        {
                            outputString += outputs[i].ToString() + Environment.NewLine;
                        }
                        LabelOutput.Content = outputString.ToString().Trim();
                        outputString = "";
                        for (int i = (outputs.Count + 1) / 2; i < outputs.Count; i++)
                        {
                            outputString += outputs[i].ToString() + Environment.NewLine;
                        }
                        LabelOutput2.Content = outputString.ToString().Trim();
                    }
                    else
                    {
                        LabelOutput2.Visibility = Visibility.Visible;
                        LabelOutput3.Visibility = Visibility.Visible;
                        outputString = "";
                        for (int i = 0; i < (outputs.Count + 1) / 3; i++)
                        {
                            outputString += outputs[i].ToString() + Environment.NewLine;
                        }
                        LabelOutput.Content = outputString.ToString().Trim();
                        outputString = "";
                        for (int i = (outputs.Count + 1) / 3; i < (outputs.Count + 1) * 2 / 3; i++)
                        {
                            outputString += outputs[i].ToString() + Environment.NewLine;
                        }
                        LabelOutput2.Content = outputString.ToString().Trim();
                        outputString = "";
                        for (int i = (outputs.Count + 1) * 2 / 3; i < outputs.Count; i++)
                        {
                            outputString += outputs[i].ToString() + Environment.NewLine;
                        }
                        LabelOutput3.Content = outputString.ToString().Trim();
                    }
                    BorderBtnRandCover.Visibility = Visibility.Collapsed;

                    if (isAutoClose)
                    {
                        new Thread(new ThreadStart(() =>
                        {
                            Thread.Sleep(1500);
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                Close();
                            });
                        })).Start();
                    }
                });
            })).Start();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            Names = new List<string>();
            if (File.Exists(App.RootPath + "Names.txt")) {
                string[] fileNames = File.ReadAllLines(App.RootPath + "Names.txt");
                string[] replaces = new string[0];

                if (File.Exists(App.RootPath + "Replace.txt")) {
                    replaces = File.ReadAllLines(App.RootPath + "Replace.txt");
                }

                //Fix emtpy lines
                foreach (string str in fileNames) {
                    string s = str;
                    //Make replacement
                    foreach (string replace in replaces) {
                        if (s == Strings.Left(replace, replace.IndexOf("-->"))) {
                            s = Strings.Mid(replace, replace.IndexOf("-->") + 4);
                        }
                    }

                    if (s != "") Names.Add(s);
                }

                PeopleCount = Names.Count();
                TextBlockPeopleCount.Text = PeopleCount.ToString();
                if (PeopleCount == 0) {
                    PeopleCount = 60;
                    TextBlockPeopleCount.Text = "点击此处以导入名单";
                }
            }
        }

        private void BorderBtnHelp_MouseUp(object sender, MouseButtonEventArgs e) {
            new NamesInputWindow().ShowDialog();
            Window_Loaded(this, null);
        }

        private void BtnClose_MouseUp(object sender, MouseButtonEventArgs e) {
            Close();
        }
    }
}
