using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;

//nugetで下記をインストール
// Codeer.Friendly
// Codeer.Friendly.Windows

namespace CodeerFriendly_step1
{
    class Program
    {
        public static string PATH = @"C:\Users\t_nii\source\repos\_test\CodeerFriendly-step1\TestTargetExeForm\bin\Debug\TestTargetExeForm.exe";
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        public static void Main()
        {
            //--- プロセス起動
            var path = @"TargetApp.exeへのPathを記載";
            var process = Process.Start(PATH);

            //--- プロセスにアタッチ
            using (var targetApp = new WindowsAppFriend(process))
            {
                dynamic form = targetApp.Type<Application>().OpenForms[0];
                form.Text = "friendly!";
            }



        }
    }
}

