using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace ProWeb {
    public partial class WebForm1 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void Date_ServerValidate (object sender, ServerValidateEventArgs args) {
            DateTime result;
            if (args.Value == null) {
                args.IsValid = false;
                return;
            }
            if (DateTime.TryParseExact(args.Value, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out result)) {
                args.IsValid = true;
                return;
            }
            args.IsValid = false;
        }

        protected void CreateButton_onClick(object sender, EventArgs e) {
            if (Page.IsValid) {
                try {
                    string code = TB_Code.Text.Trim();
                    string name = TB_Name.Text.Trim();
                    int amount = int.Parse(TB_Amount.Text.Trim());
                    float price = float.Parse(TB_Price.Text.Trim());
                    int category = int.Parse(DDL_Category.SelectedValue);
                    DateTime creationDate;
                    DateTime.TryParseExact(TB_Date.Text.Trim(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out creationDate);
                    
                    ENProduct en = new ENProduct(code, name, amount, price, category, creationDate);
                    en.Create();

                    TB_Code.Text = "";
                    TB_Name.Text = "";
                    TB_Amount.Text = "";
                    TB_Price.Text = "";
                    DDL_Category.SelectedIndex = 0;
                    TB_Date.Text = "";
                } 
                catch (Exception ex) { Console.WriteLine("User operation has failed. Error: {0}", ex.Message); }
            }
            return;
        }

        protected void UpdateButton_onClick(object sender, EventArgs e) {
            if (Page.IsValid) {
                try {
                    string code = TB_Code.Text.Trim();
                    string name = TB_Name.Text.Trim();
                    int amount = int.Parse(TB_Amount.Text.Trim());
                    float price = float.Parse(TB_Price.Text.Trim());
                    int category = int.Parse(DDL_Category.SelectedValue);
                    DateTime creationDate;
                    DateTime.TryParseExact(TB_Date.Text.Trim(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out creationDate);
                    
                    ENProduct en = new ENProduct(code, name, amount, price, category, creationDate);
                    en.Update();

                    TB_Code.Text = "";
                    TB_Name.Text = "";
                    TB_Amount.Text = "";
                    TB_Price.Text = "";
                    DDL_Category.SelectedIndex = 0;
                    TB_Date.Text = "";
                }
                catch (Exception ex) { Console.WriteLine("User operation has failed. Error: {0}", ex.Message); }
            }
            return;
        }

        protected void DeleteButton_onClick(object sender, EventArgs e) {
            if (Page.IsValid) {
                try {
                    string code = TB_Code.Text.Trim();
                    string name = TB_Name.Text.Trim();
                    int amount = int.Parse(TB_Amount.Text.Trim());
                    float price = float.Parse(TB_Price.Text.Trim());
                    int category = int.Parse(DDL_Category.SelectedValue);
                    DateTime creationDate;
                    DateTime.TryParseExact(TB_Date.Text.Trim(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out creationDate);
                    
                    ENProduct en = new ENProduct(code, name, amount, price, category, creationDate);
                    en.Delete();

                    TB_Code.Text = "";
                    TB_Name.Text = "";
                    TB_Amount.Text = "";
                    TB_Price.Text = "";
                    DDL_Category.SelectedIndex = 0;
                    TB_Date.Text = "";
                }
                catch (Exception ex) { Console.WriteLine("User operation has failed. Error: {0}", ex.Message); }
            }
            return;
        }

        protected void ReadButton_onClick(object sender, EventArgs e) {
            Page.Validate("Read");
            try {
                string code = TB_Code.Text.Trim();
                    
                ENProduct en = new ENProduct(code, "", -1, -1, -1, DateTime.MinValue);
                if (en.Read()) {

                    TB_Code.Text = en.Code;
                    TB_Name.Text = en.Name;
                    TB_Amount.Text = en.Amount.ToString();
                    TB_Price.Text = en.Price.ToString();
                    DDL_Category.SelectedIndex = en.Category - 1; //For dealing with the offset
                    TB_Date.Text = en.CreationDate.ToString();
                }
            }
            catch (Exception ex) { Console.WriteLine("User operation has failed. Error: {0}", ex.Message); }
        }

        protected void ReadFirstButton_onClick(object sender, EventArgs e) {
            try {
                ENProduct en = new ENProduct("", "", -1, -1, -1, DateTime.MinValue);
                if (en.ReadFirst()) {

                    TB_Code.Text = en.Code;
                    TB_Name.Text = en.Name;
                    TB_Amount.Text = en.Amount.ToString();
                    TB_Price.Text = en.Price.ToString();
                    DDL_Category.SelectedIndex = en.Category - 1; //For dealing with the offset
                    TB_Date.Text = en.CreationDate.ToString();
                }
            }
            catch (Exception ex) { Console.WriteLine("User operation has failed. Error: {0}", ex.Message); }
        }

        protected void ReadPrevButton_onClick(object sender, EventArgs e) {
            Page.Validate("Read");
            try {
                string code = TB_Code.Text.Trim();
                ENProduct en = new ENProduct(code, "", -1, -1, -1, DateTime.MinValue);
                    
                if (en.ReadPrev()) {

                    TB_Code.Text = en.Code;
                    TB_Name.Text = en.Name;
                    TB_Amount.Text = en.Amount.ToString();
                    TB_Price.Text = en.Price.ToString();
                    DDL_Category.SelectedIndex = en.Category - 1; //For dealing with the offset
                    TB_Date.Text = en.CreationDate.ToString();
                }
            }
            catch (Exception ex) { Console.WriteLine("User operation has failed. Error: {0}", ex.Message); }
        }

        protected void ReadNextButton_onClick(object sender, EventArgs e) {
            Page.Validate("Read");
            try {
                string code = TB_Code.Text.Trim();
                ENProduct en = new ENProduct(code, "", -1, -1, -1, DateTime.MinValue);
                if (en.ReadNext()) {

                    TB_Code.Text = en.Code;
                    TB_Name.Text = en.Name;
                    TB_Amount.Text = en.Amount.ToString();
                    TB_Price.Text = en.Price.ToString();
                    DDL_Category.SelectedIndex = en.Category - 1; //For dealing with the offset
                    TB_Date.Text = en.CreationDate.ToString();
                }
            }
            catch (Exception ex) { Console.WriteLine("User operation has failed. Error: {0}", ex.Message); }
        }
    }
}