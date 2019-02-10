<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNewPartner.aspx.cs" Inherits="AdminPanel.AddNewPartner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- content -->
    <section class="content">
        <% if (Prcs == Process.AddPartner || Prcs == Process.EditPartner)
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
                        <!-- text input -->
                        <div class="form-group">
                            <label><%=AdminPanel.Resources.Index.PartnerName %></label>
                            <input type="text" id="txtPartnerName" runat="server" class="form-control" placeholder="">
                        </div>
                        <div class="form-group">
                            <label><%=AdminPanel.Resources.Index.UploadPartnerLogo %></label>
                        </div>

                        <div id="imageuploading" runat="server" class="form-group">

                            <div class="col-lg-4 col-sm-6 col-xs-6 col-md-4">
                                <a href="javascript:void(0);" class="thumbnail">
                                    <img src="Content/img/plus.png" class="uploadImg" data-value="file1" id="img1" />
                                </a>
                            </div>

                            <input type="hidden" name="hid1" id="hid1" value="images/plus.png" />
                            <input type="file" data-value="img1" data-hidden="hid1" class="upload" id="file1" />
                            <script type="text/javascript">
                                $(".uploadImg").on("click", function () {
                                    var dataUpload = $(this).attr("data-value");
                                    $("#" + dataUpload).click();
                                });

                                $(".upload").on("change", function () {
                                    var fileUpload = $(this).get(0);
                                    var files = fileUpload.files;
                                    var datas = new FormData();
                                    for (var i = 0; i < files.length; i++) {
                                        datas.append(files[i].name, files[i]);
                                    }
                                    var dataImg = $(this).attr("data-value");
                                    var dataHidden = $(this).attr("data-hidden");
                                    $.ajax({
                                        url: "ajax/UploadService.ashx",
                                        method: "POST",
                                        data: datas,
                                        contentType: false,
                                        processData: false,
                                        success: function (result) {
                                            $("#" + dataImg).attr("src", result);
                                            $("#" + dataHidden).attr("value", result);
                                        },
                                        error: function (err) {
                                            alert(err);
                                        }

                                    });

                                });
                            </script>
                        </div>

                    </form>

                    <!-- /.box-body -->
                </div>
               
            </div>
             <div id="Viewingimages" runat="server" class="box-footer">
                    <div class="col-lg-3 col-sm-4 col-xs-6 col-md-4">
                        <asp:Image ID="image1" runat="server" Height="200px" Width="200px" ImageUrl="Content/img/plus.png" />
                         <div class="col-lg-3 col-sm-4 col-xs-6 col-md-4">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </div>
                    </div>
                   
                </div>
                <div id="uploadbuttondiv" runat="server" class="box-footer">
                    <p>
                        <asp:Button ID="BtnUpload" runat="server" class="btn btn-primary" Text="Upload" OnClick="BtnUpload_Click" />
                    </p>
                </div>
            <div class="box-footer">
                <input type="button" runat="server" class="btn btn-primary" id="btnUpdate" onserverclick="BtnUpdate_ServerClick" name="name" value='Save' />

                <input type="button" runat="server" class="btn btn-primary" id="btnClear" onserverclick="BtnClear_ServerClick" name="name" value='Clear' />
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





