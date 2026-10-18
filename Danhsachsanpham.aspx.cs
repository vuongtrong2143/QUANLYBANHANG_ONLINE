using QUANLYBANHANG_ONLINE.App_Code;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QUANLYBANHANG_ONLINE
{
    public partial class Danhsachsanpham : System.Web.UI.Page
    {
        XULYDULIEU xuly = new XULYDULIEU();
        DataTable tbSANPHAM;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 1. Lấy mã danh mục truyền từ URL xuống
                string madanhmuc = Request.QueryString.Get("MADANHMUC");

                // 2. Mặc định lấy tất cả, nếu có chọn danh mục thì thêm điều kiện WHERE
                string sql = "SELECT * FROM tbSANPHAM";
                if (!string.IsNullOrEmpty(madanhmuc))
                {
                    sql += " WHERE MADANHMUC = " + madanhmuc;
                }

                // 3. Lấy dữ liệu và gán lên DataList
                DataTable dt = xuly.getTable(sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.DataList1.RepeatColumns = 3;
                    this.DataList1.DataSource = dt;
                    this.DataList1.DataBind();
                }
            }
        }
        // Sự kiện khi người dùng click vào nút giỏ hàng (Imagecart)
        /*        protected void Imagecart_Click(object sender, ImageClickEventArgs e)
                {
                    ImageButton btn = (ImageButton)sender;
                    string masanpham = btn.CommandArgument;

                    if (!string.IsNullOrEmpty(masanpham))
                    {
                        string sql = "SELECT * FROM tbSANPHAM WHERE MASANPHAM = " + masanpham;
                        DataTable tb = xuly.getTable(sql);

                        if (tb != null && tb.Rows.Count > 0)
                        {
                            Session.Timeout = 20; // 2 phút là hơi ngắn để test, có thể tăng lên
                            App_Code.CART cart = new App_Code.CART();

                            string tensanpham = tb.Rows[0]["TENSANPHAM"].ToString();
                            double dongia = Convert.ToDouble(tb.Rows[0]["DONGIA"]);
                            string hinhanh = tb.Rows[0]["HINHANH"].ToString();

                            if (Session["CART"] != null)
                                cart = (App_Code.CART)Session["CART"];

                            cart.AddCart(masanpham, tensanpham, hinhanh, 1, dongia);
                            Session["CART"] = cart;

                            Response.Redirect("pageGIOHANG.aspx");
                        }
                    }
                }*/
        protected void Imagecart_Click(object sender, ImageClickEventArgs e)
        {
            // Ép kiểu sender về ImageButton để đọc đúng CommandArgument
            ImageButton btn = (ImageButton)sender;
            string masanpham = btn.CommandArgument;

            if (!string.IsNullOrEmpty(masanpham))
            {
                // Truy vấn lấy thông tin đúng của sản phẩm vừa click
                DataTable dtSP = xuly.getTable("SELECT * FROM tbSANPHAM WHERE MASANPHAM = " + masanpham);
                if (dtSP != null && dtSP.Rows.Count > 0)
                {
                    string tensanpham = dtSP.Rows[0]["TENSANPHAM"].ToString();
                    double dongia = Convert.ToDouble(dtSP.Rows[0]["DONGIA"]);
                    string hinhanh = dtSP.Rows[0]["HINHANH"].ToString();

                    App_Code.CART cart = new App_Code.CART();
                    if (Session["CART"] != null)
                    {
                        cart = (App_Code.CART)Session["CART"];
                    }

                    cart.AddCart(masanpham, tensanpham, hinhanh, 1, dongia);
                    Session["CART"] = cart;

                    Response.Redirect("pageGIOHANG.aspx");
                }
            }
        }
    }
}