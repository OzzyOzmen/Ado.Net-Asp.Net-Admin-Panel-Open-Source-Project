<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ServicesList.aspx.cs" Inherits="AdminPanel.ServicesList" %>

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
                                        <th><%=AdminPanel.Resources.Index.ServiceName %></th>
                                        <th><%=AdminPanel.Resources.Index.ServiceDescription %></th>
                                        <th><%=AdminPanel.Resources.Index.Actions %></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%foreach (var item in servicess)

                                        {

                                    %>

                                    <tr>
                                        <td><%=item.id %></td>
                                        <%if (test == "tr-TR")
                                            {

                                        %>                                     
                                        <td><%=item.ServiceTitleTR  %></td>
                                        <td><%# (Eval("ServiceDescriptionTR").ToString().Length > 40) ? Eval("ServiceDescriptionTR").ToString().Substring(0,40) : Eval("ServiceDescriptionTR").ToString() %>...
                                        </td>
                                        <%} %>
                                        <% 
                                            else if (test == "en-US")
                                            {%>
                                       
                                        <td><%=item.ServiceTitleEN  %></td>
                                        <td><%# (Eval("ServiceDescriptionEN").ToString().Length > 40) ? Eval("ServiceDescriptionEN").ToString().Substring(0,40) : Eval("ServiceDescriptionEN").ToString() %>...
                                        </td>
                                        <%} %>
                                        <td>
                                            <div class="col-lg-2 col-md-2 col-sm-1">
                                                <p><a href="/AddNewService.aspx?Process=EditService&id=<%= item.id %>"><%= AdminPanel.Resources.Index.Edit %></a></p>
                                                <p><a href="/AddNewService.aspx?process=DeleteService&id=<%= item.id %>"><%= AdminPanel.Resources.Index.Delete %></a></p>
                                            </div>
                                        </td>
                                    </tr>
                                    <%} %>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th>ID No</th>
                                        <th><%=AdminPanel.Resources.Index.ServiceName %></th>
                                        <th><%=AdminPanel.Resources.Index.ServiceDescription %></th>
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
