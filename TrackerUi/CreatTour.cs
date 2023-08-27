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

namespace TrackerUi
{
    public partial class CreatTour : Form, IPrizeRequester, IteamRequester
    {
        List<PrizeModel> PrizesAll = new List<PrizeModel>();
        List<teamModel> teamAll = globalConfig.Connections.getTeamAll();
        List<teamModel> teamsSelected = new List<teamModel>();


        public CreatTour()
        {
            InitializeComponent();
            wireUpPrizeList();
            wireUpAvailableTeamsList();



        }
        private void wireUpPrizeList()
        {
            PrizesAllListBox.DataSource = null;
            PrizesAllListBox.DataSource = PrizesAll;
            PrizesAllListBox.DisplayMember = "placeName";
        }
        private void wireUpAvailableTeamsList()
        {
            SelectTeamDropDown.DataSource = null;
            SelectTeamDropDown.DataSource = teamAll;
            SelectTeamDropDown.DisplayMember = "teamName";
        }
        private void wireUpSelectedTeamsList()
        {
            teamsListbox.DataSource = null;
            teamsListbox.DataSource = teamsSelected;
            teamsListbox.DisplayMember = "teamName";
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void deleteSelectedPrize_Click(object sender, EventArgs e)
        {
            PrizeModel p = (PrizeModel)PrizesAllListBox.SelectedItem;
            if (p != null)
            {

                PrizesAll.Remove(p);
                wireUpPrizeList();
            }
        }

        private void SelectTeamDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void btn_addTeam_Click(object sender, EventArgs e)
        {
            teamModel p = (teamModel)SelectTeamDropDown.SelectedItem;
            if (p != null)
            {
                teamsSelected.Add(p);
                teamAll.Remove(p);
                wireUpSelectedTeamsList();
                wireUpAvailableTeamsList();
            }


        }

        private void deleteSelectedTeam_Click(object sender, EventArgs e)
        {
            teamModel p = (teamModel)teamsListbox.SelectedItem;
            if (p != null)
            {

                teamsSelected.Remove(p);
                teamAll.Add(p);
                wireUpSelectedTeamsList();
                wireUpAvailableTeamsList();
            }
        }

        private void btn_addPrize_Click(object sender, EventArgs e)
        {
            //call the creatprize form
            creatPrize frm = new creatPrize(this); /// this means this exactly form that  we're in
            frm.Show();
            //gt back prizeModel form the creatPrize form
            // take that prize model and put it in selected prize Listbox

        }

        public void prizeComplete(PrizeModel model)
        {
            // *  get back prizeModel form the creatPrize form
            // take that prize model and put it in selected prize Listbox
            PrizesAll.Add(model);
            wireUpPrizeList();
        }

        public void teamComplete(teamModel model)
        {
            teamsSelected.Add(model);
            wireUpSelectedTeamsList();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            creatTeam frm = new creatTeam(this); /// this means this exactly form that  we're in
            frm.Show();
        }

        private void btn_addTourament_Click(object sender, EventArgs e)
        {

        }
    }
}
