<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PagesList.aspx.cs" Inherits="AdminPanel.PagesList" %>

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
                                        <th><%=AdminPanel.Resources.Index.PageTitle %></th>                                       
                                        <th><%=AdminPanel.Resources.Index.PageContent %></th>
                                         <th><%=AdminPanel.Resources.Index.PageUrl %></th>
                                        <th><%=AdminPanel.Resources.Index.Actions %></th>

                                    </tr>
                                </thead>
                                <tbody>

                                    <%foreach (var item in pages)
                                        {
                                    %>

                                    <tr>
                                         <td><%=item.id %></td>

                                        <%if (test == "tr-TR")
                                            {

                                        %>
                                       
                                        <td><%=item.PageTitleTR  %></td>                                       
                                        <td><%# (Eval("PageContentTR").ToString().Length > 40) ? Eval("PageContentTR").ToString().Substring(0,40) : Eval("PageContentTR").ToString() %>...
                                        </td>                                      
                                        <%} %>
                                        <% 
                                            else if (test == "en-US")
                                            {%>
                                      
                                        <td><%=item.PageTitleEN  %></td>                                        
                                        <td><%# (Eval("PageContentEN").ToString().Length > 40) ? Eval("PageContentEN").ToString().Substring(0,40) : Eval("PageContentEN").ToString() %>...
                                        </td>                                       
                                            <%} %>
                                        
                                         <td><%=item.PageUrl  %></td>
                                        <td>
                                            <div class="col-lg-2 col-md-2 col-sm-1">
                                                <p><a href="/AddNewPage.aspx?Process=EditPage&id=<%= item.id %>"><%= AdminPanel.Resources.Index.Edit %></a></p>
                                                <p><a href="/AddNewPage.aspx?process=DeletePage&id=<%= item.id %>"><%= AdminPanel.Resources.Index.Delete %></a></p>
                                            </div>
                                               </td>

                                    </tr>
                                    <%} %>
                                </tbody>
                                <tfoot>
                                    <tr>

                                        <th>ID No</th>
                                        <th><%=AdminPanel.Resources.Index.PageTitle %></th>                                       
                                        <th><%=AdminPanel.Resources.Index.PageContent %></th>
                                         <th><%=AdminPanel.Resources.Index.PageUrl %></th>
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

