<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReferenceList.aspx.cs" Inherits="AdminPanel.ReferenceList" %>

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
                                        <th><%=AdminPanel.Resources.Index.ReferenceName %></th>
                                        <th><%=AdminPanel.Resources.Index.ReferenceCategory %></th>
                                        <th><%=AdminPanel.Resources.Index.ReferenceDescription %></th>
                                        <th><%=AdminPanel.Resources.Index.ReferenceLogo %></th>
                                        <th><%=AdminPanel.Resources.Index.Actions %></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%foreach (var item in referencess)

                                        {
                                             Image1.ImageUrl = item.RefereneLogo.ToString();

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
                                        <td><%=item.TurkishReferenceName  %></td>
                                        <td><%=item.ReferenceCategory  %></td>
                                        <td><%# (Eval("ReferenceDescriptionTR").ToString().Length > 40) ? Eval("ReferenceDescriptionTR").ToString().Substring(0,40) : Eval("ReferenceDescriptionTR").ToString() %>...
                                        </td>
                                        <%} %>
                                        <% 
                                            else if (test == "en-US")
                                            {%>
                                        <td><%=item.id %></td>
                                        <td><%=item.EnglishReferenceName  %></td>
                                        <td><%=item.ReferenceCategory  %></td>
                                        <td><%# (Eval("ReferenceDescriptionEN").ToString().Length > 40) ? Eval("ReferenceDescriptionEN").ToString().Substring(0,40) : Eval("ReferenceDescriptionEN").ToString() %>...
                                        </td>
                                        <%} %>

                                        <td>
                                            <asp:Image ID="Image1" runat="server" Width="50px" Height="50px" ImageUrl="" />

                                        </td>
                                        <td>
                                            <div class="col-lg-2 col-md-2 col-sm-1">
                                                <p><a href="/AddNewReference.aspx?Process=EditReference&id=<%= item.id %>"><%= AdminPanel.Resources.Index.Edit %></a></p>
                                                <p><a href="/AddNewReference.aspx?Process=DeleteReference&id=<%= item.id %>"><%= AdminPanel.Resources.Index.Delete %></a></p>
                                            </div>
                                        </td>
                                    </tr>
                                    <%} %>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th>ID No</th>
                                        <th><%=AdminPanel.Resources.Index.ReferenceName %></th>
                                        <th><%=AdminPanel.Resources.Index.ReferenceCategory %></th>
                                        <th><%=AdminPanel.Resources.Index.ReferenceDescription %></th>
                                        <th><%=AdminPanel.Resources.Index.ReferenceLogo %></th>
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
