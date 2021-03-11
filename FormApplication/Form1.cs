using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FormApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadGrids();
        }

        CarManager _carManager = new CarManager(new EfCarDal());
        BrandManager _brandManager = new BrandManager(new EfBrandDal());
        ColorManager _colorManager = new ColorManager(new EfColorDal());

        private void LoadGrids()
        {
            var carresult = _carManager.GetAll();
            List<Car> carList = carresult.Data;

            var brandresult = _brandManager.GetAll();
            List<Brand> brandList = brandresult.Data;

            var colorresult = _colorManager.GetAll();
            List<Entities.Concrete.Color> colorList = colorresult.Data;

            cargridview.DataSource = carList;
            brandgridview.DataSource = brandList;
            colorgridview.DataSource = colorList;
        }
        private void addcarbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(addcarnamebox.Text)
                || string.IsNullOrEmpty(addcarbrandidbox.Text)
                || string.IsNullOrEmpty(addcarcoloridbox.Text)
                || string.IsNullOrEmpty(addcardailypricebox.Text)
                || string.IsNullOrEmpty(addcarmodelyearbox.Text))
            {
                string message = String.Format("Car couldn't added ! \n --YOU MUST FILL ALL THE BOXES--");
                MessageBox.Show(message, "ADD OPERATION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var result = _carManager.Add(new Car
                {
                    CarName = addcarnamebox.Text,
                    BrandId = Convert.ToInt32(addcarbrandidbox.Text),
                    ColorId = Convert.ToInt32(addcarcoloridbox.Text),
                    DailyPrice = Convert.ToDecimal(addcardailypricebox.Text),
                    ModelYear = addcarmodelyearbox.Text,
                    Description = addcardescriptionbox.Text
                });
                if (result.Success)
                {
                    string message = String.Format("Car Name: {0}  \n ADDED !", addcarnamebox.Text);
                    MessageBox.Show(message, "ADD OPERATION SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    deletebrandidbox.Text = String.Empty;

                }
                else // BUSINESS RULES WILL BE ADDED HERE
                {
                    string message = String.Format("Car Name: {0} couldn't added !", addcarnamebox.Text);
                    MessageBox.Show(message, "ADD OPERATION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            LoadGrids();
            addcarnamebox.Text = String.Empty;
            addcarbrandidbox.Text = String.Empty;
            addcarcoloridbox.Text = String.Empty;
            addcardailypricebox.Text = String.Empty;
            addcarmodelyearbox.Text = String.Empty;
            addcardescriptionbox.Text = String.Empty;
        }

        private void deletecarbutton_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(deletecaridbox.Text)))
            {
                int id = Convert.ToInt32(deletecaridbox.Text);
                Car carToDelete = _carManager.GetById(id).Data;
                var result = _carManager.Delete(carToDelete);
                if (result.Success)
                {
                    string message = String.Format("Car ID: {0}  \n DELETED !", id);
                    MessageBox.Show(message, "DELETE OPERATION SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // BUSINESS RULES WILL BE ADDED HERE
                {
                    string message = String.Format("Car ID: {0} couldn't deleted !", id);
                    MessageBox.Show(message, "DELETE OPERATION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string message = String.Format("Car couldn't deleted ! \n --YOU MUST ENTER AN ID--");
                MessageBox.Show(message, "DELETE OPERATION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadGrids();
            deletecaridbox.Text = String.Empty;
        }

        private void updatecarbutton_Click(object sender, EventArgs e)
        {

            Car carToUpdate = null;
            string finalMessage = "";
            if (!string.IsNullOrEmpty(updatecaridbox.Text))
            {
                int id = Convert.ToInt32(updatecaridbox.Text);
                carToUpdate = _carManager.GetById(id).Data;
                finalMessage += String.Format("Car ID: {0} UPDATED ! \n", id);
                if (!string.IsNullOrEmpty(updatecarnamebox.Text))
                {
                    finalMessage += carToUpdate.CarName + " => " + updatecarnamebox.Text + "\n";
                    carToUpdate.CarName = updatecarnamebox.Text;
                }
                if (!string.IsNullOrEmpty(updatecarbrandidbox.Text))
                {
                    finalMessage += carToUpdate.BrandId + " => " + updatecarbrandidbox.Text + "\n";
                    carToUpdate.BrandId = Convert.ToInt32(updatecarbrandidbox.Text);
                }
                if (!string.IsNullOrEmpty(updatecarcoloridbox.Text))
                {
                    finalMessage += carToUpdate.ColorId + " => " + updatecarcoloridbox.Text + "\n";
                    carToUpdate.ColorId = Convert.ToInt32(updatecarcoloridbox.Text);
                }
                if (!string.IsNullOrEmpty(updatecarpricebox.Text))
                {
                    finalMessage += carToUpdate.DailyPrice + " => " + updatecarpricebox.Text + "\n";
                    carToUpdate.DailyPrice = Convert.ToDecimal(updatecarpricebox.Text);
                }
                if (!string.IsNullOrEmpty(updatecarmodelyearbox.Text))
                {
                    finalMessage += carToUpdate.ModelYear + " => " + updatecarmodelyearbox.Text + "\n";
                    carToUpdate.ModelYear = updatecarmodelyearbox.Text;
                }
                if (!string.IsNullOrEmpty(updatecardescbox.Text))
                {
                    finalMessage += "Description Updated";
                    carToUpdate.Description = updatecardescbox.Text;
                }

                var result = _carManager.Update(carToUpdate);
                if (result.Success)
                {
                    string initialMessage = String.Format("Car ID: {0} UPDATED ! \n", id);
                    if (string.Equals(finalMessage, initialMessage))
                        finalMessage = "--NOTHING HAS CHANGED--";
                    MessageBox.Show(finalMessage, "UPDATE OPERATION SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // BUSINESS RULES WILL BE ADDED HERE
                {
                    string message = String.Format("Car ID: {0} couldn't updated !", carToUpdate.CarId);
                    MessageBox.Show(message, "UPDATE OPERATION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string message = String.Format("CAR ID MUST BE ENTERED !");
                MessageBox.Show(message, "DELETE OPERATION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadGrids();
            updatecaridbox.Text = String.Empty;
            updatecarnamebox.Text = String.Empty;
            updatebrandidbox.Text = String.Empty;
            updatecarcoloridbox.Text = String.Empty;
            updatecarpricebox.Text = String.Empty;
            updatecarmodelyearbox.Text = String.Empty;
            updatecardescbox.Text = String.Empty;
        }
        private void addbrandbutton_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(addbrandnamebox.Text)))
            {
                var result = _brandManager.Add(new Brand { BrandName = addbrandnamebox.Text });
                if (result.Success)
                {
                    string message = String.Format("Brand Name: {0} \n ADDED !", addbrandnamebox.Text);
                    MessageBox.Show(message, "ADD OPERATION SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // BUSINESS RULES WILL BE ADDED HERE
                {
                    string message = String.Format("Brand Name: {0} couldn't ADDED !", addbrandnamebox.Text);
                    MessageBox.Show(message, "ADD OPERATION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string message = String.Format("Brand couldn't added ! \n --YOU MUST ENTER A BRAND NAME--");
                MessageBox.Show(message, "ADD OPERATION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadGrids();
            addbrandnamebox.Text = String.Empty;
        }

        private void deletebrandbutton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(deletebrandidbox.Text))
            {
                int id = Convert.ToInt32(deletebrandidbox.Text);
                Brand brandToDelete = _brandManager.GetById(id).Data;
                var result = _brandManager.Delete(brandToDelete);
                if (result.Success)
                {
                    string message = String.Format("Brand ID: {0}  \n DELETED !", id);
                    MessageBox.Show(message, "DELETE OPERATION SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // BUSINESS RULES WILL BE ADDED HERE
                {
                    string message = String.Format("Brand ID: {0} couldn't deleted !", id);
                    MessageBox.Show(message, "DELETE OPERATION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string message = String.Format("Brand couldn't deleted ! \n --YOU MUST ENTER A BRAND ID--");
                MessageBox.Show(message, "DELETE OPERATION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadGrids();
            deletebrandidbox.Text = String.Empty;
        }

        private void updatebrandbutton_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(updatebrandidbox.Text) || string.IsNullOrEmpty(updatebrandnamebox.Text)))
            {
                int id = Convert.ToInt32(updatebrandidbox.Text);
                Brand brandToUpdate = _brandManager.GetById(id).Data;
                string oldName = brandToUpdate.BrandName;
                brandToUpdate.BrandName = updatebrandnamebox.Text;
                var result = _brandManager.Update(brandToUpdate);
                if (result.Success)
                {
                    string message = String.Format("Brand ID: {0}  \n UPDATED ! \n Brand name changed with : {1} => {2} ", id, oldName, updatebrandnamebox.Text);
                    MessageBox.Show(message, "UPDATE OPERATION SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // BUSINESS RULES WILL BE ADDED HERE
                {
                    string message = String.Format("Brand ID: {0} couldn't updated !", id);
                    MessageBox.Show(message, "UPDATE OPERATION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string message = String.Format("Brand couldn't updated ! \n --YOU MUST FILL ALL THE BOXES--");
                MessageBox.Show(message, "UPDATE OPERATION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadGrids();
            updatebrandidbox.Text = String.Empty;
            updatebrandnamebox.Text = String.Empty;
        }
        private void addcolorbutton_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(addcolornamebox.Text)))
            {
                var result = _colorManager.Add(new Entities.Concrete.Color { ColorName = addcolornamebox.Text });
                if (result.Success)
                {
                    string message = String.Format("Color Name: {0} \n ADDED !", addcolornamebox.Text);
                    MessageBox.Show(message, "ADD OPERATION SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // BUSINESS RULES WILL BE ADDED HERE
                {
                    string message = String.Format("Color Name: {0} couldn't ADDED !", addcolornamebox.Text);
                    MessageBox.Show(message, "ADD OPERATION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string message = String.Format("Color couldn't added ! \n --YOU MUST ENTER A COLOR NAME--");
                MessageBox.Show(message, "ADD OPERATION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadGrids();
            addcolornamebox.Text = String.Empty;
        }

        private void deletecolorbutton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(deletecoloridbox.Text))
            {
                int id = Convert.ToInt32(deletecoloridbox.Text);
                Entities.Concrete.Color colorToDelete = _colorManager.GetById(id).Data;
                var result = _colorManager.Delete(colorToDelete);
                if (result.Success)
                {
                    string message = String.Format("Color ID: {0}  \n DELETED !", id);
                    MessageBox.Show(message, "DELETE OPERATION SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // BUSINESS RULES WILL BE ADDED HERE
                {
                    string message = String.Format("Color ID: {0} couldn't deleted !", id);
                    MessageBox.Show(message, "DELETE OPERATION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string message = String.Format("Color couldn't deleted ! \n --YOU MUST ENTER A COLOR ID--");
                MessageBox.Show(message, "DELETE OPERATION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadGrids();
            deletecoloridbox.Text = String.Empty;
        }

        private void updatecolorbutton_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(updatecoloridbox.Text) || string.IsNullOrEmpty(updatecolornamebox.Text)))
            {
                int id = Convert.ToInt32(updatecoloridbox.Text);
                Entities.Concrete.Color colorToUpdate = _colorManager.GetById(id).Data;
                string oldName = colorToUpdate.ColorName;
                colorToUpdate.ColorName = updatecolornamebox.Text;
                var result = _colorManager.Update(colorToUpdate);
                if (result.Success)
                {
                    string message = String.Format("Color ID: {0}  \n UPDATED ! \n Color name changed with : {1} => {2} ", id, oldName, updatecolornamebox.Text);
                    MessageBox.Show(message, "UPDATE OPERATION SUCCESSFUL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // BUSINESS RULES WILL BE ADDED HERE
                {
                    string message = String.Format("Color ID: {0} couldn't updated !", id);
                    MessageBox.Show(message, "UPDATE OPERATION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                string message = String.Format("Color couldn't updated ! \n --YOU MUST FILL ALL THE BOXES--");
                MessageBox.Show(message, "UPDATE OPERATION ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadGrids();
            updatecoloridbox.Text = String.Empty;
            updatecolornamebox.Text = String.Empty;
        }
    }
}
