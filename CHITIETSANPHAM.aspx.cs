using System;
using System.Data;
using System.Web.UI;
using QUANLYBANHANG_ONLINE.App_Code;

namespace QUANLYBANHANG_ONLINE
{
    public partial class CHITIETSANPHAM : System.Web.UI.Page
    {
        XULYDULIEU xuly = new XULYDULIEU();
        DataTable tbSANPHAM; // Khai báo toàn cục để sự kiện Click giỏ hàng có thể dùng lại dữ liệu

        protected void Page_Load(object sender, EventArgs e)
        {
            string masanpham = Request.QueryString["MASANPHAM"];

            if (!string.IsNullOrEmpty(masanpham))
            {
                // Truy vấn trực tiếp theo phong cách code hiện tại của bạn
                string sql = "SELECT * FROM tbSANPHAM WHERE MASANPHAM = " + masanpham;
                tbSANPHAM = xuly.getTable(sql);

                // Chỉ DataBind lần đầu mở trang để tránh mất sự kiện Click của nút giỏ hàng khi PostBack
                if (!IsPostBack)
                {
                    if (tbSANPHAM != null && tbSANPHAM.Rows.Count > 0)
                    {
                        Repeater1.DataSource = tbSANPHAM;
                        Repeater1.DataBind();
                    }
                }
            }
        }

        // Sự kiện khi người dùng click vào nút giỏ hàng (Imagecart)
        protected void Imagecart_Click(object sender, ImageClickEventArgs e)
        {
            Session.Timeout = 20;
            App_Code.CART cart = new App_Code.CART();

            if (tbSANPHAM != null && tbSANPHAM.Rows.Count > 0)
            {
                string masanpham = tbSANPHAM.Rows[0]["MASANPHAM"].ToString();
                string tensanpham = tbSANPHAM.Rows[0]["TENSANPHAM"].ToString();
                double dongia = Convert.ToDouble(tbSANPHAM.Rows[0]["DONGIA"]);
                string hinhanh = tbSANPHAM.Rows[0]["HINHANH"].ToString();

                // Nếu trong phiên làm việc đã có giỏ hàng thì lấy lại giỏ hàng cũ
                if (Session["CART"] != null)
                {
                    cart = (App_Code.CART)Session["CART"];
                }

                // Thêm sản phẩm vào giỏ (số lượng mặc định là 1) và lưu lại vào Session
                cart.AddCart(masanpham, tensanpham, hinhanh, 1, dongia);
                Session["CART"] = cart;

                // Chuyển hướng sang trang giỏ hàng
                Response.Redirect("pageGIOHANG.aspx");
            }
        }
    }
}