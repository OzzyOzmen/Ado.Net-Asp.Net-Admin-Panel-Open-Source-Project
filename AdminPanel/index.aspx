<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AdminPanel.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Default box -->
    <section class="content">
        <div class="box">
            <div class="box-body">
                <!-- general form elements disabled -->
                <div class="box-header with-border">
                    <h3 class="box-title"><%=AdminPanel.Resources.Index.AspNetAdminPanelOnSale %></h3>
                </div>
                <!-- /.box-header -->
                <div class="box-body">
                    <form role="form">



                        <div class="form-group">
                            <label>Fiyatı</label>

                            <p><asp:Label ID="lbluyari" runat="server" Text="" ForeColor="Red" Font-Size="Larger" Font-Bold="true"></asp:Label></p>
                            <p>500 TL</p>
                            <p>Bu Admin Panel sitesi scripti satılıktır ve backend kısmı sıfır kodlamadır ve tamamen bana aittir.</p>
                            <p>Bu script Asp.Net dili ile yazılmıştır ve ayrıca responsive dir.</p>
                            <p>Site Türkçe ve İngilizce olarak iki dilde kodlanmıştır fakat başka diller de ekletebilirsiniz.</p>
                            <p>Kayıtlar iki dilde eklenmektedir.</p>
                            <p>Dil ekletme fiyatı ise dil başına eğer çeviri sizden ise 50 TL ama çeviride bize ait olursa 100 TL dir.</p>
                            <p>Benim bilgim dahili dışında kullanılması, satılması ve çoğaltılması suçtur.</p>

                        </div>
                        <div class="form-group">
                            <label>Neden Satın Almalıyım ?</label>


                            <p>Şöyle düşünün bir firmanız var ve kurumsal müşterileriniz için websiteler tasarlıyorsunuz.</p>
                            <p>Yada kendi firmanız için kurumsal site yazacaksınız</p>
                            <p>Herseferinde yeniden admin paneli tasarlayıp kodlamak yada başkalarına ücretli yaptırmak sizcede büyük zahmet ve külfet değil mi?  </p>
                            <p>İşte tam burada sırtınızdaki yükü azaltmak için bu yazdığım Admin paneli devreye giiyor </p>
                            <p>Bütün kurumsal sitelerin yapıları aynı olduğu için bu admin paneli ile bütün ihtiyaçlarınızı karşılayabileceğinizden emin olabilirsiniz.  </p>

                        </div>
                        <div class="form-group">
                            <label>Peki sıfır kodlama ise neden bu kadar ucuz ? ?</label>

                            <p>Çünkü önceliğim herzamanki gibi müşteri memnuniyeti benim için ön planda.</p>


                        </div>
                </div>

                <div class="box-footer">
                    <label>iletişim Bilgileri</label>

                    <p>Sadece satış amaçlı ulaşabileceğiniz adreslerim.</p>

                    <p>Linkedin : https://www.linkedin.com/in/ozmencelik/ </p>
                    <p>Facebook : https://www.facebook.com/OzmenOzzYCelik </p>

                </div>
                </form>


                    <!-- /.box-body -->
            </div>
        </div>
        <!-- /.box -->


    </section>
    <!-- /content -->


</asp:Content>



