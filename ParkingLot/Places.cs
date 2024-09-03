using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingLot
{
    public partial class Places : Form
    {
        public Places()
        {
            InitializeComponent();
            Con = new Functions();
            ShowPlaces();
        }

        Functions Con;

        private void ShowPlaces()
        {
            string Query = "select * from PlaceTbl";
            PlacesDGV.DataSource = Con.GetData(Query);
        }

        private void Places_Load(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (PositionTb.Text == "" || Status.SelectedIndex == -1 )
            {
                MessageBox.Show("Missing Data!!!");

            }
            else
            {

                try
                {
                    string Position = PositionTb.Text;
                    string Stat = Status.SelectedItem.ToString();
                    string Query = "Insert into PlaceTbl values('{0}','{1}')";
                    Query = String.Format(Query, Position, Stat);
                    Con.SetData(Query);
                    MessageBox.Show("Place Added!!!!");
                    ShowPlaces();

                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }

        }
        int Key = 0;

        private void PlacesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PositionTb.Text = PlacesDGV.SelectedRows[0].Cells[1].Value.ToString();

            Status.Text = PlacesDGV.SelectedRows[0].Cells[2].Value.ToString();

         
            if (PositionTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(PlacesDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (PositionTb.Text == "" || Status.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Data!!!");

            }
            else
            {

                try
                {
                    string Position = PositionTb.Text;
                    string Stat = Status.SelectedItem.ToString();
                    string Query = "Update  PlaceTbl set Pposition = '{0}', PStatus = '{1}' where PlNum = {2}";
                    Query = String.Format(Query, Position, Stat, Key);
                    Con.SetData(Query);
                    MessageBox.Show("Place Updated!!!!");
                    ShowPlaces();

                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (PositionTb.Text == "" || Status.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Data!!!");

            }
            else
            {

                try
                {
                    string Position = PositionTb.Text;
                    string Stat = Status.SelectedItem.ToString();
                    string Query = "Delete from  PlaceTbl where PlNum = {0}";
                    Query = String.Format(Query, Key);
                    Con.SetData(Query);
                    MessageBox.Show("Place Deleted!!!!");
                    ShowPlaces();

                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Parking Obj = new Parking();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                Places lform = new Places();
                lform.Show();
                this.Hide();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
