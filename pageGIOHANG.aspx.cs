using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace QUANLYBANHANG_ONLINE
{
    public partial class pageGIOHANG : System.Web.UI.Page
    {
        public void LoadCart()
        {
            if (Session["CART"] != null)
            {
                // Ép kiểu Session["CART"] về lớp CART
                App_Code.CART cart = (App_Code.CART)Session["CART"];

                this.grvCART.DataSource = cart.LISTCARTS.Values.ToList();
                this.grvCART.DataBind();
                this.grvCART.FooterRow.Cells[0].Text = "Tổng tiền=";
                this.grvCART.FooterRow.Cells[4].Text = cart.TotalBill().ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            if (!IsPostBack)
            {
                if (Session["CART"] == null)
                {
                    App_Code.CART demoCart = new App_Code.CART();

                    // Sản phẩm 1: THINKPAD W510 i7 EXTREME (SL: 2, Đơn giá: 300 => 600)
                    demoCart.AddCart("9", "THINKPAD W510 i7 EXTREME", "laptop.png", 2, 300);

                    // Sản phẩm 2: Laptop Dell Vostro 3420 I5 (SL: 1, Đơn giá: 300 => 300)
                    demoCart.AddCart("11", "Laptop Dell Vostro 3420 I5", "laptop.png", 1, 300);

                    // Sản phẩm 3: Samsung Z Flip/Fold (SL: 1, Đơn giá: 500 => 500)
                    demoCart.AddCart("10", "THINKPAD W510 i7 EXTREME", "SAMSUNG2.jfif", 1, 500);

                    Session["CART"] = demoCart;
                }
                LoadCart();
            }*/

            /*
            // Kiểm tra trạng thái đăng nhập
            if (Session["LOGIN"] != null)
            {
                DataTable tblogin = (DataTable)Session["LOGIN"];
                if (!IsPostBack && tblogin.Rows.Count > 0)
                {
                    LoadCart();
                }
            }
            else
            {
                Response.Redirect("Danhsachsanpham.aspx");
            }*/

            // Bỏ qua kiểm tra đăng nhập để vào thẳng xem giỏ hàng
            if (!IsPostBack)
            {
                LoadCart();
            }
        }

        protected void btnDELETE_Click(object sender, EventArgs e)
        {
            if (Session["CART"] != null)
            {
                App_Code.CART cart = (App_Code.CART)Session["CART"];

                foreach (GridViewRow row in grvCART.Rows)
                {
                    CheckBox ckb = (CheckBox)row.FindControl("ckbREMOVEITEM");
                    if (ckb != null && ckb.Checked)
                    {
                        string masanpham = row.Cells[0].Text;
                        cart.RemoveCart(masanpham);
                    }
                }

                Session["CART"] = cart;
                LoadCart();
            }
        }
    }
}