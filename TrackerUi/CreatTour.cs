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
using Tourament_library.TouramentLogic;

namespace TrackerUi
{
    public partial class CreatTour : Form, IPrizeRequester, IteamRequester
    {
        ITourRequester callingForm;
        List<PrizeModel> PrizesAll = new List<PrizeModel>();
        List<teamModel> teamAll = globalConfig.Connections.getTeamAll();
        List<teamModel> teamsSelected = new List<teamModel>();


        public CreatTour(ITourRequester caller)
        {
            InitializeComponent();
            wireUpPrizeList();
            wireUpAvailableTeamsList();
            callingForm = caller;



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
        public int i=1;

        private void btn_addPrize_Click(object sender, EventArgs e)
        {
            //call the creatprize form
             
            creatPrize frm = new creatPrize(this,i); /// this means this exactly form that  we're in
            frm.Show();
            i++;// this to increament the pace number automaticly
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
            decimal fee = 0;
            bool feeValidation = decimal.TryParse(entryFee_val.Text, out fee);
            if (!feeValidation)
            {
                MessageBox.Show("please enter an decimale value in Entry fee box", "invalide fee",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (touramentName.Text=="")
            {
                MessageBox.Show("Tourament Name is requered ", "invalide Tourament Name",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }
            if (teamsSelected.Count < 2)
            {
                MessageBox.Show("the number of team should be 2 team or more", "cannot create tourament",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                return;
            }
            tourement_Model tr = new tourement_Model(
                                touramentName.Text,
                                double.Parse(entryFee_val.Text),
                                teamsSelected,
                                PrizesAll
                );
            // order the list randomly 
            // teams should be 2 or more
            //if it's number team count id even can divie by 2 do not add byes ==>else ad one byes in first round
            // create rounds (round 1 that other rounds)
            
            tourLogic.CreateRounds(tr);
            

             globalConfig.Connections.createTourament(tr);
            /// todo -- close this form or make it get me to next form
            callingForm.tourComplete(tr);
            this.Close();



        }

        private void entryFee_val_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
