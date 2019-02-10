<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GalleryList.aspx.cs" Inherits="AdminPanel.GalleryList" %>

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
                                        <th><%=AdminPanel.Resources.Index.GalleryName %></th>
                                        <th><%=AdminPanel.Resources.Index.GalleryCategory %></th>
                                        <th><%=AdminPanel.Resources.Index.GallleryPhoto %></th>
                                        <th><%=AdminPanel.Resources.Index.GallleryPhoto %></th>
                                        <th><%=AdminPanel.Resources.Index.GallleryPhoto %></th>
                                        <th><%=AdminPanel.Resources.Index.GallleryPhoto %></th>
                                        <th><%=AdminPanel.Resources.Index.Actions %></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%foreach (var item in galleriess)

                                        {
                                            Image1.ImageUrl = item.GaleryPhoto1.ToString();
                                            Image2.ImageUrl = item.GaleryPhoto2.ToString();
                                            Image3.ImageUrl = item.GaleryPhoto3.ToString();
                                            Image4.ImageUrl = item.GaleryPhoto4.ToString();

                                    %>

                                    <tr>

                                        <%if (test == "tr-TR")
                                            {

                                        %>

                                        <td><%=item.id %></td>
                                        <td><%=item.GaleryNameTR  %></td>
                                        <td><%=item.GaleryCategory  %></td>
                                        <%} %>
                                        <% 
                                            else if (test == "en-US")
                                            {%>
                                        <td><%=item.id %></td>
                                        <td><%=item.GaleryNameEN  %></td>
                                        <td><%=item.GaleryCategory  %></td>
                                        <%} %>
                                        <td>
                                            <asp:Image ID="Image1" runat="server" Width="50px" Height="50px" ImageUrl="" />
                                        </td>
                                        <td>
                                            <asp:Image ID="Image2" runat="server" Width="50px" Height="50px" ImageUrl="" />
                                        </td>
                                        <td>
                                            <asp:Image ID="Image3" runat="server" Width="50px" Height="50px" ImageUrl="" />
                                        </td>
                                        <td>
                                            <asp:Image ID="Image4" runat="server" Width="50px" Height="50px" ImageUrl="" />

                                        </td>
                                        <td>
                                            <div class="col-lg-2 col-md-2 col-sm-1">
                                                <p><a href="/AddNewGallery.aspx?Process=EditGallery&id=<%= item.id %>"><%= AdminPanel.Resources.Index.Edit %></a></p>
                                                <p><a href="/AddNewGallery.aspx?Process=DeleteGallery&id=<%= item.id %>"><%= AdminPanel.Resources.Index.Delete %></a></p>
                                            </div>
                                        </td>
                                    </tr>
                                    <%} %>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th>ID No</th>
                                        <th><%=AdminPanel.Resources.Index.GalleryName %></th>
                                        <th><%=AdminPanel.Resources.Index.GalleryCategory %></th>
                                        <th><%=AdminPanel.Resources.Index.GallleryPhoto %></th>
                                        <th><%=AdminPanel.Resources.Index.GallleryPhoto %></th>
                                        <th><%=AdminPanel.Resources.Index.GallleryPhoto %></th>
                                        <th><%=AdminPanel.Resources.Index.GallleryPhoto %></th>
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
