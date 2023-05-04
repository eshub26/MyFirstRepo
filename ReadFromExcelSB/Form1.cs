using ExcelDataReader;
using ExcelDataReader.Core;
using ReadFromExcelSB.Managers;
using System.Configuration;

namespace ReadFromExcelSB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            LogData("Process started");
            try
            {
                var filePath = ConfigurationManager.AppSettings["ExcelFilePath"];

                if (filePath == null) throw new ArgumentNullException("File Path Not found");

                var excelManager = new ExcelManager();

                dataGridView1.DataSource = excelManager.ProcessData(filePath);

            }
            catch (Exception ex)
            {
                LogData(ex.ToString());
            }

        }

        public void LogData(string log)
        {
            logTextBox.Text = $"{DateTime.Now.ToLongTimeString()}: {log} {Environment.NewLine} {logTextBox.Text}";
        }
    }
}