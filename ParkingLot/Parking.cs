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
    public partial class Parking : Form
    {
        public Parking()
        {
            InitializeComponent();
            Con = new Functions();
            GetCars();
            GetPlaces();
            ShowBooking();
        }

        Functions Con;
        private void GetCars()
        {
            string Query = "select * from CarsTbl";
            CarsCb.ValueMember = Con.GetData(Query).Columns["CNum"].ToString();
            CarsCb.DisplayMember = Con.GetData(Query).Columns["PNumber"].ToString();
            CarsCb.DataSource = Con.GetData(Query);

        }

        private void GetPlaces()
        {
            string PSt = "Free";
            string Query = "select * from PlaceTbl where PStatus = '{0}'";
            Query = string.Format(Query, PSt);
            PlaceCb.ValueMember = Con.GetData(Query).Columns["PlNum"].ToString();
            PlaceCb.DisplayMember = Con.GetData(Query).Columns["Pposition"].ToString();
            PlaceCb.DataSource = Con.GetData(Query);

        }
        private void ShowBooking()
        {
            string Query = "select * from ParkingTbl";
            ParkingDGV.DataSource = Con.GetData(Query);
        }


        private void Parking_Load(object sender, EventArgs e)
        {

        }
        private void UpdatedStatus()
        {
            try
            {
                string PSt = "Booked";
                string Place = PlaceCb.SelectedValue.ToString();
                string Query = "Update  PlaceTbl set   PStatus = '{0}' where PlNum = {1}";
                Query = string.Format(Query,PSt, Place);
                Con.SetData(Query);
                MessageBox.Show("Place Updated!!!!");
               // ShowPlaces();

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
        }
       
        private void BookBtn_Click(object sender, EventArgs e)
        {
            if (CarsCb.SelectedIndex == 1 || PlaceCb.SelectedIndex == 1 || AmountTb.Text == "-1" || DurationTb.Text == "")
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {

                try
                {
                    string Car = CarsCb.SelectedValue.ToString();
                    string Duration = DurationTb.Text;

                    int Amount = Convert.ToInt32(AmountTb.Text);
                    string Place = PlaceCb.SelectedValue.ToString();
                   
                    string Query = "Insert into ParkingTbl values('{1},'{2}',{3},{4},'{5}')";
                    Query = string.Format(Query, Car, System.DateTime.Today.ToString(), Duration, Amount, Place);
                    Con.SetData(Query);
                    MessageBox.Show("Place Booked!!!!");
                    ShowBooking();

                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Cars Obj = new Cars();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Places Obj = new Places();
            Obj.Show();
            this.Hide();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            if (CarsCb.SelectedIndex == -1 || PlaceCb.SelectedIndex == -1 || AmountTb.Text == "1" || DurationTb.Text == "1")
            {
                MessageBox.Show("Missing Data!!");
            }
            else
            {

                try
                {
                    string Car = CarsCb.SelectedValue.ToString();
                    string Duration = DurationTb.Text;

                    int Amount = Convert.ToInt32(AmountTb.Text);
                    string Place = PlaceCb.SelectedValue.ToString();

                    string Query = "Insert into ParkingTbl values('{1}','{2}',{3},{4},'{5}')";
                    Query = string.Format(Query, Car, System.DateTime.Today.ToString(), Duration, Amount, Place);
                    Con.SetData(Query);
                    MessageBox.Show("Place Booked!!!!");
                    ShowBooking();

                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void CarsCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                Cars lform = new Cars();
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
