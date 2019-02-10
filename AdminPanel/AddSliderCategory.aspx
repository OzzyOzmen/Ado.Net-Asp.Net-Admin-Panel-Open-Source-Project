<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSliderCategory.aspx.cs" Inherits="AdminPanel.AddSliderCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- content -->
    <section class="content">
        <% if (Prcs == Process.AddCategoryName || Prcs == Process.EditCategoryName)
            {

        %>
        <!-- Default box -->
        <div class="box">
            <div class="box-body">
                <!-- general form elements disabled -->
                <div class="box-header with-border">
                    <h3 class="box-title"><%=PageTitle %></h3>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <form role="form">

                        <!--- Tab Başlangıç ----->
                        <div class="nav-tabs-custom">
                            <ul class="nav nav-tabs">
                                <li class="active"><a href="#Türkçe" data-toggle="tab">
                                    <img src="Content/img/turkish.png" style="width: 25px; height: 25px" />&nbsp;<%=AdminPanel.Resources.Index.Turkish %></a></li>
                                <li><a href="#İngilizce" data-toggle="tab">
                                    <img src="Content/img/english.png" style="width: 25px; height: 25px" />&nbsp;<%=AdminPanel.Resources.Index.English %></a></li>
                            </ul>
                            <div class="tab-content">
                                <div class="active tab-pane" id="Türkçe">
                                    <!-- Türkçe -->
                                    <ul>
                                        <div class="form-group">
                                            <label><%=AdminPanel.Resources.Index.CategoryNameTR %></label>
                                            <input type="text" id="txtCategoryNameTR" runat="server" class="form-control" placeholder="">
                                        </div>
                                        <!-- END Türkçe -->
                                    </ul>
                                </div>
                                <!-- /.tab-pane -->
                                <div class="tab-pane" id="İngilizce">
                                    <!-- The İngilizces -->
                                    <ul>
                                        <div class="form-group">
                                            <label><%=AdminPanel.Resources.Index.CategoryNameEN %></label>
                                            <input type="text" id="txtCategoryNameEN" runat="server" class="form-control" placeholder="">
                                        </div>
                                        <!-- END İngilizces item -->
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <!--- Tab Bitiş ----->



                        <div class="box-footer">
                            <input type="button" runat="server" class="btn btn-primary" id="btnUpdate" onserverclick="BtnUpdate_ServerClick" name="name" value='Save' />

                            <input type="button" runat="server" class="btn btn-primary" id="btnClear" onserverclick="BtnClear_ServerClick" name="name" value='Clear' />
                        </div>
                        <!-- /.box-body -->
                </div>

            </div>
            <!-- /.box -->
            <!-- Default box -->
            <div class="box">
                <div class="box-body">
                    <!-- general form elements disabled -->
                    <div class="box-header with-border">
                        <h3 class="box-title"><%=AdminPanel.Resources.Index.SliderCategoryList %></h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <table id="example2" class="table table-bordered table-hover">
                            <%
                                var test = HttpContext.Current.Request.Cookies["locale"].Value.ToString();

                                var a = test;
                            %>
                            <thead>
                                <tr>
                                    <th>ID No</th>
                                    <th><%=AdminPanel.Resources.Index.CategoryName %></th>
                                    <th><%=AdminPanel.Resources.Index.Actions %></th>
                                </tr>
                            </thead>
                            <tbody>
                                <%foreach (var item in slidercategoriess)

                                    {


                                %>

                                <tr>
                                    <%if (test == "tr-TR")
                                        {

                                    %>
                                    <td><%=item.id %></td>
                                    <td><%=item.SliderCategoryNameTR  %></td>
                                    <%} %>
                                    <% 
                                        else if (test == "en-US")
                                        {%>
                                    <td><%=item.id %></td>
                                    <td><%=item.SliderCategoryNameEN  %></td>
                                    <%} %>
                                    <td>
                                        <div class="col-lg-2 col-md-2 col-sm-1">
                                            <p><a href="/AddSliderCategory.aspx?Process=EditCategoryName&id=<%= item.id %>"><%= AdminPanel.Resources.Index.Edit %></a></p>
                                            <p><a href="/AddSliderCategory.aspx?Process=DeleteCategoryName&id=<%= item.id %>"><%= AdminPanel.Resources.Index.Delete %></a></p>
                                        </div>

                                        <%--<asp:LinkButton runat="server" ID="btnEdit" href="/AddNewPartners.aspx?Process=EditPartner&id=<%= item.id %>" CssClass="btn btn-success"><%= AdminPanel.Resources.Index.Edit %></asp:LinkButton>
                                            <asp:LinkButton runat="server" ID="btnDelete" href="/AddNewPartners.aspx?process=DeletePartner&id=<%= item.id %>" CssClass="btn btn-danger"><%= AdminPanel.Resources.Index.Delete %></asp:LinkButton>--%>
                                    </td>
                                </tr>
                                <%} %>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <th>ID No</th>
                                    <th><%=AdminPanel.Resources.Index.CategoryName %></th>
                                    <th><%=AdminPanel.Resources.Index.Actions %></th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                    <!-- /.box-body -->
                </div>
            </div>
        </div>
        <%} %>
    </section>
    <!-- /content -->

</asp:Content>

