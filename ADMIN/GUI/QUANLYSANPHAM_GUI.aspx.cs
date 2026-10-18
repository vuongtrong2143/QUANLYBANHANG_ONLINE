using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QUANLYBANHANG_ONLINE.ADMIN.BUSINESSLOGIC;

namespace QUANLYBANHANG_ONLINE.ADMIN.GUI
{
    public partial class QUANLYSANPHAM_GUI : System.Web.UI.Page
    {
        QUANLYSANPHAM_BUSINESSLOGIC businesslogic;

        protected void Page_Load(object sender, EventArgs e)
        {
            businesslogic = new QUANLYSANPHAM_BUSINESSLOGIC(this);

            if (!IsPostBack)
            {
                businesslogic.SetValueDropdownlistDanhMuc();
                businesslogic.SetValueGridViewSanPham();
            }
        }

        // Sự kiện Thêm mới sản phẩm
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            int k = businesslogic.InsertRecordSanPham();
            businesslogic.SetValueGridViewSanPham();
        }

        // Sự kiện Xóa sản phẩm
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            businesslogic.DeleteRecordSanPham();
            businesslogic.SetValueGridViewSanPham();
        }

        // Sự kiện Cập nhật sản phẩm
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int k = businesslogic.UpdateRecordSanPham();
            businesslogic.SetValueGridViewSanPham();
        }
    }
}