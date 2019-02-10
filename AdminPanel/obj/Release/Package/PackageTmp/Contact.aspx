<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="AdminPanel.Contact" %>
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
                        
                        <div class="row List_satirlar">
                            <table id="example2" class="table table-bordered table-hover">

                                <thead>
                                    <tr>
                                        <th>ID No</th>
                                        <th><%=AdminPanel.Resources.Index.SenderName %></th>
                                        <th><%=AdminPanel.Resources.Index.ContactMessage %></th>
                                        <th><%=AdminPanel.Resources.Index.Actions %></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%foreach (var item in contacts)

                                        {

                                    %>

                                    <tr>
                                        <td><%=item.id %></td>
                                        <td><%=item.SenderName  %></td>
                                        <td><%# (Eval("ContactMessage").ToString().Length > 40) ? Eval("ContactMessage").ToString().Substring(0,40) : Eval("ContactMessage").ToString() %>...
                                        </td>
                                        <td>
                                            <div class="col-lg-2 col-md-2 col-sm-1">
                                                <p><a href="/ViewContactMessage.aspx?Process=ViewContact&id=<%= item.id %>"><%= AdminPanel.Resources.Index.ViewContact %></a></p>
                                            </div>
                                          
                                        </td>
                                    </tr>
                                    <%} %>
                                </tbody>
                                <tfoot>
                                    <tr>
                                         <th>ID No</th>
                                        <th><%=AdminPanel.Resources.Index.SenderName %></th>
                                        <th><%=AdminPanel.Resources.Index.ContactMessage %></th>
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
             </div>
            <!-- /.row -->
    </section>
    <!-- /content -->


</asp:Content>
