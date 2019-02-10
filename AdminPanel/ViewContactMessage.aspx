<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewContactMessage.aspx.cs" Inherits="AdminPanel.ViewContactMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- content -->
    <section class="content">
        <% if (Prcs == Process.ViewContact)
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


                        <div class="form-group">
                            <label><%=AdminPanel.Resources.Index.SenderName %></label>
                            <input type="text" id="txtSenderName" runat="server" class="form-control" placeholder="">
                        </div>
                        <div class="form-group">
                            <label><%=AdminPanel.Resources.Index.ContactMessage %> </label>
                            <textarea class="form-control" id="txtContactMessage" runat="server" rows="3" placeholder=""></textarea>
                        </div>

                    </form>

                    <!-- /.box-body -->
                </div>

            </div>


            <!-- /.box -->
        </div>
        <% }
            else if (Prcs == Process.DataNotFound)
            {
        %>
        <div class="row">
            <div><%= AdminPanel.Resources.Index.Thedatayouarelookingforcouldntfind %>.</div>

        </div>
        <% } %>
    </section>
    <!-- /content -->


</asp:Content>

