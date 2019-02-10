<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="AdminPanel.NewsList" %>

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
                                        <th><%=AdminPanel.Resources.Index.TurkishNewsTitle %></th>
                                        <th><%=AdminPanel.Resources.Index.TurkishNewsContent %></th>
                                        <th><%=AdminPanel.Resources.Index.NewsDate %></th>
                                        <th><%=AdminPanel.Resources.Index.NewsImage %></th>
                                        <th><%=AdminPanel.Resources.Index.Actions %></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%foreach (var item in newss)

                                        {
                                             Image1.ImageUrl = item.NewsImage.ToString();

                                            if (Image1.ImageUrl == "")
                                            {
                                                Image1.ImageUrl = "~\\Content\\img\\resimyok.png";
                                            }

                                    %>

                                    <tr>
                                        <%if (test == "tr-TR")
                                            {

                                        %>
                                        <td><%=item.id %></td>
                                        <td><%=item.NewsTitleTR  %></td>
                                        <td><%# (Eval("TurkishNewsContentTR").ToString().Length > 40) ? Eval("TurkishNewsContentTR").ToString().Substring(0,40) : Eval("TurkishNewsContentTR").ToString() %>...
                                        </td>
                                        <td><%=item.NewsDate  %></td>
                                        <%} %>
                                        <% 
                                            else if (test == "en-US")
                                            {%>

                                        <td><%=item.id %></td>
                                        <td><%=item.NewsTitleEN  %></td>
                                        <td><%# (Eval("TurkishNewsContentEN").ToString().Length > 40) ? Eval("TurkishNewsContentEN").ToString().Substring(0,40) : Eval("TurkishNewsContentEN").ToString() %>...
                                        </td>
                                        <td><%=item.NewsDate  %></td>
                                        <%} %>
                                        <td>
                                            <asp:Image ID="Image1" runat="server" Width="50px" Height="50px" ImageUrl="" />

                                        </td>
                                        <td>
                                            <div class="col-lg-2 col-md-2 col-sm-1">
                                                <p><a href="/AddNewsPage.aspx?Process=EditNews&id=<%= item.id %>"><%= AdminPanel.Resources.Index.Edit %></a></p>
                                                <p><a href="/AddNewsPage.aspx?Process=DeleteNews&id=<%= item.id %>"><%= AdminPanel.Resources.Index.Delete %></a></p>
                                            </div>
                                        </td>
                                    </tr>
                                    <%} %>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th>ID No</th>
                                        <th><%=AdminPanel.Resources.Index.TurkishNewsTitle %></th>
                                        <th><%=AdminPanel.Resources.Index.TurkishNewsContent %></th>
                                        <th><%=AdminPanel.Resources.Index.NewsDate %></th>
                                        <th><%=AdminPanel.Resources.Index.NewsImage %></th>
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

