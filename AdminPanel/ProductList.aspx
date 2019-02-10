<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="AdminPanel.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- content -->
    <section class="content">
        <div class="row">
            <div class="col-xs-12">
                <div class="box">

                    <div class="box-header with-border">
                        <h3 class="box-title"><%=PageTitle %></h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <asp:Button ID="BtnAddNew" class="btn btn-primary" runat="server" Text="Add New" OnClick="BtnAddNew_Click" />
                        <div class="row List_satirlar">
                            <table id="example2" class="table table-bordered table-hover">
                                <%
                                    var test = HttpContext.Current.Request.Cookies["locale"].Value.ToString();

                                    var a = test;
                                %>
                                <thead>
                                    <tr>
                                        <th>ID No</th>
                                        <th><%=AdminPanel.Resources.Index.ProductName %></th>
                                        <th><%=AdminPanel.Resources.Index.ProductDescription %></th>
                                        <th><%=AdminPanel.Resources.Index.ProductsCategory %></th>
                                        <th><%=AdminPanel.Resources.Index.ProductCode %></th>
                                        <th><%=AdminPanel.Resources.Index.ProductUrl %></th>
                                        <th><%=AdminPanel.Resources.Index.ProductPhoto %></th>
                                        <th><%=AdminPanel.Resources.Index.Actions %></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%foreach (var item in products)

                                        {
                                             Image1.ImageUrl = item.ProductPhoto.ToString();

                                            if (Image1.ImageUrl == "")
                                            {
                                                Image1.ImageUrl = "~\\Content\\img\\resimyok.png";
                                            }
                                            
                                    %>

                                    <tr>
                                        <td><%=item.id %></td>
                                        <%if (test == "tr-TR")
                                            {

                                        %>
                                        
                                        <td><%=item.ProductNameTR  %></td>
                                        <td><%# (Eval("ProductDescriptionTR").ToString().Length > 40) ? Eval("ProductDescriptionTR").ToString().Substring(0,40) : Eval("ProductDescriptionTR").ToString() %>...
                                        </td>                                      

                                      
                                        <%} %>
                                        <% 
                                            else if (test == "en-US")
                                            {%>
                                       
                                        <td><%=item.ProductNameEN  %></td>
                                        <td><%# (Eval("ProductDescriptionEN").ToString().Length > 40) ? Eval("ProductDescriptionEN").ToString().Substring(0,40) : Eval("ProductDescriptionEN").ToString() %>...
                                        </td>
                                         <%} %>
                                        <td><%=item.ProductCategory  %></td>
                                        <td><%=item.ProductCode  %></td>
                                        <td><%=item.ProductURL  %></td>
                                        <td>
                                            <asp:Image ID="Image1" runat="server" Width="50px" Height="50px" ImageUrl="" />

                                        </td>
                                       
                                        <td>
                                            <div class="col-lg-2 col-md-2 col-sm-1">
                                                <p><a href="/AddNewProduct.aspx?Process=EditProduct&id=<%= item.id %>"><%= AdminPanel.Resources.Index.Edit %></a></p>
                                                <p><a href="/AddNewProduct.aspx?process=DeleteProduct&id=<%= item.id %>"><%= AdminPanel.Resources.Index.Delete %></a></p>
                                            </div>
                                        </td>
                                    </tr>
                                    <%} %>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th>ID No</th>
                                        <th><%=AdminPanel.Resources.Index.ProductName %></th>
                                        <th><%=AdminPanel.Resources.Index.ProductDescription %></th>
                                        <th><%=AdminPanel.Resources.Index.ProductsCategory %></th>
                                        <th><%=AdminPanel.Resources.Index.ProductCode %></th>
                                        <th><%=AdminPanel.Resources.Index.ProductUrl %></th>
                                        <th><%=AdminPanel.Resources.Index.ProductPhoto %></th>
                                        <th><%=AdminPanel.Resources.Index.Actions %></th>
                                    </tr>
                                </tfoot>

                            </table>

                        </div>
                        <!-- /.box-body -->
                    </div>
                    <!-- /.box -->

                    <!-- /.box -->
                </div>
                <!-- /.col -->
            </div>
            <!-- /.row -->
    </section>
    <!-- /content -->


</asp:Content>
