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
    public partial class dashBoard : Form, ITourRequester
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
    }
}
