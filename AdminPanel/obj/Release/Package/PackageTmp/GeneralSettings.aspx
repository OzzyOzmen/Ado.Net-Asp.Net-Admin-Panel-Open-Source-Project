<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GeneralSettings.aspx.cs" Inherits="AdminPanel.GeneralSettings" %>

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
                            <label><%=AdminPanel.Resources.Index.CompanyName %></label>
                            <input type="text" id="txtCompanyName" runat="server" class="form-control" placeholder="" required>
                        </div>
                        <div class="form-group">
                            <label><%=AdminPanel.Resources.Index.Keywords %></label>
                            <input type="text" id="txtKeywords" runat="server" class="form-control" placeholder="" required>
                        </div>
                        <div class="form-group">
                            <label><%=AdminPanel.Resources.Index.SiteURL %></label>
                            <input type="text" id="txtSiteURL" runat="server" class="form-control" placeholder="" required>
                        </div>
                        <div class="form-group">
                            <label><%=AdminPanel.Resources.Index.CompanyEmail %></label>
                            <input type="text" id="txtCompanyEmail" runat="server" class="form-control" placeholder="" required>
                        </div>
                        <div class="form-group">
                            <label><%=AdminPanel.Resources.Index.CompanyPhone %></label>
                            <input type="text" id="txtCompanyPhone" runat="server" class="form-control" placeholder="" required>
                        </div>
                        <div class="form-group">
                            <label><%=AdminPanel.Resources.Index.CompanyAddress %></label>
                            <input type="text" id="txtCompanyAddress" runat="server" class="form-control" placeholder="" required>
                        </div>
                        <div class="form-group">
                            <label><%=AdminPanel.Resources.Index.WeekdaysWorkingHours %></label>
                            <input type="text" id="txtWeekdaysWorkingHours" runat="server" class="form-control" placeholder="" required>
                        </div>
                        <div class="form-group">
                            <label><%=AdminPanel.Resources.Index.WeekendWorkingHours %></label>
                            <input type="text" id="txtWeekendWorkingHours" runat="server" class="form-control" placeholder="" required>
                        </div>
                        <div class="form-group">
                            <label><%=AdminPanel.Resources.Index.Copyright %></label>
                            <input type="text" id="txtCopyright" runat="server" class="form-control" placeholder="" required>
                        </div>
                        <div class="form-group">
                            <label><%=AdminPanel.Resources.Index.CompanyFacebook %></label>
                            <input type="text" id="txtCompanyFacebook" runat="server" class="form-control" placeholder="" required>
                        </div>
                        <div class="form-group">
                            <label><%=AdminPanel.Resources.Index.CompanyTwitter %></label>
                            <input type="text" id="txtCompanyTwitter" runat="server" class="form-control" placeholder="" required>
                        </div>
                        <div class="form-group">
                            <label><%=AdminPanel.Resources.Index.CompanyLinkedin %></label>
                            <input type="text" id="txtCompanyLinkedin" runat="server" class="form-control" placeholder="" required>
                        </div>
                        <div class="form-group">
                            <label><%=AdminPanel.Resources.Index.CompanySkype %></label>
                            <input type="text" id="txtCompanySkype" runat="server" class="form-control" placeholder="" required>
                        </div>
                        <div class="form-group">
                            <label><%=AdminPanel.Resources.Index.SiteStution %></label>
                        </div>
                        <div class="form-group">
                            <label>
                                <input type="radio" id="chkopen" runat="server" name="r3" class="flat-red" checked>
                                <label><%=AdminPanel.Resources.Index.Open %></label>
                            </label>
                            <label>
                                <input type="radio" id="chkclose" runat="server" name="r3" class="flat-red">
                                <label><%=AdminPanel.Resources.Index.Close %></label>
                            </label>
                        </div>

                       <div class="box-footer">
                            <div class="col-lg-3 col-sm-4 col-xs-6 col-md-4">
                                <asp:Image ID="image1" runat="server" Height="200px" Width="200px" ImageUrl="Content/img/plus.png" />
                                <div class="col-lg-3 col-sm-4 col-xs-6 col-md-4">
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </div>
                            </div>

                        </div>
                        
                    </form>

                    <!-- /.box-body -->
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
