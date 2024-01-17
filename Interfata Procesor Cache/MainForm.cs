namespace Interfata_Procesor_Cache
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var files = Directory.GetFiles("./Traces/")
                .Select(x => x.Split("/").Last())
                .Select(x => x.Split(".").First())
                .ToArray();

            if (files.Length == 0)
            {
                MessageBox.Show("Nu au fost gasite fisiere trace!");
                this.Close();
            }

            this.tracesSelector.Items.Clear();
            this.tracesSelector.Items.AddRange(files);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            string[] files = tracesSelector.SelectedItems.Cast<string>().ToArray();

            Settings settings = new Settings()
                .setFetchRate(4)
                .setInstructionBufferSize(4)
                .setIssueRateMaxim(4)
                .setDataCacheBlockSize(4)

                .setInstructionBufferSize(4)
                .setInstructionCacheSize(4)

                .setHitLatency(2)
                .setMissLatency(10)

                .validate();

            Simulation simulation = new Simulation(settings, files, simulationUpdateCallback);

            var tasks = simulation.startSimulation();

            foreach (var task in tasks)
            {
                task.ContinueWith(async (x) => {
                    var result = await x;

                    this.Invoke(setSimulationResult, result.GetSimulationResult);
                });
            }
        }

        private void simulationUpdateCallback(string traceName, int value)
        {
            if(value == 100)
            {
                MessageBox.Show("done: " + traceName);
            }
        }

        private void setSimulationResult(SimulationResult simulationResult)
        {
            return;
        }
    }
}
