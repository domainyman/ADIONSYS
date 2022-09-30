using ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.Brand.Create;
using ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.Brand.Delete;
using ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.Brand.Edit;
using ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.CategorySet.Create;
using ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.CategorySet.Delete;
using ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.CategorySet.Edit;
using ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.ProductItem.Create;
using ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.ProductItem.Delete;
using ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.ProductItem.Edit;
using ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.StorageSet.Create;
using ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.StorageSet.Delete;
using ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.StorageSet.Edit;
using ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.SupplierSet.Create;
using ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.SupplierSet.Delete;
using ADIONSYS.Plugin.POS.Warehose.Product.ProductSet.SupplierSet.Edit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADIONSYS.Plugin.POS.Warehose.Product.ProductSet
{
    public partial class ProductSettingForm : Form
    {
        public ProductSettingForm()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            CreateCategory CreateCategory = new CreateCategory();
            CreateCategory.ShowDialog();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteCategory DeleteCategory = new DeleteCategory();
            DeleteCategory.ShowDialog();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EditCategory EditCategory = new EditCategory();
            EditCategory.ShowDialog();
        }

        private void BtnSupplierCreate_Click(object sender, EventArgs e)
        {
            CreateSupplier CreateSupplier = new CreateSupplier();
            CreateSupplier.ShowDialog();
        }

        private void BtnSupplierDelete_Click(object sender, EventArgs e)
        {
            DeleteSupplier DeleteSupplier = new DeleteSupplier();
            DeleteSupplier.ShowDialog();
        }

        private void BtnSupplierEdit_Click(object sender, EventArgs e)
        {
            ChooseSupplier ChooseSupplier = new ChooseSupplier();
            ChooseSupplier.ShowDialog();
        }

        private void BtnBraCre_Click(object sender, EventArgs e)
        {
            CreateBrand CreateBrand = new CreateBrand();
            CreateBrand.ShowDialog();
        }

        private void BtnBraDel_Click(object sender, EventArgs e)
        {
            DeleteBrand DeleteBrand = new DeleteBrand();
            DeleteBrand.ShowDialog();

        }

        private void BtnBraEdit_Click(object sender, EventArgs e)
        {
            EditBrand EditBrand = new EditBrand();
            EditBrand.ShowDialog();
        }

        private void BtnStorCre_Click(object sender, EventArgs e)
        {
            CreateStorage CreateStorage = new CreateStorage();
            CreateStorage.ShowDialog();
        }

        private void BtnStorDel_Click(object sender, EventArgs e)
        {
            DeleteStorage DeleteStorage = new DeleteStorage();
            DeleteStorage.ShowDialog();
        }

        private void BtnStorEdit_Click(object sender, EventArgs e)
        {
            ChooseStorage ChooseStorage = new ChooseStorage();
            ChooseStorage.ShowDialog();
        }

        private void BtnProCre_Click(object sender, EventArgs e)
        {
            CreateProduct CreateProduct = new CreateProduct();
            CreateProduct.ShowDialog();
        }

        private void BtnProDel_Click(object sender, EventArgs e)
        {
            DeleteProduct DeleteProduct = new DeleteProduct();
            DeleteProduct.ShowDialog();
        }

        private void BtnProEdit_Click(object sender, EventArgs e)
        {
            ChooseProduct ChooseProduct = new ChooseProduct();
            ChooseProduct.ShowDialog();

        }
    }
}
