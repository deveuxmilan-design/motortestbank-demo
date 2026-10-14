using System;
using System.Windows.Forms;

namespace MotorTestbankDemo;

internal static class Program
{
    /// <summary>
    /// Het programma start hier.
    /// De applicatie toont eerst de Testgegevens-pagina, daarna volgt de kringselectie
    /// en vervolgens het meetscherm. Tijdens de eerste opstart wordt automatisch een
    /// standaardconfiguratie gemaakt en opgeslagen.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // Zorg dat het programma in een moderne Windows-Form omgeving draait.
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // Zorg voor een consistente locale voor decimale punten en Nederlandstalige UI.
        System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("nl-NL");
        System.Globalization.CultureInfo.CurrentUICulture = new System.Globalization.CultureInfo("nl-NL");

        try
        {
            var config = ConfigurationService.LoadOrCreateDefault();
            Application.Run(new MainForm(config));
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Er is een onverwachte fout opgetreden bij het starten van de applicatie.\n\n" + ex.Message,
                "Opstartfout",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
