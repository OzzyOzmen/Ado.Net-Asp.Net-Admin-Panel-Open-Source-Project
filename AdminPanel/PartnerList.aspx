<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PartnerList.aspx.cs" Inherits="AdminPanel.PartnerList" %>

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
                                
                                <thead>
                                    <tr>
                                        <th>ID No</th>
                                        <th><%=AdminPanel.Resources.Index.PartnerName %></th>
                                        <th><%=AdminPanel.Resources.Index.PartnerLogo %></th>
                                        <th><%=AdminPanel.Resources.Index.Actions %></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%foreach (var item in partnerss)

                                        {
                                             Image1.ImageUrl = item.PartnerLogo.ToString();

                                            if (Image1.ImageUrl == "")
                                            {
                                                Image1.ImageUrl = "~\\Content\\img\\resimyok.png";
                                            }

                                    %>

                                    <tr>
                                        <td><%=item.id %></td>
                                        <td><%=item.PartnerName  %></td>
                                         <td>
                                             <asp:Image ID="Image1" runat="server" Width="50px" Height="50px" ImageUrl="" /> 

                                         </td>
                                        <td>
                                            <div class="col-lg-2 col-md-2 col-sm-1">
                                                <p><a href="/AddNewPartner.aspx?Process=EditPartner&id=<%= item.id %>"><%= AdminPanel.Resources.Index.Edit %></a></p>
                                                <p><a href="/AddNewPartner.aspx?Process=DeletePartner&id=<%= item.id %>"><%= AdminPanel.Resources.Index.Delete %></a></p>
                                            </div>
                                        </td>
                                    </tr>
                                    <%} %>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th>ID No</th>
                                        <th><%=AdminPanel.Resources.Index.PartnerName %></th>
                                        <th><%=AdminPanel.Resources.Index.PartnerLogo %></th>
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
