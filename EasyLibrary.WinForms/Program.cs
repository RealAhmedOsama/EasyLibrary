using EasyLibrary.Core.Services;
using EasyLibrary.WinForms.Auth;

namespace EasyLibrary.WinForms;

internal static class Program
{
    /// <summary>
    ///     The main entry point for the application.
    /// </summary>
    [STAThread]
    private static async Task Main()
    {
        ApplicationConfiguration.Initialize();

        // Insert dummy data on application start
        try
        {
            await DummyDataService.InsertDummyDataAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show($@"Error inserting dummy data: {ex.Message}", @"Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        Application.Run(new LoginForm());
    }
}