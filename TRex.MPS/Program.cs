namespace TRex.MPS;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        Config.IoC.Init();

        var mainForm = Config.IoC.GetForm<MainForm>();

        Application.Run(mainForm);
    }
}