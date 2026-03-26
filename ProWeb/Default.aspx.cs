using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                }
                catch (Exception ex) { Console.WriteLine("User operation has failed. Error: {0}", ex.Message); }
            }
            return;
        }

        protected void ReadButton_onClick(object sender, EventArgs e) {
            if (Page.IsValid) {
                try {
                    string code = TB_Code.Text.Trim();
                    ENProduct en = new ENProduct(code, "", -1, -1, -1, DateTime.MinValue);
                    en.Read();
                }
                catch (Exception ex) { Console.WriteLine("User operation has failed. Error: {0}", ex.Message); }
            }
            return;
        }

        protected void ReadFirstButton_onClick(object sender, EventArgs e) {
            if (Page.IsValid) {
                try {
                    string code = TB_Code.Text.Trim();
                    ENProduct en = new ENProduct(code, "", -1, -1, -1, DateTime.MinValue);
                    en.ReadFirst();
                }
                catch (Exception ex) { Console.WriteLine("User operation has failed. Error: {0}", ex.Message); }
            }
            return;
        }

        protected void ReadPrevButton_onClick(object sender, EventArgs e) {
            if (Page.IsValid) {
                try {
                    string code = TB_Code.Text.Trim();
                    ENProduct en = new ENProduct(code, "", -1, -1, -1, DateTime.MinValue);
                    en.ReadPrev();
                }
                catch (Exception ex) { Console.WriteLine("User operation has failed. Error: {0}", ex.Message); }
            }
            return;
        }

        protected void ReadNextButton_onClick(object sender, EventArgs e) {
            if (Page.IsValid) {
                try {
                    string code = TB_Code.Text.Trim();
                    ENProduct en = new ENProduct(code, "", -1, -1, -1, DateTime.MinValue);
                    en.Read();
                }
                catch (Exception ex) { Console.WriteLine("User operation has failed. Error: {0}", ex.Message); }
            }
            return;
        }
    }
}