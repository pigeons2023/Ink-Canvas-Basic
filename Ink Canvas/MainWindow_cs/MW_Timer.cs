﻿using Ink_Canvas.Helpers;
using System;
using System.Diagnostics;
using System.Timers;
using System.Windows;
using MessageBox = System.Windows.MessageBox;

namespace Ink_Canvas
{
    public partial class MainWindow : Window
    {
        Timer timerCheckPPT = new Timer();
        Timer timerKillProcess = new Timer();
        Timer timerCheckAutoFold = new Timer();
        string AvailableLatestVersion = null;
        Timer timerCheckAutoUpdateWithSilence = new Timer();
        bool isHidingSubPanelsWhenInking = false; // 避免书写时触发二次关闭二级菜单导致动画不连续

        private void InitTimers()
        {
            timerCheckPPT.Elapsed += TimerCheckPPT_Elapsed;
            timerCheckPPT.Interval = 1000;
            timerKillProcess.Elapsed += TimerKillProcess_Elapsed;
            timerKillProcess.Interval = 5000;
            timerCheckAutoFold.Elapsed += timerCheckAutoFold_Elapsed;
            timerCheckAutoFold.Interval = 1500;
            timerCheckAutoUpdateWithSilence.Elapsed += timerCheckAutoUpdateWithSilence_Elapsed;
            timerCheckAutoUpdateWithSilence.Interval = 1000 * 60 * 10;
        }

        private void TimerKillProcess_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                // 希沃相关： easinote swenserver RemoteProcess EasiNote.MediaHttpService smartnote.cloud EasiUpdate smartnote EasiUpdate3 EasiUpdate3Protect SeewoP2P CefSharp.BrowserSubprocess SeewoUploadService
                string arg = "/F";
                if (Settings.Automation.IsAutoKillPptService)
                {
                    Process[] processes = Process.GetProcessesByName("PPTService");
                    if (processes.Length > 0)
                    {
                        arg += " /IM PPTService.exe";
                    }
                    processes = Process.GetProcessesByName("SeewoIwbAssistant");
                    if (processes.Length > 0)
                    {
                        arg += " /IM SeewoIwbAssistant.exe" + " /IM Sia.Guard.exe";
                    }
                }
                if (Settings.Automation.IsAutoKillEasiNote)
                {
                    Process[] processes = Process.GetProcessesByName("EasiNote");
                    if (processes.Length > 0)
                    {
                        arg += " /IM EasiNote.exe";
                    }
                }
                if (Settings.Automation.IsAutoKillZHKT)
                {
                    Process[] processes = Process.GetProcessesByName("SmartClassPad_V4");
                    if (processes.Length > 0)
                    {
                        arg += " /IM SmartClassPad_V4.exe" + " /IM YJCamera.exe" + " /IM E_Board.exe";
                    }
                }
                if (arg != "/F")
                {
                    Process p = new Process();
                    p.StartInfo = new ProcessStartInfo("taskkill", arg);
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    p.Start();

                    if (arg.Contains("EasiNote"))
                    {
                        BtnSwitch_Click(null, null);
                        MessageBox.Show("“希沃白板 5”已自动关闭");
                    }
                    if (arg.Contains("SmartClassPad_V4"))
                    {
                        BtnSwitch_Click(null, null);
                        MessageBox.Show("“智慧课堂系列软件”已自动关闭");
                    }
                }
            }
            catch { }
        }


        bool foldFloatingBarByUser = false, // 保持收纳操作不受自动收纳的控制
            unfoldFloatingBarByUser = false; // 允许用户在希沃软件内进行展开操作

        private void timerCheckAutoFold_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (isFloatingBarChangingHideMode) return;
            try
            {
                string windowProcessName = ForegroundWindowInfo.ProcessName();
                string windowTitle = ForegroundWindowInfo.WindowTitle();
                //LogHelper.WriteLogToFile("windowTitle | " + windowTitle + " | windowProcessName | " + windowProcessName);

                if (Settings.Automation.IsAutoFoldInEasiNote && windowProcessName == "EasiNote" // 希沃白板
                    && (!(windowTitle.Length == 0 && ForegroundWindowInfo.WindowRect().Height < 500) || !Settings.Automation.IsAutoFoldInEasiNoteIgnoreDesktopAnno)
                    || Settings.Automation.IsAutoFoldInEasiCamera && windowProcessName == "EasiCamera" // 希沃视频展台
                    || Settings.Automation.IsAutoFoldInEasiNote3C && windowProcessName == "EasiNote" // 希沃轻白板3C
                    || Settings.Automation.IsAutoFoldInEasiNote5C && windowProcessName == "EasiNote5C" // 希沃轻白板5C
                    || Settings.Automation.IsAutoFoldInSeewoPincoTeacher && (windowProcessName == "BoardService" || windowProcessName == "seewoPincoTeacher") // 希沃品课
                    || Settings.Automation.IsAutoFoldInHiteCamera && windowProcessName == "HiteCamera" // 鸿合视频展台
                    || Settings.Automation.IsAutoFoldInHiteTouchPro && windowProcessName == "HiteTouchPro" // 鸿合白板
                    || Settings.Automation.IsAutoFoldInWxBoardMain && windowProcessName == "WxBoardMain" // 文香白板
                    || Settings.Automation.IsAutoFoldInMSWhiteboard && (windowProcessName == "MicrosoftWhiteboard" || windowProcessName == "msedgewebview2") // 微软白板
                    || Settings.Automation.IsAutoFoldInAdmoxWhiteboard && windowProcessName == "Amdox.WhiteBoard" // 安道白板
                    || Settings.Automation.IsAutoFoldInAdmoxBooth && windowProcessName == "Amdox.Booth" // 安道展台
                    || Settings.Automation.IsAutoFoldInQPoint && windowProcessName == "QPoint" // 艺云白板
                    || Settings.Automation.IsAutoFoldInYiYunVisualPresenter && windowProcessName == "YiYunVisualPresenter" // 艺云展台
                    || Settings.Automation.IsAutoFoldInMaxHubWhiteboard && windowProcessName == "WhiteBoard" // MaxHub白板
                    || Settings.Automation.IsAutoFoldInZHKTWhiteboard && windowProcessName == "E_Board" // 智慧课堂白板
                    || Settings.Automation.IsAutoFoldInZHKTZhanTai && windowProcessName == "YJCamera" // 智慧课堂展台
                    || Settings.Automation.IsAutoFoldInOldZyBoard && // 中原旧白板
                    (WinTabWindowsChecker.IsWindowExisted("WhiteBoard - DrawingWindow")
                    || WinTabWindowsChecker.IsWindowExisted("InstantAnnotationWindow"))
                    || Settings.Automation.IsAutoFoldInZHKTZhanTai_New && // 智慧课堂展台
                    (WinTabWindowsChecker.IsWindowExisted("CamShow")))
                {
                    if (!unfoldFloatingBarByUser && !isFloatingBarFolded)
                    {
                        FoldFloatingBar_Click(null, null);
                    }
                }
                else if (WinTabWindowsChecker.IsWindowExisted("幻灯片放映", false))
                { // 处于幻灯片放映状态
                    if (!Settings.Automation.IsAutoFoldInPPTSlideShow && isFloatingBarFolded && !foldFloatingBarByUser)
                    {
                        UnFoldFloatingBar_MouseUp(null, null);
                    }
                }
                else
                {
                    if (isFloatingBarFolded && !foldFloatingBarByUser)
                    {
                        UnFoldFloatingBar_MouseUp(null, null);
                    }
                    unfoldFloatingBarByUser = false;
                }
            }
            catch { }
        }

        private void timerCheckAutoUpdateWithSilence_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                try
                {
                    if ((!Topmost) || (inkCanvas.Strokes.Count > 0)) return;
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLogToFile(ex.ToString(), LogHelper.LogType.Error);
                }
            });
            try
            {
                if (AutoUpdateWithSilenceTimeComboBox.CheckIsInSilencePeriod(Settings.Startup.AutoUpdateWithSilenceStartTime, Settings.Startup.AutoUpdateWithSilenceEndTime))
                {
                    AutoUpdateHelper.InstallNewVersionApp(AvailableLatestVersion, true);
                    timerCheckAutoUpdateWithSilence.Stop();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLogToFile(ex.ToString(), LogHelper.LogType.Error);
            }
        }
    }
}
