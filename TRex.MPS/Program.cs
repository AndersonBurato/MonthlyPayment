using TRex.MPS.Config;

namespace TRex.MPS;

internal static class Program
{
    /// <summary>
    ///     The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        IoC.Init();

        var mainForm = IoC.GetForm<MainForm>();

        Application.Run(mainForm);
    }
}