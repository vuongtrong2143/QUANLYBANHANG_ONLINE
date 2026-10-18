<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QUANLYSANPHAM_GUI.aspx.cs" Inherits="QUANLYBANHANG_ONLINE.ADMIN.GUI.QUANLYSANPHAM_GUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý sản phẩm</title>
    <style type="text/css">
        .table-admin {
            width: 750px;
            margin: 20px auto;
            border-collapse: collapse;
            background-color: #d8ecf8;
            font-family: Arial, sans-serif;
            font-size: 14px;
        }
        .table-admin td {
            padding: 6px 10px;
        }
        .title-header {
            font-weight: bold;
            font-size: 16px;
            text-align: center;
            padding: 12px !important;
        }
        .text-input {
            width: 250px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table-admin" border="1" cellpadding="0" cellspacing="0">
            <!-- Tiêu đề trang -->
            <tr>
                <td colspan="2" class="title-header">
                    QUẢN LÝ DANH SÁCH SẢN PHẨM
                </td>
            </tr>

            <!-- 1. Danh mục sản phẩm (DropDownList) -->
            <tr>
                <td style="width: 150px;">Mã danh mục</td>
                <td>
                    <asp:DropDownList ID="drpDANHMUC" runat="server" Width="180px">
                    </asp:DropDownList>
                </td>
            </tr>

            <!-- 2. Mã sản phẩm (TextBox) -->
            <tr>
                <td>Mã sản phẩm</td>
                <td>
                    <asp:TextBox ID="txtMASANPHAM" runat="server" CssClass="text-input"></asp:TextBox>
                </td>
            </tr>

            <!-- 3. Tên sản phẩm (TextBox) -->
            <tr>
                <td>Tên sản phẩm</td>
                <td>
                    <asp:TextBox ID="txtTENSANPHAM" runat="server" CssClass="text-input"></asp:TextBox>
                </td>
            </tr>

            <!-- 4. Đơn giá (TextBox) -->
            <tr>
                <td>Đơn giá</td>
                <td>
                    <asp:TextBox ID="txtDONGIA" runat="server" CssClass="text-input"></asp:TextBox>
                </td>
            </tr>

            <!-- 5. Số lượng (TextBox) -->
            <tr>
                <td>Số lượng</td>
                <td>
                    <asp:TextBox ID="txtSOLUONG" runat="server" CssClass="text-input"></asp:TextBox>
                </td>
            </tr>

            <!-- 6. Upload Ảnh (FileUpload) -->
            <tr>
                <td>Upload Ảnh</td>
                <td>
                    <asp:FileUpload ID="FileANHSANPHAM" runat="server" />
                </td>
            </tr>

            <!-- 7. Mô tả (Multiline TextBox) -->
            <tr>
                <td colspan="2" align="center">
                    MÔ TẢ<br />
                    <asp:TextBox ID="txtMOTA" runat="server" TextMode="MultiLine" Rows="5" Width="95%"></asp:TextBox>
                </td>
            </tr>

            <!-- 8. Nhóm nút bấm Thêm / Xóa / Sửa (Button) -->
            <tr>
                <td colspan="2" align="center" style="padding: 10px;">
                    <asp:Button ID="btnInsert" runat="server" Text="Thêm mới" OnClick="btnInsert_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnDelete" runat="server" Text="Xóa" OnClick="btnDelete_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnUpdate" runat="server" Text="Sửa" OnClick="btnUpdate_Click" />
                </td>
            </tr>

            <!-- 9. Bảng danh sách sản phẩm (GridView) -->
            <tr>
                <td colspan="2">
                    <asp:GridView ID="grvSANPHAM" runat="server" AutoGenerateColumns="False" Width="100%" 
                        CellPadding="4" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
                        <Columns>
                            <asp:BoundField DataField="MASANPHAM" HeaderText="Mã sản phẩm" />
                            <asp:BoundField DataField="TENSANPHAM" HeaderText="Tên sản phẩm" />
                            <asp:BoundField DataField="DONGIA" HeaderText="Đơn giá" />
                            <asp:BoundField DataField="SOLUONG" HeaderText="Số lượng" />
                            <asp:ImageField DataAlternateTextField="HINHANH" DataImageUrlField="HINHANH" 
                                DataImageUrlFormatString="images/{0}" HeaderText="Ảnh sản phẩm">
                                <ControlStyle Width="60px" Height="60px" />
                            </asp:ImageField>
                        </Columns>
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <RowStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
