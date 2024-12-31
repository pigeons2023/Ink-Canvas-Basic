﻿using Ink_Canvas.Helpers;
using Newtonsoft.Json;
using OSVersionExtension;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using File = System.IO.File;

namespace Ink_Canvas
{
    public partial class MainWindow : Window
    {
        #region Behavior

        private void ToggleSwitchIsAutoUpdate_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Startup.IsAutoUpdate = ToggleSwitchIsAutoUpdate.IsOn;
            IsAutoUpdateWithSilenceBlock.Visibility = ToggleSwitchIsAutoUpdate.IsOn ? Visibility.Visible : Visibility.Collapsed;
            SaveSettingsToFile();
        }

        private void RunAsUserButton_Click(object sender, RoutedEventArgs e)
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            if (principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                Process.Start("explorer.exe", Assembly.GetEntryAssembly().Location);

                CloseIsFromButton = true;
                Application.Current.Shutdown();
            }
        }

        private void RunAsAdminButton_Click(object sender, RoutedEventArgs e)
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                var file = new FileInfo(Assembly.GetExecutingAssembly().Location);
                var exe = Path.Combine(file.DirectoryName, file.Name.Replace(file.Extension, "") + ".exe");

                var proc = new Process
                {
                    StartInfo = {
                        FileName = exe,
                        Verb = "runas",
                        UseShellExecute = true,
                        Arguments = "-m"
                    }
                };
                proc.Start();

                CloseIsFromButton = true;
                Application.Current.Shutdown();
            }
        }

        private void ToggleSwitchIsAutoUpdateWithSilence_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Startup.IsAutoUpdateWithSilence = ToggleSwitchIsAutoUpdateWithSilence.IsOn;
            AutoUpdateTimePeriodBlock.Visibility = Settings.Startup.IsAutoUpdateWithSilence ? Visibility.Visible : Visibility.Collapsed;
            SaveSettingsToFile();
        }

        private void ToggleSwitchIsAutoUpdateWithProxy_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Startup.IsAutoUpdateWithProxy = ToggleSwitchIsAutoUpdateWithProxy.IsOn;
            AutoUpdateWithProxy_Title.Visibility = Settings.Startup.IsAutoUpdateWithProxy ? Visibility.Visible : Visibility.Collapsed;
            SaveSettingsToFile();
        }

        private void AutoUpdateProxyTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Startup.AutoUpdateProxy = AutoUpdateProxyTextBox.Text;
            SaveSettingsToFile();
        }

        private void BtnResetAutoUpdateProxyToGHProxy_Click(object sender, RoutedEventArgs e)
        {
            AutoUpdateProxyTextBox.Text = "https://mirror.ghproxy.com/";
        }

        private async void BtnCheckAutoUpdateProxyReturnedData_Click(object sender, RoutedEventArgs e)
        {
            string ProxyReturnedData = await AutoUpdateHelper.GetRemoteVersion(Settings.Startup.AutoUpdateProxy + "https://raw.githubusercontent.com/InkCanvas/Ink-Canvas-Basic/master/AutomaticUpdateVersionControl.txt");
            ShowNotificationAsync(ProxyReturnedData);
        }

        private void AutoUpdateWithSilenceStartTimeComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Startup.AutoUpdateWithSilenceStartTime = (string)AutoUpdateWithSilenceStartTimeComboBox.SelectedItem;
            SaveSettingsToFile();
        }

        private void AutoUpdateWithSilenceEndTimeComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Startup.AutoUpdateWithSilenceEndTime = (string)AutoUpdateWithSilenceEndTimeComboBox.SelectedItem;
            SaveSettingsToFile();
        }

        private void ToggleSwitchRunAtStartup_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            if (ToggleSwitchRunAtStartup.IsOn)
            {
                StartAutomaticallyDel("InkCanvas");
                StartAutomaticallyDel("Ink Canvas Annotation");
                StartAutomaticallyDel("Ink Canvas Artistry");
                StartAutomaticallyCreate("Ink Canvas Basic");
            }
            else
            {
                StartAutomaticallyDel("InkCanvas");
                StartAutomaticallyDel("Ink Canvas Annotation");
                StartAutomaticallyDel("Ink Canvas Artistry");
                StartAutomaticallyCreate("Ink Canvas Basic");
            }
        }

        private void ToggleSwitchFoldAtStartup_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Startup.IsFoldAtStartup = ToggleSwitchFoldAtStartup.IsOn;
            SaveSettingsToFile();
        }

        private void ToggleSwitchSupportPowerPoint_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;

            Settings.PowerPointSettings.PowerPointSupport = ToggleSwitchSupportPowerPoint.IsOn;
            SaveSettingsToFile();

            if (Settings.PowerPointSettings.PowerPointSupport)
            {
                timerCheckPPT.Start();
            }
            else
            {
                timerCheckPPT.Stop();
            }
        }

        private void ToggleSwitchShowCanvasAtNewSlideShow_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;

            Settings.PowerPointSettings.IsShowCanvasAtNewSlideShow = ToggleSwitchShowCanvasAtNewSlideShow.IsOn;
            SaveSettingsToFile();
        }

        #endregion

        #region Startup

        private void ToggleSwitchEnableNibMode_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            if (sender == ToggleSwitchEnableNibMode)
            {
                BoardToggleSwitchEnableNibMode.IsOn = ToggleSwitchEnableNibMode.IsOn;
            }
            else
            {
                ToggleSwitchEnableNibMode.IsOn = BoardToggleSwitchEnableNibMode.IsOn;
            }
            Settings.Startup.IsEnableNibMode = ToggleSwitchEnableNibMode.IsOn;

            if (Settings.Startup.IsEnableNibMode)
            {
                BoundsWidth = Settings.Advanced.NibModeBoundsWidth;
            }
            else
            {
                BoundsWidth = Settings.Advanced.FingerModeBoundsWidth;
            }
            SaveSettingsToFile();
        }
        #endregion

        #region Appearance
        private void ToggleSwitchEnableDisPlayFloatBarText_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Appearance.IsEnableDisPlayFloatBarText = ToggleSwitchEnableDisPlayFloatBarText.IsOn;
            SaveSettingsToFile();
            LoadSettings();
        }

        private void ToggleSwitchEnableDisPlayNibModeToggle_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Appearance.IsEnableDisPlayNibModeToggler = ToggleSwitchEnableDisPlayNibModeToggle.IsOn;
            SaveSettingsToFile();
            LoadSettings();
        }

        private void ToggleSwitchIsColorfulViewboxFloatingBar_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Appearance.IsColorfulViewboxFloatingBar = ToggleSwitchColorfulViewboxFloatingBar.IsOn;
            SaveSettingsToFile();
            LoadSettings();
        }

        private void ToggleSwitchEnableViewboxFloatingBarScaleTransform_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Appearance.EnableViewboxFloatingBarScaleTransform = ToggleSwitchEnableViewboxFloatingBarScaleTransform.IsOn;
            SaveSettingsToFile();
            LoadSettings();
        }

        private void ToggleSwitchEnableViewboxBlackBoardScaleTransform_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Appearance.EnableViewboxBlackBoardScaleTransform = ToggleSwitchEnableViewboxBlackBoardScaleTransform.IsOn;
            SaveSettingsToFile();
            LoadSettings();
        }

        private void ToggleSwitchShowButtonPPTNavigationBottom_OnToggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.PowerPointSettings.IsShowPPTNavigationBottom = ToggleSwitchShowButtonPPTNavigationBottom.IsOn;
            PptNavigationBottomBtn.Visibility = Settings.PowerPointSettings.IsShowPPTNavigationBottom ? Visibility.Visible : Visibility.Collapsed;
            SaveSettingsToFile();
        }

        private void ToggleSwitchShowButtonPPTNavigationSides_OnToggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.PowerPointSettings.IsShowPPTNavigationSides = ToggleSwitchShowButtonPPTNavigationSides.IsOn;
            PptNavigationSidesBtn.Visibility = Settings.PowerPointSettings.IsShowPPTNavigationSides ? Visibility.Visible : Visibility.Collapsed;
            SaveSettingsToFile();
        }

        private void ToggleSwitchShowPPTNavigationPanelBottom_OnToggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.PowerPointSettings.IsShowBottomPPTNavigationPanel = ToggleSwitchShowPPTNavigationPanelBottom.IsOn;
            if (BtnPPTSlideShowEnd.Visibility == Visibility.Visible)
            {
                PPTNavigationBottomLeft.Visibility = Settings.PowerPointSettings.IsShowBottomPPTNavigationPanel ? Visibility.Visible : Visibility.Collapsed;
                PPTNavigationBottomRight.Visibility = Settings.PowerPointSettings.IsShowBottomPPTNavigationPanel ? Visibility.Visible : Visibility.Collapsed;
            }
            SaveSettingsToFile();
        }

        private void ToggleSwitchShowPPTNavigationPanelSide_OnToggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.PowerPointSettings.IsShowSidePPTNavigationPanel = ToggleSwitchShowPPTNavigationPanelSide.IsOn;
            if (BtnPPTSlideShowEnd.Visibility == Visibility.Visible)
            {
                PPTNavigationSidesLeft.Visibility = Settings.PowerPointSettings.IsShowSidePPTNavigationPanel ? Visibility.Visible : Visibility.Collapsed;
                PPTNavigationSidesRight.Visibility = Settings.PowerPointSettings.IsShowSidePPTNavigationPanel ? Visibility.Visible : Visibility.Collapsed;
            }
            SaveSettingsToFile();
        }

        private void ToggleSwitchCompressPicturesUploaded_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Canvas.IsCompressPicturesUploaded = ToggleSwitchCompressPicturesUploaded.IsOn;
            SaveSettingsToFile();
        }

        private void ToggleSwitchShowCursor_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Canvas.IsShowCursor = ToggleSwitchShowCursor.IsOn;
            inkCanvas_EditingModeChanged(inkCanvas, null);
            SaveSettingsToFile();
        }

        #endregion

        #region Canvas

        private void ComboBoxPenStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!isLoaded) return;
            if (sender == ComboBoxPenStyle)
            {
                Settings.Canvas.InkStyle = ComboBoxPenStyle.SelectedIndex;
                BoardComboBoxPenStyle.SelectedIndex = ComboBoxPenStyle.SelectedIndex;
            }
            else
            {
                Settings.Canvas.InkStyle = BoardComboBoxPenStyle.SelectedIndex;
                ComboBoxPenStyle.SelectedIndex = BoardComboBoxPenStyle.SelectedIndex;
            }
            SaveSettingsToFile();
        }

        private void ComboBoxEraserSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Canvas.EraserSize = ComboBoxEraserSize.SelectedIndex;
            SaveSettingsToFile();
        }

        private void ComboBoxHyperbolaAsymptoteOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Canvas.HyperbolaAsymptoteOption = (OptionalOperation)ComboBoxHyperbolaAsymptoteOption.SelectedIndex;
            SaveSettingsToFile();
        }

        #endregion

        #region Automation

        private void StartOrStoptimerCheckAutoFold()
        {
            if (Settings.Automation.IsEnableAutoFold)
            {
                timerCheckAutoFold.Start();
            }
            else
            {
                timerCheckAutoFold.Stop();
            }
        }

        private void ToggleSwitchAutoFoldInEasiNote_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.IsAutoFoldInEasiNote = ToggleSwitchAutoFoldInEasiNote.IsOn;
            SaveSettingsToFile();
            StartOrStoptimerCheckAutoFold();
        }

        private void ToggleSwitchAutoFoldInEasiNoteIgnoreDesktopAnno_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.IsAutoFoldInEasiNoteIgnoreDesktopAnno = ToggleSwitchAutoFoldInEasiNoteIgnoreDesktopAnno.IsOn;
            SaveSettingsToFile();
        }

        private void ToggleSwitchAutoFoldInEasiCamera_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.IsAutoFoldInEasiCamera = ToggleSwitchAutoFoldInEasiCamera.IsOn;
            SaveSettingsToFile();
            StartOrStoptimerCheckAutoFold();
        }

        private void ToggleSwitchAutoFoldInEasiNote3C_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.IsAutoFoldInEasiNote3C = ToggleSwitchAutoFoldInEasiNote3C.IsOn;
            SaveSettingsToFile();
            StartOrStoptimerCheckAutoFold();
        }

        private void ToggleSwitchAutoFoldInEasiNote5C_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.IsAutoFoldInEasiNote5C = ToggleSwitchAutoFoldInEasiNote5C.IsOn;
            SaveSettingsToFile();
            StartOrStoptimerCheckAutoFold();
        }

        private void ToggleSwitchAutoFoldInSeewoPincoTeacher_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.IsAutoFoldInSeewoPincoTeacher = ToggleSwitchAutoFoldInSeewoPincoTeacher.IsOn;
            SaveSettingsToFile();
            StartOrStoptimerCheckAutoFold();
        }

        private void ToggleSwitchAutoFoldInHiteTouchPro_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.IsAutoFoldInHiteTouchPro = ToggleSwitchAutoFoldInHiteTouchPro.IsOn;
            SaveSettingsToFile();
            StartOrStoptimerCheckAutoFold();
        }

        private void ToggleSwitchAutoFoldInHiteCamera_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.IsAutoFoldInHiteCamera = ToggleSwitchAutoFoldInHiteCamera.IsOn;
            SaveSettingsToFile();
            StartOrStoptimerCheckAutoFold();
        }

        private void ToggleSwitchAutoFoldInWxBoardMain_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.IsAutoFoldInWxBoardMain = ToggleSwitchAutoFoldInWxBoardMain.IsOn;
            SaveSettingsToFile();
            StartOrStoptimerCheckAutoFold();
        }

        private void ToggleSwitchAutoFoldInOldZyBoard_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.IsAutoFoldInOldZyBoard = ToggleSwitchAutoFoldInOldZyBoard.IsOn;
            SaveSettingsToFile();
            StartOrStoptimerCheckAutoFold();
        }

        private void ToggleSwitchAutoFoldInMSWhiteboard_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.IsAutoFoldInMSWhiteboard = ToggleSwitchAutoFoldInMSWhiteboard.IsOn;
            SaveSettingsToFile();
            StartOrStoptimerCheckAutoFold();
        }

        private void ToggleSwitchAutoFoldInAdmoxWhiteboard_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.IsAutoFoldInAdmoxWhiteboard = ToggleSwitchAutoFoldInAdmoxWhiteboard.IsOn;
            SaveSettingsToFile();
            StartOrStoptimerCheckAutoFold();
        }

        private void ToggleSwitchAutoFoldInAdmoxBooth_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.IsAutoFoldInAdmoxBooth = ToggleSwitchAutoFoldInAdmoxBooth.IsOn;
            SaveSettingsToFile();
            StartOrStoptimerCheckAutoFold();
        }

        private void ToggleSwitchAutoFoldInQPoint_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.IsAutoFoldInQPoint = ToggleSwitchAutoFoldInQPoint.IsOn;
            SaveSettingsToFile();
            StartOrStoptimerCheckAutoFold();
        }

        private void ToggleSwitchAutoFoldInYiYunVisualPresenter_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.IsAutoFoldInYiYunVisualPresenter = ToggleSwitchAutoFoldInYiYunVisualPresenter.IsOn;
            SaveSettingsToFile();
            StartOrStoptimerCheckAutoFold();
        }

        private void ToggleSwitchAutoFoldInMaxHubWhiteboard_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.IsAutoFoldInMaxHubWhiteboard = ToggleSwitchAutoFoldInMaxHubWhiteboard.IsOn;
            SaveSettingsToFile();
            StartOrStoptimerCheckAutoFold();
        }

        private void ToggleSwitchAutoFoldInZHKTWhiteboard_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.IsAutoFoldInZHKTWhiteboard = ToggleSwitchAutoFoldInZHKTWhiteboard.IsOn;
            SaveSettingsToFile();
            StartOrStoptimerCheckAutoFold();
        }

        private void ToggleSwitchAutoFoldInZHKTZhanTai_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.IsAutoFoldInZHKTZhanTai = ToggleSwitchAutoFoldInZHKTZhanTai.IsOn;
            SaveSettingsToFile();
            StartOrStoptimerCheckAutoFold();
        }

        private void ToggleSwitchAutoFoldInZHKTZhanTai_New_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.IsAutoFoldInZHKTZhanTai_New = ToggleSwitchAutoFoldInZHKTZhanTai_New.IsOn;
            SaveSettingsToFile();
            StartOrStoptimerCheckAutoFold();
        }

        private void ToggleSwitchAutoFoldInPPTSlideShow_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.IsAutoFoldInPPTSlideShow = ToggleSwitchAutoFoldInPPTSlideShow.IsOn;
            SaveSettingsToFile();
            StartOrStoptimerCheckAutoFold();
        }

        private void ToggleSwitchAutoKillPptService_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.IsAutoKillPptService = ToggleSwitchAutoKillPptService.IsOn;
            SaveSettingsToFile();

            if (Settings.Automation.IsAutoKillEasiNote || Settings.Automation.IsAutoKillPptService || Settings.Automation.IsAutoKillZHKT)
            {
                timerKillProcess.Start();
            }
            else
            {
                timerKillProcess.Stop();
            }
        }

        private void ToggleSwitchAutoKillEasiNote_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.IsAutoKillEasiNote = ToggleSwitchAutoKillEasiNote.IsOn;
            SaveSettingsToFile();
            if (Settings.Automation.IsAutoKillEasiNote || Settings.Automation.IsAutoKillPptService || Settings.Automation.IsAutoKillZHKT)
            {
                timerKillProcess.Start();
            }
            else
            {
                timerKillProcess.Stop();
            }
        }

        private void ToggleSwitchAutoKillZHKT_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.IsAutoKillZHKT = ToggleSwitchAutoKillZHKT.IsOn;
            SaveSettingsToFile();
            if (Settings.Automation.IsAutoKillEasiNote || Settings.Automation.IsAutoKillPptService || Settings.Automation.IsAutoKillZHKT)
            {
                timerKillProcess.Start();
            }
            else
            {
                timerKillProcess.Stop();
            }
        }

        private void ToggleSwitchSaveScreenshotsInDateFolders_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.IsSaveScreenshotsInDateFolders = ToggleSwitchSaveScreenshotsInDateFolders.IsOn;
            SaveSettingsToFile();
        }

        private void ToggleSwitchAutoSaveStrokesAtScreenshot_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.IsAutoSaveStrokesAtScreenshot = ToggleSwitchAutoSaveStrokesAtScreenshot.IsOn;
            ToggleSwitchAutoSaveStrokesAtClear.Header = ToggleSwitchAutoSaveStrokesAtScreenshot.IsOn ? "清屏时自动截图并保存墨迹" : "清屏时自动截图";
            SaveSettingsToFile();
        }

        private void ToggleSwitchAutoSaveStrokesAtClear_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.IsAutoSaveStrokesAtClear = ToggleSwitchAutoSaveStrokesAtClear.IsOn;
            SaveSettingsToFile();
        }

        private void ToggleSwitchHideStrokeWhenSelecting_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Canvas.HideStrokeWhenSelecting = ToggleSwitchHideStrokeWhenSelecting.IsOn;
            SaveSettingsToFile();
        }

        private void ToggleSwitchAutoSaveStrokesInPowerPoint_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.PowerPointSettings.IsAutoSaveStrokesInPowerPoint = ToggleSwitchAutoSaveStrokesInPowerPoint.IsOn;
            SaveSettingsToFile();
        }

        private void ToggleSwitchNotifyPreviousPage_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.PowerPointSettings.IsNotifyPreviousPage = ToggleSwitchNotifyPreviousPage.IsOn;
            SaveSettingsToFile();
        }

        private void ToggleSwitchNotifyHiddenPage_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.PowerPointSettings.IsNotifyHiddenPage = ToggleSwitchNotifyHiddenPage.IsOn;
            SaveSettingsToFile();
        }

        private void ToggleSwitchNotifyAutoPlayPresentation_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.PowerPointSettings.IsNotifyAutoPlayPresentation = ToggleSwitchNotifyAutoPlayPresentation.IsOn;
            SaveSettingsToFile();
        }

        private void SideControlMinimumAutomationSlider_ValueChanged(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.MinimumAutomationStrokeNumber = (int)SideControlMinimumAutomationSlider.Value;
            SaveSettingsToFile();
        }

        private void AutoSavedStrokesLocationTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.AutoSavedStrokesLocation = AutoSavedStrokesLocation.Text;
            SaveSettingsToFile();
        }

        private void AutoSavedStrokesLocationButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            folderBrowser.ShowDialog();
            if (folderBrowser.SelectedPath.Length > 0) AutoSavedStrokesLocation.Text = folderBrowser.SelectedPath;
        }

        private void SetAutoSavedStrokesLocationToDiskDButton_Click(object sender, RoutedEventArgs e)
        {
            AutoSavedStrokesLocation.Text = @"D:\Ink Canvas";
        }

        private void SetAutoSavedStrokesLocationToDocumentFolderButton_Click(object sender, RoutedEventArgs e)
        {
            AutoSavedStrokesLocation.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Ink Canvas";
        }

        private void ToggleSwitchAutoDelSavedFiles_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.AutoDelSavedFiles = ToggleSwitchAutoDelSavedFiles.IsOn;
            SaveSettingsToFile();
        }

        private void ComboBoxAutoDelSavedFilesDaysThreshold_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Automation.AutoDelSavedFilesDaysThreshold = int.Parse(((ComboBoxItem)ComboBoxAutoDelSavedFilesDaysThreshold.SelectedItem).Content.ToString());
            SaveSettingsToFile();
        }

        private void ToggleSwitchAutoSaveScreenShotInPowerPoint_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.PowerPointSettings.IsAutoSaveScreenShotInPowerPoint = ToggleSwitchAutoSaveScreenShotInPowerPoint.IsOn;
            SaveSettingsToFile();
        }

        #endregion

        #region Gesture

        private void ComboBoxMatrixTransformCenterPoint_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Gesture.MatrixTransformCenterPoint = (MatrixTransformCenterPointOptions)ComboBoxMatrixTransformCenterPoint.SelectedIndex;
            SaveSettingsToFile();
        }

        private void ToggleSwitchEnableFingerGestureSlideShowControl_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.PowerPointSettings.IsEnableFingerGestureSlideShowControl = ToggleSwitchEnableFingerGestureSlideShowControl.IsOn;
            SaveSettingsToFile();
        }

        private void ToggleSwitchAutoSwitchTwoFingerGesture_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Gesture.AutoSwitchTwoFingerGesture = ToggleSwitchAutoSwitchTwoFingerGesture.IsOn;
            SaveSettingsToFile();
        }

        private void ToggleSwitchEnableTwoFingerZoom_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            if (sender == ToggleSwitchEnableTwoFingerZoom)
            {
                BoardToggleSwitchEnableTwoFingerZoom.IsOn = ToggleSwitchEnableTwoFingerZoom.IsOn;
            }
            else
            {
                ToggleSwitchEnableTwoFingerZoom.IsOn = BoardToggleSwitchEnableTwoFingerZoom.IsOn;
            }
            Settings.Gesture.IsEnableTwoFingerZoom = ToggleSwitchEnableTwoFingerZoom.IsOn;
            CheckEnableTwoFingerGestureBtnColorPrompt();
            SaveSettingsToFile();
        }

        private void ToggleSwitchEnableMultiTouchMode_Toggled(object sender, RoutedEventArgs e)
        {
            //if (!isLoaded) return;
            if (sender == ToggleSwitchEnableMultiTouchMode)
            {
                BoardToggleSwitchEnableMultiTouchMode.IsOn = ToggleSwitchEnableMultiTouchMode.IsOn;
            }
            else
            {
                ToggleSwitchEnableMultiTouchMode.IsOn = BoardToggleSwitchEnableMultiTouchMode.IsOn;
            }
            if (ToggleSwitchEnableMultiTouchMode.IsOn)
            {
                if (!isInMultiTouchMode) BorderMultiTouchMode_MouseUp(null, null);
            }
            else
            {
                if (isInMultiTouchMode) BorderMultiTouchMode_MouseUp(null, null);
            }
            Settings.Gesture.IsEnableMultiTouchMode = ToggleSwitchEnableMultiTouchMode.IsOn;
            CheckEnableTwoFingerGestureBtnColorPrompt();
            SaveSettingsToFile();
        }

        private void ToggleSwitchEnableTwoFingerTranslate_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            if (sender == ToggleSwitchEnableTwoFingerTranslate)
            {
                BoardToggleSwitchEnableTwoFingerTranslate.IsOn = ToggleSwitchEnableTwoFingerTranslate.IsOn;
            }
            else
            {
                ToggleSwitchEnableTwoFingerTranslate.IsOn = BoardToggleSwitchEnableTwoFingerTranslate.IsOn;
            }
            Settings.Gesture.IsEnableTwoFingerTranslate = ToggleSwitchEnableTwoFingerTranslate.IsOn;
            CheckEnableTwoFingerGestureBtnColorPrompt();
            SaveSettingsToFile();
        }

        private void ToggleSwitchEnableTwoFingerRotation_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;

            if (sender == ToggleSwitchEnableTwoFingerRotation)
            {
                BoardToggleSwitchEnableTwoFingerRotation.IsOn = ToggleSwitchEnableTwoFingerRotation.IsOn;
            }
            else
            {
                ToggleSwitchEnableTwoFingerRotation.IsOn = BoardToggleSwitchEnableTwoFingerRotation.IsOn;
            }
            Settings.Gesture.IsEnableTwoFingerRotation = ToggleSwitchEnableTwoFingerRotation.IsOn;
            Settings.Gesture.IsEnableTwoFingerRotationOnSelection = ToggleSwitchEnableTwoFingerRotationOnSelection.IsOn;
            CheckEnableTwoFingerGestureBtnColorPrompt();
            SaveSettingsToFile();
        }

        private void ToggleSwitchEnableTwoFingerGestureInPresentationMode_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.PowerPointSettings.IsEnableTwoFingerGestureInPresentationMode = ToggleSwitchEnableTwoFingerGestureInPresentationMode.IsOn;
            SaveSettingsToFile();
        }

        #endregion

        #region Reset

        public static void SetSettingsToRecommendation()
        {
            bool AutoDelSavedFilesDays = Settings.Automation.AutoDelSavedFiles;
            int AutoDelSavedFilesDaysThreshold = Settings.Automation.AutoDelSavedFilesDaysThreshold;
            Settings = new Settings();
            Settings.Advanced.IsSpecialScreen = true;
            Settings.Advanced.IsQuadIR = false;
            Settings.Advanced.TouchMultiplier = 0.22;
            Settings.Advanced.NibModeBoundsWidth = 5;
            Settings.Advanced.FingerModeBoundsWidth = 50;
            Settings.Advanced.NibModeBoundsWidthThresholdValue = 2.5;
            Settings.Advanced.FingerModeBoundsWidthThresholdValue = 2.5;
            Settings.Advanced.NibModeBoundsWidthEraserSize = 1.0;
            Settings.Advanced.FingerModeBoundsWidthEraserSize = 1.0;
            Settings.Advanced.IsLogEnabled = true;
            Settings.Advanced.IsSecondConfimeWhenShutdownApp = false;
            Settings.Advanced.IsEnableEdgeGestureUtil = false;

            Settings.Appearance.IsEnableDisPlayFloatBarText = true;
            Settings.Appearance.IsEnableDisPlayNibModeToggler = false;
            Settings.Appearance.IsColorfulViewboxFloatingBar = false;
            Settings.Appearance.EnableViewboxFloatingBarScaleTransform = false;
            Settings.Appearance.EnableViewboxBlackBoardScaleTransform = false;
            Settings.Appearance.IsTransparentButtonBackground = true;
            Settings.Appearance.IsShowExitButton = true;
            Settings.Appearance.IsShowEraserButton = true;
            Settings.Appearance.IsShowHideControlButton = false;
            Settings.Appearance.IsShowLRSwitchButton = false;
            Settings.Appearance.IsShowModeFingerToggleSwitch = true;
            Settings.Appearance.Theme = 0;

            Settings.Automation.IsAutoFoldInEasiNote = true;
            Settings.Automation.IsAutoFoldInEasiNoteIgnoreDesktopAnno = true;
            Settings.Automation.IsAutoFoldInEasiCamera = true;
            Settings.Automation.IsAutoFoldInEasiNote3C = false;
            Settings.Automation.IsAutoFoldInEasiNote5C = false;
            Settings.Automation.IsAutoFoldInSeewoPincoTeacher = false;
            Settings.Automation.IsAutoFoldInHiteTouchPro = false;
            Settings.Automation.IsAutoFoldInHiteCamera = false;
            Settings.Automation.IsAutoFoldInWxBoardMain = false;
            Settings.Automation.IsAutoFoldInOldZyBoard = false;
            Settings.Automation.IsAutoFoldInMSWhiteboard = false;
            Settings.Automation.IsAutoFoldInAdmoxWhiteboard = false;
            Settings.Automation.IsAutoFoldInAdmoxBooth = false;
            Settings.Automation.IsAutoFoldInQPoint = false;
            Settings.Automation.IsAutoFoldInYiYunVisualPresenter = false;
            Settings.Automation.IsAutoFoldInMaxHubWhiteboard = false;
            Settings.Automation.IsAutoFoldInZHKTWhiteboard = true;
            Settings.Automation.IsAutoFoldInZHKTZhanTai = false;
            Settings.Automation.IsAutoFoldInZHKTZhanTai_New = true;
            Settings.Automation.IsAutoFoldInPPTSlideShow = false;
            Settings.Automation.IsAutoKillPptService = false;
            Settings.Automation.IsAutoKillEasiNote = true;
            Settings.Automation.IsAutoKillZHKT = false;
            Settings.Automation.IsSaveScreenshotsInDateFolders = true;
            Settings.Automation.IsAutoSaveStrokesAtScreenshot = true;
            Settings.Automation.IsAutoSaveStrokesAtClear = true;
            Settings.Automation.IsAutoClearWhenExitingWritingMode = false;
            Settings.Automation.MinimumAutomationStrokeNumber = 0;
            Settings.Automation.AutoDelSavedFiles = AutoDelSavedFilesDays;
            Settings.Automation.AutoDelSavedFilesDaysThreshold = AutoDelSavedFilesDaysThreshold;

            Settings.PowerPointSettings.IsShowPPTNavigationBottom = true;
            Settings.PowerPointSettings.IsShowBottomPPTNavigationPanel = true;
            Settings.PowerPointSettings.IsShowSidePPTNavigationPanel = false;
            Settings.PowerPointSettings.PowerPointSupport = true;
            Settings.PowerPointSettings.IsShowCanvasAtNewSlideShow = true;
            Settings.PowerPointSettings.IsNoClearStrokeOnSelectWhenInPowerPoint = true;
            Settings.PowerPointSettings.IsShowStrokeOnSelectInPowerPoint = false;
            Settings.PowerPointSettings.IsAutoSaveStrokesInPowerPoint = true;
            Settings.PowerPointSettings.IsAutoSaveScreenShotInPowerPoint = true;
            Settings.PowerPointSettings.IsNotifyPreviousPage = true;
            Settings.PowerPointSettings.IsNotifyHiddenPage = false;
            Settings.PowerPointSettings.IsNotifyAutoPlayPresentation = true;
            Settings.PowerPointSettings.IsEnableTwoFingerGestureInPresentationMode = false;
            Settings.PowerPointSettings.IsEnableFingerGestureSlideShowControl = false;
            Settings.PowerPointSettings.IsSupportWPS = true;

            Settings.Canvas.InkWidth = 2.5;
            Settings.Canvas.InkAlpha = 80;
            Settings.Canvas.IsShowCursor = false;
            Settings.Canvas.InkStyle = 0;
            Settings.Canvas.EraserSize = 0;
            Settings.Canvas.EraserType = 0;
            Settings.Canvas.HideStrokeWhenSelecting = false;
            Settings.Canvas.UsingWhiteboard = false;
            Settings.Canvas.HyperbolaAsymptoteOption = 0;

            Settings.Gesture.MatrixTransformCenterPoint = MatrixTransformCenterPointOptions.GestureOperationCenterPoint;
            Settings.Gesture.AutoSwitchTwoFingerGesture = true;
            Settings.Gesture.IsEnableTwoFingerTranslate = true;
            Settings.Gesture.IsEnableTwoFingerZoom = false;
            Settings.Gesture.IsEnableTwoFingerRotation = false;
            Settings.Gesture.IsEnableTwoFingerRotationOnSelection = true;

            Settings.InkToShape.IsInkToShapeEnabled = false;

            Settings.Startup.IsEnableNibMode = false;
            Settings.Startup.IsAutoUpdate = true;
            Settings.Startup.IsAutoUpdateWithSilence = true;
            Settings.Startup.IsAutoUpdateWithProxy = true;
            Settings.Startup.AutoUpdateProxy = "https://mirror.ghproxy.com/";
            Settings.Startup.AutoUpdateWithSilenceStartTime = "18:00";
            Settings.Startup.AutoUpdateWithSilenceEndTime = "07:20";
            Settings.Startup.IsFoldAtStartup = false;
        }

        private void BtnResetToSuggestion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isLoaded = false;
                SetSettingsToRecommendation();
                SaveSettingsToFile();
                LoadSettings();
                isLoaded = true;
                ToggleSwitchRunAtStartup.IsOn = true;
            }
            catch { }
            ShowNotificationAsync("设置已重置为默认推荐设置~");
        }

        private async void SpecialVersionResetToSuggestion_Click()
        {
            await Task.Delay(1000);
            try
            {
                isLoaded = false;
                SetSettingsToRecommendation();
                Settings.Automation.AutoDelSavedFiles = true;
                Settings.Automation.AutoDelSavedFilesDaysThreshold = 15;
                Settings.Appearance.IsEnableDisPlayFloatBarText = true;
                SetAutoSavedStrokesLocationToDiskDButton_Click(null, null);
                SaveSettingsToFile();
                LoadSettings();
                isLoaded = true;
            }
            catch { }
        }

        #endregion

        #region Ink To Shape

        private void ToggleSwitchEnableInkToShape_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.InkToShape.IsInkToShapeEnabled = ToggleSwitchEnableInkToShape.IsOn;
            SaveSettingsToFile();
        }

        #endregion

        #region Advanced

        private void ToggleSwitchIsSpecialScreen_OnToggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Advanced.IsSpecialScreen = ToggleSwitchIsSpecialScreen.IsOn;
            TouchMultiplierSlider.Visibility = ToggleSwitchIsSpecialScreen.IsOn ? Visibility.Visible : Visibility.Collapsed;
            SaveSettingsToFile();
        }

        private void TouchMultiplierSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!isLoaded) return;
            Settings.Advanced.TouchMultiplier = e.NewValue;
            SaveSettingsToFile();
        }

        private void BorderCalculateMultiplier_TouchDown(object sender, TouchEventArgs e)
        {
            var args = e.GetTouchPoint(null).Bounds;
            double value;
            if (!Settings.Advanced.IsQuadIR) value = args.Width;
            else value = Math.Sqrt(args.Width * args.Height); //四边红外
            TextBlockShowCalculatedMultiplier.Text = (5 / (value * 1.1)).ToString();
        }

        private void NibModeBoundsWidthSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!isLoaded) return;
            Settings.Advanced.NibModeBoundsWidth = (int)e.NewValue;
            BoundsWidth = Settings.Startup.IsEnableNibMode ? BoundsWidth = Settings.Advanced.NibModeBoundsWidth : BoundsWidth = Settings.Advanced.FingerModeBoundsWidth;
            SaveSettingsToFile();
        }

        private void FingerModeBoundsWidthSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!isLoaded) return;
            Settings.Advanced.FingerModeBoundsWidth = (int)e.NewValue;
            BoundsWidth = Settings.Startup.IsEnableNibMode ? BoundsWidth = Settings.Advanced.NibModeBoundsWidth : BoundsWidth = Settings.Advanced.FingerModeBoundsWidth;
            SaveSettingsToFile();
        }

        private void NibModeBoundsWidthThresholdValueSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!isLoaded) return;
            Settings.Advanced.NibModeBoundsWidthThresholdValue = (double)e.NewValue;
            SaveSettingsToFile();
        }

        private void FingerModeBoundsWidthThresholdValueSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!isLoaded) return;
            Settings.Advanced.FingerModeBoundsWidthThresholdValue = (double)e.NewValue;
            SaveSettingsToFile();
        }

        private void NibModeBoundsWidthEraserSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!isLoaded) return;
            Settings.Advanced.NibModeBoundsWidthEraserSize = (double)e.NewValue;
            SaveSettingsToFile();
        }

        private void FingerModeBoundsWidthEraserSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!isLoaded) return;
            Settings.Advanced.FingerModeBoundsWidthEraserSize = (double)e.NewValue;
            SaveSettingsToFile();
        }

        private void ToggleSwitchIsQuadIR_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Advanced.IsQuadIR = ToggleSwitchIsQuadIR.IsOn;
            SaveSettingsToFile();
        }

        private void ToggleSwitchIsLogEnabled_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Advanced.IsLogEnabled = ToggleSwitchIsLogEnabled.IsOn;
            SaveSettingsToFile();
        }

        private void ToggleSwitchIsSecondConfimeWhenShutdownApp_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Advanced.IsSecondConfimeWhenShutdownApp = ToggleSwitchIsSecondConfimeWhenShutdownApp.IsOn;
            SaveSettingsToFile();
        }

        private void ToggleSwitchIsEnableEdgeGestureUtil_Toggled(object sender, RoutedEventArgs e)
        {
            if (!isLoaded) return;
            Settings.Advanced.IsEnableEdgeGestureUtil = ToggleSwitchIsEnableEdgeGestureUtil.IsOn;
            if (OSVersion.GetOperatingSystem() >= OSVersionExtension.OperatingSystem.Windows10) EdgeGestureUtil.DisableEdgeGestures(new WindowInteropHelper(this).Handle, ToggleSwitchIsEnableEdgeGestureUtil.IsOn);
            SaveSettingsToFile();
        }

        #endregion

        public static void SaveSettingsToFile()
        {
            string text = JsonConvert.SerializeObject(Settings, Formatting.Indented);
            try
            {
                File.WriteAllText(App.RootPath + settingsFileName, text);
            }
            catch { }
        }

        private void SCManipulationBoundaryFeedback(object sender, ManipulationBoundaryFeedbackEventArgs e)
        {
            e.Handled = true;
        }

        private void HyperlinkSourceToPresentRepository_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/pigeons2023/Ink-Canvas-Basic");
            HideSubPanels();
        }

        private void HyperlinkSourceToInkCanvasForClassRepository_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/InkCanvas/InkCanvasForClass");
            HideSubPanels();
        }

        private void HyperlinkSourceToInkCanvasArtistryRepository_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/InkCanvas/Ink-Canvas-Artistry");
            HideSubPanels();
        }

        private void HyperlinkSourceToOringinalRepository_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/WXRIW/Ink-Canvas");
            HideSubPanels();
        }
    }
}