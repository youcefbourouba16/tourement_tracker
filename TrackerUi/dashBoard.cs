using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tourament_library;
using Tourament_library.Models;
using Tourament_library.DataAccess;


namespace TrackerUi
{
    public partial class dashBoard : Form, ITourRequester, IMainRequester
    {
        List<tourement_Model> TouramentAll = globalConfig.Connections.getTourAll();

        public dashBoard()
        {

            InitializeComponent();
            wireUpTpuramentList();

        }
        private void wireUpTpuramentList()
        {
            touramentList.DataSource = null;
            touramentList.DataSource = TouramentAll;
            touramentList.DisplayMember = "TouramentName";
        }
        private void dashBoard_Load(object sender, EventArgs e)
        {

        }

        private void creatTourament_Click(object sender, EventArgs e)
        {
            CreatTour frm = new CreatTour(this); /// this means this exactly form that  we're in
            frm.Show();

        }

        public void tourComplete(tourement_Model model)
        {
            TouramentAll.Add(model);
            wireUpTpuramentList();
        }

        private void loadTorament_Click(object sender, EventArgs e)
        {

            tourement_Model tour = createMainApp();
            if (tour != null)
            {
                
                if (tour.Active == 2)
                {
                    tourament_Bracket frm = new tourament_Bracket(tour); /// this means this exactly form that  we're in
                    frm.Show();
                    dashBoard frm1 = new dashBoard();
                    frm1.Close();
                    /// todo-- exit this
                    
                    

                    
                }
                else
                {
                    mainApp frm1 = new mainApp(tour); /// this means this exactly form that  we're in

                    //this.Close();
                    frm1.Show();

                }
                
                
            }


        }

        public tourement_Model createMainApp()
        {
            tourement_Model output = new tourement_Model();
            if (touramentList.SelectedItem != null)
            {
                return (tourement_Model)touramentList.SelectedItem;
            }
            else
            {
                MessageBox.Show("Please select OR Create a Tourament First", "invalide Tourament",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return null;
            }



        }
    }
}
