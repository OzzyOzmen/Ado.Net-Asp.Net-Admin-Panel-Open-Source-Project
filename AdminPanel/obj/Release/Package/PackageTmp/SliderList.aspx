<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SliderList.aspx.cs" Inherits="AdminPanel.SlidersList" %>

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
                                        <th><%=AdminPanel.Resources.Index.SliderName %></th>
                                        <th><%=AdminPanel.Resources.Index.SliderCategory %></th>
                                        <th><%=AdminPanel.Resources.Index.SliderPhoto %></th>
                                        <th><%=AdminPanel.Resources.Index.SliderPhoto %></th>
                                        <th><%=AdminPanel.Resources.Index.SliderPhoto %></th>
                                        <th><%=AdminPanel.Resources.Index.SliderPhoto %></th>
                                        <th><%=AdminPanel.Resources.Index.Actions %></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%foreach (var item in sliderss)

                                        {
                                            Image1.ImageUrl = item.SliderPhoto1.ToString();
                                            Image2.ImageUrl = item.SliderPhoto2.ToString();
                                            Image3.ImageUrl = item.SliderPhoto3.ToString();
                                            Image4.ImageUrl = item.SliderPhoto4.ToString();

                                            if (Image1.ImageUrl == "" && Image2.ImageUrl == "" && Image3.ImageUrl == "" && Image4.ImageUrl == "" )
                                            {
                                                Image1.ImageUrl = "~\\Content\\img\\resimyok.png";
                                                Image2.ImageUrl = "~\\Content\\img\\resimyok.png";
                                                Image3.ImageUrl = "~\\Content\\img\\resimyok.png";
                                                Image4.ImageUrl = "~\\Content\\img\\resimyok.png";
                                            }

                                    %>

                                    <tr>
                                    <tr>
                                        <%if (test == "tr-TR")
                                            {

                                        %>
                                        <td><%=item.id %></td>
                                        <td><%=item.SliderNameTR  %></td>
                                        <td><%=item.SliderCategory  %></td>
                                        <%} %>
                                        <% 
                                            else if (test == "en-US")
                                            {%>
                                        <td><%=item.id %></td>
                                        <td><%=item.SliderNameEN  %></td>
                                        <td><%=item.SliderCategory  %></td>
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
                                                <p><a href="/AddNewSlider.aspx?Process=EditSlider&id=<%= item.id %>"><%= AdminPanel.Resources.Index.Edit %></a></p>
                                                <p><a href="/AddNewSlider.aspx?Process=DeleteSlider&id=<%= item.id %>"><%= AdminPanel.Resources.Index.Delete %></a></p>
                                            </div>
                                        </td>
                                    </tr>
                                    <%} %>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th>ID No</th>
                                        <th><%=AdminPanel.Resources.Index.SliderName %></th>
                                        <th><%=AdminPanel.Resources.Index.SliderCategory %></th>
                                        <th><%=AdminPanel.Resources.Index.SliderPhoto %></th>
                                        <th><%=AdminPanel.Resources.Index.SliderPhoto %></th>
                                        <th><%=AdminPanel.Resources.Index.SliderPhoto %></th>
                                        <th><%=AdminPanel.Resources.Index.SliderPhoto %></th>
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
