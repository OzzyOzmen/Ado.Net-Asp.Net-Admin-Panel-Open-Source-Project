<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" ValidateRequest="false"  CodeBehind="AddNewsPage.aspx.cs" Inherits="AdminPanel.AddNewsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <!-- content -->
    <section class="content">
        <% if (Prcs == Process.AddNews || Prcs == Process.EditNews)
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
                                    <img src="Content/img/turkish.png" style="width: 25px; height: 25px" />&nbsp;<asp:Label Text="Turkish" ID="lblturkish" runat="server" /></a></li>
                                <li><a href="#İngilizce" data-toggle="tab">
                                    <img src="Content/img/english.png" style="width: 25px; height: 25px" />&nbsp;<asp:Label Text="English" ID="lblenglish" runat="server" /></a></li>
                            </ul>
                            <div class="tab-content">
                                <div class="active tab-pane" id="Türkçe">
                                    <!-- Türkçe -->
                                    <ul>

                                        <div class="form-group">
                                            <label><%=AdminPanel.Resources.Index.TurkishNewsTitle %></label>
                                            <input type="text" id="txtTurkishTitle" runat="server" class="form-control" placeholder="">
                                        </div>
                                        <div class="form-group">
                                            <label><%=AdminPanel.Resources.Index.TurkishNewsContent %> </label>
                                            <textarea class="form-control" id="txtturkish" runat="server" rows="3" placeholder=""></textarea>
                                        </div>

                                        <!-- END Türkçe -->
                                    </ul>
                                </div>
                                <!-- /.tab-pane -->
                                <div class="tab-pane" id="İngilizce">
                                    <!-- The İngilizces -->
                                    <ul>

                                        <div class="form-group">
                                            <label><%=AdminPanel.Resources.Index.EnglishNewsTitle %></label>
                                            <input type="text" id="txtEnglishTitle" runat="server" class="form-control" placeholder="">
                                        </div>

                                        <div class="form-group">
                                            <label><%=AdminPanel.Resources.Index.EnglishNewsContent %></label>
                                            <textarea class="form-control" id="txtenglish" runat="server" rows="3" placeholder=""></textarea>
                                        </div>

                                        <!-- END İngilizces item -->

                                    </ul>
                                </div>
                            </div>
                        </div>
                        <!--- Tab Bitiş ----->
                        <div class="form-group">
                            <label><%=AdminPanel.Resources.Index.NewsDate %></label>
                            <input type="text" id="txtNewsDate" runat="server" class="form-control" placeholder="">
                         
                        </div>
                         <div class="form-group">
                            <label><%=AdminPanel.Resources.Index.NewsImage %></label>
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
