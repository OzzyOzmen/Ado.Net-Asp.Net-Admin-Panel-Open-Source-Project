<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProfileSettings.aspx.cs" Inherits="AdminPanel.ProfileSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <!-- content -->
    <section class="content">

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
                            <asp:Label Text="text" ID="lblid" runat="server" Visible="false" />                            
                             <label><%=AdminPanel.Resources.Index.UserName %></label>
                            <input type="text" id="txtUserName" runat="server" class="form-control" placeholder="" required>
                        </div>
                        <div class="form-group">
                            <label><%=AdminPanel.Resources.Index.Password %></label>
                            <input type="text" id="txtPassword" runat="server" class="form-control" placeholder="" required>
                        </div>
                        <div class="form-group">
                            <label><%=AdminPanel.Resources.Index.ConfirmPassword %></label>
                            <input type="text" id="txtConfirmPassword" runat="server" class="form-control" placeholder="" required>
                        </div>
                        <div class="form-group">
                            <label><%=AdminPanel.Resources.Index.NameSurname %></label>
                            <input type="text" id="txtNameSurname" runat="server" class="form-control" placeholder="" required>
                        </div>
                        <div class="form-group">
                            <label><%=AdminPanel.Resources.Index.Email %></label>
                            <input type="text" id="txtEmail" runat="server" class="form-control" placeholder="" required>
                        </div>
                        <div class="form-group">
                            <label><%=AdminPanel.Resources.Index.UserRole %></label>
                             <asp:DropDownList ID="ddlYetki" runat="server" class="form-control select2" data-placeholder="Choose Role">
                                <asp:ListItem Selected="True">Lütfen Seçiniz</asp:ListItem>
                                <asp:ListItem Enabled="False"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label><%=AdminPanel.Resources.Index.ProfilePhoto %></label>                          
                        </div>
                        <div class="box-footer">
                            <div class="col-lg-3 col-sm-4 col-xs-6 col-md-4">
                                <asp:Image ID="image1" runat="server" Height="200px" Width="200px" ImageUrl="Content/img/plus.png" />
                                <div class="col-lg-3 col-sm-4 col-xs-6 col-md-4">
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </div>
                            </div>

                        </div>
                        <asp:Label ID="Label1" runat="server" Text="DİKKAT !!! DEMO AMAÇLI GÖSTERİM OLDUĞU İÇİN PROFİL BİLGİLRİ ÜNCELLEME OLAYINI DEVRE DIŞI BIRAKTIM." ForeColor="Red" Font-Size="Larger" Font-Bold="true"></asp:Label>
                    </form>

                    <!-- /.box-body -->
                </div>

            </div>

            <div class="box-footer">
                <input type="button" runat="server" class="btn btn-primary" id="btnUpdate" onserverclick="BtnUpdate_ServerClick" name="name" value='Save' />

                <input type="button" runat="server" class="btn btn-primary" id="btnClear" onserverclick="BtnClear_ServerClick" name="name" value='Clear' />
            </div>

            <!-- /.box -->
        </div>

        <div id="hata"><%= Error1 %></div>

        <script type="text/javascript">
            $("<%= btnUpdate.ClientID %>").on("click", function () {
                $(".kontrol").each(function (i) {
                    var val = $(this).val();
                    if (val == "") {
                        $(this).css("border", "1px solid red");
                    }
                });
            });
        </script>
    </section>
    <!-- /content -->


</asp:Content>
