namespace lab_2
{
    public partial class Form1 : Form
    {
        public S7PROSIMLib.S7ProSim sim = new S7PROSIMLib.S7ProSim();
        object Q0_0 = true;
        object Q0_1 = false;
        public Form1()
        {
            InitializeComponent();
            sim.Connect();
            sim.SetScanMode(S7PROSIMLib.ScanModeConstants.ContinuousScan);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer_Read_Data_Tick(object sender, EventArgs e)
        {
            
            if(comboBox1.Text != sim.GetState())
            {
                comboBox1.Text = sim.GetState();
            }
            sim.ReadOutputPoint(0, 0, S7PROSIMLib.PointDataTypeConstants.S7_Bit, ref Q0_0);
            sim.ReadOutputPoint(0, 1, S7PROSIMLib.PointDataTypeConstants.S7_Bit, ref Q0_1);

            if ((bool)Q0_0) { label_Alert.Text = "Нормальна Робота"; label_Alert.BackColor = Color.Lime; }
            else { label_Alert.Text = "Аварія"; label_Alert.BackColor = Color.Red; }
 //           if ((bool)Q0_1) { label_Alert.Text = "Аварія"; label_Alert.BackColor = Color.Red; }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string s = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            sim.SetState(s);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            object I0_0 = checkBox1.Checked;
            sim.WriteInputPoint(0, 0, ref I0_0);
            if ((bool)I0_0)
            {
                pictureBox1.Image = Properties.Resources.vtk_emkost_6work_191x300;
            }
            else
            {
                pictureBox1.Image = Properties.Resources.vtk_emkost_680__191x300;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            object I0_1 = checkBox2.Checked;
            sim.WriteInputPoint(0, 1, ref I0_1);
            if ((bool)I0_1)
            {
                pictureBox2.Image = Properties.Resources.vtk_emkost_6work_191x300;
            }
            else
            {
                pictureBox2.Image = Properties.Resources.vtk_emkost_680__191x300;
            }
        }
    }
}