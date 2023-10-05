using _420DA3_Demo_Intra_Live.Business;

namespace _420DA3_Demo_Intra_Live;

internal static class Program {
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {
        new FilmsApp().Start();
    }
}