using System;
using System.Windows.Forms;

namespace TestTargetExeForm
{
    public static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TestTargetExeForm.TestTargetForm());
        }
    }
}
