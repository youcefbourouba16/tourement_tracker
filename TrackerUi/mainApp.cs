using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tourament_library.Models;

namespace TrackerUi
{
    public partial class mainApp : Form
    {
        ITourRequester callingForm;
        tourement_Model tour = new tourement_Model();
        List<int> roundNum = new List<int>();


        public mainApp(ITourRequester caller, tourement_Model tr)
        {

            InitializeComponent();
            callingForm = caller;
            tour = tr;
            // todo-- team competing in first round need to be fix in test file setting
            loadTour();
            roundGetList();
            wireUpRoundList();


        }

        public void wireUpRoundList()
        {
            round_list.DataSource = null;
            round_list.DataSource = roundNum;


        }

        public void loadTour()
        {
            TourName.Text = tour.TouramentName;

        }
        public void roundGetList()
        {
            roundNum.Add(1);
            int currRound = 1;
            foreach (List<MatchupModel> list in tour.round)
            {
                foreach (MatchupModel matchp in list)
                {
                    if (matchp.MatchupRound > currRound)
                    {
                        currRound++;
                        roundNum.Add(currRound);
                    }
                }
            }
        }

        private void score_teamTWO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
    }
}
