using System.Diagnostics;
using System.Text;

namespace FRBSiteMigrator
{
    public class ProcessWrapper : IDisposable
    {
        readonly Process process;

        readonly StringBuilder outBuilder = new StringBuilder();

        public string Out { get; private set; }

        readonly StringBuilder errBuilder = new StringBuilder();

        public string Error { get; private set; }

        public int ExitCode { get; private set; }

        public string File { get { return process.StartInfo.FileName; } }

        public string Arguments { get { return process.StartInfo.Arguments; } }

        public ProcessWrapper(string executable, string arguments)
        {
            process = new Process();
            process.OutputDataReceived += OutputDataReceived;
            process.ErrorDataReceived += ErrorDataReceived;

            var startInfo = process.StartInfo;
            startInfo.FileName = executable;
            startInfo.Arguments = arguments;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardOutput = true;
        }

        public bool Run()
        {
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            process.WaitForExit();

            Out = outBuilder.ToString();
            Error = errBuilder.ToString();

            ExitCode = process.ExitCode;
            return ExitCode == 0;
        }

        void OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            outBuilder.Append(e.Data);
        }

        void ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            errBuilder.Append(e.Data);
        }

        public void Dispose()
        {
            process.Dispose();
        }
    }
}
