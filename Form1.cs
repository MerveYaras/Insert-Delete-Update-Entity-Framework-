using CRUD_Northwind.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_Northwind
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool kaydet = true;
        int id;
        private void btnListele_Click(object sender, EventArgs e)
        {
            NorthwindDbContext tablo = new NorthwindDbContext();
            List<Category> c = tablo.Categories.ToList();
            dataGridView1.DataSource = c;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (kaydet == true)
            {
                NorthwindDbContext tablo = new NorthwindDbContext();
                Category c1 = tablo.Categories.FirstOrDefault(x => x.CategoryName == txtAd.Text);

                if (c1 == null)
                {
                    Category c = new Category();
                    c.Description = txtDesciption.Text;
                    c.CategoryName = txtAd.Text;
                    tablo.Categories.Add(c);
                    tablo.SaveChanges();
                    txtAd.Text = "";
                    txtDesciption.Text = "";
                    MessageBox.Show("Kayıt Yapılmıştır.");

                }
                else
                {
                    MessageBox.Show("Bu kategori zatenkayıtlıdır.");
                }
            }
            else
            {
                NorthwindDbContext tablo = new NorthwindDbContext();
                id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                Category c = tablo.Categories.FirstOrDefault(x => x.CategoryID == id);
                c.Description = txtDesciption.Text;
                c.CategoryName = txtAd.Text;
                tablo.SaveChanges();
                kaydet = true;
                txtAd.Text = "";
                txtDesciption.Text = "";
                MessageBox.Show("Kayıt Yapılmıştır.");

            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                NorthwindDbContext tablo = new NorthwindDbContext();
                id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                txtAd.Text = tablo.Categories.FirstOrDefault(x => x.CategoryID == id).CategoryName;
                txtDesciption.Text = tablo.Categories.FirstOrDefault(x => x.CategoryID == id).Description;
            }
            else { MessageBox.Show("Lütfen güncellenecek satırı seçiniz."); }
            kaydet = false;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                NorthwindDbContext tablo = new NorthwindDbContext();
                id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                Category c = tablo.Categories.FirstOrDefault(x => x.CategoryID == id);
                tablo.Categories.Remove(c);
                tablo.SaveChanges();
                MessageBox.Show("Silme İşlemi Tamamlandı.");
            }
            else
            { MessageBox.Show("Lütfen Silinecek satırı seçiniz."); }

        }


    }

}


