using Microsoft.Win32.TaskScheduler;

namespace UNBKGo.Service.Diagnostics
{
    public class StartupInstaller
    {
        private const string TaskName = "UNBKGo";
        private readonly string _appPath;

        public StartupInstaller(string appPath)
        {
            _appPath = appPath;
        }

        public void InstallStartup()
        {
            using (var ts = new TaskService())
            {
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "UNBKGo Startup";
                td.Principal.LogonType = TaskLogonType.InteractiveToken;
                td.Principal.RunLevel = TaskRunLevel.Highest;
                
                td.Triggers.Add(new LogonTrigger());
                td.Actions.Add(new ExecAction(_appPath, "-startup"));
                
                ts.RootFolder.RegisterTaskDefinition(TaskName, td);
            }
        }

        public void UninstallStartup()
        {
            using (var ts = new TaskService())
            {
                ts.RootFolder.DeleteTask(TaskName);
            }
        }
    }
}
