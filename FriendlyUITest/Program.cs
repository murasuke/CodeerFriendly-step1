using System;
using Codeer.Friendly.Dynamic;
using Codeer.Friendly.Windows;

//nugetで下記をインストールしてからusingで読み込む
// Codeer.Friendly
// Codeer.Friendly.Windows


class Program{
    /// <summary>
    /// アプリケーションのメイン エントリ ポイントです。
    /// </summary>
    [STAThread]
    public static void Main()
    {
        //--- プロセス起動
        var path = System.IO.Path.Combine(Environment.CurrentDirectory, @"..\..\..\testExe\TestTargetExeForm.exe");
        var process = System.Diagnostics.Process.Start(path);

        //--- プロセスにアタッチ
        using (var targetApp = new WindowsAppFriend(process))
        {
            // フォームを取得
            dynamic form = targetApp.Type<System.Windows.Forms.Application>().OpenForms[0];

            // 2 * 3 を入力(別プロセスのテキストボックス、ラジオボタンに値が設定される)     
            form.textBox1.Text = "2";
            form.rdoMul.Checked = true;
            form.textBox2.Text = "3";

            // 計算ボタンをクリック
            form.button1.PerformClick();

            // 計算結果をデバッガに出力
            System.Diagnostics.Debug.WriteLine((string)form.textBox3.Text);
        }
    }
}


