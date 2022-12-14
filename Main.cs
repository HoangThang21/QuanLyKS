using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manager_Hotel
{
    public partial class Main : Form
    {
        bool hiden = true;
        int pw;
        public Main()
        {
            InitializeComponent();
            pw = panelSlider.Width;
            panelSlider.Width = 0;
        }

       

        private void btnSlider_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (hiden)
            {
                panelSlider.Width = panelSlider.Width + 10;
                if (panelSlider.Width >= pw)
                {
                    timer1.Stop();
                    hiden = false;
                    this.Refresh();
                }

            }
            else
            {
                panelSlider.Width = panelSlider.Width - 10;
                if (panelSlider.Width <= 0)
                {
                    timer1.Stop();
                    hiden = true;
                    this.Refresh();
                }
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.ShowDialog();
            
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            DatPhong dp = new DatPhong();
            dp.ShowDialog();
        }

        private void btnNhanPhong_Click(object sender, EventArgs e)
        {
            NhanPhong np = new NhanPhong();
            np.ShowDialog();
        }

        private void btnSDDVTT_Click(object sender, EventArgs e)
        {
            SuDungDichVuVaThanToan dvtt = new SuDungDichVuVaThanToan();
            dvtt.ShowDialog();
        }

        private void btnQuanLiPhong_Click(object sender, EventArgs e)
        {
            QuanLiPhong qlp = new QuanLiPhong();
            qlp.ShowDialog();
        }

        private void btnQuanLiDatPhong_Click(object sender, EventArgs e)
        {
        }

        private void btnQuanLiNV_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien qlnv = new QuanLyNhanVien();

            qlnv.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        private void btnQLHoaDon_Click(object sender, EventArgs e)
        {
            InHoaDon print = new InHoaDon();
            print.ShowDialog();


        }

        private void btnSubLogOut_Click(object sender, EventArgs e)
        {
            
        }
    }
}
